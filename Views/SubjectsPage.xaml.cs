using SchoolProject.ViewModels;

namespace SchoolProject.Views;

public partial class SubjectsPage : ContentPage
{
    //link viewmodel to view
    private SubjectViewModel _viewModel;

    //pass viewmodel
    public SubjectsPage(SubjectViewModel vm)
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
        _viewModel.GetSubjectListCommand.Execute(null);
    }


}
