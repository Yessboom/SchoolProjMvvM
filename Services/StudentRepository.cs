﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolProject.Models;

namespace SchoolProject.Services
{
    internal class StudentRepository : IStudentService
    {
        private SQLiteAsyncConnection _dbConnection;

        //Setup Connection to DB.
        private async Task SetUpDb()
        {
            if (_dbConnection == null)
            {
                //connect db
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Student.db3");
                var options = new SQLiteConnectionString(dbPath, true, "password", postKeyAction: c =>
                {
                    c.Execute("PRAGMA cipher_compatability = 3");
                });
                _dbConnection = new SQLiteAsyncConnection(options);
                await _dbConnection.CreateTableAsync<StudentModel>();

            }
        }
        //Create a new student
        public async Task<int> AddStudent(StudentModel studentModel)
        {
            await SetUpDb();
            return await _dbConnection.InsertAsync(studentModel);
        }
        //Get list of students
        public async Task<List<StudentModel>> GetStudentList()
        {
            await SetUpDb();
            var studentList = await _dbConnection.Table<StudentModel>().ToListAsync();
            return studentList;
        }
        //Edit student details
        public async Task<int> EditStudent(StudentModel studentModel)
        {
            await SetUpDb();
            return await _dbConnection.UpdateAsync(studentModel);
        }
        //Delete a student
        public async Task<int> DeleteStudent(StudentModel studentModel)
        {
            await SetUpDb();
            return await _dbConnection.DeleteAsync(studentModel);
        }

        public async Task<List<GradeModel>> GetGradesForStudent(int studentId)
        {
        await SetUpDb();
        
        // Fetch grades for the specified student from the database
        var gradesForStudent = await _dbConnection.Table<GradeModel>().Where(grade => grade.GradeStudentID == studentId.ToString()).ToListAsync();

        return gradesForStudent;
        }
    }
}
