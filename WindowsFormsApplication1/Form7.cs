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
    public partial class Form7 : Form
    {
        int r;
        int w;
        string zh;
        string id;//课程号
        int id1;//题目号
        public Form7(string id,int id1,string zh,int r,int w)
        {
            this.id = id;
            this.id1 = id1;
            this.zh = zh;
            this.r = r;
            this.w = w;
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.AppSettings["ConnectionString"];
            try
            {
                SqlConnection conn = new SqlConnection(constr);

                conn.Open();
            
               // string cmdStr = "select * from xuanze  where 编号 ='" + id1 + "'";
                string cmdStr = "select * from judge where 课程编号='"+id+"'";
                SqlDataAdapter da = new SqlDataAdapter(cmdStr, conn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                textBox1.Text = ds.Tables[0].Rows[id1][1].ToString();
                textBox2.Text = ds.Tables[0].Rows[id1][2].ToString();
                textBox3.Text = ds.Tables[0].Rows[id1][3].ToString();
              
                //   if(ds.Tables[0].Rows[0][6]==textBox6.Text)用来增加成绩

                conn.Close();

            }
            catch (Exception error)
            {
                MessageBox.Show("" + error);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                MessageBox.Show(this.textBox1, "填空不可以为空");
                return;

            }
            string constr = ConfigurationManager.AppSettings["ConnectionString"];
            try
            {
                SqlConnection conn = new SqlConnection(constr);

                conn.Open();
                string cmdStr = "select * from judge where 课程编号='" + id + "'";
                SqlDataAdapter da = new SqlDataAdapter(cmdStr, conn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (textBox4.Text.ToString() == ds.Tables[0].Rows[id1][4].ToString())
                {
                    MessageBox.Show("恭喜你回答正确！");
                    r++;
                }
                else
                {
                    MessageBox.Show(string.Format("很可惜回答错误，正确答案为{0}!", ds.Tables[0].Rows[id1][4].ToString()), "提示");
                    w++;
                }

                string sql = "SELECT COUNT(*) FROM judge where 课程编号='"+id+"'";
                SqlCommand cmd = new SqlCommand(sql, conn);
              
                //   MessageBox.Show(string.Format("数据库里共有{0}条记录", cmd.ExecuteScalar()), "提示");
                if (id1 >= (Convert.ToInt16(cmd.ExecuteScalar())-1))
                {
                    this.Hide();
                    Form3 form1=new Form3(zh,r,w);
                    form1.Show();
                }
                else
                {
                    this.Hide();
                    //  MessageBox.Show(comboBox1.ValueMember+1);
                    Form7 form = new Form7(id, id1 + 1,zh,r,w);
                    form.Show();
                }
             
            }
            catch (Exception error)
            {
                MessageBox.Show("" + error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 from = new Form3(zh,r,w);
            from.Show();
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
