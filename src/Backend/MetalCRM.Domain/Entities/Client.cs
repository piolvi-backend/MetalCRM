namespace MetalCRM.Domain.Entities;

public class Client
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string PhoneOrCardNumber { get; set; } = string.Empty;
    public string BankName { get; set; } = string.Empty;
    public string DocsName { get; set; } = string.Empty;
    public string DocsNumber { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    
    public Client(string fullName, string phoneOrCardNumber, string bankName, string docsName, string docsNumber, string description)
    {
        Id = Guid.NewGuid();
        FullName = fullName;
        PhoneOrCardNumber = phoneOrCardNumber;
        CreatedAt = DateTime.UtcNow;
        BankName = bankName;
        DocsName = docsName;
        DocsNumber = docsNumber;
        Description = description;
    }
    
    private Client() { }
}