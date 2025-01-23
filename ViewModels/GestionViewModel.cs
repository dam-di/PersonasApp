using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PersonasApp.Models;
using PersonasApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonasApp.ViewModels
{
    public partial class GestionViewModel : ObservableObject
    {
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
