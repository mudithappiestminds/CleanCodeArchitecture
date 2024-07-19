public interface IAadharCardService
{
    IEnumerable<AadharCard> GetAll();
    AadharCard GetById(string id);
    void Add(AadharCard AadharCard);
    void Update(AadharCard AadharCard);
    void Delete(string id);
    IEnumerable<AadharCard> FilterBy(string name, string state, string city);
    bool IsValidId(string id);
}