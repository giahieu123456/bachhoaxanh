using bachhoaxanhdemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bachhoaxanhdemo.Controllers
{
    public class ProductController : Controller
    {

        public bhxEntities _dbBhx = new bhxEntities();
        // GET: Product
        public ActionResult Index(int? id, int? idProd)
        {

            if (id == null && idProd == null)
            {
                return HttpNotFound();
            }
            var listCategories = _dbBhx.Categories.OrderBy(x => x.idCategory).ToList();
            var listTitle = _dbBhx.ProductTitles.OrderBy(x => x.idProductTitle).ToList();
            ViewBag.listCategories = listCategories;
            ViewBag.listTitle = listTitle;
            return View();
        }

        public ActionResult ProductDetails(int? id, int? idProd)
        {

            if (id == null && idProd == null)
            {
                return HttpNotFound();
            }
            var productDetail = _dbBhx.Products.Where(x => x.idProductTitle == id).FirstOrDefault(x => x.idProduct == idProd);
            return View(productDetail);
        }
    }
}