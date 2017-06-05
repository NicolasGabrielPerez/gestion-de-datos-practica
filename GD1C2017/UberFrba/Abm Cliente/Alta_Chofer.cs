using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.Abm_Chofer
{
    public partial class Alta_Chofer : Form
    {
        public Alta_Chofer()
        {
            InitializeComponent();
            for (int i=0; i < 300 ; i++)
            cb_anio.Items.Insert(i, i + 1900);
            for (int i=0; i < 31 ; i++)
            cb_dia.Items.Insert(i,i+1);
            for (int i = 0; i < 12; i++)
                cb_mes.Items.Insert(i, i + 1);
        
        }

        private void Alta_Chofer_Load(object sender, EventArgs e)
        {

        }

        private void bt_crear_chofer_Click(object sender, EventArgs e)
        {
            if (cb_anio.Text != "" && cb_dia.Text != "" && cb_mes.Text != "" && tb_calle.Text != "" && tb_apellido.Text != "" && tb_DNI.Text != "" && tb_localidad.Text != "" && tb_mail.Text != "" && tb_nombre.Text != "" && tb_nroPiso.Text != "" && tb_telefono.Text != "")
            {
                this.Close();
            }
            else
                MessageBox.Show("Complete todos los datos por favor");
        }

        private void bt_volver_abm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tb_nombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void tb_apellido_TextChanged(object sender, EventArgs e)
        {

        }

        private void tb_mail_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void tb_DNI_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void cb_anio_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
