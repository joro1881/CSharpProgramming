using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public class SetOfClasses : ICommentable
    {
        //setofteachers
        List<SetOfTeachers> teachers;
        List<SetOfStudents> students;
        public string Identifier { get; set; }

        public SetOfClasses(string iden)
        {
            this.Identifier = iden;
            this.teachers = new List<SetOfTeachers>();
            this.students = new List<SetOfStudents>();
        }

        public List<string> Comments { get; set; }

        public void AddComment(string comment)
        {
            Comments.Add(comment);
        }
    }
}
