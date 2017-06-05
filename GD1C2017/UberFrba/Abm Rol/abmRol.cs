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

namespace UberFrba.Abm_Rol
{
    public partial class AbmRol : Form
    {
        Form parent;
        string userName;

        public AbmRol(Form parent, string userName)
        {
            this.parent = parent;
            this.userName = userName;
            InitializeComponent();
            this.fill_data_set();
        }

        public void fill_data_set()
        {
            /*using (var connection = DBConnection.getInstance().getConnection())
            {
                //ejecuto sp para traer roles modificables
                SqlCommand query = new SqlCommand("FSOCIETY.sp_get_modif_roles", connection);
                query.CommandType = CommandType.StoredProcedure;
                query.Parameters.Add(new SqlParameter("@username", this.userName));

                //adapter
                SqlDataAdapter adapter = new SqlDataAdapter(query);

                //Lleno el dataset y lo seteo como source del dataGridView
                DataTable table = new DataTable();
                adapter.Fill(table);
                this.dataGridView1.DataSource = table;
                this.dataGridView1.ReadOnly = true;
                this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                this.dataGridView1.MultiSelect = false;
                this.dataGridView1.AllowUserToAddRows = false;
                //Oculto pk
                this.dataGridView1.Columns[0].Visible = false;
            }*/
        }

        private void Form1_Load(object sender, EventArgs e) 
        {
        
        }

        private void button3_Click(object sender, EventArgs e) 
        {
            //Modificadion Rol
            if (this.dataGridView1.SelectedRows.Count == 0) 
                MessageBox.Show("Debe seleccionar el rol a seleccionar");
            else (new DefinicionRol(this.dataGridView1.SelectedRows[0], this)).Show();
        }

        private void button1_Click(object sender, EventArgs e) 
        {
            //Alta Rol
            (new DefinicionRol(this)).Show();
        }

        private void button5_Click(object sender, EventArgs e) 
        {
            //Volver
            this.Close();
            this.parent.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
