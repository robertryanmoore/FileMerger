using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileMerger
{
    public partial class ProgressWindow : Form
    {
        public ProgressWindow()
        {
            InitializeComponent();
        }

        private void ProgressWindow_Load(object sender, EventArgs e)
        {

        }

        public void ProgressBar1_Click(object sender, EventArgs e)
        {

        }

        public void setProgressBarMax(int max) {
            progressBar1.Maximum = max;
        }

        public void setProgressBarMin(int min) {
            progressBar1.Minimum = min;
        }

        public void setProgressBarValue(int value) {
            progressBar1.Value = value;
        }

        public void setLabelText(string text) {
            lblPercent.Text = text;
            lblPercent.Refresh();
        }
    }
}
