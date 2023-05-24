using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NijolGroup.Menu.Interfaces
{
    internal interface IClientMenu
    {
        public void ClientMain();
        public void Register();
        public void ViewAllPropertyAvailable();
        public void MakePurchase();
        public void MakePayment();
        public void ClientMenuClose();
    }
}
