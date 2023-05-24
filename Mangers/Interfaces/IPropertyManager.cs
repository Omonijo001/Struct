using NijolGroup.Enums;
using NijolGroup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NijolGroup.Mangers.Interfaces
{
    internal interface IPropertyManager
    {
        public Property Create(string name, string regNumber, PropertyType type, double price, string address);
        public Property Get(int id);
        public Property Get(string regNumber);
        public List<Property> GetAll();
        public Property Update(string name, string regNumber, PropertyType type, double price, string address);
        public void Delete(string regNumber);


    }
}
