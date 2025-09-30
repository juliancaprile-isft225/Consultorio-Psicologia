using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud_ConsultorioPsicologico
{
    internal class Paciente
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public int Edad { get; set; }

        public string Motivo { get; set; }



    }
        /*
    // constructor por si quiero mostrar datos del paciente
    public Paciente (string nombre, string apellido, int edad , string motivo)
        {
            Nombre = nombre;
            Apellido = apellido;
            Edad = edad;
            Motivo = motivo;
        }
        */
}
