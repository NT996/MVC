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
    public class BillsController : ApiController
    {
        private ApplicationDbContext _context;

        public BillsController()
        {
            _context = new ApplicationDbContext();
        }

        //Get /api/bills //all bills-vracamo sve racune iz baze
        public IEnumerable<BillDto> GetBills()                                                                                        //Ovde umesto Bill stavljamo BillDto
        {
            return _context.Bills.ToList().Select(Mapper.Map<Bill, BillDto>); //uzimamo racune iz baze i stavljamo u listu            //Sada je potrebno da mapiramo ovaj bill objekat na BillDto koristeci metodu Select
        }

        //Get api/bills/1 //get single bill-uzimamo samo jedan racun na osnovu id
        public BillDto GetBill(int ID)                                                                                                //Menjamo ime iz Bill u BillDto
        {
            var bill = _context.Bills.SingleOrDefault(b => b.ID == ID);

            if (bill == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return Mapper.Map<Bill, BillDto>(bill);                                                                                    //Ubacujemo (bill) objekat kao argument ovoj metodi
        }

        //Post /api/bills
        [HttpPost]
        public BillDto CreateBill(BillDto billDto )                                                                                    //Menjamo ime iz Bill u BillDto
        {
            if (!ModelState.IsValid) //da li su podaci ispravno uneti
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var bill = Mapper.Map<BillDto, Bill>(billDto);                                                                              //Prvo uradimo rename (bill u billDto) a zatim kreiramo novi bill objekat
            _context.Bills.Add(bill); //ukoliko su podaci pravilno uneti, dodaj novi racun
            _context.SaveChanges(); //i sacuvaj ga
            billDto.ID = bill.ID;                                                                                                       //Ovaj bill objekat takodje ima bill ID koji je generisan od strane baze podataka
            return billDto; //vrati objekat                                                                                             //I mi ga zatim dodajemo i vracamo ga korisniku
        }

        //Put /api/bills/1 
        //radi se azuriranje racuna na osnovu njegovog id-a iz url-a i drugog parametra koji (Bill bill) koji dolazi iz tela zahteva
        [HttpPut]
        public void UpdateBill(int ID, BillDto billDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            //Uzimamo racun iz baze na osnovu njgeovog ID-a
            var billInDb = _context.Bills.Single(c => c.ID == ID);

            //Postoji mogucnost da korisnik prosledi pogresan ID pa moramo da proverimo to
            if (billInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            //Ukoliko je sve dobro, onda se radi update
            Mapper.Map(billDto, billInDb);                                                                                              //Ubacivanjem ovog drugog argumenta (billInDb) koga smo iscitali iz
                                                                                                                                        //var billInDb = _context.Bills.Single(n => n.ID == ID) nisu nam vise potrebne linije koda
            // Na kraju čuvamo izmene.                                                                                                  //poput billInDb.Name = billDto.Name itd....
            _context.SaveChanges();
        }

        //Delete /api/Bills/1 //Brisanje racuna
        [HttpDelete]
        public void DeleteBill(int ID)
        {
            //Uzimamo korisnika iz baze na osnovu njegovog ID-a
            var billInDb = _context.Bills.Single(c => c.ID == ID);

            //Postoji mogucnost da korisnik prosledi pogresan ID pa moramo da proverimo to
            if (billInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            //Sada se member brise iz memorije
            _context.Bills.Remove(billInDb);
            _context.SaveChanges();
        }
    }
}
