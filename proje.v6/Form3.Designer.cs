namespace proje.v6
{
    partial class Form3
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
            this.label2 = new System.Windows.Forms.Label();
            this.lb_izinhakki = new System.Windows.Forms.Label();
            this.lb_izinbitisi = new System.Windows.Forms.Label();
            this.lb_izinbaslangici = new System.Windows.Forms.Label();
            this.bt_izinal = new System.Windows.Forms.Button();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(109, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "____";
            // 
            // lb_izinhakki
            // 
            this.lb_izinhakki.AutoSize = true;
            this.lb_izinhakki.Location = new System.Drawing.Point(12, 21);
            this.lb_izinhakki.Name = "lb_izinhakki";
            this.lb_izinhakki.Size = new System.Drawing.Size(60, 13);
            this.lb_izinhakki.TabIndex = 12;
            this.lb_izinhakki.Text = "İzin Hakkı :";
            // 
            // lb_izinbitisi
            // 
            this.lb_izinbitisi.AutoSize = true;
            this.lb_izinbitisi.Font = new System.Drawing.Font("Calisto MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_izinbitisi.ForeColor = System.Drawing.Color.Red;
            this.lb_izinbitisi.Location = new System.Drawing.Point(374, 62);
            this.lb_izinbitisi.Name = "lb_izinbitisi";
            this.lb_izinbitisi.Size = new System.Drawing.Size(75, 20);
            this.lb_izinbitisi.TabIndex = 11;
            this.lb_izinbitisi.Text = "İzin bitişi";
            // 
            // lb_izinbaslangici
            // 
            this.lb_izinbaslangici.AutoSize = true;
            this.lb_izinbaslangici.Font = new System.Drawing.Font("Calisto MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_izinbaslangici.ForeColor = System.Drawing.Color.Red;
            this.lb_izinbaslangici.Location = new System.Drawing.Point(-1, 62);
            this.lb_izinbaslangici.Name = "lb_izinbaslangici";
            this.lb_izinbaslangici.Size = new System.Drawing.Size(112, 20);
            this.lb_izinbaslangici.TabIndex = 10;
            this.lb_izinbaslangici.Text = "İzin başlangıcı";
            // 
            // bt_izinal
            // 
            this.bt_izinal.Location = new System.Drawing.Point(281, 271);
            this.bt_izinal.Name = "bt_izinal";
            this.bt_izinal.Size = new System.Drawing.Size(88, 34);
            this.bt_izinal.TabIndex = 9;
            this.bt_izinal.Text = "İzin Al";
            this.bt_izinal.UseVisualStyleBackColor = true;
            this.bt_izinal.Click += new System.EventHandler(this.bt_izinal_Click);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(378, 101);
            this.dateTimePicker2.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker2.MinDate = new System.DateTime(2018, 12, 24, 0, 0, 0, 0);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(265, 20);
            this.dateTimePicker2.TabIndex = 8;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(3, 101);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker1.MinDate = new System.DateTime(2018, 12, 24, 0, 0, 0, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(275, 20);
            this.dateTimePicker1.TabIndex = 7;
            this.dateTimePicker1.Value = new System.DateTime(2018, 12, 24, 0, 0, 0, 0);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(656, 339);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lb_izinhakki);
            this.Controls.Add(this.lb_izinbitisi);
            this.Controls.Add(this.lb_izinbaslangici);
            this.Controls.Add(this.bt_izinal);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Name = "Form3";
            this.Text = "Form3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lb_izinhakki;
        private System.Windows.Forms.Label lb_izinbitisi;
        private System.Windows.Forms.Label lb_izinbaslangici;
        private System.Windows.Forms.Button bt_izinal;
        public System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}