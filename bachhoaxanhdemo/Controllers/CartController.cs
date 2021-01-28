using bachhoaxanhdemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bachhoaxanhdemo.Controllers
{
    public class CartController : Controller
    {
        private const string CartSession = "CartSession";
        public BhxDbContext _dbBhx = new BhxDbContext();
        // GET: Cart
        public ActionResult Index()
        {
            var listCategories = _dbBhx.Categories.OrderBy(x => x.idCategory).ToList();
            var listTitle = _dbBhx.ProductTitles.OrderBy(x => x.idProductTitle).ToList();
            ViewBag.listCategories = listCategories;
            ViewBag.listTitle = listTitle;


            var cart = Session[CartSession];
            List<CardItem> list = new List<CardItem>();
            
            if (cart != null)
            {
                list = (List<CardItem>)cart;
            }
            return View(list);
        }

        public ActionResult AddItem(int? productId, int quantity)
        {
            var cart = Session[CartSession];
            var product = _dbBhx.Products.FirstOrDefault(x => x.idProduct == productId);
            var list = (List<CardItem>)cart;
            if (cart != null)
            {
                
                if (list.Exists(x => x.Product.idProduct == productId))
                {
                    foreach (var item in list)
                    {
                        if (item.Product.idProduct == productId)
                        {
                            item.Quantity += quantity;
                        }
                    }
                }
                else
                {
                    var item = new CardItem();
                    item.Product = product;
                    item.Quantity = quantity;
                    list.Add(item);

                }

            }
            else
            {
                //create new cart item
                var item = new CardItem();
                item.Product = product;
                item.Quantity = quantity;            
                list.Add(item);
                //assign list card item into session
                //Session[CartSession] = list;
                Session[CartSession] = list;

            }
            return View(list);
        }
    }
}