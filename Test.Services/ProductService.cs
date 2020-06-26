using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Test.Core.Models;
using Test.Interfaces;
using Test.Sql;

namespace Test.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext db;
        private readonly IImageService _imageService;

        public ProductService(ApplicationDbContext db, IImageService imageService)
        {
            this.db = db;
            this._imageService = imageService;
        }

        public Product Add(Product product, List<Image> images)
        {
            using (DbContextTransaction transaction = db.Database.BeginTransaction())
            {
                try
                {
                    db.Products.Add(product);
                    db.SaveChanges();

                    foreach (var image in images)
                    {
                        image.ProductId = product.ProductId;
                        _imageService.Add(image);
                    }

                    transaction.Commit();
                    return product;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return null;
                }
            }
        }

        public void Update(Product product)
        {
            var entry = db.Entry(product);
            entry.State = EntityState.Modified;

            db.SaveChanges();
        }


        public Product Get(int id)
        {
            return db.Products.Include(x=>x.Images).FirstOrDefault(r => r.ProductId == id);
        }

        public IEnumerable<Product> GetAll()
        {
            return db.Products.ToList();
        }

        public void Delete(Product product)
        {
            db.Products.Remove(product);
            db.SaveChanges();
        }
    }
}