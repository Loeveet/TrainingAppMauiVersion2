using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingAppMauiVersion2.Models;

namespace TrainingAppMauiVersion2.Singletons
{
    class ChosenParameters
    {
        private string chosenMuscle;
        private string chosenDifficulty;
        private string chosenTypeOfTraining;

        private static readonly ChosenParameters _instance = new ChosenParameters();

        private ChosenParameters()
        {
            chosenMuscle = string.Empty;
            chosenDifficulty = string.Empty;
            chosenTypeOfTraining = string.Empty;
        }

        public static ChosenParameters GetInstansOfChosenParameters()         //Nytt
        {

            return _instance;
        }

        public void SetChosenMuscle(string muscle)
        {
            chosenMuscle = muscle;
        }

        public string GetChosenMuscle()
        {
            return chosenMuscle;
        }
        public void SetChosenDifficulty(string diff)
        {
            chosenDifficulty = diff;
        }

        public string GetChosenDifficulty()
        {
            return chosenDifficulty;
        }
        public void SetChosenTypeOfExercise(string type)
        {
            chosenTypeOfTraining = type;
        }

        public string GetChosenTypeOfExercise()
        {
            return chosenTypeOfTraining;
        }


    }
}
