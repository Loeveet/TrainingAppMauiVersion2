﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingAppMauiVersion2.SessionData
{
    internal static class SiteVariables
    {
        public static string SearchOtherExercises { get; set; }
        public static Models.Person LoggedInPerson { get; set; } // kanske inte behöver
        public static string ChosenMuscle { get; set; }
    }
}
