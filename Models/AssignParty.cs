using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PartyProductMVC.Models
{
    public class AssignParty
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AssignId { get; set; }


        [ForeignKey("Party")]
        [Index("IX_Party_Product", 1, IsUnique = true)]
        public int PartyId { get; set; }

        public virtual Party Party { get; set; }


        [ForeignKey("Product")]
        [Index("IX_Party_Product", 2, IsUnique = true)]
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }

}