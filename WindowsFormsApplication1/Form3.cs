using System;
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
    public partial class Form3 : Form
    {
        int r;
        int w;
        string zh="";
        public Form3(string id,int r,int w)
        {
            this.zh = id;
            this.r = r;
            this.w = w;
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            label3.Text= "当前系统时间为：" + time.ToString();
            string constr = ConfigurationManager.AppSettings["ConnectionString"];
            try
            {
                SqlConnection conn = new SqlConnection(constr);
                int id = this.comboBox1.Items.Count + 1;
                conn.Open();
                string cmdStr = "select 名称 from course";
                SqlDataAdapter da = new SqlDataAdapter(cmdStr, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    comboBox1.Items.Insert(i, dt.Rows[i][0]);
                }
                comboBox1.SelectedIndex = 0;
                conn.Close();


            }
            catch (Exception error)
            {
                MessageBox.Show("" + error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            //  MessageBox.Show(comboBox1.ValueMember+1);
            Form6 form = new Form6(Convert.ToString(comboBox1.SelectedIndex+1),0,zh,0,0);
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            
            Form7 form = new Form7(Convert.ToString(comboBox1.SelectedIndex+1), 0,zh,0,0);
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if((r+w)==0)
                MessageBox.Show("当前正确率为0" );
            else
            MessageBox.Show("当前正确题数为"+r);
        }

        private void button5_Click(object sender, EventArgs e)
        {
           

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
