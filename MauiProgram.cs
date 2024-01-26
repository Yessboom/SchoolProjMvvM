using Microsoft.Extensions.Logging;
using SchoolProject.Services;
using Microsoft.Extensions.DependencyInjection;
using SkiaSharp.Views.Maui.Controls.Hosting;
using SchoolProject.ViewModels;
using SchoolProject.ViewModels.AddUpdateViewModels;
using SchoolProject.Views.AddUpdateViews;
using SchoolProject.Views;
namespace SchoolProject
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseSkiaSharp()
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    //initalizing fonts for project
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Roboto-Bold.ttf", "Roboto-Bold");
                    fonts.AddFont("Roboto-Regular.ttf", "Roboto-Regular");
                    fonts.AddFont("Rubik-Bold.ttf", "Rubik-Bold");
                    fonts.AddFont("Rubik-Regular.ttf", "Rubik-Regular");
                });

            //Services
            builder.Services.AddSingleton<IStudentService, StudentRepository>();
            builder.Services.AddSingleton<ITeacherService, TeacherRepository>();
            builder.Services.AddSingleton<ISubjectService, SubjectRepository>();
            builder.Services.AddSingleton<IGradeService, GradeRepository>();

            //Views
            builder.Services.AddSingleton<DashboardPage>();

            builder.Services.AddSingleton<StudentsPage>();
            builder.Services.AddTransient<AddUpdateStudentPage>();

            builder.Services.AddSingleton<SubjectsPage>();
            builder.Services.AddTransient<AddUpdateSubjectPage>();

            builder.Services.AddSingleton<TeachersPage>();
            builder.Services.AddTransient<AddUpdateTeacherPage>();

            builder.Services.AddSingleton<MainPage>();

            builder.Services.AddTransient<AddUpdateGradePage>();




            //Viewmodels

            builder.Services.AddSingleton<TeacherViewModel>();
            builder.Services.AddTransient<AddUpdateTeacherViewModel>();

            builder.Services.AddSingleton<StudentViewModel>();
            builder.Services.AddTransient<AddUpdateStudentViewModel>();

            builder.Services.AddSingleton<SubjectViewModel>();
            builder.Services.AddTransient<AddUpdateSubjectViewModel>();

            builder.Services.AddTransient<AddUpdateGradeViewModel>();
            builder.Services.AddSingleton<LoginViewModel>();


            return builder.Build();
        }
    }
}
