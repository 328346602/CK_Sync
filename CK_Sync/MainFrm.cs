using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CM.Map;
using System.Data.OracleClient;
using System.Configuration;


namespace CK_Sync
{
    public partial class MainFrm : Form
    {
        private delegate void SyncEventHandler();

        SynPromptDlg frmSyn = new SynPromptDlg();

        public MainFrm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 读取配置文件中相关的值,并赋值给对应的控件
        /// </summary>
        private void GetConfigValue()
        {


            #region 从配置文件中获取OA数据库的相关配置信息(Oracle)
            //判断是否要同步功能中心数据库
            bool bOASyn = Config.GetConfigValue("OASyn") == "false" ? false : true;
            CKB_OA_Syn.Checked = bOASyn;
            btn_OADbTest.Enabled = bOASyn;
            //
            txt_OA_DBIP.Text = Config.GetConfigValue("OA_DBIP");
            txt_OA_DBIP.Enabled = bOASyn;
            //数据库口号
            txt_OA_DBPort.Text = Config.GetConfigValue("OA_DBPort");
            txt_OA_DBPort.Enabled = bOASyn;
            //数据库名称
            txt_OA_DBName.Text = Config.GetConfigValue("OA_DBName");
            txt_OA_DBName.Enabled = bOASyn;
            //数据库用户名
            txt_OA_DBUserName.Text = Config.GetConfigValue("OA_DBUserName");
            txt_OA_DBUserName.Enabled = bOASyn;
            //数据库密码
            txt_OA_DBPassword.Text = Config.GetConfigValue("OA_DBPassword");
            txt_OA_DBPassword.Enabled = bOASyn;
            #endregion

            #region 从配置文件中获取采矿权数据库的相关配置信息(Oracle)
            //判断是否要同步功能中心数据库
            bool bMDBSyn = Config.GetConfigValue("MDBSyn") == "false" ? false : true;
            CKB_CKQ_Syn.Checked = bMDBSyn;
            btn_MDBDbTest.Enabled = bMDBSyn;
            btnOpenMDB.Enabled = bMDBSyn;
            //
            txt_MDB_DBPATH.Text = Config.GetConfigValue("MDB_PATH");
            txt_MDB_DBPATH.Enabled = bMDBSyn;
            #endregion

            #region 获取图形服务配置
            bool bIGSSyn = Config.GetConfigValue("IGSSyn") == "false" ? false : true;
            CKB_IGS_Syn.Checked = bIGSSyn;
            txt_IGS_PATH.Text = Config.GetConfigValue("IGS_PATH");
            txt_IGS_PATH.Enabled = bIGSSyn;
            btn_IGSTest.Enabled = bIGSSyn;
            #endregion

        }

        /// <summary>
        /// 保存配置信息
        /// </summary>
        private void SaveConfig()
        {
            #region 保存OA数据库同步配置(Oracle)
            if (CKB_OA_Syn.Checked)
            {
                Config.SetConfigValue("OASyn", "true");
            }
            else
            {
                Config.SetConfigValue("OASyn", "false");
            }
            Config.SetConfigValue("OA_DBIP", txt_OA_DBIP.Text);
            Config.SetConfigValue("OA_DBPort", txt_OA_DBPort.Text);
            Config.SetConfigValue("OA_DBName", txt_OA_DBName.Text);
            Config.SetConfigValue("OA_DBUserName", txt_OA_DBUserName.Text);
            Config.SetConfigValue("OA_DBPassword", txt_OA_DBPassword.Text);
            #endregion

            #region 保存采矿权数据库同步配置(MDB)
            if (CKB_CKQ_Syn.Checked)
            {
                Config.SetConfigValue("MDBSyn", "true");
            }
            else
            {
                Config.SetConfigValue("MDBSyn", "false");
            }
            Config.SetConfigValue("MDB_PATH", txt_MDB_DBPATH.Text);
            Config.SetConfigValue("MDB_ConnectString", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + txt_MDB_DBPATH.Text);
            #endregion

            #region 保存图形服务配置
            if (CKB_IGS_Syn.Checked)
            {
                Config.SetConfigValue("IGSSyn", "true");
            }
            else
            {
                Config.SetConfigValue("IGSSyn", "false");
            }
            Config.SetConfigValue("IGS_PATH", txt_IGS_PATH.Text);
            #endregion
        }

        /// <summary>
        /// 同步方法
        /// </summary>
        private void SynDatas()
        {
            {
                DialogResult ret = MessageBox.Show("同步之前请检查、测试各项设置并保存！","注意", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (ret == DialogResult.Yes)
                {
                    DatabaseOledb dbMDB = new DatabaseOledb(CM.Map.Config.GetConfigValue("MDB_ConnectString"));//MDB连接
                    #region Oracle连接串StringBuilder ora_Conn
                    StringBuilder ora_Conn = new StringBuilder("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=");
                    ora_Conn.Append(CM.Map.Config.GetConfigValue("OA_DBIP"));
                    ora_Conn.Append(")(PORT=");
                    ora_Conn.Append(CM.Map.Config.GetConfigValue("OA_DBPort"));
                    ora_Conn.Append(")))(CONNECT_DATA=(SERVICE_NAME=");
                    ora_Conn.Append(CM.Map.Config.GetConfigValue("OA_DBName"));
                    ora_Conn.Append(")));User Id=");
                    ora_Conn.Append(CM.Map.Config.GetConfigValue("OA_DBUserName"));
                    ora_Conn.Append(";Password=");
                    ora_Conn.Append(CM.Map.Config.GetConfigValue("OA_DBPassword"));
                    ora_Conn.Append(";");
                    #endregion

                    DatabaseORC dbORA = new DatabaseORC(ora_Conn.ToString());

                    #region 同步数据

                    string IGSUri = Config.GetConfigValue("IGS_PATH");

                    #region MDBSyn=false
                    if (Config.GetConfigValue("MDBSyn") == "false")
                    {
                        MessageBox.Show("请检查采矿权数据库配置并保存!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    #endregion

                    #region OASyn=true
                    else if (Config.GetConfigValue("OASyn") == "true")
                    {
                        #region OASyn/IGSSyn都为true
                        if (Config.GetConfigValue("IGSSyn") == "true")
                        {
                            if (Sync.SynORA(dbORA, dbMDB) && Sync.SynIGS(dbMDB, IGSUri))
                            {
                                MessageBox.Show("成功!", "同步成功", MessageBoxButtons.OK, MessageBoxIcon.None);
                                return;
                            }
                            else
                            {
                                MessageBox.Show(Sync.errorMsg.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        #endregion

                        #region IGSSyn为false
                        else
                        {
                            if (Sync.SynORA(dbORA, dbMDB))
                            {
                                MessageBox.Show("成功!", "同步成功", MessageBoxButtons.OK, MessageBoxIcon.None);
                                return;
                            }
                            else
                            {
                                MessageBox.Show(Sync.errorMsg.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        #endregion
                    }
                    #endregion

                    #region OASyn=false/IGSSyn=true
                    else if (Config.GetConfigValue("IGSSyn") == "true")
                    {
                        if (Sync.SynIGS(dbMDB, IGSUri))
                        {
                            MessageBox.Show("成功!", "同步成功", MessageBoxButtons.OK, MessageBoxIcon.None);
                            return;
                        }
                        else
                        {
                            MessageBox.Show("图形同步失败，请检查配置并保存！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //Log.WriteLog("IGSSyn错误『OASyn=false/IGSSyn=true』>>>>" + errorMsg);
                            return;
                        }
                    }
                    #endregion

                    #region MDBSyn=true&&OASyn=false&&IGSSyn=false
                    else
                    {
                        MessageBox.Show("请检查MapGIS一张图政务/图形同步设置并保存!", "信息", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        return;
                    }
                    #endregion
                    #endregion
                }
            }

            
        }

        private void SyncData()
        {
            try
            {
                DialogResult ret = MessageBox.Show("同步之前请检查、测试各项设置并保存！", "注意", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (ret == DialogResult.Yes)
                {
                    DatabaseOledb dbMDB = new DatabaseOledb(CM.Map.Config.GetConfigValue("MDB_ConnectString"));//MDB连接
                    #region Oracle连接串StringBuilder ora_Conn
                    StringBuilder ora_Conn = new StringBuilder("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=");
                    ora_Conn.Append(CM.Map.Config.GetConfigValue("OA_DBIP"));
                    ora_Conn.Append(")(PORT=");
                    ora_Conn.Append(CM.Map.Config.GetConfigValue("OA_DBPort"));
                    ora_Conn.Append(")))(CONNECT_DATA=(SERVICE_NAME=");
                    ora_Conn.Append(CM.Map.Config.GetConfigValue("OA_DBName"));
                    ora_Conn.Append(")));User Id=");
                    ora_Conn.Append(CM.Map.Config.GetConfigValue("OA_DBUserName"));
                    ora_Conn.Append(";Password=");
                    ora_Conn.Append(CM.Map.Config.GetConfigValue("OA_DBPassword"));
                    ora_Conn.Append(";");
                    #endregion

                    DatabaseORC dbORA = new DatabaseORC(ora_Conn.ToString());

                    #region 同步数据

                    string IGSUri = Config.GetConfigValue("IGS_PATH");

                    #region MDBSyn=false
                    if (Config.GetConfigValue("MDBSyn") == "false")
                    {
                        MessageBox.Show("请检查采矿权数据库配置并保存!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    #endregion

                    #region OASyn=true
                    else if (Config.GetConfigValue("OASyn") == "true")
                    {
                        #region OASyn/IGSSyn都为true
                        if (Config.GetConfigValue("IGSSyn") == "true")
                        {
                            if (Sync.SynORA(dbORA, dbMDB) && Sync.SynIGS(dbMDB, IGSUri))
                            {
                                MessageBox.Show("成功!", "同步成功", MessageBoxButtons.OK, MessageBoxIcon.None);
                                return;
                            }
                            else
                            {
                                MessageBox.Show(Sync.errorMsg.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        #endregion

                        #region IGSSyn为false
                        else
                        {
                            if (Sync.SynORA(dbORA, dbMDB))
                            {
                                MessageBox.Show("成功!", "同步成功", MessageBoxButtons.OK, MessageBoxIcon.None);
                                return;
                            }
                            else
                            {
                                MessageBox.Show(Sync.errorMsg.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        #endregion
                    }
                    #endregion

                    #region OASyn=false/IGSSyn=true
                    else if (Config.GetConfigValue("IGSSyn") == "true")
                    {
                        if (Sync.SynIGS(dbMDB, IGSUri))
                        {
                            MessageBox.Show("成功!", "同步成功", MessageBoxButtons.OK, MessageBoxIcon.None);
                            return;
                        }
                        else
                        {
                            MessageBox.Show("图形同步失败，请检查配置并保存！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //Log.WriteLog("IGSSyn错误『OASyn=false/IGSSyn=true』>>>>" + errorMsg);
                            return;
                        }
                    }
                    #endregion

                    #region MDBSyn=true&&OASyn=false&&IGSSyn=false
                    else
                    {
                        MessageBox.Show("请检查MapGIS一张图政务/图形同步设置并保存!", "信息", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        return;
                    }
                    #endregion
                    #endregion
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 异步CallBack
        /// </summary>
        /// <param name="ar"></param>
        private void RunCallBack(IAsyncResult ar)
        {
            SyncEventHandler d = null;

            try
            {
                System.Runtime.Remoting.Messaging.AsyncResult asres = (System.Runtime.Remoting.Messaging.AsyncResult)ar;
                d = ((SyncEventHandler)asres.AsyncDelegate);
                d.EndInvoke(ar);

                frmSyn.BeginInvoke((Action)delegate()
                {
                    frmSyn.Close();
                });
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainFrm_Load(object sender, EventArgs e)
        {
            GetConfigValue();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_OADbTest_Click(object sender, EventArgs e)
        {
            try
            {
                string sMessage = "";
                bool b = DatabaseORC.TestOracleConn(txt_OA_DBIP.Text, txt_OA_DBPort.Text, txt_OA_DBName.Text, txt_OA_DBUserName.Text, txt_OA_DBPassword.Text, ref sMessage);
                if (b)
                {
                    MessageBox.Show(sMessage, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(sMessage, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenMDB_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileName = new OpenFileDialog();
            fileName.InitialDirectory = txt_MDB_DBPATH.Text;
            fileName.Filter = "数据库文件(*.mdb)|*.mdb|所有文件(*.*)|*.*";
            fileName.RestoreDirectory = true;
            if (fileName.ShowDialog() == DialogResult.OK)
            {
                txt_MDB_DBPATH.Text = fileName.FileName.ToString();
                //mdbPath = fileName.FileName.ToString();//获取用户选择文件的完整路径
            }
        }

        /// <summary>
        /// btn_IGSTest_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_IGSTest_Click(object sender, EventArgs e)
        {
            try
            {
                string sMessage = "";
                bool b = CK.TestIGS(txt_IGS_PATH.Text, ref sMessage);
                if (b)
                {
                    MessageBox.Show(sMessage, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(sMessage, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_MDBDbTest_Click(object sender, EventArgs e)
        {
            try
            {
                string sMessage = "";
                bool b = DatabaseOledb.TestAccessConn(txt_MDB_DBPATH.Text, ref sMessage);
                if (b)
                {
                    MessageBox.Show(sMessage, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(sMessage, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Save_Click(object sender, EventArgs e)
        {
            SaveConfig();
            MessageBox.Show("保存成功", "提示");
        }

        /// <summary>
        /// Btn_StartSyn_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_StartSyn_Click(object sender, EventArgs e)
        {
            try
            {

                SyncEventHandler syncEn = new SyncEventHandler(SynDatas);

                syncEn.BeginInvoke(new AsyncCallback(RunCallBack), null);

                frmSyn.sMessage = "操作正在执行中,请稍候...";
                frmSyn.ShowDialog();

                //SynUsers(Convert.ToInt32(strSynType));
            }
            catch (Exception ex)
            {
                //throw ex;
                Log.WriteLog(ex.Message);
                MessageBox.Show(Sync.errorMsg.ToString());
            }
        }

        /// <summary>
        /// Btn_Exit_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// CKB_OA_Syn_CheckedChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CKB_OA_Syn_CheckedChanged(object sender, EventArgs e)
        {
            txt_OA_DBIP.Enabled = CKB_OA_Syn.Checked;
            txt_OA_DBName.Enabled = CKB_OA_Syn.Checked;
            txt_OA_DBPassword.Enabled = CKB_OA_Syn.Checked;
            txt_OA_DBPort.Enabled = CKB_OA_Syn.Checked;
            txt_OA_DBUserName.Enabled = CKB_OA_Syn.Checked;
            btn_OADbTest.Enabled = CKB_OA_Syn.Checked;
        }

        /// <summary>
        /// CKB_CKQ_Syn_CheckedChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CKB_CKQ_Syn_CheckedChanged(object sender, EventArgs e)
        {
            txt_MDB_DBPATH.Enabled = CKB_CKQ_Syn.Checked;
            btn_MDBDbTest.Enabled = CKB_CKQ_Syn.Checked;
            btnOpenMDB.Enabled = CKB_CKQ_Syn.Checked;
        }

        /// <summary>
        /// CKB_IGS_Syn_CheckedChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CKB_IGS_Syn_CheckedChanged(object sender, EventArgs e)
        {
            txt_IGS_PATH.Enabled = CKB_IGS_Syn.Checked;
            btn_IGSTest.Enabled = CKB_IGS_Syn.Checked;
        }

    }
}
