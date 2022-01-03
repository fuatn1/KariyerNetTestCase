using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerNet.Data.Configurations
{
    public class MongoDbSettings
    {
        public string ConnectionString;
        public string Database;

        //Configuration için kullanılacak
        #region Const Values

        public const string ConnectionStringValue = "mongodb://root:1234@localhost:27017";
        public const string DatabaseValue = "KariyerDb";

        #endregion
    }
}
