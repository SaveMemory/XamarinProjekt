using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NoteView : ContentPage
    {
        private DataAccess DataAccessObject { get; set; }
        private NoteViewModel Note { get; set; }

        public NoteView(NoteViewModel noteViewModel)
        {
            InitializeComponent();

            Note = new NoteViewModel();
            DataAccessObject = new DataAccess();

            Note.Id = noteViewModel.Id;
            Note.Title = noteViewModel.Title;
            Note.Content = noteViewModel.Content;

            title.Text = Note.Title;
            content.Text = Note.Content;
        }

        private void SaveNote(object sender, EventArgs e)
        {
            DataAccessObject.SaveNote(Note);
            NavigateToMainPage();
        }

        private void DeleteNote(object sender, EventArgs e)
        {
            if (Note.Id != 0)
            {
                DataAccessObject.DeleteNote(Note.Id);
                NavigateToMainPage();
            }
            else
            {
                DisplayAlert("Error", "Cannot delete non existent note", "OK");
            }
        }

        private void NavigateToMainPage()
        {
            Application.Current.MainPage =
                new NavigationPage(new MainPage());
        }

        private void Title_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            Note.Title = e.NewTextValue;
        }

        private void Content_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            Note.Content = e.NewTextValue;
        }
    }
}