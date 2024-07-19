// Services/AadharCardService.cs
using System.Text.RegularExpressions;

public class AadharCardService : IAadharCardService
{
    public IEnumerable<AadharCard> GetAll() => InMemoryDataStore.AadharCards;

      public void Add(AadharCard AadharCard)
    {
        if (!IsValidId(AadharCard.Id))
            throw new ArgumentException("Invalid ID format.");
        if (InMemoryDataStore.AadharCards.Any(x => x.Id == AadharCard.Id))
            throw new ArgumentException("ID already exists.");
        InMemoryDataStore.AadharCards.Add(AadharCard);
    }

    public void Update(AadharCard AadharCard)
    {
        var existingCard = GetById(AadharCard.Id);
        if (existingCard == null)
            throw new KeyNotFoundException("Identity card not found.");
        existingCard.Name = AadharCard.Name;
        existingCard.DateOfBirth = AadharCard.DateOfBirth;
        existingCard.Address = AadharCard.Address;
        existingCard.State = AadharCard.State;
        existingCard.City = AadharCard.City;
        existingCard.DocumentProofs = AadharCard.DocumentProofs;
    }

    public void Delete(string id)
    {
        var AadharCard = GetById(id);
        if (AadharCard != null)
            InMemoryDataStore.AadharCards.Remove(AadharCard);
    }

    public IEnumerable<AadharCard> FilterBy(string name, string state, string city)
    {
        return InMemoryDataStore.AadharCards
            .Where(x => (string.IsNullOrEmpty(name) || x.Name.Contains(name, StringComparison.OrdinalIgnoreCase)) &&
                        (string.IsNullOrEmpty(state) || x.State.Contains(state, StringComparison.OrdinalIgnoreCase)) &&
                        (string.IsNullOrEmpty(city) || x.City.Contains(city, StringComparison.OrdinalIgnoreCase)));
    }

      public AadharCard GetById(string id) => InMemoryDataStore.AadharCards.FirstOrDefault(x => x.Id == id);

    public bool IsValidId(string id)
    {
        if (id == null) return false;
        return Regex.IsMatch(id, @"^\d{12}$");
    }
}
