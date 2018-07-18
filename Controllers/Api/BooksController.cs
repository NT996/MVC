using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IzdavackaKuca.Models;
using IzdavackaKuca.Dtos;
using AutoMapper;

namespace IzdavackaKuca.Controllers.Api
{
    public class BooksController : ApiController
    {
        //Deklarisemo Dbcontext
        private ApplicationDbContext _context;

        public BooksController()
        {
            _context = new ApplicationDbContext();
        }

        //Get /api/books //all books-vracamo sve knjige iz baze
        public IEnumerable<BookDto> GetBooks()                                                                                   //Ovde umesto Member stavljamo BookDto
        {
            return _context.Books.ToList().Select(Mapper.Map<Book, BookDto>); //uzimamo membere iz baze i stavljamo u listu      //Sada je potrebno da mapiramo ovaj book objekat na BookDto koristeci metodu Select
        }

        //Get api/books/1 //get single book-uzimamo samo jednu knjigu na osnovu id
        public BookDto GetBook(int ID)
        {
            var book = _context.Books.SingleOrDefault(b => b.ID == ID);

            if (book == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return Mapper.Map<Book, BookDto>(book);                                                                               //Ubacujemo (book) objekat kao argument ovoj metodi
        }

        //Post /api/books
        [HttpPost]
        public BookDto CreateBook(BookDto bookDto)                                                                                //Menjamo ime iz Book u BookDto
        {
            if (!ModelState.IsValid) //da li su podaci ispravno uneti
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var book = Mapper.Map<BookDto, Book>(bookDto);                                                                        //Prvo uradimo rename (book u bookDto) a zatim kreiramo novi member objekat
            _context.Books.Add(book); //ukoliko su podaci pravilno uneti, dodaj novu knjigu
            _context.SaveChanges(); //i sacuvaj je
            bookDto.ID = book.ID;                                                                                                 //Ovaj book objekat takodje ima book ID koji je generisan od strane baze podataka
            return bookDto; //vrati objekat                                                                                       //I mi ga zatim dodajemo i vracamo ga korisniku
        }

        //Put /api/books/1 
        //radi se azuriranje knjige na osnovu njenog id-a iz url-a i drugog parametra koji (Book book) koji dolazi iz tela zahteva
        [HttpPut]
        public void UpdateBook(int ID, BookDto bookDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            //Uzimamo clana iz baze na osnovu njgeovog ID-a
            var bookInDB = _context.Books.SingleOrDefault(b => b.ID == ID);

            //Postoji mogucnost da korisnik prosledi pogresan ID pa moramo da proverimo to
            if (bookInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            //Ukoliko je sve dobro, onda se radi update
            Mapper.Map(bookDto, bookInDB);                                                                                         //Ubacivanjem ovog drugog argumenta (bookInDb) koga smo iscitali iz
                                                                                                                                   //var bookInDb = _context.Books.Single(n => n.ID == ID) nisu nam vise potrebne linije koda
            // Na kraju čuvamo izmene.                                                                                             //poput bookInDb.Name = bookInDb.Name itd....
            _context.SaveChanges();
        }

        //Delete /api/books/1 //Brisanje knjige
        [HttpDelete]
        public void DeleteBook(int ID)
        {
            //Uzimamo korisnika iz baze na osnovu njegovog ID-a
            var bookInDB = _context.Books.SingleOrDefault(b => b.ID == ID);

            //Postoji mogucnost da korisnik prosledi pogresan ID pa moramo da proverimo to
            if (bookInDB == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            //Sada se member brise iz memorije
            _context.Books.Remove(bookInDB);
            _context.SaveChanges();
        }
    }
}
