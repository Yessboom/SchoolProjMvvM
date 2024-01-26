
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SchoolProject.Models;
using SchoolProject.Services;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SchoolProject.ViewModels.AddUpdateViewModels
{
    //url queries to pass between pages
    [QueryProperty(nameof(SubjectDetail), "SubjectDetail")]

    public partial class AddUpdateSubjectViewModel : ObservableObject
    {
        //Observable collection to populate picker with list of lecturers
        public ObservableCollection<TeacherModel> Lec { get; set; } = new ObservableCollection<TeacherModel>();

        //call db data from SubjectModel Table
        [ObservableProperty]
        public SubjectModel _subjectDetail = new SubjectModel();

        //Initialize Interface for CRUD functions
        private readonly ISubjectService _subjectRepository;
        public AddUpdateSubjectViewModel(ISubjectService subjectService)
        {
            _subjectRepository = subjectService;

            //New instance of List for lecturers
            listOfLecturers = new List<TeacherModel>();
            //call function to load GetTeacherList()
            GetListOfLecturers();

        }

        //initiate new list for lecturers
        [ObservableProperty]
        List<TeacherModel> listOfLecturers;

        //listen and populate lecturer chosen from picker as selectedLecturer
        [ObservableProperty]
        TeacherModel selectedLecturer;

        //function to load GetTeacherList()
        public async void GetListOfLecturers()
        {
            // T<List> -> <List> 
            //get list of lecturers from repository
            ListOfLecturers = await App.TeacherRepo.GetTeacherList();

            //loop through list of teacher
            foreach (var listOfLecturer in listOfLecturers.ToList())
            {
  
                Lec.Add(listOfLecturer);
                
            }
        }

        //Add and Edit function
        [ICommand]
        public async void AddUpdateSubject()
        {
            int response = -1;

            if (SubjectDetail.SubjectID > 0)
            {
                //edit subject details
                response = await _subjectRepository.EditSubject(SubjectDetail);
            }
            else
            {
                //add new subject to table
                response = await _subjectRepository.AddSubject(new Models.SubjectModel
                {
                    SubjectTitle = SubjectDetail.SubjectTitle,
                    SubjectCode = SubjectDetail.SubjectCode,
                    SubjectLecturer = SelectedLecturer.TeacherFirstName,
                    SubjectCredits = SubjectDetail.SubjectCredits,

                });
            }
            //respond if added to table or error occured
            if (response > 0)
            {
                await Shell.Current.DisplayAlert("Subject info saved", "Record Saved", "OK");
            }
            else
            {
                await Shell.Current.DisplayAlert("Not added", "Something went wrong while adding record", "OK");
            }
        }
    }
}

