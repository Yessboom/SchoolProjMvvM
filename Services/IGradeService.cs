using SchoolProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Services
{
    public interface IGradeService
    {
        //Initialize CRUD operations
        //Create grade
        Task<int> AddGrade(GradeModel gradeModel);
        //Read grade list
        Task<List<GradeModel>> GetGradeList();
        //Update grade
        Task<int> EditGrade(GradeModel gradeModel);
        //Delete grade
        Task<int> DeleteGrade(GradeModel gradeModel);

    }
}
