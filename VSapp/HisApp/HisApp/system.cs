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
    public partial class system : Form
    {
        public system()
        {
            InitializeComponent();
        }

        // 封装一个共享调用MySQL的函数
        // 使其是共享的，采用public
        // 在当前的类使用时，定义一个静态方法static
        // 返回值：空值void
        // 此处返回一个数据表格 DataTable
        // sqlCom：执行一条sql语句
        // strsql：将sql语句作为参数传输进来
        public static DataTable sqlCom(string strsql)
        {
            string str = "server=localhost;user id = root;password=123456;database=myhis";  //参数定义
            MySqlConnection conn = new MySqlConnection(str);  //构造函数，与MySQL连接的，建造与MySQL沟通的桥梁
            conn.Open();  //打开与MySQL连接的路线



            // MySQL命令
            MySqlCommand cmd = new MySqlCommand(strsql, conn);

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);  //适配器：接受查询的结果

            DataSet ds = new DataSet();  //数据集对象,数据集中可以有1至n张表;若放进去的仅是一个数值，也会作为表格
            da.Fill(ds);  // 将适配器查询到的结果放入到数据集中

            //关闭连接
            conn.Close();

            //返回结果
            return ds.Tables[0];
        }







        /**
         * 
         *   模糊查询系统
         * 
         * 
         * 
         * */
        // 模糊查询
        private void bnt_submit_Click(object sender, EventArgs e)
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
        private void btn_exit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }






        // ***********************************************************************************************************************************************
        /**
         * 
         * 
         *  ①挂号系统
         * 
         * */
        private void cb_part_Click(object sender, EventArgs e)
        {
            string strcmd = "select * from 科室信息表";
            DataTable dt = sqlCom(strcmd);
            cb_part.DataSource = dt;
            cb_part.DisplayMember = "名称";  // 展示表的“名称”字段的值
            cb_part.ValueMember = "编号";   //获得所选“名称”对应的编号信息
        }

        

        private void cb_doctor_Click(object sender, EventArgs e)
        {
            string strcmd = "select * from 医生信息表";
            DataTable dt = sqlCom(strcmd);
            cb_doctor.DataSource = dt;
            cb_doctor.DisplayMember = "姓名";
            cb_doctor.ValueMember = "姓名";  //选择下拉列表的值，获得了这个值所对应的编号信息
        }


        // 查询挂号信息
        private void btn_search01_Click(object sender, EventArgs e)
        {


            string strcmd =

                @"select 挂号信息表.编号 as 就诊号,  挂号信息表.病人编号,  挂号信息表.姓名,  挂号信息表.性别,  患者基本信息表.年龄,  挂号信息表.挂号费用,  挂号信息表.时间,

                医生信息表.姓名 as 医生,  科室信息表.名称 as 科室 

                from 挂号信息表,  患者基本信息表,  医生信息表,  科室信息表
                where 挂号信息表.病人编号 = 患者基本信息表.编号  and  挂号信息表.医生 = 医生信息表.姓名  and  挂号信息表.挂号科室 = 科室信息表.编号 
                and 挂号信息表.姓名 like '%" + txt_name00.Text.ToString() + "%' order by 挂号信息表.编号 ";


            dataGridView_register.DataSource = sqlCom(strcmd);

        }



        // 删除挂号信息
        private void btn_delete_Click(object sender, EventArgs e)
        {
            string str = "server=localhost;user id = root;password=123456;database=myhis";  //参数定义
            MySqlConnection conn = new MySqlConnection(str);  //构造函数，与mysql连接的，建造与mysql沟通的桥梁
            conn.Open();  //打开与mysql连接的路线

            // 从当前的表格中选中某个单元格的值
            string idRegister = Convert.ToString(dataGridView_register.CurrentRow.Cells[0].Value);
            string idPatient = Convert.ToString(dataGridView_register.CurrentRow.Cells[1].Value);


            string str1 = "delete from 挂号信息表 where 编号 = '" + idRegister + "'";
            string str2 = "delete from 患者基本信息表 where 编号 = '" + idPatient + "'";

            MySqlCommand cmd1 = new MySqlCommand(str1, conn);  //数据库命令
            MySqlCommand cmd2 = new MySqlCommand(str2, conn);  //数据库命令

            // 执行命令
            cmd2.ExecuteNonQuery();
            int x = cmd1.ExecuteNonQuery();

            // 删除这里没有数据适配器，直接返回命令看是否删除成功
            if (x == 0)
            {
                MessageBox.Show("患者信息删除失败");
            }
            else
            {
                MessageBox.Show("患者信息删除成功");
            }
        }



        //定义一个用来生成信息的患者编号的方法
        public static string patientID()
        {
            string strcmd = "select count(*)+1 from 患者基本信息表";
            DataTable dt = sqlCom(strcmd);
            string patientId = "p" + dt.Rows[0][0].ToString();
            return patientId;

        }


        //定义一个用来生成新的挂号编号的方法
        public static string  registerID()
        {
            string strcmd = "select count(*)+1 from 挂号信息表";
            DataTable dt = sqlCom(strcmd);
            string registerId = "z" + dt.Rows[0][0].ToString();
            return registerId;
        }




        // inreginf()写入到挂号信息表的方法
        public void inreginf(string registerId, string patientId)
        {
            string str = "server=localhost;user id = root;password=123456;database=myhis";  //参数定义
            MySqlConnection conn = new MySqlConnection(str);  //构造函数，与mysql连接的，建造与mysql沟通的桥梁
            conn.Open();  //打开与mysql连接的路线

            Console.WriteLine(registerId);
            Console.WriteLine(patientId);
            Console.WriteLine(txt_name01.Text);
            Console.WriteLine(cb_sex.SelectedItem);
            Console.WriteLine(cb_part.SelectedValue);
            Console.WriteLine(txt_fee.Text);
            Console.WriteLine(cb_doctor.SelectedValue);

            string r1 = registerId;
            string r2 = patientId;
            string r3 = txt_name01.Text;
            string r4 = Convert.ToString(cb_sex.SelectedItem);
            string r5 = Convert.ToString(cb_part.SelectedValue);
            string r6 = txt_fee01.Text;
            string r7 = Convert.ToString(cb_doctor.SelectedValue);

            string str1 = "insert into 挂号信息表 values ('" + r1 + "' ,'" + r2 + "', '" + r3 + "' ,  '" + r4 + "'  , '" + r5 + "'  , '" + r6 + "'  , '" + r7 + "' , now() ) ";

            MySqlCommand cmd = new MySqlCommand(str1, conn);
            cmd.ExecuteNonQuery();

            conn.Close();
        }



        // inpatinf() 写入患者基本信息表的方法
        public void inpatinf(string patientId)
        {
            string str = "server=localhost;user id = root;password=123456;database=myhis";  //参数定义
            MySqlConnection conn = new MySqlConnection(str);  //构造函数，与mysql连接的，建造与mysql沟通的桥梁
            conn.Open();  //打开与mysql连接的路线

            string str1 = "insert into 患者基本信息表 values ('" + patientId + "' , '" + txt_name01.Text + "' , '" + cb_sex.SelectedItem + "' ,  '" + txt_age01.Text + "' ,  '" + txt_phone01.Text + "') ";

            MySqlCommand cmd = new MySqlCommand(str1, conn);
            cmd.ExecuteNonQuery();

            conn.Close();
        }




        // 挂号+编号增加
        private void btn_register_Click(object sender, EventArgs e)
        {
            string patientId = patientID();
            string registerId = registerID();

            inpatinf(patientId);
            inreginf(registerId, patientId);

            MessageBox.Show("挂号成功");
        }

        





        







        // ***********************************************************************************************************************************************
        /**
         * 
         * 
         *  ②科室查询系统
         * 
         * */

        // 生成科室编号
        public static string partID()
        {
            string strcmd = "select count(*)+1 from 科室信息表";
            DataTable dt = sqlCom(strcmd);
            string partId = "dp" + dt.Rows[0][0].ToString();
            return partId;
        }


        // 查询科室
        private void btn_partQuery_Click(object sender, EventArgs e)
        {

            string strcmd = @" select * from 科室信息表 where 名称 like '%" + txt_partName.Text.ToString() + "%' order by 编号";
            dataGridView_part.DataSource = sqlCom(strcmd);

        }


        //添加科室
        private void btn_partAdd_Click(object sender, EventArgs e)
        {
            string str = "server=localhost;user id = root;password=123456;database=myhis";  //参数定义
            MySqlConnection conn = new MySqlConnection(str);  //构造函数，与mysql连接的，建造与mysql沟通的桥梁
            conn.Open();  //打开与mysql连接的路线

            string str1 = "insert into 科室信息表 values ('" + partID() + "' ,'" + txt_partName.Text + "', '" + txt_partNote.Text + "') ";

            MySqlCommand cmd = new MySqlCommand(str1, conn);
            cmd.ExecuteNonQuery();

            MessageBox.Show("科室添加成功");
            conn.Close();
        }


        // 删除科室信息
        private void btn_partDelete_Click(object sender, EventArgs e)
        {

            string str = "server=localhost;user id = root;password=123456;database=myhis";  //参数定义
            MySqlConnection conn = new MySqlConnection(str);  //构造函数，与mysql连接的，建造与mysql沟通的桥梁
            conn.Open();  //打开与mysql连接的路线

            // 从当前的表格中选中某个单元格的值
            string id = Convert.ToString(dataGridView_part.CurrentRow.Cells[0].Value);


            string str1 = "delete from 科室信息表 where 编号 = '" + id + "'";
            MySqlCommand cmd = new MySqlCommand(str1, conn);  //数据库命令
            int x = cmd.ExecuteNonQuery();

            // 删除这里没有数据适配器，直接返回命令看是否删除成功
            if (x == 0)
            {
                MessageBox.Show("科室信息删除失败");
            }
            else
            {
                MessageBox.Show("科室信息删除成功");
            }

        }


        // 更新科室信息
        private void btn_partUpdate_Click(object sender, EventArgs e)
        {
            string str = "server=localhost;user id = root;password=123456;database=myhis";  //参数定义
            MySqlConnection conn = new MySqlConnection(str);  //构造函数，与mysql连接的，建造与mysql沟通的桥梁
            conn.Open();  //打开与mysql连接的路线


            string id = Convert.ToString(dataGridView_part.CurrentRow.Cells[0].Value);


            string str1 = @"update 科室信息表 set 编号 = '" + id + "' , 名称 = '" + txt_partName.Text + "', 备注 = '" + txt_doctorNote.Text + "' where 编号 = '" + id + "' ";

            MySqlCommand cmd = new MySqlCommand(str1, conn);
            cmd.ExecuteNonQuery();

            MessageBox.Show("科室信息更新成功");
            conn.Close();
        }




        // ***********************************************************************************************************************************************
        /**
         * 
         * 
         *  ③医生查询系统
         * 
         * */


        //科室下拉列表填充
        private void cb_partName_Click(object sender, EventArgs e)
        {
            string strcmd = "select * from 科室信息表";
            DataTable dt = sqlCom(strcmd);
            cb_partName.DataSource = dt;
            cb_partName.DisplayMember = "名称";
            cb_partName.ValueMember = "编号";
        }


        // 查询医生信息
        private void btn_doctorQuery_Click(object sender, EventArgs e)
        {
            string strcmd = " select * from 医生信息表 where 姓名 like '%" + txt_doctorName.Text.ToString() + "%' ";
            dataGridView_doctor.DataSource = sqlCom(strcmd);
        }


        // 生成医生编号
        public static string doctorID()
        {
            string strcmd = "select count(*)+1 from 医生信息表";
            DataTable dt = sqlCom(strcmd);

            string doctorId = "d" + dt.Rows[0][0].ToString();
            return doctorId;
        }


        //添加医生信息
        private void btn_doctorAdd_Click(object sender, EventArgs e)
        {

            string str = "server=localhost;user id = root;password=123456;database=myhis";  //参数定义
            MySqlConnection conn = new MySqlConnection(str);  //构造函数，与mysql连接的，建造与mysql沟通的桥梁
            conn.Open();  //打开与mysql连接的路线

            string str1 =
                @"insert into 医生信息表 values ('" + doctorID() + "' , '" + txt_doctorName.Text + "', " +
                "'" + cb_partName.SelectedValue.ToString() + "' , '" + txt_doctorNote.Text + "') ";

            MySqlCommand cmd = new MySqlCommand(str1, conn);
            cmd.ExecuteNonQuery();

            MessageBox.Show("医生信息添加成功");
            conn.Close();


        }


        // 删除医生信息
        private void btn_doctorDelete_Click(object sender, EventArgs e)
        {

            string str = "server=localhost;user id = root;password=123456;database=myhis";  //参数定义
            MySqlConnection conn = new MySqlConnection(str);  //构造函数，与mysql连接的，建造与mysql沟通的桥梁
            conn.Open();  //打开与mysql连接的路线

            // 从当前的表格中选中某个单元格的值
            string id = Convert.ToString(dataGridView_doctor.CurrentRow.Cells[0].Value);
            

            string str1 = "delete from 医生信息表 where 编号 = '" + id + "'";
            MySqlCommand cmd = new MySqlCommand(str1, conn);  //数据库命令
            int x = cmd.ExecuteNonQuery();

            // 删除这里没有数据适配器，直接返回命令看是否删除成功
            if (x == 0)
            {
                MessageBox.Show("医生信息删除失败");
            }
            else
            {
                MessageBox.Show("医生信息删除成功");
            }

        }


        // 更新医生信息
        private void btn_doctorUpdate_Click_1(object sender, EventArgs e)
        {

            string str = "server=localhost;user id = root;password=123456;database=myhis";  //参数定义
            MySqlConnection conn = new MySqlConnection(str);  //构造函数，与mysql连接的，建造与mysql沟通的桥梁
            conn.Open();  //打开与mysql连接的路线


            string id = Convert.ToString(dataGridView_doctor.CurrentRow.Cells[0].Value);

            Console.WriteLine("a1:" + id);
            Console.WriteLine("a2:" + txt_doctorName.Text);
            Console.WriteLine("a3:" + cb_partName.SelectedValue);
            Console.WriteLine("a4:" + txt_doctorNote.Text);


            string str1 =  @"update 医生信息表 set 编号 = '" + id + "' , 姓名 = '" + txt_doctorName.Text + "', 科室 = '" + cb_partName.SelectedValue + "', 备注 = '" + txt_doctorNote.Text + "' where 编号 = '" + id + "' ";

            MySqlCommand cmd = new MySqlCommand(str1, conn);
            cmd.ExecuteNonQuery();

            MessageBox.Show("医生信息更新成功");
            conn.Close();


        }



        


        // ***********************************************************************************************************************************************
        /**
         * 
         * 
         *  ④处方系统
         * 
         * */


        // 药品名称的下拉列表罗列
        private void cb_drugName_Click(object sender, EventArgs e)
        {
            string strcmd = "select * from 药品信息表";
            DataTable dt = sqlCom(strcmd);
            cb_drugName.DataSource = dt;
            cb_drugName.DisplayMember = "名称";
            cb_drugName.ValueMember = "编号";  //选择下拉列表的值，获得了这个值所对应的编号信息
        }



        
        //处方系统查询按钮
        private void btn_treatSearch_Click(object sender, EventArgs e)
        {
            string strcmd = @" select 就诊号,病人编号,姓名,性别,年龄,时间
     from (select 挂号信息表.编号 as 就诊号,挂号信息表.病人编号,挂号信息表.姓名,
     挂号信息表.性别,患者基本信息表.年龄,科室信息表.名称 as 科室,
     医生信息表.姓名 as 医生,挂号信息表.挂号费用,挂号信息表.时间
     from 患者基本信息表,科室信息表,医生信息表,挂号信息表
     where 挂号信息表.病人编号=患者基本信息表.编号
     and 挂号信息表.挂号科室=科室信息表.编号
     and 挂号信息表.医生=医生信息表.姓名) as A
     order by 就诊号";

            dataGridView_treat.DataSource = sqlCom(strcmd);
            if (sqlCom(strcmd).Rows.Count != 0)
            {
                txt_treatNum.Text = sqlCom(strcmd).Rows[0][0].ToString();
                txt_patientNum.Text = sqlCom(strcmd).Rows[0][0].ToString();
                txt_patientName.Text = sqlCom(strcmd).Rows[0][0].ToString();
            }
        }

        


        // 生成处方编号
        public static string treatID()
        {
            string strcmd = "select count(*)+1 from 诊断信息表;";
            DataTable dt = sqlCom(strcmd);
            string treatId = "z" + dt.Rows[0][0].ToString();
            return treatId;
        }


        // 诊断信息表添加信息，即处方信息
        public void treatment(string treatId)
        {

            string str = "server=localhost;user id = root;password=123456;database=myhis";  //参数定义
            MySqlConnection conn = new MySqlConnection(str);  //构造函数，与MySQL连接的，建造与MySQL沟通的桥梁
            conn.Open();  //打开与MySQL连接的路线

            //string strcmd = 

            //    @"insert into 诊断信息表(编号, 病人编号, 药品编号, 药品数量) values 
            //    ('" + treatId + "'  ,  '" + txt_patientNum.Text + "'  ,  '" + cb_drugName.SelectedValue.ToString() + "'， '" + cb_drugNum.Text + "' )" ;

            //MySqlCommand cmd = new MySqlCommand(strcmd, conn);
            //cmd.ExecuteNonQuery();
            //conn.Close();

            //MessageBox.Show("处方添加成功");




            string numcmd = "select count(*)+1 from 诊断信息表";


            // mysql命令
            MySqlCommand cmd = new MySqlCommand(numcmd, conn);

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);  //适配器：接受查询的结果

            DataSet ds = new DataSet();  //数据集对象,数据集中可以有1至n张表;若放进去的仅是一个数值，也2会作为表格
            da.Fill(ds);  // 将适配器查询到的结果放入到数据集中

            string medid = ds.Tables[0].Rows[0][0].ToString();




            medid = "z" + medid;
            string str1 = @"insert into 诊断信息表(编号, 病人编号, 药品编号, 药品数量) values   
   ('" + treatId + "'  ,  '" + txt_patientNum.Text + "'  ,  '" + cb_drugName.SelectedValue.ToString() + "', '" + cb_drugNum.Text + "' )";
            MySqlCommand cmd1 = new MySqlCommand(str1, conn);
            MySqlDataAdapter da1 = new MySqlDataAdapter(cmd1);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);

            conn.Close();

        }




        // “开方”按钮，同时查询结果并插入新诊断结果到诊断表信息
        private void btn_prescription_Click(object sender, EventArgs e)
        {
            string treatId = treatID();
            treatment(treatId);

            string strcmd = 
                
                @" select 患者基本信息表.姓名,  药品信息表.名称 as 药品,  诊断信息表.药品数量 as 数量
                from 诊断信息表,  患者基本信息表,  药品信息表
                where 诊断信息表.病人编号 = 患者基本信息表.编号
                and 诊断信息表.药品编号 = 药品信息表.编号
                order by 诊断信息表.编号";

            dataGridView_prescription.DataSource = sqlCom(strcmd);
        }


        

        private void dataGridView_treat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string c0 = dataGridView_treat.CurrentRow.Cells[0].Value.ToString();
            string c1 = dataGridView_treat.CurrentRow.Cells[1].Value.ToString();
            string c2 = dataGridView_treat.CurrentRow.Cells[2].Value.ToString();

            txt_treatNum.Text = c0;
            txt_patientNum.Text = c1;
            txt_patientName.Text = c2;
        }







        // ***********************************************************************************************************************************************
        /**
         * 
         * 
         *  ⑤结算系统
         * 
         * */

        private void btn_feeCheck_Click(object sender, EventArgs e)
        {
            //string strcmd =

                        //@" select  c.编号 as 患者编号,  c.姓名,  挂号信息表.挂号费用,  c.药品费用,  挂号信息表.挂号费用+c.药品费用 as 费用总计

                        //from 挂号信息表,(select 编号,  姓名,  sum(药品费) as 药品费用
                        //from (select  患者基本信息表.编号,  患者基本信息表.姓名,  诊断信息表.药品数量*药品信息表.单价 as 药品费
                        //from 诊断信息表,  药品信息表,  患者基本信息表
                        //where 诊断信息表.病人编号=患者基本信息表.编号  and  诊断信息表.药品编号=药品信息表.编号) as b
                        //group by 编号)  as  c

                        //where c.编号=挂号信息表.病人编号  and  c.姓名 like '%" + txt_namefee.text.tostring() + "%' ";



           
   


            string strcmd = @"select     
    挂号信息表.病人编号 as 患者编号,    
    患者基本信息表.姓名 as 病人姓名,    
    挂号信息表.挂号费用,    
    coalesce(药品费用子查询.药品费用, 0) as 药品费用,    
    挂号信息表.挂号费用 + coalesce(药品费用子查询.药品费用, 0) as 费用总计    
from     
    挂号信息表    
left join     
    (select     
        患者基本信息表.编号,    
        患者基本信息表.姓名,    
        sum(诊断信息表.药品数量 * 药品信息表.单价) as 药品费用    
    from     
        诊断信息表    
    join     
        药品信息表 on 诊断信息表.药品编号 = 药品信息表.编号    
    join     
        患者基本信息表 on 诊断信息表.病人编号 = 患者基本信息表.编号    
    group by     
        患者基本信息表.编号, 患者基本信息表.姓名    
    ) as 药品费用子查询 on 挂号信息表.病人编号 = 药品费用子查询.编号    
join     
    患者基本信息表 on 挂号信息表.病人编号 = 患者基本信息表.编号
 and  患者基本信息表.姓名 like '%" + txt_nameFee.Text.ToString() + "%' ";


            //                        string strcmd = @"SELECT   
            //    挂号信息表.病人编号 AS 患者编号,  
            //    患者基本信息表.姓名 AS 病人姓名,  
            //    挂号信息表.挂号费用,  
            //    COALESCE(药品费用子查询.药品费用, 0) AS 药品费用,  
            //    挂号信息表.挂号费用 + COALESCE(药品费用子查询.药品费用, 0) AS 费用总计  
            //FROM   
            //    挂号信息表  
            //LEFT JOIN   
            //    (SELECT   
            //        患者基本信息表.编号,  
            //        患者基本信息表.姓名,  
            //        SUM(诊断信息表.药品数量 * 药品信息表.单价) AS 药品费用  
            //    FROM   
            //        诊断信息表  
            //    JOIN   
            //        药品信息表 ON 诊断信息表.药品编号 = 药品信息表.编号  
            //    JOIN   
            //        患者基本信息表 ON 诊断信息表.病人编号 = 患者基本信息表.编号  
            //    GROUP BY   
            //        患者基本信息表.编号, 患者基本信息表.姓名  
            //    ) AS 药品费用子查询 ON 挂号信息表.病人编号 = 药品费用子查询.编号  
            //JOIN   
            //    患者基本信息表 ON 挂号信息表.病人编号 = 患者基本信息表.编号;";


            dataGridView_feeCheck.DataSource = sqlCom(strcmd);
        }

        
        private void btn_feeSettle_Click(object sender, EventArgs e)
        {
            feeSettle fee = new feeSettle();
            fee.Show();
        }






        // ***********************************************************************************************************************************************
        /**
         * 
         * 
         *  账户管理系统
         * 
         * */

        // 切换用户
        private void btn_userChange_Click(object sender, EventArgs e)
        {
            
                login obj = new login();
                obj.Show();
                this.Hide();
             
            
        }


        // 退出系统
        private void btn_loginExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    

        // 设置当前用户文本
        private void txt_user_TextChanged_1(object sender, EventArgs e)
        {
            txt_user.Text = login.UserName;

        }

        
    }
}
