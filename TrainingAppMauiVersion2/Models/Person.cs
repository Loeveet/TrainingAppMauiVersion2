using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingAppMauiVersion2.Models
{
    internal class Person
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public string Email { get; set; }
        public List<TrainingProgram> Programs { get; set; }
    }
}
