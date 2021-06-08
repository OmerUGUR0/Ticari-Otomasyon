using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_Ticari_Otomasyon.Models.Classes
{
    public class Expense //Giderler
    {
        [Key]
        public int ExpensesId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string ExpensesExplanation { get; set; }//Gider Açıklama
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
    }
}