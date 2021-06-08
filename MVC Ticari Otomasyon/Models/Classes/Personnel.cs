using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_Ticari_Otomasyon.Models.Classes
{
    public class Personnel
    {
        [Key]
        public int PersonnelID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string PersonnelName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string PersonnelSurName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string PersonnelImage { get; set; }
        public ICollection<SalesMovement> SalesMovements { get; set; }
        public int Departmentid { get; set; }
        public virtual Department Department { get; set; }
    }
}