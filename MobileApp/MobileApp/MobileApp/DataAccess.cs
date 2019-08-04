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
        }
        public IEnumerable<Note> GetAllNotes()
        {
            var notesList = new List<Note>();
            var allNotes = db.Query<Note>("SELECT * FROM Notes");

            foreach (var note in allNotes)
            {
                notesList.Add(note);
            }

            return notesList;
        }

        public void UpdateNote(Note note)
        {
            db.Query<Note>($"UPDATE Notes SET Title = {note.Title}, Content = {note.Content} WHERE Id == {note.Id}");
        }

        public void DeleteNote(int id)
        {
            db.Query<Note>($"DELETE FROM Notes WHERE Id == {id}");
        }
    }
}
