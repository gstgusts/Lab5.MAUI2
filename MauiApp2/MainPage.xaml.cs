using Lab5.MAUIData.Interfaces;
using Lab5.MAUIData.Services;
using MauiApp2.Models;
using Newtonsoft.Json;

namespace MauiApp2
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        private readonly IApiDataRepository _apiRepository;

        public MainPage()
        {
            InitializeComponent();

            _apiRepository = new ApiDataRepository(new StudentApiClient());
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            var students = await _apiRepository.GetStudentsAsync();
        }
    }

}
