using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab5.MAUIData.Interfaces;
using Lab5.MAUIData.Models;
using static Android.Icu.Text.CaseMap;

namespace MauiApp2.ViewModels
{
    public class GradesPageViewModel : ViewModelBase
    {
        private readonly IDataRepository _dataRepository;

        public GradesPageViewModel(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        Student student;
        public Student Student
        {
            get => student;
            set
            {
                student = value;
                OnPropertyChanged();

                LoadData();
            }
        }

        private Grade[] _grades;

        public Grade[] Grades
        {
            get => _grades;
            set
            {
                _grades = value;
                OnPropertyChanged();
            }
        }

        public async Task LoadData()
        {
            var data = await _dataRepository.GetStudentGradesAsync(Student.Id);
            Grades = data;
        }
    }
}
