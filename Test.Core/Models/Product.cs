using Test.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Core.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Barcode is required")]
        public string Barcode { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public decimal Price { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        public int Quantity { get; set; }

        public List<Image> Images { get; set; }

        public static Product Create(string name, string barcode, decimal price, string description, int quantity)
        {
            return new Product()
            {
                Name = name,
                Barcode = barcode,
                Price = price,
                Description = description,
                Quantity = quantity,
            };
        }

        public Product Update(string name, string barcode, decimal price, string description, int quantity)
        {
            Name = name;
            Barcode = barcode;
            Price = price;
            Description = description;
            Quantity = quantity;

            return this;
        }
    }
}
