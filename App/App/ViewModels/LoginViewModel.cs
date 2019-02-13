using App.Layers.Business;
using App.Layers.Service;
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
    public class LoginViewModel : INotifyPropertyChanged
    {

        public LoginViewModel()
        {
            Login = new Models.LoginModel();
            Perfil = new Models.PerfilModel();

            EntrarClickedCommand = new Command(() => {
                var mensagem = "Login ou Senha inválidos";

                try
                {

                    Perfil = new PerfilBusiness().Login(Login);
                    Global.EmailPerfil = Perfil.Email;

                    MessagingCenter.Send<LoginViewModel>(this, "LoginSucesso");

                }
                catch
                {
                    App.MensagemAlerta(mensagem);
                }

            });

            
            CadastroClickedCommand = new Command(() => {
                MessagingCenter.Send<LoginViewModel>(this, "CadastroPage");
            });

            
        }

        public LoginModel Login { get; private set; }
        public PerfilModel Perfil { get; private set; }

        public ICommand EntrarClickedCommand { get; set; }
        public ICommand CadastroClickedCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
