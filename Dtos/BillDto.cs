using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using IzdavackaKuca.Models;

namespace IzdavackaKuca.Dtos
{
    public class BillDto
    {
        public int ID { get; set; }
        [Required]
        public decimal Total { get; set; }
        [BillDate]
        public DateTime IssuingDate { get; set; }
    }
}