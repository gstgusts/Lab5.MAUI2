using AndroidX.Lifecycle;
using Lab5.MAUIData.Interfaces;
using Lab5.MAUIData.Models;
using Lab5.MAUIData.Services;
using MauiApp2.ViewModels;

namespace MauiApp2;

[QueryProperty(nameof(Student), "Student")]
public partial class GradesPage : ContentPage
{
    private GradesPageViewModel _viewModel;

    Student student;
    public Student Student
    {
        get => student;
        set
        {
            student = value;
            _viewModel.Student = value;
            OnPropertyChanged();
        }
    }

    public GradesPage(GradesPageViewModel viewModel)
	{
		InitializeComponent();

        _viewModel = viewModel;
        BindingContext = _viewModel;
    }
}