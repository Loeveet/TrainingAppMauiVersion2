﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingAppMauiVersion2.Facade
{
    internal interface ILoginFacade
    {
        bool CanLogIn(string userName, string password);
    }
}
