using System;

using Xamarin.Forms;

namespace RozApp.Views
{
    public class AddPage : ContentPage
    {
        public AddPage()
        {
            Title = "Panel dodawania";

            var firstNameLabel = new Label
            {
                Text = "Imie:"
            };
            
            var firstNameEntry = new Entry
            {

            };

            var lastNameLabel = new Label
            {
                Text = "Nazwisko:"
            };

            var lastNameEntry = new Entry
            {

            };

            var segmantLabel = new Label
            {
                Text = "Segreator:"
            };

            var segmentEntry = new Entry
            {

            };

            var yearLabel = new Label
            {
                Text = "Rok:"
            };

            var yearEntry = new Entry
            {
                VerticalOptions = LayoutOptions.StartAndExpand
            };

            var doneButton = new Button
            {
                Text = "Zapisz do bazy"
            };

            Content = new StackLayout
            {
                Padding = 20,
                Children = {
                    firstNameLabel,
                    firstNameEntry,
                    lastNameLabel,
                    lastNameEntry,
                    segmantLabel,
                    segmentEntry,
                    yearLabel,
                    yearEntry,
                    doneButton
                }
            };
        }
    }
}

