using CAP2025.Day4;
using System;
/// <summary>
/// this program is to demonstrate how inhertience works, created a base class Person and inherited the properties to child/derived classes 
/// </summary>

public class Person
{
    private int Marks;
    private int Birthday;
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }

    public virtual string GetDetails()
    {
        return $"Id = {Id}, Name = {Name}, Age = {Age}";
    }
}

public class Man : Person
{
    public string Playing { get; set; }

    public override string GetDetails()
    {
        return $"Id = {Id}, Name = {Name}, Age = {Age}, Playing = {Playing}";
    }
}

public class Woman : Person
{
    public string PlayManage { get; set; }

    public override string GetDetails()
    {
        return $"Id = {Id}, Name = {Name}, Age = {Age}, Activity = {PlayManage}";
    }
}

public class Child : Person
{
    public string WatchingCartoon { get; set; }

    public override string GetDetails()
    {
        return $"Id = {Id}, Name = {Name}, Age = {Age}, Cartoon = {WatchingCartoon}";
    }
}

/// <summary>
/// this is main class in which we have created objects for the classes and accesssing the classes through the objects
/// </summary>
public class Inheritence
{
    public static void Main(string[] args)
    {
        Person person = new Person { Id = 1, Name = "Arul", Age = 20 };
        Person man = new Man { Id = 10, Name = "Kumar", Age = 24, Playing = "Football" };
        Person woman = new Woman { Id = 11, Name = "Kumari", Age = 23, PlayManage = "Rugby & Home" };
        Person child = new Child { Id = 100, Name = "Anki", Age = 5, WatchingCartoon = "Chota Bheem" };

        Console.WriteLine(person.GetDetails());
        Console.WriteLine(man.GetDetails());
        Console.WriteLine(woman.GetDetails());
        Console.WriteLine(child.GetDetails());
    }
}