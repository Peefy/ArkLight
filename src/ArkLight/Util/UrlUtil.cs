using System;
using System.Collections.Specialized;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace ArkLight.Util
{
    public class UrlUtil
    {
        static Encoding encoding = Encoding.UTF8;

        public static string Base64Encrypt(string sourtUrl)
        {
            return Convert.ToBase64String(encoding.GetBytes(HttpUtility.UrlEncode(sourtUrl)));
        }

        public static string Base64Decrypt(string eStr)
        {
            if (IsBase64(eStr))
                return eStr;
            byte[] buffer = Convert.FromBase64String(eStr);
            string sourthUrl = encoding.GetString(buffer);
            sourthUrl = HttpUtility.UrlDecode(sourthUrl);
            return sourthUrl;
        }

        public static bool IsBase64(string eStr)
        {
            if ((eStr.Length % 4) != 0)
                return false;
            if (!Regex.IsMatch(eStr, "^[A-Z0-9/+=]*$", RegexOptions.IgnoreCase))
                return false;
            return true;
        }

        public static string UpdateParam(string url, string paramName, string value)
        {
            var keyWord = paramName + "=";
            int index = url.IndexOf(keyWord) + keyWord.Length;
            int index1 = url.IndexOf("&", index);
            if(index == -1)
            {
                url = url.Remove(index, url.Length - index);
                url = string.Concat(url, value);
            }
            url = url.Remove(index, index1 - index);
            url = url.Insert(index, value);
            return url;
        }

        public static void ParseUrl(string url, out string baseUrl, out NameValueCollection nvc)
        {
            if (url == null)
                throw new ArgumentNullException("url");

            nvc = new NameValueCollection();
            baseUrl = "";

            if (url == "")
                return;

            int questionMarkIndex = url.IndexOf('?');

            if (questionMarkIndex == -1)
            {
                baseUrl = url;
                return;
            }
            baseUrl = url.Substring(0, questionMarkIndex);
            if (questionMarkIndex == url.Length - 1)
                return;
            string ps = url.Substring(questionMarkIndex + 1);

            Regex re = new Regex(@"(^|&)?(\w+)=([^&]+)(&|$)?", RegexOptions.Compiled);
            MatchCollection mc = re.Matches(ps);

            foreach (Match m in mc)
            {
                nvc.Add(m.Result("$2").ToLower(), m.Result("$3"));
            }
        }

    }
}
