using App.Layers.Business;
using App.Layers.Service;
using App.Models;
using App.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace App.ViewModel
{
    public class CadastroViewModel : INotifyPropertyChanged
    {

        public CadastroViewModel()
        {
            Perfil = new Models.PerfilModel();

            CadastrarCommandClicked = new Command(() => {
                var mensagem = "Perfil Cadastrado";
                try
                {
                    new PerfilBusiness().CadastroPerfil(Perfil);
                    App.MensagemAlerta(mensagem);
                    Global.EmailPerfil = Perfil.Email;
                    MessagingCenter.Send<CadastroViewModel>(this, "CadastroFeito");
                }
                catch (Exception ex)
                {
                    App.MensagemAlerta("Perfil não cadastrado " + ex.Message);
                }

            });

            
            VoltarClickedCommand = new Command(() => {
                MessagingCenter.Send<CadastroViewModel>(this, "Voltar");
            });
            
        }


        public ICommand CadastrarCommandClicked { get; set; }

        public ICommand VoltarClickedCommand { get; set; }
        public PerfilModel Perfil { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
}
}