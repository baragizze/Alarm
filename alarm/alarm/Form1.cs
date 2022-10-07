using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Media;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace alarm
{
    public partial class Form1 : Form
    {
        Timer timer01 = new Timer();
        SoundPlayer sp = new SoundPlayer("C:/Users/baragizze/source/repos/alarm/alarm/sound/1.wav");
        bool al = false;
        

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button2.Enabled = false;
            timer01.Interval = 1000;
            timer01.Tick += new EventHandler(timer1_Tick);
            timer01.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.Hour.ToString("00") + ":" + DateTime.Now.Minute.ToString("00") + ":" + DateTime.Now.Second.ToString("00");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (al == false)
            {
                bool errorCheck = false;
                label2.Text = maskedTextBox1.Text;
                timer2.Start();
                string val = label2.Text;
                for (int i = 0; i < val.Length; ++i)
                    { // 49 -> 1
                    if (i == 0) if (Convert.ToInt32(val[i]) > 50) { MessageBox.Show("Ошибка ввода времени!"); errorCheck = true; break; }
                    if (i == 1) if ((Convert.ToInt32(val[i - 1]) == 50) & (Convert.ToInt32(val[i]) > 51)) { MessageBox.Show("Ошибка ввода времени!"); errorCheck = true; break; }
                    if (i == 3) if (Convert.ToInt32(val[i]) > 53) { MessageBox.Show("Ошибка ввода времени!"); errorCheck = true; break; }
                    if (val[i] == ' ') { MessageBox.Show("Ошибка ввода времени!"); errorCheck = true; break; }
                }
                if (errorCheck == true) { al = false; maskedTextBox1.Visible = true; }
                else {
                    maskedTextBox1.Visible = false;
                    button1.Text = "Убрать будильник";
                    al = true;
                }
            }

            else if (al == true)
            {
                label2.Text = "00:00";
                timer2.Stop();
                maskedTextBox1.Visible = true;
                button1.Text = "Завести будильник";
                al = false;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (label1.Text == label2.Text + ":00")
            {
                button2.Enabled = true;
                button1.Enabled = false;
                sp.PlayLooping();
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sp.Stop();
            button2.Enabled = false;
            button1.Enabled = true;
            maskedTextBox1.Visible = true;
            button1.Text = "Завести будильник";
            al = false;
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}