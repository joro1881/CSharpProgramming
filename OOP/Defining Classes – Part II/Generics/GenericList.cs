//Write a generic class GenericList<T> that keeps
//a list of elements of some parametric type T.
//Keep the elements of the list in an array with 
//fixed capacity which is given as parameter in 
//the class constructor. Implement methods for adding 
//element, accessing element by index, removing element 
//by index, inserting element at given position, clearing
//the list, finding element by its value and ToString().
//Check all input parameters to avoid accessing elements at invalid positions.


using System;
using System.Collections.Generic;
using System.Text;

public class GenericList<T> where T : IComparable<T>
{
    //field
    private const int defaultSize = 10;
    private T[] list;
    private int listIndex = 0;

    //constructors
    public GenericList()
        : this(defaultSize)
    {

    }

    public GenericList(int capacity)
    {
        this.list = new T[capacity];
    }

    //property

    public T this[int index]
    {
        get
        {
            return this.list[index];
        }
        set
        {
            this.list[index] = value;
        }
    }

    //methods

    public void AddElement(T arrElement)
    {
        if(this.listIndex >= this.list.Length)
        {
            T[] newList = new T[this.list.Length * 2];
            for (int i = 0; i < this.list.Length; i++)
            {
                newList[i] = this.list[i];
            }
            this.listIndex++;
            newList[this.list.Length] = arrElement;
            this.list = newList;
        }
        else
        {
            this.list[listIndex] = arrElement;
            listIndex++;
        }
    }

    public T AccessElement(int position)
    {
        T element = this.list[position];
        return element;
    }

    public void RemoveAtIndex(int position)
    {
        if (position >= 0 && position < list.Length)
        {
            T[] newList = new T[this.list.Length - 1];

            if (position == 0)// if is the first element
            {
                int jug = 0;
                for (int i = 1; i < this.list.Length; i++)
                {
                    newList[jug] = this.list[i];
                    jug++; 
                }
            }
            else if(position == (list.Length-1))// if is the last element
            {
                for (int i = 0; i < this.list.Length - 1; i++)
                {
                    newList[i] = this.list[i];
                }
            }
            else if (position > 0 && position < (list.Length - 1))//element between first and last
            {
                int jug = 0;
                for (int i = 0; i < this.list.Length; i++)
                {
                    if (position == i)
                    {
                        i++;
                    }
                    newList[jug] = this.list[i];
                    jug++;
                }
            }

            this.list = newList;
        }
        else
        {
            Console.WriteLine("Wrong index!\n Not in the boundaries!");
        }
    }

    public void InsertElement(int position, T element)
    {
        if (position >= 0 && position < list.Length)
        {
            T[] newList = new T[this.list.Length + 1];
            int jug = 0;
            for (int i = 0; i < this.list.Length+1; i++)
            {
                if (position == i)
                {
                    //inserting the element to the new array
                    newList[i] = element;
                    i++;
                    
                }
                if (list.Length == jug)
                {
                    //savety check for the old array, if we get out of boundaries
                    jug--;
                }
                newList[i] = this.list[jug];
                jug++;
            }

            this.list = newList;
        }
        else
        {
            Console.WriteLine("Wrong index!\n Not in the boundaries!");
        }
    }

    public void ClearingList()
    {
        this.list = new T[10];
        this.listIndex = 0;
    }

    public int FindElementByValue(int value)
    {
        int elementIndex = -1;
        for (int i = 0; i < this.list.Length; i++)
        {
            if(this.list[i].Equals(value))
            {
                elementIndex = i;
                break;
            }
        }
        return elementIndex;
    }

    public override string ToString()
    {
        StringBuilder str = new StringBuilder();
        foreach (var item in this.list)
        {
            str.AppendFormat("{0}", item);
            str.AppendLine();
        }
        return str.ToString();
    }

//Create generic methods Min<T>() and Max<T>() for 
//finding the minimal and maximal element in the  
//GenericList<T>. You may need to add a generic 
//constraints for the type T.

    public T Max<T>() where T : IComparable<T>
    {
        dynamic biggest = int.MinValue;
        for (int i = 0; i < this.list.Length; i++)
        {
            if (this.list[i] > biggest)
            {
                biggest = this.list[i];
            }
        }

        return biggest;
    }

    public T Min<T>() where T : IComparable<T>
    {
        dynamic smallest = int.MaxValue;
        for (int i = 0; i < this.list.Length; i++)
        {
            if (this.list[i] < smallest)
            {
                smallest = this.list[i];
            }
        }

        return smallest;
    }
}

