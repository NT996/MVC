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
    public class MembersController : ApiController
    {
        //Deklarisemo Dbcontext
        private ApplicationDbContext _context;

        public MembersController()
        {
            _context = new ApplicationDbContext();
        }

        //Get /api/members //all members-vracamo sve membere iz baze
        public IEnumerable<MemberDto> GetMembers()                                                                                   //Ovde umesto Member stavljamo MemberDto
        {                                                                                                           
            return _context.Members.ToList().Select(Mapper.Map<Member, MemberDto>); //uzimamo membere iz baze i stavljamo u listu    //Sada je potrebno da mapiramo ovaj member objekat na MemberDto koristeci metodu Select
        }

        //Get api/members/1 //get single member-uzimamo samo jednog membera na osnovu id
        public MemberDto GetMember(int ID)                                                                                           //Menjamo ime iz Member u MemberDto
        {
            var member = _context.Members.SingleOrDefault(m => m.ID == ID);

            if(member == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return Mapper.Map<Member, MemberDto>(member);                                                                             //Ubacujemo (member) objekat kao argument ovoj metodi
        }

        //Post /api/members
        [HttpPost]
        public MemberDto CreateMember(MemberDto memberDto)                                                                            //Menjamo ime iz Member u MemberDto
        {
            if(!ModelState.IsValid) //da li su podaci ispravno uneti
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var member = Mapper.Map<MemberDto, Member>(memberDto);                                                                    //Prvo uradimo rename (member u memberDto) a zatim kreiramo novi member objekat
                _context.Members.Add(member); //ukoliko su podaci pravilno uneti, dodaj novog membera
                _context.SaveChanges(); //i sacuvaj ga
            memberDto.ID = member.ID;                                                                                                 //Ovaj member objekat takodje ima member ID koji je generisan od strane baze podataka
            return memberDto; //vrati objekat                                                                                         //I mi ga zatim dodajemo i vracamo ga korisniku
        }

        //Put /api/members/1 
        //radi se azuriranje membera na osnovu njegovog id-a iz url-a i drugog parametra koji (Member member) koji dolazi iz tela zahteva
        [HttpPut]
        public void UpdateMember(int ID, MemberDto memberDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            //Uzimamo clana iz baze na osnovu njgeovog ID-a
            var memberInDb = _context.Members.Single(n => n.ID == ID);

            //Postoji mogucnost da korisnik prosledi pogresan ID pa moramo da proverimo to
            if (memberInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            //Ukoliko je sve dobro, onda se radi update
            Mapper.Map(memberDto, memberInDb);                                                                                      //Ubacivanjem ovog drugog argumenta (memberInDb) koga smo iscitali iz
                                                                                                                                    //var memberInDb = _context.Members.Single(n => n.ID == ID) nisu nam vise potrebne linije koda
            // Na kraju čuvamo izmene.                                                                                              //poput memberInDb.Name = memberDbo.Name itd....
            _context.SaveChanges();
        }

        //Delete /api/members/1 //Brisanje korisnika
        [HttpDelete]
        public void DeleteMember(int ID)
        {
            //Uzimamo korisnika iz baze na osnovu njegovog ID-a
            var memberInDb = _context.Members.SingleOrDefault(m => m.ID == ID);

            //Postoji mogucnost da korisnik prosledi pogresan ID pa moramo da proverimo to
            if (memberInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            //Sada se member brise iz memorije
            _context.Members.Remove(memberInDb);
            _context.SaveChanges();
        }
    }
}
