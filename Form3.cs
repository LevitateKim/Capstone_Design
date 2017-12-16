using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace test
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen; // 시작위치 중앙

            InitializeComponent();

            Manual0.Show();
            Manual0_R.Show();

            Manual1.Hide();
            Manual1_L.Hide();
            Manual1_R.Hide();

            Manual2.Hide();
            Manual2_L.Hide();
            Manual2_R.Hide();

            Manual3.Hide();
            Manual3_L.Hide();
            Manual3_R.Hide();

            Manual4.Hide();
            Manual4_L.Hide();
            Manual4_R.Hide();

            Manual5.Hide();
            Manual5_L.Hide();
            Manual5_R.Hide();

            Manual6.Hide();
            Manual6_L.Hide();
            Manual6_R.Hide();

            Manual7.Hide();
            Manual7_L.Hide();
            Manual7_R.Hide();

            Manual8.Hide();
            Manual8_L.Hide();
        }        

        private void Manual0_R_Click(object sender, EventArgs e)
        {
            Manual0.Hide();
            Manual0_R.Hide();
            Manual1.Show();
            Manual1_L.Show();
            Manual1_R.Show();
        }

        private void Manual1_L_Click(object sender, EventArgs e)
        {
            Manual0.Show();
            Manual0_R.Show();
            Manual1.Hide();
            Manual1_L.Hide();
            Manual1_R.Hide();
        }

        private void Manual1_R_Click(object sender, EventArgs e)
        {
            Manual1.Hide();
            Manual1_L.Hide();
            Manual1_R.Hide();
            Manual2.Show();
            Manual2_L.Show();
            Manual2_R.Show();
        }

        private void Manual2_L_Click(object sender, EventArgs e)
        {
            Manual1.Show();
            Manual1_L.Show();
            Manual1_R.Show();
            Manual2.Hide();
            Manual2_L.Hide();
            Manual2_R.Hide();
        }

        private void Manual2_R_Click(object sender, EventArgs e)
        {
            Manual3.Show();
            Manual3_L.Show();
            Manual3_R.Show();
            Manual2.Hide();
            Manual2_L.Hide();
            Manual2_R.Hide();
        }

        private void Manual3_L_Click(object sender, EventArgs e)
        {
            Manual3.Hide();
            Manual3_L.Hide();
            Manual3_R.Hide();
            Manual2.Show();
            Manual2_L.Show();
            Manual2_R.Show();
        }

        private void Manual3_R_Click(object sender, EventArgs e)
        {
            Manual3.Hide();
            Manual3_L.Hide();
            Manual3_R.Hide();
            Manual4.Show();
            Manual4_L.Show();
            Manual4_R.Show();
        }

        private void Manual4_L_Click(object sender, EventArgs e)
        {
            Manual4.Hide();
            Manual4_L.Hide();
            Manual4_R.Hide();
            Manual3.Show();
            Manual3_L.Show();
            Manual3_R.Show();
        }

        private void Manual4_R_Click(object sender, EventArgs e)
        {
            Manual4.Hide();
            Manual4_L.Hide();
            Manual4_R.Hide();
            Manual5.Show();
            Manual5_L.Show();
            Manual5_R.Show();
        }

        private void Manual5_L_Click(object sender, EventArgs e)
        {
            Manual5.Hide();
            Manual5_L.Hide();
            Manual5_R.Hide();
            Manual4.Show();
            Manual4_L.Show();
            Manual4_R.Show();
        }

        private void Manual5_R_Click(object sender, EventArgs e)
        {
            Manual5.Hide();
            Manual5_L.Hide();
            Manual5_R.Hide();
            Manual6.Show();
            Manual6_L.Show();
            Manual6_R.Show();
        }

        private void Manual6_L_Click(object sender, EventArgs e)
        {
            Manual6.Hide();
            Manual6_L.Hide();
            Manual6_R.Hide();
            Manual5.Show();
            Manual5_L.Show();
            Manual5_R.Show();
        }

        private void Manual6_R_Click(object sender, EventArgs e)
        {
            Manual6.Hide();
            Manual6_L.Hide();
            Manual6_R.Hide();
            Manual7.Show();
            Manual7_L.Show();
            Manual7_R.Show();
        }

        private void Manual7_L_Click(object sender, EventArgs e)
        {
            Manual7.Hide();
            Manual7_L.Hide();
            Manual7_R.Hide();
            Manual6.Show();
            Manual6_L.Show();
            Manual6_R.Show();
        }

        private void Manual7_R_Click(object sender, EventArgs e)
        {
            Manual7.Hide();
            Manual7_L.Hide();
            Manual7_R.Hide();
            Manual8.Show();
            Manual8_L.Show();
        }

        private void Manual8_L_Click(object sender, EventArgs e)
        {
            Manual8.Hide();
            Manual8_L.Hide();
            Manual7.Show();
            Manual7_L.Show();
            Manual7_R.Show();
        }       
    }
}
