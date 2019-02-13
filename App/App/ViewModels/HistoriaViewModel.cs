using App.Layers.Business;
using App.Models;
using App.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace App.ViewModels
{
    public class HistoriaViewModel
    {
        public HistoriaViewModel()
        {
            Historia = Global.HistoriaPosicao;

            ListaCapitulo = new CapituloBusiness().ListarCapitulos();

            VoltarCommandClicked = new Command(async () =>
            {
                await Xamarin.Forms.Application.Current.MainPage.Navigation.PopModalAsync();
            });

            CapituloTappedCommand = new Command(async () =>
            {
                Global.CapituloPosicao = capituloSelecionado;
                await Xamarin.Forms.Application.Current.MainPage.Navigation.PushModalAsync(new CapituloPage());
            });
        }

        public HistoriaViewModel(Models.HistoriaModel _historia)
        {
            Historia = _historia;
        }


        private Models.HistoriaModel historia;
        public Models.HistoriaModel Historia
        {
            get
            {
                return historia;
            }
            set
            {
                historia = value;
            }
        }

        private IList<Models.CapituloModel> listaCapitulo;
        public IList<Models.CapituloModel> ListaCapitulo
        {
            get
            {
                return listaCapitulo;
            }
            set
            {
                listaCapitulo = value;
            }
        }

        private Models.CapituloModel capituloSelecionado;
        public Models.CapituloModel CapituloSelecionado
        {
            get
            {
                return capituloSelecionado;
            }
            set
            {
                capituloSelecionado = value;
            }
        }

        private Models.CapituloModel capituloPosicao;

        public Models.CapituloModel CapituloPosicao
        {
            get { return capituloPosicao; }
            set { capituloPosicao = value; }
        }

        public ICommand VoltarCommandClicked { get; set; }

        public ICommand CapituloTappedCommand { get; set; }

    }
}
