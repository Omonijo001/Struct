using NijolGroup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NijolGroup.Mangers.Interfaces
{
    internal interface IClientManager
    {
        public Client Register(string name, string email, string password, string phoneNumber);
        public Client Get(int id);
        public Client Get(string email);
        public List<Client> GetAll();
        public Client Update(string email, string name,string phoneNumber);
        public void Delete(string email);
        public Client Login(string email, string password);
        public void FundWallet(string email, double amount);
    }
}
