using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_Ticari_Otomasyon.Models.Classes
{
    public class Invoice
    {
        [Key]
        public int InvoiceId { get; set; }

        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string InvoicetSerialNumber { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(6)]
        public string InvoicetRowNumber { get; set; }
        public DateTime InvoicetDate { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(60)]
        public string TaxAdministr { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(5)]
        public string Hour { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Delivering { get; set; }//Teslim Eden

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Receive { get; set; }//Teslim Alan

        public decimal Total { get; set; }

        public ICollection<InvoiceItem> InvoiceItems { get; set; }
    }
}