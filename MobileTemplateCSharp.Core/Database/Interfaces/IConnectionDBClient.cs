using System;
using SQLite;

namespace MobileTemplateCSharp.Core.Database.Interfaces {
    /// <summary>
    /// Basic service working with DB. All DBCliens should have it. 
    /// </summary>
    public interface IConnectionDBClient {
        object locker { get; set; }
        SQLiteConnection Database { get; set; }
    }
}
