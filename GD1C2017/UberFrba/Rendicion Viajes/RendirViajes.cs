using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.Dao;

namespace UberFrba.Rendicion_Viajes
{
    public partial class RendirViajes : Form
    {
        private DAOChofer chofer;
        private DaoViajes viaje;
        

        public RendirViajes()
        {
            InitializeComponent();
        }
        public bool CheckEmptyFields()
        {
            List<TextBox> inputs = new List<TextBox> {this.txtCApellido, this.txtCDoc, this.txtCMail, this.txtCNombre, 
                this.txtCTel};
            if (inputs.Any((t) => t.Text == "") || (this.cbturno.Text== ""))
            {
                MessageBox.Show("Complete todos los campos");
                return false;
            }
            else return true;

        }
        private void btRealizarBusqueda_Click(object sender, EventArgs e)
        {
            if (CheckEmptyFields())
            { }

        }
    }
}
