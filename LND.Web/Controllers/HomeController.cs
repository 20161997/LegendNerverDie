using AutoMapper;
using LND.Model.Models;
using LND.Service;
using LND.Web.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace LND.Web.Controllers
{
    public class HomeController : Controller
    {
        private IProductService _productService;
        private IProductCategoryService _productCategoryService;

        public HomeController(IProductService productService, IProductCategoryService productCategoryService)
        {
            this._productService = productService;
            this._productCategoryService = productCategoryService;
        }
        [OutputCache(Duration = 3600,Location =System.Web.UI.OutputCacheLocation.Server)]
        public ActionResult Index()
        {
            var model = _productService.GetAll();
            var listProductViewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(model);
            return View(listProductViewModel);
        }
        [ChildActionOnly]
        [OutputCache(Duration = 3600)]
        public ActionResult Header()
        {
            var model = _productCategoryService.GetAll();
            var listProductCategoryViewModel = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(model);
            return PartialView(listProductCategoryViewModel);
        }
        [ChildActionOnly]
        [OutputCache(Duration =3600)]
        public ActionResult Footer()
        {
            return PartialView();
        }

        [ChildActionOnly]
        [OutputCache(Duration = 3600)]
        public ActionResult SignIn()
        {
            return PartialView();
        }

        [ChildActionOnly]
        [OutputCache(Duration = 3600)]
        public ActionResult HomeSlide()
        {
            return PartialView();
        }
    }
}