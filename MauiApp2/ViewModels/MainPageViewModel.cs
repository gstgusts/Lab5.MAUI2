using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Lab5.MAUIData.Interfaces;
using Lab5.MAUIData.Models;

namespace MauiApp2.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly IApiDataRepository _apiDataRepository;

        public MainPageViewModel(IApiDataRepository apiDataRepository)
        {
            Title = "Loading ...";
            _apiDataRepository = apiDataRepository;

            LoadCommand = new RelayCommand(LoadData);

            LoadData();
        }

        private string _title;

        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }

        private Student[] _students;

        public Student[] Students
        {
            get
            {
                return _students;
            }
            set
            {
                _students = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoadCommand { get; }

        public async void LoadData()
        {
            Title = "Loading ...";
            var data = await _apiDataRepository.GetStudentsAsync();
            Students = data;
            Title = "Number of students: " + data.Length;
        }
    }
}
