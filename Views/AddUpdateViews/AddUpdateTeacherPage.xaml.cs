
using SchoolProject.ViewModels.AddUpdateViewModels;

namespace SchoolProject.Views.AddUpdateViews;

public partial class AddUpdateTeacherPage : ContentPage
{
	public AddUpdateTeacherPage(AddUpdateTeacherViewModel vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}
}