using SchoolProject.Services;
using SchoolProject.Handlers;
namespace SchoolProject
{
    public partial class App : Application
    {
        //initializing repos form interfaces
        public static ITeacherService TeacherRepo { get; private set; }
        public static IStudentService StudentRepo { get; private set; }
        public static ISubjectService SubjectRepo { get; private set; }

        public App(ITeacherService teacherRepo, IStudentService studentRepo, ISubjectService subjectRepo)
        {
            InitializeComponent();
            //borderless entry code for Windows machines
            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(BordlessEntry), (handler, view) =>
            {
#if WINDOWS
              handler.PlatformView.BorderThickness = new Microsoft.UI.Xaml.Thickness(0);

#endif
            });

            MainPage = new AppShell();
            //Initializing our repos
            TeacherRepo = teacherRepo;
            StudentRepo = studentRepo;
            SubjectRepo = subjectRepo;
        }
    }
}
