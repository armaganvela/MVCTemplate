using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Core.Models
{
    public class Image
    {
        public int ImageId { get; set; }

        public string Title { get; set; }

        public string FileExtension { get; set; }

        public byte[] BlobContent { get; set; }

        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }

        public static Image Create(string title, string fileExtension, byte[] blobContent)
        {
            return new Image()
            {
                Title = title,
                FileExtension = fileExtension,
                BlobContent = blobContent
            };
        }
    }
}
