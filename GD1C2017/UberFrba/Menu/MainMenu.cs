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
using UberFrba.Abm_Automovil;
using UberFrba.Dao;
using UberFrba.Abm_Rol;
using UberFrba.Abm_Cliente;
using System.Reflection;

namespace UberFrba.Menu
{
    public partial class MainMenu : Form
    {
        private Usuario user;
        private List<Funcionalidades> functions;

        public MainMenu(Object user)
        {
            InitializeComponent();
            this.user = (Usuario)user;
          
        }

        private void setupFunctions()
        {
            DaoFuncionalidades dao = new DaoFuncionalidades();
            this.functions = dao.getFunctionsByRol(user.getRol());
        }

        private void setupMenu()
        {
            this.IsMdiContainer = true;
            MenuStrip MnuStrip = new MenuStrip();
            this.Controls.Add(MnuStrip);

            createParentIntems(MnuStrip);
            this.MainMenuStrip = MnuStrip;
        }

        private ToolStripMenuItem createSubMenuItems(Funcionalidades f)
        {
            ToolStripMenuItem item = new ToolStripMenuItem(f.getDescription(), null, new EventHandler(ChildClick),f.getFormName());
            return item;
        }

        private ToolStripMenuItem createMenuItems(String name)
        {
            ToolStripMenuItem item = new ToolStripMenuItem(name);
            return item;
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            setupFunctions();
            setupMenu();

        }

        private void createParentIntems(MenuStrip MnuStrip)
        {
            List<Funcionalidades> func = functions.Where(item => item.getParent() == "").ToList();
            foreach (Funcionalidades f in func)
            {
                ToolStripMenuItem parent = createMenuItems(f.getDescription());
                createChildrenItems(f, parent);
                MnuStrip.Items.Add(parent);
            }
        }

        private void createChildrenItems(Funcionalidades f, ToolStripMenuItem parent) {
            List<Funcionalidades> func = functions.Where(item => item.getParent() == f.getDescription()).ToList();
            foreach(Funcionalidades f2 in func){
                parent.DropDownItems.Add(createSubMenuItems(f2));
            }
        }

        private void ChildClick(object sender, EventArgs e)
        {
            ToolStripMenuItem tool = (ToolStripMenuItem)sender;
            Assembly frmAssembly = Assembly.LoadFile(Application.ExecutablePath);
            foreach (Type type in frmAssembly.GetTypes())
            {
                
                if (type.BaseType == typeof(Form))
                {
                    if (type.Name == tool.Name)
                    {
                        Form frmShow = (Form)frmAssembly.CreateInstance(type.ToString());

                        foreach (Form form in this.MdiChildren)
                        {
                            form.Close();
                        }

                        frmShow.MdiParent = this;
                        frmShow.WindowState = FormWindowState.Maximized;
                        //frmShow.ControlBox = false;
                        frmShow.Show();
                    }
                }
            }
        }
    }
}
