using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace IzdavackaKuca.Models
{
    //Kreiramo klasu Member i dodeljujemo atribute
    public class Member
    {
        public int ID { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        [Required]
        [StringLength(30)]
        public string Surname { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [Display (Name = "Date of birth")]
        public DateTime? DateofBirth { get; set; }
        [Required]
        [StringLength(20)]
        [Display(Name = "Place of Birth")]
        public string PlaceOfBIrth { get; set; }
        [Required]
        [StringLength(50)]
        public string Address { get; set; }
        public Status Status { get; set; }
        public byte StatusID { get; set; }
    }
}