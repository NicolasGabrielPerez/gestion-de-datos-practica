using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using UberFrba.Utils;
using UberFrba.Dao;


namespace UberFrba.Abm_Automovil
{
    public partial class Automovil : Form
    {
        private DAOAutomovil dao;

        public Automovil()
        {
            this.dao = new DAOAutomovil();
            InitializeComponent();
            setupGrid();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //this.llenarAutomovil();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void setupGrid() {
            this.dataGridView1.DataSource = dao.getAllCars();
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersVisible = false;
        }
    }
}