namespace phone_book_system
{
	internal class Program
	{
		static void Main(string[] args)
		{

			ContactManager contactManager = new ContactManager();

			Session s = new Session(contactManager);
			
			s.Handle_Answer_Code();
			
		}
	}
}
