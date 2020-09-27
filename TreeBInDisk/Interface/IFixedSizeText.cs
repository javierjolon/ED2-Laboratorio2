using System;
using System.Collections.Generic;
using System.Text;

namespace TreeBInDisk.Interface
{
	public interface IFixedSizeText
	{
		int FixedSize { get; }
		string ToFixedSizeString();
	}
}
