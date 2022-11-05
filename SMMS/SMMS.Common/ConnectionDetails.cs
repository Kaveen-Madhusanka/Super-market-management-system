using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMMS.Common
{
    public static class ConnectionDetails
    {
        public static string ConnetionString { get; set; }

        public static SqlConnection Conn { get; set; }
    }
}
