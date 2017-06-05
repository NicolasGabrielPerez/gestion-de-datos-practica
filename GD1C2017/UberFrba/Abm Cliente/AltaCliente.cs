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
using System.Globalization;

namespace UberFrba.Abm_Cliente
{
    public partial class AltaCliente : Form
    {
        int clientId = 0;
        int idPersona;
        private DAOClientes dao;
        

        public AltaCliente()
        {
            InitializeComponent();
            this.dao = new DAOClientes();
        }

        public AltaCliente(DataGridViewRow row)
        {
            InitializeComponent();
            this.Text = "Modifique al cliente";
            this.saveButton.Text = "Modificar";
            this.dao = new DAOClientes();
            this.clientId = 1;
            this.completarCampos(row);

            Persona personaprevia = new Persona(this.fieldName.Text, this.fieldSurname.Text, this.fieldDocument.Text, this.fieldStreet.Text, this.birthTimePicker.Value, this.clientId);
            this.idPersona = dao.getIdPersona(personaprevia);
            

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void saveButton_Click(object sender, EventArgs e)
        {
            // al guardar se hara tanto el alta como la modificacion, de acuerdo al clientId

            if (this.clientId != 0)
            {
                updateOrDeleteClient(dao);
            }
            else
            {
                createClient(dao);
           }
        }

        private bool checkDNInot0()
        {
            if (this.fieldDocument.Text.Equals("0"))
            {
                MessageBox.Show("El número de documento no puede ser 0 ni vacio");
                return false;
            }
            else return true;
        }

        private void completarCampos(DataGridViewRow row)
        {
            this.fieldName.Text = row.Cells["Nombre"].Value.ToString();
            this.fieldSurname.Text = row.Cells["Apellido"].Value.ToString();
            this.fieldDocument.Text = row.Cells["DNI"].Value.ToString();
            this.fieldTelephone.Text = row.Cells["Telefono"].Value.ToString();
            this.fieldMail.Text = row.Cells["Email"].Value.ToString();
            this.birthTimePicker.Text = row.Cells["Fecha de Nacimiento"].Value.ToString();
            this.fieldStreet.Text = row.Cells["Direccion"].Value.ToString();
            this.fieldZipcode.Text = row.Cells["Codigo_Postal"].Value.ToString();
            this.checkHabilitado.Checked = (bool)row.Cells["Habilitado"].Value;
        }

        public bool CheckEmptyFields()
        {
            List<TextBox> inputs = new List<TextBox> {this.fieldName, this.fieldSurname, this.fieldDocument, this.fieldMail, 
                this.fieldTelephone, this.fieldZipcode, this.fieldStreet};
            if (inputs.Any((t) => t.Text == ""))
            {
                MessageBox.Show("Complete todos los campos");
                return false;
            }
            else return true;

        }

        private bool createClient(DAOClientes dao)
        {
            bool success = false;
            if (this.CheckEmptyFields())
            {
                if (this.checkDNInot0())
                {
                    
                    Persona persona = new Persona(this.fieldName.Text, this.fieldSurname.Text, this.fieldDocument.Text, this.fieldStreet.Text, this.birthTimePicker.Value, this.idPersona);
                    Cliente cliente = new Cliente(this.fieldTelephone.Text, this.fieldMail.Text, this.fieldZipcode.Text, this.idPersona, this.checkHabilitado.Checked);

                    try
                    {
                        dao.crearPersona(persona);
                        cliente.setIdCliente(dao.getIdPersona(persona));                 
                        dao.crearCliente(cliente);
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

        private void updateOrDeleteClient(DAOClientes dao)
        {
            Persona persona = new Persona(this.fieldName.Text, this.fieldSurname.Text, this.fieldDocument.Text, this.fieldStreet.Text, this.birthTimePicker.Value, this.idPersona);
            Cliente cliente = new Cliente(this.fieldTelephone.Text, this.fieldMail.Text, this.fieldZipcode.Text, this.idPersona , this.checkHabilitado.Checked);

            verifyFields(dao, persona, cliente);
            dao.modificarPersona(persona);
            dao.modificarCliente(cliente);

            MessageBox.Show("Cambios guardados");
        }

        private bool verifyFields(DAOClientes dao, Persona persona, Cliente cliente)
        {
            if (dao.getDNIById(persona) != 0)
            {
                MessageBox.Show("El numero de DNI ya existe para otra persona", "DNI ya existe");
                return false;
            }
            if (dao.getMailById(cliente) != 0)
            {
                MessageBox.Show("La direccion de mail ya existe para otra persona", "Mail ya existe");
                return false;
            }
            return true;
        }
    }
}