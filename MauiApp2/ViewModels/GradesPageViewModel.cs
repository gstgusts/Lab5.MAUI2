using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using Lab5.MAUIData.Interfaces;
using Lab5.MAUIData.Models;

namespace MauiApp2.ViewModels
{
    public class GradesPageViewModel : ViewModelBase
    {
        private readonly IDataRepository _dataRepository;

        public GradesPageViewModel()
        {
            
        }
        public GradesPageViewModel(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;

            DeleteCommand = new RelayCommand(DeleteGrade);
            SelectGradeCommand = new RelayCommand(GradeSelected);

            DeleteConfirmCommand = new RelayCommand(ConfirmDeleteGrade);
            DeleteCancelCommand = new RelayCommand(CancelDeleteGrade);

            EditStudentCommand = new RelayCommand(EditStudentDetails);

            UpdateConfirmCommand = new RelayCommand(ConfirmUpdateStudent);
            UpdateCancelCommand = new RelayCommand(CancelUpdateStudent);

            ValidateCommand = new RelayCommand(ValidateStudent);

            IsEditEnabled = false;
            IsReadOnly = !IsEditEnabled;
        }

        private void ValidateStudent()
        {
            IsStudentDataValid();
        }

        Student student;
        public Student Student
        {
            get => student;
            set
            {
                student = value;

                IsDeleteEnabled = false;

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

        public ICommand DeleteCommand { get; }

        public ICommand SelectGradeCommand { get; }

        public ICommand DeleteConfirmCommand { get; }

        public ICommand DeleteCancelCommand { get; }

        public ICommand EditStudentCommand { get; }

        public ICommand UpdateConfirmCommand { get; }

        public ICommand UpdateCancelCommand { get; }

        public ICommand ValidateCommand { get; }

        public void DeleteGrade()
        {
            IsDeleteConfirmationVisible = true;
        }

        public void GradeSelected()
        {
            IsDeleteEnabled = true;
        }

        public void EditStudentDetails()
        {
            IsEditEnabled = true;
            IsReadOnly = !IsEditEnabled;
        }

        private Grade _selectedGrade;
        public Grade SelectedGrade
        {
            get
            {
                return _selectedGrade;
            }
            set
            {
                _selectedGrade = value;
                OnPropertyChanged();
            }
        }

        private bool _isDeleteEnabled;
        public bool IsDeleteEnabled
        {
            get
            {
                return _isDeleteEnabled;
            }
            set
            {
                _isDeleteEnabled = value;
                OnPropertyChanged();
            }
        }

        private bool _isDeleteConfirmationVisible;
        public bool IsDeleteConfirmationVisible
        {
            get
            {
                return _isDeleteConfirmationVisible;
            }
            set
            {
                _isDeleteConfirmationVisible = value;
                OnPropertyChanged();
            }
        }

        private bool _isEditEnabled;
        public bool IsEditEnabled
        {
            get
            {
                return _isEditEnabled;
            }
            set
            {
                _isEditEnabled = value;
                OnPropertyChanged();
            }
        }

        private bool _isReadOnly;
        public bool IsReadOnly
        {
            get
            {
                return _isReadOnly;
            }
            set
            {
                _isReadOnly = value;
                OnPropertyChanged();
            }
        }

        private bool _isCodeInValid;
        public bool IsCodeInValid
        {
            get
            {
                return _isCodeInValid;
            }
            set
            {
                _isCodeInValid = value;
                OnPropertyChanged();
            }
        }

        private bool _isNameInValid;
        public bool IsNameInValid
        {
            get
            {
                return _isNameInValid;
            }
            set
            {
                _isNameInValid = value;
                OnPropertyChanged();
            }
        }

        private bool _isSurnameInValid;
        public bool IsSurnameInValid
        {
            get
            {
                return _isSurnameInValid;
            }
            set
            {
                _isSurnameInValid = value;
                OnPropertyChanged();
            }
        }

        private void CancelDeleteGrade()
        {
            IsDeleteConfirmationVisible = false;
        }

        private async void ConfirmDeleteGrade()
        {
            await _dataRepository.DeleteGrade(Student.Id, SelectedGrade.Id);
            IsDeleteConfirmationVisible = false;
            IsDeleteEnabled = false;

            await LoadData();
        }

        private void CancelUpdateStudent()
        {
            IsEditEnabled = false;
            IsReadOnly = !IsEditEnabled;
        }

        private async void ConfirmUpdateStudent()
        {
            if (!IsStudentDataValid())
            {
                return;
            }

            await _dataRepository.UpdateStudentAsync(Student);

            OnPropertyChanged(nameof(Student));

            IsEditEnabled = false;
            IsReadOnly = !IsEditEnabled;
        }

        private bool IsStudentDataValid()
        {
            IsCodeInValid = string.IsNullOrEmpty(Student.Code);

            IsNameInValid = string.IsNullOrEmpty(Student.Name);

            IsSurnameInValid = string.IsNullOrEmpty(Student.Surname);

            if (string.IsNullOrEmpty(Student.Code)
                || string.IsNullOrEmpty(Student.Name)
                || string.IsNullOrEmpty(Student.Surname))
            {
                return false;
            }

            return true;
        }
    }
}
