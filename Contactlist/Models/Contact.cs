using Contactlist.Interfaces;

namespace Contactlist.Models;

public class Contact : IContact
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string FistName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string StreetName { get; set; } = null!;
    public string City { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public string FirstName { get; set; } = null!;

 
}
