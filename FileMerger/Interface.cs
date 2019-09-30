using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace FileMerger
{
    public partial class Interface : Form
    {


        private Handler handler = new Handler();

        public Interface()
        {
            InitializeComponent();
        }

        private void Interface_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLoadFiles_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            string File1Str = txfInput1.Text;
            string File2Str = txfInput2.Text;

            //clear the drop downs to prevent dulplicate data and set default selection
            cmbFile1.Items.Clear();
            cmbFile1.Items.Add("please select");
            cmbFile1.SelectedIndex = 0;

            try
            {
                handler.Loader(File1Str, File2Str);
                this.btnBasic.Enabled = true;
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
                this.btnBasic.Enabled = false;
            }


            for (int i = 0; i < handler.getDT1().Columns.Count; i++)
            {
                cmbFile1.Items.Add(handler.getDT1().Columns[i].ColumnName.ToString().ToUpper());
            }

            Cursor.Current = Cursors.Default;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cmbFile2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnMerge(object sender, EventArgs e)
        {

            String mergKey = cmbFile1.SelectedItem.ToString();

            if (mergKey.Equals("please select"))
            {
                MessageBox.Show("You cannot leave 'please select' as the primary key");
            }
            else
            {
                try
                {
                    DialogResult result = saveFileDialog.ShowDialog();

                    this.Focus();

                    if (result == DialogResult.OK)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        string path = saveFileDialog.FileName;
                        handler.MisMatchLogger(mergKey, txfInput1.Text, txfInput2.Text);
                        handler.AutoMatchMerge(mergKey);
                        handler.Writer(handler.getDT3(), path);
                        handler.Writer(handler.getDTMergedRecords(), path.Insert(path.LastIndexOf('.'), " Merged Records Log"));// revisit this idea
                        MessageBox.Show("Files merged successfully");
                        Cursor.Current = Cursors.Default;
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }
            
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Console.Clear();

        }

        private void bntFile1_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                string path = openFileDialog.FileName;
                txfInput1.Text = path;
            }
        }

        private void bntFile2_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                string path = openFileDialog.FileName;
                txfInput2.Text = path;
            }
        }

        private void Automatch_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
