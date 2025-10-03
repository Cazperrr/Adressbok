using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

public class Program
{
    static void Main()
    {
        List<Contact> contacts = new List<Contact> { };
        Contact.LoadFromFile(contacts);
        AddContact(contacts);
        Contact.SaveToFile(contacts);
        ChangeContact(contacts);
    }

    static void AddContact(List<Contact> contacts)
    {
        Console.Write("\nNamn: ");
        string name = Console.ReadLine();

        Console.Write("\nAdress: ");
        string address = Console.ReadLine();

        Console.Write("\nPostnummer: ");
        string zipCode = Console.ReadLine();

        Console.Write("\nPostort: ");
        string postalAddress = Console.ReadLine();

        Console.Write("\nMobil: ");
        string phone = Console.ReadLine();

        Console.Write("\nEmail: ");
        string email = Console.ReadLine();

        Contact newContact = new Contact(name, address, zipCode, postalAddress, phone, email);
        contacts.Add(newContact);

        Console.WriteLine(newContact.ToString());
        Console.WriteLine("Contact added!");
    }

    static void ChangeContact(List<Contact> contacts)
    {
        Console.Write($"name of contact to change: ");
        string search = Console.ReadLine();

        Contact contact = contacts.FirstOrDefault(c => c.Name.Equals(search, StringComparison.OrdinalIgnoreCase));

        if (contact != null)
        {
            Console.WriteLine($"editing {contact.Name}");
            Console.Write($"Enter new address: ");
            contact.Address = Console.ReadLine();

            Console.WriteLine($"contact updated");
            Contact.SaveToFile(contacts);
        }
    }
}