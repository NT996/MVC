using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace IzdavackaKuca.Models
{
    public class Book
    {
        public int ID { get; set; }
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        [Required]
        [StringLength(20)]
        public string Autor { get; set; }
        [Display(Name = "Year of publication")]
        public DateTime YearofPublication { get; set; }
        public decimal Price { get; set; }
        [Display(Name = "On sale")]
        public bool OnSale { get; set; }
        [Display(Name = "Number in stock")]
        public byte NumberInStock { get; set; }
        public Genre Genre { get; set; }
        [Display(Name = "Genre")]
        [Required]
        public byte GenreID { get; set; }
        public Publisher Publisher { get; set; }
        [Display(Name = "Publisher")]
        [Required]
        public byte PublisherID { get; set; }
    }
}