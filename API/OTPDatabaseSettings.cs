using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrowIndigo_Otp_Login_DemoProject
{
    public class OTPDatabaseSettings : IOTPDatabaseSettings
    {
        public string CollectionName { get; set; }

        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IOTPDatabaseSettings
    {
        string CollectionName { get; set; }

        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
