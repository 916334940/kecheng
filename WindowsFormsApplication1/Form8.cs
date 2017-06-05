using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            Form8 form = new Form8();

            this.Hide();
            int id = 1;
            MessageBox.Show(id + "登录成功");
            form.Show();
            Form8 form2 = new Form8();

            this.Hide();
            int id1 = 2;
            MessageBox.Show(id + "登录成功");
            form2.Show();
            int count=0;
            count++;

            if (count >= 5)
            {
                MessageBox.Show("您已连续输错密码5次，被迫退出！", "【警告】");

                System.Threading.Thread.Sleep(1000);//等待1秒  

                Application.Exit();
            }
            else
            {
                MessageBox.Show("用户名、密码、登录类型不匹配，请重试！", "【提示】");
            }
           
        }
    }
}
