using System.Collections.Generic;
using IzdavackaKuca.Models;

namespace IzdavackaKuca.ViewModels
{
    public class BookFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public IEnumerable<Publisher> Publishers { get; set; }
        public Book Book { get; set; }
        public string Title
        {
            get
            {
                if (Book != null && Book.ID != 0)
                    return "Edit Book";
                    return "New Book";
            }
        }
    }
}