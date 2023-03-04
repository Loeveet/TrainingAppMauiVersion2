using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingAppMauiVersion2.Components;

namespace TrainingAppMauiVersion2.Facade
{
    internal class LoginFacade : ILoginFacade
    {
        private readonly IAutheticationService _autheticationService;

        public LoginFacade()
        {
            _autheticationService = new AutheticationService();
        }



        public bool CanLogIn(string userName, string password)
        {
            if (_autheticationService.IsAutheticated(userName, password))
            {
                return true;
            }
            return false;
        }
    }
}
