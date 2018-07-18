using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using IzdavackaKuca.Models;
using System.Data.Entity;
using IzdavackaKuca.ViewModels;

namespace IzdavackaKuca.Controllers
{
    public class BillsController : Controller
    {
        //Deklarisanje DbContext promenljive kako bi pristupili bazi
        private ApplicationDbContext _context;

        //Pravljenje konstruktora
        public BillsController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult New()
        {
            var books = _context.Books.ToList();
            var members = _context.Members.ToList();
            var viewModel = new BillFormViewModel
            {
                Bill = new Bill(), //Validacija - da bi se ID bio 0, jer je on skriveno (hidden) polje.
                Books = books,
                Members = members,
            };
            return View("BillForm", viewModel);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Save(Bill bill)
        {
            if (!ModelState.IsValid)
            {
                // Ako nije validan, vraćamo korisnika na formu.
                var viewModel = new BillFormViewModel()
                {
                    Members = _context.Members.ToList(),
                    Books = _context.Books.ToList()
                };
                return View("BillForm", viewModel);
            }
            if (bill.ID == 0)
                _context.Bills.Add(bill);
            else
            {
                var billInDb = _context.Bills.Single(c => c.ID == bill.ID);
                billInDb.MemberID = bill.MemberID;
                billInDb.BookID = bill.BookID;
                billInDb.IssuingDate = bill.IssuingDate;
                billInDb.Total = bill.Total;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Bills");
        }

        public ViewResult Index()
        {
            var bills = _context.Bills.Include(b => b.Book).Include(m => m.Members).ToList();

            return View(bills);
        }

        public ActionResult Details(int id)
        {
            var bill = _context.Bills.Include(b => b.Book).Include(m => m.Members).ToList();

            if (bill == null)
                return HttpNotFound();

            return View(bill);
        }

        public ActionResult Edit(int id)
        {
            var bill = _context.Bills.SingleOrDefault(c => c.ID == id);
            if (bill == null)
            {
                HttpNotFound();
            }
            var viewModel = new BillFormViewModel
            {
                Books = _context.Books.ToList(),
                Members = _context.Members.ToList(),
                Bill = bill
            };
            return View("BillForm", viewModel);
        }
    }
}