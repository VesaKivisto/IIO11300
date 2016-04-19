using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using System.Resources;

namespace Tehtava12
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitStuff();
        }

        public void InitStuff()
        {
            string[] languages = new string[2] { "Finnish", "English" };
            foreach (string language in languages)
            {
                cboLanguages.Items.Add(language);
            }
            cboLanguages.SelectedIndex = 0;

            string[] types = new string[3] { "XML", "SSL", "ASD" };
            foreach (string type in types)
            {
                cboTypes.Items.Add(type);
            }
        }

        private void cboLanguages_SelectedIndexChanged(object sender, EventArgs e)
        {
            string language = cboLanguages.SelectedItem.ToString();
            if (language == "Finnish")
            {
                ResourceManager LocRM = new ResourceManager("Tehtava12.WinFormStrings", typeof(Form1).Assembly);
                lblTunnus.Text = LocRM.GetString("lblTunnus");
                lblSala.Text = LocRM.GetString("lblSala");
                btnPeruuta.Text = LocRM.GetString("btnPeruuta");
                btnUusi.Text = LocRM.GetString("btnUusi");
            }
            else if (language == "English")
            {
                ResourceManager LocRM = new ResourceManager("Tehtava12.WinFormStrings-en-GB", typeof(Form1).Assembly);
                lblTunnus.Text = LocRM.GetString("lblTunnus");
                lblSala.Text = LocRM.GetString("lblSala");
                btnPeruuta.Text = LocRM.GetString("btnPeruuta");
                btnUusi.Text = LocRM.GetString("btnUusi");
            }
        }
    }
}
