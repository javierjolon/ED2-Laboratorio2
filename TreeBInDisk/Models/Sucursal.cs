using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TreeBInDisk.Interface;

namespace TreeBInDisk.Models
{
	public class Sucursal : IComparable, IFixedSizeText
	{
		public int ID { get; set; }

		public string Nombre { get; set; }

		public string Direccion { get; set; }

		public int CompareTo(object obj)
		{
			var s2 = (Sucursal)obj;
			return ID.CompareTo(s2.ID);
		}

		public int FixedSize { get { return 62; } }

		public string ToFixedSizeString()
		{
			return $"{ID.ToString("0000000000;-0000000000")}~" +
				$"{string.Format("{0,-25}", Nombre)}~" +
				$"{string.Format("{0,-25}", Direccion)}";
		}

		public int FixedSizeText
		{
			//return suma de todos los caracteres en ToFixedSizeString
			get { return FixedSize; }
		}

		public override string ToString()
		{
			return string.Format("ID: {0}\r\nNombre: {1}\r\nDireccion: {2}"
				, ID.ToString("0000000000;-0000000000")
				, string.Format("{0,-25}", Nombre)
				, string.Format("{0,-25}", Direccion));
		}
	}
}
