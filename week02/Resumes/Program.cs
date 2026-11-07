using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1.JobTitle = "Software Engineer";
        job1.Company = "Springboard";
        job1.StartYear = 2026;
        job1.EndYear = 2029;

        Job job2 = new Job();
        job2.JobTitle = "Data Entry Specialist";
        job2.Company = "Tech Solutions Inc.";
        job2.StartYear = 2020;
        job2.EndYear = 2023;

        Resume myResume = new Resume();
        myResume.name = "Jaime Cussara Omar";
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);
        myResume.Display();
    }
}