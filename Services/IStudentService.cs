using SchoolProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Services
{
    public interface IStudentService
    {
        //Initialize CRUD operations
        //Create student
        Task<int> AddStudent(StudentModel studentModel);
        //Read student list
        Task<List<StudentModel>> GetStudentList();
        //Update Student
        Task<int> EditStudent(StudentModel studentModel);
        //Delete student
        Task<int> DeleteStudent(StudentModel studentModel);

        Task<List<GradeModel>> GetGradesForStudent(int studentId);

    }
}
