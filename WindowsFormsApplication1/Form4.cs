﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace WindowsFormsApplication1
{
    public partial class Form4 : Form
    {
        string id;
        string zh;
        public Form4(string id,string zh)
        {
            this.id = id;
            this.zh = zh;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.AppSettings["ConnectionString"];
            try
            {
                SqlConnection conn = new SqlConnection(constr);

                conn.Open();
                
                string cmdStr1 = "insert xc values('" + textBox1.Text.Trim() + "','" + id + "')";
                SqlCommand cmd1 = new SqlCommand(cmdStr1, conn);
                cmd1.ExecuteNonQuery();

                MessageBox.Show(id);
                string cmdStr = "insert xuanze values( '" + textBox1.Text.Trim() +
                "','" + textBox2.Text.Trim() + "','" + textBox3.Text.Trim() +
                "','" + textBox4.Text.Trim() + "','" + textBox5.Text.Trim() +
                "','" + textBox6.Text.Trim() + "','" + textBox7.Text.Trim() + "','" + id + "')";
                SqlCommand cmd = new SqlCommand(cmdStr, conn);
                if (cmd.ExecuteNonQuery() == 0)
                {
                    MessageBox.Show("未知错误!");
                    return;
                }
                else
                {
                    this.Hide();
                    Form2 form = new Form2(zh);
                    form.Show();
                    MessageBox.Show("增加课程成功");
                }


                conn.Close();

            }
            catch (Exception error)
            {
                MessageBox.Show("" + error);
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.AppSettings["ConnectionString"];
            try
            {
                SqlConnection conn = new SqlConnection(constr);

                conn.Open();

                string cmdStr1 = "select count(*) from xuanze";
                SqlDataAdapter da = new SqlDataAdapter(cmdStr1, conn);
                DataSet ds = new DataSet();
                 da.Fill(ds);
                int id22 = Convert.ToInt16( ds.Tables[0].Rows[0][0]);

                MessageBox.Show("当前选择题数有"+id22+"个");
               


                conn.Close();

            }
            catch (Exception error)
            {
                MessageBox.Show("" + error);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form = new Form2(zh);
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form8 form = new Form8();

            this.Hide();
            int id = 1;
            MessageBox.Show(id + "登录成功");
            form.Show();
            Form8 form2 = new Form8();
            MessageBox.Show("1");
            this.Hide();
            int id1 = 2;
            MessageBox.Show(id1 + "登录成功");
            form2.Show();
            int count = 0;
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
