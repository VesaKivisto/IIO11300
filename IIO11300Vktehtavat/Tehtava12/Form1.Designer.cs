namespace Tehtava12
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnOK = new System.Windows.Forms.Button();
            this.btnUusi = new System.Windows.Forms.Button();
            this.btnPeruuta = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cboLanguages = new System.Windows.Forms.ComboBox();
            this.lblTunnus = new System.Windows.Forms.Label();
            this.lblSala = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.cboTypes = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.Name = "btnOK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnUusi
            // 
            resources.ApplyResources(this.btnUusi, "btnUusi");
            this.btnUusi.Name = "btnUusi";
            this.btnUusi.UseVisualStyleBackColor = true;
            // 
            // btnPeruuta
            // 
            resources.ApplyResources(this.btnPeruuta, "btnPeruuta");
            this.btnPeruuta.Name = "btnPeruuta";
            this.btnPeruuta.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            // 
            // cboLanguages
            // 
            this.cboLanguages.FormattingEnabled = true;
            resources.ApplyResources(this.cboLanguages, "cboLanguages");
            this.cboLanguages.Name = "cboLanguages";
            this.cboLanguages.SelectedIndexChanged += new System.EventHandler(this.cboLanguages_SelectedIndexChanged);
            // 
            // lblTunnus
            // 
            resources.ApplyResources(this.lblTunnus, "lblTunnus");
            this.lblTunnus.Name = "lblTunnus";
            // 
            // lblSala
            // 
            resources.ApplyResources(this.lblSala, "lblSala");
            this.lblSala.Name = "lblSala";
            // 
            // textBox2
            // 
            resources.ApplyResources(this.textBox2, "textBox2");
            this.textBox2.Name = "textBox2";
            // 
            // cboTypes
            // 
            this.cboTypes.FormattingEnabled = true;
            resources.ApplyResources(this.cboTypes, "cboTypes");
            this.cboTypes.Name = "cboTypes";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblSala);
            this.Controls.Add(this.lblTunnus);
            this.Controls.Add(this.cboTypes);
            this.Controls.Add(this.cboLanguages);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnPeruuta);
            this.Controls.Add(this.btnUusi);
            this.Controls.Add(this.btnOK);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnUusi;
        private System.Windows.Forms.Button btnPeruuta;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox cboLanguages;
        private System.Windows.Forms.Label lblTunnus;
        private System.Windows.Forms.Label lblSala;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ComboBox cboTypes;
    }
}

