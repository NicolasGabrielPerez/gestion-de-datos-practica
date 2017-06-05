using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.Abm_Cliente;
using UberFrba.Dao;

namespace UberFrba.Abm_Chofer
{
    public partial class Alta_Chofer : Form
    {
        private DAOChofer dao;
        private Persona per;
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
       Alta_Chofer(DataGridViewRow row)
        {
            InitializeComponent();
            this.Text = "Modifique al cliente";
            this.dao = new DAOChofer();
            this.Id = 1;
            this.completarCampos(row);

            Persona personaprevia = new Persona(this.fieldName.Text, this.fieldSurname.Text, this.fieldDocument.Text, this.fieldStreet.Text, this.birthTimePicker.Value, this.clientId);
            this.idPersona = dao.getIdPersona(personaprevia);
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
        private void completarCampos(DataGridViewRow row)
        {
            per.fieldName.Text = row.Cells["Nombre"].Value.ToString();
            this.fieldSurname.Text = row.Cells["Apellido"].Value.ToString();
            this.fieldDocument.Text = row.Cells["DNI"].Value.ToString();
            this.fieldTelephone.Text = row.Cells["Telefono"].Value.ToString();
            this.fieldMail.Text = row.Cells["Email"].Value.ToString();
            this.birthTimePicker.Text = row.Cells["Fecha de Nacimiento"].Value.ToString();
            this.fieldStreet.Text = row.Cells["Direccion"].Value.ToString();
            this.checkHabilitado.Checked = row.Cells["Habilitado"].ToString();
        }
    }
}
