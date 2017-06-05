using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.Mapping;


namespace UberFrba.Menu
{
    class MenuItemFactory
    {

        public static String createChildrenItem(Funcionalidades f, ToolStripMenuItem parent) {

            switch (f.getId()) { 
            
                case 1:
                    return "choferes";
                case 2:
                    return "clientes";
                default:
                    return "asd";
            }

        }

        private void asdasd() { 
        
        }

    }
}
