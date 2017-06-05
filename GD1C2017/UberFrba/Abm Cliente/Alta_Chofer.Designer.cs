namespace UberFrba.Abm_Chofer
{
    partial class Alta_Chofer
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
            this.bt_crear_chofer = new System.Windows.Forms.Button();
            this.bt_volver_abm = new System.Windows.Forms.Button();
            this.tb_nombre = new System.Windows.Forms.TextBox();
            this.tb_apellido = new System.Windows.Forms.TextBox();
            this.tb_DNI = new System.Windows.Forms.TextBox();
            this.tb_mail = new System.Windows.Forms.TextBox();
            this.tb_telefono = new System.Windows.Forms.TextBox();
            this.tb_calle = new System.Windows.Forms.TextBox();
            this.tb_nroPiso = new System.Windows.Forms.TextBox();
            this.tb_localidad = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cb_dia = new System.Windows.Forms.ComboBox();
            this.cb_mes = new System.Windows.Forms.ComboBox();
            this.cb_anio = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bt_crear_chofer
            // 
            this.bt_crear_chofer.Location = new System.Drawing.Point(627, 338);
            this.bt_crear_chofer.Name = "bt_crear_chofer";
            this.bt_crear_chofer.Size = new System.Drawing.Size(85, 27);
            this.bt_crear_chofer.TabIndex = 1;
            this.bt_crear_chofer.Text = "Crear";
            this.bt_crear_chofer.UseVisualStyleBackColor = true;
            this.bt_crear_chofer.Click += new System.EventHandler(this.bt_crear_chofer_Click);
            // 
            // bt_volver_abm
            // 
            this.bt_volver_abm.Location = new System.Drawing.Point(12, 338);
            this.bt_volver_abm.Name = "bt_volver_abm";
            this.bt_volver_abm.Size = new System.Drawing.Size(85, 27);
            this.bt_volver_abm.TabIndex = 2;
            this.bt_volver_abm.Text = "Cancelar";
            this.bt_volver_abm.UseVisualStyleBackColor = true;
            this.bt_volver_abm.Click += new System.EventHandler(this.bt_volver_abm_Click);
            // 
            // tb_nombre
            // 
            this.tb_nombre.Location = new System.Drawing.Point(39, 32);
            this.tb_nombre.Name = "tb_nombre";
            this.tb_nombre.Size = new System.Drawing.Size(113, 20);
            this.tb_nombre.TabIndex = 3;
            this.tb_nombre.TextChanged += new System.EventHandler(this.tb_nombre_TextChanged);
            // 
            // tb_apellido
            // 
            this.tb_apellido.Location = new System.Drawing.Point(158, 32);
            this.tb_apellido.Name = "tb_apellido";
            this.tb_apellido.Size = new System.Drawing.Size(113, 20);
            this.tb_apellido.TabIndex = 4;
            this.tb_apellido.TextChanged += new System.EventHandler(this.tb_apellido_TextChanged);
            // 
            // tb_DNI
            // 
            this.tb_DNI.Location = new System.Drawing.Point(39, 84);
            this.tb_DNI.Name = "tb_DNI";
            this.tb_DNI.Size = new System.Drawing.Size(113, 20);
            this.tb_DNI.TabIndex = 5;
            this.tb_DNI.TextChanged += new System.EventHandler(this.tb_DNI_TextChanged);
            // 
            // tb_mail
            // 
            this.tb_mail.Location = new System.Drawing.Point(338, 32);
            this.tb_mail.Name = "tb_mail";
            this.tb_mail.Size = new System.Drawing.Size(191, 20);
            this.tb_mail.TabIndex = 6;
            this.tb_mail.TextChanged += new System.EventHandler(this.tb_mail_TextChanged);
            // 
            // tb_telefono
            // 
            this.tb_telefono.Location = new System.Drawing.Point(566, 32);
            this.tb_telefono.Name = "tb_telefono";
            this.tb_telefono.Size = new System.Drawing.Size(113, 20);
            this.tb_telefono.TabIndex = 7;
            this.tb_telefono.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // tb_calle
            // 
            this.tb_calle.Location = new System.Drawing.Point(39, 194);
            this.tb_calle.Name = "tb_calle";
            this.tb_calle.Size = new System.Drawing.Size(113, 20);
            this.tb_calle.TabIndex = 9;
            // 
            // tb_nroPiso
            // 
            this.tb_nroPiso.Location = new System.Drawing.Point(228, 194);
            this.tb_nroPiso.Name = "tb_nroPiso";
            this.tb_nroPiso.Size = new System.Drawing.Size(113, 20);
            this.tb_nroPiso.TabIndex = 10;
            // 
            // tb_localidad
            // 
            this.tb_localidad.Location = new System.Drawing.Point(416, 194);
            this.tb_localidad.Name = "tb_localidad";
            this.tb_localidad.Size = new System.Drawing.Size(113, 20);
            this.tb_localidad.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(155, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Apellido";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(335, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Mail";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(563, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Telefono";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "DNI";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(36, 178);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Calle";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(227, 178);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Numero de piso";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(413, 178);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Localidad";
            // 
            // cb_dia
            // 
            this.cb_dia.FormattingEnabled = true;
            this.cb_dia.Location = new System.Drawing.Point(158, 85);
            this.cb_dia.Name = "cb_dia";
            this.cb_dia.Size = new System.Drawing.Size(36, 21);
            this.cb_dia.TabIndex = 21;
            // 
            // cb_mes
            // 
            this.cb_mes.FormattingEnabled = true;
            this.cb_mes.Location = new System.Drawing.Point(200, 85);
            this.cb_mes.Name = "cb_mes";
            this.cb_mes.Size = new System.Drawing.Size(36, 21);
            this.cb_mes.TabIndex = 22;
            // 
            // cb_anio
            // 
            this.cb_anio.FormattingEnabled = true;
            this.cb_anio.Location = new System.Drawing.Point(242, 85);
            this.cb_anio.Name = "cb_anio";
            this.cb_anio.Size = new System.Drawing.Size(46, 21);
            this.cb_anio.TabIndex = 23;
            this.cb_anio.SelectedIndexChanged += new System.EventHandler(this.cb_anio_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(168, 69);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(23, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "Dia";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(206, 69);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(27, 13);
            this.label10.TabIndex = 25;
            this.label10.Text = "Mes";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(245, 69);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(26, 13);
            this.label11.TabIndex = 26;
            this.label11.Text = "Año";
            // 
            // Alta_Chofer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 377);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cb_anio);
            this.Controls.Add(this.cb_mes);
            this.Controls.Add(this.cb_dia);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_localidad);
            this.Controls.Add(this.tb_nroPiso);
            this.Controls.Add(this.tb_calle);
            this.Controls.Add(this.tb_telefono);
            this.Controls.Add(this.tb_mail);
            this.Controls.Add(this.tb_DNI);
            this.Controls.Add(this.tb_apellido);
            this.Controls.Add(this.tb_nombre);
            this.Controls.Add(this.bt_volver_abm);
            this.Controls.Add(this.bt_crear_chofer);
            this.Name = "Alta_Chofer";
            this.Text = "Alta nuevo chofer";
            this.Load += new System.EventHandler(this.Alta_Chofer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_crear_chofer;
        private System.Windows.Forms.Button bt_volver_abm;
        private System.Windows.Forms.TextBox tb_nombre;
        private System.Windows.Forms.TextBox tb_apellido;
        private System.Windows.Forms.TextBox tb_DNI;
        private System.Windows.Forms.TextBox tb_mail;
        private System.Windows.Forms.TextBox tb_telefono;
        private System.Windows.Forms.TextBox tb_calle;
        private System.Windows.Forms.TextBox tb_nroPiso;
        private System.Windows.Forms.TextBox tb_localidad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cb_dia;
        private System.Windows.Forms.ComboBox cb_mes;
        private System.Windows.Forms.ComboBox cb_anio;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
    }
}