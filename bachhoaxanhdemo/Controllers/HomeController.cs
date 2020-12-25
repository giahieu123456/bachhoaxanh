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
        public bhxEntities _dbBhx = new bhxEntities();



        public ActionResult Index()
        {

            return View();
        }

        public ActionResult GroupFeature()
        {

            //var listProduct = _dbBhx.Products.OrderBy(x => x.idProduct).Take(4);

            var productByCate = (from p in _dbBhx.Products.ToList()
                                 join pt in _dbBhx.ProductTitles on p.idProductTitle equals pt.idProductTitle
                                 join c in _dbBhx.Categories on pt.idCategory equals c.idCategory

                                 select new DemoModel { LIST_PRODUCT = p, ID_CATE = c.idCategory }).ToList();

            


            ViewBag.listProductByCate = productByCate;
            ViewBag.Category = _dbBhx.Categories.OrderBy(x => x.idCategory).Take(5).ToList();

            return View();
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
        
        public JsonResult LoadMoreProduct(int idcate=5, int page_index=5)
        {

            List<DemoModel> model1 = (from p in _dbBhx.Products.ToList()
                          join pt in _dbBhx.ProductTitles on p.idProductTitle equals pt.idProductTitle
                          join c in _dbBhx.Categories on pt.idCategory equals c.idCategory
                          where c.idCategory == idcate
                          select new DemoModel { LIST_PRODUCT = p, ID_CATE = c.idCategory }).Skip(page_index).Take(4).ToList();
            

           
            int modelCount = _dbBhx.Products.Count();
            /*if (model1.Any())
            {
                string modelString = RenderRazorViewToString("LoadMoreProduct", model1);
                return Json(new { ModelString = modelString, ModelCount = modelCount });
            }*/

            return Json(model1[1].ID_CATE, JsonRequestBehavior.AllowGet);
        }
        
       

    }
}