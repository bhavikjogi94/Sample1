using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Province
    {
        [Key]
        public Int32 ProvinceID { get; set; }
        [Required]
        public Int32 CountryID { get; set; }
        [Column(TypeName = "nvarchar")]
        [StringLength(100)]
        [Display(Name = "Province")]
        public string ProvinceName { get; set; }
    }
}