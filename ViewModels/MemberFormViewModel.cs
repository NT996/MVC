using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IzdavackaKuca.Models;

namespace IzdavackaKuca.ViewModels
{
    public class MemberFormViewModel
    {
        //U ovom novom modelu trebamo listu status
        public IEnumerable<Status> Statuses { get; set; }
        public Member Member { get; set; }
        public string Title
        {
            get
            {
                if (Member != null && Member.ID != 0)
                    return "Edit Member";
                    return "New Member";
            }
        }
    }
}