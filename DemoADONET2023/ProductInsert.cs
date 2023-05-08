using Negocio;
using System;
using System.Data;
using System.Windows.Forms;


namespace DemoADONET2023
{
    public partial class ProductInsert : Form
    {
        BProducto negocio = new BProducto();
        public ProductInsert()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                BProducto negocio = new BProducto();
                negocio.Insertar(new Entidad.Producto
                {
                    Nombre = txtNombre.Text,
                    Precio = Convert.ToDecimal(txtPrecio.Text),
                    Estado = chkActivo.Checked
                });
                MessageBox.Show("Registro exitoso");
            }
            catch (Exception)
            {
                MessageBox.Show("Error");

            }


        }



        private void btnActualizar_Click(object sender, EventArgs e)
        {
            DataRowView selectedRow = (DataRowView)cbId2.SelectedItem;
            int IdProduct = 0;

            try
            {
                BProducto negocio = new BProducto();
                negocio.Actualizar(new Entidad.Producto
                {
                    Nombre = txtNombre.Text,
                    Precio = Convert.ToDecimal(txtPrecio.Text),
                    Estado = chkActivo.Checked
                });
                txtNombre.Text = "";
                txtPrecio.Text = "";
                btnInsertar.Enabled = true;
                btnActualizar.Enabled = false;
                chkActivo.Checked = false;
                MessageBox.Show("Actualizacion exitosa");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);

            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DataRowView selectedRow = (DataRowView)cbId2.SelectedItem;
            int IdProduct = 0;

            try
            {
                BProducto negocio = new BProducto();
                negocio.Eliminar(new Entidad.Producto

                {
                    IdProducto = Convert.ToInt32(selectedRow["IdProducto"]),
                });
                MessageBox.Show("Eliminación exitosa");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);

            }

        }
    }
}

