using System;
using System.ComponentModel.DataAnnotations;

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
        [Range(1, int.MaxValue, ErrorMessage = "CurrentRate must be greater than 0")]
        public int CurrentRate { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0")]
        public int Quantity { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfPurchase { get; set; }
    }
}