﻿using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace ObjectDetector
{
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
            ((SettingsViewModel)BindingContext).ConfigureCanCancelCommand.Execute(null);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await ((SettingsViewModel)BindingContext).SetUp();
        }

        public static Xamarin.Forms.Page CreateSettingsPage()
        {
            var settings = new Xamarin.Forms.NavigationPage(new SettingsPage())
            {
                BarBackgroundColor = Color.DarkSlateBlue,
                BarTextColor = Color.White
            };
            settings.On<iOS>().SetPrefersLargeTitles(true);

            return settings;
        }
    }
}
