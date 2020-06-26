using Interfaces;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Test.Core.Models;
using Test.Interfaces;
using Test.Web.Extensions;
using Test.Web.Models;

namespace Test.Web.Controllers
{
    [Authorize]
    public class ProductManagementController : Controller
    {
        private readonly IProductService _productService;
        private readonly IUserService _userService;

        public ProductManagementController(IProductService productService, IUserService userService)
        {
            this._productService = productService;
            this._userService = userService;
        }

        public ActionResult Index()
        {
            ApplicationUser applicationUser = _userService.GetUser(User.Identity.GetUserId());

            var products = _productService.GetAll();

            List<ProductViewModel> productsViewModel = products.Select(x => x.ToViewModel()).ToList();
            return View(productsViewModel);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product product = _productService.Get(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }

            var byteImages = product.Images.Select(x => x.BlobContent).ToList();
            var base64Images = byteImages.Select(x => Convert.ToBase64String(x)).ToList();

            var productViewModel = product.ToViewModel();
            productViewModel.StringImages = base64Images;

            return View(productViewModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = ModelState.GetFirstError();
                return View(viewModel);
            }

            List<Image> images = new List<Image>();

            foreach (var image in viewModel.Images)
            {
                if (image != null)
                {
                    byte[] content = ConvertToBytes(image);
                    Image newImage = Image.Create(image.FileName, image.ContentType, content);
                    images.Add(newImage);
                }
            }

            Product product = Product.Create(viewModel.Name, viewModel.Barcode, viewModel.Price, viewModel.Description, viewModel.Quantity);

            _productService.Add(product, images);

            TempData["SuccessMessage"] = "Create Operation is success";
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product product = _productService.Get(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product.ToViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = ModelState.GetFirstError();
                return View(viewModel);
            }

            Product product = _productService.Get(viewModel.ProductId);

            product = product.Update(viewModel.Name, viewModel.Barcode, viewModel.Price, viewModel.Description, viewModel.Quantity);

            _productService.Update(product);
            
            TempData["SuccessMessage"] = "Update Operation is success";
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product product = _productService.Get(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product.ToViewModel());
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = _productService.Get(id);

            _productService.Delete(product);

            return RedirectToAction("Index");
        }

        private byte[] ConvertToBytes(HttpPostedFileBase image)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(image.InputStream);
            imageBytes = reader.ReadBytes((int)image.ContentLength);
            return imageBytes;
        }
    }
}