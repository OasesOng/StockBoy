using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.stockboy.portal.repository.utility
{
    public class BaseRepository
    {
        protected string ConnectionStringName { get; set; }

        private DatabaseProviderFactory factory = new DatabaseProviderFactory();

        public BaseRepository()
        {
            this.ConnectionStringName = "DefaultConnection";
        }
        public BaseRepository(string connectionStringName)
        {
            this.ConnectionStringName = connectionStringName;
        }

        private Database _db;
        internal Database Db
        {
            get
            {
                try
                {
                    if (this._db == null)
                    {
                        if (string.IsNullOrEmpty(this.ConnectionStringName))
                        {
                            _db = this.factory.CreateDefault();
                        }
                        this._db = this.factory.Create(this.ConnectionStringName);
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
