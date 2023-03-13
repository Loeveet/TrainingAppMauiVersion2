using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingAppMauiVersion2.Singletons
{
    class WrongInput
    {
        private string wrongInputLogInPage;
        private string userNameTaken;
        private string incorrectWeight;

        private static readonly WrongInput _instance = new WrongInput();

        private WrongInput()
        {
            wrongInputLogInPage = string.Empty;
            userNameTaken = string.Empty;
            incorrectWeight = string.Empty;
        }

        public static WrongInput GetInstansOfInputs()
        {

            return _instance;
        }

        public void SetWrongInputLogInPage(bool b)
        {
            if (b == false)
            {
                wrongInputLogInPage = "Wrong username or password";
            }
            else
            {
                wrongInputLogInPage = string.Empty;
            }
        }

        public string GetWrongInputLogInPage()
        {
            return wrongInputLogInPage;
        }





        public void SetUserNameTaken(bool b)
        {
            if (b == false)
            {
                userNameTaken = "Username already taken";
            }
            else
            {

                userNameTaken = string.Empty;
            }
        }

        public string GetUserNameTaken()
        {
            return userNameTaken;
        }
        public void SetIncorrectWeight(bool b)
        {
            if (b == false)
            {
                incorrectWeight = "Use numbers when entering weight";
            }
            else
            {

                incorrectWeight = string.Empty;
            }
        }

        public string GetIncorrectWeight()
        {
            return incorrectWeight;
        }

    }
}
