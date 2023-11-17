using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PartyProductMVC.Models
{
    public class ProductRate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int ProductRateId { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Rate must be a positive number")]
        public int Rate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfRate { get; set; }

        public virtual Product Product { get; set; }
    }
}