using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CK_Sync
{
    /// <summary>
    /// 类说明： 自定义采矿权数据类
    /// 创建日期：2015-06-4
    /// 创建人：LDM
    /// </summary>
    public class CK
    {

        #region 成员变量

        //#region CK_GUID
        ///// <summary>
        ///// CK_GUID
        ///// </summary>
        //private string ck_guid;

        ///// <summary>
        ///// CK_GUID
        ///// </summary>
        //public string CK_GUID
        //{
        //    get 
        //    { 
        //        return ck_guid;
        //    }
        //    set 
        //    { 
        //        ck_guid = value;
        //    }
        //}
        //#endregion

        //#region 申请序号
        ///// <summary>
        ///// 申请序号
        ///// </summary>
        //private string shenqingxuhao;
        
        ///// <summary>
        ///// 申请序号
        ///// </summary>
        //public string ShenQingXuHao
        //{
        //    get
        //    {
        //        return shenqingxuhao;
        //    }
        //    set
        //    {
        //        shenqingxuhao = value;
        //    }
        //}
        //#endregion

        //#region 许可证号
        ///// <summary>
        ///// 许可证号
        ///// </summary>
        //private string xukezhenghao;

        ///// <summary>
        ///// 许可证号
        ///// </summary>
        //public string XuKeZhengHao
        //{
        //    get
        //    {
        //        return xukezhenghao;
        //    }
        //    set
        //    {
        //        xukezhenghao = value;
        //    }
        //}
        //#endregion

        //#region 项目档案号
        ///// <summary>
        ///// 项目档案号
        ///// </summary>
        //private string xiangmudanganhao;

        ///// <summary>
        ///// 项目档案号
        ///// </summary>
        //public string XiangMuDangAnHao
        //{
        //    get
        //    {
        //        return xiangmudanganhao;
        //    }
        //    set
        //    {
        //        xiangmudanganhao = value;
        //    }
        //}
        //#endregion

        //#region 项目类型
        ///// <summary>
        ///// 项目类型
        ///// </summary>
        //private string xiangmuleixing;

        ///// <summary>
        ///// 项目类型
        ///// </summary>
        //public string XiangMuLeiXing
        //{
        //    get
        //    {
        //        return xiangmudanganhao;
        //    }
        //    set
        //    {
        //        xiangmuleixing = value;
        //    }
        //}
        //#endregion

        //#region 申请人
        ///// <summary>
        ///// 申请人
        ///// </summary>
        //private string shenqingren;

        ///// <summary>
        ///// 申请人
        ///// </summary>
        //public string ShenQingRen
        //{
        //    get
        //    {
        //        return shenqingren;
        //    }
        //    set
        //    {
        //        shenqingren = value;
        //    }
        //}
        //#endregion

        //#region 7电话
        ///// <summary>
        ///// 电话
        ///// </summary>
        //private string dianhua;

        ///// <summary>
        ///// 电话
        ///// </summary>
        //public string DianHua
        //{
        //    get
        //    {
        //        return dianhua;
        //    }
        //    set
        //    {
        //        dianhua = value;
        //    }
        //}
        //#endregion

        //#region 8地址
        ///// <summary>
        ///// 地址
        ///// </summary>
        //private string dizhi;

        ///// <summary>
        ///// 地址
        ///// </summary>
        //public string DiZhi
        //{
        //    get
        //    {
        //        return dizhi;
        //    }
        //    set
        //    {
        //        dizhi = value;
        //    }
        //}
        //#endregion

        //#region 9邮编
        ///// <summary>
        ///// 邮编
        ///// </summary>
        //private string youbian;

        ///// <summary>
        ///// 邮编
        ///// </summary>
        //public string YouBian
        //{
        //    get
        //    {
        //        return youbian;
        //    }
        //    set
        //    {
        //        youbian = value;
        //    }
        //}
        //#endregion

        //#region 10 矿山名称
        ///// <summary>
        ///// 矿山名称
        ///// </summary>
        //private string kuangshanmingcheng;

        ///// <summary>
        ///// 矿山名称
        ///// </summary>
        //public string KuangShanMingCheng
        //{
        //    get
        //    {
        //        return kuangshanmingcheng;
        //    }
        //    set
        //    {
        //        kuangshanmingcheng = value;
        //    }
        //}
        //#endregion

        //#region 11经济类型
        ///// <summary>
        ///// 经济类型
        ///// </summary>
        //private string jingjileixing;

        ///// <summary>
        ///// 经济类型
        ///// </summary>
        //public string JingJiLeiXing
        //{
        //    get
        //    {
        //        return jingjileixing;
        //    }
        //    set
        //    {
        //        jingjileixing = value;
        //    }
        //}
        //#endregion

        //#region 12 项目审批机关
        ///// <summary>
        ///// 项目审批机关
        ///// </summary>
        //private string xiangmushenpijiguan;

        ///// <summary>
        ///// 项目审批机关
        ///// </summary>
        //public string XiangMuShenPiJiGuan
        //{
        //    get
        //    {
        //        return xiangmushenpijiguan;
        //    }
        //    set
        //    {
        //        xiangmushenpijiguan = value;
        //    }
        //}
        //#endregion

        //#region 13批准文号
        ///// <summary>
        ///// 批准文号
        ///// </summary>
        //private string pizhunwenhao;

        ///// <summary>
        ///// 批准文号
        ///// </summary>
        //public string PiZhunWenHao
        //{
        //    get
        //    {
        //        return pizhunwenhao;
        //    }
        //    set
        //    {
        //        pizhunwenhao = value;
        //    }
        //}
        //#endregion

        //#region 14 资金来源
        ///// <summary>
        ///// 资金来源
        ///// </summary>
        //private string zijinlaiyuan;

        ///// <summary>
        ///// 资金来源
        ///// </summary>
        //public string ZiJinLaiYuan
        //{
        //    get
        //    {
        //        return zijinlaiyuan;
        //    }
        //    set
        //    {
        //        zijinlaiyuan = value;
        //    }
        //}
        //#endregion

        //#region 15设计年限
        ///// <summary>
        ///// 设计年限
        ///// </summary>
        //private string shejinianxian;

        ///// <summary>
        ///// 设计年限
        ///// </summary>
        //public string SheJiNianXian
        //{
        //    get
        //    {
        //        return shejinianxian;
        //    }
        //    set
        //    {
        //        shejinianxian = value;
        //    }
        //}
        //#endregion

        //#region 16开采主矿种
        ///// <summary>
        ///// 开采主矿种
        ///// </summary>
        //private string kaicaizhukuangzhong;

        ///// <summary>
        ///// 开采主矿种
        ///// </summary>
        //public string KaiCaiZhuKuangZhong
        //{
        //    get
        //    {
        //        return kaicaizhukuangzhong;
        //    }
        //    set
        //    {
        //        kaicaizhukuangzhong = value;
        //    }
        //}
        //#endregion

        //#region 17设计规模
        ///// <summary>
        ///// 设计规模
        ///// </summary>
        //private string shejiguimo;

        ///// <summary>
        ///// 设计规模
        ///// </summary>
        //public string SheJiGuiMo
        //{
        //    get
        //    {
        //        return shejiguimo;
        //    }
        //    set
        //    {
        //        shejiguimo = value;
        //    }
        //}
        //#endregion

        //#region 18规模单位
        ///// <summary>
        ///// 规模单位
        ///// </summary>
        //private string guimodanwei;

        ///// <summary>
        ///// 规模单位
        ///// </summary>
        //public string GuiMoDanWei
        //{
        //    get
        //    {
        //        return guimodanwei;
        //    }
        //    set
        //    {
        //        guimodanwei = value;
        //    }
        //}
        //#endregion

        //#region 19开采方式
        ///// <summary>
        ///// 开采方式
        ///// </summary>
        //private string kaicaifangshi;

        ///// <summary>
        ///// 开采方式
        ///// </summary>
        //public string KaiCaiFangShi
        //{
        //    get
        //    {
        //        return kaicaifangshi;
        //    }
        //    set
        //    {
        //        kaicaifangshi = value;
        //    }
        //}
        //#endregion

        //#region 20采矿方法
        ///// <summary>
        ///// 采矿方法
        ///// </summary>
        //private string caikuangfangfa;

        ///// <summary>
        ///// 采矿方法
        ///// </summary>
        //public string CaiKuangFangFa
        //{
        //    get
        //    {
        //        return caikuangfangfa;
        //    }
        //    set
        //    {
        //        caikuangfangfa = value;
        //    }
        //}
        //#endregion

        //#region 21选矿方法
        ///// <summary>
        ///// 选矿方法
        ///// </summary>
        //private string xuankuangfangfa;

        ///// <summary>
        ///// 选矿方法
        ///// </summary>
        //public string XuanKuangFangFa
        //{
        //    get
        //    {
        //        return xuankuangfangfa;
        //    }
        //    set
        //    {
        //        xuankuangfangfa = value;
        //    }
        //}
        //#endregion

        //#region 22应缴纳采矿权价款
        ///// <summary>
        ///// 应缴纳采矿权价款
        ///// </summary>
        //private string yingjiaonacaikuangquanjiakuan;

        ///// <summary>
        ///// 应缴纳采矿权价款
        ///// </summary>
        //public string YingJiaoNaCaiKuangQuanJiaKuan
        //{
        //    get
        //    {
        //        return yingjiaonacaikuangquanjiakuan;
        //    }
        //    set
        //    {
        //        yingjiaonacaikuangquanjiakuan = value;
        //    }
        //}
        //#endregion

        //#region 23采深上限
        ///// <summary>
        ///// 采深上限
        ///// </summary>
        //private string caishenshangxian;

        ///// <summary>
        ///// 采深上限
        ///// </summary>
        //public string CaiShenShangXian
        //{
        //    get
        //    {
        //        return caishenshangxian;
        //    }
        //    set
        //    {
        //        caishenshangxian = value;
        //    }
        //}
        //#endregion

        //#region 24采深下限
        ///// <summary>
        ///// 采深下限
        ///// </summary>
        //private string caishenxiaxian;

        ///// <summary>
        ///// 采深下限
        ///// </summary>
        //public string CaiShenXiaXian
        //{
        //    get
        //    {
        //        return caishenxiaxian;
        //    }
        //    set
        //    {
        //        caishenxiaxian = value;
        //    }
        //}
        //#endregion

        //#region 25矿区面积
        ///// <summary>
        ///// 矿区面积
        ///// </summary>
        //private string kuangqumianji;

        ///// <summary>
        ///// 矿区面积
        ///// </summary>
        //public string KuangQuMianJi
        //{
        //    get
        //    {
        //        return kuangqumianji;
        //    }
        //    set
        //    {
        //        kuangqumianji = value;
        //    }
        //}
        //#endregion

        //#region 26采矿权使用费
        ///// <summary>
        ///// 采矿权使用费
        ///// </summary>
        //private string caikuangquanshiyongfei;

        ///// <summary>
        ///// 采矿权使用费
        ///// </summary>
        //public string CaiKuangQuanShiYongFei
        //{
        //    get
        //    {
        //        return caikuangquanshiyongfei;
        //    }
        //    set
        //    {
        //        caikuangquanshiyongfei = value;
        //    }
        //}
        //#endregion

        //#region 27有效期限
        ///// <summary>
        ///// 有效期限
        ///// </summary>
        //private string youxiaoqixian;

        ///// <summary>
        ///// 有效期限
        ///// </summary>
        //public string YouXiaoQiXian
        //{
        //    get
        //    {
        //        return youxiaoqixian;
        //    }
        //    set
        //    {
        //        youxiaoqixian = value;
        //    }
        //}
        //#endregion

        //#region 28 有效期起
        ///// <summary>
        ///// 有效期起
        ///// </summary>
        //private string youxiaoqiqi;

        ///// <summary>
        ///// 有效期起
        ///// </summary>
        //public string YouXiaoQiQi
        //{
        //    get
        //    {
        //        return youxiaoqiqi;
        //    }
        //    set
        //    {
        //        youxiaoqiqi = value;
        //    }
        //}
        //#endregion

        //#region 29有效期止
        ///// <summary>
        ///// 有效期止
        ///// </summary>
        //private string youxiaoqizhi;

        ///// <summary>
        ///// 有效期止
        ///// </summary>
        //public string YouXiaoQiZhi
        //{
        //    get
        //    {
        //        return youxiaoqizhi;
        //    }
        //    set
        //    {
        //        youxiaoqizhi = value;
        //    }
        //}
        //#endregion

        //#region 30矿区编码
        ///// <summary>
        ///// 矿区编码
        ///// </summary>
        //private string kuangqubianma;

        ///// <summary>
        ///// 矿区编码
        ///// </summary>
        //public string KuangQuBianMa
        //{
        //    get
        //    {
        //        return kuangqubianma;
        //    }
        //    set
        //    {
        //        kuangqubianma = value;
        //    }
        //}
        //#endregion

        //#region 31原许可证号
        ///// <summary>
        ///// 原许可证号
        ///// </summary>
        //private string yuanxukezhenghao;

        ///// <summary>
        ///// 原许可证号
        ///// </summary>
        //public string YuanXuKeZhengHao
        //{
        //    get
        //    {
        //        return yuanxukezhenghao;
        //    }
        //    set
        //    {
        //        yuanxukezhenghao = value;
        //    }
        //}
        //#endregion

        //#region 32发证机关名称
        ///// <summary>
        ///// 发证机关名称
        ///// </summary>
        //private string fazhengjiguanmingcheng;

        ///// <summary>
        ///// 发证机关名称
        ///// </summary>
        //public string FaZhengJiGuanMingCheng
        //{
        //    get
        //    {
        //        return fazhengjiguanmingcheng;
        //    }
        //    set
        //    {
        //        fazhengjiguanmingcheng = value;
        //    }
        //}
        //#endregion

        //#region 33区域坐标
        ///// <summary>
        ///// 区域坐标
        ///// </summary>
        //private string quyuzuobiao;

        ///// <summary>
        ///// 区域坐标
        ///// </summary>
        //public string QuYuZuoBiao
        //{
        //    get
        //    {
        //        return quyuzuobiao;
        //    }
        //    set
        //    {
        //        quyuzuobiao = value;
        //    }
        //}
        //#endregion

        //#region 34设计利用储量
        ///// <summary>
        ///// 设计利用储量
        ///// </summary>
        //private string shejiliyongchuliang;

        ///// <summary>
        ///// 设计利用储量
        ///// </summary>
        //public string SheJiLiYongChuLiang
        //{
        //    get
        //    {
        //        return shejiliyongchuliang;
        //    }
        //    set
        //    {
        //        shejiliyongchuliang = value;
        //    }
        //}
        //#endregion

        //#region 35其他主矿种
        ///// <summary>
        ///// 其他主矿种
        ///// </summary>
        //private string qitazhukuangzhong;

        ///// <summary>
        ///// 其他主矿种
        ///// </summary>
        //public string QiTaZhuKuangZhong
        //{
        //    get
        //    {
        //        return qitazhukuangzhong;
        //    }
        //    set
        //    {
        //        qitazhukuangzhong = value;
        //    }
        //}
        //#endregion

        //#region 36签发时间
        ///// <summary>
        ///// 签发时间
        ///// </summary>
        //private string qianfashijian;

        ///// <summary>
        ///// 签发时间
        ///// </summary>
        //public string QianFaShiJian
        //{
        //    get
        //    {
        //        return qianfashijian;
        //    }
        //    set
        //    {
        //        qianfashijian = value;
        //    }
        //}
        //#endregion

        #endregion

        public static string errorMsg = string.Empty;

        /// <summary>
        /// 采矿权数据所在图层的图层简称<LayerShortName></LayerShortName>
        /// </summary>
        public static string strLayerShortName = "CKSQDJ";

        /// <summary>
        /// MDB整行数据
        /// </summary>
        private DataRow DR;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dr"></param>
        public CK(DataRow dr)
        {
            try
            {
                this.DR = dr;
                #region 为成员变量赋值
                //this.CK_GUID =DR["CK_GUID"].ToString();//1
                //this.ShenQingXuHao = DR["申请序号"].ToString();//2
                //this.XuKeZhengHao = DR["许可证号"].ToString();//3
                //this.XiangMuDangAnHao = DR["项目档案号"].ToString();//4
                //this.XiangMuLeiXing = DR["项目类型"].ToString();//5
                //this.ShenQingRen= DR["申请人"].ToString();//6
                //this.DianHua = DR["电话"].ToString();//7
                //this.DiZhi = DR["地址"].ToString();//8
                //this.YouBian = DR["邮编"].ToString();//9
                //this.KuangShanMingCheng = DR["矿山名称"].ToString();//10
                //this.JingJiLeiXing = DR["经济类型"].ToString();//11
                //this.XiangMuShenPiJiGuan = DR["项目审批机关"].ToString();//12
                //this.PiZhunWenHao = DR["批准文号"].ToString();//13
                //this.ZiJinLaiYuan = DR["资金来源"].ToString();//14
                //this.SheJiNianXian = DR["设计年限"].ToString();//15
                //this.KaiCaiZhuKuangZhong = DR["开采主矿种"].ToString();//16
                //this.SheJiGuiMo = DR["设计规模"].ToString();//17
                //this.GuiMoDanWei = DR["规模单位"].ToString();//18
                //this.KaiCaiFangShi = DR["开采方式"].ToString();//19
                //this.CaiKuangFangFa = DR["采矿方法"].ToString();//20
                //this.XuanKuangFangFa = DR["选矿方法"].ToString();//21
                //this.YingJiaoNaCaiKuangQuanJiaKuan = DR["应缴纳采矿权价款"].ToString();//22
                //this.CaiShenShangXian = DR["采深上限"].ToString();//23
                //this.CaiShenXiaXian = DR["采深下限"].ToString();//24
                //this.KuangQuMianJi = DR["矿区面积"].ToString();//25
                //this.CaiKuangQuanShiYongFei = DR["采矿权使用费"].ToString();//26
                //this.YouXiaoQiXian = DR["有效期限"].ToString();//27
                //this.YouXiaoQiQi = DR["有效期起"].ToString();//28
                //this.YouXiaoQiZhi = DR["有效期止"].ToString();//29
                //this.KuangQuBianMa = DR["矿区编码"].ToString();//30
                //this.YuanXuKeZhengHao = DR["原许可证号"].ToString();//31
                //this.FaZhengJiGuanMingCheng = DR["发证机关名称"].ToString();//32
                //this.QuYuZuoBiao = DR["区域坐标"].ToString();//33
                //this.SheJiLiYongChuLiang = DR["设计利用储量"].ToString();//34
                //this.QiTaZhuKuangZhong = DR["其它主矿种"].ToString();//35
                //this.QianFaShiJian = DR["签发时间"].ToString();//36
                #endregion
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 比较CK对象是否相同
        /// </summary>
        /// <param name="DR"></param>
        /// <returns></returns>
        public bool Compare(CK ck)
        {
            try
            {
                bool b = this.DR==ck.DR;
                return b;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /* 重写ToString()方法
         * public override string ToString()
        {
            StringBuilder toString = new StringBuilder(); 
            toString.Append("\r\nCK_GUID>>>>" + this.CK_GUID);//1
            toString.Append("\r\n申请序号>>>>" + this.ShenQingXuHao);//2
            toString.Append("\r\n许可证号>>>>" + this.XuKeZhengHao);//3
            toString.Append("\r\n项目档案号>>>>" + this.XiangMuDangAnHao);//4
            toString.Append("\r\n项目类型>>>>" + this.XiangMuLeiXing);//5
            toString.Append("\r\n申请人>>>>" + this.ShenQingRen);//6
            toString.Append("\r\n电话>>>>" + this.DianHua);//7
            toString.Append("\r\n地址>>>>" + this.DiZhi);//8
            toString.Append("\r\n邮编>>>>" + this.YouBian);//9
            toString.Append("\r\n矿山名称>>>>" + this.KuangShanMingCheng);//10
            toString.Append("\r\n经济类型>>>>" + this.JingJiLeiXing);//11
            toString.Append("\r\n项目审批机关>>>>" + this.XiangMuShenPiJiGuan);//12
            toString.Append("\r\n批准文号>>>>" + this.PiZhunWenHao);//13
            toString.Append("\r\n资金来源>>>>" + this.ZiJinLaiYuan);//14
            toString.Append("\r\n设计年限>>>>" + this.SheJiNianXian);//15
            toString.Append("\r\n开采主矿种>>>>" + this.KaiCaiZhuKuangZhong);//16
            toString.Append("\r\n设计规模>>>>" + this.SheJiGuiMo);//17
            toString.Append("\r\n规模单位>>>>" + this.GuiMoDanWei);//18
            toString.Append("\r\n开采方式>>>>" + this.KaiCaiFangShi);//19
            toString.Append("\r\n采矿方法>>>>" + this.CaiKuangFangFa);//20
            toString.Append("\r\n选矿方法>>>>" + this.XuanKuangFangFa);//21
            toString.Append("\r\n应缴纳采矿权价款>>>>" + this.YingJiaoNaCaiKuangQuanJiaKuan);
            toString.Append("\r\n采深上限>>>>" + this.CaiShenShangXian);//23
            toString.Append("\r\n采深下限>>>>" + this.CaiShenXiaXian);//24
            toString.Append("\r\n矿区面积>>>>" + this.KuangQuMianJi);//25
            toString.Append("\r\n采矿权使用费>>>>" + this.CaiKuangQuanShiYongFei);//26
            toString.Append("\r\n有效期限>>>>" + this.YouXiaoQiXian);//27
            toString.Append("\r\n有效期起>>>>" + this.YouXiaoQiQi);//28
            toString.Append("\r\n有效期止>>>>" + this.YouXiaoQiZhi);//29
            toString.Append("\r\n矿区编码>>>>" + this.KuangQuBianMa);//30
            toString.Append("\r\n原许可证号>>>>" + this.YuanXuKeZhengHao);//31
            toString.Append("\r\n发证机关名称>>>>" + this.FaZhengJiGuanMingCheng);//32
            toString.Append("\r\n区域坐标>>>>" + this.QuYuZuoBiao);//33
            toString.Append("\r\n设计利用储量>>>>" + this.SheJiLiYongChuLiang);//34
            toString.Append("\r\n其它主矿种>>>>" + this.QiTaZhuKuangZhong);//35
            toString.Append("\r\n签发时间>>>>" + this.QianFaShiJian);//36
            toString.Append("\r\n"+"===========================================================");
            return toString.ToString();
        }
         * */

    }

}
