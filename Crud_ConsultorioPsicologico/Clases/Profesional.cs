using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud_ConsultorioPsicologico.Clases
{
    internal class Profesional
    {
        public string Nombre {  get; set; }
        public string Matricula { get; set; }

       

        // Constructor
        public Profesional(string nombre, string matricula)
        {
            Nombre = nombre;
            Matricula = matricula;
            
        }



    }


}
