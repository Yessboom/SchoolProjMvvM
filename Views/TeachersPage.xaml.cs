using SchoolProject.ViewModels;

namespace SchoolProject.Views;

public partial class TeachersPage : ContentPage
{
    //link viewmodel to view
    private TeacherViewModel _viewModel;
    public TeachersPage(TeacherViewModel vm)
    {
        InitializeComponent();
        _viewModel = vm;
        //bind viewmodel
        this.BindingContext = vm;
    }

    protected override void OnAppearing()
    {
        //run getsubjects when page loads
        base.OnAppearing();
        _viewModel.GetTeacherListCommand.Execute(null);
    }
}
