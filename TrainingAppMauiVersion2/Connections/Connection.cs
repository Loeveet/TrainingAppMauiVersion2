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

        public static IMongoCollection<Person> UserCollection()
        {
            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://RobinLiliegren:robin88@cluster0.cst2dyy.mongodb.net/?retryWrites=true&w=majority");
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            var database = client.GetDatabase("TrainingAppPerson");
            var myUsers = database.GetCollection<Person>("MyUsers");
            return myUsers;
        }

        public static IMongoCollection<TrainingProgram> TrainingProgramCollection()
        {
            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://RobinLiliegren:robin88@cluster0.cst2dyy.mongodb.net/?retryWrites=true&w=majority");
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            var database = client.GetDatabase("TrainingAppPerson");
            var myTrainingPrograms = database.GetCollection<TrainingProgram>("MyPrograms");
            return myTrainingPrograms;
        }

    }
}
