using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bachhoaxanhdemo.Models;

namespace bachhoaxanhdemo.Controllers
{
   
    public class ProductTitlesController : Controller
    {
        public bhxEntities2 _dbBhx2 = new bhxEntities2();
        // GET: ProductTitles
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();       
            }
            var listCategories = _dbBhx2.Categories.OrderBy(x => x.idCategory).ToList();
            var listTitle = _dbBhx2.ProductTitles.OrderBy(x => x.idProductTitle).ToList();
            ViewBag.listCategories = listCategories;
            ViewBag.listTitle = listTitle;
            return View();
        }
        public ActionResult GroupFeatureProductByTitle(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            //var productTitle = _dbBhx.ProductTitles.Where(p => p.idProductTitle == id).ToList();
            List<Product> listProductByTitle = (from p in _dbBhx2.Products
                                                join pt in _dbBhx2.ProductTitles on p.idProductTitle equals pt.idProductTitle
                                                where p.idProductTitle == id
                                                select p).ToList();
            var productTitleName = _dbBhx2.ProductTitles.FirstOrDefault(x => x.idProductTitle == id).productTitleName;
            var ProductByTitle = new ProdByTitle();
            ProductByTitle.LIST_PRODUCT = listProductByTitle;
            ProductByTitle.ProductTitleName = productTitleName;         
            return View( ProductByTitle);
        }

    }
}