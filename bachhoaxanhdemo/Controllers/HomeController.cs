﻿using bachhoaxanhdemo.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;

namespace bachhoaxanhdemo.Controllers
{

    public class HomeController : Controller
    {
        public BhxDbContext _dbBhx2 = new BhxDbContext();



        public ActionResult Index()
        {
            var listCategories = _dbBhx2.Categories.OrderBy(x => x.idCategory).ToList();
            var listTitle = _dbBhx2.ProductTitles.OrderBy(x => x.idProductTitle).ToList();
            ViewBag.listCategories = listCategories;
            ViewBag.listTitle = listTitle;
            return View();
        }


        /*  public ActionResult loadProductTitle(int idCate)
          {
              var listProductTitle = _dbBhx2.ProductTitles.OrderBy(x => x.idCategory).ToList();
              return ViewBag;
          }
  */
        public ActionResult GroupFeature()
        {
            var listCategories = _dbBhx2.Categories.OrderBy(x => x.idCategory).ToList();
            var listproduct = _dbBhx2.Products.OrderBy(m => m.idProduct).ToList();
            var listproducttitle = _dbBhx2.ProductTitles.OrderBy(n => n.idProductTitle).ToList();
            return View(listCategories);
        }

        public ActionResult GroupFeatureProduct(int? idcate)
        {
            List<DemoModel> model1 = (from p in _dbBhx2.Products
                                      join pt in _dbBhx2.ProductTitles on p.idProductTitle equals pt.idProductTitle
                                      join c in _dbBhx2.Categories on pt.idCategory equals c.idCategory
                                      where c.idCategory == idcate
                                      select new DemoModel { idProduct = p.idProduct, productName = p.productName, productPrice = p.productPrice, image = p.image, idCategory = c.idCategory, idProductTitle = p.idProductTitle }).OrderBy(x => x.idCategory).Take(4).ToList();
            var countproduct = model1.Count;
            return View(model1);
        }

        public string RenderRazorViewToString(string viewName, object model)
        {
            ViewData.Model = model;
            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext,
                                                                         viewName);
                var viewContext = new ViewContext(ControllerContext, viewResult.View,
                                             ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);
                viewResult.ViewEngine.ReleaseView(ControllerContext, viewResult.View);
                return sw.GetStringBuilder().ToString();
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult LoadMoreProduct(int idcate, int page_index)
        {

            var model1 = (from p in _dbBhx2.Products
                          join pt in _dbBhx2.ProductTitles on p.idProductTitle equals pt.idProductTitle
                          join c in _dbBhx2.Categories on pt.idCategory equals c.idCategory
                          where c.idCategory == idcate
                          select new DemoModel { idProduct = p.idProduct, productName = p.productName, productPrice = p.productPrice, image = p.image, idCategory = c.idCategory, idProductTitle = p.idProductTitle }).OrderBy(x => x.idCategory).Skip(page_index).ToList();
            int modelCount = model1.Skip(4).Count();
            var model2 = model1.Take(4).ToList();
            if (model1.Any())
            {
                string modelString = RenderRazorViewToString("LoadMoreProduct", model2);
                return Json(new { ModelString = modelString, ModelCount = modelCount }, JsonRequestBehavior.AllowGet);
            }
            return Json(null);
        }



    }
}