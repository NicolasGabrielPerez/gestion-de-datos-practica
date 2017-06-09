using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1;
using UberFrba.Dao;

namespace UberFrba.Abm_Rol
{
    public partial class AbmRol : Form
    {
        private DAORoles dao;

        public AbmRol()
        {
            InitializeComponent();
            this.dao = new DAORoles();
        }

        private void bt_buscar_Click_1(object sender, EventArgs e)
        {

            try
            {
                DataTable roles = dao.buscarRol(this.textBox1.Text);
                this.fill_data_set(roles);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }
        public void fill_data_set(DataTable table)
        {
            this.dataGridView1.DataSource = table;
            this.dataGridView1.Columns[0].Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count == 0)
                MessageBox.Show("Debe seleccionar el rol a seleccionar");
            else
            {
                DataGridViewRow row = this.dataGridView1.SelectedRows[0];
                (new DefinicionRol(row)).Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            (new DefinicionRol()).Show();
        }

        private void button5_Click(object sender, EventArgs e) 
        {
            this.Close();
        }
    }
}