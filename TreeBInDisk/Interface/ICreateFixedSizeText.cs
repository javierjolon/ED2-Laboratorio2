using System;
using System.Collections.Generic;
using System.Text;

namespace TreeBInDisk.Interface
{
	public interface ICreateFixedSizeText<T> where T : IFixedSizeText
	{
		T Create(string FixedSizeText);
		T CreateNull();
	}
}
