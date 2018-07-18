using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using IzdavackaKuca.Models;

namespace IzdavackaKuca.Dtos
{
    public class BookDto
    {
        public int ID { get; set; }
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        [Required]
        [StringLength(20)]
        public string Autor { get; set; }
        public DateTime YearofPublication { get; set; }
        public decimal Price { get; set; }
        public bool OnSale { get; set; }
        public byte NumberInStock { get; set; }
    }
}