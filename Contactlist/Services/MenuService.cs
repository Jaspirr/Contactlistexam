using Contactlist.Interfaces;
using Contactlist.Models;
using Newtonsoft.Json;
using Contactlist.Services;

namespace Contactlist.Services;

public class MenuService
{
    public List<Contact> contacts = new List<Contact>();
    public FileService file = new FileService();
    private string? json;


    public string FilePath { get; set; } = null!;

    public void WelcomeMenu()
    {
        Console.WriteLine("Welcome to the Address Book");
        Console.WriteLine("1. Add a new contact.");
        Console.WriteLine("2. Show all contacts.");
        Console.WriteLine("3. Show a specific contact.");
        Console.WriteLine("4. Delete a specific contact.");
        Console.WriteLine("Select a alternative from above:");
        var option = Console.ReadLine();

        switch (option)
        {
            case "1": AddContact(); break;

            case "2": AllContacts(); break;

            case "3": SpecificContact(); break;

            case "4": DeleteContact(); break;

            default:
                Console.Clear();
                Console.WriteLine("Invalid option, please try again");
                Console.WriteLine();
                break;
        }
    }

    private void AddContact()
    {
        Console.Clear();
        Contact contact = new Contact();
        Console.Write("Enter the first name of the new contact: ");
        contact.FirstName = Console.ReadLine();
        Console.Write("Enter the last name of the new contact: ");
        contact.LastName = Console.ReadLine();
        Console.Write("Enter the phone number of the new contact: ");
        contact.Phone = Console.ReadLine();
        Console.Write("Enter the email of the new contact: ");
        contact.Email = Console.ReadLine();
        Console.Write("Enter the street name of the new contact: ");
        contact.StreetName = Console.ReadLine();
        Console.Write("Enter the city of the new contact: ");
        contact.City = Console.ReadLine();
        Console.Write("Enter the postal code of the new contact: ");
        contact.PostalCode = Console.ReadLine();

        contacts.Add(contact);
        string json = JsonConvert.SerializeObject(contacts);
        File.WriteAllText("content.json", json);
        Console.WriteLine();
        Console.WriteLine("Contact successfully added!");
        Console.WriteLine();
        Console.WriteLine("Press enter to go back to the menu");
        Console.ReadKey();
        Console.Clear();


    }

    private void AllContacts()
    {
        Console.Clear();
        if (!File.Exists("content.json"))
        {
            Console.WriteLine("No contacts to display.");
        }
        else
        {
            string json = File.ReadAllText("content.json");
            contacts = JsonConvert.DeserializeObject<List<Contact>>(json)!;

            foreach (Contact contact in contacts!)
            {
                Console.WriteLine("First Name: " + contact.FirstName);
                Console.WriteLine("Last Name: " + contact.LastName);
                Console.WriteLine("Email: " + contact.Email);
                Console.WriteLine("-------------------");
            }
        }
    }
    private void SpecificContact()
    {
        Console.Clear();
        Console.Write("Enter the first name or last name of the contact you want to view: ");
        string name = Console.ReadLine();
        string json = File.ReadAllText("content.json");
        contacts = JsonConvert.DeserializeObject<List<Contact>>(json)!;
        List<Contact> foundContacts = contacts.FindAll(c => c.FirstName == name || c.LastName == name);
        if (foundContacts.Count == 0)
        {
            Console.WriteLine("Contact not found.");
        }
        else if (foundContacts.Count == 1)
        {
            var contactToView = foundContacts[0];
            Console.WriteLine("First Name: " + contactToView.FirstName);
            Console.WriteLine("Last Name: " + contactToView.LastName);
            Console.WriteLine("Phone: " + contactToView.Phone);
            Console.WriteLine("Email: " + contactToView.Email);
            Console.WriteLine("Street: " + contactToView.StreetName);
            Console.WriteLine("City: " + contactToView.City);
            Console.WriteLine("Postal Code: " + contactToView.PostalCode);
            Console.WriteLine("ID: " + contactToView.Id);
            Console.WriteLine("-------------------");
            Console.WriteLine();
            Console.WriteLine("Press enter to go back to the menu");
            Console.ReadKey();
            Console.Clear();
        }
        else
        {
            Console.WriteLine("Multiple contacts found, please specify the last name of the contact you want to view:");
            foreach (var contact in foundContacts)
            {
                Console.WriteLine("Last name: " + contact.LastName + "   | Full name: " + contact.FirstName + " " + contact.LastName);
            }
            Console.WriteLine();
            Console.WriteLine("Type the last name of the contact you want to view:");
            string lastName = Console.ReadLine();
            var contactToView = foundContacts.FirstOrDefault(c => c.LastName == lastName);

            if (contactToView != null)
            {
                Console.WriteLine("First Name: " + contactToView.FirstName);
                Console.WriteLine("Last Name: " + contactToView.LastName);
                Console.WriteLine("Phone: " + contactToView.Phone);
                Console.WriteLine("Email: " + contactToView.Email);
                Console.WriteLine("Street: " + contactToView.StreetName);
                Console.WriteLine("City: " + contactToView.City);
                Console.WriteLine("Postal Code: " + contactToView.PostalCode);
                Console.WriteLine("ID: " + contactToView.Id);
                Console.WriteLine("-------------------");
                Console.WriteLine();
                Console.WriteLine("Press enter to go back to the menu");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Invalid last name, contact not found.");
            }
        }
    }
    private void DeleteContact()
    {
        Console.Clear();
        Console.Write("Enter the first name or last name of the contact you want to delete: ");
        string name = Console.ReadLine();
        string json = File.ReadAllText("content.json");
        contacts = JsonConvert.DeserializeObject<List<Contact>>(json);
        Contact foundContact = contacts.Find(c => c.FirstName == name || c.LastName == name);
        if (foundContact != null)
        {
            Console.WriteLine("Are you sure you want to delete this contact? (y/n)");
            Console.WriteLine();
            Console.WriteLine("Full name: " + foundContact.FirstName + " " + foundContact.LastName);
            string confirm = Console.ReadLine();
            if (confirm == "y")
            {
                contacts.Remove(foundContact);
                json = JsonConvert.SerializeObject(contacts);
                File.WriteAllText("content.json", json);
                Console.WriteLine("Contact successfully deleted!");
            }
            else if (confirm == "n")
            {
                Console.WriteLine();
                Console.WriteLine("Contact not deleted.");
                Console.WriteLine();
                Console.WriteLine("Press enter to go back to the menu");
                Console.ReadLine();
                Console.Clear();
            }
        }
        else
        {
            List<Contact> foundContacts = contacts.FindAll(c => c.FirstName == name || c.LastName == name);
            if (foundContacts.Count == 0)
            {
                Console.WriteLine("Contact not found.");
            }
            else if (foundContacts.Count == 1)
            {
                Console.WriteLine("Are you sure you want to delete this contact? (y/n)");
                Console.WriteLine();
                Console.WriteLine("Full name: " + foundContacts[0].FirstName + " " + foundContacts[0].LastName);
                string confirm = Console.ReadLine();
                if (confirm == "y")
                {
                    contacts.Remove(foundContacts[0]);
                    json = JsonConvert.SerializeObject(contacts);
                    File.WriteAllText("content.json", json);
                    Console.WriteLine("Contact successfully deleted!");
                }
                else if (confirm == "n")
                {
                    Console.WriteLine();
                    Console.WriteLine("Contact not deleted.");
                    Console.WriteLine();
                    Console.WriteLine("Press enter to go back to the menu");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
            else if (foundContacts.Count > 1)
            {
                Contact contactToDelete = null;
                while (contactToDelete == null)
                {
                    Console.WriteLine("Multiple contacts found with that name, please specify the first name of the contact to delete:");
                    foreach (var contact in foundContacts)
                    {
                        Console.WriteLine("Full name: " + contact.FirstName + " " + contact.LastName);
                    }
                    Console.WriteLine("Type the first name of the contact you want to delete:");
                    string firstName = Console.ReadLine();
                    contactToDelete = foundContacts.Find(c => c.FirstName == firstName);
                    if (contactToDelete == null)
                    {
                        Console.WriteLine("Contact not found with that first name, please try again.");
                    }
                }
                Console.WriteLine("Are you sure you want to delete this contact? (y/n)");
                Console.WriteLine();
                Console.WriteLine("Full name: " + contactToDelete.FirstName + " " + contactToDelete.LastName);
                string confirm = Console.ReadLine();
                if (confirm == "y")
                {
                    contacts.Remove(contactToDelete);
                    json = JsonConvert.SerializeObject(contacts);
                    File.WriteAllText("content.json", json);
                    Console.WriteLine("Contact successfully deleted!");
                }
                else if (confirm == "n")
                {
                    Console.WriteLine();
                    Console.WriteLine("Contact not deleted.");
                    Console.WriteLine();
                    Console.WriteLine("Press enter to go back to the menu");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }
    }
}
