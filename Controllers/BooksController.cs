using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using IzdavackaKuca.Models;
using System.Data.Entity;
using IzdavackaKuca.ViewModels;

namespace IzdavackaKuca.Controllers
{
    public class BooksController : Controller
    {
        //Deklarisanje DbContext promenljive kako bi pristupili bazi
        private ApplicationDbContext _context;

        //Pravljenje konstruktora
        public BooksController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult New()
        {
            var genre = _context.Genres.ToList();
            var publisher = _context.Publishers.ToList();
            var viewModel = new BookFormViewModel
            {
                Genres = genre,
                Publishers = publisher

            };
            return View("BookForm", viewModel);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Save(Book book)
        {
            if (book.ID == 0)
                _context.Books.Add(book);
            else
            {
                var bookInDB = _context.Books.Single(n => n.ID == book.ID);
                bookInDB.Name = book.Name;
                bookInDB.Autor = book.Autor;
                bookInDB.OnSale = book.OnSale;
                bookInDB.Price = book.Price;
                bookInDB.YearofPublication = book.YearofPublication;
                bookInDB.NumberInStock = book.NumberInStock;
                bookInDB.GenreID = book.GenreID;
                bookInDB.PublisherID = book.PublisherID;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Books");
        }

        public ViewResult Index()
        {
            var books = _context.Books.Include(c => c.Genre).ToList();

            return View(books);
        }

        public ActionResult Details(int id)
        {
            var book = _context.Books.SingleOrDefault(c => c.ID == id);
            var genre = _context.Books.Include(g => g.Genre).SingleOrDefault(c => c.ID == id);

            if (book == null)
                return HttpNotFound();

            return View(book);
        }
        public ActionResult Edit(int id)
        {
            var book = _context.Books.SingleOrDefault(c => c.ID == id);
            if (book == null)
            {
                HttpNotFound();
            }
            var viewModel = new BookFormViewModel
            {
                Book = book,
                Genres = _context.Genres.ToList(),
                Publishers = _context.Publishers.ToList()
            };
            return View("BookForm", viewModel);
        }
    }
}