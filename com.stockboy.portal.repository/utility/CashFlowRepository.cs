using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace com.stockboy.portal.repository.utility
{
    public class CashFlowRepository
    {
        protected string ConnectionStringName2 { get; set; }

        private DatabaseProviderFactory factory = new DatabaseProviderFactory();

        public CashFlowRepository()
        {
            this.ConnectionStringName2 = "DefaultConnection2";
        }
        public CashFlowRepository(string connectionStringName2)
        {
            this.ConnectionStringName2 = connectionStringName2;
        }
        private Database _db;
        internal Database Db
        {
            get
            {
                try
                {
                    if (this.Db == null)
                    {
                        if (string.IsNullOrEmpty(this.ConnectionStringName2))
                        {
                            _db = this.factory.CreateDefault();
                        }
                        this._db = this.factory.Create(this.ConnectionStringName2);
                    }
                }
                catch (Exception ex)
                {
                    //logger.Fatal(ex);
                    throw ex;
                }

                return this._db;
            }
        }
    }
}
