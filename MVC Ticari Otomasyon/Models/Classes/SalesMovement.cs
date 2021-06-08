using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Ticari_Otomasyon.Models.Classes
{
    public class SalesMovement
    {
        [Key]
        public int SalesMovementID { get; set; }
        public DateTime Date { get; set; }
        public int Piece { get; set; }
        public decimal Price { get; set; }
        public decimal TotalAmount { get; set; }

        public int Productid { get; set; }
        public int Currentid { get; set; }
        public int Personnelid { get; set; }

        public virtual Product Product { get; set; }
        public virtual Current Currents { get; set; }
        public virtual Personnel Personnel { get; set; }
    }
}