using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TreeBInDisk.Interface;

namespace TreeBInDisk.Models
{
    public class Sucursal_Producto : IComparable, IFixedSizeText
    {
        [Display(Name = "ID Sucursal")]
        public int IDSucursal { get; set; }

        [Display(Name = "ID Producto")]
        public int IDProducto { get; set; }

        [Display(Name = "Cantidad en inventario")]
        public int Stock { get; set; }

        public int CompareTo(object obj)
        {
            var s2 = (Sucursal_Producto)obj;
            return IDSucursal.CompareTo(s2.IDSucursal);
        }

        public int FixedSize { get { return 30; } }

        public string ToFixedSizeString()
        {
            return $"{IDSucursal.ToString("0000000000;-0000000000")}~" +
                $"{IDProducto.ToString("0000000000;-0000000000")}~" +
                $"{Stock.ToString("0000000000;-0000000000")}";
        }

        public int FixedSizeText
        {
            //return suma de todos los caracteres en ToFixedSizeString
            get { return FixedSize; }
        }

        public override string ToString()
        {
            return string.Format("IDSucursal: {0}\r\nIDProducto: {1}\r\nStock: {2}"
                , IDSucursal.ToString("0000000000;-0000000000")
                , IDProducto.ToString("0000000000;-0000000000")
                , Stock.ToString("0000000000;-0000000000"));
        }
    }
}
