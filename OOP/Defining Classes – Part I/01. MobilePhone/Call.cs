using System;

//Create a class Call to hold a call performed 
//through a GSM. It should contain date, time, 
//dialed phone number and duration (in seconds).



namespace _01.MobilePhone
{
    public class Call
    {
        private DateTime time;
        private int duration;
        private string phone;

        //constructor

        public Call (DateTime time, int dur, string phone)
        {
            this.Time = time;
            this.Duration = dur;
            this.PhoneNumber = phone;
        }
        //properties
        public DateTime Time
        {
            get { return this.time; }
            set { this.time = value; }
        }

        public int Duration
        {
            get { return this.duration; }
            set { this.duration = value; }
        }

        public string PhoneNumber
        {
            get { return this.phone; }
            set { this.phone = value; }
        }


    }
}
