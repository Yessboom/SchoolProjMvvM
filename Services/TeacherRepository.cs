using SchoolProject.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Services
{
    internal class TeacherRepository : ITeacherService
    {
        private SQLiteAsyncConnection _dbConnection;

        //Setup Connection to DB.
        private async Task SetUpDb()
        {
            if (_dbConnection == null)
            {



                //connect db
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Teacher.db3");
                var options = new SQLiteConnectionString(dbPath, true, "password", postKeyAction: c =>
                {
                    c.Execute("PRAGMA cipher_compatability = 3");
                });
                _dbConnection = new SQLiteAsyncConnection(options);
                await _dbConnection.CreateTableAsync<TeacherModel>();
            }
        }



        //Create a new teacher user
        public async Task<int> AddTeacher(TeacherModel teacherModel)
        {
            await SetUpDb();
            return await _dbConnection.InsertAsync(teacherModel);
        }
        //Get list of teacher
        public async Task<List<TeacherModel>> GetTeacherList()
        {
            await SetUpDb();
            var teacherList = await _dbConnection.Table<TeacherModel>().ToListAsync();
            return teacherList;
        }
        //Edit teacher details
        public async Task<int> EditTeacher(TeacherModel teacherModel)
        {
            await SetUpDb();
            return await _dbConnection.UpdateAsync(teacherModel);
        }
        //Delete a teacher
        public async Task<int> DeleteTeacher(TeacherModel teacherModel)
        {
            await SetUpDb();
            return await _dbConnection.DeleteAsync(teacherModel);
        }

       
    }
}

