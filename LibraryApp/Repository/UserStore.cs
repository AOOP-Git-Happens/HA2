using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using LibraryApp.Models;

namespace LibraryApp.Repository;

// 1. A simple class just to safely hold the JSON data
public class UserData
{
    public List<Member> Members { get; set; } = new List<Member>();
    public List<Librarian> Librarians { get; set; } = new List<Librarian>();
}

public class UserStore
{
    public static string LoggedInUsername { get; set; } = "";
    public List<Member> Members { get; set; } = new List<Member>();
    public List<Librarian> Librarians { get; set; } = new List<Librarian>();

    public UserStore()
    {
        LoadUsers();
    }

    public void LoadUsers()
    {
        string fileName = "Assets/login.json";
        
        if (!File.Exists(fileName)) return;

        string jsonString = File.ReadAllText(fileName);
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        
        UserData? loadedData = JsonSerializer.Deserialize<UserData>(jsonString, options);

        if (loadedData != null)
        {
            if (loadedData.Members != null) Members = loadedData.Members;
            if (loadedData.Librarians != null) Librarians = loadedData.Librarians;
        }
    }

    public string ValidateUser(string username, string password)
    {
        foreach (var member in Members)
        {
            if (member.UserName == username && member.Password == password) 
                return "member";
        }
        
        foreach (var librarian in Librarians)
        {
            if (librarian.UserName == username && librarian.Password == password) 
                return "librarian";
        }
        
        return "invalid";
    }
}