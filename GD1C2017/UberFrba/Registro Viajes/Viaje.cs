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
using UberFrba.Mapping;

namespace UberFrba.Registro_Viajes
{
    public partial class Viaje : Form
    {
        private DaoViajes dao;
        private List<ViajeChofer> choferes;
        private List<ViajePersona> clientes;
        private Viajes viaje;

        public Viaje()
        {
            InitializeComponent();
            this.dao = new DaoViajes();
            this.viaje = new Viajes();
            this.choferes = new List<ViajeChofer>();
            this.clientes = new List<ViajePersona>();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            reloadAndGetModel();
            try
            {
                validateDates();
                validatesKM();
                dao.InsertTravelIfNotExited(this.viaje);
                MessageBox.Show("Se ingreso el viaje correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void validateDates()
        {
            if (this.viaje.Inicio >= this.viaje.Fin)
            {
                throw new Exception("Las fechas son invalidas");
            }
        }

        private void validatesKM()
        {
            if (this.viaje.KM <= 0)
            {
                throw new Exception("Ingrese cantidad de kms validos");
            }
        }

        private void Viaje_Load(object sender, EventArgs e)
        {
            setupDates();
            choferes = dao.getAllDrivers();
            clientes = dao.getAllClients();
            setupComboChoferes();
            setupComboClientes();
        }

        private void setupComboChoferes()
        {
            this.comboChofer.ValueMember = "id";
            this.comboChofer.DisplayMember = "prettyName";
            this.comboChofer.Sorted = true;
            this.comboChofer.DataSource = choferes;
        }

        private void setupComboClientes()
        {
            this.comboCliente.ValueMember = "id";
            this.comboCliente.DisplayMember = "prettyName";
            this.comboCliente.Sorted = true;
            this.comboCliente.DataSource = clientes;

        }

        private void comboChofer_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViajeChofer c = this.comboChofer.SelectedItem as ViajeChofer;
            this.txtCNombre.Text = c.getName();
            this.txtCApellido.Text = c.getLastname();
            this.txtCDoc.Text = c.getDoc();
            this.txtCTel.Text = c.getPhone();
            this.txtCMail.Text = c.getEmail();
            this.dtCFecha.Value = c.getDate();
            this.txtPatente.Text = c.Auto.Patente;
            this.txtMarca.Text = c.Auto.Marca;
            this.txtModelo.Text = c.Auto.Modelo;
        }

        private void comboCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViajePersona c = this.comboCliente.SelectedItem as ViajePersona;
            this.txtClNombre.Text = c.getName();
            this.txtClApellido.Text = c.getLastname();
            this.txtClDoc.Text = c.getDoc();
            this.txtClTel.Text = c.getPhone();
            this.txtClMail.Text = c.getEmail();
            this.dtClDate.Value = c.getDate();
        }

        private void dtClDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtkm_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private Viajes reloadAndGetModel()
        {
            this.viaje.Chofer = this.comboChofer.SelectedItem as ViajePersona;
            this.viaje.Cliente = this.comboCliente.SelectedItem as ViajePersona;
            this.viaje.Inicio = this.dtInicio.Value;
            this.viaje.Fin = this.dtFin.Value;
            this.viaje.KM = this.txtkm.Text != "" ? Int32.Parse(this.txtkm.Text) : 0;
            return this.viaje;
        }

        private void setupDates()
        {
            DateTime now = DateTime.Now;
            this.dtInicio.Value = now;
            this.dtFin.Value = now.AddMinutes(10);
        }
    }
}
