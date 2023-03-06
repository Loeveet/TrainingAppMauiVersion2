using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingAppMauiVersion2.Models
{
    internal class TrainingProgram
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Person Person { get; set; }
        public List<ExerciseSet> Exercises { get; set; }
    }
}
