using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

namespace MobileApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public IEnumerable<Note> Notes = new List<Note>();
        public MainPage()
        {
            InitializeComponent();
        }

        public void AddMockedNote(object sender, EventArgs args)
        {
            var dataAccessObject = new DataAccess();
            var note = new Note()
            {
                Title = "Test Note",
                Content = "Test Content"
            };
            dataAccessObject.AddNote(note);
        }

        public void GetAllNotes(object sender, EventArgs args)
        {
            var dataAccessObject = new DataAccess();
            var notes = dataAccessObject.GetAllNotes();

            Notes = notes;
        }
    }   
}
