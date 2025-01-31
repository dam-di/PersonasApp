using CommunityToolkit.Mvvm.Input;
using PersonasApp.Models;
using PersonasApp.Services;
using PersonasApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonasApp.Commands
{
    public class CrearGastoCommand : IRelayCommand
    {
        public event EventHandler? CanExecuteChanged;
        private GestionViewModel vm;

        public CrearGastoCommand(GestionViewModel _vm)
        {
            vm = _vm;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public async void Execute(object? parameter)
        {

            await App.Current.MainPage.DisplayAlert("PersonasApp",
                "Vas a crear un gasto",
                "ACEPTAR");

            vm.SelectedGasto.Persona = new Persona();
            vm.SelectedGasto.Persona.Id = vm.SelectedPersona.Id;
            RequestModel request = new RequestModel()
            {
                Method = "POST",
                Route = "http://localhost:8080/gastos/crear",
                Data = vm.SelectedGasto
            };

            ResponseModel response = await APIService.ExecuteRequest(request);
            if (response.Success.Equals(0))
            {
                await App.Current.MainPage.DisplayAlert("PersonasApp",
                    response.Message,
                    "ACEPTAR");
            }

        }

        public void NotifyCanExecuteChanged()
        {
            throw new NotImplementedException();
        }
    }
}
