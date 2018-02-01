using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ArkLight.Util
{
    /// <summary>
    /// 验证码
    /// </summary>
    public static class StringCAPTCHA
    {
        /// <summary>
        /// create a random key
        /// </summary>
        static readonly Random Random = new Random(~unchecked((int)DateTime.Now.Ticks));
        static readonly char[] NumberList = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static readonly char[] CharList = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        static readonly char[] MixedList = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'J', 'K', 'L', 'M', 'N', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' }; //remove I & O

        #region 生成随机数字
        /// <summary>
        /// 生成随机数字
        /// </summary>
        /// <param name="Length">生成长度</param>
        public static string Number(int Length)
        {
            return Create(Length, false, NumberList);
        }

        /// <summary>
        /// 生成随机数字
        /// </summary>
        /// <param name="Length">生成长度</param>
        /// <param name="Sleep">是否要在生成前将当前线程阻止以避免重复</param>
        public static string Number(int Length, bool Sleep)
        {
            return Create(Length, Sleep, NumberList);
        }
        #endregion

        #region 生成随机字母与数字
        /// <summary>
        /// 生成随机字母与数字
        /// </summary>
        /// <param name="Length">生成长度</param>
        public static string Mixed(int Length)
        {
            return Create(Length, false, MixedList);
        }

        /// <summary>
        /// 生成随机字母与数字
        /// </summary>
        /// <param name="Length">生成长度</param>
        /// <param name="Sleep">是否要在生成前将当前线程阻止以避免重复</param>
        public static string Mixed(int Length, bool Sleep)
        {
            return Create(Length, Sleep, MixedList);
        }
        #endregion

        #region 生成随机纯字母随机数
        /// <summary>
        /// 生成随机纯字母随机数
        /// </summary>
        /// <param name="Length">生成长度</param>
        public static string Char(int Length)
        {
            return Create(Length, false, CharList);
        }

        /// <summary>
        /// 生成随机纯字母随机数
        /// </summary>
        /// <param name="Length">生成长度</param>
        /// <param name="Sleep">是否要在生成前将当前线程阻止以避免重复</param>
        public static string Char(int Length, bool Sleep)
        {
            return Create(Length, Sleep, CharList);
        }
        #endregion

        /// <summary>
        /// Create the CAPTCHA specified Length, Sleep and List.
        /// </summary>
        /// <returns>The create.</returns>
        /// <param name="Length">Length.</param>
        /// <param name="Sleep">If set to <c>true</c> sleep.</param>
        /// <param name="List">List create CAPTCHA based on</param>
        private static string Create(int Length, bool Sleep, char[] List)
        {
            if (Sleep)
                Thread.Sleep(3);
            char[] Pattern = List;
            string result = string.Empty;
            int n = Pattern.Length;

            for (int i = 0; i < Length; i++)
            {
                int rnd = Random.Next(0, n);
                result += Pattern[rnd];
            }
            return result;
        }

    }
}
