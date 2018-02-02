using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ArkLight.Util
{
    public class HtmlUtils
    {
        ///<summary>   
        ///清除HTML标记   
        ///</summary>   
        ///<param name="NoHTML">包括HTML的源码</param>   
        ///<returns>已经去除后的文字</returns>   
        public static string ReplaceHtmlTag(string html, int length = 0)
        {
            string strText = Regex.Replace(html, "<[^>]+>", "");
            strText = Regex.Replace(strText, "&[^;]+;", "");
            if (length > 0 && strText.Length > length)
                return strText.Substring(0, length);
            return strText;
        }

        ///<summary>   
        ///清除HTML标记   
        ///</summary>   
        ///<param name="NoHTML">包括HTML的源码</param>   
        ///<returns>已经去除后的文字</returns>   
        public static string NoHTML(string Htmlstring)
        {
            //删除脚本   
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);

            //删除HTML   
            Regex regex = new Regex("<.+?>", RegexOptions.IgnoreCase);
            Htmlstring = regex.Replace(Htmlstring, "");
            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);

            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", "   ", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);

            Htmlstring.Replace("<", "");
            Htmlstring.Replace(">", "");
            Htmlstring.Replace("\r\n", "");

            return Htmlstring;
        }

        #region 压缩HTML输出
        /// <summary>
        /// 压缩HTML输出
        /// </summary>
        public static string ZipHtml(string Html)
        {
            Html = Regex.Replace(Html, @">\s+?<", "><");//去除HTML中的空白字符
            Html = Regex.Replace(Html, @"\r\n\s*", "");
            Html = Regex.Replace(Html, @"<body([\s|\S]*?)>([\s|\S]*?)</body>", @"<body$1>$2</body>", RegexOptions.IgnoreCase);
            return Html;
        }
        #endregion

        #region 过滤指定HTML标签
        /// <summary>
        /// 过滤指定HTML标签
        /// </summary>
        /// <param name="s_TextStr">要过滤的字符</param>
        /// <param name="html_Str">a img p div</param>
        public static string DelHtml(string s_TextStr, string html_Str)
        {
            string rStr = "";
            if (!string.IsNullOrEmpty(s_TextStr))
            {
                rStr = Regex.Replace(s_TextStr, "<" + html_Str + "[^>]*>", "", RegexOptions.IgnoreCase);
                rStr = Regex.Replace(rStr, "</" + html_Str + ">", "", RegexOptions.IgnoreCase);
            }
            return rStr;
        }
        #endregion

    }

}
