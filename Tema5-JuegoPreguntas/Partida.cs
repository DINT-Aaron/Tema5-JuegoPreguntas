using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema5_JuegoPreguntas
{
    class Partida : ObservableObject
    {
        private ObservableCollection<Pregunta> listaPreguntas;
        private bool empezada;
        private bool preguntasValidas;

        public ObservableCollection<Pregunta> ListaPreguntas
        {
            get { return listaPreguntas; }
            set { SetProperty(ref listaPreguntas, value); }
        }
        public bool Empezada
        {
            get { return empezada; }
            set { SetProperty(ref empezada, value); }
        }
        public bool PreguntasValidas
        {
            get { return preguntasValidas; }
            set { SetProperty(ref preguntasValidas, value); }
        }
    }
}
