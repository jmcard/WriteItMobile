using App.ViewModel;
using App.ViewModels;
using App.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace App
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Views.LoginPage());

            /*
            if ( ! Logged() ) {
                MainPage.Navigation.PushModalAsync(new LoginPage());
            } else
            {
                MainPage = new NavigationPage(new Views.HomePage());
            }
            */

            //MainPage = new Views.LoginPage();

        }


        private bool Logged()
        {
            return false;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            MessagingCenter.Subscribe<LoginViewModel>(this, "LoginSucesso",
                (sender) =>
                {
                    MainPage = new HomePage();
                });
            
            MessagingCenter.Subscribe<String>("", "Logoff",
                (sender) =>
                {
                    MainPage = new LoginPage();
                });
            
            MessagingCenter.Subscribe<LoginViewModel>(this, "CadastroPage",
                (sender) =>
                {
                    MainPage = new CadastroPage();
                });

            MessagingCenter.Subscribe<CadastroViewModel>(this, "CadastroFeito",
                (sender) => 
                {
                    MainPage = new HomePage();
                });

            MessagingCenter.Subscribe<CadastroViewModel>(this, "Voltar",
                (sender) =>
                {
                    MainPage = new LoginPage();
                });
            MessagingCenter.Subscribe<HomePageViewModel>(this, "HistoriaAbrir",
                (sender) => 
                {
                    MainPage = new HistoriaPage();
                });

        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        internal static void MensagemAlerta(string texto)
        {
            App.Current.MainPage.DisplayAlert("Titulo", texto, "Ok");
        }
    }
}
