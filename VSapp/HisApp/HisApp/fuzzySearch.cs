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
    public partial class fuzzySearch : Form
    {
        public fuzzySearch()
        {
            InitializeComponent();
        }

        
        // 模糊查询
        private void button1_Click(object sender, EventArgs e)
        {

            string str = "server=localhost;user id = root;password=123456;database=myhis";  //参数定义
            MySqlConnection conn = new MySqlConnection(str);  //构造函数，与MySQL连接的，建造与MySQL沟通的桥梁
            conn.Open();  //打开与MySQL连接的路线


            // 变量与常量同时存在，常量（如：字符类型）需要用单引号
            string strcmd = " select * from 患者基本信息表 where 姓名 like '%" + txt_name0.Text.ToString() + "%' order by 编号";

            // MySQL命令
            MySqlCommand cmd = new MySqlCommand(strcmd, conn);

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);  //适配器：接受查询的结果

            DataSet ds = new DataSet();  //数据集对象,数据集中可以有1至n张表;若放进去的仅是一个数值，也会作为表格
            da.Fill(ds);  // 将适配器查询到的结果放入到数据集中

            dataGridView1.DataSource = ds.Tables[0];  //数据集中编号为0的表


            conn.Close();
        }


        // 添加患者信息
        private void btn_add_click_Click(object sender, EventArgs e)
        {
            
            string str = "server=localhost;user id = root;password=123456;database=myhis";  //参数定义
            MySqlConnection conn = new MySqlConnection(str);  //构造函数，与MySQL连接的，建造与MySQL沟通的桥梁
            conn.Open();  //打开与MySQL连接的路线

            // 在sql语句前添加@符号作用：使编码语句都是字符串
            // 如：string numcmd =@ "select count(*)+1 from myhis.病人基本信息表";
            string numcmd = "select count(*)+1 from myhis.患者基本信息表";


            // mysql命令
            MySqlCommand cmd = new MySqlCommand(numcmd, conn);

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);  //适配器：接受查询的结果

            DataSet ds = new DataSet();  //数据集对象,数据集中可以有1至n张表;若放进去的仅是一个数值，也2会作为表格
            da.Fill(ds);  // 将适配器查询到的结果放入到数据集中

            string patientid = ds.Tables[0].Rows[0][0].ToString();//取出第一个单元格里的数据(表是二维的，采用二维标号的形式取)
            // .tostring():用于将数据转换为字符串型；未添加此之前是对象型数据
            // console.writeline("编号：" + patientid);

            patientid = "p" + patientid;
            // 此处后面的引用值的顺序必须与数据表的字段数据顺序保持一致
            // 字符类型需要用单引号括起来，整数型int不需要
            // 通过添加双引号，使引用的变量变为常量
            // 通过+...+的用法，引入该字段值的变量
            string str1 = "insert into 患者基本信息表 values ('" + patientid + "' , '" + txt_name.Text + "',  '" + txt_sex.Text + "',   " + txt_age.Text + ",  '" + txt_phone.Text + "') ";
            MySqlCommand cmd1 = new MySqlCommand(str1, conn);
            MySqlDataAdapter da1 = new MySqlDataAdapter(cmd1);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);

            conn.Close();
    
            
        }

        

        // 删除患者信息
        private void btn_delete_click_Click(object sender, EventArgs e)
        {
            
            string str = "server=localhost;user id = root;password=123456;database=myhis";  //参数定义
            MySqlConnection conn = new MySqlConnection(str);  //构造函数，与mysql连接的，建造与mysql沟通的桥梁
            conn.Open();  //打开与mysql连接的路线

            // 从当前的表格中选中某个单元格的值
            string id = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value);
            // console.writeline("编号：" + id);    //该语句用于查看是否得到该值

            string str1 = "delete from 患者基本信息表 where 编号 = '" + id + "'";
            MySqlCommand cmd = new MySqlCommand(str1, conn);  //数据库命令
            int x = cmd.ExecuteNonQuery();

            // 删除这里没有数据适配器，直接返回命令看是否删除成功
            if (x == 0)
            {
                MessageBox.Show("删除失败");
            }
            else
            {
                MessageBox.Show("删除成功");
            }
            
        }


        // 更新患者信息
        private void btn_update_Click(object sender, EventArgs e)
        {
            
            string str = "server=localhost;user id = root;password=123456;database=myhis";  //参数定义
            MySqlConnection conn = new MySqlConnection(str);  //构造函数，与mysql连接的，建造与mysql沟通的桥梁
            conn.Open();  //打开与mysql连接的路线

            string id = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value);
            string str1 = "update 患者基本信息表 set 姓名 = '" + txt_name.Text + "', 性别 = '" + txt_sex.Text + "', 年龄 = " + txt_age.Text + ",  电话 = '" + txt_phone.Text + "' where 编号 = '" + id + "' ";

            MySqlCommand cmd = new MySqlCommand(str1, conn);
            cmd.ExecuteNonQuery();

            MessageBox.Show("更新成功！");
            conn.Close();
            
            
        }

        // 退出
        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }

    
}
