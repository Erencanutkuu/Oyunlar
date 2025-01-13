using System;

namespace adamasmacayeni1
{
    partial class Form1
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
            this.lblMesaj = new System.Windows.Forms.Label();
            this.lblKalanHak = new System.Windows.Forms.Label();
            this.txtHarf = new System.Windows.Forms.TextBox();
            this.btnTahminEt = new System.Windows.Forms.Button();
            this.lblMaskeliSehir = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMesaj
            // 
            this.lblMesaj.AutoSize = true;
            this.lblMesaj.Location = new System.Drawing.Point(335, 329);
            this.lblMesaj.Name = "lblMesaj";
            this.lblMesaj.Size = new System.Drawing.Size(35, 13);
            this.lblMesaj.TabIndex = 0;
            this.lblMesaj.Text = "label1";
            // 
            // lblKalanHak
            // 
            this.lblKalanHak.AutoSize = true;
            this.lblKalanHak.Location = new System.Drawing.Point(541, 217);
            this.lblKalanHak.Name = "lblKalanHak";
            this.lblKalanHak.Size = new System.Drawing.Size(35, 13);
            this.lblKalanHak.TabIndex = 1;
            this.lblKalanHak.Text = "label2";
            // 
            // txtHarf
            // 
            this.txtHarf.Location = new System.Drawing.Point(513, 179);
            this.txtHarf.MaxLength = 1;
            this.txtHarf.Name = "txtHarf";
            this.txtHarf.Size = new System.Drawing.Size(100, 20);
            this.txtHarf.TabIndex = 2;
            // 
            // btnTahminEt
            // 
            this.btnTahminEt.Location = new System.Drawing.Point(523, 233);
            this.btnTahminEt.Name = "btnTahminEt";
            this.btnTahminEt.Size = new System.Drawing.Size(75, 23);
            this.btnTahminEt.TabIndex = 3;
            this.btnTahminEt.Text = "giriş";
            this.btnTahminEt.UseVisualStyleBackColor = true;
            this.btnTahminEt.Click += new System.EventHandler(this.btnTahminEt_Click);
            // 
            // lblMaskeliSehir
            // 
            this.lblMaskeliSehir.AutoSize = true;
            this.lblMaskeliSehir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblMaskeliSehir.Location = new System.Drawing.Point(541, 54);
            this.lblMaskeliSehir.Name = "lblMaskeliSehir";
            this.lblMaskeliSehir.Size = new System.Drawing.Size(0, 20);
            this.lblMaskeliSehir.TabIndex = 4;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::adamasmacayeni1.Properties.Resources.adam1;
            this.pictureBox2.Location = new System.Drawing.Point(748, 428);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(10, 10);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.lblMaskeliSehir);
            this.Controls.Add(this.btnTahminEt);
            this.Controls.Add(this.txtHarf);
            this.Controls.Add(this.lblKalanHak);
            this.Controls.Add(this.lblMesaj);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMesaj;
        private System.Windows.Forms.Label lblKalanHak;
        private System.Windows.Forms.TextBox txtHarf;
        private System.Windows.Forms.Button btnTahminEt;
        private System.Windows.Forms.Label lblMaskeliSehir;
        private System.Windows.Forms.PictureBox pictureBox2;
        private EventHandler txtHarf_TextChanged;
        private EventHandler btnTahminEt_Click_1;
    }
}

