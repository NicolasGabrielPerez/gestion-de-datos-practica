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
using UberFrba.Mapping;

namespace UberFrba.Abm_Chofer
{
    public partial class Alta_Chofer : Form
    {
        private DAOChofer dao;
        private int id;
        private DAOClientes pers;
        public Alta_Chofer()
        {
            InitializeComponent();
            this.dao = new DAOChofer();
            this.pers = new DAOClientes();
            this.id = 1;
        }


       public Alta_Chofer(DataGridViewRow row)
       {
           InitializeComponent();
           this.dao = new DAOChofer();
           this.pers = new DAOClientes();
           this.id = 1;
           this.completarCampos(row);

           Persona personaprevia = new Persona(this.tb_nombre.Text, this.tb_apellido.Text, this.tb_DNI.Text, this.tb_calle.Text, this.birthTimePicker.Value, this.id);
           this.id = pers.getIdPersona(personaprevia);
       }



        private void Alta_Chofer_Load(object sender, EventArgs e)
        {

        }

        private void bt_crear_chofer_Click(object sender, EventArgs e)
        {
            if (tb_calle.Text != "" && tb_apellido.Text != "" && tb_DNI.Text != "" && tb_mail.Text != "" && tb_nombre.Text != "" && tb_telefono.Text != "")
            {
                if (this.id != 0)
                {
                    updateOrDeleteChofer(dao);
                }
                else
                {
                    createChofer(dao);
                }
                this.Close();
            }
            else
                MessageBox.Show("Complete todos los datos por favor");
        }

        private bool createChofer(DAOChofer dao)
        {
            bool success = false;
            if (this.CheckEmptyFields())
            {
                if (this.checkDNInot0())
                {

                    Persona persona = new Persona(this.tb_nombre.Text, this.tb_apellido.Text, this.tb_DNI.Text, this.tb_calle.Text, this.birthTimePicker.Value, this.id);
                    Chofer chofer = new Chofer(this.id, this.tb_telefono.Text, this.tb_mail.Text, this.cbHabilitado.Checked);

                    try
                    {
                        pers.crearPersona(persona);
                        chofer.setIdChofer(pers.getIdPersona(persona));
                        dao.crearChofer(chofer);
                        success = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }

                    MessageBox.Show("El cliente fue creado exitosamente");
                    this.Close();
                }
            }
            return success;
        }


        private bool verifyFields(DAOClientes pers ,DAOChofer dao, Persona persona, Chofer chofer)
        {
            if (pers.getDNIById(persona) != 0)
            {
                MessageBox.Show("El numero de DNI ya existe para otra persona", "DNI ya existe");
                return false;
            }
            if (dao.getMailById(chofer) != 0)
            {
                MessageBox.Show("La direccion de mail ya existe para otra persona", "Mail ya existe");
                return false;
            }
            return true;
        }


        private void updateOrDeleteChofer(DAOChofer dao)
        {
            Persona persona = new Persona(this.tb_nombre.Text, this.tb_apellido.Text, this.tb_DNI.Text, this.tb_calle.Text, this.birthTimePicker.Value, this.id);
            Chofer chofer = new Chofer(this.id, this.tb_telefono.Text, this.tb_mail.Text, this.cbHabilitado.Checked);

            verifyFields(pers,dao, persona, chofer);
            pers.modificarPersona(persona);
            dao.modificarChofer(chofer);

            MessageBox.Show("Cambios guardados");
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
            this.tb_nombre.Text = row.Cells["Nombre"].Value.ToString();
            this.tb_apellido.Text = row.Cells["Apellido"].Value.ToString();
            this.tb_DNI.Text = row.Cells["DNI"].Value.ToString();
            this.tb_telefono.Text = row.Cells["Telefono"].Value.ToString();
            this.tb_mail.Text = row.Cells["Email"].Value.ToString();
            this.birthTimePicker.Text = row.Cells["Fecha de Nacimiento"].Value.ToString();
            this.tb_calle.Text = row.Cells["Direccion"].Value.ToString();
            this.cbHabilitado.Checked = (bool)row.Cells["Habilitado"].Value;
        }


        public bool CheckEmptyFields()
        {
            List<TextBox> inputs = new List<TextBox> {this.tb_nombre, this.tb_apellido, this.tb_DNI, this.tb_mail, 
                this.tb_telefono, this.tb_calle};
            if (inputs.Any((t) => t.Text == ""))
            {
                MessageBox.Show("Complete todos los campos");
                return false;
            }
            else return true;

        }

        private bool checkDNInot0()
        {
            if (this.tb_DNI.Text.Equals("0"))
            {
                MessageBox.Show("El número de documento no puede ser 0 ni vacio");
                return false;
            }
            else return true;
        }


        private void birthTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cbHabilitado_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
