using NijolGroup.Enums;
using NijolGroup.Mangers.Implementation;
using NijolGroup.Mangers.Interfaces;
using NijolGroup.Menu.Interfaces;
using NijolGroup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace NijolGroup.Menu.Implementations
{
    internal class AgentMenu : IAgentMenu
    {
        IAgentManager agentManager = new AgentManager();
        IPropertyManager propertyManager = new PropertyManager();
        IClientManager clientManager = new ClientManager();
        IPurchaseManager purchaseManager = new PurchaseManager();
       
        public void AgentMain()
        {
            Console.WriteLine("Enter 1 to Create Property\nEnter 2 to View All Client\nEnter 3 to View All Property\nEnter 4 to View All Purcahse\nEnter 5 to Logout ");
            int option = int.Parse(Console.ReadLine());
            if (option == 1)
            {
                CreatePropertyMenu();
                AgentMain();
            }
            else if (option == 2)
            {
                ViewAllClient();
                AgentMain();
            }
            else if (option == 3)
            {
                ViewAllProperty();
                AgentMain();
            }
            else if (option == 4)
            {
                ViewAllPurchase();
                AgentMain();
            }
            else if (option == 5)
            {
                Console.WriteLine("You have logout sucessfully ");
                MainMenu menu = new MainMenu();
                menu.Menu();
            }
            else
            {
                Console.WriteLine("Invalid input");
                AgentMain();
            }
        }

        public void AgentMenuClose()
        {
                Console.WriteLine("You have sucessfully logout");
                AgentMain();
        }

        public void CreatePropertyMenu()
        {
            Console.Write("Enter the name of the Property: ");
            string name = Console.ReadLine();
            Console.Write("Enter the Property registeration number: ");
            string regNumber = Console.ReadLine();
            Console.Write("Enter 1 for Land\tEnter 2 for Building:  ");
            //int Type = int.Parse(Console.ReadLine());
            PropertyType type = (PropertyType) Enum.Parse(typeof(PropertyType), Console.ReadLine());
            Console.Write("Enter the price of the Property: ");
            double price = double.Parse(Console.ReadLine());
            Console.Write("Enter the Address of the Property: ");
            string address = Console.ReadLine();
            Console.WriteLine("Property Created Sucesfully");
            propertyManager.Create(name, regNumber, type, price, address);
            
          
        }

        public void ViewAllClient()
        {
            var clients = clientManager.GetAll();
            foreach (var client in clients) 
            {
                Console.WriteLine($"Client name is {client.Name}\tContact: {client.PhoneNumber}");
            }
            
        }

        public void ViewAllProperty()
        {
            var properties = propertyManager.GetAll();
            foreach (var property in properties)
            {
                
                Console.WriteLine($"{property.RegNumber}\t{property.Type}\t{property.Price}\t{property.Address}\t{property.Owner}\t{property.IsAvailable}");
            }
        }

        public void ViewAllPurchase()
        {
            var purchase = purchaseManager.GetAll();
            foreach (var item in purchase)
            {
                Console.WriteLine($"{item.ClientEmail}\t{item.ReferenceNumber}");
            }
        }
       
    }
}
