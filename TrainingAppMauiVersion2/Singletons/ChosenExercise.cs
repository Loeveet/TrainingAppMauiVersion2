using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingAppMauiVersion2.Models;

namespace TrainingAppMauiVersion2.Singletons
{
    class ChosenExercise
    {
        private Exercise chosenExercise;

        private static readonly ChosenExercise _instance = new ChosenExercise();

        private ChosenExercise()
        {
            chosenExercise = new Exercise();
        }

        public static ChosenExercise GetInstansOfChosenExercise()         //Nytt
        {

            return _instance;
        }

        public void SetChosenExercise(Exercise exercise)
        {
            chosenExercise = exercise;
        }

        public Exercise GetChosenExercise()
        {
            return chosenExercise;
        }
    }
}
