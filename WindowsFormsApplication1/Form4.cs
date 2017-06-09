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
            
        }
    }
}
