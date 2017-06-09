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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.birthTimePicker = new System.Windows.Forms.DateTimePicker();
            this.checkHabilitado = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbHabilitado = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // bt_crear_chofer
            // 
            this.bt_crear_chofer.Location = new System.Drawing.Point(627, 338);
            this.bt_crear_chofer.Name = "bt_crear_chofer";
            this.bt_crear_chofer.Size = new System.Drawing.Size(85, 27);
            this.bt_crear_chofer.TabIndex = 1;
            this.bt_crear_chofer.Text = "Guardar";
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
            this.tb_calle.Size = new System.Drawing.Size(359, 20);
            this.tb_calle.TabIndex = 9;
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
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(168, 69);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "Fecha de nacimiento";
            // 
            // birthTimePicker
            // 
            this.birthTimePicker.Location = new System.Drawing.Point(158, 85);
            this.birthTimePicker.Name = "birthTimePicker";
            this.birthTimePicker.Size = new System.Drawing.Size(216, 20);
            this.birthTimePicker.TabIndex = 27;
            this.birthTimePicker.ValueChanged += new System.EventHandler(this.birthTimePicker_ValueChanged);
            // 
            // checkHabilitado
            // 
            this.checkHabilitado.AutoSize = true;
            this.checkHabilitado.Checked = true;
            this.checkHabilitado.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkHabilitado.Location = new System.Drawing.Point(137, -27);
            this.checkHabilitado.Name = "checkHabilitado";
            this.checkHabilitado.Size = new System.Drawing.Size(15, 14);
            this.checkHabilitado.TabIndex = 29;
            this.checkHabilitado.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(36, 259);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 13);
            this.label7.TabIndex = 28;
            this.label7.Text = "Cliente habilitado";
            // 
            // cbHabilitado
            // 
            this.cbHabilitado.AutoSize = true;
            this.cbHabilitado.Checked = true;
            this.cbHabilitado.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbHabilitado.Location = new System.Drawing.Point(171, 259);
            this.cbHabilitado.Name = "cbHabilitado";
            this.cbHabilitado.Size = new System.Drawing.Size(15, 14);
            this.cbHabilitado.TabIndex = 30;
            this.cbHabilitado.UseVisualStyleBackColor = true;
            this.cbHabilitado.CheckedChanged += new System.EventHandler(this.cbHabilitado_CheckedChanged);
            // 
            // Alta_Chofer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 377);
            this.Controls.Add(this.cbHabilitado);
            this.Controls.Add(this.checkHabilitado);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.birthTimePicker);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker birthTimePicker;
        private System.Windows.Forms.CheckBox checkHabilitado;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox cbHabilitado;
    }
}