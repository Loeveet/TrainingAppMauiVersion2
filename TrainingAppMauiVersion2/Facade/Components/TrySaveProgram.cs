using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingAppMauiVersion2.Models;
using TrainingAppMauiVersion2.Singletons;
using MongoDB.Driver;
using Amazon.Runtime.Internal.Util;
using TrainingAppMauiVersion2.NewFolder;

namespace TrainingAppMauiVersion2.Facade.Components
{
    internal class TrySaveProgram : ITrySaveProgram
    {
        public bool IsSaved(string programName, Person user)
        {
            try
            {
                NewTrainingProgram newTrainingProgram = NewTrainingProgram.GetInstansOfListOfSets();
                var users = Connections.Connection.UserCollection();

                TrainingProgram trainingProgram = new TrainingProgram()
                {
                    Id = Guid.NewGuid(),
                    Name = programName,
                    Exercises = newTrainingProgram.GetListOfSets()
                };
                user.Programs.Add(trainingProgram);
                Person.UpdateUser(user);

                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
