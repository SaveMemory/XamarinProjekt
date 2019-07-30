using System;
using System.IO;
using SQLite;

namespace MobileApp
{
    [Table("Notes")]
    public class Stock
    {
        public SQLiteConnection db; 

        public Stock()
        {
            db = new SQLiteConnection(Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                "ormdemo.db3"));
            ConfigureDb();
        }

        [PrimaryKey, AutoIncrement, Column("Id")]
        public int Id { get; set; }

        [MaxLength(32)]
        public string Title { get; set; }
        public string Content { get; set; }


        public void ConfigureDb()
        {
            Console.WriteLine("Creating database, if it doesn't already exist");

            db.CreateTable<Stock>();
            if (db.Table<Stock>().Count() == 0)
            {
                // only insert the data if it doesn't already exist
                var newStock = new Stock();
                newStock.Content = "AAPL";
                db.Insert(newStock);
                newStock = new Stock();
                newStock.Content = "GOOG";
                db.Insert(newStock);
                newStock = new Stock();
                newStock.Content = "MSFT";
                db.Insert(newStock);
            }

            Console.WriteLine("Reading data");
            var table = db.Table<Stock>();
            foreach (var s in table)
            {
                Console.WriteLine(s.Id + " " + s.Content);
            }
        }

        public Stock GetFirstNote()
        {
            var note = db.Get<Stock>(1);
            return note;
        }
    }
}
