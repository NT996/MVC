using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using IzdavackaKuca.Models;

namespace IzdavackaKuca.Models
{
    public class BillDate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var bill = (Bill)validationContext.ObjectInstance;
            if (bill.IssuingDate == null)
                return new ValidationResult("Niste uneli datum!.");

            return (DateTime.Today == bill.IssuingDate)
                ? ValidationResult.Success
                : new ValidationResult("Datum nastanka racuna se mora poklopiti sa danasnjim datutmom.");
        }
    }
}