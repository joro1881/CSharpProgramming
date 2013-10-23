//Write a method that from a given array 
//of students finds all students whose 
//first name is before its last name alphabetically. Use LINQ query operators.

using System;

public class Student
{
    private string name;
    private string famillyName;
    private byte age;

    public Student(string name, string famillyName)
        : this(name, famillyName, 0)
    {
    }

    public Student(string name, string famillyName, byte age)
    {
        this.Age = age;
        this.FamillyName = famillyName;
        this.Name = name;
    }

    public byte Age
    {
        get { return this.age; }
        set { this.age = value; }
    }

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public string FamillyName
    {
        get { return this.famillyName; }
        set { this.famillyName = value; }
    }

    public override string ToString()
    {
        return string.Format("{0} {1} {2}", this.Name, this.FamillyName, this.Age);
    }
}


