using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingAppMauiVersion2.Singletons;
using TrainingAppMauiVersion2.ViewModels;

namespace TrainingAppMauiVersion2.Components
{
    internal class AutheticationService : IAutheticationService
    {
        LoggedInPerson loggedInUser = LoggedInPerson.GetInstansOfLoggedInPerson();

        public bool IsAutheticated(string userName, string passWord)
        {
            var users = Connections.Connection.UserCollection();

            foreach (var user in users.AsQueryable().ToList())
            {
                if (user.UserName == userName && user.PassWord == passWord)
                {
                    loggedInUser.SetLoggedInPerson(user);
                   return true;
                }
                    
            }
            return false;
        }
    }
}
