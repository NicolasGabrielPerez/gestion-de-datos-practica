using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.Utils;
using UberFrba.Dao;



namespace UberFrba.Abm_Chofer
{
    public partial class ABMChofer : Form
    {
        private String inicialTB = "Ingrese criterio de Busqueda";
        private String inicialCB = "";
        private String condicionWhere;

       
        public ABMChofer()
        {
              InitializeComponent();
              tb_obtener_filtro.Text = inicialTB;
              CBbuscarf.Items.Insert(0, "DNI");
              CBbuscarf.Items.Insert(1, "Apellido");
              CBbuscarf.Items.Insert(2, "Nombre");
              BTeliminar.Visible = false;
              BTModificar.Visible = false;
              
              
        }

        private void button2_Click(object sender, EventArgs e)
            //   esta mierda queda asi
        {
            if ((tb_obtener_filtro.Text == inicialTB) || (CBbuscarf.Text == inicialCB)) 
            { MessageBox.Show("No se puede realizar una busqueda, por favor complete la informacion adecuada"); }
            else
            {
                BTModificar.Visible = true;
                BTeliminar.Visible = true;
                bt_nuevo_chofer.Visible = false;
                CBbuscarf.Visible = false;
                tb_obtener_filtro.Visible = false;
                BuscarPor.Visible = false;
                this.dataGridView1.DataSource = UberFrba.Dao.DAOChofer.buscarChofer(CBbuscarf.Text, tb_obtener_filtro.Text);
                //todo error loco            
            }
           

        }

        private void bt_nuevo_chofer_Click(object sender, EventArgs e)
        {
            Alta_Chofer alta1 = new Alta_Chofer();
            alta1.ShowDialog();
           
        }

        private void bt_Volver_Click(object sender, EventArgs e)
        {
            BTeliminar.Visible = false;
            BTModificar.Visible = false;
            bt_nuevo_chofer.Visible = true;
            CBbuscarf.Visible = true;
            tb_obtener_filtro.Visible = true;
            BuscarPor.Visible = true;
           // aca hay q ver si esta lleno cb
       
 
            
        }

        private void ABMChofer_Load(object sender, EventArgs e)
        {
            

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void tb_obtener_filtro_TextChanged(object sender, EventArgs e)
        {
   
        }

        private void cb_opcion_busqueda_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void BTModificar_Click(object sender, EventArgs e)
        {
            Alta_Chofer mod = new Alta_Chofer();
            mod.ShowDialog();
        }

        private void BTeliminar_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
        // metodos generales

        private void llenarChoferes()
        {

            if (CBbuscarf.Text == "DNI") 
            {
                condicionWhere = "";//buscar por dni 
            }
            if (CBbuscarf.Text == "Apellido") 
            {
                condicionWhere = "";//buscar por
            }
            if (CBbuscarf.Text == "Nombre") 
            {
                condicionWhere = "";//buscar por
            }
            else 
            {
                MessageBox.Show("ERROR no se puede realizar la busqueda"); 
            }
            
        /*var connection = WindowsFormsApplication1.DBConnection.getInstance().getConnection();
        SqlCommand get_Choferes = new SqlCommand("FSOCIETY.sp_get_Choferes", connection);
        get_Choferes.Parameters.Add(new SqlParameter("@NombreTabla",this.condicionWhere));
        get_Choferes.Parameters.Add(new SqlParameter("@itemABuscar", this.tb_obtener_filtro.Text));
        get_Choferes.CommandType = CommandType.StoredProcedure;
        connection.Open();
        SqlDataReader reader = get_Choferes.ExecuteReader();
        */

        }
    }
}
