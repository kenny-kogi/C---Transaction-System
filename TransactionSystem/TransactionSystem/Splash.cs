﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TransactionSystem
{
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        int startpoint = 0;
        
        private void timer1_Tick(object sender, EventArgs e)
        {

            startpoint += 1;
            MyProgress.Value = startpoint;
            if (MyProgress.Value == 100) {
                MyProgress.Value = 0;
                timer1.Stop();
                Form1 log = new Form1();
                this.Hide();
                log.Show();
            }
        }

        private void Splash_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
