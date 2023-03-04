using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingAppMauiVersion2.Components
{
    internal interface IAutheticationService
    {
        bool IsAutheticated(string userName, string Password);
    }
}
