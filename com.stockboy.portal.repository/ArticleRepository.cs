using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.stockboy.portal.viewmodel;
using Dapper;

namespace com.stockboy.portal.repository
{
    public class ArticleRepository : utility.BaseRepository
    {
        /// <summary>
        /// 取得所有文章內容
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns value = "result"></returns>
        public IEnumerable<ArticleViewMoel> FetchArticleList(ArticleCriteriaViewModel criteria)
        {
            // Base Sql
            String baseSelectQuery = @"SELECT  *
                                       FROM Article 
                                       WHERE Article.Open_tag = 0 {0} order by Article_Date desc ";

            ///Condition
            List<string> listCondition = new List<string>();

            if (criteria.Article_id.HasValue)
            {
                listCondition.Add("Article_id =@Article_id");
            }
            string strCondition = string.Empty;
            if (listCondition.Count > 0)
            {
                strCondition = string.Join("and", listCondition.ToArray());
                strCondition = "and" + strCondition;
            }

            baseSelectQuery = string.Format(baseSelectQuery, strCondition);


            //Execute
            var result = Db.CreateConnection().Query<ArticleViewMoel>(baseSelectQuery, criteria);

            return result;
        }

        public int FetchArticleCount(decimal? Article_id)
        {
            //Base Sql 
            String baseSelectQuery = @"SELECT count(*)
                                                 FROM Article 
                                                 WHERE Article.Open_tag = 0 {0} " ;

            ///Condition
            List<string> listCondition = new List<string>();

            if (Article_id.HasValue)
            {
                listCondition.Add("Article_id =@Article_id");
            }
            string strCondition = string.Empty;
            if (listCondition.Count > 0)
            {
                strCondition = string.Join(" and ", listCondition.ToArray());
                strCondition = " and " + strCondition;
            }

            baseSelectQuery = string.Format(baseSelectQuery, strCondition);

            //Execute
            int result = Db.CreateConnection().Query<int>(baseSelectQuery, new { Article_id = Article_id }).Single();

            return result;
        }
    }
}
