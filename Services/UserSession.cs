using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestingManagerApp.Models;

namespace InvestingManagerApp.Services
{
    public class UserSession
    {   
        public User? CurrentUser { get; private set; }

        public void Login(User user)
        {
            CurrentUser = user;
        }
        public void Logout()
        {
            CurrentUser = null;
        }
        public bool IsAuthenticated => CurrentUser != null;
    }
}
