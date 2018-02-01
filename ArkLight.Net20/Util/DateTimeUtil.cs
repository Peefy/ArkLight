using System;

namespace ArkLight.Util
{
    public static class DateTimeUtil
    {
        public static string CommonTime(DateTime dt)
        {
            TimeSpan span = DateTime.Now.Subtract(dt);
            if (span.Days > 0)
            {
                var month = (DateTime.Now.Year - dt.Year) * 12 + DateTime.Now.Month - dt.Month;

                if (month >= 12)
                {
                    return string.Format("{0}年前", (month / 12).ToString());
                }
                else if (month > 0)
                {
                    return string.Format("{0}月前", month.ToString());
                }
                else
                {
                    return string.Format("{0}天前", span.Days.ToString());
                }
            }
            else
            {
                if (span.Hours > 0)
                {
                    return string.Format("{0}小时前", span.Hours.ToString());
                }
                else
                {
                    if (span.Minutes > 0)
                    {
                        return string.Format("{0}分钟前", span.Minutes.ToString());
                    }
                    else
                    {
                        if (span.Seconds > 5)
                        {
                            return string.Format("{0}秒前", span.Seconds.ToString());
                        }
                        else
                        {
                            return "刚刚";
                        }
                    }
                }
            }

        }

        /// <summary>
        /// 获得两个日期的间隔
        /// </summary>
        /// <param name="DateTime1">日期一。</param>
        /// <param name="DateTime2">日期二。</param>
        /// <returns>日期间隔TimeSpan。</returns>
        public static TimeSpan DateDiff(DateTime DateTime1, DateTime DateTime2)
        {
            TimeSpan ts1 = new TimeSpan(DateTime1.Ticks);
            TimeSpan ts2 = new TimeSpan(DateTime2.Ticks);
            TimeSpan ts = ts1.Subtract(ts2).Duration();
            return ts;
        }

        /// <summary>
        /// 格式化日期时间
        /// <para>1. "yyyy-MM-dd";</para>
        /// <para>2. "yyyy-MM-dd HH:mm:ss";</para>
        /// <para>3. "yyyy/MM/dd";</para>
        /// <para>4. "yyyy年MM月dd日";</para>
        /// <para>5. "MM-dd";</para>
        /// <para>6. "MM/dd";</para>
        /// <para>7. "MM月dd日";</para>
        /// <para>8. "yyyy/MM";</para>
        /// <para>9. "yyyy年MM月";</para>
        /// </summary>
        /// <param name="dateTime1">日期时间</param>
        /// <param name="dateMode">显示模式</param>
        /// <returns>0-9种模式的日期</returns>
        public static string FormatDate(DateTime dateTime1, string dateMode)
        {
            switch (dateMode)
            {
                case "0":
                    return dateTime1.ToString("yyyy-MM-dd");
                case "1":
                    return dateTime1.ToString("yyyy-MM-dd HH:mm:ss");
                case "2":
                    return dateTime1.ToString("yyyy/MM/dd");
                case "3":
                    return dateTime1.ToString("yyyy年MM月dd日");
                case "4":
                    return dateTime1.ToString("MM-dd");
                case "5":
                    return dateTime1.ToString("MM/dd");
                case "6":
                    return dateTime1.ToString("MM月dd日");
                case "7":
                    return dateTime1.ToString("yyyy-MM");
                case "8":
                    return dateTime1.ToString("yyyy/MM");
                case "9":
                    return dateTime1.ToString("yyyy年MM月");
                default:
                    return dateTime1.ToString();
            }
        }

        /// <summary>
        /// 得到随机日期
        /// </summary>
        /// <param name="time1">起始日期</param>
        /// <param name="time2">结束日期</param>
        /// <returns>间隔日期之间的 随机日期</returns>
        public static DateTime GetRandomTime(DateTime time1, DateTime time2)
        {
            Random random = new Random();
            DateTime minTime = new DateTime();
            DateTime maxTime = new DateTime();

            TimeSpan ts = new System.TimeSpan(time1.Ticks - time2.Ticks);

            // 获取两个时间相隔的秒数
            double dTotalSecontds = ts.TotalSeconds;
            int iTotalSecontds = 0;

            if (dTotalSecontds > System.Int32.MaxValue)
            {
                iTotalSecontds = System.Int32.MaxValue;
            }
            else if (dTotalSecontds < System.Int32.MinValue)
            {
                iTotalSecontds = System.Int32.MinValue;
            }
            else
            {
                iTotalSecontds = (int)dTotalSecontds;
            }


            if (iTotalSecontds > 0)
            {
                minTime = time2;
                maxTime = time1;
            }
            else if (iTotalSecontds < 0)
            {
                minTime = time1;
                maxTime = time2;
            }
            else
            {
                return time1;
            }

            int maxValue = iTotalSecontds;

            if (iTotalSecontds <= System.Int32.MinValue)
                maxValue = System.Int32.MinValue + 1;

            int i = random.Next(System.Math.Abs(maxValue));

            return minTime.AddSeconds(i);
        }
    
    }

}
