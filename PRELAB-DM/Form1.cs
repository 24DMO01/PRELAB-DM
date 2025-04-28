namespace PRELAB_DM // Define un espacio de nombres llamado PRELAB_DM para organizar las clases y evitar conflictos de nombres en el proyecto.
{
    public partial class Form1 : Form // Declara una clase parcial llamada Form1 que hereda de la clase Form (formulario de Windows Forms).
    {
        public Form1() // Constructor de la clase Form1, que se ejecuta cuando se crea una nueva instancia del formulario.
        {
            InitializeComponent(); // Llama al método InitializeComponent para inicializar y configurar todos los controles visuales del formulario (botones, cajas de texto, etc.).
        }

       
        private void button1_Click(object sender, EventArgs e) // Declara un método privado que maneja el evento de hacer clic en el botón (button1).
        {
           
            string usuario = textBox1.Text;// Crea una variable de tipo string llamada "usuario" y le asigna el texto ingresado en el primer cuadro de texto (textBox1).
            string contraseña = textBox2.Text;// Crea una variable de tipo string llamada "contraseña" y le asigna el texto ingresado en el segundo cuadro de texto (textBox2).

            if (usuario == "estudiante" && contraseña == "2025")// Evalúa si el contenido de "usuario" es "estudiante" y el de "contraseña" es "2025" (validación de acceso).
            {
                
                Form2 ventanaCRUD = new Form2();// Si las credenciales son correctas, crea una nueva instancia del formulario Form2, llamado "ventanaCRUD"
                ventanaCRUD.Show();// Muestra en pantalla el formulario "ventanaCRUD" (Form2) para que el usuario interactúe con él
                this.Hide(); // Oculta el formulario actual (Form1) para que solo se vea el nuevo formulario abierto.

            }
            else // Si las credenciales no coinciden con las esperadas
            {
               
                MessageBox.Show("Usuario o contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);// Muestra un cuadro de mensaje indicando que el usuario o la contraseña son incorrectos, con un icono de error.
            }
        }
    }
}
