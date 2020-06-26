using Test.Core.Models;
using Test.Interfaces;
using Test.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Services
{
    public class ImageService : IImageService
    {
        private readonly ApplicationDbContext db;

        public ImageService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public Image Add(Image image)
        {
            db.Images.Add(image);
            db.SaveChanges();

            return image;
        }

        public Image Delete(Image image)
        {
            db.Images.Remove(image);
            db.SaveChanges();

            return image;
        }
    }
}
