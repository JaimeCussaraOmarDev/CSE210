using System;
public class Job
{
    public string JobTitle = "";
    public string Company = "";
    public int StartYear = 0;
    public int EndYear = 0;

    public void Display()
    {
        Console.WriteLine($"{JobTitle} ({Company}) {StartYear} - {EndYear}");
    }
}