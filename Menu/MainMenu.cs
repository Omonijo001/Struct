using NijolGroup.Mangers.Implementation;
using NijolGroup.Mangers.Interfaces;
using NijolGroup.Menu.Implementations;
using NijolGroup.Menu.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NijolGroup.Menu
{
    internal class MainMenu
    {
        IAgentManager agentManager = new AgentManager();
        IClientManager clientManager = new ClientManager();
        IAgentMenu agentMenu = new AgentMenu();
        IClientMenu clientMenu = new ClientMenu();
        public void Menu()
        {
            Console.WriteLine("enter 1 to register\nenter 2 to login");
            int option = int.Parse(Console.ReadLine());
            if (option == 1)
            {
                RegisterClientMenu();
            }
            else if (option == 2)
            {
                LoginMenu();
            }
            else
            {
                Console.WriteLine("wrong input");
                Menu();
            }
        }

        public void RegisterClientMenu()
        {
            Console.WriteLine("enter your name");
            string name = Console.ReadLine();
            Console.WriteLine("enter your email");
            string email = Console.ReadLine();
            Console.WriteLine("enter password");
            string password = Console.ReadLine();
            Console.WriteLine("enter phone number");
            string phoneNumber = Console.ReadLine();
            var client = clientManager.Register(name, email, password, phoneNumber);
            if (client != null)
            {
                Console.WriteLine("registration successful");
            }
            else
            {
                Console.WriteLine("user already exist");
            }
            Menu();

        }

        public void LoginMenu()
        {
            Console.WriteLine("enter your email");
            string email = Console.ReadLine();
            Console.WriteLine("enter your password");
            string password = Console.ReadLine();
            var agentLogin = agentManager.Login(email, password);
            var clientLogin = clientManager.Login(email, password);

            if (agentLogin != null || clientLogin != null)
            {
                if (clientLogin != null)
                {
                    clientMenu.ClientMain();
                }
                else if (agentLogin != null)
                {
                    agentMenu.AgentMain();
                }

            }
            else
            {
                Console.WriteLine("Incorrect Details!!!!!Enter a valid email and password");
                Console.WriteLine("Do you wish to login again?\nEnter 1 for YES and 2 for NO");
                int input = int.Parse(Console.ReadLine());
                if (input == 1)
                {
                    var menu = new MainMenu();
                    menu.LoginMenu();
                }
            }
        }
    }
}