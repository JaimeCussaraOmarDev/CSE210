using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Journal theJournal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        int choice = 0;

        while (choice != 5)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("Select a choice from 1-5: ");
            
            string input = Console.ReadLine();
            if (int.TryParse(input, out choice))
            {
                if (choice == 1)
                {
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine(prompt);
                    Console.Write("> ");
                    string entryText = Console.ReadLine();
                    string date = DateTime.Now.ToShortDateString();

                    Entry newEntry = new Entry();
                    newEntry._date = date;
                    newEntry._promptText = prompt;
                    newEntry._entryText = entryText;

                    theJournal.AddEntry(newEntry);
                }
                else if (choice == 2)
                {
                    theJournal.DisplayAll();
                }
                else if (choice == 3)
                {
                    Console.Write("Enter filename to load: ");
                    string filename = Console.ReadLine();
                    theJournal.LoadFromFile(filename);
                }
                else if (choice == 4)
                {
                    Console.Write("Enter filename to save: ");
                    string filename = Console.ReadLine();
                    theJournal.SaveToFile(filename);
                }
            }
        }
    }
}

class PromptGenerator
{
    private readonly List<string> _prompts;
    private readonly Random _random;

    public PromptGenerator()
    {
        _prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the strongest emotion I felt today?",
            "What was one thing I learned today that I want to remember?",
            "What challenge did I face today and how did I respond?",
            "What is something I am grateful for today?"
        };
        _random = new Random();
    }

    public string GetRandomPrompt()
    {
        return _prompts[_random.Next(_prompts.Count)];
    }
}

class Entry
{
    public string _date;
    public string _promptText;
    public string _entryText;

    public void Display()
    {
        Console.WriteLine($"Date: {_date} - Prompt: {_promptText}");
        Console.WriteLine(_entryText);
    }
}

class Journal
{
    private readonly List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        List<string> lines = new List<string>();
        foreach (Entry entry in _entries)
        {
            lines.Add($"{entry._date}|{entry._promptText}|{entry._entryText}");
        }
        File.WriteAllLines(filename, lines);
    }

    public void LoadFromFile(string filename)
    {
        _entries.Clear();
        foreach (string line in File.ReadAllLines(filename))
        {
            string[] parts = line.Split(new[] { '|' }, 3);
            if (parts.Length == 3)
            {
                _entries.Add(new Entry
                {
                    _date = parts[0],
                    _promptText = parts[1],
                    _entryText = parts[2]
                });
            }
        }
    }
}