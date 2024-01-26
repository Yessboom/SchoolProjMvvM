using SchoolProject.ViewModels.AddUpdateViewModels;

namespace SchoolProject.Views.AddUpdateViews;

public partial class AddUpdateStudentPage : ContentPage
{
	public AddUpdateStudentPage(AddUpdateStudentViewModel vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}
}