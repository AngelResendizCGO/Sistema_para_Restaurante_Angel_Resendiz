
namespace Sistema_para_Restaurante_Angel_Resendiz.Productos
{
    partial class Productos_rest
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Panel_Grupos = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtBuscarSalon = new System.Windows.Forms.TextBox();
            this.AgregarGrupo = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(318, 450);
            this.panel1.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.Panel_Grupos);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 116);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(318, 334);
            this.panel3.TabIndex = 1;
            // 
            // Panel_Grupos
            // 
            this.Panel_Grupos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel_Grupos.Location = new System.Drawing.Point(0, 0);
            this.Panel_Grupos.Name = "Panel_Grupos";
            this.Panel_Grupos.Size = new System.Drawing.Size(318, 334);
            this.Panel_Grupos.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.AgregarGrupo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(318, 116);
            this.panel2.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.panel4.Controls.Add(this.pictureBox1);
            this.panel4.Controls.Add(this.txtBuscarSalon);
            this.panel4.Location = new System.Drawing.Point(15, 55);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(289, 55);
            this.panel4.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(251, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 16);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // txtBuscarSalon
            // 
            this.txtBuscarSalon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.txtBuscarSalon.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBuscarSalon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarSalon.ForeColor = System.Drawing.Color.White;
            this.txtBuscarSalon.Location = new System.Drawing.Point(13, 19);
            this.txtBuscarSalon.Name = "txtBuscarSalon";
            this.txtBuscarSalon.Size = new System.Drawing.Size(232, 19);
            this.txtBuscarSalon.TabIndex = 0;
            // 
            // AgregarGrupo
            // 
            this.AgregarGrupo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.AgregarGrupo.FlatAppearance.BorderSize = 0;
            this.AgregarGrupo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AgregarGrupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AgregarGrupo.ForeColor = System.Drawing.Color.White;
            this.AgregarGrupo.Location = new System.Drawing.Point(12, 12);
            this.AgregarGrupo.Name = "AgregarGrupo";
            this.AgregarGrupo.Size = new System.Drawing.Size(176, 37);
            this.AgregarGrupo.TabIndex = 0;
            this.AgregarGrupo.Text = "+ Agregar Grupo";
            this.AgregarGrupo.UseVisualStyleBackColor = false;
            // 
            // Productos_rest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "Productos_rest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Productos_rest";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Productos_rest_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.FlowLayoutPanel Panel_Grupos;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtBuscarSalon;
        private System.Windows.Forms.Button AgregarGrupo;
    }
}