using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CK_Sync
{
    public partial class SynPromptDlg : Form
    {
        public string sMessage = "";

        public SynPromptDlg()
        {
            InitializeComponent();
        }

        private void SynPromptDlg_Load(object sender, EventArgs e)
        {
            lab_Message.Text = sMessage;
        }
    }
}
