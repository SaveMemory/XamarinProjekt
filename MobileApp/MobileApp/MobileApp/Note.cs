﻿
using SQLite.Net.Attributes;

namespace MobileApp
{
    public class Note
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

    }
}
