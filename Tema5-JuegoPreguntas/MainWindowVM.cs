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
    class MainWindowVM : ObservableObject
    {
        private Partida partida;
        private ObservableCollection<string> listaCategorias;
        private ObservableCollection<string> listaDificultades;
        private Pregunta preguntaSeleccionada;
        private JsonService serviceJSON;
        private DialogosService dialogService;
        private Pregunta preguntaActual;
        private AzureBlobStorageService azureService;
        public Partida Partida
        {
            get { return partida; }
            set { SetProperty(ref partida, value); }
        }
        public ObservableCollection<string> ListaCategorias
        {
            get { return listaCategorias; }
            set { SetProperty(ref listaCategorias, value); }
        }
        public ObservableCollection<string> ListaDificultades
        {
            get { return listaDificultades; }
            set { SetProperty(ref listaDificultades, value); }
        }
        public Pregunta PreguntaSeleccionada
        {
            get { return preguntaSeleccionada; }
            set { SetProperty(ref preguntaSeleccionada, value); }
        }
        public JsonService ServiceJSON
        {
            get { return serviceJSON; }
            set { SetProperty(ref serviceJSON, value); }
        }
        public DialogosService DialogService
        {
            get { return dialogService; }
            set { SetProperty(ref dialogService, value); }
        }
        public Pregunta PreguntaActual
        {
            get { return preguntaActual; }
            set { SetProperty(ref preguntaActual, value); }
        }
        public AzureBlobStorageService AzureService
        {
            get { return azureService; }
            set { SetProperty(ref azureService, value); }
        }
        public MainWindowVM()
        {
            Partida = new Partida();
            ServiceJSON = new JsonService();
            DialogService = new DialogosService();
            ListaCategorias = new ObservableCollection<string>();
            ListaDificultades = new ObservableCollection<string>();
            
            añadirDificultades();
            añadirCategorias();
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

            foreach (string c in ListaCategorias)
            {
                if (!partida.ListaPreguntas.Any(p => p.Equals(c)))
                {
                    categoriaContienePregunta = false;
                }
            }

            return categoriaContienePregunta;
        }
        public void cargarJSON()
        {
            Partida.ListaPreguntas = ServiceJSON.cargarJSON(DialogService.abrirFichero());
        }
        public void guardarJSON()
        {
            ServiceJSON.guardarJSON(partida, DialogService.guardarFichero());
        }
        public void añadirPregunta(string enunciado, string respuesta, string imagen, string nivelDificultad, string categoria)
        {
            if (string.IsNullOrEmpty(imagen))
            {
                imagen = "assets/question.png";
            }
            else
            {
                imagen = azureService.subirImagen(imagen);
            }
            Partida.ListaPreguntas.Add(new Pregunta(enunciado, respuesta, imagen, nivelDificultad, categoria));
        }
        public void eliminarPregunta()
        {
            Partida.ListaPreguntas.Remove(PreguntaSeleccionada);
        }
        public void validarRespuesta(string respuestaUsuario)
        {
            int i = 1;
            if (respuestaUsuario.Equals(PreguntaActual.Respuesta))
            {
                if (i > Partida.ListaPreguntas.Count)
                {
                    PreguntaActual = Partida.ListaPreguntas[i];
                    i++;
                }
                else
                {
                    DialogService.mostrarMensaje("Has acertado todas las categorías", "Enhorabuena!");
                    Partida.Empezada = false;
                }
            }
            else
            {
                DialogService.mostrarMensaje("Respuesta incorrecta", "Respuesta incorrecta");
            }
        }
        public void nuevaPartida(double dificultad)
        {
            string dificultadElegida = dificultad == 0 ? "Fácil" : "Difícil";
            foreach (string c in ListaCategorias)
            {
                List<Pregunta> preguntasDificultadElegida = Partida.ListaPreguntas.Where(p => p.CategoriaPregunta == c && p.NivelDeDificultad == dificultadElegida).ToList();
                if (preguntasDificultadElegida.Count > 0)
                {
                    Random rnd = new Random();
                    Partida.ListaPreguntas.Add(preguntasDificultadElegida[rnd.Next(0, preguntasDificultadElegida.Count)]);
                }
            }
            if (Partida.ListaPreguntas.Count < 4)
            {
                DialogService.mostrarError("Es necesaria al menos una pregunta por cada categoría para empezar una partida");
            }
            else
            {
                Partida.Empezada = true;
                PreguntaActual = Partida.ListaPreguntas[0];
            }
        }
        public string subirImagen()
        {
           return AzureService.subirImagen(DialogService.abrirFichero());
        }
    }
}
