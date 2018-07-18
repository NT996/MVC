using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using IzdavackaKuca.Models;

namespace IzdavackaKuca.Dtos
{
    public class MemberDto
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
        public DateTime? DateofBirth { get; set; }
        [Required]
        [StringLength(20)]
        public string PlaceOfBIrth { get; set; }
        [Required]
        [StringLength(50)]
        public string Address { get; set; }
    }
}