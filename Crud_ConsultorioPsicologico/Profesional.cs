using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud_ConsultorioPsicologico
{
    internal class Profesional
    {
        public string Nombre {  get; set; }
        public string Matricula { get; set; }

        // Lista para almacenar los bloques horarios de disponibilidad
        public List<string> HorariosDisponibles { get; set; }

        // Constructor
        public Profesional(string nombre, string matricula)
        {
            Nombre = nombre;
            Matricula = matricula;
            HorariosDisponibles = new List<string>(); // Inicializar la lista vacia
        }

        public void AgregarDisponibilidad(string dia, List<string> horarios)
        {
            foreach (var horario in horarios)
            {
                HorariosDisponibles.Add($"{dia} - {horario}");
            }
        }

    }


}
