using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using PersonasApp.Models;
using PersonasApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonasApp.ViewModels
{
    public partial class GestionViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Persona> listaPersonas;

        [ObservableProperty]
        private Persona seletedPersona;

        [RelayCommand]
        public async void ObtenerPersonas()
        {
            RequestModel request = new RequestModel()
            {
                Method = "GET",
                Data = string.Empty,
                Route = "http://localhost:8080/personas/todos"
            };

            ResponseModel response = await APIService.ExecuteRequest(request);
            if (response.Success.Equals(0))
            {
                try
                {
                    ListaPersonas =
                        JsonConvert.DeserializeObject<ObservableCollection<Persona>>(response.Data.ToString());
                }
                catch (Exception ex) { }
            }

        }

        [RelayCommand]
        public async void CrearGasto()
        {
            await App.Current.MainPage.DisplayAlert("PersonasApp",
                "Vas a crear un gasto",
                "ACEPTAR");

            var g = new Gasto()
            {
                Descripcion = "Cerveza 100 latas 500 cl",
                Fecha = DateTime.Now,
                Total = 58,
                Persona = new Persona() { Id = 1 }
            };
            RequestModel request = new RequestModel()
            {
                Method = "POST",
                Route = "http://localhost:8080/gastos/crear",
                Data = g
            };

            ResponseModel response = await APIService.ExecuteRequest(request);
            if (response.Success.Equals(0))
            {
                await App.Current.MainPage.DisplayAlert("PersonasApp",
                    response.Message,
                    "ACEPTAR");
            }

        }
    }
}
