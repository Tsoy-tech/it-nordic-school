﻿using System;
using System.Collections.Generic;
using System.Text;

namespace L15_ClassWork
{
	public class Account<T>
	{
		public T Id { get; private set; }
		public string Name { get; private set; }

		public Account(T id, string name)
		{
			Id = id;
			Name = name;
		}

		public void WriteProperties()
		{
			Console.WriteLine($"{Id}	{Name}");
		}
	}
}
