using Lab5.MAUIData.Interfaces;
using Lab5.MAUIData.Services;
using MauiApp2.ViewModels;
using Newtonsoft.Json;

namespace MauiApp2
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage(MainPageViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }

}
