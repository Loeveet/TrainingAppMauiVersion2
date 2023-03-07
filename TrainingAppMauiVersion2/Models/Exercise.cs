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
            "olympic_weightlifting",
            "plyometrics",
            "powerlifting",
            "strength",
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
    }
}
