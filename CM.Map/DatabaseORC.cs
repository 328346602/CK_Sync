using System;
using System.Web;
using System.Data;
using System.Data.OracleClient;
using System.Data.Common;
using System.Text;
using System.Collections.Generic;

namespace CM.Map
{
    /// <summary>
    /// 数据库通用操作类
    /// </summary>
    public class DatabaseORC
    {
        public new OracleConnection Conn = new OracleConnection();

        public DatabaseORC()
        {
            //测试方法
            //string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["connectionString"].ToString();
            //中地使用方法
            string connStr = System.Configuration.ConfigurationManager.AppSettings["connectionString"].ToString();
            Conn = new OracleConnection(connStr);
        }

        public DatabaseORC(string constr)
        {
            try
            {
                Conn = new OracleConnection(constr);
            }
            catch(Exception ex)
            {

                throw ex;
            }
        }

        #region 打开数据库连接
        /// <summary>
        /// 打开数据库连接
        /// </summary>
        public void Open()
        {
            try
            {
                //打开数据库连接
                if (Conn.State == ConnectionState.Closed)
                {
                    try
                    {
                        //打开数据库连接
                        Conn.Open();
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 关闭数据库连接
        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        public void Close()
        {
            try
            {
                //判断连接的状态是否已经打开
                if (Conn.State == ConnectionState.Open)
                {
                    Conn.Close();
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog("DatabaseORC.Close();>>>>>>>>>>>>>>");
                throw ex;
            }
           
        }
        #endregion

        #region 执行带参数的SQL语句
        /// <summary>
        /// 执行不带参数的SQL语句
        /// </summary>
        /// <param name="sql">SQL语句</param>     
        public void ExecuteSql(string sql)
        {
            OracleCommand cmd = new OracleCommand(sql, Conn);
            try
            {
                Open();
                cmd.ExecuteNonQuery();
                Close();
            }
            catch (System.Data.OracleClient.OracleException e)
            {
                Close();
                throw e;
            }
        }
        #endregion

        #region 执行带参数的SQL语句
        /// <summary>
        /// 执行不带参数的SQL语句
        /// </summary>
        /// <param name="sql">SQL语句</param>     
        public object ExecuteScalarSql(string sql)
        {
            object o = null;
            OracleCommand cmd = new OracleCommand(sql, Conn);
            try
            {
                Open();
                o = cmd.ExecuteScalar();
                Close();
            }
            catch (System.Data.OracleClient.OracleException e)
            {
                Close();
                throw e;
            }
            return o;
        }
        #endregion

        #region 执行SQL语句，返回数据到DataSet中
        /// <summary>
        /// 执行SQL语句，返回数据到DataSet中
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns>返回DataSet</returns>
        public DataSet GetDataSet(string sql)
        {
            DataSet ds = new DataSet();
            try
            {
                Open();//打开数据连接
                OracleDataAdapter adapter = new OracleDataAdapter(sql, Conn);
                adapter.Fill(ds);
            }
            catch//(Exception ex)
            {
            }
            finally
            {
                Close();//关闭数据库连接
            }
            return ds;
        }
        #endregion

        #region 执行SQL语句，返回数据到自定义DataSet中
        /// <summary>
        /// 执行SQL语句，返回数据到DataSet中
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="DataSetName">自定义返回的DataSet表名</param>
        /// <returns>返回DataSet</returns>
        public DataSet GetDataSet(string sql, string DataSetName)
        {
            DataSet ds = new DataSet();
            Open();//打开数据连接
            OracleDataAdapter adapter = new OracleDataAdapter(sql, Conn);
            adapter.Fill(ds, DataSetName);
            Close();//关闭数据库连接
            return ds;
        }
        #endregion


    }


}