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
    public class MoreInfoPageViewModel : BindableBase, INavigatedAware
    {
		INavigationService _navigationService;

        public DelegateCommand NavToNewPageCommand { get; set; }
        public DelegateCommand GoBackCommand { get; set; }

        private WeatherItem _weatherItem;
        public WeatherItem WeatherItem
        {
            get { return _weatherItem; }
            set { SetProperty(ref _weatherItem, value); }
        }

        private async void NavToNextPage1(WeatherItem weatherItem)
        {
            var navParams = new NavigationParameters();
            navParams.Add("WeatherItemInfo", weatherItem);
            await _navigationService.NavigateAsync("NextPage1", navParams);
        }

        public MoreInfoPageViewModel(INavigationService navigationService)
        {
			_navigationService = navigationService;
			GoBackCommand = new DelegateCommand(GoBack);
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
