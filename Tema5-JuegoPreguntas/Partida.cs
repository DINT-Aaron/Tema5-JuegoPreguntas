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
        public ObservableCollection<Pregunta> ListaPreguntas
        {
            get { return listaPreguntas; }
            set { SetProperty(ref listaPreguntas, value); }
        }
        private bool empezada;
        public bool Empezada
        {
            get { return empezada; }
            set { SetProperty(ref empezada, value); }
        }
        public Partida()
        {
            listaPreguntas = new ObservableCollection<Pregunta>();
        }
        public void añadePregunta(Pregunta pregunta)
        {
            ListaPreguntas.Add(pregunta);
        }
    }
}
