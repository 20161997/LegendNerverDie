using AutoMapper;
using LND.Common;
using LND.Model.Models;
using LND.Service;
using LND.Web.Infrastructure.Core;
using LND.Web.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace LND.Web.Controllers
{
    public class ProductController : Controller
    {
         IProductService _productService;
        IProductCategoryService _productCategoryService;
        public ProductController(IProductService productService,IProductCategoryService productCategoryService)
        {
            this._productService = productService;
            this._productCategoryService = productCategoryService;

        }

        // GET: Product
        public ActionResult Detail(int id)
        {
            var productModel = _productService.GetById(id);
            var viewModel = Mapper.Map<Product, ProductViewModel>(productModel);
            var relatedProduct = _productService.GetReatedProducts(id, 4);
            ViewBag.RelatedProducts = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(relatedProduct);
            List<string> listImages = new JavaScriptSerializer().Deserialize<List<string>>(viewModel.MoreImages);
            ViewBag.MoreImages = listImages;
            ViewBag.Tags = Mapper.Map<IEnumerable<Tag>, IEnumerable<TagViewModel>>(_productService.GetListTagByProductId(id));
            return View(viewModel);
        }

        public ActionResult Category(int id,int page =1)
        {
            int pageSize = 12;
            int totalRow = 0;
            var productModel = _productService.GetListProductByCategoryIdPaging(id,page, pageSize, out totalRow);
            var productViewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(productModel);
            int totalPage = (int)Math.Ceiling((double)totalRow / pageSize);

            var category = _productCategoryService.GetById(id);
            ViewBag.Category = Mapper.Map<ProductCategory, ProductCategoryViewModel>(category);
            var paginationSet = new PaginationSet<ProductViewModel>()
            {
                Items = productViewModel,
                MaxPage = 5,
                Page = page,
               
                TotalCount = totalRow,
                TotalPages = totalPage
            };

            return View(paginationSet);
        }
        public ActionResult ListByTag(string id, int page = 1)
        {
            int pageSize = 12;
            int totalRow = 0;
            var productModel = _productService.GetListProductByTag(id, page, pageSize, out totalRow);
            var productViewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(productModel);
            int totalPage = (int)Math.Ceiling((double)totalRow / pageSize);

            ViewBag.Tag = Mapper.Map<Tag, TagViewModel>(_productService.GetTag(id));
            var paginationSet = new PaginationSet<ProductViewModel>()
            {
                Items = productViewModel,
                MaxPage = 5,
                Page = page,
                TotalCount = totalRow,
                TotalPages = totalPage
            };

            return View(paginationSet);
        }
        public ActionResult Search(string keyword)
        {
            ViewBag.Keyword = keyword;
            var model = _productService.Search(keyword);
            IEnumerable<ProductViewModel> listProductViewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(model);
            return View(listProductViewModel);
        }
        public ActionResult Sale()
        {
            var model = _productService.GetAll();
            var listProductViewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(model);
            return View(listProductViewModel);
        }
    }
}