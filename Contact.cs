class Contact
{
    static string filePath = "contacts.txt";

    // Properties
    public string Name { get; set; }
    public string Address { get; set; }
    public string ZipCode { get; set; }
    public string PostalAddress { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }

    // Require all values when creating contact object
    public Contact(string name, string address, string zipCode, string postalAddress, string phone, string email)
    {
        Name = name;
        Address = address;
        ZipCode = zipCode;
        PostalAddress = postalAddress;
        Phone = phone;
        Email = email;
    }

    public override string ToString() // Overrides built in ToString method so you see contact details instead of Namespace.Contact
    {
        return $"{Name}, {Address}, {ZipCode}, {PostalAddress}, {Phone}, {Email}";
    }

    public static void SaveToFile(List<Contact> contacts)
    {
        using (StreamWriter writer = new StreamWriter(filePath)) // Open or Create contacts.txt
        {
            foreach (Contact c in contacts) // Loop through every contact in the list, write one line per contact
            {
                writer.WriteLine($"{c.Name} | {c.Address} | {c.ZipCode} | {c.PostalAddress} | {c.Phone} | {c.Email}");
            }
        }
    }

    public static void LoadFromFile(List<Contact> contacts)
    {
        if (File.Exists(filePath)) // Check if file exists
        {
            string[] lines = File.ReadAllLines(filePath); // Read whole file and return array of strings.
            foreach (string line in lines)
            {
                string[] parts = line.Split('|'); // Splits strings by |
                if (parts.Length == 6) // Only add if all 6 fields
                {
                    // Create new Contact object for every Contact
                    contacts.Add(new Contact(

                        parts[0], // Name
                        parts[1], // Address
                        parts[2], // ZipCode
                        parts[3], // PostalAddress
                        parts[4], // Phone
                        parts[5]  // Email
                    ));
                }
            }
        }
        else
        {
            Console.WriteLine($"File: {filePath} does not exist.");
        }
    }
}