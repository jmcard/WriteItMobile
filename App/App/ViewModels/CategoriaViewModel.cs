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
    public class CategoriaViewModel : INotifyPropertyChanged
    {

        public CategoriaViewModel()
        {
            ListaCategoria = new CategoriaBusiness().ListarCategorias();

            CatTappedCommand = new Command(async () =>
            {

                Global.CategoriaPosicao = categoriaSelecionada;
                //MessagingCenter.Send<HomePageViewModel>(this, "HistoriaAbrir");
                await Xamarin.Forms.Application.Current.MainPage.Navigation.PushModalAsync(new CategoriaHistoriasPage());

            });
        }

        private IList<Models.CategoriaModel> listaCategoria;
        public IList<Models.CategoriaModel> ListaCategoria
        {
            get
            {
                return listaCategoria;
            }
            set
            {
                listaCategoria = value;
                NotifyPropertyChanged();
            }
        }

        private Models.CategoriaModel categoriaSelecionada;

        public Models.CategoriaModel CategoriaSelecionada
        {
            get { return categoriaSelecionada; }
            set { categoriaSelecionada = value; }
        }

        private Models.CategoriaModel categoriaPosicao;

        public Models.CategoriaModel CategoriaPosicao
        {
            get { return categoriaSelecionada; }
            set { categoriaSelecionada = value; }
        }

        public ICommand CatTappedCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
