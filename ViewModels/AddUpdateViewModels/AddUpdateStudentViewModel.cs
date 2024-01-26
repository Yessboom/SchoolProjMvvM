using CommunityToolkit.Mvvm.ComponentModel;
using SchoolProject.Models;
using SchoolProject.Services;
using Microsoft.Toolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace SchoolProject.ViewModels.AddUpdateViewModels
{
    //url queries to pass between pages
    [QueryProperty(nameof(StudentDetail), "StudentDetail")]

    public partial class AddUpdateStudentViewModel : ObservableObject
    {
        //Observable collection to populate picker with list of Majors
        public ObservableCollection<SubjectModel> Major { get; set; } = new ObservableCollection<SubjectModel>();
        //Observable collection to populate picker with list of Theories
        public ObservableCollection<SubjectModel> Theory { get; set; } = new ObservableCollection<SubjectModel>();
        //Degree has 6 modules extra
        //Observable collection to populate picker with list of Modules
        public ObservableCollection<SubjectModel> DegreeModule { get; set; } = new ObservableCollection<SubjectModel>();

        //call db data from StudentModel Table
        [ObservableProperty]
        public StudentModel _studentDetail = new StudentModel();

        //Initialize Interface for CRUD functions
        private readonly IStudentService _studentRepository;
        public AddUpdateStudentViewModel(IStudentService studentService)
        {
            _studentRepository = studentService;

            //New instance of List for subjects
            listOfSubjects = new List<SubjectModel>();
            //call function to load GetSubjectList()
            GetListOfSubjects();

        }

        //initiate new list for Subjects
        [ObservableProperty]
        List<SubjectModel> listOfSubjects;
        //listen and populate subjects chosen from picker as selectedSubject
        [ObservableProperty]
        SubjectModel selectedSubject;
        //listen and populate major chosen from picker as selectedSubject



        //function to load GetSubjectList()
        public async void GetListOfSubjects()
        {
            // T<List> -> <List> 
            //get list of subjects from repository
            ListOfSubjects = await App.SubjectRepo.GetSubjectList();

            //loop through list of subjects
            foreach (var listOfSubjects in ListOfSubjects.ToList())
            {
                //populate observable collection with only major
                    Major.Add(listOfSubjects);
 
            }

        }
        //Add and Edit function
        [ICommand]
        public async void AddUpdateStudent()
        {
            int response = -1;
            if (StudentDetail.StudentID > 0)
            {
                //edit student details
                response = await _studentRepository.EditStudent(StudentDetail);
            }
            else
            {
                //add new student to table
                response = await _studentRepository.AddStudent(new Models.StudentModel
                {
                    StudentFirstName = StudentDetail.StudentFirstName,
                    StudentLastName = StudentDetail.StudentLastName,
                });
            }
            //respond if added to table or error occured
            if (response > 0)
            {
                await Shell.Current.DisplayAlert("Student information saved.", "Record Saved", "OK");
            }
            else
            {
                await Shell.Current.DisplayAlert("Information not added.", "Something went wrong while adding record.", "OK");
            }
        }
    }
}
