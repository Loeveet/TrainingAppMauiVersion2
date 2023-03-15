using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingAppMauiVersion2.Facade
{
    internal interface ISaveProgramFacade
    {
        bool SaveProgram(string programName, Models.Person user);
    }
}
