using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace TrainingAppMauiVersion2.Models
{
    internal class Person
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string Name { get; set; }
        public double Weight { get; set; }
        public List<TrainingProgram> Programs { get; set; }

        public static async void UpdateUser(Person user)
        {
            var users = await Connections.Connection.UserCollection();
            await users.ReplaceOneAsync(x => x.Id == user.Id, user);
        }
    }
}
