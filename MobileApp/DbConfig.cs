using System;
using SQLite;

[Table("Items")]
public class Stock
{
    [PrimaryKey, AutoIncrement, Column("_id")]
    public int Id { get; set; }
    [MaxLength(8)]
    public string Symbol { get; set; }

    public static void DoSomeDataAccess()
    {
        Console.WriteLine("Creating database, if it doesn't already exist");
        string dbPath = Path.Combine(
             Environment.GetFolderPath(Environment.SpecialFolder.Personal),
             "ormdemo.db3");
        var db = new SQLiteConnection(dbPath);
        db.CreateTable<Stock>();
        if (db.Table<Stock>().Count() == 0)
        {
            // only insert the data if it doesn't already exist
            var newStock = new Stock();
            newStock.Symbol = "AAPL";
            db.Insert(newStock);
            newStock = new Stock();
            newStock.Symbol = "GOOG";
            db.Insert(newStock);
            newStock = new Stock();
            newStock.Symbol = "MSFT";
            db.Insert(newStock);
        }
        Console.WriteLine("Reading data");
        var table = db.Table<Stock>();
        foreach (var s in table)
        {
            Console.WriteLine(s.Id + " " + s.Symbol);
        }
    }
}
