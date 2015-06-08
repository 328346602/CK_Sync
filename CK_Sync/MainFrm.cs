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

        string errorMsg = string.Empty;
        string strLayerShortName = "CKSQDJ";

        public MainFrm()
        {
            InitializeComponent();
        }


        
        
        private bool TestIGS(string IGS_PATH,ref string Message)
        {
            try
            {
                try
                {
                    WebFeature.Feature f = new WebFeature.Feature();
                    f.Url = "http://" + Config.GetConfigValue("IGS_PATH") + "//IGSLandService//Feature.asmx";
                    //bool b = Boolean.Parse(f.GetLayerAttCountNew("两矿","layerShortName="+strLayerShortName,"项目档案号 is not null").ToString());
                    bool b = Boolean.Parse(f.IsFeatureExistNew("两矿", "layerShortName=" + strLayerShortName, "项目档案号 is not null").ToString());
                    if (b)
                    {
                        Message = "连接成功";
                    }
                    else
                    {
                        Message = "连接图形服务失败！";
                    }
                    return b;
                }
                catch(Exception ex)
                {
                    Log.WriteLog(ex.Message);
                    Message = "连接图形服务失败！";
                    return false;
                    throw ex;
                }
            }
            catch(Exception ex)
            {
                Log.WriteLog(ex.Message);
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

        #region 采探矿数据库坐标格式化
        /// <summary>
        /// 格式化采矿权数据库中储存的坐标串
        /// </summary>
        /// <param name="strDot">坐标串</param>
        /// <returns>格式化后的坐标串</returns>
        public static string GetCKFormattedDotString(string strDot)
        {
            if (string.IsNullOrEmpty(strDot))
            {
                return "";
            }

            string[] strDots = strDot.Split(',');
            int iPlotNo = int.Parse(strDots[0]);        //圈数
            int iCurIndex = 1;
            string strDotString = "";

            for (int i = 0; i < iPlotNo; i++)
            {
                try
                {
                    int iPointNo = int.Parse(strDots[iCurIndex]);
                    iCurIndex += 2;


                    for (int j = 0; j < iPointNo; j++)
                    {
                        strDotString += strDots[iCurIndex] + "," + strDots[iCurIndex + 1] + " ";
                        //strDotString += strDots[iCurIndex+1] + "," + strDots[iCurIndex] + " ";
                        iCurIndex += 3;
                    }

                    if (strDotString.EndsWith(" "))
                    { strDotString = strDotString.Substring(0, strDotString.Length - 1); }

                    if ((iCurIndex + 3 + 1) < strDots.Length)
                    {
                        int iPointTag = int.Parse(strDots[iCurIndex + 3]);
                        if ((iCurIndex + iPointTag * 3 + 7 + 1) < strDots.Length)
                        {
                            if (strDots[iCurIndex + iPointTag * 3 + 7] == "-1")
                            {
                                strDotString += "@";
                            }
                            else
                            {
                                strDotString += "#";
                            }
                        }
                    }
                    //strDotString += "@";
                    iCurIndex += 3;
                }
                catch (Exception oExcept)
                {
                    Log.WriteLog("采矿权数据库坐标解析问题：" + oExcept.Message);
                }
            }

            if (strDotString.EndsWith("@"))
            { strDotString = strDotString.Substring(0, strDotString.Length - 1); }
            else if (strDotString.EndsWith(" "))
            { strDotString = strDotString.Substring(0, strDotString.Length - 1); }

            return strDotString;
        }
        #endregion

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
                DialogResult ret = MessageBox.Show("同步之前请检查、测试各项设置并保存！","注意", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (ret == DialogResult.Yes)
                {
                    DatabaseOledb dbMDB = new DatabaseOledb(CM.Map.Config.GetConfigValue("MDB_ConnectString"));//MDB连接
                    //StringBuilder ora_Conn = new StringBuilder("data source=" + CM.Map.Config.GetConfigValue("OA_DBName") + ";user=" + CM.Map.Config.GetConfigValue("OA_DBUserName") + ";password=" + CM.Map.Config.GetConfigValue("OA_DBPassword") + ";");
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
                        }
                        #endregion

                        #region IGSSyn为false
                        else
                        {
                            if (SynORA(dbORA, dbMDB))
                            {
                                MessageBox.Show("成功!", "同步成功", MessageBoxButtons.OK, MessageBoxIcon.None);
                                return;
                            }
                            else
                            {
                                MessageBox.Show(errorMsg.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        #endregion
                    }
                    #endregion

                    #region OASyn=false/IGSSyn=true
                    else if (Config.GetConfigValue("IGSSyn") == "true")
                    {
                        if (SynIGS(dbMDB, IGSUri))
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

                string mdbSQL = "select * from 采矿申请登记 where 签发时间 is not null";
                DataTable dt = dbMDB.GetDataSet(mdbSQL).Tables[0];
                DataRow dr = null;
                //DataRow temp = null;
                string oraSQL = string.Empty;
                string upSQL = string.Empty;

                #region 更新『采矿申请登记』表
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dr = dt.Rows[i];
                    //oraSQL = "select * from 采矿申请登记 where 项目档案号='" + dr["项目档案号"] + "' and 签发时间 is not null and to_char(签发时间,'yyyy-mm-dd,hh:mi:ss')='" + dr["签发时间"] + "'";
                    oraSQL = "select * from 采矿申请登记 where 项目档案号='" + dr["项目档案号"] + "' and 签发时间=to_date('" + dr["签发时间"] + "','yyyy-mm-dd hh24:mi:ss')";
                    //Log.WriteLog(oraSQL);
                    DataSet ds = dbORA.GetDataSet(oraSQL);

                    if (!(ds.Tables[0].Rows.Count > 0))
                    {
                        upSQL = UpdateSQL(dr, "采矿申请登记");
                        dbORA.ExecuteSql(upSQL);
                    }
                    
                }
                #endregion

                #region 更新『项目档案』表
                mdbSQL = "select * from 项目档案 where 签发时间 is not null";
                dt = dbMDB.GetDataSet(mdbSQL).Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dr = dt.Rows[i];
                    //oraSQL = "select * from 采矿申请登记 where 项目档案号='" + dr["项目档案号"] + "' and 签发时间 is not null and to_char(签发时间,'yyyy-mm-dd,hh:mi:ss')='" + dr["签发时间"] + "'";
                    oraSQL = "select * from 项目档案 where 项目档案号='" + dr["项目档案号"] + "' and 签发时间=to_date('" + dr["签发时间"] + "','yyyy-mm-dd hh24:mi:ss')";
                    DataSet ds = dbORA.GetDataSet(oraSQL);

                    if (!(ds.Tables[0].Rows.Count > 0))
                    {
                        upSQL = UpdateSQL(dr, "项目档案");
                        dbORA.ExecuteSql(upSQL);
                    }
                }
                #endregion

                return b;
            }
            catch (Exception ex)
            {
                Log.WriteLog("SynORA同步错误>>>>" + ex.Message);
                errorMsg = "同步MapGIS一张图数据库时出错，请检查相关配置信息！";
                return false;
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

                //CM.Map.Feature f = new CM.Map.Feature("http://" + IGSUri + "/IGSLandService/Feature.asmx");
                WebFeature.Feature f = new WebFeature.Feature();
                f.Url = "http://" + IGSUri + "/IGSLandService/Feature.asmx";;
                string mdbSQL = "select * from 采矿申请登记 where 签发时间 is not null";
                DataTable dt = new DataTable();
                #region 判断是否查询到数据，若未查询到数据则不需要进行后面的判断
                if (dbMDB.GetDataSet(mdbSQL).Tables.Count > 0)
                {
                    try
                    {
                        dt = dbMDB.GetDataSet(mdbSQL).Tables[0];
                    }
                    catch (Exception ex)
                    {
                        errorMsg = "同步错误，请检查采矿权数据库设置！";
                        return false;
                        throw ex;
                    }
                }
                else
                {
                    errorMsg = "同步错误，采矿权数据库(MDB)中未查询到数据！";
                    return false;
                }
                #endregion
                DataRow dr = null;
                #region 遍历采矿申请登记表，更新采矿权图层
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dr = dt.Rows[i];
                    try
                    {
                        b = UpdateFeature(f, dr) && b;
                        //Log.WriteLog(string.Format(b.ToString() + "循环第{0}次", i + 1));
                        if (!b)
                            return b;
                        //else
                        //    continue;
                    }
                    catch (Exception ex)
                    {
                        Log.WriteLog("UpdateFeature()>>>>" + ex.Message);
                        return false;
                        throw ex;
                    }
                }
                #endregion

                #region 查询项目档案中已注销矿权信息

                #region 重新初始化数据对象
                mdbSQL = string.Empty;
                dt = null;
                dr = null;
                #endregion
                mdbSQL = "select * from 项目档案 where 项目类型=1070";

                if (dbMDB.GetDataSet(mdbSQL).Tables.Count > 0)
                {
                    try
                    {
                        //Log.WriteLog(mdbSQL);
                        dt = dbMDB.GetDataSet(mdbSQL).Tables[0];
                    }
                    catch (Exception ex)
                    {
                        errorMsg = "同步错误，请检查采矿权数据库设置！";
                        return false;
                        throw ex;
                    }
                }
                else
                {
                    b = b && true;
                }
                #endregion

                #region 遍历项目档案登记表，删除已注销矿权
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dr = dt.Rows[i];
                    try
                    {
                        b = DelFeature(f, dr) && b;
                        //Log.WriteLog(string.Format("DelFeature()>>>>"+b.ToString() + "循环第{0}次", i + 1));
                        if (!b)
                            return b;
                        //else
                        //    continue;
                    }
                    catch (Exception ex)
                    {
                        Log.WriteLog("DelFeature()>>>>" + ex.Message);
                        return false;
                        throw ex;
                    }
                }
                #endregion
                return b;
            }
            catch (Exception ex)
            {
                Log.WriteLog("SynIGS错误>>>>" + ex.Message);
                errorMsg = "同步图形错误!";
                return false;
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
                b = f.IsFeatureExistNew("两矿", "layerShortName=" + strLayerShortName, strWhere) && b;
                #region Debug
                //Log.WriteLog(GetCKFormattedDotString(dr["区域坐标"].ToString()));
                #endregion
                //Log.WriteLog(b.ToString()+">>>>IsFeatureExitCKSQDJ执行成功>>>>" + strWhere);
                return b;

                //#region Debug
                //bool b = true;
                //string strWhere = "项目档案号='1111' and 签发时间=‘2012-04-04 00:00:00'";
                //b = f.IsFeatureExistNew("两矿", "layerShortName="+strLayerShortName, strWhere);

                
                //Log.WriteLog("IsFeatureExitCKSQDJ执行成功>>>>");
                //return b;
                //#endregion
            }
            catch (Exception ex)
            {
                Log.WriteLog("IsFeatureExitCKSQDJ()方法报错>>>>" + ex.Message);
                errorMsg = "IsFeatureExitCKSQDJ()方法报错!";
                return false;
                throw ex;
                
            }
        }
        #endregion

        #region 更新数据，重写UpdateFeature()方法
        private bool UpdateFeature(WebFeature.Feature f, DataRow dr)
        {
            try
            {
                bool b = false;
                if (IsFeatureExitCKSQDJ(f, dr))
                {
                    return true;
                }
                else
                {
                    #region attField
                    string[] attField ={   "项目档案号",
                                           "项目类型",
                                           "申请人",
                                           "电话",
                                           "地址",
                                           "邮编",
                                           "矿山名称",
                                           "经济类型",
                                           "项目审批机关",
                                           "批准文号",
                                           "资金来源",
                                           "设计年限",
                                           "开采主矿种",
                                           "设计规模",
                                           "规模单位",
                                           "开采方式",
                                           "采矿方法",
                                           "选矿方法",
                                           "应缴纳采矿权价款",
                                           "采深上限",
                                           "采深下限",
                                           "矿区面积",
                                           "采矿权使用费",
                                           "有效期限",
                                           "有效期起",
                                           "有效期止",
                                           "矿区编码",
                                           "原许可证号",
                                           "发证机关名称",
                                           "区域坐标",
                                           "设计利用储量",
                                           "其它主矿种",
                                           "签发时间"};
                    #endregion

                    #region attValue
                    string[] attValue = {   dr["项目档案号"].ToString(),
                                            dr["项目类型"].ToString(),
                                            dr["申请人"].ToString(),
                                            dr["电话"].ToString(),
                                            dr["地址"].ToString(), 
                                            dr["邮编"].ToString(),
                                            dr["矿山名称"].ToString(),
                                            dr["经济类型"].ToString(),
                                            dr["项目审批机关"].ToString(),
                                            dr["批准文号"].ToString(),
                                            dr["资金来源"].ToString(),
                                            dr["设计年限"].ToString(),
                                            dr["开采主矿种"].ToString(),
                                            dr["设计规模"].ToString(),
                                            dr["规模单位"].ToString(),
                                            dr["开采方式"].ToString(),
                                            dr["采矿方法"].ToString(),
                                            dr["选矿方法"].ToString(),
                                            dr["应缴纳采矿权价款"].ToString(),
                                            dr["采深上限"].ToString(),
                                            dr["采深下限"].ToString(),
                                            dr["矿区面积"].ToString(),
                                            dr["采矿权使用费"].ToString(),
                                            dr["有效期限"].ToString(),
                                            dr["有效期起"].ToString(),
                                            dr["有效期止"].ToString(),
                                            dr["矿区编码"].ToString(),
                                            dr["原许可证号"].ToString(),
                                            dr["发证机关名称"].ToString(),
                                            dr["区域坐标"].ToString(),
                                            dr["设计利用储量"].ToString(),
                                            dr["其它主矿种"].ToString(),
                                            dr["签发时间"].ToString()};
                    #endregion
                    
                    #region 判断当前『项目档案号』是否存在于图层中
                    string strWhere = "项目档案号='" + dr["项目档案号"].ToString() + "'";
                    #region 存在时先删除记录
                    if (f.IsFeatureExistNew("两矿", "layerShortName=" + strLayerShortName, strWhere))
                    {
                        try
                        {
                            #region 删除对应记录
                            if (!f.DelFeatureNew("两矿", "layerShortName=" + strLayerShortName, 0, strWhere))
                            {
                                b = false;
                                return b;
                            }
                            #endregion
                        }
                        catch (Exception ex)
                        {

                            throw ex;
                        }

                    }
                    #endregion
                    #endregion

                    #region 插入记录
                    //Log.WriteLog("AddFeatureNew");
                    ///尝试插入数据
                    if (f.AddFeatureNew("两矿", "layerShortName=" + strLayerShortName, GetCKFormattedDotString(dr["区域坐标"].ToString()), attField, attValue))
                    {
                        b = true;
                    }
                    else
                    {
                        b = false;
                    }
                    #endregion

                    #region UpdateFeature.Debug
                    //for (int i = 0; i < attField.Length;i++ )
                    //    Log.WriteLog(attField[i].ToString());

                    //Log.WriteLog("===========================================================");
                    //for (int i = 0; i < attValue.Length;i++ )
                    //    Log.WriteLog(attValue[i].ToString());
                    #endregion
                }
                return b;
            }
            catch(Exception ex)
            {
                errorMsg = "UpdateFeature()方法出错！";
                Log.WriteLog(errorMsg + ">>>>" + ex.Message);
                throw ex;
            }
        }
        #endregion

        #region 删除已注销要素
        public bool DelFeature(WebFeature.Feature f, DataRow dr)
        {
            try
            {
                bool b = true;
                string strWhere = "项目档案号='" + dr["项目档案号"].ToString() + "'";
                //Log.WriteLog("strWhere>>>>" + strWhere);
                #region 要素存在时，删除
                //if (f.IsFeatureExistNew("两矿","layerShortName="+strLayerShortName,strWhere))
                //{
                    b = f.DelFeatureNew("两矿", "layerShortName=" + strLayerShortName, 0, strWhere) && b;
                //}
                #endregion
                return b;
            }
            catch (Exception ex)
            {
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
                //Log.WriteLog(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>\r\n" + sb.ToString());
                return sb.ToString();
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.Message);
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
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void btn_OADbTest_Click(object sender, EventArgs e)
        {
            try
            {
                string sMessage = "";
                bool b = CM.Map.DatabaseORC.TestOracleConn(txt_OA_DBIP.Text, txt_OA_DBPort.Text, txt_OA_DBName.Text, txt_OA_DBUserName.Text, txt_OA_DBPassword.Text, ref sMessage);
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
                bool b = CM.Map.DatabaseOledb.TestAccessConn(txt_MDB_DBPATH.Text, ref sMessage);
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
                Log.WriteLog(ex.Message);
                MessageBox.Show(errorMsg.ToString());
            }
        }

    }
}
