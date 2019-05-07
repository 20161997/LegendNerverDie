using AutoMapper;
using LND.Model.Models;
using LND.Service;
using LND.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LND.Web.Controllers
{
    public class HomeController : Controller
    {
        IProductService _productService;
        IProductCategoryService _productCategoryService;
        public HomeController(IProductService productService,IProductCategoryService productCategoryService)
        {
           this._productService = productService;
            this._productCategoryService = productCategoryService;
          
        }
        public ActionResult Index()
        {
            var model = _productService.GetAll();
            var listProductViewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(model);
            return View(listProductViewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
     
        public ActionResult Header()
        {
            var model = _productCategoryService.GetAll();
            var listProductCategoryViewModel = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(model);
            return PartialView(listProductCategoryViewModel);
        }
        public ActionResult Footer()
        {
            return PartialView();
        }
        public ActionResult SignIn()
        {
            return PartialView();
        }
        public ActionResult HomeSlide ()
        {
            return PartialView();
        }
    }
}