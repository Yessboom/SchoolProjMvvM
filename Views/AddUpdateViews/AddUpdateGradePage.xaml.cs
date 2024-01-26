using SchoolProject.ViewModels.AddUpdateViewModels;

namespace SchoolProject.Views.AddUpdateViews;

public partial class AddUpdateGradePage : ContentPage
{
    public AddUpdateGradePage(AddUpdateGradeViewModel vm)
    {
        InitializeComponent();
        this.BindingContext = vm;
    }
}