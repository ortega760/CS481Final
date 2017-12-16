﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Prism.Unity;
using Week9PrismExampleApp.Views;
using Xamarin.Forms.Xaml;

namespace Week9PrismExampleApp
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync($"MainPage");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<SamplePageForNavigation>();
            Container.RegisterTypeForNavigation<MoreInfoPage>();
            Container.RegisterTypeForNavigation<NextPage1>();
            Container.RegisterTypeForNavigation<NextPage2>();
            Container.RegisterTypeForNavigation<NextPage3>();
            Container.RegisterTypeForNavigation<NextPage4>();
		}
    }
}

