using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.Json;

namespace ToolBox
{
    public class Translator
    {
        public string GetTranslate(string word)
        {
            string trans = "";
            try
            {
                var url = "http://fanyi.youdao.com/translate?smartresult=dict&smartresult=rule";
                var headers = new WebHeaderCollection();
                headers["Content-Type"] = "application/x-www-form-urlencoded";
                headers["user-agent"] = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36";
                headers["Referer"] = "https://www.lagou.com/jobs/list_unity3d?labelWords=&fromSearch=true&suginput=";
                var dict = new Dictionary<string, string>()
{
    {"i",word },
    {"from","AUTO" },
    {"to","AUTO" },
    {"smartresult","dict" },
    {"client", "fanyideskweb" },
    {"salt","15808837717114" },
    {"sign","22a6ee9a07d4821f04e50bd029f73de0" },
    {"ts" ,"1580883771711" },
    {"bv","38c3ccbde2d50a86f0f9606d2be5a3d8"},
    {"doctype","json" },
    {"version","2.1"},
    {"keyfrom","fanyi.web"},
    {"action","FY_BY_REALTlME" }
};
                var str = PostInf(url, headers, GetPostArgs(dict));

                using (var dt = JsonDocument.Parse(str))
                {
                    trans = dt.RootElement.GetProperty("translateResult")[0][0].GetProperty("tgt").ToString();
                }
            }
            catch
            {
            }

            return trans;
        }

        /// <summary>
        /// 把字典转化为请求字符串
        /// </summary>
        /// <param name="dict">参数字典</param>
        /// <returns>返回请求字符串</returns>
        public static string GetPostArgs(Dictionary<string, string> dict)
        {
            StringBuilder sb = new StringBuilder();
            bool first = true;
            foreach (var item in dict)
            {
                if (first)
                {
                    sb.Append(item.Key);
                    sb.Append("=");
                    sb.Append(item.Value);
                    first = false;
                }
                else
                {
                    sb.Append("&");
                    sb.Append(item.Key);
                    sb.Append("=");
                    sb.Append(item.Value);
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// 发送Post请求
        /// </summary>
        /// <param name="url">连接</param>
        /// <param name="headers">HTTP头</param>
        /// <param name="str">请求字符串</param>
        /// <returns>返回结果</returns>
        public static string PostInf(string url, WebHeaderCollection headers, string str)
        {
            //创建HTTP请求
            var re = WebRequest.Create(url) as HttpWebRequest;
            //设置请求头
            //re.Headers = headers;
            re.ContentType = "application/x-www-form-urlencoded";
            re.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36";
            re.Referer = "https://www.lagou.com/jobs/list_unity3d?labelWords=&fromSearch=true&suginput=";
            //设置访问类型为POST
            re.Method = "POST";
            //写入请求信息
            using (StreamWriter sw = new StreamWriter(re.GetRequestStream()))
            {
                sw.WriteLine(str);
            }
            //获取相应内容
            var ans = re.GetResponse();
            using (var st = new StreamReader(ans.GetResponseStream()))
            {
                return st.ReadToEnd();
            }
        }
    }
}