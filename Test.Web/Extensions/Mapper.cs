using Test.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Test.Core.Models;

namespace Test.Web.Extensions
{
    public static class Mapper
    {
        public static ProductViewModel ToViewModel(this Product model)
        {
            return new ProductViewModel()
            {
                ProductId = model.ProductId,
                Name = model.Name,
                Barcode = model.Barcode,
                Price = model.Price,
                Quantity = model.Quantity,
                Description = model.Description,
            };
        }
    }
}