using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GadgetHub.Domain.Abstract;
using GadgetHub.WebUI.Models;

namespace GadgetHub.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository myRepository;

        public ProductController (IProductRepository productRepository)
        {
            this.myRepository = productRepository;
        }

        public int pageSize = 4;
        public ViewResult List(string category, int page = 1)
        {
            ProductsListViewModels model = new ProductsListViewModels
            {
                Products = myRepository.Products.OrderBy(p => p.ProductID)
                    .Where(p => category == null || p.Category == category)
                    .OrderBy(p => p.ProductID)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = category == null ?
                        myRepository.Products.Count() :
                        myRepository.Products.Where(e => e.Category == category).Count()
                },
                CurrentCategory = category
            };
            return View(model);
        }
    }
}