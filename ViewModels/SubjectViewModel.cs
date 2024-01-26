using CommunityToolkit.Mvvm.ComponentModel;
using SchoolProject.Models;
using SchoolProject.Services;
using SchoolProject.Views.AddUpdateViews;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.ViewModels
{
    public partial class SubjectViewModel : ObservableObject
    {
        //Observable collection to populate frontend with list of subjects
        public ObservableCollection<SubjectModel> Subjects { get; set; } = new ObservableCollection<SubjectModel>();

        //Initialize Interface for CRUD functions
        private readonly ISubjectService _subjectRepository;
        private readonly IStudentService _studentRepository;
        public SubjectViewModel(ISubjectService subjectService, IStudentService studentRepository)
        {
            _subjectRepository = subjectService;
            _studentRepository = studentRepository;
        }

        //observe entry on frontend for keywords to search
        [ObservableProperty]
        string search;








        //Get list of subjects
        [ICommand]
        public async void GetSubjectList()
        {
            //get list of subjects
            var subjectList = await _subjectRepository.GetSubjectList();
            //get list of students
            var studentList = await _studentRepository.GetStudentList();

            if (subjectList?.Count > 0)
            {

                //clearing total subjects
                Subjects.Clear();
                //looping through subjects 
                foreach (var subject in subjectList)
                {

                    //add subject to list
                    Subjects.Add(subject);
                    //looping through students
                    
                }
            }
        }

        //Search funtionality
        [ICommand]
        public async void GetSubjectListSearch()
        {
            //get list of subjects
            var subjectList = await _subjectRepository.GetSubjectList();
            //filter through list and get new list containing the keyword from the entry
            var filteredItems = subjectList.Where(value => value.SubjectTitle.Contains(Search)).ToList();

            //clear subjects
            Subjects.Clear();
            //loop through list and populate new list with contained subjects
            foreach (var subject in filteredItems)
            {
                Subjects.Add(subject);
            }
        }


        //navigate to add/edit page
        [ICommand]
        public async void AddUpdateSubject()
        {
            await AppShell.Current.GoToAsync(nameof(AddUpdateSubjectPage));
        }

        //get id of item and let user decide if the want to edit or delete
        [ICommand]
        public async void DisplayAction(SubjectModel subjectModel)
        {
            var response = await AppShell.Current.DisplayActionSheet("Select Option", "OK", null, "Edit", "Delete");
            if (response == "Edit")
            {
                //go to edit page and transfer data theough navigation paramaters
                var navParam = new Dictionary<string, object>();
                navParam.Add("SubjectDetail", subjectModel);
                await AppShell.Current.GoToAsync(nameof(AddUpdateSubjectPage), navParam);
            }
            else if (response == "Delete")
            {
                //else delete item
                var delResponse = await _subjectRepository.DeleteSubject(subjectModel);
                if (delResponse > 0)
                {
                    GetSubjectList();
                }
            }
        }
    }
}
