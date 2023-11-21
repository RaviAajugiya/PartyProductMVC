using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PartyProductMVC.Models
{
    public class Invoice
    {
        [Key]
        public int InvoiceId { get; set; }

        [Required(ErrorMessage = "ProductName is required")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "PartyName is required")]

        public string PartyName { get; set; }
        [Required(ErrorMessage = "CurrentRate is required")]

        public int CurrentRate { get; set; }
        [Required(ErrorMessage = "Quantity is required")]

        public int Quantity { get; set; }

        public DateTime DateOfPurchase { get; set; }
    }
}