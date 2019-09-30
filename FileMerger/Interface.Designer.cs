using System.Windows.Forms;

namespace FileMerger
{
    partial class Interface
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Interface));
            this.txfInput1 = new System.Windows.Forms.TextBox();
            this.txfInput2 = new System.Windows.Forms.TextBox();
            this.lblInput1 = new System.Windows.Forms.Label();
            this.lblInput2 = new System.Windows.Forms.Label();
            this.btnLoadFiles = new System.Windows.Forms.Button();
            this.cmbFile1 = new System.Windows.Forms.ComboBox();
            this.lblDrop1 = new System.Windows.Forms.Label();
            this.btnBasic = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.bntFile1 = new System.Windows.Forms.Button();
            this.bntFile2 = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.lblWarning = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txfInput1
            // 
            this.txfInput1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            resources.ApplyResources(this.txfInput1, "txfInput1");
            this.txfInput1.Name = "txfInput1";
            this.txfInput1.ReadOnly = true;
            this.txfInput1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txfInput2
            // 
            this.txfInput2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            resources.ApplyResources(this.txfInput2, "txfInput2");
            this.txfInput2.Name = "txfInput2";
            // 
            // lblInput1
            // 
            resources.ApplyResources(this.lblInput1, "lblInput1");
            this.lblInput1.Name = "lblInput1";
            // 
            // lblInput2
            // 
            resources.ApplyResources(this.lblInput2, "lblInput2");
            this.lblInput2.Name = "lblInput2";
            // 
            // btnLoadFiles
            // 
            resources.ApplyResources(this.btnLoadFiles, "btnLoadFiles");
            this.btnLoadFiles.Name = "btnLoadFiles";
            this.btnLoadFiles.UseVisualStyleBackColor = true;
            this.btnLoadFiles.Click += new System.EventHandler(this.btnLoadFiles_Click);
            // 
            // cmbFile1
            // 
            this.cmbFile1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFile1.FormattingEnabled = true;
            this.cmbFile1.Items.AddRange(new object[] {
            resources.GetString("cmbFile1.Items")});
            resources.ApplyResources(this.cmbFile1, "cmbFile1");
            this.cmbFile1.Name = "cmbFile1";
            // 
            // lblDrop1
            // 
            resources.ApplyResources(this.lblDrop1, "lblDrop1");
            this.lblDrop1.Name = "lblDrop1";
            // 
            // btnBasic
            // 
            resources.ApplyResources(this.btnBasic, "btnBasic");
            this.btnBasic.Name = "btnBasic";
            this.btnBasic.UseVisualStyleBackColor = true;
            this.btnBasic.Click += new System.EventHandler(this.btnMerge);
            // 
            // btnRefresh
            // 
            resources.ApplyResources(this.btnRefresh, "btnRefresh");
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.AddExtension = false;
            this.openFileDialog.DefaultExt = "csv";
            this.openFileDialog.FileName = "openFileDialog1";
            resources.ApplyResources(this.openFileDialog, "openFileDialog");
            // 
            // bntFile1
            // 
            resources.ApplyResources(this.bntFile1, "bntFile1");
            this.bntFile1.Name = "bntFile1";
            this.bntFile1.UseVisualStyleBackColor = true;
            this.bntFile1.Click += new System.EventHandler(this.bntFile1_Click);
            // 
            // bntFile2
            // 
            resources.ApplyResources(this.bntFile2, "bntFile2");
            this.bntFile2.Name = "bntFile2";
            this.bntFile2.UseVisualStyleBackColor = true;
            this.bntFile2.Click += new System.EventHandler(this.bntFile2_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "CSV|*.csv";
            this.saveFileDialog.FileName = "output.csv";
            resources.ApplyResources(this.saveFileDialog, "saveFileDialog");
            // 
            // lblWarning
            // 
            resources.ApplyResources(this.lblWarning, "lblWarning");
            this.lblWarning.ForeColor = System.Drawing.Color.Red;
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.UseMnemonic = false;
            // 
            // Interface
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblWarning);
            this.Controls.Add(this.bntFile2);
            this.Controls.Add(this.bntFile1);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnBasic);
            this.Controls.Add(this.lblDrop1);
            this.Controls.Add(this.cmbFile1);
            this.Controls.Add(this.btnLoadFiles);
            this.Controls.Add(this.lblInput2);
            this.Controls.Add(this.lblInput1);
            this.Controls.Add(this.txfInput2);
            this.Controls.Add(this.txfInput1);
            this.Name = "Interface";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.Interface_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txfInput1;
        private System.Windows.Forms.TextBox txfInput2;
        private System.Windows.Forms.Label lblInput1;
        private System.Windows.Forms.Label lblInput2;
        private System.Windows.Forms.Button btnLoadFiles;
        private System.Windows.Forms.ComboBox cmbFile1;
        private System.Windows.Forms.Label lblDrop1;
        private System.Windows.Forms.Button btnBasic;
        private System.Windows.Forms.Button btnRefresh;
        private OpenFileDialog openFileDialog;
        private Button bntFile1;
        private Button bntFile2;
        private SaveFileDialog saveFileDialog;
        private Label lblWarning;
    }
}

