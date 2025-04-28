using System;// Importa la biblioteca que proporciona tipos básicos como String, Int32 y funciones principales del sistema.
using System.Collections.Generic;// Importa herramientas para trabajar con colecciones genéricas como List<T>.
using System.ComponentModel;// Importa clases que permiten el control de componentes y notificaciones de cambios.
using System.Data;// Importa clases para trabajar con datos y bases de datos (aunque aquí no se usa directamente).
using System.Drawing;// Importa herramientas para trabajar con gráficos, colores y diseño visual.
using System.Linq;// Importa utilidades para consultar colecciones de datos de forma más sencilla.
using System.Text;// Importa herramientas para trabajar con texto y codificación de caracteres.
using System.Threading.Tasks;// Importa funcionalidades para programación asíncrona y paralela.
using System.Windows.Forms;// Importa clases para construir interfaces gráficas en Windows Forms.

namespace PRELAB_DM// Define el espacio de nombres "PRELAB_DM" para agrupar las clases del proyecto y evitar conflictos de nombre.
{
    public partial class Form2 : Form // Declara una clase pública parcial llamada "Form2" que hereda de "Form" (un formulario de Windows Forms).
    {
        
        public class Alumno // Define una clase pública interna llamada "Alumno" que representa la estructura de un estudiante.
        {
            public string Nombre { get; set; } // Propiedad pública "Nombre" para almacenar el nombre del alumno.
            public string Grado { get; set; } // Propiedad pública "Grado" para almacenar el grado escolar del alumno.
            public string Seccion { get; set; } // Propiedad pública "Seccion" para almacenar la sección del alumno.
            public string Telefono { get; set; } // Propiedad pública "Telefono" para almacenar el número de teléfono del alumno.
            public string Matricula { get; set; }  // Propiedad pública "Matricula" para almacenar la matrícula del alumno.
            public string Ciclo { get; set; } // Propiedad pública "Ciclo" para almacenar el ciclo académico.
            public string Direccion { get; set; } // Propiedad pública "Direccion" para almacenar la dirección del alumno.
            public string Correo { get; set; } // Propiedad pública "Correo" para almacenar el correo electrónico del alumno.
            public DateTime FechaNacimiento { get; set; } // Propiedad pública "FechaNacimiento" para almacenar la fecha de nacimiento.
            public string Encargado { get; set; } // Propiedad pública "Encargado" para almacenar el nombre del encargado del alumno.
            public string Genero { get; set; } // Propiedad pública "Genero" para almacenar el género del alumno.
        }
        
        private List<Alumno> listaAlumnos = new List<Alumno>();// Declara una lista privada de tipo Alumno llamada "listaAlumnos" para almacenar todos los registros temporalmente.

        public Form2() // Constructor de la clase Form2.
        {
            InitializeComponent(); // Llama al método para inicializar todos los componentes visuales (botones, textbox, datagridview, etc)
        }

        private void Form2_Load(object sender, EventArgs e)// Método que se ejecuta cuando el formulario Form2 se carga. (Actualmente está vacío)
        {
            // esta no fue necesaria para el código
        }

        private void btnAgregar_Click(object sender, EventArgs e)// Método que se ejecuta cuando se hace clic en el botón "Agregar"
        {
           
            Alumno alumno = new Alumno // Crea un nuevo objeto "Alumno" y lo inicializa con los datos ingresados en los cuadros de texto
            {
                Nombre = txtNombre.Text, // Asigna el valor del TextBox "txtNombre" a la propiedad "Nombre".
                Grado = txtGrado.Text, // Asigna el valor del TextBox "txtGrado" a la propiedad "Grado".
                Seccion = txtSeccion.Text, // Asigna el valor del TextBox "txtSeccion" a la propiedad "Seccion".
                Telefono = txtTelefono.Text, // Asigna el valor del TextBox "txtTelefono" a la propiedad "Telefono".
                Matricula = txtMatricula.Text, // Asigna el valor del TextBox "txtMatricula" a la propiedad "Matricula".
                Ciclo = txtCiclo.Text, // Asigna el valor del TextBox "txtCiclo" a la propiedad "Ciclo".
                Direccion = txtDireccion.Text, // Asigna el valor del TextBox "txtDireccion" a la propiedad "Direccion".
                Correo = txtCorreo.Text, // Asigna el valor del TextBox "txtCorreo" a la propiedad "Correo".
                FechaNacimiento = dtpFechaNacimiento.Value, // Asigna la fecha seleccionada en el DateTimePicker "dtpFechaNacimiento".
                Encargado = txtEncargado.Text, // Asigna el valor del TextBox "txtEncargado" a la propiedad "Encargado".
                Genero = cbGenero.Text // Asigna el texto seleccionado en el ComboBox "cbGenero" a la propiedad "Genero".
            };

            listaAlumnos.Add(alumno); // Agrega el objeto "alumno" recién creado a la lista "listaAlumnos".
            MostrarAlumnos();         // Llama al método para actualizar y mostrar los datos en el DataGridView.
            LimpiarCampos();          // Llama al método para limpiar los campos del formulario después de agregar un alumno.

        }

        private void btnEliminar_Click(object sender, EventArgs e) // Método que se ejecuta cuando se hace clic en el botón "Eliminar"
        {
            int index = dgvAlumnos.CurrentRow.Index; // Obtiene el índice (posición) de la fila seleccionada en el DataGridView.

            if (index >= 0) // Si el índice es válido (mayor o igual a 0)
            {
                listaAlumnos.RemoveAt(index); // Elimina el alumno que está en esa posición de la lista "listaAlumnos".
                MostrarAlumnos();// Refresca y actualiza el DataGridView mostrando la lista actualizada.
            }
        }

        private void MostrarAlumnos()  // Método para mostrar la lista de alumnos en el DataGridView.
        {
            dgvAlumnos.DataSource = null;// Limpia la fuente de datos actual del DataGridView para actualizarlo.
            dgvAlumnos.DataSource = listaAlumnos; // Asigna la lista actualizada de alumnos como nueva fuente de datos del DataGridView
        }

        
        private void LimpiarCampos()// Método para limpiar todos los campos de entrada del formulario.
        {
            txtNombre.Clear();// Borra el contenido del TextBox "txtNombre".
            txtGrado.Clear(); // Borra el contenido del TextBox "txtGrado".
            txtSeccion.Clear();// Borra el contenido del TextBox "txtSeccion".
            txtTelefono.Clear();// Borra el contenido del TextBox "txtTelefono".
            txtMatricula.Clear();// Borra el contenido del TextBox "txtMatricula".
            txtCiclo.Clear();// Borra el contenido del TextBox "txtCiclo".
            txtDireccion.Clear();// Borra el contenido del TextBox "txtDireccion".
            txtCorreo.Clear();// Borra el contenido del TextBox "txtCorreo".
            txtEncargado.Clear();// Borra el contenido del TextBox "txtEncargado".
            cbGenero.SelectedIndex = -1;// Deselecciona cualquier opción en el ComboBox "cbGenero".
            dtpFechaNacimiento.Value = DateTime.Today; // Reinicia el DateTimePicker "dtpFechaNacimiento" a la fecha actual.
        }

        private void btnEditar_Click(object sender, EventArgs e)// Método que se ejecuta cuando se hace clic en el botón "Editar".
        {
            int index = dgvAlumnos.CurrentRow.Index;// Obtiene el índice de la fila seleccionada en el DataGridView.

            if (index >= 0) // Si hay un elemento seleccionado
            {
                Alumno alumno = listaAlumnos[index];// Accede al alumno correspondiente en la lista basado en el índice.
                alumno.Nombre = txtNombre.Text;// Actualiza el nombre del alumno con el contenido del TextBox "txtNombre".
                alumno.Grado = txtGrado.Text;// Actualiza el grado del alumno.
                alumno.Seccion = txtSeccion.Text;// Actualiza la sección del alumno.
                alumno.Telefono = txtTelefono.Text;// Actualiza el teléfono del alumno.
                alumno.Matricula = txtMatricula.Text;// Actualiza la matrícula del alumno.
                alumno.Ciclo = txtCiclo.Text;// Actualiza el ciclo académico del alumno.
                alumno.Direccion = txtDireccion.Text;// Actualiza la dirección del alumno.
                alumno.Correo = txtCorreo.Text; // Actualiza el correo electrónico del alumno.
                alumno.FechaNacimiento = dtpFechaNacimiento.Value;// Actualiza la fecha de nacimiento del alumno.
                alumno.Encargado = txtEncargado.Text;// Actualiza el encargado del alumno.
                alumno.Genero = cbGenero.Text;// Actualiza el género del alumno.

                MostrarAlumnos(); // Refresca el DataGridView para mostrar los cambios.
                LimpiarCampos();  // Limpia los campos de entrada después de editar.
            }
        }
        private void btnLimpiar_Click(object sender, EventArgs e)// Método vacío que se ejecuta al presionar el botón "Limpiar" (no implementado aún).
        {
            // esta no fue necesaria para el código
        }

        private void button1_Click(object sender, EventArgs e)// Método que se ejecuta al presionar el botón "Créditos".
        {
            Form3 cambio1 = new Form3();// Crea una nueva instancia del formulario Form3 llamado "cambio1"
            cambio1.Show();// Muestra el formulario "Form3".
            this.Hide();// Oculta el formulario actual "Form2".
        }
    }
}
