using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace HisApp
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }



        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        // 设置username变量，便于后续system中查看用户名
        public static string UserName = "";

        private void btn_login_Click(object sender, EventArgs e)
        {

            string str = "server=localhost;user id = root;password=123456;database=myhis";  //参数定义
            MySqlConnection conn = new MySqlConnection(str);  //构造函数，与MySQL连接的，建造与MySQL沟通的桥梁
            conn.Open();  //打开与MySQL连接的路线


            MySqlDataAdapter da = new MySqlDataAdapter("select count(*) from 指定用户登陆表 where 用户名 = '" + txt_name.Text + "' and 密码 = '" + txt_password.Text + "'",conn);
            DataTable dt = new DataTable();
            da.Fill(dt);


            if (dt.Rows[0][0].ToString() == "1")
            {
                UserName = txt_name.Text;
                system obj = new system();
                obj.Show();
                this.Hide();
                conn.Close();
            }
            else
            {
                MessageBox.Show("用户名或密码错误！！！");
            }
            conn.Close();
        }

       
    }
}
