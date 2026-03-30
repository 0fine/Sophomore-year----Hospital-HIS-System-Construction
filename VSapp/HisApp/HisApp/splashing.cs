using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HisApp
{
    public partial class splashing : Form
    {
        public splashing()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


        // 写一个计时器，便于进度条加载显示
        int startpos = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            startpos += 1;
            splashProgress.Value = startpos;

            // 变量值的变化，写再加载界面上
            percentage_lable.Text = startpos + "%";

            if(splashProgress.Value == 100)
            {
                splashProgress.Value = 0;
                timer1.Stop();
                login log = new login();  //当进度加载到100，弹出用户登录界面，即“login”
                log.Show();
                this.Hide();
            }
        }

        private void splashing_Load(object sender, EventArgs e)
        {
            // 当“splashing”界面打开时，计时器开始工作
            timer1.Start();
        }
    }
}
