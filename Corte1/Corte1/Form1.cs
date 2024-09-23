using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Corte1.Models;

namespace Corte1
{
    public partial class Form1 : Form
    {
        // Instancia de la clase Registro para almacenar las personas
        private Registro registro = new Registro();

        // Instancia de la clase Operacion para realizar cálculos sobre las personas
        private Operacion operacion = new Operacion();

        public Form1()
        {
            InitializeComponent();
            // Añade una lista de ciudades al ComboBox
            cbCity.Items.AddRange(new string[] { "Managua", "Granada", "Masaya" });
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Validación: Verificar que los nombres no estén vacíos
            if (string.IsNullOrWhiteSpace(tbNames.Text))
            {
                MessageBox.Show("Por favor, ingrese un nombre.");
                return;
            }

            // Validación: Verificar que los apellidos no estén vacíos
            if (string.IsNullOrWhiteSpace(tbLastNames.Text))
            {
                MessageBox.Show("Por favor, ingrese un apellido.");
                return;
            }

            // Validación: Verificar que una ciudad haya sido seleccionada
            if (cbCity.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione una ciudad.");
                return;
            }

            // Crea una nueva instancia de Persona con los datos ingresados
            Persona persona = new Persona
            {
                Nombres = tbNames.Text,
                Apellidos = tbLastNames.Text,
                FechaNacimiento = dtpBirthdate.Value,
                Ciudad = cbCity.SelectedItem.ToString()
            };

            // Agrega la persona al registro
            registro.AgregarPersona(persona);

            // Muestra un mensaje de confirmación
            MessageBox.Show("Persona agregada con éxito.");
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            // Obtiene la última persona añadida al registro
            Persona persona = registro.MostrarPersonas().LastOrDefault();

            // Validación: Verificar que haya al menos una persona registrada
            if (persona == null)
            {
                MessageBox.Show("No hay personas registradas.");
                return;
            }

            // Calcula la edad de la persona
            int edad = operacion.CalcularEdad(persona.FechaNacimiento);

            // Determina si es mayor o menor de edad
            bool esMayor = operacion.EsMayorDeEdad(persona.FechaNacimiento);

            // Muestra un mensaje con la edad y si es mayor o menor de edad
            MessageBox.Show($"{persona.Nombres} tiene {edad} años y es {(esMayor ? "mayor" : "menor")} de edad.");
        }
    }
    
}
