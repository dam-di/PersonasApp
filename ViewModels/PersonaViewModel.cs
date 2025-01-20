using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PersonasApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonasApp.ViewModels
{
    public partial class PersonaViewModel : ObservableObject
    {
        [ObservableProperty]
        private Persona persona;

        public PersonaViewModel()
        {
            Persona = new Persona();
        }

        [RelayCommand]
        public void CrearPersona()
        {
            Debug.WriteLine("VAS A CREAR UNA PERSONA");
        }

    }
}
