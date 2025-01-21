using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PersonasApp.Models;
using PersonasApp.Services;
using PersonasApp.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking.Sockets;

namespace PersonasApp.ViewModels
{
    public partial class PersonaViewModel : ObservableObject
    {
        [ObservableProperty]
        private Persona persona;

        [ObservableProperty]
        private string rutaImagen;

        public PersonaViewModel()
        {
            Persona = new Persona();
        }

        [RelayCommand]
        public async void SeleccionarImagen()
        {
            var file = await FileSelector.SelectImageAsync();
            if (file != null)
            {
                RutaImagen = file.FullPath;
            }
        }


        [RelayCommand]
        public void CheckTelefono(object check)
        {
            bool isCheck = (bool)check;
            if (isCheck)
            {
                Persona.Telefono = new Telefono();
            }
            else
            {
                Persona.Telefono = null;
            }
        }

        [RelayCommand]
        public void CheckPasaporte(object check)
        {
            bool isCheck = (bool)check;
            if (isCheck)
            {
                Persona.Pasaporte = new Pasaporte();
            }
            else
            {
                Persona.Pasaporte = null;
            }
        }

        [RelayCommand]
        public async void CrearPersona()
        {
            Debug.WriteLine("VAS A CREAR UNA PERSONA");
            RequestModel request = new RequestModel();
            request.Method = "POST"; //POST GET DELETE UPDATE
            request.Route = "http://localhost:8080/personas/crear";
            request.Data = Persona;
            ResponseModel response = await APIService.ExecuteRequest(request);

            if (response.Success == 0)
            {

            }

            Debug.WriteLine(response.Message);

        }

    }
}
