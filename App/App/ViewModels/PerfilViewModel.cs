using App.Layers.Business;
using App.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace App.ViewModels
{
    public class PerfilViewModel : INotifyPropertyChanged
    {
        public PerfilViewModel()
        {

            Perfil = new PerfilBusiness().DadosPerfil();
            SairCommandClicked = new Command(() => {
                MessagingCenter.Send<String>("", "Logoff");
            });

        }

        public PerfilModel Perfil { get; private set; }
        public ICommand SairCommandClicked { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
