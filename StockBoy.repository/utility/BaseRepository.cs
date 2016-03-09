using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockBoy.repository.utility
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

        //private string Combine(string baseSelectQuery, string query)
        //{
        //    String result = baseSelectQuery;
        //    if (baseSelectQuery.Split(' ').Contains<string>("WHERE"))
        //        result += " AND " + query;
        //    else
        //        result += " WHERE " + query;
        //    return result;
        //}


        //public String ConnectToSQL()
        //{
        //    string strConn = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        //    //建立連接
        //    connection = new SqlConnection(strConn);
        //    try
        //    {
        //        connection.Open();
        //        return "Success";
        //    }
        //    catch (Exception e)
        //    {
        //        return e.Message;
        //    }
        //}
        //public String DisconnectToSQL()
        //{
        //    try
        //    {
        //        connection.Close();
        //        return "Success";
        //    }
        //    catch (Exception e)
        //    {
        //        return e.Message;
        //    }
        //}
    }
}
