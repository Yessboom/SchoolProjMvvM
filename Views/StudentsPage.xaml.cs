using SchoolProject.ViewModels;

namespace SchoolProject.Views
{
    public partial class StudentsPage : ContentPage
    {
        private StudentViewModel _viewModel;
        public StudentsPage(StudentViewModel vm)
        {
            InitializeComponent();
            _viewModel = vm;
            this.BindingContext = vm;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.GetStudentListCommand.Execute(null);
        }
    }
}
