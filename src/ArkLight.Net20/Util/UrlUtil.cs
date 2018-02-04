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

        public static string CanonicalizeUrl(string url, string refer)
        {
            Uri baseUri;
            try
            {
                try
                {
                    baseUri = new Uri(refer);
                }
                catch
                {
                    return new Uri(refer).ToString();
                }
                if (url.StartsWith("?") == true)
                    url = baseUri.LocalPath + url;
                var abs = new Uri(baseUri, url);
                return abs.ToString();
            }
            catch
            {
                return "";
            }
        }

        public static string EncodeIllegalCharacterInUrl(string url)
        {
            return url.Replace(" ", "%20");
        }

        public static string FixIllegalCharacterInUrl(string url)
        {
            return url.Replace(" ", "%20").Replace("#+", "#");
        }

        public static string GetHost(string url)
        {
            var host = url;
            int i = url.IndexOf("/", 0, 3);
            if (i > 0)
            {
                host = url.Substring(0, i);
            }
            return host;
        }

        public const string patternForProtoca = "[\\w]+://";

        public static string RemoveProtocol(string url)
        {
            return Regex.Replace(url, patternForProtoca, "");
        }

        public static string GetDomain(string url)
        {
            var domain = RemoveProtocol(url);
            int i = domain.IndexOf("/", 0, 1);
            if (i > 0)
            {
                domain = domain.Substring(0, i);
            }
            return RemovePort(domain);
        }

        public static string RemovePort(string domain)
        {
            int portIndex = domain.IndexOf(":");
            if (portIndex != -1)
            {
                return domain.Substring(0, portIndex);
            }
            else
            {
                return domain;
            }
        }

        public const string PatternForCharset = "charset\\s*=\\s*['\"]*([^\\s;'\"]*)";

        public static string GetCharset(string contentType)
        {
            var collection = Regex.Matches(contentType, PatternForCharset);
            if (collection.Count >= 1)
            {
                string charset = collection[1].Value;
                return charset;
            }
            return null;
        }

    }
}
