using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phone_book_system
{
	internal class Session
	{

		private readonly ContactManager _contactManager;
		Contact c = new Contact();

		public Session(ContactManager contactManager) {
			_contactManager = contactManager;
		}
		
		
		
		public void Handle_Answer_Code()
		{
			
			while (true)
			{
				Console.WriteLine("Phone Book System");
				Console.WriteLine("[1] Show Contacts");
				Console.WriteLine("[2] Add New Contact");
				Console.WriteLine("[3] Edit Contact Information");
				Console.WriteLine("[4] Search Contact");
				Console.WriteLine("[5] Exit");
				Console.Write("Enter Code: ");
				string ans = Console.ReadLine();
				Console.WriteLine(" ");

				switch (ans)
				{
					case "1": Display_Contacts(); break;
					case "2": Add_Contact(); break;
					//case "3": Edit_Contact(); break;
					case "4": Search_Contact(); break;
					case "5": return;  // Exit the method, ending the loop and closing the application
					default: Console.WriteLine("Invalid option. Please try again."); break;
				}

				Console.WriteLine();  // Add a blank line for better readability
			}
		}

		public void Display_Contacts() {
			//List<Contact> contacts = Return_Contacts();
			List<Contact> contacts = _contactManager.GetContacts();
			if (contacts.Count == 0) {
				Console.WriteLine("No Contacts To Display");
			}
			else {
				foreach (var ce in contacts)
				{
					Console.WriteLine($"Name: {ce.Name}");
					Console.WriteLine($"Phone Number: {ce.Phone_Number}");
					Console.WriteLine($"Second Phone Number: {ce.Second_Phone_Number}");
					Console.WriteLine($"Favourite: {(ce.IsFavourite ? "Yes" : "No")}");
					Console.WriteLine("------------------------------");
					Console.WriteLine(" ");
				}
				
			}
		}

		public void Add_Contact() {

			Contact c = new Contact()
			{
				Name = "Mohamed",
				Phone_Number = "01025861336",
				Second_Phone_Number = "01025861336",
				IsFavourite = true
			};
			

			_contactManager.AddContact(c);
			Console.WriteLine("Added");
			Console.WriteLine(" ");	
		}

		//public Contact Edit_Contact()
		//{
		//	Console.Write("What Contact Do You Want To Change: ");
		//	string Name = Console.ReadLine();
		//	Contact contact = _contactManager.GetContact(Name);
		//	Console.Write($"The Old Name is {contact.Name}, What is the New Name write skip to skip this: ");
		//	string newName = Console.ReadLine();
		//	return Contacts[0];
		//}

		public void Search_Contact() {
			Console.Write("Enter The Name Of The Contact: ");
			string Name = Console.ReadLine();
			Console.WriteLine();
			Contact contact = _contactManager.GetContact(Name);
			Console.WriteLine($"Name: {contact.Name}");
			Console.WriteLine($"Phone Number: {contact.Phone_Number}");
			Console.WriteLine($"Second Phone Number: {contact.Second_Phone_Number}");
			Console.WriteLine($"Favourite: {(contact.IsFavourite ? "Yes" : "No")}");
			Console.WriteLine("------------------------------");
			Console.WriteLine(" ");
		}

	}
}
