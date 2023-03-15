using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingAppMauiVersion2.Models;

namespace TrainingAppMauiVersion2.Singletons
{
    class ChosenExercise
    {/*
      Jag skriver bara en kommentar här, men jag har, som man kan se, en mapp med olika Singletons. De har gjort min resa
      en aning lättare, då de underlättat för mig med variabler jag vill kunna nå på olika sidor. 
      */
        private Exercise chosenExercise;

        private static readonly ChosenExercise _instance = new ChosenExercise();

        private ChosenExercise()
        {
            chosenExercise = new Exercise();
        }

        public static ChosenExercise GetInstansOfChosenExercise()
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
