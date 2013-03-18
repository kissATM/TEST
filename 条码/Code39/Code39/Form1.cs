using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Code39
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DeltaCat.BarCode.Code39 c39 = new DeltaCat.BarCode.Code39();
            c39.BarCodeValue = this.textBox1.Text;
            c39.Label = this.textBox2.Text;
            c39.AdditionalInfo = this.textBox3.Text;
            c39.ShowBarCodeValue = this.checkBox1.Checked;
            this.pictureBox1.Image = Image.FromStream(c39.CreateWinForm(System.Drawing.Imaging.ImageFormat.Gif));
            c39 = null;
        }
    }
}