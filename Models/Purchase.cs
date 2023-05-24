using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NijolGroup.Models
{
    internal class Purchase
    {
        public int Id;
        public string ReferenceNumber;
        public string ClientEmail;
        public string PropertyRegNo;

        public Purchase(int id, string clientEmail, string propertyRegNo, string referenceNumber)
        {
            Id = id;
            ClientEmail = clientEmail;
            PropertyRegNo = propertyRegNo;
            ReferenceNumber = referenceNumber;
        }
    }
}
