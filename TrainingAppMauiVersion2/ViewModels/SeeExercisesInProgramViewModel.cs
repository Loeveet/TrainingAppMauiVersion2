using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingAppMauiVersion2.Models;
using TrainingAppMauiVersion2.Singletons;

namespace TrainingAppMauiVersion2.ViewModels
{
    internal partial class SeeExercisesInProgramViewModel : ObservableObject
    {
        ChosenTrainingProgram chosenTrainingProgram = ChosenTrainingProgram.GetInstansOfChosenTrainingProgram();

        [ObservableProperty]
        TrainingProgram userTrainingProgram;
        public SeeExercisesInProgramViewModel()
        {
            UserTrainingProgram = chosenTrainingProgram.GetChosenTrainingProgram();
        }
    }
}
