using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using TrainingAppMauiVersion2.Models;

namespace TrainingAppMauiVersion2.Connections
{
    internal static class Connection
    {
        private static MongoClient GetClient()
        {
            string connectionString = @"mongodb + srv://RobinLiliegren:robin88@cluster0.cst2dyy.mongodb.net/?retryWrites=true&w=majority";
            MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(connectionString));
            settings.SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
            var mongoClient = new MongoClient(settings);
            return mongoClient;
        }

        public static IMongoCollection<Models.Person> UserCollection()
        {
            var client = GetClient();
            var database = client.GetDatabase("TrainingAppPerson");
            var myCollection = database.GetCollection<Models.Person>("Person");
            return myCollection;
        }

        public static IMongoCollection<TrainingProgram> TrainingProgramCollection()
        {
            var client = GetClient();
            var database = client.GetDatabase("TrainingAppPerson");
            var myCollection = database.GetCollection<TrainingProgram>("MyPrograms");
            return myCollection;
        }

    }
}
