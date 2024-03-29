﻿using System;
using Xamarin.Forms;
using SQLiteEx.Droid;
using System.IO;
using MobileApp;
using SQLite;

namespace SQLiteEx.Droid
{
    public class SqliteService 
    {
        public SqliteService() { }

        public void AccessData()
        {
            Console.WriteLine("Creating database, if it doesn't already exist");
            string dbPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                "ormdemo.db3");
            var db = new SQLiteConnection(dbPath);
            db.CreateTable<NoteViewModel>();
            if (db.Table<NoteViewModel>().Count() == 0)
            {
                // only insert the data if it doesn't already exist
                var newStock = new NoteViewModel();
                newStock.Content = "AAPL";
                db.Insert(newStock);
                newStock = new NoteViewModel();
                newStock.Content = "GOOG";
                db.Insert(newStock);
                newStock = new NoteViewModel();
                newStock.Content = "MSFT";
                db.Insert(newStock);
            }
            Console.WriteLine("Reading data");
            var table = db.Table<NoteViewModel>();
            foreach (var s in table)
            {
                Console.WriteLine(s.Id + " " + s.Content);
            }
        }
    }
}