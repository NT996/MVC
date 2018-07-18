using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using IzdavackaKuca.Models;
using System.Data.Entity;
using IzdavackaKuca.ViewModels;

namespace IzdavackaKuca.Controllers
{
    public class MembersController : Controller
    {
        //Deklarisanje DbContext promenljive kako bi pristupili bazi
        private ApplicationDbContext _context;

        //Pravljenje konstruktora
        public MembersController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult New()
        {
            var status = _context.Statuses.ToList();
            var viewModel = new MemberFormViewModel
            {
                Statuses = status
            };
            return View("MemberForm", viewModel);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Save(Member member)
        {
            if (member.ID == 0)
                _context.Members.Add(member);
            else
            {
                var memberInDb = _context.Members.Single(n => n.ID == member.ID);
                memberInDb.Name = member.Name;
                memberInDb.Surname = member.Surname;
                memberInDb.Email = member.Email;
                memberInDb.Address = member.Address;
                memberInDb.DateofBirth = member.DateofBirth;
                memberInDb.PlaceOfBIrth = member.PlaceOfBIrth;
                memberInDb.StatusID = member.StatusID;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Members");
        }

        public ViewResult Index()
        {
            var members = _context.Members.Include(c => c.Status).ToList();

            return View(members);
        }

        public ActionResult Details(int id)
        {
            var member = _context.Members.SingleOrDefault(c => c.ID == id);

            if (member == null)
                return HttpNotFound();

            return View(member);
        }

        public ActionResult Edit(int id)
        {
            var member = _context.Members.SingleOrDefault(c => c.ID == id);
            if (member == null)
            {
                HttpNotFound();
            }
            var viewModel = new MemberFormViewModel
            {
                Member = member,
                Statuses = _context.Statuses.ToList()
            };
            return View("MemberForm", viewModel);
        }
    }
}