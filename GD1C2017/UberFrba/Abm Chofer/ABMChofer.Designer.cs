namespace UberFrba.Abm_Chofer
{
    partial class ABMChofer
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
            this.bt_nuevo_chofer = new System.Windows.Forms.Button();
            this.bt_buscar = new System.Windows.Forms.Button();
            this.bt_Volver = new System.Windows.Forms.Button();
            this.tb_obtener_filtro = new System.Windows.Forms.TextBox();
            this.CBbuscarf = new System.Windows.Forms.ComboBox();
            this.BTModificar = new System.Windows.Forms.Button();
            this.BTeliminar = new System.Windows.Forms.Button();
            this.BuscarPor = new System.Windows.Forms.Label();
            this.Apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DNI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // bt_nuevo_chofer
            // 
            this.bt_nuevo_chofer.Location = new System.Drawing.Point(419, 240);
            this.bt_nuevo_chofer.Name = "bt_nuevo_chofer";
            this.bt_nuevo_chofer.Size = new System.Drawing.Size(85, 27);
            this.bt_nuevo_chofer.TabIndex = 0;
            this.bt_nuevo_chofer.Text = "Nuevo chofer";
            this.bt_nuevo_chofer.UseVisualStyleBackColor = true;
            this.bt_nuevo_chofer.Click += new System.EventHandler(this.bt_nuevo_chofer_Click);
            // 
            // bt_buscar
            // 
            this.bt_buscar.Location = new System.Drawing.Point(319, 240);
            this.bt_buscar.Name = "bt_buscar";
            this.bt_buscar.Size = new System.Drawing.Size(85, 27);
            this.bt_buscar.TabIndex = 1;
            this.bt_buscar.Text = "Buscar";
            this.bt_buscar.UseVisualStyleBackColor = true;
            this.bt_buscar.Click += new System.EventHandler(this.button2_Click);
            // 
            // bt_Volver
            // 
            this.bt_Volver.Location = new System.Drawing.Point(12, 240);
            this.bt_Volver.Name = "bt_Volver";
            this.bt_Volver.Size = new System.Drawing.Size(85, 27);
            this.bt_Volver.TabIndex = 2;
            this.bt_Volver.Text = "Volver";
            this.bt_Volver.UseVisualStyleBackColor = true;
            this.bt_Volver.Click += new System.EventHandler(this.bt_Volver_Click);
            // 
            // tb_obtener_filtro
            // 
            this.tb_obtener_filtro.Location = new System.Drawing.Point(167, 21);
            this.tb_obtener_filtro.Name = "tb_obtener_filtro";
            this.tb_obtener_filtro.Size = new System.Drawing.Size(175, 20);
            this.tb_obtener_filtro.TabIndex = 4;
            this.tb_obtener_filtro.TextChanged += new System.EventHandler(this.tb_obtener_filtro_TextChanged);
            // 
            // CBbuscarf
            // 
            this.CBbuscarf.FormattingEnabled = true;
            this.CBbuscarf.Location = new System.Drawing.Point(72, 21);
            this.CBbuscarf.Name = "CBbuscarf";
            this.CBbuscarf.Size = new System.Drawing.Size(80, 21);
            this.CBbuscarf.TabIndex = 5;
            this.CBbuscarf.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // BTModificar
            // 
            this.BTModificar.Location = new System.Drawing.Point(419, 207);
            this.BTModificar.Name = "BTModificar";
            this.BTModificar.Size = new System.Drawing.Size(85, 27);
            this.BTModificar.TabIndex = 6;
            this.BTModificar.Text = "Modificar";
            this.BTModificar.UseVisualStyleBackColor = true;
            this.BTModificar.Click += new System.EventHandler(this.BTModificar_Click);
            // 
            // BTeliminar
            // 
            this.BTeliminar.Location = new System.Drawing.Point(419, 174);
            this.BTeliminar.Name = "BTeliminar";
            this.BTeliminar.Size = new System.Drawing.Size(85, 27);
            this.BTeliminar.TabIndex = 7;
            this.BTeliminar.Text = "Eliminar";
            this.BTeliminar.UseVisualStyleBackColor = true;
            this.BTeliminar.Click += new System.EventHandler(this.BTeliminar_Click);
            // 
            // BuscarPor
            // 
            this.BuscarPor.AutoSize = true;
            this.BuscarPor.Location = new System.Drawing.Point(9, 25);
            this.BuscarPor.Name = "BuscarPor";
            this.BuscarPor.Size = new System.Drawing.Size(61, 13);
            this.BuscarPor.TabIndex = 8;
            this.BuscarPor.Text = "Buscar por:";
            this.BuscarPor.Click += new System.EventHandler(this.label1_Click);
            // 
            // Apellido
            // 
            this.Apellido.HeaderText = "Apellido";
            this.Apellido.Name = "Apellido";
            this.Apellido.ReadOnly = true;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // DNI
            // 
            this.DNI.HeaderText = "DNI";
            this.DNI.Name = "DNI";
            this.DNI.ReadOnly = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DNI,
            this.Nombre,
            this.Apellido});
            this.dataGridView1.Location = new System.Drawing.Point(12, 62);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dataGridView1.Size = new System.Drawing.Size(343, 139);
            this.dataGridView1.TabIndex = 9;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_1);
            // 
            // ABMChofer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 279);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.BuscarPor);
            this.Controls.Add(this.BTeliminar);
            this.Controls.Add(this.BTModificar);
            this.Controls.Add(this.CBbuscarf);
            this.Controls.Add(this.tb_obtener_filtro);
            this.Controls.Add(this.bt_Volver);
            this.Controls.Add(this.bt_buscar);
            this.Controls.Add(this.bt_nuevo_chofer);
            this.Name = "ABMChofer";
            this.Text = "Gestion de choferes";
            this.Load += new System.EventHandler(this.ABMChofer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_nuevo_chofer;
        private System.Windows.Forms.Button bt_buscar;
        private System.Windows.Forms.Button bt_Volver;
        private System.Windows.Forms.TextBox tb_obtener_filtro;
        private System.Windows.Forms.ComboBox CBbuscarf;
        private System.Windows.Forms.Button BTModificar;
        private System.Windows.Forms.Button BTeliminar;
        private System.Windows.Forms.Label BuscarPor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn DNI;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}