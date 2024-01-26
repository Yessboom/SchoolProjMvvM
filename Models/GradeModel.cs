using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SchoolProject.Models
{
    //initialize table
    [Table("grade")]
    public class GradeModel
    {
        //primary key as an ID
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int GradeID { get; set; }

        [MaxLength(100)]
        public string GradeSubjectID { get; set; }

        [MaxLength(100)]
        public string GradeStudentID { get; set; }

        [MaxLength(100)]
        public int Gradenum { get; set; }


        [MaxLength(100)]
        public int GradeLetter { get; set; }

    }
}
