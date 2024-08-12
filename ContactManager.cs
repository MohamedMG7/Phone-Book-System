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

		public void RemoveContact() { 
		
		}

		public List<Contact> GetContacts() {
			return _contacts;
		}
	}
}
