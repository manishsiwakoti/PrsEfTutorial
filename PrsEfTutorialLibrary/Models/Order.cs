using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PrsEfTutorialLibrary.Models
    {
    public class Order
        {
        public int Id { get; set; }
        [StringLength(30)]
        [Required]
        public string Description { get; set; }
        public double Amount { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public override string ToString() => $"{Id}/{Description}/{Amount}/{Customer.Name}";
        public virtual List<Orderline> Orderlines { get; set; }
        public Order() { }
        }
    }
