using System;
using System.IO;
using RozApp.Services;
using Xamarin.Forms;
using System.Reflection;
using System.Diagnostics;
using System.Collections.Generic;
using RozApp.Models;
using System.Xml.Serialization;
using RozApp.Data;

namespace RozApp.Views
{
    public class MenuPage : ContentPage
    {
        public MenuPage()
        {
            var kasz = new InitalData();

            Title = "Menu";

            var pickYearLabel = new Label
            {
                Text = "Wybierz lata:"
            };

            var year2018Label= new Label
            {
                Text = "2018",
                FontSize = 40
            };

            var year2018Switch = new Switch
            {
                
            };

            var year2018Layout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = {
                    year2018Label,
                    year2018Switch
                }
            };

            var year2017Label = new Label
            {
                Text = "2017",
                FontSize = 40
            };


            var year2017Switch = new Switch
            {
                
            };

            var year2017Layout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = {
                    year2017Label,
                    year2017Switch
                }
            };

            var year2016Label = new Label
            {
                Text = "2016",
                FontSize = 40
            };

            var year2016Switch = new Switch
            {
                
            };

            var year2016Layout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = {
                    year2016Label,
                    year2016Switch
                }
            };

            var seeDataButton = new Button
            {
                VerticalOptions = LayoutOptions.StartAndExpand,
                Text = "Zobacz wybrane lata"
            }; 
            seeDataButton.Clicked += async (sender, e) => 
            {
                await Navigation.PushAsync(new MainPage());
            };
            
            var addDataButton = new Button
            {
                Text = "Dodaje dane"
            };
            addDataButton.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new AddPage());
            };

            Content = new StackLayout
            {
                Padding = 20,
                Children = {
                    pickYearLabel,
                    year2018Layout,
                    year2017Layout,
                    year2016Layout,
                    seeDataButton,
                    addDataButton
                }
            };
        }
    }
}

