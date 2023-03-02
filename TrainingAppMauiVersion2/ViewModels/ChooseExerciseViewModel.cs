using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TrainingAppMauiVersion2.Models;
using TrainingAppMauiVersion2.SessionData;

namespace TrainingAppMauiVersion2.ViewModels
{
    internal partial class ChooseExerciseViewModel : ObservableObject
    {
        [ObservableProperty]
        string name;
        [ObservableProperty]
        string type;
        [ObservableProperty]
        string muscle;
        [ObservableProperty]
        string equipment;
        [ObservableProperty]
        string difficulty;
        [ObservableProperty]
        string instructions;
        [ObservableProperty]
        string chosenMuscle;

        [ObservableProperty]
        ObservableCollection<Exercise> exercises;

        public ChooseExerciseViewModel()
        {
            Exercises = new ObservableCollection<Exercise>();
            ChosenMuscle = SiteVariables.ChosenMuscle;
            GetTheExercises();

        }
        public async void GetTheExercises()
        {
            var exercises = await GetExercices();
            Exercises = exercises;
        }

        public static async Task<ObservableCollection<Exercise>> GetExercices()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api.api-ninjas.com");
            client.DefaultRequestHeaders.Add("X-Api-Key", "4DGnPLCofmkfjBtzIHc4Z55iv07P2Aw6vV57v5SP");
            ObservableCollection<Exercise> exercises = null;
            //TODO: tror jag gör fel här. FNULA!
            HttpResponseMessage response = await client.GetAsync("/v1/exercises?muscle=" + SiteVariables.ChosenMuscle);
            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                exercises = JsonSerializer.Deserialize<ObservableCollection<Exercise>>(responseString);
            }

            return exercises;
        }
    }
}
