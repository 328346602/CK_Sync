using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;



namespace CM.Map
{
    public class Feature
    {
        static WebFeature.Feature f = new WebFeature.Feature();
        string serviceUrl = System.Configuration.ConfigurationManager.AppSettings["IGSLandService"];
        public Feature()
        {
            try
            {
                //Console.WriteLine("Feature1");
                //Console.WriteLine(serviceUrl);
                this.serviceUrl = serviceUrl + "//Feature.asmx";
                //Console.WriteLine(f.Url);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public Feature(string strUrl)
        {
            try
            {
                //Console.WriteLine("Feature2");
                f.Url = strUrl + "/Feature.asmx";
                //Console.WriteLine(f.Url);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 增加新的要素
        /// </summary>
        /// <param name="solutionName">命名规则名称</param>
        /// <param name="inputAtt">图层信息</param>
        /// <param name="dotString">坐标串</param>
        /// <param name="attFields">属性字段</param>
        /// <param name="attValues">对应字段的属性值</param>
        /// <returns></returns>
        public bool AddFeature(string solutionName,string inputAtt,string dotString,string[] attFields,string[] attValues)
        {
            try
            {
                //if (solutionName.Length < 1)
                //    Console.WriteLine("输入的solutionName有误！");
                //if (inputAtt.Length < 1)
                //    Console.WriteLine("输入的inputAtt有误！");
                //if (dotString.Length < 1)
                //    Console.WriteLine("输入的dotString有误！");
                //if (attFields.Length < 1)
                //    Console.WriteLine("输入的attFields有误！");
                //if (attValues.Length < 1)
                //    Console.WriteLine("输入的attValues有误！");
                bool bSuccess = f.AddFeatureNew(solutionName, inputAtt, dotString,attFields,attValues);
                return bSuccess;
            }
            catch(Exception ex)
            {
                //Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// 判断指定要素是否存在
        /// </summary>
        /// <param name="solutionName">命名规则名</param>
        /// <param name="inputAtt">图层信息，例如: subjectType=DC&year=2009&scale=G</param>
        /// <param name="strWhere">图层条件语句，例如：ID = ‘5’</param>
        /// <returns>指定要素是否存在，存在返回true，不存在返回false</returns>
        public bool IsFeatureExist(string solutionName,string inputAtt,string strWhere)
        {
            try
            {
                bool bSuccess=f.IsFeatureExistNew(solutionName,inputAtt,strWhere);
                return bSuccess;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 判断数据库里面的记录与图层中是否完全一致
        /// </summary>
        /// <param name="solutionName">命名规则名</param>
        /// <param name="inputAtt">图层信息</param>
        /// <param name="strWhere">查询条件</param>
        /// <param name="strAccessPath">access数据库路径</param>
        /// <param name="strTableName">相关表名</param>
        /// <param name="keyValue">对应数据的关键字值</param>
        /// <returns></returns>
        public static bool CompareFeatureCK(string strKey,string strAccessPath)
        {
            try
            {
                DatabaseOledb db = new DatabaseOledb();
                db.Open();
                string accSQL = "select * from 采矿申请登记 where CK_GUID = '" + strKey + "'";
                DataTable dtAccess= db.GetDataSet(accSQL).Tables[0];
                db.Close();

                DataTable dtFeature = dtAccess;
                //DataTable dtFeature = f.GetLayerAttNew("两矿", "layerShortName=CKSQDJ", "CK_GUID", "CK_GUID", 10, 1, strKey, "").Tables[0];
                bool bSuccess = (dtAccess==dtFeature);
                return bSuccess;
                //bool bSuccess=(drData==drFeature);
                //return bSuccess;
            }
            catch(Exception ex)
            {
                Log.WriteLog(ex.Message);
                throw ex;
            }
        }

        public bool DelFeature(string solutionName, string inputAtt, string strWhere)
        {
            try
            {
                bool b;
                b = f.DelFeatureNew(solutionName,inputAtt,0,strWhere);
                return b;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        //public static void Main(string[] args)
        //{
        //    #region 测试Feature
        //    /*Console.WriteLine("开始执行程序！");
        //    Console.ReadKey();
        //    try
        //    {
        //        Feature f = new Feature();
        //        string[] attFields = new string[0];
        //        string[] attValues = new string[0];
        //        string solutionName=string.Empty;
        //        string inputAtt=string.Empty;
        //        string dotString=string.Empty;

        //        bool bSuccess = Feature.AddFeature(solutionName, inputAtt, dotString, attFields, attValues);
        //        if (bSuccess)
        //        {
        //            Console.Write("成功！");
        //        }
        //        else
        //        {
        //            Console.Write("失败！");
        //        }
        //        Console.WriteLine("执行完毕！");
        //    }
        //    catch (Exception ex)
        //    {

        //        Console.Write("遇到错误：" + ex.Message);
        //        throw ex;
        //    }*/
        //    #endregion

        //    #region 测试access数据库连接
        //    try
        //    {
        //        DatabaseOledb db = new DatabaseOledb();
        //        Console.WriteLine("新建DatabaseOledb对象成功>>>");
        //        db.Open();
        //        Console.WriteLine("打开DatabaseOledb对象连接成功>>>"+db.ToString());
        //        Console.ReadKey();
        //        string key=Console.ReadLine();
        //        string accSQL = "select * from 采矿申请登记 where CK_GUID like '%"+key+"%'";
        //        //string accSQL = "select * from 采矿申请登记 where CK_GUID is not null";
        //        Console.WriteLine("SQL=" + accSQL);
        //        DataTable dt=db.GetDataSet(accSQL).Tables[0];
        //        for (int i = 0; i < dt.Rows.Count;i++ )
        //        {
        //            for(int j=0;j<dt.Columns.Count;j++)
        //            {
        //                Console.WriteLine(dt.Rows[i][j].ToString());
        //            }
        //        }
        //            Console.WriteLine("执行SQL查询成功>>>");
        //        Console.ReadKey();
        //    }
        //   catch(Exception ex)
        //    {
        //        Log.WriteLog(ex.Message);
        //    }
            
        //    #endregion
        //}


    }

}
