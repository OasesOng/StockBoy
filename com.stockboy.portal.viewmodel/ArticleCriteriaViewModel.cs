using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.stockboy.portal.viewmodel
{
    [Serializable]
    public class ArticleCriteriaViewModel
    {
        public Decimal? Article_id { get; set; }

        public String Open_tag { get; set; }

        public DateTime? Article_Date { get; set; }

        public String Article_Title { get; set; }

        public String Article_Text { get; set; }

        public String Article_Img { get; set; }

        public DateTime? add_date { get; set; }

        public DateTime? edit_date { get; set; }

        public String edit_ip { get; set; }
    }
}
