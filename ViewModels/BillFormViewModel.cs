using System.Collections.Generic;
using IzdavackaKuca.Models;

namespace IzdavackaKuca.ViewModels
{
    public class BillFormViewModel
    {
        public IEnumerable<Book> Books { get; set; }
        public IEnumerable<Member> Members { get; set; }
        public Bill Bill { get; set; }
        public string Title
        {
            get
            {
                if (Bill != null && Bill.ID != 0)
                    return "Edit Bill";
                return "New Bill";
            }
        }
    }
}