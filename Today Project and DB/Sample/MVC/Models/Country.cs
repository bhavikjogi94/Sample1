using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Models
{
    public class Country
    {
        [Key]
        public Int32 CountryID { get; set; }
        [Column(TypeName = "nvarchar")]
        [StringLength(100)]
        [Display(Name = "Country")]
        public string CountryName { get; set; }
    }
}