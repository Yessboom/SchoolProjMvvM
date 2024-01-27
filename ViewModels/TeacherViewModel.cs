using CommunityToolkit.Mvvm.ComponentModel;
using SchoolProject.Models;
using SchoolProject.Services;
using SchoolProject.Views.AddUpdateViews;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.ViewModels
{
    public partial class TeacherViewModel : ObservableObject
    {
        //Observable collection to populate frontend with list of teacher
        public ObservableCollection<TeacherModel> Teacher { get; set; } = new ObservableCollection<TeacherModel>();

        //Initialize Interface for CRUD functions
        private readonly ITeacherService _teacherRepository;
        public TeacherViewModel(ITeacherService teacherService)
        {
            _teacherRepository = teacherService;
        }

        //count total lecturers
        [ObservableProperty]
        int totalLecturers;

        //observe entry on frontend for keywords to search
        [ObservableProperty]
        string search;

        //Get list of teacher
        [ICommand]
        public async void GetTeacherList()
        {
            //get list of teacher
            var teacherList = await _teacherRepository.GetTeacherList();
            if (teacherList?.Count > 0)
            {
                //clear teacher
                Teacher.Clear();
                foreach (var teacher in teacherList)
                {
                    //populate list of teacher
                    Teacher.Add(teacher);




                }
            }
        }

        //Search funtionality
        [ICommand]
        public async void GetTeacherListSearch()
        {
            //get list of subjects
            var teacherList = await _teacherRepository.GetTeacherList();
            //filter through list and get new list containing the keyword from the entry
            var filteredItems = teacherList.Where(value => value.TeacherFirstName.Contains(Search)).ToList();
            //filter through list and get new list containing the keyword from the entry
            var filteredItems2 = teacherList.Where(value => value.TeacherLastName.ToString().Contains(Search)).ToList();
            //clear teacher
            Teacher.Clear();
            //loop through list and populate new list with contained teacher name
            foreach (var teacher in filteredItems)
            {
                Teacher.Add(teacher);
            }
            //loop through list and populate new list with contained teacher id
            foreach (var teacher in filteredItems2)
            {
                Teacher.Add(teacher);
            }
        }

        //navigate to add/edit page
        [ICommand]
        public async void AddUpdateTeacher()
        {
            await AppShell.Current.GoToAsync(nameof(AddUpdateTeacherPage));
        }

        //get id of item and let user decide if the want to edit or delete
        [ICommand]
        public async void DisplayAction(TeacherModel teacherModel)
        {
            var response = await AppShell.Current.DisplayActionSheet("Select Option", "OK", null, "Edit", "Delete");
            if (response == "Edit")
            {
                //go to edit page and transfer data theough navigation paramaters
                var navParam = new Dictionary<string, object>();
                navParam.Add("TeacherDetail", teacherModel);
                await AppShell.Current.GoToAsync(nameof(AddUpdateTeacherPage), navParam);

            }
            else if (response == "Delete")
            {
                //else delete item
                var delResponse = await _teacherRepository.DeleteTeacher(teacherModel);
                if (delResponse > 0)
                {
                    GetTeacherList();
                }
            }
        }
    }
}

