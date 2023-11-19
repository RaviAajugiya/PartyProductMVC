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
        public string ProductName { get; set; }
        public string PartyName { get; set; }
        public int CurrentRate { get; set; }
        public int Quantity { get; set; }
        public DateTime DateOfPurchase { get; set; }
    }
}