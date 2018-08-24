using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using ZXing;//EL 
using System.IO;
namespace Lector_y_Generador_QR
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txtTextoQR.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            { 
                //Zsinging
                BarcodeWriter br = new BarcodeWriter();
                br.Format = BarcodeFormat.QR_CODE;
                Bitmap bm = new Bitmap(br.Write(textBox1.Text),150,150);
                PboxCodigoGenerado.Image = bm;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "Imagen png|*.png",
                
            InitialDirectory = @"C:\Users\Naz-Dell\source\repos\Lector_y_Generador_QR\Lector_y_Generador_QR\bin\Debug\Codigos"
            };
            if (sfd.ShowDialog()==DialogResult.OK)
            {
                PboxCodigoGenerado.Image.Save(sfd.FileName);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "Imagen png|*.png",
                InitialDirectory = @"C:\Users\Naz-Dell\source\repos\Lector_y_Generador_QR\Lector_y_Generador_QR\bin\Debug\Codigos"
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(ofd.FileName);
                BarcodeReader br = new BarcodeReader();
                string text = br.Decode((Bitmap)pictureBox1.Image).ToString();
                txtTextoQR.Text = text;
            }
        }

        private void txtTextoQR_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
