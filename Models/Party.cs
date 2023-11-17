using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PartyProductMVC.Models
{
    public class Party
    {
        [Key]
        public int PartyId { get; set; }
        public string PartyName { get; set; }
    }
}