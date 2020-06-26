using Test.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Interfaces
{
    public interface IImageService
    {
        Image Add(Image image);

        Image Delete(Image image);
    }
}
