using NijolGroup.Mangers.Interfaces;
using NijolGroup.Menu;
using NijolGroup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NijolGroup.Mangers.Implementation
{
    internal class ClientManager : IClientManager
    {
        PropertyManager prop = new PropertyManager();
        
        public static List<Client> clientDatabase = new List<Client>();
        public void Delete(string email)
        {
            var client = CheckIfExist(email);
            if (client != null)
            {
                clientDatabase.Remove(client);
                Console.WriteLine("Client deleted successfully");
                
            }
            Console.WriteLine("Client does  not exist");

        }

        public Client Get(int id)
        {
            foreach (var client in clientDatabase)
            {
                if (client.Id == id)
                {
                    return client;
                }
            }
            return null;
        }

        public Client Get(string email)
        {
            foreach (var client in clientDatabase)
            {
                if (client.Email == email)
                {
                    return client;
                }
            }
            return null;
        }

        public List<Client> GetAll()
        {
            return clientDatabase;
        }

        public Client Login(string email, string password)
        {
            foreach (var client in clientDatabase)
            {
                if(email == client.Email && password== client.Password)
                {
                    Console.WriteLine("Login successful"); 
                    return client;
                }
               
            }
          return null;
          
        }

        public Client Register(string name, string email, string password, string phoneNumber)
        {
            var clientexist = CheckIfExist(email);
            if (clientexist == null)
            {
                int id = clientDatabase.Count + 1;
                double wallet = 0;
                Client client = new Client(id, name, email, password, phoneNumber, wallet);
                clientDatabase.Add(client);
                return client;
            }
            return null;
            
        }

        public Client Update(string email, string name, string phoneNumber)
        {
            var client = CheckIfExist(email);
            if(client != null)
            {
                client.Name = name;
                client.PhoneNumber = phoneNumber;
                return client;
            }
            return null;
        }

        public void FundWallet(string email, double amount)
        {
            var client = Get(email);
            if(client != null)
            {
                if (amount > 0)
                {
                    client.Wallet += amount;
                    Console.WriteLine($"Mr/Mrs {client.Name}, you fund {amount} to your wallet and your new balance is {client.Wallet}");
                    
                }
                else
                {
                    Console.WriteLine("amount not valid");
                }

                
                
            }
            
        }

        private Client CheckIfExist(string email)
        {
            foreach (var client in clientDatabase)
            {
                if (client.Email == email)
                {
                    return client;
                }
            }
            return null;
        }


    }
}
