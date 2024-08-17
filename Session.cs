namespace phone_book_system
{
	internal class Session
	{

		private readonly ContactManager _contactManager;
		

		public Session(ContactManager contactManager) {
			_contactManager = contactManager;
		}

		public List<(string,string,string,bool)> Read_New_Contact_Values()
		{
			Console.WriteLine("Enter Name: ");
			string NewName = Console.ReadLine();
			Console.WriteLine("Enter PhoneNumebr: ");
			string NewPhoneNumber = Console.ReadLine();
			Console.WriteLine("Enter Second Phone Number: ");
			string NewSecondPhoneNumber = Console.ReadLine();
			Console.WriteLine("Do You Want To Add The Contact To Favourites[Y/N]: ");
			string NewIsFavourite = Console.ReadLine();
			bool IsFavouriteInput;
			if (NewIsFavourite.ToLower() == "y") {
				IsFavouriteInput = true;
			}
			else {
				IsFavouriteInput = false;
			}
			 
			List<(string,string,string,bool)> newValues = new List<(string, string, string, bool)>();
			
			newValues.Add((NewName, NewPhoneNumber, NewSecondPhoneNumber, IsFavouriteInput));
           

            return newValues;
		}
		public void Display_Contact(Contact contact) {
            Console.WriteLine(" ");
            Console.WriteLine("------------------------------");
            Console.WriteLine($"Name: {contact.Name}");
            Console.WriteLine($"Phone Number: {contact.Phone_Number}");
            Console.WriteLine($"Second Phone Number: {contact.Second_Phone_Number}");
            Console.WriteLine($"Favourite: {(contact.IsFavourite ? "Yes" : "No")}");
            Console.WriteLine("------------------------------");
            Console.WriteLine(" ");
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
				Console.WriteLine("[5] Remove Contact");
				Console.WriteLine("[6] Exit");
				Console.Write("Enter Code: ");
				string ans = Console.ReadLine();
				Console.WriteLine(" ");

				switch (ans)
				{
					case "1": Display_Contacts(); break;
					case "2": Add_Contact(); break;
					case "3": Edit_Contact(); break;
					case "4": Search_Contact(); break;
                    case "5": Remove_Contact(); break;
                    case "6": return;  
					default: Console.WriteLine("Invalid option. Please try again."); break;
				}

				Console.WriteLine();  
			}
		}

		public void Display_Contacts() {
			List<Contact> contacts = _contactManager.GetContacts();
			if (contacts.Count == 0) {
				Console.WriteLine("No Contacts To Display");
			}
			else {
				foreach (var ce in contacts)
				{
					Display_Contact(ce);
				}
				
			}
		}

		public void Add_Contact() {
			List<(string, string, string, bool)> contactInformation = Read_New_Contact_Values();
			Contact c = new Contact()
			{
				Name = contactInformation[0].Item1,
				Phone_Number = contactInformation[0].Item2,
				Second_Phone_Number = contactInformation[0].Item3,
				IsFavourite = contactInformation[0].Item4
            };
			

			_contactManager.AddContact(c);
			Console.WriteLine("Added");
			Console.WriteLine(" ");	
		}

		public void Edit_Contact()
		{
			Console.Write("What Contact Do You Want To Change: ");
			string Name = Console.ReadLine();
			Contact contact = _contactManager.GetContact(Name);
			Display_Contact(contact);
            Console.Write("Is This The Contact You Want To Chang[Y/N]: ");
            string answer = Console.ReadLine();

			if (answer.ToLower() == "y")
			{
				List<(string,string,string,bool)> newValues = Read_New_Contact_Values();
				_contactManager.EditContact(contact, newValues[0].Item1, newValues[0].Item2, newValues[0].Item3, newValues[0].Item4);
				Console.WriteLine("Done");
			}	
			else 
			{
				Console.WriteLine("Try again");	
			}
        
		}

		public void Search_Contact() {
			Console.Write("Enter The Name Of The Contact: ");
			string Name = Console.ReadLine();
			
            Contact contact = _contactManager.GetContact(Name);
			Display_Contact(contact);
		}

		public void Remove_Contact() {
			Console.WriteLine("What is The Contact That You Want To Delete: ");
			string contactName = Console.ReadLine();
			Contact contact = _contactManager.GetContact(contactName);
			_contactManager.RemoveContact(contact);
		}

	}
}
