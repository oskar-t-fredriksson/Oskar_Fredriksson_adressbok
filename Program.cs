using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace Oskar_Fredriksson_adressbok
{
    class Program
    {
        class PhoneBook
        {
             string newName, newAdress, newPhone, newEmail;
            public PhoneBook(string name, string address, string phone, string email)
            {
                newName = name;
                newAdress = address;
                newPhone = phone;
                newEmail = email;
            }
            public string List()
            {
                return $"{newName}, {newAdress}, {newPhone}, {newEmail}";
            }
        }
        static void Main(string[] args)
        {
            //C:\\Users\\oskar\\adressbok.txt
            string command;
            string line;
            Console.WriteLine("Kontaktboken!");
            Console.WriteLine("Välj mellan att 'Visa', 'Ta bort', 'Lägg till' och Avsluta!");
            Console.WriteLine("> ");
            command = Console.ReadLine();
            List<DictionaryEntry> contacts = new List<DictionaryEntry>();
            string newName;
            string newAdress;
            string newPhone;
            string newEmail;

            do
            {
                //Read and write textfile code https://docs.microsoft.com/en-us/troubleshoot/dotnet/csharp/read-write-text-file


                //Read the first line of text

                if (command == "Visa")
                {
                    StreamReader sr = new StreamReader("C:\\Users\\oskar\\adressbok.txt");
                    line = sr.ReadLine();
                    while (line != null)
                    {
                        Console.WriteLine(line);
                        line = sr.ReadLine();
                    }
                    sr.Close();
                    Main(null);

                }
                else if (command == "Lägg till")
                {
                    //Edit and save function
                    StreamWriter sw = new StreamWriter(Path.Combine("C:\\Users\\oskar\\adressbok.txt"), true);
                    //User input data variables
                    Console.Write("Ange namn: ");
                    newName = Console.ReadLine();
                    Console.Write("\nAnge adress: ");
                    newAdress = Console.ReadLine();
                    Console.Write("\nAnge telefon: ");
                    newPhone = Console.ReadLine();
                    Console.Write("\nAnge e-post: ");
                    newEmail = Console.ReadLine();
                    //Add input to list (NOT WORKING?)
                    contacts.Add(new DictionaryEntry(newName, newAdress));
                    contacts.Add(new DictionaryEntry(newPhone, newEmail));
                    Console.WriteLine($"{newName} tillagd!");
                    PhoneBook One = new PhoneBook($"{newName}", $"{newAdress}", $"{newPhone}", $"{newEmail}");
                    //Add input to txt file
                    sw.WriteLine(One.List());
                    sw.Close();
                    Main(null);




                }
                //Test for list
                else if (command == "List")
                {
                    Console.WriteLine("hej");
                    for (int i = 0; i < contacts.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}: {contacts[i]}");
                    }
                    Main(null);
                }

            }

            while (command != "Avsluta"); 
            
            

            

        }
    }
}
