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
    public class HomePageViewModel
    {
        public HomePageViewModel()
        {
            ListaHistoria = new HistoriasBusiness().ListarHistorias();

            HistoriaTappedCommand = new Command(async () =>
            {

                Global.HistoriaPosicao = historiaSelecionada;
                //MessagingCenter.Send<HomePageViewModel>(this, "HistoriaAbrir");
                await Xamarin.Forms.Application.Current.MainPage.Navigation.PushModalAsync(new HistoriaPage());

            });

        }

        private IList<Models.HistoriaModel> listaHistoria;
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

        private Models.HistoriaModel historiaPosicao;

        public Models.HistoriaModel HistoriaPosicao
        {
            get { return historiaPosicao; }
            set { historiaPosicao = value; }
        }


        public ICommand HistoriaTappedCommand { get; private set; }
    }
}
