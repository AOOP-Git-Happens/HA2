using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using LibraryApp.Models;
using System.Security.Cryptography;
using System.Text;

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
    // Hash the password the user just typed in
    string hashedInputPassword = HashPassword(password);

    foreach (var member in Members)
    {
        // Compare the hashed input against the stored hash
        if (member.UserName == username && member.Password == hashedInputPassword) 
            return "member";
    }
    
    foreach (var librarian in Librarians)
    {
        // Compare the hashed input against the stored hash
        if (librarian.UserName == username && librarian.Password == hashedInputPassword) 
            return "librarian";
    }
    
    return "invalid";
}
    private string HashPassword(string password)
{
    using (SHA256 sha256Hash = SHA256.Create())
    {
        // Convert the string to a byte array and compute the hash
        byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
        
        // Convert the byte array back to a hexadecimal string
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < bytes.Length; i++)
        {
            builder.Append(bytes[i].ToString("x2"));
        }
        return builder.ToString();
    }
}
}