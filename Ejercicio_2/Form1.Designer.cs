namespace Ejercicio_2
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.tbCapacidad = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCerrarCamion = new System.Windows.Forms.Button();
            this.btnDescargarCamion = new System.Windows.Forms.Button();
            this.btnCargarCamion = new System.Windows.Forms.Button();
            this.btnCrearCamion = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDescargar = new System.Windows.Forms.Button();
            this.btnRecibirCamion = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpFecha);
            this.groupBox1.Controls.Add(this.tbCapacidad);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnCerrarCamion);
            this.groupBox1.Controls.Add(this.btnDescargarCamion);
            this.groupBox1.Controls.Add(this.btnCargarCamion);
            this.groupBox1.Controls.Add(this.btnCrearCamion);
            this.groupBox1.Controls.Add(this.listBox1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(390, 363);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cargas";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(184, 19);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(200, 20);
            this.dtpFecha.TabIndex = 8;
            // 
            // tbCapacidad
            // 
            this.tbCapacidad.Location = new System.Drawing.Point(317, 79);
            this.tbCapacidad.Name = "tbCapacidad";
            this.tbCapacidad.Size = new System.Drawing.Size(67, 20);
            this.tbCapacidad.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(314, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Capacidad";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Lista de Autos";
            // 
            // btnCerrarCamion
            // 
            this.btnCerrarCamion.Enabled = false;
            this.btnCerrarCamion.Location = new System.Drawing.Point(215, 279);
            this.btnCerrarCamion.Name = "btnCerrarCamion";
            this.btnCerrarCamion.Size = new System.Drawing.Size(76, 54);
            this.btnCerrarCamion.TabIndex = 4;
            this.btnCerrarCamion.Text = "Cerrar Camion";
            this.btnCerrarCamion.UseVisualStyleBackColor = true;
            this.btnCerrarCamion.Click += new System.EventHandler(this.btnCerrarCamion_Click);
            // 
            // btnDescargarCamion
            // 
            this.btnDescargarCamion.Enabled = false;
            this.btnDescargarCamion.Location = new System.Drawing.Point(215, 206);
            this.btnDescargarCamion.Name = "btnDescargarCamion";
            this.btnDescargarCamion.Size = new System.Drawing.Size(76, 54);
            this.btnDescargarCamion.TabIndex = 3;
            this.btnDescargarCamion.Text = "Descargar";
            this.btnDescargarCamion.UseVisualStyleBackColor = true;
            this.btnDescargarCamion.Click += new System.EventHandler(this.btnDescargarCamion_Click);
            // 
            // btnCargarCamion
            // 
            this.btnCargarCamion.Enabled = false;
            this.btnCargarCamion.Location = new System.Drawing.Point(215, 132);
            this.btnCargarCamion.Name = "btnCargarCamion";
            this.btnCargarCamion.Size = new System.Drawing.Size(76, 54);
            this.btnCargarCamion.TabIndex = 2;
            this.btnCargarCamion.Text = "Cargar";
            this.btnCargarCamion.UseVisualStyleBackColor = true;
            this.btnCargarCamion.Click += new System.EventHandler(this.btnCargarCamion_Click);
            // 
            // btnCrearCamion
            // 
            this.btnCrearCamion.Location = new System.Drawing.Point(215, 61);
            this.btnCrearCamion.Name = "btnCrearCamion";
            this.btnCrearCamion.Size = new System.Drawing.Size(76, 54);
            this.btnCrearCamion.TabIndex = 1;
            this.btnCrearCamion.Text = "Crear Camion";
            this.btnCrearCamion.UseVisualStyleBackColor = true;
            this.btnCrearCamion.Click += new System.EventHandler(this.btnCrearCamion_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(7, 61);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(188, 277);
            this.listBox1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDescargar);
            this.groupBox2.Controls.Add(this.btnRecibirCamion);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.listBox2);
            this.groupBox2.Location = new System.Drawing.Point(454, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(385, 363);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Descargas";
            // 
            // btnDescargar
            // 
            this.btnDescargar.Enabled = false;
            this.btnDescargar.Location = new System.Drawing.Point(235, 132);
            this.btnDescargar.Name = "btnDescargar";
            this.btnDescargar.Size = new System.Drawing.Size(76, 54);
            this.btnDescargar.TabIndex = 9;
            this.btnDescargar.Text = "Descargar";
            this.btnDescargar.UseVisualStyleBackColor = true;
            this.btnDescargar.Click += new System.EventHandler(this.btnDescargar_Click);
            // 
            // btnRecibirCamion
            // 
            this.btnRecibirCamion.Location = new System.Drawing.Point(235, 61);
            this.btnRecibirCamion.Name = "btnRecibirCamion";
            this.btnRecibirCamion.Size = new System.Drawing.Size(76, 54);
            this.btnRecibirCamion.TabIndex = 8;
            this.btnRecibirCamion.Text = "Recibir Camion";
            this.btnRecibirCamion.UseVisualStyleBackColor = true;
            this.btnRecibirCamion.Click += new System.EventHandler(this.btnRecibirCamion_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Lista de Recibidos";
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(6, 61);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(188, 277);
            this.listBox2.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 393);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbCapacidad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCerrarCamion;
        private System.Windows.Forms.Button btnDescargarCamion;
        private System.Windows.Forms.Button btnCargarCamion;
        private System.Windows.Forms.Button btnCrearCamion;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnDescargar;
        private System.Windows.Forms.Button btnRecibirCamion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.DateTimePicker dtpFecha;
    }
}

