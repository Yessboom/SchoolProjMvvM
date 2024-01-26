using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SchoolProject.Models
{
    //initialize table
    [Table("student")]
    public class StudentModel
    {
        //primary key as an ID
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int StudentID { get; set; }

        [MaxLength(100)]
        public string StudentFirstName { get; set; }

        [MaxLength(100)]
        public string StudentLastName { get; set; }

        [MaxLength(100)]
        public string StudentSubjects { get; set; }


        [MaxLength(100)]
        public int StudentCredits { get; set; }

    }
}
