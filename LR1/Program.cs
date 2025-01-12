using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        string filePath = "D:\\уник\\Основы программной инженерии\\ЛР№1\\LR1\\LR1\\data.txt";

        // Считать данные из файла
        List<LibraryRecord> records = ReadData(filePath);

        // Запрос 1: Книги Пушкина Александра Сергеевича
        Console.WriteLine("Книги Пушкина Александра Сергеевича:");
        var pushkinBooks = records
            .Where(r => r.AuthorLastName == "Пушкин" && r.AuthorFirstName == "Александр" && r.AuthorMiddleName == "Сергеевич");
        foreach (var record in pushkinBooks)
        {
            Console.WriteLine(record);
        }

        // Запрос 2: Книги, взятые в марте 2015 года
        Console.WriteLine("\nКниги, взятые в марте 2015 года:");
        var march2015Books = records
            .Where(r => r.StartDate.Year == 2015 && r.StartDate.Month == 3);
        foreach (var record in march2015Books)
        {
            Console.WriteLine(record);
        }
    }

    static List<LibraryRecord> ReadData(string filePath)
    {
        var records = new List<LibraryRecord>();
        foreach (var line in File.ReadAllLines(filePath))
        {
            string[] parts = line.Split(new[] { ' ' }, 9); // Разделение строки на 9 частей
            if (parts.Length == 9)
            {
                records.Add(new LibraryRecord
                {
                    ReaderLastName = parts[0],
                    ReaderFirstName = parts[1],
                    ReaderMiddleName = parts[2],
                    StartDate = DateTime.Parse(parts[3]),
                    EndDate = DateTime.Parse(parts[4]),
                    AuthorLastName = parts[5],
                    AuthorFirstName = parts[6],
                    AuthorMiddleName = parts[7],
                    BookTitle = parts[8]
                });
            }
        }
        return records;
    }
}

class LibraryRecord
{
    public string ReaderLastName { get; set; }
    public string ReaderFirstName { get; set; }
    public string ReaderMiddleName { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string AuthorLastName { get; set; }
    public string AuthorFirstName { get; set; }
    public string AuthorMiddleName { get; set; }
    public string BookTitle { get; set; }

    public override string ToString()
    {
        return $"{ReaderLastName} {ReaderFirstName} {ReaderMiddleName} взял \"{BookTitle}\" ({AuthorLastName} {AuthorFirstName} {AuthorMiddleName}) с {StartDate:dd.MM.yyyy} по {EndDate:dd.MM.yyyy}";
    }
}
