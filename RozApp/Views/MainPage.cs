using System;
using System.Collections.Generic;
using System.Diagnostics;
using RozApp.Data;
using RozApp.Services;
using Syncfusion.SfAutoComplete.XForms;
using Xamarin.Forms;

namespace RozApp.Views
{
    public class MainPage : ContentPage
    {
        public MainPage()
        {
            Title = "Panel przeglądania";

            List<String> nameList = new List<String>();

            StackLayout mainLayout;

            Label numberLabel = new Label
            {
                HorizontalTextAlignment = TextAlignment.Center,
                Margin = new Thickness(0, 70, 0, 0),
                FontSize = 80,
                TextColor = Color.Black
            };

            var speechButton = new Button
            {
                Text = "Wyszukiwanie głosowe"
            };

            speechButton.Clicked += (sender, e) =>
            {
                Debug.WriteLine("Speech button clicked.");
                var service = DependencyService.Get<ISpeechToText>();
                service.StartReconigze();
            };

            var editButton = new Button
            {
                Text = "Wprowadź"
            };

            Content = mainLayout = new StackLayout
            {
                Margin = 40,
                VerticalOptions = LayoutOptions.Start,
                Children =
                {
                    new Label { Text = "Wyszukaj:", FontSize= 20, TextColor = Color.Black },
                }
            };

            SfAutoComplete autoComplete = new SfAutoComplete()
            {
                HeightRequest = 40,
            };

            autoComplete.DataSource = nameList;
            autoComplete.SuggestionMode = SuggestionMode.Contains;

            autoComplete.SelectionChanged += (sender, e) =>
            {
                string text = (string)autoComplete.SelectedValue;
            };
            mainLayout.Children.Add(autoComplete);
            mainLayout.Children.Add(numberLabel);
            mainLayout.Children.Add(speechButton);
            mainLayout.Children.Add(editButton);
        }
    }
}
