using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {

       

        public Form1()
        {
            InitializeComponent();
        }
        delegate void dodawanie();

        private void button1_Click(object sender, EventArgs e)
        {

            Graphics obj;
            obj = this.CreateGraphics();
            Pen myPen = new Pen(Color.Yellow, 20);
            obj.DrawLine(myPen, 0, 340, 500, 340);


            string command = "/c ping " + textBox1.Text;
                ProcessStartInfo jakiProces = new ProcessStartInfo("CMD", command);
                Process proc = new Process();
                proc.StartInfo = jakiProces;
                jakiProces.RedirectStandardOutput = true;
                jakiProces.UseShellExecute = false;
                jakiProces.CreateNoWindow = true;
               
                proc.OutputDataReceived += new DataReceivedEventHandler(linia);

                proc.Start();
                proc.BeginOutputReadLine();

        }

        public void linia(object sender, DataReceivedEventArgs e)
        {
            if ((e.Data != null ) )
            {
                string nowalinia = e.Data.Trim() + Environment.NewLine;
               
                void Dodawan()
                {
                    richTextBox1.Text += nowalinia;
                }

                dodawanie dod = new dodawanie(Dodawan);
                richTextBox1.Invoke(dod);

            }
        }
    }
    
}
