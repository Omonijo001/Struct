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
    internal class PurchaseManager : IPurchaseManager
    {
        public static List<Purchase> purchaseDatabase = new List<Purchase>();
        IClientManager clientManager = new ClientManager();
        IPropertyManager propertyManager = new PropertyManager();
        public void Delete(string referenceNumber)
        {
            var purchase = CheckIfExist(referenceNumber);
            if(purchase == null)
            {
                Console.WriteLine("Purchase Invalid");
            }
            purchaseDatabase.Remove(purchase);
            Console.WriteLine("Delete Sucessfully");
        }

        public Purchase Make(string clientEmail, string propertyRegNo)
        {
            var client = clientManager.Get(clientEmail);
            var property = propertyManager.Get(propertyRegNo);
            if(property != null && property.IsAvailable == true)
            {
                if(client != null)
                {
                    
                    while( client.Wallet < property.Price)
                    {
                        Console.WriteLine($"the price of the property is {property.Price} and your wallet ballance is {client.Wallet}");
                        Console.WriteLine("Proceed to fund your wallet");
                        Console.WriteLine($"enter amount to fund wallet");
                        double amount = double.Parse(Console.ReadLine());
                        if (property.Price < client.Wallet)
                        {
                            Console.WriteLine("Insufficient Balance");
                            Console.WriteLine("Enter 1 to Fund Wallet or Enter 2 to Exit");
                            int option = int.Parse(Console.ReadLine());
                            if(option == 1)
                            {
                                Console.WriteLine($"enter amount to fund wallet");
                                double balance = double.Parse(Console.ReadLine());
                                client.Wallet = client.Wallet + balance;
                                property.IsAvailable = false;
                               // Console.WriteLine($"the price of the property is {property.Price} ad your wallet ballance is {client.Wallet + balance}");
                            }
                            else
                            {
                                Console.WriteLine("You dont have enough fund to compelete the Transaction!!!");
                                var menu = new MainMenu();
                                menu.LoginMenu();
                            }
                            
                        }
                        clientManager.FundWallet(clientEmail, amount);   
                    }

                    string referenceNumber = GenerateRefNumber();
                    client.Wallet -= property.Price;
                    Purchase purchase = new Purchase(purchaseDatabase.Count + 1, clientEmail, propertyRegNo, referenceNumber);
                    purchaseDatabase.Add(purchase);
                    return purchase;

                }
                else
                {
                    Console.WriteLine("customer does not exist on the app");
                    return null;
                }
            }
            else
            {
                Console.WriteLine("property not available");
                return null;
            }

            
        }


        public Purchase Get(int id)
        {
            foreach (var purchase in purchaseDatabase)
            {
                if(purchase.Id == id)
                {
                    return purchase;
                }
            }
            return null;
        }

        public Purchase Get(string referenceNumber)
        {
            foreach (var purchase in purchaseDatabase)
            {
                if(purchase.ReferenceNumber == referenceNumber)
                {
                    return purchase;
                }
            }
            return null;
        }

        public List<Purchase> GetAll()
        {
            return purchaseDatabase;
        }

        private Purchase CheckIfExist(string referenceNumber)
        {
            foreach (var purchase in purchaseDatabase)
            {
                if(purchase.ReferenceNumber == referenceNumber)
                {
                    return purchase;
                }
            }
            return null;   
        }

        private string GenerateRefNumber()
        {
            Random rand = new Random();
            return $"nij/" + rand.Next(1000,9999).ToString();
        }
    }
}
