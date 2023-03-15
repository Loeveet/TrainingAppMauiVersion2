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
        /*
         Använder facade för inloggning här under. Tyvärr så är det bara en check i databasen för att se om personen finns,
         men är det så att man bygger vidare appen så är det lätt att lägga till de parameterna som vi gick igenom på 
         lektionen, för att se om personen har behörighet samt har betalat. 
        */
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
