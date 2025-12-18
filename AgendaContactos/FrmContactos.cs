using System;
using System.Windows.Forms;
using AgendaContactos.Clases;
using AgendaContactos.Datos;

namespace AgendaContactos
{
    public partial class FrmContactos : Form
    {
        ContactoDAO dao = new ContactoDAO();

        public FrmContactos()
        {
            InitializeComponent();

            // FORZAR EVENTOS DE BOTONES
            btnGuardar.Click += btnGuardar_Click;
            btnBuscar.Click += btnBuscar_Click;
            btnListar.Click += btnListar_Click;

            this.Load += FrmContactos_Load;
        }

        // ===== LOAD DEL FORM =====
        private void FrmContactos_Load(object sender, EventArgs e)
        {
            dgvContactos.DataSource = dao.Listar();
            dgvContactos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvContactos.ReadOnly = true;
            dgvContactos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        // ===== GUARDAR =====
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ENTRÓ AL BOTÓN GUARDAR"); // prueba

            if (txtNombre.Text == "" || txtTelefono.Text == "")
            {
                MessageBox.Show("Nombre y Teléfono son obligatorios");
                return;
            }

            Contacto c = new Contacto
            {
                Nombre = txtNombre.Text,
                Telefono = txtTelefono.Text,
                Direccion = txtDireccion.Text,
                Instagram = txtInstagram.Text,
                Facebook = txtFacebook.Text,
                LinkedIn = txtLinkedIn.Text
            };

            dao.Insertar(c);
            MessageBox.Show("Contacto guardado correctamente");

            Limpiar();
            dgvContactos.DataSource = dao.Listar();
        }

        // ===== LISTAR =====
        private void btnListar_Click(object sender, EventArgs e)
        {
            dgvContactos.DataSource = dao.Listar();
        }

        // ===== BUSCAR =====
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvContactos.DataSource = dao.Buscar(txtBuscar.Text);
        }

        // ===== LIMPIAR TEXTBOX =====
        private void Limpiar()
        {
            txtNombre.Clear();
            txtTelefono.Clear();
            txtDireccion.Clear();
            txtInstagram.Clear();
            txtFacebook.Clear();
            txtLinkedIn.Clear();
            txtBuscar.Clear();
        }
    }
}
