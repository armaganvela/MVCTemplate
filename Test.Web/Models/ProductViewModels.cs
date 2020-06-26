using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Test.Web.Models
{
    public class ProductViewModel
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

        public List<HttpPostedFileBase> Images { get; set; }

        public List<string> StringImages { get; set; }
    }
}