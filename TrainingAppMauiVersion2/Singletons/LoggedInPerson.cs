using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingAppMauiVersion2.Models;

namespace TrainingAppMauiVersion2.Singletons
{
    class LoggedInPerson
    {
        private Person loginPerson = new ();


        private static readonly LoggedInPerson _instance = new LoggedInPerson();

        private LoggedInPerson()
        {
            
        }

        public static LoggedInPerson GetInstansOfLoggedInPerson()         //Nytt
        {
            
            return _instance;
        }
        
        public void SetLoggedInPerson(Person person)
        {
            loginPerson = person;
        }

        public Person GetLoggedInPerson()
        {
            return loginPerson;
        }
    }
}
