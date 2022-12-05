using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema5_JuegoPreguntas
{
    class MainWindowVM:ObservableObject
    {
        private Partida partida;
        public Partida Partida
        {
            get { return partida; }
            set { SetProperty(ref partida, value); }
        }

        private ObservableCollection<string> listaCategorias;
        public ObservableCollection<string> ListaCategorias
        {
            get { return listaCategorias; }
            set { SetProperty(ref listaCategorias, value); }
        }
        private ObservableCollection<string> listaDificultades;
        public ObservableCollection<string> ListaDificultades
        {
            get { return listaDificultades; }
            set { SetProperty(ref listaDificultades, value); }
        }
        private Pregunta preguntaSeleccionada;
        public Pregunta PreguntaSeleccionada
        {
            get { return preguntaSeleccionada; }
            set { SetProperty(ref preguntaSeleccionada, value); }
        }
        public MainWindowVM()
        {
            Partida = new Partida();
            ListaCategorias = new ObservableCollection<string>();
            ListaDificultades = new ObservableCollection<string>();

            añadirDificultades();
            añadirCategorias();

            Partida.ListaPreguntas.Add(new Pregunta("Pregunta 1", "1", "1", "Fácil", "Ciencia"));
            Partida.ListaPreguntas.Add(new Pregunta("Pregunta 2", "2", "2", "Fácil", "Geografía"));
            Partida.ListaPreguntas.Add(new Pregunta("Pregunta 3", "3", "3", "Difícil", "Historia"));
            Partida.ListaPreguntas.Add(new Pregunta("Pregunta 4", "4", "4", "Difícil", "Arte y literatura"));
            
        }
        private void añadirCategorias()
        {
            ListaCategorias.Add("Geografía");
            ListaCategorias.Add("Arte y literatura");
            ListaCategorias.Add("Historia");
            ListaCategorias.Add("Ciencia");
        }

        private void añadirDificultades()
        {
            ListaDificultades.Add("Fácil");
            ListaDificultades.Add("Difícil");
        }

        public bool comprobarCategoriasContienenPregunta()
        {
            bool categoriaContienePregunta = true;

            foreach(string c in ListaCategorias)
            {
                if(!partida.ListaPreguntas.Any(p => p.Equals(c))){
                    categoriaContienePregunta = false;
                }
            }

            return categoriaContienePregunta;
        }
        public void cargarJSON (){
            ObservableCollection<Pregunta> lista=new ObservableCollection<Pregunta>();

            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                string preguntasJson = File.ReadAllText(openFileDialog.FileName);
                lista = JsonConvert.DeserializeObject<ObservableCollection<Pregunta>>(preguntasJson);
            }

            Partida.ListaPreguntas = lista;
        }
        public void guardarJSON()
        {
            ObservableCollection<Pregunta> lista;
            lista = new ObservableCollection<Pregunta>();

            //Exportar a un fichero JSON
            string personasJson = JsonConvert.SerializeObject(lista);
            File.WriteAllText("personas.json", personasJson);
        }
        public void añadirPregunta(string enunciado, string respuesta, string imagen, string nivelDificultad, string categoria)
        {
            Partida.ListaPreguntas.Add(new Pregunta(enunciado, respuesta, imagen, nivelDificultad, categoria));
        }
    }
}
