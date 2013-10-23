//Create a [Version] attribute that can be
//applied to structures, classes, interfaces,
//enumerations and methods and holds a version
//in the format major.minor (e.g. 2.11). Apply
//the version attribute to a sample class and
//display its version at runtime.

using System;

class AttributeTry
{
    static void Main()
    {
        Ball testball = new Ball(10, 100);
        Type myType = typeof(Ball);

        object[] myAttributes = myType.GetCustomAttributes(false);

        foreach (VersionAttribute attribute in myAttributes)
        {
            Console.WriteLine("{0} {1}", attribute, attribute.Version);
        }
	
    }
}

