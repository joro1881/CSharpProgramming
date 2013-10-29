using System; 

namespace GoliathNationalBank
{
    public class Companies : Customers
    {
        //auto-hide field

        //properties
        private string Name { get; set; }
        private int RegNumber { get; set; }

        //constructor
        public Companies(string name, int reg)
        {
            this.Name = name;
            this.RegNumber = reg;
        }
    }
}
