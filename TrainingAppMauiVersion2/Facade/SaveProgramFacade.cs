using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingAppMauiVersion2.Facade.Components;

namespace TrainingAppMauiVersion2.Facade
{
    internal class SaveProgramFacade : ISaveProgramFacade
    {
        /*
         Här använder jag facade igen, den här gången för att spara det nya träningsprogrammet på den inloggade användaren.
         Jag tyckte att det passade bra med en facade här, för koden blev lite kladdig när allt låg i en metod. 
         */

        private readonly ITrySaveProgram _trySaveProgram;

        public SaveProgramFacade()
        {
            _trySaveProgram = new TrySaveProgram();
        }
        public bool CanSaveProgram(string programName, Models.Person user)
        {
            if (_trySaveProgram.IsSaved(programName, user))
            {
                return true;
            }
            return false;
        }
    }
}
