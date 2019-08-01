using System;
using System.Collections.Generic;
using System.IO;
using SQLite;

namespace MobileApp
{
    public class DataAccess
    {
        public SQLiteConnection db;

        public DataAccess()
        {
            var dbPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                "ormdemo.db3");
            db = new SQLiteConnection(dbPath);
            db.CreateTable<Note>();
        }

        public void AddNote(Note note)
        {
            var newNote = new Note();
            newNote.Title = note.Title;
            newNote.Content = note.Content;

            db.Insert(newNote);
            var table = db.Table<Note>();
        }
        public IEnumerable<Note> GetAllNotes()
        {
            var allNotes = db.Table<Note>();

            foreach (var note in allNotes)
            {
                 yield return note;
            }
        }
    }
}
