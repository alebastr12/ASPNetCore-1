using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lesson1.Infrastructure.Interfaces;
using lesson1.Models;
using Microsoft.AspNetCore.Mvc;
using WebStore.Domain.Filters;

namespace lesson1.Controllers
{
    public class CatalogController : Controller
    {
        private readonly IProductService _productService;

        public CatalogController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult ProductDetails()
        {
            return View();
        }
        public IActionResult Shop(int? CategoryId, int? BrandId)
        {
            var products = _productService.GetProducts(
                new ProductFilter { BrandId = BrandId, CategoryId = CategoryId });

            // сконвертируем в CatalogViewModel
            var model = new CatalogViewModel()
            {
                BrandId = BrandId,
                CategoryId = CategoryId,
                Products = products.Select(p => new ProductViewModel()
                {
                    Id = p.Id,
                    ImageUrl = p.ImageUrl,
                    Name = p.Name,
                    Order = p.Order,
                    Price = p.Price
                }).OrderBy(p => p.Order).ToList()
            };

            return View(model);
        }
    }
}