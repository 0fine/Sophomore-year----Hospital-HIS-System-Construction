namespace HisApp
{
    partial class fuzzySearch
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.bnt_submit = new System.Windows.Forms.Button();
            this.txt_name0 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.txt_age = new System.Windows.Forms.TextBox();
            this.txt_sex = new System.Windows.Forms.TextBox();
            this.txt_phone = new System.Windows.Forms.TextBox();
            this.btn_add_click = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.btn_delete_click = new System.Windows.Forms.Button();
            this.btn_update = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(27, 56);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.Size = new System.Drawing.Size(837, 610);
            this.dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(932, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "姓名";
            // 
            // bnt_submit
            // 
            this.bnt_submit.Location = new System.Drawing.Point(935, 128);
            this.bnt_submit.Name = "bnt_submit";
            this.bnt_submit.Size = new System.Drawing.Size(234, 33);
            this.bnt_submit.TabIndex = 2;
            this.bnt_submit.Text = "模糊查询";
            this.bnt_submit.UseVisualStyleBackColor = true;
            this.bnt_submit.Click += new System.EventHandler(this.button1_Click);
            // 
            // txt_name0
            // 
            this.txt_name0.Location = new System.Drawing.Point(1015, 78);
            this.txt_name0.Name = "txt_name0";
            this.txt_name0.Size = new System.Drawing.Size(154, 28);
            this.txt_name0.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(932, 261);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "姓名";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(932, 383);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 18);
            this.label3.TabIndex = 7;
            this.label3.Text = "年龄";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(932, 325);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 18);
            this.label4.TabIndex = 8;
            this.label4.Text = "性别";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(932, 443);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 18);
            this.label5.TabIndex = 9;
            this.label5.Text = "电话";
            // 
            // txt_name
            // 
            this.txt_name.Location = new System.Drawing.Point(1015, 251);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(154, 28);
            this.txt_name.TabIndex = 10;
            // 
            // txt_age
            // 
            this.txt_age.Location = new System.Drawing.Point(1015, 377);
            this.txt_age.Name = "txt_age";
            this.txt_age.Size = new System.Drawing.Size(154, 28);
            this.txt_age.TabIndex = 11;
            // 
            // txt_sex
            // 
            this.txt_sex.Location = new System.Drawing.Point(1015, 315);
            this.txt_sex.Name = "txt_sex";
            this.txt_sex.Size = new System.Drawing.Size(154, 28);
            this.txt_sex.TabIndex = 12;
            // 
            // txt_phone
            // 
            this.txt_phone.Location = new System.Drawing.Point(1015, 437);
            this.txt_phone.Name = "txt_phone";
            this.txt_phone.Size = new System.Drawing.Size(154, 28);
            this.txt_phone.TabIndex = 13;
            // 
            // btn_add_click
            // 
            this.btn_add_click.Location = new System.Drawing.Point(901, 515);
            this.btn_add_click.Name = "btn_add_click";
            this.btn_add_click.Size = new System.Drawing.Size(155, 50);
            this.btn_add_click.TabIndex = 14;
            this.btn_add_click.Text = "添加患者信息";
            this.btn_add_click.UseVisualStyleBackColor = true;
            this.btn_add_click.Click += new System.EventHandler(this.btn_add_click_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.Location = new System.Drawing.Point(1086, 592);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(155, 50);
            this.btn_exit.TabIndex = 17;
            this.btn_exit.Text = "退出";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // btn_delete_click
            // 
            this.btn_delete_click.Location = new System.Drawing.Point(901, 592);
            this.btn_delete_click.Name = "btn_delete_click";
            this.btn_delete_click.Size = new System.Drawing.Size(155, 50);
            this.btn_delete_click.TabIndex = 18;
            this.btn_delete_click.Text = "删除患者信息";
            this.btn_delete_click.UseVisualStyleBackColor = true;
            this.btn_delete_click.Click += new System.EventHandler(this.btn_delete_click_Click);
            // 
            // btn_update
            // 
            this.btn_update.Location = new System.Drawing.Point(1086, 515);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(155, 50);
            this.btn_update.TabIndex = 19;
            this.btn_update.Text = "更新患者信息";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // fuzzySearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1265, 684);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.btn_delete_click);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.btn_add_click);
            this.Controls.Add(this.txt_phone);
            this.Controls.Add(this.txt_sex);
            this.Controls.Add(this.txt_age);
            this.Controls.Add(this.txt_name);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_name0);
            this.Controls.Add(this.bnt_submit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "fuzzySearch";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bnt_submit;
        private System.Windows.Forms.TextBox txt_name0;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.TextBox txt_age;
        private System.Windows.Forms.TextBox txt_sex;
        private System.Windows.Forms.TextBox txt_phone;
        private System.Windows.Forms.Button btn_add_click;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Button btn_delete_click;
        private System.Windows.Forms.Button btn_update;
    }
}

