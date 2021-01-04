using bachhoaxanhdemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bachhoaxanhdemo.Controllers
{
    public class ProductTitleController : Controller
    {
        public bhxEntities _dbBhx = new bhxEntities();

        // GET: ProductTitle
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            
            

            var listCategories = _dbBhx.Categories.OrderBy(x => x.idCategory).ToList();
            var listTitle = _dbBhx.ProductTitles.OrderBy(x => x.idProductTitle).ToList();
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
            List<Product> listProductByTitle = (from p in _dbBhx.Products
                                                join pt in _dbBhx.ProductTitles on p.idProductTitle equals pt.idProductTitle
                                                where p.idProductTitle == id
                                                select p).ToList();
            var productTitleName = _dbBhx.ProductTitles.FirstOrDefault(x => x.idProductTitle == id).productTitleName;

            var PRODUCTBYTITLE = new _ProdByTitle();
            PRODUCTBYTITLE.LIST_PRODUCT = listProductByTitle;
            PRODUCTBYTITLE.ProductTitleName = productTitleName;

            return View(PRODUCTBYTITLE);
        }
    }
}