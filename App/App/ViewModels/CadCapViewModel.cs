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
    public class CadCapViewModel : INotifyPropertyChanged
    {
        public CadCapViewModel()
        {
            string Id = new CapituloBusiness().RetornarId();

            Capitulo = new CapituloModel();

            CadCapCommandClicked = new Command(async () => {
                var mensagem = "Capitulo Cadastrado";
                try
                {
                    new CapituloBusiness().CadastrarCapitulo(Capitulo,Id);
                    await Xamarin.Forms.Application.Current.MainPage.Navigation.PopModalAsync();
                }
                catch(Exception ex)
                {
                    App.MensagemAlerta("Capitulo Não Cadastrado " + ex.Message);
                }
            });

            VoltarClickedCommand = new Command(async () => 
            {
                await Xamarin.Forms.Application.Current.MainPage.Navigation.PopModalAsync();
            });
        }

        public ICommand CadCapCommandClicked { get; set; }
        public ICommand VoltarClickedCommand { get; set; }

        public CapituloModel Capitulo { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
