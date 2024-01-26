using SchoolProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Services
{
    public interface ITeacherService
    {
        //Initialize CRUD operations
        //Create teacher
        Task<int> AddTeacher(TeacherModel teacherModel);
        //Read teacher list
        Task<List<TeacherModel>> GetTeacherList();
        //Update teacher
        Task<int> EditTeacher(TeacherModel teacherModel);
        //Delete teacher
        Task<int> DeleteTeacher(TeacherModel teacherModel);
        //Get user login authentication

    }
}
