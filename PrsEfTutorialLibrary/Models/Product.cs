using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PrsEfTutorialLibrary.Models
    {
    public class Product
        {
        public int Id { get; set; }
        [StringLength(30)]
        [Required]
        public string Code { get; set; }
        [StringLength(30)]
        [Required]
        public string Name { get; set; }
        public double Price { get; set; }
        public virtual List<Orderline> Orderlines { get; set; }
        public Product() { }
        }
    }
