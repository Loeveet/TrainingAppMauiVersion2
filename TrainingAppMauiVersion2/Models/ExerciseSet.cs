using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingAppMauiVersion2.Models
{
    internal class ExerciseSet
    {
        public Exercise Exercise { get; set; }
        public int ChoosenWeight { get; set; }
        public int Repetitions { get; set; }
        public double Duration { get; set; }
        public double CaloriesBurned { get; set; } 
    }
}
