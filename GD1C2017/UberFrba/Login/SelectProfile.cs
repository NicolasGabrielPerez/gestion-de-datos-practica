using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.Mapping;
using UberFrba.Dao;
using UberFrba.Menu;

namespace UberFrba.Login
{
    public partial class SelectProfile : Form
    {
        private Usuario user;
        private List<Rol> roles;

        public SelectProfile(Object user)
        {
            this.user = (Usuario)user;
            setupRoles();
            InitializeComponent();
            setupCombobox();

        }


        private void btnContinuar_Click(object sender, EventArgs e)
        {
            Rol r = comboBox1.SelectedItem as Rol;
            user.setRol(r);
            showMainMenu();
        }


        private void setupCombobox()
        {
            this.comboBox1.ValueMember = "id";
            this.comboBox1.DisplayMember = "description";
            this.comboBox1.Sorted = true;
            this.comboBox1.DataSource = roles;
        }

        private void setupRoles()
        {
            DAORoles dao = new DAORoles();
            this.roles = dao.getRolesByUserId(user.getId());
        }

        private void showMainMenu() {
            UberFrba.Menu.MainMenu menu = new UberFrba.Menu.MainMenu(user);
            this.Hide();//reimplementar con un close.
            menu.ShowDialog();
        }

        public void present()
        {
            if (roles.Count > 1)
            {
                base.ShowDialog();
            }
            else
            {
                user.setRol(roles[0]);
                showMainMenu();
            }
        }

        private void SelectProfile_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
