﻿using CommunityToolkit.Mvvm.ComponentModel;
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
    public partial class StudentViewModel : ObservableObject
    {
        //Observable collection to populate frontend with list of students
        public ObservableCollection<StudentModel> Students { get; set; } = new ObservableCollection<StudentModel>();
        private ObservableCollection<StudentWithGradesModel> _studentsWithGrades;
        
        public ObservableCollection<StudentWithGradesModel> StudentsWithGrades
        {
            get { return _studentsWithGrades; }
            set { SetProperty(ref _studentsWithGrades, value); }
        }
        //Initialize Interface for CRUD functions
        private readonly IStudentService _studentRepository;
        public StudentViewModel(IStudentService studentService)
        {
            _studentRepository = studentService;

        }




        //observe entry on frontend for keywords to search
        [ObservableProperty]
        string search;


        //Get list of students
        [ICommand]
        public async void GetStudentList()
        {
            //get list of students
            var studentList = await _studentRepository.GetStudentList();
            if (studentList?.Count > 0)
            {
                //clear students
                Students.Clear();
                //loop through list
                foreach (var student in studentList)
                {
                    Students.Add(student);

                }
            }
        }

        public async void GetStudentSubjetsGrades()
        {
            var studentList = await _studentRepository.GetStudentList();
            StudentsWithGrades = new ObservableCollection<StudentWithGradesModel>();

            foreach (var student in studentList)
            {
                var gradesForStudent = await _studentRepository.GetGradesForStudent(student.StudentID);
                var studentWithGrades = new StudentWithGradesModel
                {
                    Student = student,
                    Grades = new ObservableCollection<GradeModel>(gradesForStudent)
                };

                StudentsWithGrades.Add(studentWithGrades);
            }
        }


        //Search funtionality
        [ICommand]
        public async void GetStudentListSearch()
        {
            //get list of students
            var studentList = await _studentRepository.GetStudentList();
            //filter through list and get new list containing the keyword from the entry
            var filteredItems = studentList.Where(value => value.StudentFirstName.Contains(Search)).ToList();
            //filter through list and get new list containing the keyword from the entry
            var filteredItems2 = studentList.Where(value => value.StudentLastName.ToString().Contains(Search)).ToList();
            //clear students
            Students.Clear();
            //loop through list and populate new list with contained students name
            foreach (var student in filteredItems)
            {
                Students.Add(student);
            }
            //loop through list and populate new list with contained students id
            foreach (var student in filteredItems2)
            {
                Students.Add(student);
            }
        }

        //navigate to add/edit page
        [ICommand]
        public async void AddUpdateStudent()
        {
            await AppShell.Current.GoToAsync(nameof(AddUpdateStudentPage));
        }

        //get id of item and let user decide if the want to edit or delete
        [ICommand]
        public async void DisplayAction(StudentModel studentModel)
        {
            var response = await AppShell.Current.DisplayActionSheet("Select an action", "OK", null, "Edit", "Give a Grade", "Delete");
            if (response == "Edit")
            {
                //go to edit page and transfer data theough navigation paramaters
                var navParam = new Dictionary<string, object>();
                navParam.Add("StudentDetail", studentModel);
                await AppShell.Current.GoToAsync(nameof(AddUpdateStudentPage), navParam);
            }
            else if (response == "Give a Grade")
            {
                //go to edit page and transfer data theough navigation paramaters
                var navParam = new Dictionary<string, object>();
                navParam.Add("StudentDetail", studentModel);
                await AppShell.Current.GoToAsync(nameof(AddUpdateGradePage), navParam);
            }
        
            else if (response == "Delete")
            {
                //else delete item
                var delResponse = await _studentRepository.DeleteStudent(studentModel);
                if (delResponse > 0)
                {
                    GetStudentList();
                }
            }
        }

    }
}
