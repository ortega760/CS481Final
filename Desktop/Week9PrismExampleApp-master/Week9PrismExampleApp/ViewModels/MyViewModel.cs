using System;

using Xamarin.Forms;

namespace Week9PrismExampleApp.ViewModels
{
    public class MyViewModel : ContentView
    {
        public MyViewModel()
        {
            Content = new Label { Text = "Hello ContentView" };
        }
    }
}

