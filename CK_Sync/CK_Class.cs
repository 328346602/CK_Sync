using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CM.Map;

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

        /// <summary>
        /// 错误信息
        /// </summary>
        private string errorMsg = string.Empty;

        /// <summary>
        /// 采矿权数据所在图层的图层简称<LayerShortName></LayerShortName>
        /// </summary>
        private string strLayerShortName = "CKSQDJ";

        /// <summary>
        /// 调试开关
        /// </summary>
        private bool bDebug = false;

        /// <summary>
        /// MDB整行数据
        /// </summary>
        private DataRow DR;

        /// <summary>
        /// 不带参数的构造函数
        /// </summary>
        public CK()
        {

        }

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

        /// <summary>
        /// 启用Debug方法
        /// </summary>
        public void Debug(bool b)
        {
            this.bDebug = b;
        }


        /// <summary>
        /// Debug
        /// </summary>
        /// <param name="sMsg"></param>
        private void Debug(string sMsg)
        {
            if (this.bDebug)
            {
                Log.WriteDebug(sMsg);
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


        #region 测试IGS服务是否可用
        /// <summary>
        /// 测试IGS服务是否正常
        /// </summary>
        /// <param name="IGS_PATH">IGS服务所在的服务器IP</param>
        /// <param name="Message">提示信息</param>
        /// <returns></returns>
        public bool TestIGS(string IGS_PATH, ref string sMsg)
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
                        sMsg = "连接成功";
                    }
                    else
                    {
                        sMsg = "连接图形服务失败！";
                    }
                    return b;
                }
                catch (Exception ex)
                {
                    Log.WriteLog(ex.Message);
                    sMsg = "连接图形服务出错！";
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
        #endregion

        #region 同步电子政务数据
        /// <summary>
        /// 同步Oracle数据
        /// </summary>
        /// <param name="dbORA">Oracle数据库连接</param>
        /// <param name="dbMDB">mdb数据库连接</param>
        /// <returns></returns>
        public bool SynORA(CM.Map.DatabaseORC dbORA, CM.Map.DatabaseOledb dbMDB,ref string sMsg)
        {

            try
            {
                bool b = true;

                string mdbSQL = "select * from 采矿申请登记 where 签发时间 is not null";
                DataTable dt = dbMDB.GetDataSet(mdbSQL).Tables[0];
                DataRow dr = null;
                string oraSQL = string.Empty;
                string upSQL = string.Empty;

                #region 更新『采矿申请登记』表
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dr = dt.Rows[i];
                    oraSQL = "select * from 采矿申请登记 where 项目档案号='" + dr["项目档案号"] + "' and 签发时间=to_date('" + dr["签发时间"] + "','yyyy-mm-dd hh24:mi:ss')";
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
                this.errorMsg = "同步MapGIS一张图数据库时出错，请检查相关配置信息！";
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
                f.Url = "http://" + IGSUri + "/IGSLandService/Feature.asmx"; ;
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
                        this.errorMsg = "同步错误，请检查采矿权数据库设置！";
                        return false;
                        throw ex;
                    }
                }
                else
                {
                    this.errorMsg = "同步错误，采矿权数据库(MDB)中未查询到数据！";
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
                        this.errorMsg = "同步错误，请检查采矿权数据库设置！";
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
                this.errorMsg = "同步图形错误!";
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
        private bool IsFeatureExitCKSQDJ(WebFeature.Feature f, DataRow dr)//CM.Map.Feature f,DataRow dr)
        {
            try
            {
                bool b = false;
                string strWhere = "项目档案号='" + dr["项目档案号"] + "' and 签发时间=‘" + dr["签发时间"] + "'";
                b = f.IsFeatureExistNew("两矿", "layerShortName=" + this.strLayerShortName, strWhere);
                return b;
            }
            catch (Exception ex)
            {
                Log.WriteLog("IsFeatureExitCKSQDJ()方法报错>>>>" + ex.Message);
                this.errorMsg = "IsFeatureExitCKSQDJ()方法报错!";
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
                    if (f.AddFeatureNew("两矿", "layerShortName=" + strLayerShortName, GetCKFormattedDotString(dr["区域坐标"].ToString(),false), attField, attValue))
                    {
                        b = true;
                    }
                    else
                    {
                        b = false;
                    }
                    #endregion
                }
                return b;
            }
            catch (Exception ex)
            {
                this.errorMsg = "UpdateFeature()方法出错！";
                Log.WriteLog(this.errorMsg + ">>>>" + ex.Message);
                throw ex;
            }
        }
        #endregion

        #region 删除已注销要素
        private bool DelFeature(WebFeature.Feature f, DataRow dr)
        {
            try
            {
                bool b = true;
                string strWhere = "项目档案号='" + dr["项目档案号"].ToString() + "'";
                //Log.WriteLog("strWhere>>>>" + strWhere);
                #region 要素存在时，删除
                if (f.IsFeatureExistNew("两矿", "layerShortName=" + this.strLayerShortName, strWhere))
                {
                    b = f.DelFeatureNew("两矿", "layerShortName=" + this.strLayerShortName, 0, strWhere) && b;
                }
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
        private string UpdateSQL(DataRow dr, string tableName)
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

        public string GetCKFormattedDotString(string strDot,bool DH)
        {
            try
            {
                if(DH)
                {
                    return GetCKFormattedDotString(strDot);
                }
                else
                {
                    return GetCKFormattedDotStringWithoutDH(strDot);
                }
            }
            catch(Exception ex)
            {
                Error(ex);
                throw ex;
            }
        }

        #region 采探矿数据库坐标格式化
        /// <summary>
        /// 格式化采矿权数据库中储存的坐标串
        /// </summary>
        /// <param name="strDot">坐标串</param>
        /// <returns>格式化后的坐标串</returns>
        private string GetCKFormattedDotString(string strDot)
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
            //输出Debug
            Debug(strDotString);
            return strDotString;
        }
        #endregion

        #region 采探矿数据库坐标格式化(去带号)
        /// <summary>
        /// 格式化采矿权数据库中储存的坐标串(去带号)
        /// </summary>
        /// <param name="strDot">坐标串</param>
        /// <returns>格式化后的坐标串</returns>
        private string GetCKFormattedDotStringWithoutDH(string strDot)
        {
            ///从成员变量中取坐标
            //string strDot = this.DR["区域坐标"].ToString();
            Debug(strDot);
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
                        strDotString += strDots[iCurIndex] + "," + strDots[iCurIndex + 1].Substring(2, strDots[iCurIndex + 1].Length-2) + " ";
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
            //输出Debug
            Debug(strDotString);
            return strDotString;
        }
        #endregion

        private void Error(Exception ex)
        {
            if (this.bDebug)
            {
                CM.Map.Log.WriteError(ex.Message);
            }
            Log.WriteException(ex);
        }
    }

}
