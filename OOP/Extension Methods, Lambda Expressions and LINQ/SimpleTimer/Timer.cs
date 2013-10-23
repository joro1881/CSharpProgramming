using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleTimer
{
    public class Timer
    {
        public delegate void ExecuteMethod();

        private ExecuteMethod methodsX;
        private int interval;
        private int time;


        public Timer() : this(0, 20) { } 
        public Timer(int interval, int time)
        {
            this.Time = time;
            this.Interval = interval;
        }

        public int Time
        {
            get { return this.time; }
            set { this.time = value; } 
        }

        public int Interval
        {
            get { return this.interval; }
            set { this.interval = value; }
        }

        public ExecuteMethod MethodsX
        {
            get { return this.methodsX; }
            set { this.methodsX = value; }
        }

        public void Execute()
        {
            DateTime start = DateTime.Now;
            DateTime end = start.AddMilliseconds(Time);
            while (start <= end)
            {
                MethodsX();
                Thread.Sleep(Interval);
                start = DateTime.Now;
            }
        }
    }
}
