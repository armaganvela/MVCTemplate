using Test.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll();

        Product Get(int id);

        Product Add(Product restaurant, List<Image> images);

        void Update(Product restaurant);

        void Delete(Product product);
    }
}
