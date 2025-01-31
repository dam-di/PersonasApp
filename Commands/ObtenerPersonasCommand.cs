using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using PersonasApp.Models;
using PersonasApp.Services;
using PersonasApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonasApp.Commands
{
    public class ObtenerPersonasCommand : IRelayCommand
    {
        public event EventHandler? CanExecuteChanged;
        private GestionViewModel vm;

        public ObtenerPersonasCommand(GestionViewModel _vm)
        {
            vm = _vm;
        }
        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public async void Execute(object? parameter)
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
                    vm.ListaPersonas =
                        JsonConvert.DeserializeObject<ObservableCollection<Persona>>(response.Data.ToString());
                }
                catch (Exception ex) { }
            }
        }

        public void NotifyCanExecuteChanged()
        {
            throw new NotImplementedException();
        }
    }
}
