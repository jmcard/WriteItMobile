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
    public class CapituloViewModel : INotifyPropertyChanged
    {
        public CapituloViewModel()
        {
            Capitulo = Global.CapituloPosicao;

            VoltarCommandClicked = new Command(async () =>
            {
                await Xamarin.Forms.Application.Current.MainPage.Navigation.PopModalAsync();
            });
        }

        public CapituloViewModel(Models.CapituloModel _capitulo)
        {
            Capitulo = _capitulo;
        }

        public CapituloModel Capitulo { get; private set; }

        public ICommand VoltarCommandClicked { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
