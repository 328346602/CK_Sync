using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CM.Map;

namespace CK_Sync
{
    class Sync
    {
        string errorMsg = string.Empty;
        string strLayerShortName = "CKSQDJ";

        /// <summary>
        /// 测试IGS服务是否正常
        /// </summary>
        /// <param name="IGS_PATH">IGS服务所在的服务器IP</param>
        /// <param name="Message">提示信息</param>
        /// <returns></returns>
        private bool TestIGS(string IGS_PATH, ref string Message)
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
                catch (Exception ex)
                {
                    Log.WriteLog(ex.Message);
                    Message = "连接图形服务失败！";
                    return false;
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.Message);
                throw ex;
            }
        }


    }
}
