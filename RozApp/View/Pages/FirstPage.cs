using System;
using System.Collections.Generic;
using RozApp.ViewModel;
using Syncfusion.SfAutoComplete.XForms;
using Xamarin.Forms;

namespace RozApp.View.Pages
{
    public class FirstPage : ContentPage
    {
        public FirstPage()
        {
            List<String> countryNames = new List<String>();
            countryNames.Add("Kowalski Jan");
            countryNames.Add("Tomaszewski Mateusz");
            countryNames.Add("Tomaszewski Tomasz");
            countryNames.Add("Mieszko Pierwszy");
            countryNames.Add("Nowak Michał");
            countryNames.Add("Gralikowski Karol");
            countryNames.Add("Konieczny Cezary");

            StackLayout layout;
            Button actionButton = new Button
            {
                Text = "Szukaj",
                FontSize = 25,
                HeightRequest = 80
            };
            // The root page of your application

            Content = layout = new StackLayout
            {
                Margin = 40,
                VerticalOptions = LayoutOptions.Start,
                Children = 
                {
                    new Label { Text = "Nazwisko:", FontSize= 20},
                }
            };
        
            SfAutoComplete autoComplete = new SfAutoComplete()
            {
                HeightRequest = 40,
            };

            //autoComplete.BindingContext = new NameViewModel();
            autoComplete.DataSource = countryNames;
            //autoComplete.DisplayMemberPath = "Sname";
            //autoComplete.SelectedValuePath = "ID";
            autoComplete.SelectionChanged += (sender, e) => {
                DisplayAlert("Selection Changed", "Selected Value: " + autoComplete.SelectedValue.ToString(), "OK");
            };
            layout.Children.Add(autoComplete);
            layout.Children.Add(actionButton);
        }
    }
}
