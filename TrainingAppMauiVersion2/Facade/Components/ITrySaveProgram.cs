﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingAppMauiVersion2.Facade.Components
{
    internal interface ITrySaveProgram
    {
        bool IsSaved(string programName, Models.Person user);
    }
}
