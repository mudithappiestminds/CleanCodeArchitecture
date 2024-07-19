// Data/InMemoryDataStore.cs
public static class InMemoryDataStore
{
    public static List<AadharCard> AadharCards { get; } = new List<AadharCard>();
    public static List<User> Users { get; } = new List<User>
    {
        new User { Username = "admin", Password = "admin123", Role = "Admin" },
        new User { Username = "citizen", Password = "citizen123", Role = "Citizen" }
    };
}
