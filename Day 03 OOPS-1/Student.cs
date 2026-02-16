using System;
/// <summary>
/// this program is to demonstrate how a class "student" can be created and can be accessed
/// </summary>
public class Student
{
    public string Name;
    public int Id;
    public string Course;
    public int Marks;
    
    public void DisplayDetails()
    {
        Console.WriteLine("StudentID: "+Id);
        Console.WriteLine("Name: "+Name);
        Console.WriteLine("Course: "+Course);
        Console.WriteLine("Total Marks: "+Marks);
    }
    public void IsPassed()
    {
        if(Marks>=150)
        {
            Console.WriteLine("Student Passed.");
        }
        else
        {
            Console.WriteLine("Student Failed");
        }    
    }

}

/// <summary>
/// this is main class in which we have created objects for the above student class and initialized the values and calling the function on the above class
/// </summary>
public class main
{
    public static void Main()
    {
        Student student =new Student();
        student.Id=12204083;
        student.Name="Bejjipuram Indra Kumar";
        student.Course="CSE";
        student.Marks=200;
        student.DisplayDetails();
        student.IsPassed();

    }
}


