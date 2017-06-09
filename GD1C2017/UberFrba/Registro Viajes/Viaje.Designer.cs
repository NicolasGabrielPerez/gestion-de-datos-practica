namespace UberFrba.Registro_Viajes
{
    partial class Viaje
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
            this.grupoCliente = new System.Windows.Forms.GroupBox();
            this.txtClDoc = new System.Windows.Forms.TextBox();
            this.dtClDate = new System.Windows.Forms.DateTimePicker();
            this.txtClMail = new System.Windows.Forms.TextBox();
            this.txtClTel = new System.Windows.Forms.TextBox();
            this.txtClApellido = new System.Windows.Forms.TextBox();
            this.txtClNombre = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.grupoAuto = new System.Windows.Forms.GroupBox();
            this.txtModelo = new System.Windows.Forms.TextBox();
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.txtPatente = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.comboChofer = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtkm = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.dtInicio = new System.Windows.Forms.DateTimePicker();
            this.dtFin = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.comboCliente = new System.Windows.Forms.ComboBox();
            this.grupoChofer = new System.Windows.Forms.GroupBox();
            this.txtCDoc = new System.Windows.Forms.TextBox();
            this.dtCFecha = new System.Windows.Forms.DateTimePicker();
            this.txtCMail = new System.Windows.Forms.TextBox();
            this.txtCTel = new System.Windows.Forms.TextBox();
            this.txtCApellido = new System.Windows.Forms.TextBox();
            this.txtCNombre = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.grupoCliente.SuspendLayout();
            this.grupoAuto.SuspendLayout();
            this.grupoChofer.SuspendLayout();
            this.SuspendLayout();
            // 
            // grupoCliente
            // 
            this.grupoCliente.Controls.Add(this.txtClDoc);
            this.grupoCliente.Controls.Add(this.dtClDate);
            this.grupoCliente.Controls.Add(this.txtClMail);
            this.grupoCliente.Controls.Add(this.txtClTel);
            this.grupoCliente.Controls.Add(this.txtClApellido);
            this.grupoCliente.Controls.Add(this.txtClNombre);
            this.grupoCliente.Controls.Add(this.label13);
            this.grupoCliente.Controls.Add(this.label1);
            this.grupoCliente.Controls.Add(this.label6);
            this.grupoCliente.Controls.Add(this.label2);
            this.grupoCliente.Controls.Add(this.label5);
            this.grupoCliente.Controls.Add(this.label3);
            this.grupoCliente.Enabled = false;
            this.grupoCliente.Location = new System.Drawing.Point(418, 169);
            this.grupoCliente.Name = "grupoCliente";
            this.grupoCliente.Size = new System.Drawing.Size(364, 182);
            this.grupoCliente.TabIndex = 23;
            this.grupoCliente.TabStop = false;
            this.grupoCliente.Text = "Datos cliente";
            // 
            // txtClDoc
            // 
            this.txtClDoc.Location = new System.Drawing.Point(133, 73);
            this.txtClDoc.Name = "txtClDoc";
            this.txtClDoc.Size = new System.Drawing.Size(216, 20);
            this.txtClDoc.TabIndex = 15;
            // 
            // dtClDate
            // 
            this.dtClDate.Location = new System.Drawing.Point(133, 151);
            this.dtClDate.Name = "dtClDate";
            this.dtClDate.Size = new System.Drawing.Size(216, 20);
            this.dtClDate.TabIndex = 13;
            this.dtClDate.ValueChanged += new System.EventHandler(this.dtClDate_ValueChanged);
            // 
            // txtClMail
            // 
            this.txtClMail.Location = new System.Drawing.Point(133, 125);
            this.txtClMail.Name = "txtClMail";
            this.txtClMail.Size = new System.Drawing.Size(216, 20);
            this.txtClMail.TabIndex = 12;
            // 
            // txtClTel
            // 
            this.txtClTel.Location = new System.Drawing.Point(133, 99);
            this.txtClTel.Name = "txtClTel";
            this.txtClTel.Size = new System.Drawing.Size(216, 20);
            this.txtClTel.TabIndex = 11;
            // 
            // txtClApellido
            // 
            this.txtClApellido.Location = new System.Drawing.Point(133, 48);
            this.txtClApellido.Name = "txtClApellido";
            this.txtClApellido.Size = new System.Drawing.Size(216, 20);
            this.txtClApellido.TabIndex = 8;
            // 
            // txtClNombre
            // 
            this.txtClNombre.Location = new System.Drawing.Point(133, 22);
            this.txtClNombre.Name = "txtClNombre";
            this.txtClNombre.Size = new System.Drawing.Size(216, 20);
            this.txtClNombre.TabIndex = 7;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(20, 154);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(106, 13);
            this.label13.TabIndex = 6;
            this.label13.Text = "Fecha de nacimiento";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Teléfono";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Apellido";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Mail";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Número documento";
            // 
            // grupoAuto
            // 
            this.grupoAuto.Controls.Add(this.txtModelo);
            this.grupoAuto.Controls.Add(this.txtMarca);
            this.grupoAuto.Controls.Add(this.txtPatente);
            this.grupoAuto.Controls.Add(this.label7);
            this.grupoAuto.Controls.Add(this.label9);
            this.grupoAuto.Controls.Add(this.label11);
            this.grupoAuto.Enabled = false;
            this.grupoAuto.Location = new System.Drawing.Point(418, 42);
            this.grupoAuto.Name = "grupoAuto";
            this.grupoAuto.Size = new System.Drawing.Size(364, 105);
            this.grupoAuto.TabIndex = 23;
            this.grupoAuto.TabStop = false;
            this.grupoAuto.Text = "Datos del auto";
            // 
            // txtModelo
            // 
            this.txtModelo.Location = new System.Drawing.Point(133, 73);
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.Size = new System.Drawing.Size(216, 20);
            this.txtModelo.TabIndex = 15;
            // 
            // txtMarca
            // 
            this.txtMarca.Location = new System.Drawing.Point(133, 48);
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(216, 20);
            this.txtMarca.TabIndex = 8;
            // 
            // txtPatente
            // 
            this.txtPatente.Location = new System.Drawing.Point(133, 22);
            this.txtPatente.Name = "txtPatente";
            this.txtPatente.Size = new System.Drawing.Size(216, 20);
            this.txtPatente.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Patente";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 51);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Marca";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(20, 76);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "Modelo";
            // 
            // comboChofer
            // 
            this.comboChofer.FormattingEnabled = true;
            this.comboChofer.Location = new System.Drawing.Point(163, 15);
            this.comboChofer.Name = "comboChofer";
            this.comboChofer.Size = new System.Drawing.Size(230, 21);
            this.comboChofer.TabIndex = 24;
            this.comboChofer.SelectedIndexChanged += new System.EventHandler(this.comboChofer_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Seleccione un chofer";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(26, 126);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "Cantidad de Km";
            // 
            // txtkm
            // 
            this.txtkm.Location = new System.Drawing.Point(163, 123);
            this.txtkm.Name = "txtkm";
            this.txtkm.Size = new System.Drawing.Size(230, 20);
            this.txtkm.TabIndex = 27;
            this.txtkm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtkm_KeyPress_1);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(26, 71);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 13);
            this.label10.TabIndex = 28;
            this.label10.Text = "Hora de Inicio";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(26, 97);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(103, 13);
            this.label12.TabIndex = 30;
            this.label12.Text = "Hora de Finalizacion";
            // 
            // dtInicio
            // 
            this.dtInicio.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtInicio.Location = new System.Drawing.Point(163, 69);
            this.dtInicio.MaxDate = new System.DateTime(2020, 12, 31, 0, 0, 0, 0);
            this.dtInicio.MinDate = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.dtInicio.Name = "dtInicio";
            this.dtInicio.Size = new System.Drawing.Size(230, 20);
            this.dtInicio.TabIndex = 31;
            // 
            // dtFin
            // 
            this.dtFin.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFin.Location = new System.Drawing.Point(163, 95);
            this.dtFin.Name = "dtFin";
            this.dtFin.Size = new System.Drawing.Size(230, 20);
            this.dtFin.TabIndex = 32;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(26, 45);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(109, 13);
            this.label14.TabIndex = 33;
            this.label14.Text = "Seleccione un cliente";
            // 
            // comboCliente
            // 
            this.comboCliente.FormattingEnabled = true;
            this.comboCliente.Location = new System.Drawing.Point(163, 42);
            this.comboCliente.Name = "comboCliente";
            this.comboCliente.Size = new System.Drawing.Size(230, 21);
            this.comboCliente.TabIndex = 34;
            this.comboCliente.SelectedIndexChanged += new System.EventHandler(this.comboCliente_SelectedIndexChanged);
            // 
            // grupoChofer
            // 
            this.grupoChofer.Controls.Add(this.txtCDoc);
            this.grupoChofer.Controls.Add(this.dtCFecha);
            this.grupoChofer.Controls.Add(this.txtCMail);
            this.grupoChofer.Controls.Add(this.txtCTel);
            this.grupoChofer.Controls.Add(this.txtCApellido);
            this.grupoChofer.Controls.Add(this.txtCNombre);
            this.grupoChofer.Controls.Add(this.label15);
            this.grupoChofer.Controls.Add(this.label16);
            this.grupoChofer.Controls.Add(this.label17);
            this.grupoChofer.Controls.Add(this.label18);
            this.grupoChofer.Controls.Add(this.label19);
            this.grupoChofer.Controls.Add(this.label20);
            this.grupoChofer.Enabled = false;
            this.grupoChofer.Location = new System.Drawing.Point(31, 169);
            this.grupoChofer.Name = "grupoChofer";
            this.grupoChofer.Size = new System.Drawing.Size(364, 182);
            this.grupoChofer.TabIndex = 24;
            this.grupoChofer.TabStop = false;
            this.grupoChofer.Text = "Datos Chofer";
            // 
            // txtCDoc
            // 
            this.txtCDoc.Location = new System.Drawing.Point(133, 73);
            this.txtCDoc.Name = "txtCDoc";
            this.txtCDoc.Size = new System.Drawing.Size(216, 20);
            this.txtCDoc.TabIndex = 15;
            // 
            // dtCFecha
            // 
            this.dtCFecha.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtCFecha.Location = new System.Drawing.Point(133, 151);
            this.dtCFecha.Name = "dtCFecha";
            this.dtCFecha.Size = new System.Drawing.Size(216, 20);
            this.dtCFecha.TabIndex = 13;
            // 
            // txtCMail
            // 
            this.txtCMail.Location = new System.Drawing.Point(133, 125);
            this.txtCMail.Name = "txtCMail";
            this.txtCMail.Size = new System.Drawing.Size(216, 20);
            this.txtCMail.TabIndex = 12;
            // 
            // txtCTel
            // 
            this.txtCTel.Location = new System.Drawing.Point(133, 99);
            this.txtCTel.Name = "txtCTel";
            this.txtCTel.Size = new System.Drawing.Size(216, 20);
            this.txtCTel.TabIndex = 11;
            // 
            // txtCApellido
            // 
            this.txtCApellido.Location = new System.Drawing.Point(133, 48);
            this.txtCApellido.Name = "txtCApellido";
            this.txtCApellido.Size = new System.Drawing.Size(216, 20);
            this.txtCApellido.TabIndex = 8;
            // 
            // txtCNombre
            // 
            this.txtCNombre.Location = new System.Drawing.Point(133, 22);
            this.txtCNombre.Name = "txtCNombre";
            this.txtCNombre.Size = new System.Drawing.Size(216, 20);
            this.txtCNombre.TabIndex = 7;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(20, 154);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(106, 13);
            this.label15.TabIndex = 6;
            this.label15.Text = "Fecha de nacimiento";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(20, 25);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(44, 13);
            this.label16.TabIndex = 0;
            this.label16.Text = "Nombre";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(20, 102);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(49, 13);
            this.label17.TabIndex = 5;
            this.label17.Text = "Teléfono";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(20, 51);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(44, 13);
            this.label18.TabIndex = 1;
            this.label18.Text = "Apellido";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(20, 128);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(26, 13);
            this.label19.TabIndex = 4;
            this.label19.Text = "Mail";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(20, 76);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(100, 13);
            this.label20.TabIndex = 2;
            this.label20.Text = "Número documento";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(707, 367);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 35;
            this.button1.Text = "Registrar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Viaje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 421);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.grupoChofer);
            this.Controls.Add(this.comboCliente);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.dtFin);
            this.Controls.Add(this.dtInicio);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.grupoCliente);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtkm);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboChofer);
            this.Controls.Add(this.grupoAuto);
            this.Name = "Viaje";
            this.ShowIcon = false;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Viaje_Load);
            this.grupoCliente.ResumeLayout(false);
            this.grupoCliente.PerformLayout();
            this.grupoAuto.ResumeLayout(false);
            this.grupoAuto.PerformLayout();
            this.grupoChofer.ResumeLayout(false);
            this.grupoChofer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grupoCliente;
        private System.Windows.Forms.TextBox txtClDoc;
        private System.Windows.Forms.DateTimePicker dtClDate;
        private System.Windows.Forms.TextBox txtClMail;
        private System.Windows.Forms.TextBox txtClTel;
        private System.Windows.Forms.TextBox txtClApellido;
        private System.Windows.Forms.TextBox txtClNombre;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox grupoAuto;
        private System.Windows.Forms.TextBox txtModelo;
        private System.Windows.Forms.TextBox txtMarca;
        private System.Windows.Forms.TextBox txtPatente;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comboChofer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtkm;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dtInicio;
        private System.Windows.Forms.DateTimePicker dtFin;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox comboCliente;
        private System.Windows.Forms.GroupBox grupoChofer;
        private System.Windows.Forms.DateTimePicker dtCFecha;
        private System.Windows.Forms.TextBox txtCMail;
        private System.Windows.Forms.TextBox txtCTel;
        private System.Windows.Forms.TextBox txtCApellido;
        private System.Windows.Forms.TextBox txtCNombre;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtCDoc;
    }
}