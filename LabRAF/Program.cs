using System;
using System.IO;
using System.Text.Json;

public class Event
{
    public int EventNumber { get; set; }
    public string Location { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        Event Event1 = new Event { EventNumber = 1, Location = "Calgary" };

        SerializeToJsonFile("Events.json", Event1);

        Event deserializedEvent = DeserializeFromJsonFile("Events.json");
        Console.WriteLine($"Event Number: {deserializedEvent.EventNumber}");
        Console.WriteLine($"Location: {deserializedEvent.Location}");

        ReadFromFile("Events.json");
    }

    static void SerializeToJsonFile(string filePath1, object obj1)
    {
        string stringJson = JsonSerializer.Serialize(obj1);
        File.WriteAllText(filePath1, stringJson);
    }

    static Event DeserializeFromJsonFile(string filePath2)
    {
        string stringJson1 = File.ReadAllText(filePath2);
        return JsonSerializer.Deserialize<Event>(stringJson1);
    }
    static void ReadFromFile(string filePath3)
    {
        using (StreamWriter writer = new StreamWriter(filePath3))
        {
            writer.Write("Hackathon");
        }

        using (FileStream fs = new FileStream(filePath3, FileMode.Open))
        {
            fs.Seek(0, SeekOrigin.Begin);
            int firstChar = fs.ReadByte();
            Console.WriteLine($"First Character : \"{(char)firstChar}\"");
            fs.Seek(fs.Length / 2, SeekOrigin.Begin);
            int secondChar = fs.ReadByte();
            Console.WriteLine($"Second  Character is: \"{(char)secondChar}\"");
            fs.Seek(-1, SeekOrigin.End);
            int lastChar = fs.ReadByte();
            Console.WriteLine($" Last Character: \"{(char)lastChar}\"");
        }
    }
}