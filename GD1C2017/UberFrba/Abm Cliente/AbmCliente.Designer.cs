namespace UberFrba.Abm_Cliente
{
    partial class ABMCliente
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.DNI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Direccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo_postal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha_de_nacimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BuscarPor = new System.Windows.Forms.Label();
            this.BTModificar = new System.Windows.Forms.Button();
            this.fieldName = new System.Windows.Forms.TextBox();
            this.bt_buscar = new System.Windows.Forms.Button();
            this.bt_nuevo_cliente = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.fieldDocument = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.fieldSurname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 64);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(798, 293);
            this.dataGridView1.TabIndex = 45;
            // 
            // DNI
            // 
            this.DNI.HeaderText = "DNI";
            this.DNI.Name = "DNI";
            this.DNI.ReadOnly = true;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // Apellido
            // 
            this.Apellido.HeaderText = "Apellido";
            this.Apellido.Name = "Apellido";
            this.Apellido.ReadOnly = true;
            // 
            // Email
            // 
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            // 
            // Telefono
            // 
            this.Telefono.HeaderText = "Telefono";
            this.Telefono.Name = "Telefono";
            this.Telefono.ReadOnly = true;
            // 
            // Direccion
            // 
            this.Direccion.HeaderText = "Direccion";
            this.Direccion.Name = "Direccion";
            this.Direccion.ReadOnly = true;
            // 
            // Codigo_postal
            // 
            this.Codigo_postal.HeaderText = "Codigo postal";
            this.Codigo_postal.Name = "Codigo_postal";
            this.Codigo_postal.ReadOnly = true;
            // 
            // Fecha_de_nacimiento
            // 
            this.Fecha_de_nacimiento.HeaderText = "Fecha de nacimiento";
            this.Fecha_de_nacimiento.Name = "Fecha_de_nacimiento";
            this.Fecha_de_nacimiento.ReadOnly = true;
            // 
            // BuscarPor
            // 
            this.BuscarPor.AutoSize = true;
            this.BuscarPor.Location = new System.Drawing.Point(6, 22);
            this.BuscarPor.Name = "BuscarPor";
            this.BuscarPor.Size = new System.Drawing.Size(47, 13);
            this.BuscarPor.TabIndex = 44;
            this.BuscarPor.Text = "Nombre:";
            // 
            // BTModificar
            // 
            this.BTModificar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BTModificar.Location = new System.Drawing.Point(634, 363);
            this.BTModificar.Name = "BTModificar";
            this.BTModificar.Size = new System.Drawing.Size(85, 27);
            this.BTModificar.TabIndex = 42;
            this.BTModificar.Text = "Modificar";
            this.BTModificar.UseVisualStyleBackColor = true;
            this.BTModificar.Click += new System.EventHandler(this.BTModificar_Click_1);
            // 
            // fieldName
            // 
            this.fieldName.Location = new System.Drawing.Point(56, 19);
            this.fieldName.Name = "fieldName";
            this.fieldName.Size = new System.Drawing.Size(123, 20);
            this.fieldName.TabIndex = 40;
            // 
            // bt_buscar
            // 
            this.bt_buscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_buscar.Location = new System.Drawing.Point(707, 15);
            this.bt_buscar.Name = "bt_buscar";
            this.bt_buscar.Size = new System.Drawing.Size(85, 27);
            this.bt_buscar.TabIndex = 38;
            this.bt_buscar.Text = "Buscar";
            this.bt_buscar.UseVisualStyleBackColor = true;
            this.bt_buscar.Click += new System.EventHandler(this.bt_buscar_Click);
            // 
            // bt_nuevo_cliente
            // 
            this.bt_nuevo_cliente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_nuevo_cliente.Location = new System.Drawing.Point(725, 363);
            this.bt_nuevo_cliente.Name = "bt_nuevo_cliente";
            this.bt_nuevo_cliente.Size = new System.Drawing.Size(85, 27);
            this.bt_nuevo_cliente.TabIndex = 37;
            this.bt_nuevo_cliente.Text = "Nuevo cliente";
            this.bt_nuevo_cliente.UseVisualStyleBackColor = true;
            this.bt_nuevo_cliente.Click += new System.EventHandler(this.bt_nuevo_cliente_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.fieldDocument);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.bt_buscar);
            this.groupBox3.Controls.Add(this.fieldSurname);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.BuscarPor);
            this.groupBox3.Controls.Add(this.fieldName);
            this.groupBox3.Location = new System.Drawing.Point(12, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(798, 52);
            this.groupBox3.TabIndex = 46;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Filtros";
            // 
            // fieldDocument
            // 
            this.fieldDocument.Location = new System.Drawing.Point(396, 19);
            this.fieldDocument.Name = "fieldDocument";
            this.fieldDocument.Size = new System.Drawing.Size(123, 20);
            this.fieldDocument.TabIndex = 49;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(364, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 48;
            this.label1.Text = "DNI:";
            // 
            // fieldSurname
            // 
            this.fieldSurname.Location = new System.Drawing.Point(235, 19);
            this.fieldSurname.Name = "fieldSurname";
            this.fieldSurname.Size = new System.Drawing.Size(123, 20);
            this.fieldSurname.TabIndex = 47;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(185, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 46;
            this.label2.Text = "Apellido:";
            // 
            // ABMCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 421);
            this.ControlBox = false;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.BTModificar);
            this.Controls.Add(this.bt_nuevo_cliente);
            this.Controls.Add(this.groupBox3);
            this.Name = "ABMCliente";
            this.ShowIcon = false;
            this.Text = "ABM de Clientes";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label BuscarPor;
        private System.Windows.Forms.Button BTModificar;
        private System.Windows.Forms.TextBox fieldName;
        private System.Windows.Forms.Button bt_buscar;
        private System.Windows.Forms.Button bt_nuevo_cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn DNI;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn Direccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo_postal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha_de_nacimiento;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox fieldSurname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox fieldDocument;
        private System.Windows.Forms.Label label1;

    }
}