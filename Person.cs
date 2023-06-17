using System;
namespace ToDo
{
	public class Person
	{
		public string isim { get; set; }
		public int ID { get; set; }

		public Person(string _isim, int _ID)
		{
			this.isim = _isim;
			this.ID = _ID;
		}
	}
}