using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingAppMauiVersion2.Models;

namespace TrainingAppMauiVersion2.Singletons
{
    internal class ChosenTrainingProgram
    {
        private TrainingProgram chosenTrainingProgram;

        private static readonly ChosenTrainingProgram _instance = new ChosenTrainingProgram();

        private ChosenTrainingProgram()
        {
            chosenTrainingProgram = new TrainingProgram();
        }

        public static ChosenTrainingProgram GetInstansOfChosenTrainingProgram()
        {

            return _instance;
        }

        public void SetChosenTrainingProgram(TrainingProgram tp)
        {
            chosenTrainingProgram = tp;
        }

        public TrainingProgram GetChosenTrainingProgram()
        {
            return chosenTrainingProgram;
        }
    }
}
