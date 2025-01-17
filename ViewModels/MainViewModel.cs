using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using PersonasApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonasApp.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Persona> listaPersonas;

        [RelayCommand]
        public async void Request()
        {

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response =
                        await client.GetAsync("http://localhost:8080/personas/a");
                    response.EnsureSuccessStatusCode();
                    string responseJSON = await response.Content.ReadAsStringAsync();
                    try
                    {
                        ListaPersonas =
                           JsonConvert.DeserializeObject<ObservableCollection<Persona>>(responseJSON);

                    }
                    catch (Exception e)
                    {

                    }

                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Request error: {e.Message}");
                }
            }
        }

    }
}
