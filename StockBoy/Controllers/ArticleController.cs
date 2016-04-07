using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using com.stockboy.portal.service;
using com.stockboy.portal.viewmodel;

namespace StockBoy.Controllers
{
    public class ArticleController : Controller
    {
        ArticleService articleService;

        public ArticleController()
        {
            articleService = new ArticleService();
        }


        // GET: Article
        public ActionResult Index()
        {
            ArticleCriteriaViewModel criteria = new ArticleCriteriaViewModel();
            IEnumerable<ArticleViewModel> list = articleService.FetchArticleByCriteria(criteria);
            return View(list.ToList());
        }

        public ActionResult Article(Decimal? id)
        {
           // ArticleViewModel article = new ArticleViewModel();
           // article.Article_id = id;

            return View();
        }

    }
}