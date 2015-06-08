namespace CK_Sync
{
    partial class MainFrm
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_OADbTest = new System.Windows.Forms.Button();
            this.CKB_OA_Syn = new System.Windows.Forms.CheckBox();
            this.txt_OA_DBPassword = new System.Windows.Forms.TextBox();
            this.txt_OA_DBUserName = new System.Windows.Forms.TextBox();
            this.txt_OA_DBName = new System.Windows.Forms.TextBox();
            this.txt_OA_DBPort = new System.Windows.Forms.TextBox();
            this.txt_OA_DBIP = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.btnOpenMDB = new System.Windows.Forms.Button();
            this.CKB_CKQ_Syn = new System.Windows.Forms.CheckBox();
            this.btn_MDBDbTest = new System.Windows.Forms.Button();
            this.txt_MDB_DBPATH = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.Btn_Save = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_IGSTest = new System.Windows.Forms.Button();
            this.CKB_IGS_Syn = new System.Windows.Forms.CheckBox();
            this.txt_IGS_PATH = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.Btn_Exit = new System.Windows.Forms.Button();
            this.Btn_StartSyn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_OADbTest);
            this.groupBox1.Controls.Add(this.CKB_OA_Syn);
            this.groupBox1.Controls.Add(this.txt_OA_DBPassword);
            this.groupBox1.Controls.Add(this.txt_OA_DBUserName);
            this.groupBox1.Controls.Add(this.txt_OA_DBName);
            this.groupBox1.Controls.Add(this.txt_OA_DBPort);
            this.groupBox1.Controls.Add(this.txt_OA_DBIP);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(317, 259);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // btn_OADbTest
            // 
            this.btn_OADbTest.Location = new System.Drawing.Point(93, 201);
            this.btn_OADbTest.Name = "btn_OADbTest";
            this.btn_OADbTest.Size = new System.Drawing.Size(160, 52);
            this.btn_OADbTest.TabIndex = 12;
            this.btn_OADbTest.Text = "测试连接";
            this.btn_OADbTest.UseVisualStyleBackColor = true;
            this.btn_OADbTest.Click += new System.EventHandler(this.btn_OADbTest_Click);
            // 
            // CKB_OA_Syn
            // 
            this.CKB_OA_Syn.AutoSize = true;
            this.CKB_OA_Syn.Location = new System.Drawing.Point(11, 0);
            this.CKB_OA_Syn.Name = "CKB_OA_Syn";
            this.CKB_OA_Syn.Size = new System.Drawing.Size(96, 16);
            this.CKB_OA_Syn.TabIndex = 11;
            this.CKB_OA_Syn.Text = "MapGIS一张图";
            this.CKB_OA_Syn.UseVisualStyleBackColor = true;
            // 
            // txt_OA_DBPassword
            // 
            this.txt_OA_DBPassword.Location = new System.Drawing.Point(93, 150);
            this.txt_OA_DBPassword.Name = "txt_OA_DBPassword";
            this.txt_OA_DBPassword.Size = new System.Drawing.Size(192, 21);
            this.txt_OA_DBPassword.TabIndex = 9;
            // 
            // txt_OA_DBUserName
            // 
            this.txt_OA_DBUserName.Location = new System.Drawing.Point(93, 121);
            this.txt_OA_DBUserName.Name = "txt_OA_DBUserName";
            this.txt_OA_DBUserName.Size = new System.Drawing.Size(192, 21);
            this.txt_OA_DBUserName.TabIndex = 8;
            // 
            // txt_OA_DBName
            // 
            this.txt_OA_DBName.Location = new System.Drawing.Point(93, 92);
            this.txt_OA_DBName.Name = "txt_OA_DBName";
            this.txt_OA_DBName.Size = new System.Drawing.Size(192, 21);
            this.txt_OA_DBName.TabIndex = 7;
            // 
            // txt_OA_DBPort
            // 
            this.txt_OA_DBPort.Location = new System.Drawing.Point(93, 63);
            this.txt_OA_DBPort.Name = "txt_OA_DBPort";
            this.txt_OA_DBPort.Size = new System.Drawing.Size(192, 21);
            this.txt_OA_DBPort.TabIndex = 6;
            // 
            // txt_OA_DBIP
            // 
            this.txt_OA_DBIP.Location = new System.Drawing.Point(93, 34);
            this.txt_OA_DBIP.Name = "txt_OA_DBIP";
            this.txt_OA_DBIP.Size = new System.Drawing.Size(192, 21);
            this.txt_OA_DBIP.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(45, 153);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 12);
            this.label9.TabIndex = 4;
            this.label9.Text = "密码:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(33, 124);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 12);
            this.label8.TabIndex = 3;
            this.label8.Text = "用户名:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 95);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 12);
            this.label7.TabIndex = 2;
            this.label7.Text = "数据库名称:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(33, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 12);
            this.label6.TabIndex = 1;
            this.label6.Text = "端口号:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "数据库地址:";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.btnOpenMDB);
            this.groupBox7.Controls.Add(this.CKB_CKQ_Syn);
            this.groupBox7.Controls.Add(this.btn_MDBDbTest);
            this.groupBox7.Controls.Add(this.txt_MDB_DBPATH);
            this.groupBox7.Controls.Add(this.label28);
            this.groupBox7.Location = new System.Drawing.Point(339, 12);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(317, 259);
            this.groupBox7.TabIndex = 23;
            this.groupBox7.TabStop = false;
            // 
            // btnOpenMDB
            // 
            this.btnOpenMDB.Location = new System.Drawing.Point(97, 63);
            this.btnOpenMDB.Name = "btnOpenMDB";
            this.btnOpenMDB.Size = new System.Drawing.Size(118, 31);
            this.btnOpenMDB.TabIndex = 22;
            this.btnOpenMDB.Text = "选择采矿权数据库";
            this.btnOpenMDB.UseVisualStyleBackColor = true;
            this.btnOpenMDB.Click += new System.EventHandler(this.btnOpenMDB_Click);
            // 
            // CKB_CKQ_Syn
            // 
            this.CKB_CKQ_Syn.AutoSize = true;
            this.CKB_CKQ_Syn.Location = new System.Drawing.Point(6, 0);
            this.CKB_CKQ_Syn.Name = "CKB_CKQ_Syn";
            this.CKB_CKQ_Syn.Size = new System.Drawing.Size(96, 16);
            this.CKB_CKQ_Syn.TabIndex = 21;
            this.CKB_CKQ_Syn.Text = "采矿权数据库";
            this.CKB_CKQ_Syn.UseVisualStyleBackColor = true;
            // 
            // btn_MDBDbTest
            // 
            this.btn_MDBDbTest.Location = new System.Drawing.Point(97, 201);
            this.btn_MDBDbTest.Name = "btn_MDBDbTest";
            this.btn_MDBDbTest.Size = new System.Drawing.Size(158, 52);
            this.btn_MDBDbTest.TabIndex = 20;
            this.btn_MDBDbTest.Text = "测试连接";
            this.btn_MDBDbTest.UseVisualStyleBackColor = true;
            this.btn_MDBDbTest.Click += new System.EventHandler(this.btn_MDBDbTest_Click);
            // 
            // txt_MDB_DBPATH
            // 
            this.txt_MDB_DBPATH.Location = new System.Drawing.Point(97, 37);
            this.txt_MDB_DBPATH.Name = "txt_MDB_DBPATH";
            this.txt_MDB_DBPATH.Size = new System.Drawing.Size(192, 21);
            this.txt_MDB_DBPATH.TabIndex = 15;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(20, 40);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(71, 12);
            this.label28.TabIndex = 10;
            this.label28.Text = "数据库路径:";
            // 
            // Btn_Save
            // 
            this.Btn_Save.Location = new System.Drawing.Point(248, 307);
            this.Btn_Save.Name = "Btn_Save";
            this.Btn_Save.Size = new System.Drawing.Size(166, 62);
            this.Btn_Save.TabIndex = 24;
            this.Btn_Save.Text = "保存";
            this.Btn_Save.UseVisualStyleBackColor = true;
            this.Btn_Save.Click += new System.EventHandler(this.Btn_Save_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_IGSTest);
            this.groupBox2.Controls.Add(this.CKB_IGS_Syn);
            this.groupBox2.Controls.Add(this.txt_IGS_PATH);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Location = new System.Drawing.Point(662, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(317, 259);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            // 
            // btn_IGSTest
            // 
            this.btn_IGSTest.Location = new System.Drawing.Point(93, 201);
            this.btn_IGSTest.Name = "btn_IGSTest";
            this.btn_IGSTest.Size = new System.Drawing.Size(160, 52);
            this.btn_IGSTest.TabIndex = 12;
            this.btn_IGSTest.Text = "测试连接";
            this.btn_IGSTest.UseVisualStyleBackColor = true;
            this.btn_IGSTest.Click += new System.EventHandler(this.btn_IGSTest_Click);
            // 
            // CKB_IGS_Syn
            // 
            this.CKB_IGS_Syn.AutoSize = true;
            this.CKB_IGS_Syn.Location = new System.Drawing.Point(11, 0);
            this.CKB_IGS_Syn.Name = "CKB_IGS_Syn";
            this.CKB_IGS_Syn.Size = new System.Drawing.Size(96, 16);
            this.CKB_IGS_Syn.TabIndex = 11;
            this.CKB_IGS_Syn.Text = "MapGIS一张图";
            this.CKB_IGS_Syn.UseVisualStyleBackColor = true;
            // 
            // txt_IGS_PATH
            // 
            this.txt_IGS_PATH.Location = new System.Drawing.Point(93, 34);
            this.txt_IGS_PATH.Name = "txt_IGS_PATH";
            this.txt_IGS_PATH.Size = new System.Drawing.Size(192, 21);
            this.txt_IGS_PATH.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 37);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 12);
            this.label10.TabIndex = 0;
            this.label10.Text = "图形服务地址:";
            // 
            // Btn_Exit
            // 
            this.Btn_Exit.Location = new System.Drawing.Point(420, 308);
            this.Btn_Exit.Name = "Btn_Exit";
            this.Btn_Exit.Size = new System.Drawing.Size(162, 62);
            this.Btn_Exit.TabIndex = 27;
            this.Btn_Exit.Text = "退出";
            this.Btn_Exit.UseVisualStyleBackColor = true;
            this.Btn_Exit.Click += new System.EventHandler(this.Btn_Exit_Click);
            // 
            // Btn_StartSyn
            // 
            this.Btn_StartSyn.Location = new System.Drawing.Point(76, 307);
            this.Btn_StartSyn.Name = "Btn_StartSyn";
            this.Btn_StartSyn.Size = new System.Drawing.Size(166, 62);
            this.Btn_StartSyn.TabIndex = 26;
            this.Btn_StartSyn.Text = "同步信息";
            this.Btn_StartSyn.UseVisualStyleBackColor = true;
            this.Btn_StartSyn.Click += new System.EventHandler(this.Btn_StartSyn_Click);
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1069, 381);
            this.Controls.Add(this.Btn_Exit);
            this.Controls.Add(this.Btn_StartSyn);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.Btn_Save);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainFrm";
            this.Text = "采矿权数据同步工具";
            this.Load += new System.EventHandler(this.MainFrm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox CKB_OA_Syn;
        private System.Windows.Forms.TextBox txt_OA_DBPassword;
        private System.Windows.Forms.TextBox txt_OA_DBUserName;
        private System.Windows.Forms.TextBox txt_OA_DBName;
        private System.Windows.Forms.TextBox txt_OA_DBPort;
        private System.Windows.Forms.TextBox txt_OA_DBIP;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_OADbTest;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.CheckBox CKB_CKQ_Syn;
        private System.Windows.Forms.Button btn_MDBDbTest;
        private System.Windows.Forms.TextBox txt_MDB_DBPATH;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Button btnOpenMDB;
        private System.Windows.Forms.Button Btn_Save;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_IGSTest;
        private System.Windows.Forms.CheckBox CKB_IGS_Syn;
        private System.Windows.Forms.TextBox txt_IGS_PATH;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button Btn_Exit;
        private System.Windows.Forms.Button Btn_StartSyn;
    }
}

