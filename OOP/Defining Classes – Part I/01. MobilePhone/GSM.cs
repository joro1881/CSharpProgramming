using System;
using System.Collections.Generic;

namespace _01.MobilePhone
{

    //model, manufacturer, price, owner
    public class GSM
    {
        public Battery Battery = new Battery();
        public Display Display = new Display();

        private string model;
        private string manufacturer;
        private int price = 0;
        private string owner = null;

        static private GSM iPhone4S = new GSM("Iphone", "Apple", 850);

        //constructors

        public GSM(string model, string manufacturer) : this(model, manufacturer, 0, null, null, null)
        {
        }

        public GSM(string model, string manufacturer, int price) : this(model, manufacturer, price, null, null, null)
        {
        }

        public GSM(string model, string manufacturer, int price, string owner) : this(model, manufacturer, price, owner, null, null)
        {
        }

        public GSM(string model, string manufacturer, int price, string owner, Battery battery, Display display)
        {
            this.Price = price;
            this.Owner = owner;
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Battery = battery;
            this.Display = display;
        }

        //properties
        
        private List<Call> historyBook = new List<Call>();

        static public GSM IPhone4S
        {
            get { return iPhone4S;}
        }

        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }

        public string Manufacturer
        {
            get { return this.manufacturer; }
            set { this.manufacturer = value; }
        }

        public int Price
        {
            
            get { return this.price; }
            set { this.price = value; }
        }

        public string Owner
        {
            get { return this.owner; }
            set
            {
            //    if (String.IsNullOrEmpty(value))
            //    {
            //        throw new ArgumentException("Invalid owner!");
            //    }
                //else
                //{
                    this.owner = value;
                //}
            }
        }

        //methods

        //Add methods in the GSM class for 
        //adding and deleting calls from 
        //    the calls history. 
        //Add a method to clear the call history.

        public void AddCall(DateTime time, string phoneNumber, int durr)
        {
            Call calling = new Call(time, durr, phoneNumber);
            historyBook.Add(calling);
        }

        public void DeletingCall(string phoneNumber, int duration)
        {
            for (int i = 0; i < historyBook.Count; i++)
            {
                if (historyBook[i].PhoneNumber == phoneNumber && historyBook[i].Duration == duration)
                {
                    historyBook.RemoveAt(i);
                    i--;
                }
            }
        }

        public void ClearHistory() { historyBook.Clear(); }

        //Add a method that calculates the 
        //total price of the calls in the 
        //call history. Assume the price 
        //per minute is fixed and is provided as a parameter.

        public double CalculateCalls(double priceFixed)
        {
            double allTime = 0;
            for (int i = 0; i < historyBook.Count; i++)
            {
                allTime = allTime + historyBook[i].Duration;
            }

            double price = priceFixed * (Math.Ceiling(allTime / 60));
            return price;
        }

        public override string ToString()
        {
            return string.Format("Telephone information:\n\n"+
                                "Model: {0}\n" +
                                "Manufacturer: {1}\n" +
                                "Price: {2}\n" +
                                "Owner: {3}\n"+
                                "\nBattery:\n{4}\n"+
                                "Display:\n{5}\n"+
                                "=========================\n" , this.model, this.manufacturer, this.price, this.owner, this.Battery, this.Display);
        }

        public void Print()
        {
            int sequence = 0;
            foreach (var call in historyBook)
            {
                sequence++;
                Console.WriteLine("Conversation {0}",sequence);
                Console.WriteLine("Number: {0}\nDuration: {1}\nDate: {2}\n", call.PhoneNumber, call.Duration, call.Time);
            }

            if (historyBook.Count == 0)
            {
                Console.WriteLine("Empty phone book", Console.ForegroundColor = ConsoleColor.Red);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
    }
}
