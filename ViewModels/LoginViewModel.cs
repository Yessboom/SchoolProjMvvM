using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using SchoolProject.Services;

namespace SchoolProject.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        //get email from input
        [ObservableProperty]
        string email;
        //get pw from input
        [ObservableProperty]
        string password;
        //display message if auth credentails is incorrect
        [ObservableProperty]
        string errorMessage;
        //switch between staying logged in or not
        [ObservableProperty]
        bool stayLoggedOn = false;



        //staying logged in functionality
        [ICommand]
        public async void GoToDashboard()
        {
            //get loggedin prefrence
            bool isLoggedOn = Preferences.Get("StayLoggedOn", false);
            if (isLoggedOn)
            {
                //navigate directly to dashboard
                await Shell.Current.GoToAsync("/DashboardPage");
            }
            else
            {

            }
        }
    }
}
