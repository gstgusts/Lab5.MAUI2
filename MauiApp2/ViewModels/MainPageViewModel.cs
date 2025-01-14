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
        private readonly IDataRepository _dataRepository;

        public MainPageViewModel(IDataRepository dataRepository)
        {
            Title = "Loading ...";
            _dataRepository = dataRepository;

            LoadCommand = new RelayCommand(LoadData);
            SelectStudentCommand = new RelayCommand(ShowDetails);

            LoadData();
        }

        public MainPageViewModel()
        {
            
        }

        public async void ShowDetails()
        {
            var navigationParameter = new ShellNavigationQueryParameters
            {
                { "Student", SelectedStudent }
            };

            await Shell.Current.GoToAsync("//GradesPage", navigationParameter);
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

        private Student _selectedStudent;
        public Student SelectedStudent
        {
            get
            {
                return _selectedStudent;
            }
            set
            {
                _selectedStudent = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoadCommand { get; }

        public ICommand SelectStudentCommand { get; }

        public async void LoadData()
        {
            Title = "Loading ...";

            var data = await _dataRepository.GetStudentsAsync();
            Students = data;
            Title = "Number of students: " + data.Length;
        }
    }
}
