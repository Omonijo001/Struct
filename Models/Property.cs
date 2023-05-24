using NijolGroup.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NijolGroup.Models
{
    internal class Property
    {
        public int Id;
        public string Name;
        public string RegNumber;
        public PropertyType Type;
        public double Price;
        public string Address;
        public bool IsAvailable;
        public string Owner;

        public Property(int id, string name, string regNumber, PropertyType type, double price, string address, bool isAvailable, string owner)
        {
            Id = id;
            Name = name;
            RegNumber = regNumber;
            Type = type;
            Price = price;
            Address = address;
            IsAvailable = isAvailable;
            Owner = owner;
           
        }
        
    }
}
