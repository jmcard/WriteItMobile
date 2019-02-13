using App.Layers.Business;
using App.Models;
using App.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace App.ViewModels
{
    public class HistAutorViewModel
    {
        public HistAutorViewModel()
        {
            string id = new PerfilBusiness().RetornarId();

            ListaHistoria = new HistoriasBusiness().ListarHistoriasAutor(id);

            HistoriaTappedCommand = new Command(async () =>
            {

                Global.HistoriaPosicao = historiaSelecionada;
                //MessagingCenter.Send<HomePageViewModel>(this, "HistoriaAbrir");
                await Xamarin.Forms.Application.Current.MainPage.Navigation.PushModalAsync(new HistoriaAutorPage());

            });

            
            CadHistCommandClicked = new Command(async () =>
            {
                await Xamarin.Forms.Application.Current.MainPage.Navigation.PushModalAsync(new CadastroHistoriaPage());
            });
            
        }

        private IList<Models.HistoriaModel> listaHistoria;

        public PerfilModel Perfil { get; private set; }

        public IList<Models.HistoriaModel> ListaHistoria
        {
            get
            {
                return listaHistoria;
            }
            set
            {
                listaHistoria = value;

            }
        }

        private Models.HistoriaModel historiaSelecionada;
        public Models.HistoriaModel HistoriaSelecionada
        {
            get
            {
                return historiaSelecionada;
            }
            set
            {
                historiaSelecionada = value;
            }
        }

        private Models.HistoriaModel historiaPosicaoAutor;

        public Models.HistoriaModel HistoriaPosicaoAutor
        {
            get { return historiaPosicaoAutor; }
            set { historiaPosicaoAutor = value; }
        }


        public ICommand HistoriaTappedCommand { get; private set; }
        public ICommand CadHistCommandClicked { get; set; }

    }
}
