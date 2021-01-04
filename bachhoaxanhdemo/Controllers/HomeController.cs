using bachhoaxanhdemo.Models;
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
        public bhxEntities2 _dbBhx2 = new bhxEntities2();



        public ActionResult Index()
        {
            var listCategories = _dbBhx2.Categories.OrderBy(x => x.idCategory).ToList();
            var listTitle = _dbBhx2.ProductTitles.OrderBy(x => x.idProductTitle).ToList();
            ViewBag.listCategories = listCategories;
            ViewBag.listTitle = listTitle;
            return View();
        }
       

        public ActionResult loadProductTitle(int idCate)
        {
            var listProductTitle = _dbBhx2.ProductTitles.OrderBy(x => x.idCategory).ToList();
            return ViewBag;
        }

        public ActionResult GroupFeature()
        {

            //var listProduct = _dbBhx.Products.OrderBy(x => x.idProduct).Take(4);

            //var productByCate = (from p in _dbBhx.Products.ToList()
            //                     join pt in _dbBhx.ProductTitles on p.idProductTitle equals pt.idProductTitle
            //                     join c in _dbBhx.Categories on pt.idCategory equals c.idCategory

            //                     select new DemoModel { LIST_PRODUCT = p, ID_CATE = c.idCategory }).ToList();




            //ViewBag.listProductByCate = productByCate;
            var listCategories = _dbBhx2.Categories.OrderBy(x => x.idCategory).ToList();
            
            return View(listCategories);
        }

        public ActionResult GroupFeatureProduct(int idcate)
        {

            //var listProduct = _dbBhx.Products.OrderBy(x => x.idProduct).Take(4);

            //var productByCate = (from p in _dbBhx.Products.ToList()
            //                     join pt in _dbBhx.ProductTitles on p.idProductTitle equals pt.idProductTitle
            //                     join c in _dbBhx.Categories on pt.idCategory equals c.idCategory

            //                     select new DemoModel { LIST_PRODUCT = p, ID_CATE = c.idCategory }).ToList();




            //ViewBag.listProductByCate = productByCate;
            List<DemoModel> model1 = (from p in _dbBhx2.Products
                                      join pt in _dbBhx2.ProductTitles on p.idProductTitle equals pt.idProductTitle
                                      join c in _dbBhx2.Categories on pt.idCategory equals c.idCategory
                                      where c.idCategory == idcate
                                      select new DemoModel { idProduct = p.idProduct, productName = p.productName, productPrice = p.productPrice, image = p.image, idCategory = c.idCategory }).OrderBy(x => x.idCategory).Take(4).ToList();

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
                          select new DemoModel { idProduct = p.idProduct, productName = p.productName, productPrice = p.productPrice, image = p.image, idCategory = c.idCategory }).OrderBy(x => x.idCategory).Skip(page_index).Take(4).ToList();


            int modelCount = model1.Count();
            if (model1.Any())
            {
                string modelString = RenderRazorViewToString("LoadMoreProduct", model1);
                return Json(new { ModelString = modelString, ModelCount = modelCount }, JsonRequestBehavior.AllowGet);
            }

            return Json(model1, JsonRequestBehavior.AllowGet);
        }



    }
}