using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockBoy.App_Code
{
    public class IPAddressHelper
    {
        #region IP Address
        ///<summary>
        /// 取得使用者真實IP位置
        /// </summary>
        /// <param name="request"></param>
        /// <param name="isGetRealIP">取得代理伺服器IP</param>
        /// <returns></returns>
        public static string GetClientIP(HttpRequestBase request, bool isGetRealIP = true)
        {
            //有設定代理伺服器的話，透過以下的語法取得Client真正的IP
            string httpXForwardFor = GetHttpXForwardedFor(request);
            if (!string.IsNullOrEmpty(httpXForwardFor) && isGetRealIP)
            {
                return httpXForwardFor;
            }
            return GetRemoteAddr(request);
        }

        /// <summary>
        /// Client 端IP
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static string GetRemoteAddr(HttpRequestBase request)
        {
            //有設定代理伺服器的話，透過以下的語法取得Client真正的IP
            if (!string.IsNullOrEmpty(request.ServerVariables ["REMOTE_ADDR"]))
            {
                return request.ServerVariables["REMOTE_ADDR"];
            }
            return string.Empty;
        }

        /// <summary>
        /// 代理伺服器 IP
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static string GetHttpVia(HttpRequestBase request)
        {
            //有設定代理伺服器的話，透過以下的語法取得代理伺服器 IP
            if (!string.IsNullOrEmpty(request.ServerVariables["HTTP_VIA"]))
            {
                return request.ServerVariables["HTTP_VIA"];
            }
            return string.Empty;
        }

        /// <summary>
        /// 代理伺服器 後端IP
        /// <para>透過reverse proxy,該IP為使用者真實IP</para>
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static string GetHttpXForwardedFor(HttpRequestBase request)
        {
            //有設定代理伺服器的話，透過以下的語法取得Client真正的IP
            if (!string.IsNullOrEmpty(request.ServerVariables["HTTP_X_FORWARDED_FOR"]))
            {
                string temp = request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                int index = temp.IndexOf(':');//排除相關port資訊
                if (index >= 0)
                {
                    temp = temp.Substring(0, index);
                }
                return temp;
            }
            return string.Empty;
        }

        /// <summary>
        /// 由Web API 取得使用者IP
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        //public static string GetClientIP(System.Net.Http.HttpRequestMessage request)
        //{
        //    string ip = string.Empty;
        //    if (request.Properties.ContainsKey("MS_HttpContext"))
        //    {
        //        HttpContextBase context = (HttpContextBase)request.Properties["MS_HttpContext"];
        //        if (context.Request.ServerVariables["HTTP_VIA"] != null)
        //        {
        //            ip = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
        //        }
        //        else
        //        {
        //            ip = context.Request.ServerVariables["REMOTE_ADDR"].ToString();
        //        }
        //    }
        //    return ip;
        //}
        #endregion
    }
}