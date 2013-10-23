//Read in MSDN about the keyword event in C# 
//and how to publish events. Re-implement the
//above using .NET events and following the best practices.

using System;
using System.Timers;

namespace EventTimer
{
    public class EvTimer
    {
        public delegate void ExecuteMethod();

        public ExecuteMethod methodX;
        private Timer timer1;

        public EvTimer()
        {
            timer1 = new Timer(5000);
        }

        public void Start(int mSec)
        {
            timer1.Elapsed += new ElapsedEventHandler(Execute);
            timer1.Interval = mSec;
            timer1.Enabled = true;
        }

        public void Execute(object sourse, ElapsedEventArgs e)
        {
            methodX();
        }
    }
}
