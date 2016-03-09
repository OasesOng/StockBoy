using StockBoy.Models;
using StockBoy.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockBoy.Services
{
    public class ArticleService
    {
        StockBoyEntities db = new StockBoyEntities();

        List<Models.Article> result = new List<Article>();

        #region List All Article
        public List<Article> GetArticleList()
        {
            result = (from Article in db.Article orderby Article.add_date descending select Article).ToList();

            return result;
        }
        #endregion
    }
}