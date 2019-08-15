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
            db.CreateTable<NoteViewModel>();
        }

        public void AddNote(NoteViewModel noteViewModel)
        {
            db.Insert(noteViewModel);
        }

        public IEnumerable<NoteViewModel> GetAllNotes()
        {
            var notesList = new List<NoteViewModel>();
            var allNotes = db.Query<NoteViewModel>("SELECT * FROM Notes");

            foreach (var note in allNotes)
            {
                notesList.Add(note);
            }

            return notesList;
        }

        public void UpdateNote(NoteViewModel noteViewModel)
        {
            db.Update(noteViewModel);
        }

        public void DeleteNote(int id)
        {
            db.Delete<NoteViewModel>(id);
        }

        public void SaveNote(NoteViewModel note)
        {
            if (note.Id == 0)
            {
                AddNote(note);
            }
            else
            {
                UpdateNote(note);
            }
        }
    }
}
