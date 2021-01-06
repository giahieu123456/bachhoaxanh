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
        public Models.bhxEntities2 _dbBhx2 = new bhxEntities2();

        // GET: DetailProduct
        public ActionResult indexDetail(int? id )
        {
            var listCategories = _dbBhx2.Categories.OrderBy(x => x.idCategory).ToList();
            var listTitle = _dbBhx2.ProductTitles.OrderBy(x => x.idProductTitle).ToList();
            ViewBag.listCategories = listCategories;
            ViewBag.listTitle = listTitle;
            return View();
        }
    }
}