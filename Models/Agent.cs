using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NijolGroup.Models
{
    internal class Agent
    {
        public int Id;
        public string Name;
        public string Email;
        public string Password;
        public string PhoneNumber;
        public double Wallet;

        public Agent(int id, string name, string email, string password, string phoneNumber, double wallet)
        {
            Id = id;
            Name = name;
            Email = email;  
            Password = password;
            PhoneNumber = phoneNumber;
            Wallet = wallet;


        }


        
    }
}
