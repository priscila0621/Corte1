using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corte1.Models
{
    public class Operacion
    {
        // Método para calcular la edad de una persona dado su fecha de nacimiento
        public int CalcularEdad(DateTime fechaNacimiento)
        {
            // Calcula la edad actual basada en el año actual y el año de nacimiento
            int edad = DateTime.Now.Year - fechaNacimiento.Year;

            // Si la persona no ha cumplido aún este año, resta 1 a la edad
            if (DateTime.Now.DayOfYear < fechaNacimiento.DayOfYear)
            {
                edad--;
            }

            return edad;  // Devuelve la edad calculada
        }

        // Método para verificar si la persona es mayor de edad (18 años o más)
        public bool EsMayorDeEdad(DateTime fechaNacimiento)
        {
            // Retorna true si la persona tiene 18 años o más, de lo contrario false
            return CalcularEdad(fechaNacimiento) >= 18;
        }
    }
}
