using CommunityToolkit.Mvvm.ComponentModel;
using SchoolProject.Models;
using SchoolProject.Services;
using Microsoft.Toolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Reflection;

namespace SchoolProject.ViewModels.AddUpdateViewModels
{
    //url queries to pass between pages
    [QueryProperty(nameof(TeacherDetail), "TeacherDetail")]


    public partial class AddUpdateTeacherViewModel : ObservableObject
    {


        //Observable collection to populate picker with list of Majors
        public ObservableCollection<SubjectModel> Subjects { get; set; } = new ObservableCollection<SubjectModel>();

        //call db data from TeacherModel Table
        [ObservableProperty]
        public TeacherModel _teacherDetail = new TeacherModel();

        //Initialize Interface for CRUD functions
        private readonly ITeacherService _teacherRepository;
        public AddUpdateTeacherViewModel(ITeacherService teacherService)
        {
            _teacherRepository = teacherService;

            //New instance of List for subjects
            listOfSubjects = new List<SubjectModel>();
            //call function to load GetSubjectList()
            GetListOfSubjects();
        }


        //initiate new list for subjects
        [ObservableProperty]
        List<SubjectModel> listOfSubjects;

        //listen and populate lecturer chosen from picker as selectedLecturer ///////////////////////////
        [ObservableProperty]
        SubjectModel selectedLecturer;

        [ObservableProperty]
        int totalhours;

        [ObservableProperty]
        int totalSalary;

        //function to load GetTeacherList()
        public async void GetListOfSubjects()
        {
            // T<List> -> <List> 
            //get list of lecturers from repository
            listOfSubjects = await App.SubjectRepo.GetSubjectList();

            //loop through list of teacher
            foreach (var listOfSubjects in listOfSubjects.ToList())
            {
                //populate observable collection with only lecturers
                if (listOfSubjects.SubjectLecturer == TeacherDetail.TeacherFirstName)
                {
                    TeacherDetail.TeacherClass = listOfSubjects.SubjectTitle;
 
                }
            }
        }




        //add display action to assign active state
        [ICommand]
        public async void AddUpdateTeacher()
        {
            int response = -1;
            if (TeacherDetail.TeacherID > 0)
            {
                //edit teacher details
                response = await _teacherRepository.EditTeacher(TeacherDetail);
            }
            else
            {
                //add new teacher to Table
                response = await _teacherRepository.AddTeacher(new Models.TeacherModel
                {
                    TeacherFirstName = TeacherDetail.TeacherFirstName,
                    TeacherLastName = TeacherDetail.TeacherLastName,
                    TeacherSalary = TeacherDetail.TeacherSalary,
                });
            }

            //respond if added to table or error occured
            if (response > 0)
            {
                await Shell.Current.DisplayAlert("Teacher info saved", "Record Saved", "OK");
            }
            else
            {
                await Shell.Current.DisplayAlert("Not added", "Something went wrong while adding record", "OK");
            }

        }
    }
}












