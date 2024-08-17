using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phone_book_system
{
	internal class ContactManager
	{
		private readonly List<Contact> _contacts = new List<Contact>();

		public void AddContact(Contact contact) {
			_contacts.Add(contact);
		}

		public void RemoveContact(Contact contact) {
			if (_contacts.Contains(contact)) {
				_contacts.Remove(contact);
				Console.WriteLine("Deleted saccesfully");
			}
			else {
				Console.WriteLine("Contact Not Found");
			}
			
		}

		public List<Contact> GetContacts() {
			return _contacts;
		}

		// This Function Search A Contact By Name And Returns It
		public Contact GetContact(string Name) {
			return _contacts.FirstOrDefault(d => d.Name == Name); 
		}


		// this function takes a contact edit it's information 
		public void EditContact(Contact contact, string NewName, string NewPhoneNumber, string NewSecondPhoneNumber, bool NewIsFavourite) {
			
			contact.Name = NewName;
			contact.Phone_Number = NewPhoneNumber;
			contact.Second_Phone_Number = NewSecondPhoneNumber;
			contact.IsFavourite = NewIsFavourite;

        }
	}
}
