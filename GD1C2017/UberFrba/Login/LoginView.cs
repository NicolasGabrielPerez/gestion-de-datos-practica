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
using UberFrba.Utils;
using UberFrba.Login;

namespace UberFrba
{
    public partial class LoginView : Form
    {
        String username = "";
        String password = "";
        
        public LoginView()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hideErrorMessage();
            username = this.txtUsername.Text;
            password = this.txtPassword.Text;
            try
            {
                validateFields();
                DAOUsers dao = new DAOUsers();
                Usuario usuario = dao.getUser(username.ToString());
                if (!usuario.isBloqued())
                {
                    if (usuario.passwordEquals(SHA256.encriptar(password)))
                    {
                        dao.resetRetries(usuario);
                        hideErrorMessage();
                        showSelectProfile(usuario);
                    }
                    else
                    {
                        dao.incrementRetries(usuario);
                        throw new Exception("Por favor ingrese correctamente la password");
                    }
                }
                else
                {
                    throw new Exception("El usuario esta bloqueado, comuniquese con el administrador");
                }
            }
            catch (Exception ex)
            {
                showErrorMessage(ex.Message.ToString());
            }

        }

        private void validateFields()
        {
            if (txtUsername.Text == string.Empty || txtPassword.Text == string.Empty)
            {
                throw new Exception("El usuario y password son obligatorios");
            }
        }

        private void showErrorMessage(String message)
        {
            lbErrorMessage.ForeColor = Color.Red;
            lbErrorMessage.Text = message;
            lbErrorMessage.Visible = true;
        }

        private void hideErrorMessage()
        {
            lbErrorMessage.Visible = false;
            lbErrorMessage.Text = "";
        }

        private void showSelectProfile(Usuario u)
        {
            SelectProfile profile = new SelectProfile(u);
            this.Hide();
            profile.present();
        }
    }
}
