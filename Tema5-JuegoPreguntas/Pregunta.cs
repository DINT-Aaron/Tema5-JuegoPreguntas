using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema5_JuegoPreguntas
{
    class Pregunta:ObservableObject
    {
        private string enunciadoPregunta;
        private string respuesta;
        private string imagen;
        private string nivelDeDificultad;
        private string categoriaPregunta;

        public Pregunta()
        {
        }

        public Pregunta(string enunciadoPregunta, string respuesta, string imagen, string nivelDeDificultad, string categoriaPregunta)
        {
            this.enunciadoPregunta = enunciadoPregunta;
            this.respuesta = respuesta;
            this.imagen = imagen;
            this.nivelDeDificultad = nivelDeDificultad;
            this.categoriaPregunta = categoriaPregunta;
        }

        public string EnunciadoPregunta
        {
            get { return enunciadoPregunta; }
            set { SetProperty(ref enunciadoPregunta, value); }
        }
        public string Respuesta
        {
            get { return respuesta; }
            set { SetProperty(ref respuesta, value); }
        }
        public string Imagen
        {
            get { return imagen; }
            set { SetProperty(ref imagen, value); }
        }
        public string NivelDeDificultad
        {
            get { return nivelDeDificultad; }
            set { SetProperty(ref nivelDeDificultad, value); }
        }
        public string CategoriaPregunta
        {
            get { return categoriaPregunta; }
            set { SetProperty(ref categoriaPregunta, value); }
        }

    }
}
