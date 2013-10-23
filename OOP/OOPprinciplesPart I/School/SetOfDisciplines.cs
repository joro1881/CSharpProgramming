using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public class SetOfDisciplines : ICommentable
    {
        private string name;
        private byte lectures;
        private byte exercises;

        public SetOfDisciplines(string name, byte lectures, byte exercises)
        {
            this.Exercises = exercises;
            this.Lectures = lectures;
            this.Name = name;
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public byte Lectures
        {
            get { return this.lectures; }
            set { this.lectures = value; }
        }

        public byte Exercises
        {
            get { return this.exercises; }
            set { this.exercises = value; }
        }

        public List<string> Comments { get; set; }

        public void AddComment(string comment)
        {
            Comments.Add(comment);
        }
    }
}
