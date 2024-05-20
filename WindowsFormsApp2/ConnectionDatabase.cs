using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    public static class ConnectionDatabase
    {
        public static string cn_oracle = "user id=SNKTR2K;password=SNKTR2K;" +
                "data source=(DESCRIPTION=(ADDRESS=(PROTOCOL=tcp)(HOST=192.168.0.9)" +
                "(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=SNKT.spclt.com.vn)))";
        //public static string query = "select top 1 * from T_ORDER";
        public static string connString = @"Data Source=192.168.122.2;Initial Catalog=F2Database;Integrated Security=false;User ID=kproduct;Password=Tanphat@02032013;";

        public static string connString059 = @"Data Source=192.168.122.2;Initial Catalog=MANUFASPCPD;Integrated Security=false;User ID=ITadmin;Password=p@@word123;";
    }
}
