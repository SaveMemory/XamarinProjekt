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
        ObservableCollection<NoteViewModel> notesDisplayCollection = new ObservableCollection<NoteViewModel>();
        private ObservableCollection<NoteViewModel> Notes => notesDisplayCollection;
        private DataAccess DataAccessObject;

        public MainPage()
        {
            InitializeComponent();
            NotesView.ItemsSource = Notes;
            DataAccessObject = new DataAccess();
            GetAllNotes();
        }

        private void GetAllNotes()
        {
            notesDisplayCollection.Clear();
            var notes = DataAccessObject.GetAllNotes();
            foreach (var note in notes)
            {
                var noteToAdd = new NoteViewModel() {Id = note.Id, Title = note.Title, Content = note.Content};
                notesDisplayCollection.Add(noteToAdd);
            }
        }

        private void ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var note = e.SelectedItem as NoteViewModel;
            Application.Current.MainPage = new NavigationPage(new NoteView(note));
        }

        private void NavigateToNewNote(object sender, EventArgs e)
        {
            Application.Current.MainPage =
                new NavigationPage(new NoteView(new NoteViewModel() {Id = 0, Title = "", Content = ""}));
        }
    }
}
