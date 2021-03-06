﻿using System; 

namespace DefiningExceptionClass
{
    //Define a class InvalidRangeException<T> that
    //holds information about an error condition 
    //related to invalid range. It should hold error
    //message and a range definition [start … end].
    //Write a sample application that demonstrates
    //the InvalidRangeException<int> and 
    //InvalidRangeException<DateTime> by entering 
    //numbers in the range [1..100] and dates in the 
    //range [1.1.1980 … 31.12.2013].

    public class InvalidRangeException<T> : Exception
    {
        //field 

        //properties
        public T Start { get; set; }
        public T End { get; set; }

        //constructor
        public InvalidRangeException(string msg, T start, T end)
            :base(msg)
        {
            this.Start = start;
            this.End = end;
        }
    }
}
