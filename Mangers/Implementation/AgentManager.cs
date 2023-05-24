using NijolGroup.Mangers.Interfaces;
using NijolGroup.Menu;
using NijolGroup.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NijolGroup.Mangers.Implementation
{
    internal class AgentManager : IAgentManager
    {
        public static List<Agent> agentDatabase = new List<Agent>()
        {
            new Agent(1,"Joshua", "josh@gmail.com", "josh1234", "080123456789", 400000),
        };
        public void Delete(string email)
        {
            var agent = CheckIfExist(email);
            if (agent == null)
            {
                Console.WriteLine("Agent does  not exist");
            }
            agentDatabase.Remove(agent);
            Console.WriteLine("Agent deleted successfully");
        }

        public Agent Get(int id)
        {
            foreach (var agent in agentDatabase)
            {
                if(agent.Id == id)
                {
                    return agent;
                }
            }
            return null;
        }

        public Agent Get(string email)
        {
            foreach (var agent in agentDatabase)
            {
                if (agent.Email == email)
                {
                    return agent;
                }
            }
            return null;
        }

        public List<Agent> GetAll()
        {
            return agentDatabase;
        }

        public Agent Login(string email, string password)
        {
            foreach (var agent in agentDatabase)
            {
                if (agent.Email == email && agent.Password == password)
                {
                    Console.WriteLine("Login successful");
                    return agent;
                }
                else if ((agent.Email == email && agent.Password != password) || (agent.Email != email && agent.Password == password) || (agent.Email != email && agent.Password != password))
                    
                {
                    return null;


                }
            }
            return null;
        }

        public Agent Register(string name, string email, string password, string phoneNumber)
        {
            var exists = CheckIfExist(email);
            if(exists == null)
            {
                int id = agentDatabase.Count + 1;
                double wallet = 0;
                Agent agent = new Agent(id, name, email, password, phoneNumber, wallet);
                agentDatabase.Add(agent);
                return agent;
            }
            return null;
            
        }

        public Agent Update(string email, string name, string phoneNumber)
        {
            var agent = CheckIfExist(email);
            if(agent != null)
            {
                agent.Name = name;
                agent.PhoneNumber = phoneNumber;
                return agent;
            }
            return null;
        }

        private Agent CheckIfExist(string email)
        {
            foreach (var agent in agentDatabase)
            {
                if (agent.Email == email)
                {
                    return agent;
                }
            }
            return null;
        }
    }
}
