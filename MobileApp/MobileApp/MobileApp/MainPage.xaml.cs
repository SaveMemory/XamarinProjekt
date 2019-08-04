using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;

namespace MobileApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        ObservableCollection<Note> notesDisplayCollection = new ObservableCollection<Note>();
        public ObservableCollection<Note> Notes => notesDisplayCollection;
        private DataAccess DataAccessObject;

        public MainPage()
        {
            InitializeComponent();
            NotesView.ItemsSource = Notes;
            DataAccessObject = new DataAccess();
        }

        public void AddMockedNote(object sender, EventArgs args)
        {
            var note = new Note()
            {
                Title = "Test Note",
                Content = "Test Content"
            };
            DataAccessObject.AddNote(note);
        }

        public void GetAllNotes(object sender, EventArgs args)
        {
            var notes = DataAccessObject.GetAllNotes();
            foreach (var note in notes)
            {
                notesDisplayCollection.Add(new Note() {Id = note.Id, Title = note.Title, Content = note.Content});
            }
        }
    }
}
