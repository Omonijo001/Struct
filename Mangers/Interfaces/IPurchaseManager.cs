using NijolGroup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NijolGroup.Mangers.Interfaces
{
    internal interface IPurchaseManager
    {
        public Purchase Make(string clientEmail, string propertyRegNo);
        public Purchase Get(int id);
        public Purchase Get(string referenceNumber);
        public List<Purchase> GetAll();
        public void Delete(string referenceNumber);
    }
}
