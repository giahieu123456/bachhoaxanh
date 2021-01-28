using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bachhoaxanhdemo.Models;

namespace bachhoaxanhdemo.Controllers
{

    public class DetailProductController : Controller
    {
        public BhxDbContext _dbBhx2 = new BhxDbContext();

        // GET: DetailProduct
        public ActionResult indexDetail(int? id, int? idProd)
        {
            if (id == null && idProd == null)
            {
                return HttpNotFound();
            }
            var listCategories = _dbBhx2.Categories.OrderBy(x => x.idCategory).ToList();
            var listTitle = _dbBhx2.ProductTitles.OrderBy(x => x.idProductTitle).ToList();
            ViewBag.listCategories = listCategories;
            ViewBag.listTitle = listTitle;
            ViewData["productDetails"] = _dbBhx2.Products.Where(p => p.idProductTitle == id).FirstOrDefault(x => x.idProduct == idProd);

            return View();
        }
        public ActionResult infodetails(int? id, int? idProd)
        {
            if (id == null && idProd == null)
            {
                return HttpNotFound();

            }
         
            var productDetails = _dbBhx2.Products.Where(p => p.idProductTitle == id).FirstOrDefault(x => x.idProduct == idProd);
            return View(productDetails);
        }

        public ActionResult ProductDetail(int? id, int? idProd)
        {
            if (id == null && idProd == null)
            {
                return HttpNotFound();
            }
            var productDetails = _dbBhx2.Products.Where(p => p.idProductTitle == id).FirstOrDefault(x => x.idProduct == idProd);
            return View(productDetails);
        }

    }
}