using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;
using System.Collections.ObjectModel;
using Xamarin.Forms.Xaml;
using static Week9PrismExampleApp.Models.WeatherItemModel;

namespace Week9PrismExampleApp.ViewModels
{
    public class NextPage4ViewModel : BindableBase, INavigatedAware
    {
        public DelegateCommand GoBackCommand { get; set; }
        public DelegateCommand NavToNewPageCommand { get; set; }
        INavigationService _navigationService;

        private WeatherItem _weatherItem;
        public WeatherItem WeatherItem
        {
            get { return _weatherItem; }
            set { SetProperty(ref _weatherItem, value); }
        }

        public NextPage4ViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            GoBackCommand = new DelegateCommand(GoBack);
        }

        private async void NavToNewPage()
        {
            var navParams1 = new NavigationParameters();
            navParams1.Add("NavFromPage", "MainPageViewModel");
            await _navigationService.NavigateAsync("SamplePageForNavigation", navParams1);

        }

        private void GoBack()
        {
            _navigationService.GoBackAsync();
        }
        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("WeatherItemInfo"))
            {
                WeatherItem = (WeatherItem)parameters["WeatherItemInfo"];
            }

        }
    }
}
