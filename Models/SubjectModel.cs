using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Models
{
    //initialize table
    [Table("subject")]
    public class SubjectModel
    {
        //primary key as an ID
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int SubjectID { get; set; }

        [MaxLength(100)]
        public string SubjectTitle { get; set; }

        [MaxLength(100)]
        public string SubjectCode { get; set; }

        [MaxLength(100)]
        public string SubjectLecturer { get; set; }

        [MaxLength(100)]
        public int SubjectCredits { get; set; }

        [MaxLength(100)]

        public int SubjectStudentCount { get; set; }    



    }
}
