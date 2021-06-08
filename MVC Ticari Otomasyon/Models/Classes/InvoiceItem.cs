using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_Ticari_Otomasyon.Models.Classes
{
    public class InvoiceItem
    {
        [Key]
        public int InvoicItemID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Explanation { get; set; }//Açıklama 100 karakter
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }//Birim Fiyat
        public decimal Amount { get; set; }//Tutar
        public virtual Invoice Invoice { get; set; }
        public int Invoiceid { get; set; }
    }
}