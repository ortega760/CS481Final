using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.Net.Http;
using static Week9PrismExampleApp.Models.WeatherItemModel;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Week9PrismExampleUnitTests")]
namespace Week9PrismExampleApp.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
		public DelegateCommand NavToNewPageCommand { get; set; }
		public DelegateCommand GetWeatherForLocationCommand { get; set; }
		public DelegateCommand<WeatherItem> NavToMoreInfoPageCommand { get; set; }
        public DelegateCommand<WeatherItem> NavToMoreInfoPageCommand1 { get; set; }
        public DelegateCommand<WeatherItem> NavToMoreInfoPageCommand2 { get; set; }
        public DelegateCommand<WeatherItem> NavToMoreInfoPageCommand3 { get; set; }
        public DelegateCommand<WeatherItem> NavToMoreInfoPageCommand4 { get; set; }

        public DelegateCommand<WeatherItem> DeleteInfoCommand { get; set; }

		private string _buttonText;
        public string ButtonText
        {
            get { return _buttonText; }
            set { SetProperty(ref _buttonText, value); }
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        private string _titletext;
        public string Titletext
        {
            get { return _titletext; }
            set { SetProperty(ref _titletext, value); }
        }

        private string _locationEnteredByUser;
        public string LocationEnteredByUser
        {
            get { return _locationEnteredByUser; }
            set { SetProperty(ref _locationEnteredByUser, value); }
        }

        private ObservableCollection<WeatherItem> _weatherCollection = new ObservableCollection<WeatherItem>();
        public ObservableCollection<WeatherItem> WeatherCollection
        {
            get { return _weatherCollection; }
            set { SetProperty(ref _weatherCollection, value); }
        }

        INavigationService _navigationService;

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            NavToNewPageCommand = new DelegateCommand(NavToNewPage);
            GetWeatherForLocationCommand = new DelegateCommand(GetWeatherForLocation);
            NavToMoreInfoPageCommand = new DelegateCommand<WeatherItem>(NavToMoreInfoPage);
            NavToMoreInfoPageCommand1 = new DelegateCommand<WeatherItem>(NavToMoreInfoPage1);
            NavToMoreInfoPageCommand2 = new DelegateCommand<WeatherItem>(NavToMoreInfoPage2);
            NavToMoreInfoPageCommand3 = new DelegateCommand<WeatherItem>(NavToMoreInfoPage3);
            NavToMoreInfoPageCommand4 = new DelegateCommand<WeatherItem>(NavToMoreInfoPage4);

            DeleteInfoCommand = new DelegateCommand<WeatherItem>(DeleteInfo);         
            Title = "Xamarin Forms Application + Prism";
            ButtonText = "Add Name";
            Titletext = "Weather Seeker";
        }

        private void DeleteInfo(WeatherItem weatherItem)
        {
            _weatherCollection.Remove(weatherItem);
        }

        private async void NavToMoreInfoPage(WeatherItem weatherItem)
        {
            var navParams = new NavigationParameters();
            navParams.Add("WeatherItemInfo", weatherItem);

            await _navigationService.NavigateAsync("MoreInfoPage", navParams);
        }
        private async void NavToMoreInfoPage1(WeatherItem weatherItem)
        {
            var navParams = new NavigationParameters();
            navParams.Add("WeatherItemInfo", weatherItem);

            await _navigationService.NavigateAsync("NextPage1", navParams);
        }

        private async void NavToMoreInfoPage2(WeatherItem weatherItem)
        {
            var navParams = new NavigationParameters();
            navParams.Add("WeatherItemInfo", weatherItem);

            await _navigationService.NavigateAsync("NextPage2", navParams);
        }

        private async void NavToMoreInfoPage3(WeatherItem weatherItem)
        {
            var navParams = new NavigationParameters();
            navParams.Add("WeatherItemInfo", weatherItem);

            await _navigationService.NavigateAsync("NextPage3", navParams);
        }

        private async void NavToMoreInfoPage4(WeatherItem weatherItem)
        {
            var navParams = new NavigationParameters();
            navParams.Add("WeatherItemInfo", weatherItem);

            await _navigationService.NavigateAsync("NextPage4", navParams);
        }
      
        internal async void GetWeatherForLocation()
        {
            HttpClient client = new HttpClient();
            var uri = new Uri(
                string.Format(
                    $"http://api.openweathermap.org/data/2.5/weather?q={LocationEnteredByUser}&units=imperial&APPID=" +
                    $"{ApiKeys.weatherKey}"));
            var response = await client.GetAsync(uri);
            WeatherItem weatherData = null;
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                weatherData = WeatherItem.FromJson(content);
            }
            WeatherCollection.Add(weatherData);
        }

        private async void NavToNewPage()
        {
            var navParams = new NavigationParameters();
            navParams.Add("NavFromPage", "MainPageViewModel");
            await _navigationService.NavigateAsync("SamplePageForNavigation", navParams);
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
        }
    }
}

