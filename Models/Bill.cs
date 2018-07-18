using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using IzdavackaKuca.Models;

namespace IzdavackaKuca.Models
{
    public class Bill
    {
        public int ID { get; set; }
        public Member Members { get; set; }
        [Display(Name = "Member")]
        [Required]
        public int MemberID { get; set; }
        public Book Book { get; set; }
        [Display(Name = "Book")]
        [Required]
        public int BookID { get; set; }
        [Required]
        public decimal Total { get; set; }
        [Display(Name = "Issuing Date")]
        [BillDate]
        public DateTime IssuingDate { get; set; }
    }
}