using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

public class Program
{
    static void Main()
    {
        List<Contact> contacts = new List<Contact> { };
        Contact.LoadFromFile(contacts);
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("\n----Adressbok----" +
                              "\n[1]Visa alla Kontakter" +
                              "\n[2]Lägg till Kontakt" +
                              "\n[3]Uppdatera Kontakt" +
                              "\n[4]Ta bort Kontakt" +
                              "\n[5]Sök Kontakt" +
                              "\n[6]Avsluta");
            Int32.TryParse(Console.ReadLine(), out int meny);

            switch (meny)
            {
                case 1:
                    ShowContacts(contacts);
                    break;
                case 2: //AddContact();
                    AddContact(contacts);
                    break;
                case 3: //UpdateContact();
                    break;
                case 4: //RemoveContact();
                    break;
                case 5:
                    SearchContact(contacts);
                    break;
                case 6:
                    running = false;
                    break;
                default:
                    Console.WriteLine("\nFelaktigt val!");
                    Console.ReadKey();
                    break;
            }
        }
    }

    static void SearchContact(List<Contact> contacts)
    {
        Console.Write("\nSök efter ett namn eller postort: ");
        string? search = (Console.ReadLine() ?? "").ToLower();

        var result = contacts.Where(k => (k.Name ?? "").ToLower().Contains(search) ||
                                         (k.PostalAddress ?? "").ToLower().Contains(search)).ToList();

        if (!result.Any())
        {
            Console.WriteLine("Kunde ej hitta kontakten du sökte efter.");
            Console.ReadKey();
            return;
        }

        Console.WriteLine($"{result.Count()} kontakter hittades.");
        int index = 1;
        foreach (var c in result)
        {
            Console.WriteLine($"{index}: {c}");
            index++;
        }
        Console.ReadLine();
    }

    static void ShowContacts(List<Contact> contacts)
    {
        if (!contacts.Any())
        {
            Console.WriteLine("\nAdressboken är tom!");
            Console.ReadLine();
            return;
        }
        foreach (var c in contacts)
        {
            Console.WriteLine(c);
        }
        Console.ReadLine();
    }

    static void AddContact(List<Contact> contacts)
    {
        Console.Write("\nNamn: ");
        string? name = Console.ReadLine();

        Console.Write("\nAdress: ");
        string? address = Console.ReadLine();

        Console.Write("\nPostnummer: ");
        string? zipCode = Console.ReadLine();

        Console.Write("\nPostort: ");
        string? postalAddress = Console.ReadLine();

        Console.Write("\nMobil: ");
        string? phone = Console.ReadLine();

        Console.Write("\nEmail: ");
        string? email = Console.ReadLine();

        Contact newContact = new Contact(name, address, zipCode, postalAddress, phone, email);
        contacts.Add(newContact);

        Console.WriteLine(newContact.ToString());
        Contact.SaveToFile(contacts);

        Console.WriteLine("Contact added!");
        Console.ReadLine();
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