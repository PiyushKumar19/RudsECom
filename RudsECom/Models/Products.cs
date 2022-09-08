﻿using System.ComponentModel.DataAnnotations;

namespace RudsECom.Models
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }
        public string ProdName { get; set; }
        public string ProdPrice { get; set; }
        public string Description { get; set; }
        public string Origin { get; set; }
        public string City { get; set; }
    }
}