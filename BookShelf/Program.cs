using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Bookshelf
{
	public class Work
	{

		public static void Main(string[] args)
		{
			Shelf<Item> shelf = new Shelf<Item> ();
			shelf.Contents = new Item[] {
				new Book ("The Count of Monte Cristo", "Alexandre Dumas"),
				new Book ("1000 Leagues Under the Sea", "Agatha Christie"),
				new Book ("And Then There Were None", "Agatha Christie"),
				new Book ("The Brothers Karamazov", "Fyodor Dostoyevsky"),
				new Movie ("The Godfather", 1972),
				new Movie ("Appollo 13", 1995) 
			};

			//for some reason, you only buy things that start with "The"
			foreach (Item item in shelf.Contents.Where(x => x.Title.StartsWith("The")))
				item.Own = true;
			//print in alphabetical order, with ownership
			Array.Sort(shelf.Contents);
			foreach (Item item in shelf.Contents)
				Console.WriteLine ("{0}", item.myFunc(item.Title, item.Own));
		}
	}

	public class Shelf<T> where T : IComparable<T>
	{
		public Shelf()
		{
		}

		public T[] Contents
		{
			get {
				return m_array;
			}
			set {
				m_array = value;
			}
		}

		private T[] m_array;
	}

	public class Book : Item
	{
		public Book(string title, string author) : base(title)
		{
		}
	}


	public class Movie : Item
	{
		public Movie(string title, int release) : base (title)
		{
		}
	}

	public class Item : IComparable<Item>
	{
		public Item(string title)
		{
			Title = title;
		}
		public string Title { get; set; }
		public bool Own { get; set; }

		public int CompareTo(Item i)
		{
			return String.Compare (this.Title, i.Title, true);
		}

		public Func<string, bool, string> myFunc = (x, y) => y ? x+", Own" : x+", Don't own";

	}
}
