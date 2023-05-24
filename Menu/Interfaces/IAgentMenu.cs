using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NijolGroup.Menu.Interfaces
{
    internal interface IAgentMenu
    {
        public void AgentMain();
        public void CreatePropertyMenu();
        public void ViewAllProperty();
        public void ViewAllClient();
        public void ViewAllPurchase();
        public void AgentMenuClose();
    }
}
