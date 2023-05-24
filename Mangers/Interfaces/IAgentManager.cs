using NijolGroup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NijolGroup.Mangers.Interfaces
{
    internal interface IAgentManager
    {
        public Agent Register(string name, string email, string password, string phoneNumber);
        public Agent Get(int id);
        public Agent Get(string email);
        public List<Agent> GetAll();
        public Agent Update(string email,string name, string phoneNumber);
        public void Delete(string email);
        public Agent Login(string email, string password);
    }
}
