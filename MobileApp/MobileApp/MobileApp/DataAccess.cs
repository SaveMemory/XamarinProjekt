
using System.Collections.Generic;
using SQLite.Net;
using Xamarin.Forms;

namespace MobileApp
{
    public class DataAccess
    {
        SQLiteConnection dbConn;
        public DataAccess()
        {
            dbConn = DependencyService.Get<ISQLite>().GetConnection();
            // create the table(s)
            dbConn.CreateTable<Note>();
        }
        public List<Note> GetAllNotes()
        {
            return dbConn.Query<Note>("Select * From [Note]");
        }
        public int SaveNotes(Note note)
        {
            return dbConn.Insert(note);
        }
        public int DeleteNotes(Note note)
        {
            return dbConn.Delete(note);
        }
        public int EditNotes(Note note)
        {
            return dbConn.Update(note);
        }
    }
}
