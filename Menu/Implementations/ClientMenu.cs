using NijolGroup.Mangers.Implementation;
using NijolGroup.Mangers.Interfaces;
using NijolGroup.Menu.Interfaces;
using NijolGroup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace NijolGroup.Menu.Implementations
{
    internal class ClientMenu : IClientMenu
    {
        IClientManager clientManager = new ClientManager();
        IPropertyManager propertyManager = new PropertyManager();
        IPurchaseManager purchaseManager = new PurchaseManager();
       
       
        public void ClientMain()
        {
            Console.WriteLine("Enter 1 to Register\nEnter 2 to View All Property Available\nEnter 3 to Make Purchase\nEnter 4 to Fund Wallet\nEnter 5 to Logout");
            int option = int.Parse(Console.ReadLine());
            if (option == 1)
            {
                Register();
                ClientMain();
            }
            else if (option == 2)
            {
                ViewAllPropertyAvailable();
                ClientMain();
            }
            else if (option == 3)
            {
                MakePurchase();
                ClientMain();
            }
            else if (option == 4)
            {
                FundWalletMenu();
                ClientMain();
            }
            else if (option == 5)
            {
                Console.WriteLine("You have Logout Sucessfully");
                MainMenu menu = new MainMenu();
                menu.Menu();
            }
            else
            {
                Console.WriteLine("Invalid input");
                ClientMain();
            }
        }

        public void ClientMenuClose()
        {
            Console.WriteLine("You have Logout Sucessfully");
            
        }
        
        public void Register()
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            Console.Write("Enter your email address: ");
            string email = Console.ReadLine();
            Console.Write("Input your password: ");
            string password = Console.ReadLine();
            Console.Write("Enter your phone number");
            string phoneNumber = Console.ReadLine();
            clientManager.Register(name, email, password, phoneNumber);
            //ClientMain();
            var client = new MainMenu();
            client.LoginMenu();

        }
        public void MakePurchase()
        {
        
            Console.Write("Enter your Email: ");
            string email = Console.ReadLine();
            Console.Write("Enter the property Registeration Number: ");
            string propertyRegNo = Console.ReadLine();
            var purchase = purchaseManager.Make(email, propertyRegNo);
            if(purchase != null)
            {
                var a = clientManager.Get(email);
                var b = a.Wallet;
                Console.WriteLine($"Purchase successful....Your Account Balance is {b}");
                
            }

        }

        public void ViewAllPropertyAvailable()
        {
            var property = propertyManager.GetAll();

            foreach(var item in property)
            {
                if(item.IsAvailable == true)
                {
                    Console.WriteLine($"Name of property: {item.Name}\tProperty RegNumber: {item.RegNumber}\tPrice of Property: {item.Price}\tAddress of Property{item.Address}");
                }
            }
        }

        public void MakePayment()
        {
            Console.Write("enter the amount you want to pay: ");
            double amount = double.Parse(Console.ReadLine());
            if(amount <= 0) 
            {
                Console.WriteLine("Error!!!!");
            }
            else if(amount > 0)
            {
                
                Console.WriteLine("Payment Successful");
            }
        }

        public void FundWalletMenu()
        {
            Console.Write("Enter your email: ");
            string mail = Console.ReadLine();
            Console.Write("Enter amount to fund: ");
            double amount = double.Parse(Console.ReadLine());
            clientManager.FundWallet(mail, amount);
            
        }
        
    }
}
