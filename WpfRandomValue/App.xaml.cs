using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WpfRandomValue
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
    }
    public class GlobalSetting
    {
        public static string CreateConectionString(string databaseFile,
                string userName, string userPass, string _charset)
        {
            FbConnectionStringBuilder ConnectionSB = new FbConnectionStringBuilder();
            ConnectionSB.Database = databaseFile;
            ConnectionSB.UserID = userName;
            ConnectionSB.Password = userPass;
            ConnectionSB.Charset = _charset;
            ConnectionSB.Pooling = false;
            return ConnectionSB.ToString();
        }
    }
}
