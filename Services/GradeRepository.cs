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
    internal class GradeRepository : IGradeService
    {
        private SQLiteAsyncConnection _dbConnection;

        //Setup Connection to DB.
        private async Task SetUpDb()
        {
            if (_dbConnection == null)
            {



                //connect db
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Grade.db3");
                var options = new SQLiteConnectionString(dbPath, true, "password", postKeyAction: c =>
                {
                    c.Execute("PRAGMA cipher_compatability = 3");
                });
                _dbConnection = new SQLiteAsyncConnection(options);
                await _dbConnection.CreateTableAsync<GradeModel>();
            }
        }



        //Create a new grade user
        public async Task<int> AddGrade(GradeModel gradeModel)
        {
            await SetUpDb();
            return await _dbConnection.InsertAsync(gradeModel);
        }
        //Get list of grade
        public async Task<List<GradeModel>> GetGradeList()
        {
            await SetUpDb();
            var gradeList = await _dbConnection.Table<GradeModel>().ToListAsync();
            return gradeList;
        }
        //Edit grade details
        public async Task<int> EditGrade(GradeModel gradeModel)
        {
            await SetUpDb();
            return await _dbConnection.UpdateAsync(gradeModel);
        }
        //Delete a grade
        public async Task<int> DeleteGrade(GradeModel gradeModel)
        {
            await SetUpDb();
            return await _dbConnection.DeleteAsync(gradeModel);
        }


    }
}

