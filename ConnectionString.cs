using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace List_To_Do__Tab_
{
    
    internal class ConnectionString
    {
        readonly string connectionString = ConfigurationManager.ConnectionStrings["Data Source=DESKTOP-6T53PQ0;Initial Catalog=&quot;To do list&quot;;Integrated Security=True;User ID=Admin;Encrypt=True;TrustServerCertificate=True"].ConnectionString;
    }

}
