using System;
using SQLite;

namespace MobileTemplateCSharp.Core.Models.Database {
    public class BaseEntity {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    }
}
