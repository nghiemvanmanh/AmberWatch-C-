using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AmberWatch.Areas.Customer.Models
{
    public class OrderModel
    {
        [Key]
        public int id_order { get; set; }
        public int id_orderwatch { get; set; }
        public int id_user { get; set; }
        public  string? model { get; set; }
        public  string? brand { get; set; }
        public  string? name { get; set; }
        public  string? collection { get; set; }
        public  string? insurance { get; set; }
        public  string? dialcolor { get; set; }
        public  string? wirecolor { get; set; }
        public  string? shellcolor { get; set; }
        public  string? waterresistant { get; set; }
        public  string? dialtype { get; set; }
        public  string? wiretype { get; set; }
        public  string? grasstype { get; set; }
        public  string? machinetype { get; set; }
        public  string? shellmaterial { get; set; }
        public  string? sex { get; set; }
        public  string? dialsize { get; set; }
        public  string? dialthickness { get; set; }
        public  string? img { get; set; }
        public double price { get; set; }
        public  string? description { get; set; }
        public int quantity { get; set; }
    }
}