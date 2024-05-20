using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class DBConnect
    {
        public static SqlConnection Connect_MS()
        {
            string connString = @"Data Source=192.168.0.7;Initial Catalog=ProductionControl;Integrated Security=false;User ID=kproduct;Password=tanphat@02032013;";
            SqlConnection conSql = new SqlConnection();
            conSql.ConnectionString = connString;
            conSql.Open();
            return conSql;
        }
        public static SqlConnection Connect_MS_new()
        {
            string connString = @"Data Source=192.168.122.2;Initial Catalog=F2Database;Integrated Security=false;User ID=kproduct;Password=Tanphat@02032013;";
            SqlConnection conSql = new SqlConnection();
            conSql.ConnectionString = connString;
            conSql.Open();
            return conSql;
        }

        public static SqlConnection Connect_MS_059()
        {
            string connString = @"Data Source=192.168.122.2;Initial Catalog=MANUFASPCPD;Integrated Security=false;User ID=ITadmin;Password=p@@word123;";
            SqlConnection conSql = new SqlConnection();
            conSql.ConnectionString = connString;
            conSql.Open();
            return conSql;
        }
    }
}
