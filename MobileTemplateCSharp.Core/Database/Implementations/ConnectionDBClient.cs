using System;
using SQLite;
using System.IO;

using MobileTemplateCSharp.Core.Database.Interfaces;

namespace MobileTemplateCSharp.Core.Database.Implementations {
    public class ConnectionDBClient : IConnectionDBClient {
        public object locker { get; set; }
        public SQLiteConnection Database { get; set; }

        public ConnectionDBClient() {
            locker = new object();
            Database = GetDBConnection();
        }

        public SQLiteConnection GetDBConnection() {
            var databaseName = $"{Constants.DatabaseName}.db3";
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var databasePath = Path.Combine(folderPath, databaseName);
            var connection = new SQLiteConnection(databasePath);
            return connection;
        }
    }
}
