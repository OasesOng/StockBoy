using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.stockboy.portal.repository;
using com.stockboy.portal.viewmodel;

namespace com.stockboy.portal.service
{
    /// <summary>
    ///  文章
    /// </summary>
    public class ArticleService
    {
        private ArticleRepository articleRepo;

        public ArticleService()
        {
            articleRepo = new ArticleRepository();
        }

        /// <summary>
        /// 取得文章
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns value = "list"></returns>
        public IEnumerable<ArticleViewModel> FetchArticleByCriteria(ArticleCriteriaViewModel criteria)
        {
            var list = articleRepo.FetchArticleList(criteria);

            return list;
        }

        public string FetchArticleByGuid(string Guid)
        {
            var result = articleRepo.FetchAllPayIDByGuid(Guid);
            return result;
        }
    }
}
