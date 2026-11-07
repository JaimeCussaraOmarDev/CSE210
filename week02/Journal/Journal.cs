using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("Your journal is currently empty.");
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string file)
    {
        using (StreamWriter outputFile = new StreamWriter(file))
        {
            outputFile.WriteLine("Date,Prompt,Mood,Text");

            foreach (Entry entry in _entries)
            {
                string escapedPrompt = EscapeCsvField(entry._promptText);
                string escapedMood = EscapeCsvField(entry._mood);
                string escapedText = EscapeCsvField(entry._entryText);

                outputFile.WriteLine($"{entry._date},{escapedPrompt},{escapedMood},{escapedText}");
            }
        }
        Console.WriteLine("Journal successfully saved as a clean CSV file!");
    }

    public void LoadFromFile(string file)
    {
        _entries.Clear();
        string[] lines = File.ReadAllLines(file);
        bool isFirstLine = true;

        foreach (string line in lines)
        {
            if (isFirstLine)
            {
                isFirstLine = false;
                if (line.StartsWith("Date,Prompt"))
                {
                    continue;
                }
            }

            List<string> parts = ParseCsvLine(line);

            if (parts.Count >= 4)
            {
                Entry entry = new Entry();
                entry._date = parts[0];
                entry._promptText = parts[1];
                entry._mood = parts[2];
                entry._entryText = parts[3];

                _entries.Add(entry);
            }
            else if (parts.Count == 3)
            {
                Entry entry = new Entry();
                entry._date = parts[0];
                entry._promptText = parts[1];
                entry._mood = "Neutral";
                entry._entryText = parts[2];

                _entries.Add(entry);
            }
        }
        Console.WriteLine("Journal successfully loaded from file!");
    }

    private string EscapeCsvField(string field)
    {
        if (field.Contains(",") || field.Contains("\"") || field.Contains("\n") || field.Contains("\r"))
        {
            field = field.Replace("\"", "\"\"");
            return $"\"{field}\"";
        }
        return field;
    }

    private List<string> ParseCsvLine(string line)
    {
        List<string> result = new List<string>();
        bool inQuotes = false;
        string currentField = "";

        for (int i = 0; i < line.Length; i++)
        {
            char c = line[i];

            if (c == '\"')
            {
                if (inQuotes && i + 1 < line.Length && line[i + 1] == '\"')
                {
                    currentField += '\"';
                    i++;
                }
                else
                {
                    inQuotes = !inQuotes;
                }
            }
            else if (c == ',' && !inQuotes)
            {
                result.Add(currentField);
                currentField = "";
            }
            else
            {
                currentField += c;
            }
        }
        result.Add(currentField);
        return result;
    }
}