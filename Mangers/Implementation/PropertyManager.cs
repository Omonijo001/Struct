using NijolGroup.Enums;
using NijolGroup.Mangers.Interfaces;
using NijolGroup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NijolGroup.Mangers.Implementation
{
    internal class PropertyManager : IPropertyManager
    {
        public static List<Property> propertyDatabase = new List<Property>();
        public Property Create(string name, string regNumber, PropertyType type,double price, string address)
        {
            var propertyExist = CheckIfExist(regNumber);
            if (propertyExist == null)
            {
                int id = propertyDatabase.Count + 1;
                string owner = "agent";
                Property property = new Property(id,name, regNumber, type, price, address,true, owner);
                propertyDatabase.Add(property);
                return property;
            }
            Console.WriteLine("Property already exist");
            return null;
        }

        public void Delete(string regNumber)
        {
            var property = CheckIfExist(regNumber);
            if (property == null)
            {
                Console.WriteLine("Property does not exist");
            }
            propertyDatabase.Remove(property);
            Console.WriteLine("Property Deleted Sucessfully");

        }

        public Property Get(int id)
        {
            foreach (var property in propertyDatabase)
            {
                if(property.Id == id)
                {
                    return property;
                }
            }
            return null;
        }

        public Property Get(string regNumber)
        {
            foreach (var property in propertyDatabase)
            {
                if (property.RegNumber == regNumber)
                {
                    return property;
                }
            }
            return null;
        }


        public List<Property> GetAll()
        {
            return propertyDatabase;
        }

        public Property Update(string name, string regNumber, PropertyType type, double price, string address)
        {
            var property = CheckIfExist(regNumber);
            if(property !=  null)
            {
                property.Type = type;
                property.Price = price;
                property.Address = address;
                return property;
            }
            return null;

        }

        private Property CheckIfExist(string regNumber)
        {
            foreach (var property in propertyDatabase)
            {
                if(property.RegNumber == regNumber)
                {
                    return property;
                }
            }
            return null;
        }
    }
}
