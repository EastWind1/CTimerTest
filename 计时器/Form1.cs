using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace 计时器
{
    public partial class Form1 : Form
    {
        int sec = 0;
        System.Timers.Timer timer;
        bool isPause;

        public Form1()
        {
            isPause = false;
            CheckForIllegalCrossThreadCalls = false;

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (timer != null)
            {
                timer.Stop();
                timer = null;
            }
            if (float.TryParse(textBox1.Text,out float miniate))
            {
                sec = (int)(miniate * 60);
                timer = new System.Timers.Timer(1000);
                timer.Elapsed += new ElapsedEventHandler(timerAction);
                timer.Start();
                button1.Enabled = false;
            }
            else
            {
                MessageBox.Show("请输入整数或小数","数据不合法");
            }
        }

        public void timerAction(object source, ElapsedEventArgs e)
        {       
            sec--;
            label3.Text=printTime(sec);
            if (sec == 0)
            {
                timer.Stop();
            }
        }
        public static String printTime(int sec)
        {
            String outString = "";
            int h = 0, m = 0, s = 0;
            h = sec / 3600;
            m = sec % 3600 / 60;
            s = sec % 60;
            outString = intToString(h) + ":" + intToString(m) + ":" + intToString(s);
            return outString;
        }
        public static String intToString(int num)
        {
            String result = "";
            if (num < 10)
                result = "0" + num;
            else
                result = num.ToString();
            return result;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (timer != null)
            {
                button1.Enabled = true;
                timer.Stop();
                label3.Text = "00:00:00";
            }
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            if (timer != null)
            {
                if (isPause == false)
                {
                    isPause = true;
                    timer.Enabled = false;
                    pauseButton.Text = "继续";
                }
                else
                {
                    timer.Enabled = true;
                    pauseButton.Text = "暂停";
                }
            }    
        }
    }
}
