using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using App.Layers.Business;
using App.Models;
using Xamarin.Forms;

namespace App.ViewModels
{
    public class CadHistViewModel : INotifyPropertyChanged
    {
        public CadHistViewModel() 
        {
            string Id = new PerfilBusiness().RetornarId();

            Historia = new Models.HistoriaModel();

            ListaCategoria = new CategoriaBusiness().ListarCategorias();

            CadastrarCommandClicked = new Command(async () => {
                var mensagem = "Historia Cadastrada";
                try
                {
                    new HistoriasBusiness().CadastrarHistoria(Historia, Id);
                    await Xamarin.Forms.Application.Current.MainPage.Navigation.PopModalAsync();
                }
                catch(Exception ex)
                {
                    App.MensagemAlerta("Historia não cadastrada "+ ex.Message);
                }
            });


            VoltarClickedCommand = new Command(async () => {
                await Xamarin.Forms.Application.Current.MainPage.Navigation.PopModalAsync();
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

        private CategoriaModel _categoriaSelecionada;

        public CategoriaModel CategoriaSelecionada
        {
            get { return _categoriaSelecionada; }
            set {
                if(_categoriaSelecionada != value)
                {
                    _categoriaSelecionada = value;
                }
            }
        }


        public HistoriaModel Historia { get; private set; }

        public ICommand CadastrarCommandClicked { get; set; }

        public ICommand VoltarClickedCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
