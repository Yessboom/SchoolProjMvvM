using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Models
{
    //Initialize Table
    [Table("teacher")]
    public class TeacherModel
    {
        //primary key as an ID
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int TeacherID { get; set; }

        [MaxLength(100)]
        public string TeacherFirstName { get; set; }

        [MaxLength(100)]
        public string TeacherLastName { get; set; }

        [MaxLength(10)]
        public int TeacherSalary { get; set; }

        [MaxLength(100)]
        public string TeacherClass { get; set; }

    }


}

