using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CM.Map;
using Oracle.DataAccess.Client;
using System.Configuration;


namespace CK_Sync
{
    public partial class MainFrm : Form
    {
        private delegate void SyncEventHandler();

        SynPromptDlg frmSyn = new SynPromptDlg();

        string errorMsg = string.Empty;
        public MainFrm()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 测试Oracle数据库链接
        /// </summary>
        /// <param name="DBIP">数据库IP</param>
        /// <param name="DBPort">数据库端口</param>
        /// <param name="DBName">数据库名称</param>
        /// <param name="DBUser">数据库用户名</param>
        /// <param name="DBPassword">数据库密码</param>
        /// <param name="Message">异常信息</param>
        /// <returns></returns>
        private bool TestOracleConn(string DBIP, string DBPort, string DBName, string DBUser, string DBPassword, ref string Message)
        {
            string ora_conn = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=" + DBIP + ")(PORT=" + DBPort + ")))(CONNECT_DATA=(SERVICE_NAME=" + DBName + ")));User Id=" + DBUser + ";Password=" + DBPassword + ";";
            OracleConnection ORA_Con = new OracleConnection(ora_conn);
            //打开数据库连接
            if (ORA_Con.State == ConnectionState.Closed)
            {
                try
                {
                    //打开数据库连接
                    ORA_Con.Open();
                    Message = "连接成功";
                    return true;
                }
                catch (Exception e)
                {
                    Message = e.Message;
                    return false;
                }
                finally
                {
                    //Close DataBase
                    //关闭数据库连接
                    ORA_Con.Close();
                }
            }
            Message = "未知原因";
            return false;
        }

        /// <summary>
        /// 测试MDB数据库链接
        /// </summary>
        /// <param name="MDB_PATH">数据库文件路径</param>
        /// <param name="Message">异常信息</param>
        /// <returns></returns>
        private bool TestAccessConn(string MDB_PATH, ref string Message)
        {
            try
            {
                string connectingString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + MDB_PATH;// CM.Map.Config.GetConfigValue("MDB_Path");
                CM.Map.DatabaseOledb acc_conn = new DatabaseOledb(connectingString);
                if (acc_conn.Conn.State == ConnectionState.Closed)
                {
                    try
                    {
                        acc_conn.Open();
                        Message = "连接成功";
                        return true;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        //Close DataBase
                        //关闭数据库连接
                        acc_conn.Close();
                    }
                }
                Message = "未知原因";
                return false;
            }
            catch(Exception ex)
            {
                CM.Map.Log.WriteLog(ex.Message);
                throw ex;
            }
        }

        private bool TestIGS(string IGS_PATH,ref string Message)
        {
            try
            {
                try
                {
                    //CM.Map.Log.WriteLog("http://" + Config.GetConfigValue("IGS_PATH") + "/IGSLandService/Feature.asmx");
                    //CM.Map.Feature f = new CM.Map.Feature("http://" + Config.GetConfigValue("IGS_PATH") + "//IGSLandService//Feature.asmx");
                    WebFeature.Feature f = new WebFeature.Feature();
                    f.Url = "http://" + Config.GetConfigValue("IGS_PATH") + "//IGSLandService//Feature.asmx";
                    Message = "连接成功";
                    return true;
                }
                catch(Exception ex)
                {
                    CM.Map.Log.WriteLog(ex.Message);
                    //throw ex;
                }
                Message = "未知原因";
                return false;
            }
            catch(Exception ex)
            {
                CM.Map.Log.WriteLog(ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// 读取配置文件中相关的值
        /// </summary>
        private void GetConfigValue()
        {


            #region 从配置文件中获取OA数据库的相关配置信息(Oracle)
            //判断是否要同步功能中心数据库
            bool bOASyn = Config.GetConfigValue("OASyn") == "false" ? false : true;
            CKB_OA_Syn.Checked = bOASyn;
            btn_OADbTest.Enabled = CKB_OA_Syn.Checked;
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
            btn_MDBDbTest.Enabled = CKB_CKQ_Syn.Checked;
            //
            txt_MDB_DBPATH.Text = Config.GetConfigValue("MDB_PATH");
            txt_MDB_DBPATH.Enabled = bMDBSyn;
            #endregion

            #region 获取图形服务配置
            bool bIGSSyn = Config.GetConfigValue("IGSSyn") == "false" ? false : true;
            CKB_IGS_Syn.Checked = bIGSSyn;
            txt_IGS_PATH.Text = Config.GetConfigValue("IGS_PATH");
            #endregion

        }

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

        private void SynDatas()
        {
            //List<CKQInfo> datas = null;
            //数据库连接字符串
            //string strConn = null;
            {
                DialogResult ret = MessageBox.Show("初始化同步将删除原来存在的所有用户/机构/角色等信息，一旦进行初始化同步，需要在一张图系统中重新对用户/机构设定系统权限，确定要进行初始化同步？",
                          "初始化同步警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (ret == DialogResult.Yes)
                {
                    DatabaseOledb dbMDB = new DatabaseOledb(CM.Map.Config.GetConfigValue("MDB_ConnectString"));//MDB连接
                    //StringBuilder ora_Conn = new StringBuilder("data source=" + CM.Map.Config.GetConfigValue("OA_DBName") + ";user=" + CM.Map.Config.GetConfigValue("OA_DBUserName") + ";password=" + CM.Map.Config.GetConfigValue("OA_DBPassword") + ";");
                    #region Oracle连接串
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

                    #region 测试连接串
                    try
                    {
                        dbORA.Open();
                        dbORA.Close();
                    }
                    catch(Exception ex)
                    {
                        CM.Map.Log.WriteLog("DatabaseORC.Open()错误>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>\r\n" + ora_Conn.ToString() +"\r\n"+ ex.Message);
                        MessageBox.Show(ex.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                        throw ex;
                    }
                    #endregion

                    #region 同步数据

                    string IGSUri = Config.GetConfigValue("IGS_PATH");
                    if (SynORA(dbORA, dbMDB) && SynIGS(dbMDB, IGSUri))
                    {
                        MessageBox.Show("成功!", "同步成功", MessageBoxButtons.OK, MessageBoxIcon.None);
                        return;
                    }
                    else
                    {
                        MessageBox.Show(errorMsg.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    #endregion
                }
            }

            MessageBox.Show("用户同步完成!", "同步完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #region 同步电子政务数据
        /// <summary>
        /// 同步Oracle数据
        /// </summary>
        /// <param name="dbORA">Oracle数据库连接</param>
        /// <param name="dbMDB">mdb数据库连接</param>
        /// <returns></returns>
        public bool SynORA(CM.Map.DatabaseORC dbORA, CM.Map.DatabaseOledb dbMDB)
        {

            try
            {
                    bool b = true;
                    if (Config.GetConfigValue("OASyn") == "true")//根据配置文件决定是否进行同步
                    {
                        string mdbSQL = "select * from 采矿申请登记 where 签发时间 is not null";
                        DataTable dt = dbMDB.GetDataSet(mdbSQL).Tables[0];
                        DataRow dr = null;
                        //DataRow temp = null;
                        string oraSQL = string.Empty;
                        string upSQL = string.Empty;

                        #region 更新采矿申请登记表
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            dr = dt.Rows[i];
                            //oraSQL = "select * from 采矿申请登记 where 项目档案号='" + dr["项目档案号"] + "' and 签发时间 is not null and to_char(签发时间,'yyyy-mm-dd,hh:mi:ss')='" + dr["签发时间"] + "'";
                            oraSQL = "select * from 采矿申请登记 where 项目档案号='" + dr["项目档案号"] + "' and 签发时间=to_date('" + dr["签发时间"] + "','yyyy-mm-dd hh24:mi:ss')";
                            CM.Map.Log.WriteLog(oraSQL);
                            DataSet ds = dbORA.GetDataSet(oraSQL);

                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                CM.Map.Log.WriteLog("当前记录已存在于数据库中>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>" + new CKQInfo(dr).ToString());
                            }
                            else
                            {

                                CM.Map.Log.WriteLog("当前记录不存在于数据库中>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>\r\n");
                                upSQL = UpdateSQL(dr, "采矿申请登记");
                                CM.Map.Log.WriteLog(upSQL);
                                dbORA.ExecuteSql(upSQL);
                            }
                        }
                        #endregion

                        #region 更新采矿申请登记表
                        mdbSQL = "select * from 项目档案 where 签发时间 is not null";
                        dt = dbMDB.GetDataSet(mdbSQL).Tables[0];
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            dr = dt.Rows[i];
                            //oraSQL = "select * from 采矿申请登记 where 项目档案号='" + dr["项目档案号"] + "' and 签发时间 is not null and to_char(签发时间,'yyyy-mm-dd,hh:mi:ss')='" + dr["签发时间"] + "'";
                            oraSQL = "select * from 项目档案 where 项目档案号='" + dr["项目档案号"] + "' and 签发时间=to_date('" + dr["签发时间"] + "','yyyy-mm-dd hh24:mi:ss')";
                            CM.Map.Log.WriteLog(oraSQL);
                            DataSet ds = dbORA.GetDataSet(oraSQL);

                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                CM.Map.Log.WriteLog("当前记录已存在于数据库中>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>" + new CKQInfo(dr).ToString());
                            }
                            else
                            {

                                CM.Map.Log.WriteLog("当前记录不存在于数据库中>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>\r\n");
                                upSQL = UpdateSQL(dr, "项目档案");
                                CM.Map.Log.WriteLog(upSQL);
                                dbORA.ExecuteSql(upSQL);
                            }
                        }
                        #endregion
                    }
                return b;
            }
            catch (Exception ex)
            {
                CM.Map.Log.WriteLog("SynORA同步错误>>>>" + ex.Message);
                errorMsg="SynORA同步错误!";
                throw ex;
            }
        }
        #endregion

        #region 同步图形数据

        /// <summary>
        /// 同步图形中的CKSQDJ图层数据
        /// </summary>
        /// <param name="dbMDB">MDB数据库对象</param>
        /// <param name="IGSUri">IGS服务地址</param>
        /// <returns></returns>
        public bool SynIGS(CM.Map.DatabaseOledb dbMDB, string IGSUri)
        {
            try
            {
                bool b = true;
                if (Config.GetConfigValue("IGSSyn") == "true")//根据配置文件决定是否进行SynIGS同步
                {
                    //CM.Map.Feature f = new CM.Map.Feature("http://" + IGSUri + "/IGSLandService/Feature.asmx");
                    WebFeature.Feature f = new WebFeature.Feature();
                    f.Url = "http://" + IGSUri + "/IGSLandService/Feature.asmx";

                    CM.Map.Log.WriteLog("http://" + IGSUri + "/IGSLandService/Feature.asmx");
                    string mdbSQL = "select * from 采矿申请登记 where 签发时间 is not null";
                    DataTable dt = dbMDB.GetDataSet(mdbSQL).Tables[0];
                    DataRow dr = null;
                    #region 遍历采矿申请登记表，更新采矿权图层
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dr = dt.Rows[i];

                        if (!IsFeatureExitCKSQDJ(f, dr))
                        {
                            //CM.Map.Log.WriteLog("当前记录已存在于采矿申请登记数据中>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>" + new CKQInfo(dr).ToString());
                            //插入更新语句
                            b = b && IsFeatureExitCKSQDJ(f, dr);
                        }
                    }
                    #endregion

                    #region Debug
                    b = b && IsFeatureExitCKSQDJ(f, dr);
                    #endregion
                }
                return b ;
            }
            catch(Exception ex)
            {
                CM.Map.Log.WriteLog("SynIGS错误>>>>" + ex.Message);
                errorMsg="SynIGS错误!";
                throw ex;
            }
        }
        #endregion

        #region 判断要素在CKSQDJ图层中是否存在
        /// <summary>
        /// 判断要素是否存在
        /// </summary>
        /// <param name="f">IGS服务</param>
        /// <param name="dr">数据对象</param>
        /// <returns></returns>
        public bool IsFeatureExitCKSQDJ(WebFeature.Feature f,DataRow dr)//CM.Map.Feature f,DataRow dr)
        {
            try
            {
                bool b = true;
                string strWhere = "项目档案号='" + dr["项目档案号"] + "' and 签发时间=‘" + dr["签发时间"] + "'";
                CM.Map.Log.WriteLog("IsFeatureExitCKSQDJ执行成功>>>>" + strWhere);
                b = f.IsFeatureExistNew("两矿", "layerShortName=CKSQDJ", strWhere);
                return b;

                //#region Debug
                //bool b = true;
                //string strWhere = "项目档案号='1111' and 签发时间=‘2012-04-04 00:00:00'";
                //b = f.IsFeatureExistNew("两矿", "layerShortName=CKSQDJ", strWhere);

                //CM.Map.Log.WriteLog("IsFeatureExitCKSQDJ执行成功>>>>");
                //return b;
                //#endregion
            }
            catch (Exception ex)
            {
                CM.Map.Log.WriteLog("IsFeatureExitCKSQDJ()方法报错>>>>" + ex.Message);
                errorMsg = "IsFeatureExitCKSQDJ()方法报错!";
                return false;
                throw ex;
                
            }
        }
        #endregion

        #region 当确认记录要插入时，获取insert语句的方法
        /// <summary>
        /// 当确认记录要插入时，获取insert语句的方法
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private string UpdateSQL(DataRow dr,string tableName)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("insert into " + tableName + " (CK_GUID,申请序号,许可证号,项目档案号,项目类型,申请人,电话,地址,邮编,矿山名称,东经起,东经止,北纬起,北纬止,经济类型,项目审批机关,批准文号,投资额,投资额单位,注册资金,注册资金单位,资金来源,开户银行,帐号,设计年限,开采主矿种,其它主矿种,共伴生类型,设计规模,规模单位,开采方式,采矿方法,选矿方法,采矿回采率,矿石贫化率,选矿回收率,应缴纳采矿权价款,采深上限,采深下限,矿区面积,采矿权使用费,法定代表人,填表人,受理日期,有效期限,有效期起,有效期止,矿权终止时间,审查人,签发,复核,审核,签发时间,变更类型,变更内容,矿区编码,采矿权取得方式,取得方式代码,价款处置方式,价款处置方式代码,勘查许可证号,总储量,储量单位,矿石类型,划矿备案号,原许可证号,原签发时间,原有效期起,原有效期止,填表时间,许可证副本说明,发证机关编码,发证机关名称,所在行政区,所在行政区名称,坐标系统,实地核查状况,实地核查单位,实地核查人,实地核查完成时间,重叠核查单位,重叠核查人,重叠核查完成时间,词典标识1,词典标识2,数值标识1,数值标识2,文本标识1,文本标识2,实地核查坐标,实地核查意见,重叠核查意见,审查人意见,区域坐标,最终产品,探矿权取得方式,价款处置方式说明,探明地质储量,设计利用储量,地质报告审批情况,矿石品位,综合回收,申请原因,补偿费交纳情况,使用费交纳情况,价款处置情况,合并项目,备注) values('");
                sb.Append(dr["CK_GUID"] + "','"); 
                sb.Append(dr["申请序号"] + "','"); 
                sb.Append(dr["许可证号"] + "','");
                sb.Append(dr["项目档案号"] + "','"); 
                sb.Append(dr["项目类型"] + "','");
                sb.Append(dr["申请人"] + "','"); 
                sb.Append(dr["电话"] + "','"); 
                sb.Append(dr["地址"] + "','"); 
                sb.Append(dr["邮编"] + "','"); 
                sb.Append(dr["矿山名称"] + "','");
                sb.Append(dr["东经起"] + "','"); 
                sb.Append(dr["东经止"] + "','"); 
                sb.Append(dr["北纬起"] + "','"); 
                sb.Append(dr["北纬止"] + "','"); 
                sb.Append(dr["经济类型"] + "','");
                sb.Append(dr["项目审批机关"] + "','"); 
                sb.Append(dr["批准文号"] + "','"); 
                sb.Append(dr["投资额"] + "','"); 
                sb.Append(dr["投资额单位"] + "','"); 
                sb.Append(dr["注册资金"] + "','"); 
                sb.Append(dr["注册资金单位"] + "','"); 
                sb.Append(dr["资金来源"] + "','"); 
                sb.Append(dr["开户银行"] + "','"); 
                sb.Append(dr["帐号"] + "','"); 
                sb.Append(dr["设计年限"] + "','"); 
                sb.Append(dr["开采主矿种"] + "','"); 
                sb.Append(dr["其它主矿种"] + "','"); 
                sb.Append(dr["共伴生类型"] + "','"); 
                sb.Append(dr["设计规模"] + "','"); 
                sb.Append(dr["规模单位"] + "','"); 
                sb.Append(dr["开采方式"] + "','"); 
                sb.Append(dr["采矿方法"] + "','"); 
                sb.Append(dr["选矿方法"] + "','"); 
                sb.Append(dr["采矿回采率"] + "','"); 
                sb.Append(dr["矿石贫化率"] + "','");
                sb.Append(dr["选矿回收率"] + "','");
                sb.Append(dr["应缴纳采矿权价款"] + "','"); 
                sb.Append(dr["采深上限"] + "','"); 
                sb.Append(dr["采深下限"] + "','"); 
                sb.Append(dr["矿区面积"] + "','");
                sb.Append(dr["采矿权使用费"] + "','"); 
                sb.Append(dr["法定代表人"] + "','"); 
                sb.Append(dr["填表人"] + "',");
                
                sb.Append("to_date('");
                sb.Append(dr["受理日期"] + "','yyyy-mm-dd hh24:mi:ss'),'"); 

                sb.Append(dr["有效期限"] + "',");

                sb.Append("to_date('");
                sb.Append(dr["有效期起"] + "','yyyy-mm-dd hh24:mi:ss'),");

                sb.Append("to_date('");
                sb.Append(dr["有效期止"] + "','yyyy-mm-dd hh24:mi:ss'),");

                sb.Append("to_date('");
                sb.Append(dr["矿权终止时间"] + "','yyyy-mm-dd hh24:mi:ss'),'");
                sb.Append(dr["审查人"] + "','"); 
                sb.Append(dr["签发"] + "','");
                sb.Append(dr["复核"] + "','"); 
                sb.Append(dr["审核"] + "',");

                sb.Append("to_date('");
                sb.Append(dr["签发时间"] + "','yyyy-mm-dd hh24:mi:ss'),'"); 

                sb.Append(dr["变更类型"] + "','");
                sb.Append(dr["变更内容"] + "','"); 
                sb.Append(dr["矿区编码"] + "','"); 
                sb.Append(dr["采矿权取得方式"] + "','"); 
                sb.Append(dr["取得方式代码"] + "','"); 
                sb.Append(dr["价款处置方式"] + "','"); 
                sb.Append(dr["价款处置方式代码"] + "','");
                sb.Append(dr["勘查许可证号"] + "','");
                sb.Append(dr["总储量"] + "','"); 
                sb.Append(dr["储量单位"] + "','"); 
                sb.Append(dr["矿石类型"] + "','"); 
                sb.Append(dr["划矿备案号"] + "','"); 
                sb.Append(dr["原许可证号"] + "',");

                sb.Append("to_date('");
                sb.Append(dr["原签发时间"] + "','yyyy-mm-dd hh24:mi:ss'),");

                sb.Append("to_date('");
                sb.Append(dr["原有效期起"] + "','yyyy-mm-dd hh24:mi:ss'),");

                sb.Append("to_date('");
                sb.Append(dr["原有效期止"] + "','yyyy-mm-dd hh24:mi:ss'),");

                sb.Append("to_date('");
                sb.Append(dr["填表时间"] + "','yyyy-mm-dd hh24:mi:ss'),'"); 

                sb.Append(dr["许可证副本说明"] + "','"); 
                sb.Append(dr["发证机关编码"] + "','");
                sb.Append(dr["发证机关名称"] + "','"); 
                sb.Append(dr["所在行政区"] + "','"); 
                sb.Append(dr["所在行政区名称"] + "','"); 
                sb.Append(dr["坐标系统"] + "','");
                sb.Append(dr["实地核查状况"] + "','");
                sb.Append(dr["实地核查单位"] + "','"); 
                sb.Append(dr["实地核查人"] + "',");

                sb.Append("to_date('");
                sb.Append(dr["实地核查完成时间"] + "','yyyy-mm-dd hh24:mi:ss'),'"); 
                sb.Append(dr["重叠核查单位"] + "','"); 
                sb.Append(dr["重叠核查人"] + "',");

                sb.Append("to_date('");
                sb.Append(dr["重叠核查完成时间"] + "','yyyy-mm-dd hh24:mi:ss'),'");
                sb.Append(dr["词典标识1"] + "','");
                sb.Append(dr["词典标识2"] + "','"); 
                sb.Append(dr["数值标识1"] + "','"); 
                sb.Append(dr["数值标识2"] + "','");
                sb.Append(dr["文本标识1"] + "','");
                sb.Append(dr["文本标识2"] + "','"); 
                sb.Append(dr["实地核查坐标"] + "','");
                sb.Append(dr["实地核查意见"] + "','"); 
                sb.Append(dr["重叠核查意见"] + "','"); 
                sb.Append(dr["审查人意见"] + "','"); 
                sb.Append(dr["区域坐标"] + "','");
                sb.Append(dr["最终产品"] + "','");
                sb.Append(dr["探矿权取得方式"] + "','");
                sb.Append(dr["价款处置方式说明"] + "','");
                sb.Append(dr["探明地质储量"] + "','"); 
                sb.Append(dr["设计利用储量"] + "','"); 
                sb.Append(dr["地质报告审批情况"] + "','"); 
                sb.Append(dr["矿石品位"] + "','"); 
                sb.Append(dr["综合回收"] + "','"); 
                sb.Append(dr["申请原因"] + "','");
                sb.Append(dr["补偿费交纳情况"] + "','"); 
                sb.Append(dr["使用费交纳情况"] + "','"); 
                sb.Append(dr["价款处置情况"] + "','");
                sb.Append(dr["合并项目"] + "','"); 
                sb.Append(dr["备注"] + "')");
                //sb.Replace(" ", "");
                //CM.Map.Log.WriteLog(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>\r\n" + sb.ToString());
                return sb.ToString();
            }
            catch (Exception ex)
            {
                CM.Map.Log.WriteLog(ex.Message);
                throw ex;
            }
        }
        #endregion

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
            catch
            {

            }
        }

        private void btn_OADbTest_Click(object sender, EventArgs e)
        {
            string sMessage = "";
            bool b = TestOracleConn(txt_OA_DBIP.Text, txt_OA_DBPort.Text, txt_OA_DBName.Text, txt_OA_DBUserName.Text, txt_OA_DBPassword.Text, ref sMessage);
            if (b)
            {
                MessageBox.Show(sMessage, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(sMessage, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            GetConfigValue();            
        }

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

        private void btn_MDBDbTest_Click(object sender, EventArgs e)
        {
            try
            {
                string sMessage = "";
                bool b = TestAccessConn(txt_MDB_DBPATH.Text, ref sMessage);
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

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            SaveConfig();
            MessageBox.Show("保存成功", "提示");
        }

        private void btn_IGSTest_Click(object sender, EventArgs e)
        {
            try
            {
                string sMessage = "";
                bool b = TestIGS(txt_IGS_PATH.Text, ref sMessage);
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

        private void Btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

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
                CM.Map.Log.WriteLog(ex.Message);
                MessageBox.Show(errorMsg.ToString());
            }
        }

    }
}
