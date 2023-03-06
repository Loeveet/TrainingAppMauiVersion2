using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingAppMauiVersion2.Models;

namespace TrainingAppMauiVersion2.Singletons
{
    class NewTrainingProgram
    {
        private List<ExerciseSet> listOfExerciseSet = new();


        private static readonly NewTrainingProgram _instance = new NewTrainingProgram();

        private NewTrainingProgram()
        {

        }

        public static NewTrainingProgram GetInstansOfListOfSets()
        {

            return _instance;
        }

        public void AddSetToList(ExerciseSet exerciseSet)
        {
            listOfExerciseSet.Add(exerciseSet);
        }

        public List<ExerciseSet> GetListOfSets()
        {
            return listOfExerciseSet;
        }
    }
}
