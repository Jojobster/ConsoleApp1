
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class Program
{
    static void Main()
    {
        Dictionary<string, int> myDictionary = new Dictionary<string, int>
        {
            {"a", 7},
            {"b", 4},
            {"c", 11}
        };

        Console.WriteLine("Початковий словник:");
        PrintDictionary(myDictionary);

        ReplaceWithSum(myDictionary);

        Console.WriteLine("\nСловник після заміни значень:");
        PrintDictionary(myDictionary);

        string jsonResult = ConvertDictionaryToJson(myDictionary);
        Console.WriteLine(jsonResult);
    }

    static void ReplaceWithSum(Dictionary<string, int> dictionary)
    {
        foreach (var key in dictionary.Keys.ToList())
        {
            dictionary[key] = dictionary.Values.Sum();
        }
    }

    static void PrintDictionary(Dictionary<string, int> dictionary)
    {
        foreach (var kvp in dictionary)
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value}");
        }
    }

    static string ConvertDictionaryToJson(Dictionary<string, int> dictionary)
    {
        return JsonSerializer.Serialize(dictionary);
    }
}
