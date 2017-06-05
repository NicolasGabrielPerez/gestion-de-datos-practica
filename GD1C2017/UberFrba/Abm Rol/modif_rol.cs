using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using WindowsFormsApplication1;
using WindowsFormsApplication1.ABM_Rol;

namespace UberFrba.Abm_Rol
{
    public partial class DefinicionRol : Form
    {
        int idRol;
        AbmRol parent;
        List<Funcionalidad> funcionalidadesAgregadas = new List<Funcionalidad>();
        List<Funcionalidad> funcionalidadesBorradas = new List<Funcionalidad>();

        public DefinicionRol(DataGridViewRow fila, AbmRol parent)
        {
            this.idRol = Int32.Parse(fila.Cells["idRol"].Value.ToString());
            this.parent = parent;
            InitializeComponent();
            this.textBox1.Text = fila.Cells["descripcion"].Value.ToString();
            this.checkBox1.Checked = (bool)fila.Cells["habilitado"].Value;
            this.button1.Click += this.update;
            this.LlenarListaFuncionalidades();
        }

        public DefinicionRol(AbmRol parent)
        {
            this.parent = parent;
            InitializeComponent();
            //this.label1.Text = "Cree un nuevo rol";
            this.button1.Text = "Crear";
            this.button1.Click += this.insert;
            this.LlenarListaFuncionalidades();
        }

        private void update(object sender, EventArgs e)
        {
            /*var connection = DBConnection.getInstance().getConnection();
            SqlCommand update_command = new SqlCommand("FSOCIETY.sp_update_roles", connection);
            update_command.CommandType = CommandType.StoredProcedure;
            update_command.Parameters.Add(new SqlParameter("@idRol", this.idRol));
            update_command.Parameters.Add(new SqlParameter("@descripcion", this.textBox1.Text));
            update_command.Parameters.Add(new SqlParameter("@habilitado", this.checkBox1.Checked));

            connection.Open();
            if (update_command.ExecuteNonQuery() >= 1)
            {
                this.aplicarSpAlistasFuncionalidades(this.funcionalidadesAgregadas, "FSOCIETY.sp_insert_funcionalidad");
                this.aplicarSpAlistasFuncionalidades(this.funcionalidadesBorradas, "FSOCIETY.sp_delete_funcionalidad");
                this.Close();
                MessageBox.Show("Se modificaron los campos correctamente");
                this.parent.fill_data_set();  // Para que refresque el data set
            }
            else
                MessageBox.Show("No se pudo modificar el rol. Intente nuevamente");
            connection.Close();*/
        }

        private void insert(object sender, EventArgs e)
        {
            if (this.textBox1.Text != "")
            {
                /*var connection = DBConnection.getInstance().getConnection();
                SqlCommand insert_command = new SqlCommand("FSOCIETY.sp_insert_rol", connection);
                insert_command.CommandType = CommandType.StoredProcedure;
                insert_command.Parameters.Add(new SqlParameter("@descripcion", this.textBox1.Text));
                insert_command.Parameters.Add(new SqlParameter("@habilitado", this.checkBox1.Checked));

                connection.Open();
                string mensaje;
                try
                {
                    int inserted_pk = Int32.Parse(insert_command.ExecuteScalar().ToString());
                    this.idRol = inserted_pk;
                    this.aplicarSpAlistasFuncionalidades(this.funcionalidadesAgregadas, "FSOCIETY.sp_insert_funcionalidad");
                    this.Close();
                    mensaje = "Rol agregado correctamente";
                    this.parent.fill_data_set();
                }
                catch
                {
                    mensaje = "No se pudo crear el rol. Intente nuevamente";
                }
                connection.Close();
                MessageBox.Show(mensaje);*/
            }
            else MessageBox.Show("Debe proveer un nombre para el rol ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void LlenarListaFuncionalidades()
        {
            /*var connection = DBConnection.getInstance().getConnection();
            List<Funcionalidad> funcionalidadesActuales = new List<Funcionalidad>();
            List<Funcionalidad> funcionalidadesTodas = new List<Funcionalidad>();

            // Pido todas las funcionalidades
            SqlCommand comandoGetFuncionalidades = new SqlCommand("FSOCIETY.sp_get_todas_funcionalidades", connection);
            comandoGetFuncionalidades.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataReader reader = comandoGetFuncionalidades.ExecuteReader();
            while (reader.Read())
                funcionalidadesTodas.Add(new Funcionalidad(Int32.Parse(reader["Id"].ToString()), reader["Descripcion"].ToString()));
            connection.Close();

            // Si es un update, pido las funcionalidades asignadas al rol
            if (this.idRol > 0)
            {
                SqlCommand comandoFuncionalidadesActuales = new SqlCommand("FSOCIETY.sp_get_rol_funcionalidades", connection);
                comandoFuncionalidadesActuales.CommandType = CommandType.StoredProcedure;
                comandoFuncionalidadesActuales.Parameters.Add(new SqlParameter("@idrol", idRol));
                connection.Open();
                SqlDataReader second_reader = comandoFuncionalidadesActuales.ExecuteReader();
                while (second_reader.Read())
                    funcionalidadesActuales.Add(new Funcionalidad(Int32.Parse(second_reader["Id"].ToString()), second_reader["Descripcion"].ToString()));
                connection.Close();
            }

            foreach (Funcionalidad funcionalidad in funcionalidadesTodas)
                this.checkedListBox1.Items.Add(funcionalidad, funcionalidadesActuales.Exists(f => funcionalidad.Equals(f)));*/
        }

        private void aplicarSpAlistasFuncionalidades(List<Funcionalidad> list, string sp)
        {
            /*var connection = DBConnection.getInstance().getConnection();
            SqlCommand command;
            foreach (Funcionalidad funcionalidad in list)
            {
                command = new SqlCommand(sp, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@idrol", this.idRol));
                command.Parameters.Add(new SqlParameter("@idFun", funcionalidad.codigo));

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }*/

        }

        private void CheckedListBox1_ItemCheck(Object sender, ItemCheckEventArgs e)
        {
            Funcionalidad changed_functionality = (Funcionalidad)this.checkedListBox1.Items[e.Index];

            if (e.NewValue == CheckState.Checked)
            {
                // Si antes la había marcado para quitarla, la seteo para agregar
                if (this.funcionalidadesBorradas.Contains(changed_functionality))
                    this.funcionalidadesBorradas.Remove(changed_functionality);
                // Para no agregarla varias veces, checkeando el botón más de una vez
                if (!this.funcionalidadesBorradas.Contains(changed_functionality))
                    this.funcionalidadesBorradas.Add(changed_functionality);
            }
            else
            {
                // Idem anterior, pero para quitar la funcionalidad
                if (this.funcionalidadesBorradas.Contains(changed_functionality))
                    this.funcionalidadesBorradas.Remove(changed_functionality);
                if (!this.funcionalidadesBorradas.Contains(changed_functionality))
                    this.funcionalidadesBorradas.Add(changed_functionality);
            }
        }

        private void InitializeComponent()
        {
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(94, 138);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 18;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(94, 40);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(189, 94);
            this.checkedListBox1.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Funcionalidad";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Habilitado";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(94, 14);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(189, 20);
            this.textBox1.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Nombre rol";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(324, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Guardar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DefinicionRol
            // 
            this.ClientSize = new System.Drawing.Size(413, 170);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Name = "DefinicionRol";
            this.Text = "Definicion de rol";
            this.Load += new System.EventHandler(this.DefinicionRol_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void DefinicionRol_Load(object sender, EventArgs e)
        {
        
        }

        private CheckBox checkBox1;
        private CheckedListBox checkedListBox1;
        private Label label4;
        private Label label3;
        private TextBox textBox1;
        private Label label2;
        private Button button1;

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
