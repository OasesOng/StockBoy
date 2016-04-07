using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.stockboy.portal.viewmodel
{
    [Serializable]
    public class ExecuteResultModel
    {
        public bool isSuccess { get; set; }

        public List<string> message = new List<string>();
    }
}
