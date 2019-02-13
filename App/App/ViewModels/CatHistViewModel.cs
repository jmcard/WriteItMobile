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
    public class CatHistViewModel
    {
        public CatHistViewModel()
        {

            Categoria = Global.CategoriaPosicao;
            var idCategoria = Categoria.IdCategoria;

            ListaHistoria = new HistoriasBusiness().ListarHistCategoria(idCategoria);

            HistoriaTappedCommand = new Command(async () =>
            {

                Global.HistoriaPosicao = historiaSelecionada;
                //MessagingCenter.Send<HomePageViewModel>(this, "HistoriaAbrir");
                await Xamarin.Forms.Application.Current.MainPage.Navigation.PushModalAsync(new HistoriaPage());

            });

            VoltarClickedCommand = new Command(async () =>
            {
                await Xamarin.Forms.Application.Current.MainPage.Navigation.PopModalAsync();
            });
        }

        
        public CatHistViewModel(String idCategoria)
        {
            ListaHistoria = new HistoriasBusiness().ListarHistCategoria(idCategoria);
        }
        

        private Models.CategoriaModel categoria;

        public Models.CategoriaModel Categoria
        {
            get { return categoria; }
            set { categoria = value; }
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

        public ICommand HistoriaTappedCommand { get; set; }
        public ICommand VoltarClickedCommand { get; set; }
    }
}
