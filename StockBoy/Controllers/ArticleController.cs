using StockBoy.Services;
using StockBoy.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StockBoy.Controllers
{
    public class ArticleController : Controller
    {
        

        // GET: Article
        public ActionResult Index()
        {
           
            return View();
        }

        public ActionResult Article(Decimal? id)
        {
            ArticleViewModel article = new ArticleViewModel();
            article.Article_id = id;

            return View();
        }




    }
}