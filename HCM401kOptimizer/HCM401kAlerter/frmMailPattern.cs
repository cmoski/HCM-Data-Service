using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HCM401kAlerter
{
    public partial class frmMailPattern : Form
    {
        public frmMailPattern()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Configuration.MailPattern = txtPattern.Text;
            Configuration.MailSubject = txtSubject.Text;
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void frmMailPattern_Load(object sender, EventArgs e)
        {
            txtPattern.Text = Configuration.MailPattern;
            txtSubject.Text = Configuration.MailSubject;
        }

    }
}
