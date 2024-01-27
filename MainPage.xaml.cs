using SchoolProject.ViewModels;

namespace SchoolProject
{
    public partial class MainPage : ContentPage
    {
        //link viewmodel to view

        public MainPage()
        {
            
            InitializeComponent();

            //bind viewmodel
        }

        protected override void OnAppearing()
        {
            //run getsubjects when page loads

        }
    }

}
