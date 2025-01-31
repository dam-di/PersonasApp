using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Mopups.Services;
using Newtonsoft.Json;
using PersonasApp.Commands;
using PersonasApp.Models;
using PersonasApp.Services;
using PersonasApp.Views.MopupsPanels;
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
        private Persona selectedPersona;

        [ObservableProperty]
        private Gasto selectedGasto;

        [ObservableProperty]
        private bool isActividadesVisible;

        [ObservableProperty]
        private bool isGastosVisible;

        [ObservableProperty]
        private bool isGastoEditable;

        public CrearGastoCommand CrearGastoCommand { get; set; }
        public ObtenerPersonasCommand ObtenerPersonasCommand { get; set; }

        public GestionViewModel()
        {
            CrearGastoCommand = new CrearGastoCommand(this);
            ObtenerPersonasCommand = new ObtenerPersonasCommand(this);
        }

        [RelayCommand]
        public async Task EditarPersona()
        {
            await Shell.Current.GoToAsync("//PersonasPage",
                new Dictionary<string, object>()
                {
                    ["Persona"] = SelectedPersona
                });
        }

        [RelayCommand]
        public async Task AbrirMopup()
        {
            await MopupService.Instance.PushAsync(new PersonaMopup());
        }

        [RelayCommand]
        public void HabilitarEditarGasto()
        {
            IsGastoEditable = true;
        }

        [RelayCommand]
        public void CancelarHabilitarEditarGasto()
        {
            IsGastoEditable = false;
        }


        [RelayCommand]
        public void EstadoInicial()
        {
            IsActividadesVisible = false;
            IsGastosVisible = false;
        }

        [RelayCommand]
        public void MostrarActividades()
        {
            if (SelectedPersona == null)
            {
                App.Current.MainPage.DisplayAlert("Atención",
                    "Debes seleccionar una persona",
                    "ACEPTAR");
                return;
            }

            if (SelectedPersona.Actividades.Count > 0)
            {
                IsActividadesVisible = true;
                IsGastosVisible = false;
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Atención",
                    "La persona seleccionada no tiene actividades",
                    "ACEPTAR");
            }

        }

        [RelayCommand]
        public void MostrarGastos()
        {

            if (SelectedPersona == null)
            {
                App.Current.MainPage.DisplayAlert("Atención",
                    "Debes seleccionar una persona",
                    "ACEPTAR");
                return;
            }

            if (SelectedPersona.Gastos.Count > 0)
            {
                IsActividadesVisible = false;
                IsGastosVisible = true;
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Atención",
                    "La persona seleccionada no tiene gastos",
                    "ACEPTAR");
            }

        }


        [RelayCommand]
        public async Task Animar(object _stack)
        {
            StackLayout stack = (StackLayout)_stack;
            await stack.RotateTo(360, 800);
        }

        [RelayCommand]
        public void ModoCrearGasto()
        {
            SelectedGasto = new Gasto();
            IsGastoEditable = true;
        }
    }
}
