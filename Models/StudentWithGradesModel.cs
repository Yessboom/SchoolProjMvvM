using System.Collections.ObjectModel;
using SchoolProject.Models;

public class StudentWithGradesModel
{
    public StudentModel Student { get; set; }
    public ObservableCollection<GradeModel> Grades { get; set; }
}
