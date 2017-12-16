using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Media.Imaging;


namespace test
{
    public partial class Form2 : Form
    {        
        int minutes;

        public Form2()
        {
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen; // 시작위치 중앙

            InitializeComponent();
            //Stage2.Hide();
            //Stage3.Hide();
        }       

        private int Form2_value; // 받는 변수

        public int Passvalue
        {
            get { return this.Form2_value; }
            set { this.Form2_value = value; } //Form1에서 전달받은 값을 쓰기
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            int stage;
            stage = Passvalue; // Form1에서 전달받은 값을 변수에 저장
            Print(stage);
        }

        public void Print(int stage)
        {         
            if (stage == 1)
            {
                textBox1.Hide(); Ex_Input.Hide(); pictureBox2.Hide();
            }
            else if (stage == 2)
            {
                textBox1.Hide(); Ex_Input.Hide(); pictureBox2.Hide();
                Stage1.Hide();
            }
            else if (stage == 3)
            {
                textBox1.Hide(); Ex_Input.Hide(); pictureBox2.Hide();
                Stage1.Hide(); Stage2.Hide();
            }
            else if (stage == 4)
            {
                textBox1.Hide(); Ex_Input.Hide(); pictureBox2.Hide();
                Stage1.Hide(); Stage2.Hide(); Stage3.Hide();
            }
            else if (stage == 5)
            {
                textBox1.Hide(); Ex_Input.Hide(); pictureBox2.Hide();
                Stage1.Hide(); Stage2.Hide(); Stage3.Hide(); Stage4.Hide();
            }
            else if (stage == 6)
            {
                textBox1.Hide(); Ex_Input.Hide(); pictureBox2.Hide();
                Stage1.Hide(); Stage2.Hide(); Stage3.Hide(); Stage4.Hide(); Stage5.Hide();
            }
            else if (stage == 7)
            {
                textBox1.Hide(); Ex_Input.Hide(); pictureBox2.Hide();
                Stage1.Hide(); Stage2.Hide(); Stage3.Hide(); Stage4.Hide(); Stage5.Hide(); Stage6.Hide();
            }
            else if (stage == 8)
            {
                textBox1.Hide(); Ex_Input.Hide(); pictureBox2.Hide();
                Stage1.Hide(); Stage2.Hide(); Stage3.Hide(); Stage4.Hide(); Stage5.Hide(); Stage6.Hide();
                Stage7.Hide();
            }
            else if (stage == 9)
            {
                textBox1.Hide(); Ex_Input.Hide(); pictureBox2.Hide();
                Stage1.Hide(); Stage2.Hide(); Stage3.Hide(); Stage4.Hide(); Stage5.Hide(); Stage6.Hide();
                Stage7.Hide(); Stage8.Hide();
            }
            else if (stage == 10)
            {
                textBox1.Hide(); Ex_Input.Hide(); pictureBox2.Hide();
                Stage1.Hide(); Stage2.Hide(); Stage3.Hide(); Stage4.Hide(); Stage5.Hide(); Stage6.Hide();
                Stage7.Hide(); Stage8.Hide(); Stage9.Hide();
            }
            else if (stage == 11)
            {
                textBox1.Hide(); Ex_Input.Hide(); pictureBox2.Hide();
                Stage1.Hide(); Stage2.Hide(); Stage3.Hide(); Stage4.Hide(); Stage5.Hide(); Stage6.Hide();
                Stage7.Hide(); Stage8.Hide(); Stage9.Hide(); Stage10.Hide();
            }
            else if (stage == 12)
            {
                textBox1.Hide(); Ex_Input.Hide(); pictureBox2.Hide();
                Stage1.Hide(); Stage2.Hide(); Stage3.Hide(); Stage4.Hide(); Stage5.Hide(); Stage6.Hide();
                Stage7.Hide(); Stage8.Hide(); Stage9.Hide(); Stage10.Hide(); Stage11.Hide();
            }
            else if (stage == 100) // 숙련자
            {
                pictureBox1.Hide();
                Stage1.Hide(); Stage2.Hide(); Stage3.Hide(); Stage4.Hide(); Stage5.Hide(); Stage6.Hide();
                Stage7.Hide(); Stage8.Hide(); Stage9.Hide(); Stage10.Hide(); Stage11.Hide(); Stage12.Hide();

            }
            else
            {
                textBox1.Hide(); Ex_Input.Hide(); pictureBox2.Hide();
                Stage1.Hide(); Stage2.Hide(); Stage3.Hide(); Stage4.Hide(); Stage5.Hide(); Stage6.Hide();
                Stage7.Hide(); Stage8.Hide(); Stage9.Hide(); Stage10.Hide(); Stage11.Hide(); Stage12.Hide();
            }
        }
        
        private void Ex_Input_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("입력을 확인해주세요");
                return;
            }

            Passvalue = Convert.ToInt32(textBox1.Text); // 분 전송
            this.Hide();
        }

        //뒤로가기
        private void Back_Click(object sender, EventArgs e)
        {
            minutes = 0;
            Passvalue = minutes; //Form1로 분 전달
            this.Close();
        }

        private void Stage1_Click(object sender, EventArgs e)
        {
            minutes = 5;
            Passvalue = minutes; //Form1로 분 전달
            this.Close();
        }

        private void Stage2_Click(object sender, EventArgs e)
        {
            minutes = 10;
            Passvalue = minutes; //Form1로 분 전달
            this.Close();
        }

        private void Stage3_Click(object sender, EventArgs e)
        {
            minutes = 15;
            Passvalue = minutes; //Form1로 분 전달
            this.Close();
        }

        private void Stage4_Click(object sender, EventArgs e)
        {
            minutes = 20;
            Passvalue = minutes; //Form1로 분 전달
            this.Close();
        }

        private void Stage5_Click(object sender, EventArgs e)
        {
            minutes = 25;
            Passvalue = minutes; //Form1로 분 전달
            this.Close();
        }

        private void Stage6_Click(object sender, EventArgs e)
        {
            minutes = 30;
            Passvalue = minutes; //Form1로 분 전달
            this.Close();
        }

        private void Stage7_Click(object sender, EventArgs e)
        {
            minutes = 35;
            Passvalue = minutes; //Form1로 분 전달
            this.Close();
        }

        private void Stage8_Click(object sender, EventArgs e)
        {
            minutes = 40;
            Passvalue = minutes; //Form1로 분 전달
            this.Close();
        }

        private void Stage9_Click(object sender, EventArgs e)
        {
            minutes = 45;
            Passvalue = minutes; //Form1로 분 전달
            this.Close();
        }

        private void Stage10_Click(object sender, EventArgs e)
        {
            minutes = 50;
            Passvalue = minutes; //Form1로 분 전달
            this.Close();
        }

        private void Stage11_Click(object sender, EventArgs e)
        {
            minutes = 55;
            Passvalue = minutes; //Form1로 분 전달
            this.Close();
        }

        private void Stage12_Click(object sender, EventArgs e)
        {
            minutes = 60;
            Passvalue = minutes; //Form1로 분 전달
            this.Close();
        }
    }
}
