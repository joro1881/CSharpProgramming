using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public class SetOfStudents : Person, ICommentable
    {
        private string name;
        private ushort uniClasNumber;

        public SetOfStudents(string name, ushort uniClasNumber)
        {
            this.Name = name;
            this.Unicode = uniClasNumber;
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public ushort Unicode
        {
            get { return this.uniClasNumber; }
            set { this.uniClasNumber = value; }
        }

        public List<string> Comments { get; set; }
        public void AddComment(string comment)
        {
            Comments.Add(comment);
        }
    }
}
