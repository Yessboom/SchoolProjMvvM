using SchoolProject.ViewModels.AddUpdateViewModels;

namespace SchoolProject.Views.AddUpdateViews;

public partial class AddUpdateSubjectPage : ContentPage
{
    public AddUpdateSubjectPage(AddUpdateSubjectViewModel vm)
    {
        InitializeComponent();
        this.BindingContext = vm;
    }
}