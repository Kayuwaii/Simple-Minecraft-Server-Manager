namespace Simple_Minecraft_Server_Manager
{
    partial class MainForm
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
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.modsCheckBox = new MetroFramework.Controls.MetroCheckBox();
            this.metroCheckBox2 = new MetroFramework.Controls.MetroCheckBox();
            this.metroCheckBox3 = new MetroFramework.Controls.MetroCheckBox();
            this.metroPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(-1, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(167, 25);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Minecraft Options";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroPanel1
            // 
            this.metroPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.metroPanel1.Controls.Add(this.metroCheckBox3);
            this.metroPanel1.Controls.Add(this.metroCheckBox2);
            this.metroPanel1.Controls.Add(this.modsCheckBox);
            this.metroPanel1.Controls.Add(this.metroLabel1);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(23, 84);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(361, 343);
            this.metroPanel1.TabIndex = 1;
            this.metroPanel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // metroPanel2
            // 
            this.metroPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Location = new System.Drawing.Point(416, 84);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(361, 343);
            this.metroPanel2.TabIndex = 2;
            this.metroPanel2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // modsCheckBox
            // 
            this.modsCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.modsCheckBox.AutoSize = true;
            this.modsCheckBox.FontWeight = MetroFramework.MetroCheckBoxWeight.Light;
            this.modsCheckBox.Location = new System.Drawing.Point(19, 40);
            this.modsCheckBox.Name = "modsCheckBox";
            this.modsCheckBox.Size = new System.Drawing.Size(74, 15);
            this.modsCheckBox.TabIndex = 5;
            this.modsCheckBox.Text = "Use Mods";
            this.modsCheckBox.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.modsCheckBox.UseSelectable = true;
            // 
            // metroCheckBox2
            // 
            this.metroCheckBox2.Appearance = System.Windows.Forms.Appearance.Button;
            this.metroCheckBox2.AutoSize = true;
            this.metroCheckBox2.FontWeight = MetroFramework.MetroCheckBoxWeight.Light;
            this.metroCheckBox2.Location = new System.Drawing.Point(122, 40);
            this.metroCheckBox2.Name = "metroCheckBox2";
            this.metroCheckBox2.Size = new System.Drawing.Size(93, 15);
            this.metroCheckBox2.TabIndex = 6;
            this.metroCheckBox2.Text = "Only Premium";
            this.metroCheckBox2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroCheckBox2.UseSelectable = true;
            // 
            // metroCheckBox3
            // 
            this.metroCheckBox3.Appearance = System.Windows.Forms.Appearance.Button;
            this.metroCheckBox3.AutoSize = true;
            this.metroCheckBox3.FontWeight = MetroFramework.MetroCheckBoxWeight.Light;
            this.metroCheckBox3.Location = new System.Drawing.Point(241, 40);
            this.metroCheckBox3.Name = "metroCheckBox3";
            this.metroCheckBox3.Size = new System.Drawing.Size(85, 15);
            this.metroCheckBox3.TabIndex = 7;
            this.metroCheckBox3.Text = "PvP Enabled";
            this.metroCheckBox3.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroCheckBox3.UseSelectable = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.metroPanel2);
            this.Controls.Add(this.metroPanel1);
            this.Name = "MainForm";
            this.Style = MetroFramework.MetroColorStyle.Teal;
            this.Text = "Simple Server Manager";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroPanel metroPanel2;
        private MetroFramework.Controls.MetroCheckBox metroCheckBox3;
        private MetroFramework.Controls.MetroCheckBox metroCheckBox2;
        private MetroFramework.Controls.MetroCheckBox modsCheckBox;
    }
}

