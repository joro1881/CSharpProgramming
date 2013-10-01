using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public class Display
    {
        //display characteristics (size and number of colors).
        private string size = null;
        private int colors = 0;

        //constructors

        public Display()
        {
        }

        public Display(string size, int colors)
        {
            this.Size = size;
            this.Colors = colors;
        }

        //properties
        public string Size
        {
            get { return this.size; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Invalid size!");
                this.size = value;
            }
        }

        public int Colors
        {
            get { return this.colors; }
            set
            {
                this.colors = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Size: {0}\nColors: {1}", this.size, this.colors);
        }
    }

