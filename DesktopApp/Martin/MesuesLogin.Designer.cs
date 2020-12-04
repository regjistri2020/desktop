namespace DesktopApp.Martin
{
    partial class MesuesLogin
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
            this.BackpictureBox = new System.Windows.Forms.PictureBox();
            this.minimizepictureBox = new System.Windows.Forms.PictureBox();
            this.closepictureBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.PasspictureBox = new System.Windows.Forms.PictureBox();
            this.UserpictureBox = new System.Windows.Forms.PictureBox();
            this.UsernamePanel = new System.Windows.Forms.Panel();
            this.PassPanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Hyni_button = new System.Windows.Forms.Button();
            this.PasstextBox = new System.Windows.Forms.TextBox();
            this.UsernametextBox = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BackpictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimizepictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.closepictureBox)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PasspictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserpictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panel1.Controls.Add(this.BackpictureBox);
            this.panel1.Controls.Add(this.minimizepictureBox);
            this.panel1.Controls.Add(this.closepictureBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(351, 123);
            this.panel1.TabIndex = 0;
            // 
            // BackpictureBox
            // 
            this.BackpictureBox.Image = global::DesktopApp.Properties.Resources.back1;
            this.BackpictureBox.Location = new System.Drawing.Point(4, 2);
            this.BackpictureBox.Name = "BackpictureBox";
            this.BackpictureBox.Size = new System.Drawing.Size(33, 33);
            this.BackpictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BackpictureBox.TabIndex = 6;
            this.BackpictureBox.TabStop = false;
            // 
            // minimizepictureBox
            // 
            this.minimizepictureBox.Image = global::DesktopApp.Properties.Resources.minus;
            this.minimizepictureBox.Location = new System.Drawing.Point(278, 0);
            this.minimizepictureBox.Name = "minimizepictureBox";
            this.minimizepictureBox.Size = new System.Drawing.Size(33, 33);
            this.minimizepictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.minimizepictureBox.TabIndex = 5;
            this.minimizepictureBox.TabStop = false;
            // 
            // closepictureBox
            // 
            this.closepictureBox.Image = global::DesktopApp.Properties.Resources.icons8_cancel_32;
            this.closepictureBox.Location = new System.Drawing.Point(318, 0);
            this.closepictureBox.Name = "closepictureBox";
            this.closepictureBox.Size = new System.Drawing.Size(33, 33);
            this.closepictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.closepictureBox.TabIndex = 4;
            this.closepictureBox.TabStop = false;
            this.closepictureBox.Click += new System.EventHandler(this.closepictureBox_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 23.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(55, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 70);
            this.label1.TabIndex = 2;
            this.label1.Text = "Identifikohuni \r\n   si mesues";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.PasspictureBox);
            this.panel2.Controls.Add(this.UserpictureBox);
            this.panel2.Controls.Add(this.UsernamePanel);
            this.panel2.Controls.Add(this.PassPanel);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.Hyni_button);
            this.panel2.Controls.Add(this.PasstextBox);
            this.panel2.Controls.Add(this.UsernametextBox);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 123);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(351, 365);
            this.panel2.TabIndex = 1;
            // 
            // PasspictureBox
            // 
            this.PasspictureBox.Image = global::DesktopApp.Properties.Resources.secure;
            this.PasspictureBox.Location = new System.Drawing.Point(35, 183);
            this.PasspictureBox.Name = "PasspictureBox";
            this.PasspictureBox.Size = new System.Drawing.Size(48, 48);
            this.PasspictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PasspictureBox.TabIndex = 23;
            this.PasspictureBox.TabStop = false;
            // 
            // UserpictureBox
            // 
            this.UserpictureBox.Image = global::DesktopApp.Properties.Resources.icons8_user_64;
            this.UserpictureBox.Location = new System.Drawing.Point(35, 73);
            this.UserpictureBox.Name = "UserpictureBox";
            this.UserpictureBox.Size = new System.Drawing.Size(48, 48);
            this.UserpictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.UserpictureBox.TabIndex = 22;
            this.UserpictureBox.TabStop = false;
            // 
            // UsernamePanel
            // 
            this.UsernamePanel.BackColor = System.Drawing.SystemColors.Desktop;
            this.UsernamePanel.Location = new System.Drawing.Point(94, 118);
            this.UsernamePanel.Name = "UsernamePanel";
            this.UsernamePanel.Size = new System.Drawing.Size(192, 2);
            this.UsernamePanel.TabIndex = 21;
            this.UsernamePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.UsernamePanel_Paint);
            // 
            // PassPanel
            // 
            this.PassPanel.BackColor = System.Drawing.SystemColors.Desktop;
            this.PassPanel.Location = new System.Drawing.Point(94, 229);
            this.PassPanel.Name = "PassPanel";
            this.PassPanel.Size = new System.Drawing.Size(192, 2);
            this.PassPanel.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(95, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 25);
            this.label3.TabIndex = 19;
            this.label3.Text = "Fjalëkalimi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(89, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(172, 25);
            this.label2.TabIndex = 18;
            this.label2.Text = "Kodi Identifikues";
            // 
            // Hyni_button
            // 
            this.Hyni_button.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.Hyni_button.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.Hyni_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Hyni_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Hyni_button.ForeColor = System.Drawing.Color.White;
            this.Hyni_button.Location = new System.Drawing.Point(225, 280);
            this.Hyni_button.Name = "Hyni_button";
            this.Hyni_button.Size = new System.Drawing.Size(80, 41);
            this.Hyni_button.TabIndex = 17;
            this.Hyni_button.Text = "Hyni";
            this.Hyni_button.UseVisualStyleBackColor = false;
            // 
            // PasstextBox
            // 
            this.PasstextBox.BackColor = System.Drawing.SystemColors.Control;
            this.PasstextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PasstextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasstextBox.Location = new System.Drawing.Point(95, 213);
            this.PasstextBox.Name = "PasstextBox";
            this.PasstextBox.Size = new System.Drawing.Size(192, 15);
            this.PasstextBox.TabIndex = 16;
            this.PasstextBox.Text = "Vendosni fjalëkalimin tuaj";
            this.PasstextBox.Click += new System.EventHandler(this.PasstextBox_Click);
            // 
            // UsernametextBox
            // 
            this.UsernametextBox.BackColor = System.Drawing.SystemColors.Control;
            this.UsernametextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UsernametextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernametextBox.Location = new System.Drawing.Point(95, 102);
            this.UsernametextBox.Name = "UsernametextBox";
            this.UsernametextBox.Size = new System.Drawing.Size(192, 15);
            this.UsernametextBox.TabIndex = 15;
            this.UsernametextBox.Text = "Vendosni kodin tuaj";
            this.UsernametextBox.Click += new System.EventHandler(this.UsernameTextbox_Click);
            // 
            // MesuesLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 488);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MesuesLogin";
            this.Text = "MesuesLogin";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BackpictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimizepictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.closepictureBox)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PasspictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserpictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox minimizepictureBox;
        private System.Windows.Forms.PictureBox closepictureBox;
        private System.Windows.Forms.PictureBox BackpictureBox;
        private System.Windows.Forms.PictureBox PasspictureBox;
        private System.Windows.Forms.PictureBox UserpictureBox;
        private System.Windows.Forms.Panel UsernamePanel;
        private System.Windows.Forms.Panel PassPanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Hyni_button;
        private System.Windows.Forms.TextBox PasstextBox;
        private System.Windows.Forms.TextBox UsernametextBox;
    }
}