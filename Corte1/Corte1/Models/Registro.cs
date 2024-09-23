using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Corte1.Models
{
    public class Registro
    {
        // Arreglo para almacenar un máximo de 30 personas
        private Persona[] personas = new Persona[30];

        // Contador para llevar registro de cuántas personas han sido añadidas
        private int contador = 0;

        // Método para agregar una persona al arreglo
        public void AgregarPersona(Persona persona)
        {
            // Verifica si hay espacio en el arreglo antes de agregar
            if (contador < 30)
            {
                personas[contador] = persona;  // Añade la persona al arreglo
                contador++;  // Incrementa el contador
            }
            else
            {
                // Muestra un mensaje si el arreglo está lleno
                MessageBox.Show("El registro está lleno.");
            }
        }

        // Método para mostrar todas las personas registradas
        public Persona[] MostrarPersonas()
        {
            // Devuelve un arreglo con las personas no nulas (ya registradas)
            return personas.Where(p => p != null).ToArray();
        }
    }
}
