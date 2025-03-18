using System;
using System.IO;
using System.Linq;
using System.Text.Json;

public interface IRepository : IDisposable
{
    Celebrity[] GetAllCelebrities();
    Celebrity? GetCelebrityById(int id);
    Celebrity[] GetCelebritiesBySurname(string surname);
    string? GetPhotoPathById(int id);
}

public record Celebrity(int Id, string Name, string Surname, string PhotoPath);


public class Repository : IRepository
{
    private readonly string jsonFilePath;
    public static string directoryPath = "C:\\Users\\ghigher\\Desktop\\labs-4-sem\\TPVI\\Celebrities";
    public static string JsonFileName { get; set; } = "Celebrities.json";

    private Repository(string directoryPath)
    {
        jsonFilePath = Path.Combine(directoryPath, JsonFileName);
    }

    public static IRepository Create(string directoryPath)
    {
        return new Repository(directoryPath);
    }

    public void Dispose() { }

    public Celebrity[] GetAllCelebrities()
    {

            string json = File.ReadAllText(jsonFilePath);
            return JsonSerializer.Deserialize<Celebrity[]>(json) ?? Array.Empty<Celebrity>();
    }

    public Celebrity? GetCelebrityById(int id) =>
        GetAllCelebrities().FirstOrDefault(x => x.Id == id);

    public Celebrity[] GetCelebritiesBySurname(string surname) =>
        GetAllCelebrities()
            .Where(x => x.Surname.Equals(surname, StringComparison.OrdinalIgnoreCase))
            .ToArray();

    public string? GetPhotoPathById(int id) =>
        GetCelebrityById(id)?.PhotoPath;
}


