using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public class SetOfTeachers : Person, ICommentable
    {
        //setofdisciplines
        public List<SetOfDisciplines> Disciplines { get; set; }

        public SetOfTeachers(string name)
        {
            this.Disciplines = new List<SetOfDisciplines>();
            this.Name = name;
        }

        public string Name { get; set; }

        public List<string> Comments { get; set; }

        public void AddComment(string comment)
        {
            Comments.Add(comment);
        }
    }
}
