using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Collections.Generic;

public interface IRepository : IDisposable
{
    Celebrity[] GetAllCelebrities();
    Celebrity? GetCelebrityById(int id);
    Celebrity[] GetCelebritiesBySurname(string surname);
    string? GetPhotoPathById(int id);
    int? AddCelebrity(Celebrity celebrity);
    bool DeleteCelebrityById(int id);
    int? UpdateCelebrityById(int id, Celebrity celebrity);
    int SaveChanges();
}

public record Celebrity(int Id, string Name, string Surname, string PhotoPath);

public class Repository : IRepository
{
    private readonly string jsonFilePath;
    public static string DirectoryPath = "C:\\Users\\ghigher\\Desktop\\labs-4-sem\\TPVI\\Celebrities";
    public static string JsonFileName = "Celebrities.json";

    private List<Celebrity> celebrities;

    public Repository(string directoryPath)
    {
        jsonFilePath = Path.Combine(directoryPath, JsonFileName);
        LoadCelebrities();
    }

    public static IRepository Create(string directoryPath)
    {
        return new Repository(directoryPath);
    }

    public void Dispose() { }

    private void LoadCelebrities()
    {
        if (File.Exists(jsonFilePath))
        {
            var json = File.ReadAllText(jsonFilePath);
            celebrities = JsonSerializer.Deserialize<List<Celebrity>>(json) ?? new List<Celebrity>();
        }
        else
        {
            celebrities = new List<Celebrity>();
        }
    }

    public Celebrity[] GetAllCelebrities()
    {
        return celebrities.ToArray();
    }

    public Celebrity? GetCelebrityById(int id)
    {
        return celebrities.FirstOrDefault(x => x.Id == id);
    }

    public Celebrity[] GetCelebritiesBySurname(string surname)
    {
        return celebrities
            .Where(x => x.Surname.Equals(surname, StringComparison.OrdinalIgnoreCase))
            .ToArray();
    }

    public string? GetPhotoPathById(int id)
    {
        var celebrity = GetCelebrityById(id);
        return celebrity?.PhotoPath;
    }

    public int? AddCelebrity(Celebrity celebrity)
    {
        if (celebrity == null)
            return null;

        var maxId = celebrities.Any() ? celebrities.Max(x => x.Id) : 0;
        int newId = celebrity.Id != 0 && !celebrities.Any(x => x.Id == celebrity.Id) ? celebrity.Id : maxId + 1;
        var newCelebrity = new Celebrity(newId, celebrity.Name, celebrity.Surname, celebrity.PhotoPath);
        celebrities.Add(newCelebrity);
        return newId;
    }

    public bool DeleteCelebrityById(int id)
    {
        var celebrity = celebrities.FirstOrDefault(x => x.Id == id);
        if (celebrity == null)
            return false;

        celebrities.Remove(celebrity);
        return true;
    }

    public int? UpdateCelebrityById(int id, Celebrity celebrity)
    {
        var index = celebrities.FindIndex(x => x.Id == id);
        if (index == -1)
            return null;

        var updatedCelebrity = new Celebrity(id, celebrity.Name, celebrity.Surname, celebrity.PhotoPath);
        celebrities[index] = updatedCelebrity;
        return id;
    }

    public int SaveChanges()
    {
        var json = JsonSerializer.Serialize(celebrities, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(jsonFilePath, json);
        var changes = celebrities.Count;
        return changes;
    }
}