using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using UberFrba.Dao;

namespace UberFrba.Abm_Cliente
{
    public partial class ABMCliente : Form
    {
        private DAOClientes dao;

        public ABMCliente()
        {
            this.dao = new DAOClientes();
            InitializeComponent();
            setupTableView();
            BTModificar.Visible = false;

        }

        private void bt_nuevo_cliente_Click(object sender, EventArgs e)
        {
            AltaCliente form = new AltaCliente();
            form.ShowDialog();
        }


        private void bt_buscar_Click(object sender, EventArgs e)
        {
            
            try
            {   
                //validateSearchOK();
                
                DataTable clientes = dao.buscarCliente(fieldName.Text, fieldSurname.Text, fieldDocument.Text);
                this.llenarClientes(clientes);
                BTModificar.Visible = true;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
               
        }

        private void llenarClientes(DataTable table)
        {
            this.dataGridView1.DataSource = table;
        }

        public void BTModificar_Click_1(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("seleccione un cliente del listado para modificar");
                return;
            }
            DataGridViewRow row = this.dataGridView1.SelectedRows[0];

            new AltaCliente(row).Show();
        }

        private Boolean validateFields(String textfieldText, String initial){
            return textfieldText == initial && textfieldText == string.Empty;
        }

        private void setupTableView() {
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersVisible = true;
        }
    }
}
