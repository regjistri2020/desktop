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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MesuesLogin));
            this.jDragControl1 = new JDragControl.JDragControl(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.PasstextBox = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.UsernametextBox = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.bunifuCustomLabel3 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.minimizepictureBox = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.Hyni_button = new Bunifu.Framework.UI.BunifuThinButton2();
            this.closepictureBox = new System.Windows.Forms.PictureBox();
            this.bunifuGradientPanel1 = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.bunifuFlatButton2 = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuCustomLabel2 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.minimizepictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.closepictureBox)).BeginInit();
            this.bunifuGradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // jDragControl1
            // 
            this.jDragControl1.GetForm = this;
            this.jDragControl1.TargetControl = this;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(316, 326);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(284, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "*Kredincialet (Username ose Password) jane shkruar gabim";
            // 
            // PasstextBox
            // 
            this.PasstextBox.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.PasstextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.PasstextBox.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.PasstextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.PasstextBox.HintForeColor = System.Drawing.Color.Empty;
            this.PasstextBox.HintText = "";
            this.PasstextBox.isPassword = true;
            this.PasstextBox.LineFocusedColor = System.Drawing.Color.DarkSlateGray;
            this.PasstextBox.LineIdleColor = System.Drawing.Color.Orange;
            this.PasstextBox.LineMouseHoverColor = System.Drawing.Color.DarkSlateGray;
            this.PasstextBox.LineThickness = 3;
            this.PasstextBox.Location = new System.Drawing.Point(322, 259);
            this.PasstextBox.Margin = new System.Windows.Forms.Padding(4);
            this.PasstextBox.Name = "PasstextBox";
            this.PasstextBox.Size = new System.Drawing.Size(266, 44);
            this.PasstextBox.TabIndex = 15;
            this.PasstextBox.Text = "Password";
            this.PasstextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.PasstextBox.Click += new System.EventHandler(this.PasstextBox_Click_1);
            // 
            // UsernametextBox
            // 
            this.UsernametextBox.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.UsernametextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.UsernametextBox.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.UsernametextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.UsernametextBox.HintForeColor = System.Drawing.Color.Empty;
            this.UsernametextBox.HintText = "";
            this.UsernametextBox.isPassword = false;
            this.UsernametextBox.LineFocusedColor = System.Drawing.Color.DarkSlateGray;
            this.UsernametextBox.LineIdleColor = System.Drawing.Color.Orange;
            this.UsernametextBox.LineMouseHoverColor = System.Drawing.Color.DarkSlateGray;
            this.UsernametextBox.LineThickness = 8;
            this.UsernametextBox.Location = new System.Drawing.Point(322, 184);
            this.UsernametextBox.Margin = new System.Windows.Forms.Padding(4);
            this.UsernametextBox.Name = "UsernametextBox";
            this.UsernametextBox.Size = new System.Drawing.Size(266, 44);
            this.UsernametextBox.TabIndex = 14;
            this.UsernametextBox.Text = "Username";
            this.UsernametextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.UsernametextBox.Click += new System.EventHandler(this.UsernametextBox_Click_1);
            // 
            // bunifuCustomLabel3
            // 
            this.bunifuCustomLabel3.AllowDrop = true;
            this.bunifuCustomLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuCustomLabel3.AutoEllipsis = true;
            this.bunifuCustomLabel3.AutoSize = true;
            this.bunifuCustomLabel3.BackColor = System.Drawing.Color.White;
            this.bunifuCustomLabel3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bunifuCustomLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bunifuCustomLabel3.Location = new System.Drawing.Point(340, 124);
            this.bunifuCustomLabel3.Name = "bunifuCustomLabel3";
            this.bunifuCustomLabel3.Size = new System.Drawing.Size(225, 25);
            this.bunifuCustomLabel3.TabIndex = 12;
            this.bunifuCustomLabel3.Text = "Identifikohu si mësues";
            this.bunifuCustomLabel3.UseWaitCursor = true;
            // 
            // minimizepictureBox
            // 
            this.minimizepictureBox.Image = global::DesktopApp.Properties.Resources.icons8_minus_321;
            this.minimizepictureBox.Location = new System.Drawing.Point(566, 12);
            this.minimizepictureBox.Name = "minimizepictureBox";
            this.minimizepictureBox.Size = new System.Drawing.Size(31, 33);
            this.minimizepictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.minimizepictureBox.TabIndex = 5;
            this.minimizepictureBox.TabStop = false;
            this.minimizepictureBox.Click += new System.EventHandler(this.minimizepictureBox_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = global::DesktopApp.Properties.Resources.icons8_user_641;
            this.pictureBox3.Location = new System.Drawing.Point(418, 52);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(76, 51);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 17;
            this.pictureBox3.TabStop = false;
            // 
            // Hyni_button
            // 
            this.Hyni_button.ActiveBorderThickness = 1;
            this.Hyni_button.ActiveCornerRadius = 20;
            this.Hyni_button.ActiveFillColor = System.Drawing.Color.DarkOrange;
            this.Hyni_button.ActiveForecolor = System.Drawing.Color.White;
            this.Hyni_button.ActiveLineColor = System.Drawing.Color.DarkOrange;
            this.Hyni_button.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Hyni_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Hyni_button.BackgroundImage")));
            this.Hyni_button.ButtonText = "Log in";
            this.Hyni_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Hyni_button.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Hyni_button.ForeColor = System.Drawing.Color.Orange;
            this.Hyni_button.IdleBorderThickness = 1;
            this.Hyni_button.IdleCornerRadius = 20;
            this.Hyni_button.IdleFillColor = System.Drawing.Color.White;
            this.Hyni_button.IdleForecolor = System.Drawing.Color.DarkOrange;
            this.Hyni_button.IdleLineColor = System.Drawing.Color.DimGray;
            this.Hyni_button.Location = new System.Drawing.Point(367, 355);
            this.Hyni_button.Margin = new System.Windows.Forms.Padding(5);
            this.Hyni_button.Name = "Hyni_button";
            this.Hyni_button.Size = new System.Drawing.Size(181, 41);
            this.Hyni_button.TabIndex = 16;
            this.Hyni_button.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Hyni_button.Click += new System.EventHandler(this.Hyni_button_Click_1);
            // 
            // closepictureBox
            // 
            this.closepictureBox.Image = global::DesktopApp.Properties.Resources.icons8_cancel_32;
            this.closepictureBox.Location = new System.Drawing.Point(603, 12);
            this.closepictureBox.Name = "closepictureBox";
            this.closepictureBox.Size = new System.Drawing.Size(30, 33);
            this.closepictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.closepictureBox.TabIndex = 4;
            this.closepictureBox.TabStop = false;
            this.closepictureBox.Click += new System.EventHandler(this.closepictureBox_Click);
            // 
            // bunifuGradientPanel1
            // 
            this.bunifuGradientPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuGradientPanel1.BackgroundImage")));
            this.bunifuGradientPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuGradientPanel1.Controls.Add(this.bunifuFlatButton2);
            this.bunifuGradientPanel1.Controls.Add(this.bunifuCustomLabel2);
            this.bunifuGradientPanel1.Controls.Add(this.bunifuCustomLabel1);
            this.bunifuGradientPanel1.Controls.Add(this.pictureBox4);
            this.bunifuGradientPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.bunifuGradientPanel1.GradientBottomLeft = System.Drawing.Color.Teal;
            this.bunifuGradientPanel1.GradientBottomRight = System.Drawing.Color.LightSeaGreen;
            this.bunifuGradientPanel1.GradientTopLeft = System.Drawing.Color.MediumTurquoise;
            this.bunifuGradientPanel1.GradientTopRight = System.Drawing.Color.DarkSlateGray;
            this.bunifuGradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.bunifuGradientPanel1.Name = "bunifuGradientPanel1";
            this.bunifuGradientPanel1.Quality = 50;
            this.bunifuGradientPanel1.Size = new System.Drawing.Size(266, 423);
            this.bunifuGradientPanel1.TabIndex = 2;
            // 
            // bunifuFlatButton2
            // 
            this.bunifuFlatButton2.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bunifuFlatButton2.BackColor = System.Drawing.Color.DarkSlateGray;
            this.bunifuFlatButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuFlatButton2.BorderRadius = 7;
            this.bunifuFlatButton2.ButtonText = "Logohu si Admin";
            this.bunifuFlatButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuFlatButton2.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuFlatButton2.Iconcolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton2.Iconimage = ((System.Drawing.Image)(resources.GetObject("bunifuFlatButton2.Iconimage")));
            this.bunifuFlatButton2.Iconimage_right = null;
            this.bunifuFlatButton2.Iconimage_right_Selected = null;
            this.bunifuFlatButton2.Iconimage_Selected = null;
            this.bunifuFlatButton2.IconMarginLeft = 0;
            this.bunifuFlatButton2.IconMarginRight = 0;
            this.bunifuFlatButton2.IconRightVisible = true;
            this.bunifuFlatButton2.IconRightZoom = 0D;
            this.bunifuFlatButton2.IconVisible = true;
            this.bunifuFlatButton2.IconZoom = 60D;
            this.bunifuFlatButton2.IsTab = false;
            this.bunifuFlatButton2.Location = new System.Drawing.Point(49, 320);
            this.bunifuFlatButton2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bunifuFlatButton2.Name = "bunifuFlatButton2";
            this.bunifuFlatButton2.Normalcolor = System.Drawing.Color.DarkSlateGray;
            this.bunifuFlatButton2.OnHovercolor = System.Drawing.Color.White;
            this.bunifuFlatButton2.OnHoverTextColor = System.Drawing.Color.Teal;
            this.bunifuFlatButton2.selected = false;
            this.bunifuFlatButton2.Size = new System.Drawing.Size(166, 40);
            this.bunifuFlatButton2.TabIndex = 3;
            this.bunifuFlatButton2.Text = "Logohu si Admin";
            this.bunifuFlatButton2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bunifuFlatButton2.Textcolor = System.Drawing.Color.White;
            this.bunifuFlatButton2.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuFlatButton2.Click += new System.EventHandler(this.bunifuFlatButton2_Click);
            // 
            // bunifuCustomLabel2
            // 
            this.bunifuCustomLabel2.AutoSize = true;
            this.bunifuCustomLabel2.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCustomLabel2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bunifuCustomLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bunifuCustomLabel2.Location = new System.Drawing.Point(45, 184);
            this.bunifuCustomLabel2.Name = "bunifuCustomLabel2";
            this.bunifuCustomLabel2.Size = new System.Drawing.Size(161, 90);
            this.bunifuCustomLabel2.TabIndex = 2;
            this.bunifuCustomLabel2.Text = "Për probleme teknike\r\ntë aplikacionit\r\nmund ti drejtoheni \r\nshërbimit IT ne adres" +
    "ën\r\nEmail: suportIT@hg.al";
            this.bunifuCustomLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCustomLabel1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(27, 126);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(207, 33);
            this.bunifuCustomLabel1.TabIndex = 1;
            this.bunifuCustomLabel1.Text = "Përshëndetje!";
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.Image = global::DesktopApp.Properties.Resources.output_onlinepngtools__1_;
            this.pictureBox4.Location = new System.Drawing.Point(31, 32);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(204, 71);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 5;
            this.pictureBox4.TabStop = false;
            // 
            // MesuesLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(645, 423);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.minimizepictureBox);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.Hyni_button);
            this.Controls.Add(this.PasstextBox);
            this.Controls.Add(this.UsernametextBox);
            this.Controls.Add(this.bunifuCustomLabel3);
            this.Controls.Add(this.closepictureBox);
            this.Controls.Add(this.bunifuGradientPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MesuesLogin";
            this.Text = "MesuesLogin";
            this.Load += new System.EventHandler(this.MesuesLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.minimizepictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.closepictureBox)).EndInit();
            this.bunifuGradientPanel1.ResumeLayout(false);
            this.bunifuGradientPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private JDragControl.JDragControl jDragControl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private Bunifu.Framework.UI.BunifuThinButton2 Hyni_button;
        private Bunifu.Framework.UI.BunifuMaterialTextbox PasstextBox;
        private Bunifu.Framework.UI.BunifuMaterialTextbox UsernametextBox;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel3;
        private Bunifu.Framework.UI.BunifuGradientPanel bunifuGradientPanel1;
        private System.Windows.Forms.PictureBox minimizepictureBox;
        private Bunifu.Framework.UI.BunifuFlatButton bunifuFlatButton2;
        private System.Windows.Forms.PictureBox closepictureBox;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel2;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private System.Windows.Forms.PictureBox pictureBox4;
    }
}