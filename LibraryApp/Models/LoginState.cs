public class UserContainer
{
    public List<UserData>? users { get; set; }
}
public class UserData
{
    public string? username { get; set; }
    public string? password { get; set; }
    public string? role { get; set; }
}