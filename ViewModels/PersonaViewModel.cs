using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Mopups.Services;
using PersonasApp.Models;
using PersonasApp.Services;
using PersonasApp.Utils;
using PersonasApp.Views.MopupsPanels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking.Sockets;

namespace PersonasApp.ViewModels
{
    [QueryProperty(nameof(Persona), "Persona")]
    public partial class PersonaViewModel : ObservableObject
    {
        [ObservableProperty]
        private Persona persona;

        [ObservableProperty]
        private bool tieneTelefono;

        [ObservableProperty]
        private bool tienePasaporte;


        [ObservableProperty]
        private string rutaImagen;

        public PersonaViewModel()
        {
            Persona = new Persona();
            RutaImagen = "http://localhost:8081/dropbox/download/imagen_bonita.png";
            //RutaImagen = "https://i.pinimg.com/originals/d9/f2/15/d9f21515b1e38d83e94fdbce88f623b6.gif";
        }

        // Establece los valores iniciales para editar o crear una persona
        [RelayCommand]
        public void EstablecerValoresIniciales()
        {
            if (Persona.Id != null) //Quiere decir que estamos editando
            {
                RutaImagen = Persona.AvatarUrl;
                TienePasaporte = Persona.Pasaporte != null;
                TieneTelefono = Persona.Telefono != null;
            }
        }


        [RelayCommand]
        public async void SeleccionarImagen()
        {
            var file = await FileSelector.SelectImageAsync();
            if (file != null)
            {
                RutaImagen = file.FullPath;
                Persona.AvatarUrl = file.FullPath;
            }
        }

        [RelayCommand]
        public async Task<bool> UploadImage(string idPersona)
        {
            try
            {
                string _rutaImagen = RutaImagen;
                RutaImagen = "loading.gif";
                await UploadImageService.UploadImageAsync(_rutaImagen, idPersona,
                    "http://localhost:8081/dropbox/upload");
                await App.Current.MainPage.DisplayAlert("ÉXITO",
                    "Subiendo imagen...",
                    "ACEPTAR");
                RutaImagen = _rutaImagen;
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al subir imagen");
                await App.Current.MainPage.DisplayAlert("ERROR",
                    "No se pudo subir la imagen",
                    "ACEPTAR");
                return false;
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
            Persona.AvatarUrl = Path.GetExtension(RutaImagen);
            // avatarurl = "http://localhost:8081/dropbox/download/50.png"
            request.Data = Persona;
            ResponseModel response = await APIService.ExecuteRequest(request);

            if (response.Success == 0)
            {
                var idPersona = response.Data;
                var okCrear = await UploadImage(idPersona.ToString());

            }

            Debug.WriteLine(response.Message);

        }

    }
}
