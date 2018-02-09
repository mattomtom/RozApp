using System;

using Xamarin.Forms;

namespace RozApp
{
    public class ConfirmPage : ContentPage
    {
        public ConfirmPage(string text)
        {
            var confirmButton = new Button()
            {
                Text = "Potwierdź"
            };

            var noButton = new Button()
            {
                Text = "Niepoprawnie",
            };

            confirmButton.Clicked += (sender, e) =>
            {
                Navigation.PopAsync();
            }; 

            noButton.Clicked += (sender, e) =>
            {
                Navigation.PopModalAsync();
            }; 

            Content = new StackLayout
            {
                Children = {
                    new Label { Text = text },
                    confirmButton,
                    noButton
                }
            };
        }
    }
}

