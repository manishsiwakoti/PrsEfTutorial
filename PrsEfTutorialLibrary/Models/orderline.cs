using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PrsEfTutorialLibrary.Models
    {
    public  class Orderline
        {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }

        [JsonIgnore]
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }


        public Orderline()
            {

            }
        }
    }
