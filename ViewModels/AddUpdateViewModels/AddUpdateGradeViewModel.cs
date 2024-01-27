using CommunityToolkit.Mvvm.ComponentModel;
using SchoolProject.Models;
using SchoolProject.Services;
using Microsoft.Toolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Reflection;

namespace SchoolProject.ViewModels.AddUpdateViewModels
{
    //url queries to pass between pages
    [QueryProperty(nameof(GradeDetail), "GradeDetail")]


    public partial class AddUpdateGradeViewModel : ObservableObject
    {


        //Observable collection to populate picker with list of Majors
        public ObservableCollection<SubjectModel> Sub { get; set; } = new ObservableCollection<SubjectModel>();
        public ObservableCollection<StudentModel> Stud { get; set; } = new ObservableCollection<StudentModel>();


        //call db data from GradeModel Table
        [ObservableProperty]
        public GradeModel _gradeDetail = new GradeModel();

        //Initialize Interface for CRUD functions
        private readonly IGradeService _gradeRepository;
        public AddUpdateGradeViewModel(IGradeService gradeService)
        {
            _gradeRepository = gradeService;

            //New instance of List for subjects
            listOfSubjects = new List<SubjectModel>();

            //New instance of list of students
            listOfStudents = new List<StudentModel>();
            //call function to load GetSubjectList()
            GetListOfSubjects();
            GetListOfStudents();
        }


        //initiate new list for subjects
        [ObservableProperty]
        List<SubjectModel> listOfSubjects;

        [ObservableProperty]
        List<StudentModel> listOfStudents;

        //listen and populate lecturer chosen from picker as selectedLecturer ///////////////////////////
        [ObservableProperty]
        StudentModel selectedStudent;

        [ObservableProperty]
        SubjectModel selectedSubject;




        //function to load GetGradeList()
        public async void GetListOfSubjects()
        {
            // T<List> -> <List> 
            //get list of lecturers from repository
            ListOfSubjects = await App.SubjectRepo.GetSubjectList();

            //loop through list of teacher
            foreach (var listOfSubject in listOfSubjects.ToList())
            {

                Sub.Add(listOfSubject);

            }
        }

        public async void GetListOfStudents()
        {
            // T<List> -> <List> 
            //get list of lecturers from repository
            ListOfStudents = await App.StudentRepo.GetStudentList();

            //loop through list of teacher
            foreach (var listOfStudent in listOfStudents.ToList())
            {

                Stud.Add(listOfStudent);

            }
        }






        //add display action to assign active state
        [ICommand]
        public async void AddUpdateGrade()
        {
            int response = -1;
            if (GradeDetail.GradeID > 0)
            {
                //edit grade details
                response = await _gradeRepository.EditGrade(GradeDetail);
            }
            else
            {
                //add new grade to Table
                response = await _gradeRepository.AddGrade(new Models.GradeModel
                {
                    GradeStudentID = SelectedStudent.StudentID.ToString(),
                    GradeSubjectID = SelectedSubject.SubjectID.ToString(),
                    GradeLetter = GradeDetail.GradeLetter,
                    Gradenum = GradeDetail.Gradenum,
                });
            }

            //respond if added to table or error occured
            if (response > 0)
            {
                await Shell.Current.DisplayAlert("Grade info saved", "Record Saved", "OK");
            }
            else
            {
                await Shell.Current.DisplayAlert("Not added", "Something went wrong while adding record", "OK");
            }

        }
    }
}













