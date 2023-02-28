using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace TrainingAppMauiVersion2.Models
{

    internal class Exercise
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("muscle")]
        public string Muscle { get; set; }

        [JsonPropertyName("equipment")]
        public string Equipment { get; set; }

        [JsonPropertyName("difficulty")]
        public string Difficulty { get; set; }

        [JsonPropertyName("instructions")]
        public string Instructions { get; set; }


        public static readonly string[] difficultyLevels = new[]
        {
            "beginner",
            "intermediate",
            "expert"
        };
        public static readonly string[] typesOfExercices = new[]
        {
            "cardio",
            "olympic_weightlifting",
            "plyometrics",
            "powerlifting",
            "strength",
            "stretching",
            "strongman"
        };
        public static readonly string[] muscles = new[]
        {
            "abdominals",
            "abductors",
            "adductors",
            "biceps",
            "calves",
            "chest",
            "forearms",
            "glutes",
            "hamstrings",
            "lats",
            "lower_back",
            "middle_back",
            "neck",
            "quadriceps",
            "traps",
            "triceps"
        };
        public static async Task<List<Exercise>> GetExercices(string uri)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api.api-ninjas.com/");
            client.DefaultRequestHeaders.Add("X-Api-Key", "E2O3R8zknVI8Lo/k0kdq7A==JBFTCWQdZStbgUQq");

            List<Exercise> exercises = null;

            HttpResponseMessage response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                exercises = JsonSerializer.Deserialize<List<Exercise>>(responseString);
            }

            return exercises;
        }
    }
}
