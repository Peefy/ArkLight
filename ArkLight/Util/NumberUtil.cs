using System;
using System.Collections.Generic;
using System.Text;

namespace ArkLight.Util
{

    public static class NumberUtil
    {
        /// <summary>
        /// 判断数字是否在范围内
        /// </summary>
        /// <param name="number"></param>
        /// <param name="range1"></param>
        /// <param name="range2"></param>
        /// <returns></returns>
        public static bool JudgeNumberInRange(double number, double range1, double range2)
        {
            var max = Math.Max(range1, range2);
            var min = Math.Min(range1, range2);
            if (number >= min && number <= max)
                return true;
            return false;
        }

        /// <summary>
        /// bool类型转 true -> '是';false ->'否'
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string BoolToString(bool value)
        {
            return value == true ? "否" : "是";
        }

        /// <summary>
        /// 数字限幅
        /// </summary>
        /// <param name="value"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static double Clamp(double value, double min, double max)
        {
            if (value <= min)
                value = min;
            if (value >= max)
                value = max;
            return value;
        }

        /// <summary>
        /// 弧度转变为角度 单精度浮点
        /// </summary>
        /// <param name="rad">输入弧度大小</param>
        /// <param name="digit">小数点后保留digit位。默认2位</param>
        /// <returns></returns>
        public static float Rad2Deg(float rad, int digit = 2)
        {
            return (float)Math.Round(rad * 57.29577951 / Math.PI, digit);
        }

        /// <summary>
        /// 弧度转变为角度 双精度浮点
        /// </summary>
        /// <param name="rad">输入弧度大小</param>
        /// <param name="digit">小数点后保留digit位。默认2位</param>
        /// <returns></returns>
        public static float Rad2Deg(double rad, int digit = 2)
        {
            return (float)Math.Round(rad * 57.29577951 / Math.PI, digit);
        }

        /// <summary>
        /// 角度转变为弧度 单精度浮点
        /// </summary>
        /// <param name="deg">输入角度大小</param>
        /// <param name="digit">小数点后保留digit位。默认2位</param>
        /// <returns></returns>
        public static float Deg2Rad(float deg, int digit = 2)
        {
            return (float)Math.Round(deg * 0.01745329, digit);
        }

        /// <summary>
        /// 角度转变为弧度 双精度浮点
        /// </summary>
        /// <param name="deg">输入角度大小</param>
        /// <param name="digit">小数点后保留digit位。默认2位</param>
        /// <returns></returns>
        public static float Deg2Rad(double deg, int digit = 2)
        {
            return (float)Math.Round(deg * 0.01745329, digit);
        }

        /// <summary>
        /// 将角度范围限制在一个2*pi周期内
        /// </summary>
        /// <param name="angle"></param>
        /// <param name="minAngle"></param>
        /// <param name="maxAngle"></param>
        /// <param name="digit"></param>
        /// <returns></returns>
        public static double PutAngleIn(double angle, double minAngle = 0, double maxAngle = 360, int digit = 2)
        {
            if (Math.Round(maxAngle - minAngle) != 360)
            {
                throw new ArgumentException("parameter 'maxAngle' sub parameter 'minAngle' must be 360 deg");
            }
            while (angle <= minAngle)
                angle += 360;
            while (angle >= maxAngle)
                angle -= 360;
            return Math.Round(angle, digit);
        }

        /// <summary>
        /// 0到10的阿拉伯数字转汉字字符串
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static string IntNumberToChineseString(int num)
        {
            var str = "";
            switch (num)
            {
                case 0:
                    str = "零";
                    break;
                case 1:
                    str = "一";
                    break;
                case 2:
                    str = "贰";
                    break;
                case 3:
                    str = "三";
                    break;
                case 4:
                    str = "四";
                    break;
                case 5:
                    str = "五";
                    break;
                case 6:
                    str = "六";
                    break;
                case 7:
                    str = "七";
                    break;
                case 8:
                    str = "八";
                    break;
                case 9:
                    str = "九";
                    break;
                case 10:
                    str = "十";
                    break;
            }
            return str;
        }

        /// <summary>
        /// 返回对象obj的String值,obj为null时返回空值。
        /// </summary>
        /// <param name="obj">对象。</param>
        /// <returns>字符串。</returns>
        public static string ToObjectString(object obj)
        {
            return null == obj ? String.Empty : obj.ToString();
        }

        /// <summary>
        /// 将对象转换为数值(Int32)类型,转换失败返回-1。
        /// </summary>
        /// <param name="obj">对象。</param>
        /// <returns>Int32数值。</returns>
        public static int ToInt(object obj)
        {
            try
            {
                return int.Parse(ToObjectString(obj));
            }
            catch
            { return -1; }
        }

        /// <summary>
        /// 将对象转换为数值(Int32)类型。
        /// </summary>
        /// <param name="obj">对象。</param>
        /// <param name="returnValue">转换失败返回该值。</param>
        /// <returns>Int32数值。</returns>
        public static int ToInt(object obj, int returnValue)
        {
            try
            {
                return int.Parse(ToObjectString(obj));
            }
            catch
            { return returnValue; }
        }
        /// <summary>
        /// 将对象转换为数值(Long)类型,转换失败返回-1。
        /// </summary>
        /// <param name="obj">对象。</param>
        /// <returns>Long数值。</returns>
        public static long ToLong(object obj)
        {
            try
            {
                return long.Parse(ToObjectString(obj));
            }
            catch
            { return -1L; }
        }
        /// <summary>
        /// 将对象转换为数值(Long)类型。
        /// </summary>
        /// <param name="obj">对象。</param>
        /// <param name="returnValue">转换失败返回该值。</param>
        /// <returns>Long数值。</returns>
        public static long ToLong(object obj, long returnValue)
        {
            try
            {
                return long.Parse(ToObjectString(obj));
            }
            catch
            { return returnValue; }
        }
        /// <summary>
        /// 将对象转换为数值(Decimal)类型,转换失败返回-1。
        /// </summary>
        /// <param name="obj">对象。</param>
        /// <returns>Decimal数值。</returns>
        public static decimal ToDecimal(object obj)
        {
            try
            {
                return decimal.Parse(ToObjectString(obj));
            }
            catch
            { return -1M; }
        }

        /// <summary>
        /// 将对象转换为数值(Decimal)类型。
        /// </summary>
        /// <param name="obj">对象。</param>
        /// <param name="returnValue">转换失败返回该值。</param>
        /// <returns>Decimal数值。</returns>
        public static decimal ToDecimal(object obj, decimal returnValue)
        {
            try
            {
                return decimal.Parse(ToObjectString(obj));
            }
            catch
            { return returnValue; }
        }
        /// <summary>
        /// 将对象转换为数值(Double)类型,转换失败返回-1。
        /// </summary>
        /// <param name="obj">对象。</param>
        /// <returns>Double数值。</returns>
        public static double ToDouble(object obj)
        {
            try
            {
                return double.Parse(ToObjectString(obj));
            }
            catch
            { return -1; }
        }

        /// <summary>
        /// 将对象转换为数值(Double)类型。
        /// </summary>
        /// <param name="obj">对象。</param>
        /// <param name="returnValue">转换失败返回该值。</param>
        /// <returns>Double数值。</returns>
        public static double ToDouble(object obj, double returnValue)
        {
            try
            {
                return double.Parse(ToObjectString(obj));
            }
            catch
            { return returnValue; }
        }
        /// <summary>
        /// 将对象转换为数值(Float)类型,转换失败返回-1。
        /// </summary>
        /// <param name="obj">对象。</param>
        /// <returns>Float数值。</returns>
        public static float ToFloat(object obj)
        {
            try
            {
                return float.Parse(ToObjectString(obj));
            }
            catch
            { return -1; }
        }

        /// <summary>
        /// 将对象转换为数值(Float)类型。
        /// </summary>
        /// <param name="obj">对象。</param>
        /// <param name="returnValue">转换失败返回该值。</param>
        /// <returns>Float数值。</returns>
        public static float ToFloat(object obj, float returnValue)
        {
            try
            {
                return float.Parse(ToObjectString(obj));
            }
            catch
            { return returnValue; }
        }
        /// <summary>
        /// 将对象转换为数值(DateTime)类型,转换失败返回Now。
        /// </summary>
        /// <param name="obj">对象。</param>
        /// <returns>DateTime值。</returns>
        public static DateTime ToDateTime(object obj)
        {
            try
            {
                DateTime dt = DateTime.Parse(ToObjectString(obj));
                if (dt > DateTime.MinValue && DateTime.MaxValue > dt)
                    return dt;
                return DateTime.Now;
            }
            catch
            { return DateTime.Now; }
        }

        /// <summary>
        /// 将对象转换为数值(DateTime)类型。
        /// </summary>
        /// <param name="obj">对象。</param>
        /// <param name="returnValue">转换失败返回该值。</param>
        /// <returns>DateTime值。</returns>
        public static DateTime ToDateTime(object obj, DateTime returnValue)
        {
            try
            {
                DateTime dt = DateTime.Parse(ToObjectString(obj));
                if (dt > DateTime.MinValue && DateTime.MaxValue > dt)
                    return dt;
                return returnValue;
            }
            catch
            { return returnValue; }
        }
        /// <summary>
        /// 从Boolean转换成byte,转换失败返回0。
        /// </summary>
        /// <param name="obj">对象。</param>
        /// <returns>Byte值。</returns>
        public static byte ToByteByBool(object obj)
        {
            string text = ToObjectString(obj).Trim();
            if (text == string.Empty)
                return 0;
            else
            {
                try
                {
                    return (byte)(text.ToLower() == "true" ? 1 : 0);
                }
                catch
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// 从Boolean转换成byte。
        /// </summary>
        /// <param name="obj">对象。</param>
        /// <param name="returnValue">转换失败返回该值。</param>
        /// <returns>Byte值。</returns>
        public static byte ToByteByBool(object obj, byte returnValue)
        {
            string text = ToObjectString(obj).Trim();
            if (text == string.Empty)
                return returnValue;
            else
            {
                try
                {
                    return (byte)(text.ToLower() == "true" ? 1 : 0);
                }
                catch
                {
                    return returnValue;
                }
            }
        }
        /// <summary>
        /// 从byte转换成Boolean,转换失败返回false。
        /// </summary>
        /// <param name="obj">对象。</param>
        /// <returns>Boolean值。</returns>
        public static bool ToBoolByByte(object obj)
        {
            try
            {
                string s = ToObjectString(obj).ToLower();
                return s == "1" || s == "true" ? true : false;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 从byte转换成Boolean。
        /// </summary>
        /// <param name="obj">对象。</param>
        /// <param name="returnValue">转换失败返回该值。</param>
        /// <returns>Boolean值。</returns>
        public static bool ToBoolByByte(object obj, bool returnValue)
        {
            try
            {
                string s = ToObjectString(obj).ToLower();
                return s == "1" || s == "true" ? true : false;
            }
            catch
            {
                return returnValue;
            }
        }

        /// <summary>
        /// 判断文本obj是否为空值。
        /// </summary>
        /// <param name="obj">对象。</param>
        /// <returns>Boolean值。</returns>
        public static bool IsEmpty(string obj)
        {
            return ToObjectString(obj).Trim() == String.Empty ? true : false;
        }

        /// <summary>
        /// 判断对象是否为正确的日期值。
        /// </summary>
        /// <param name="obj">对象。</param>
        /// <returns>Boolean。</returns>
        public static bool IsDateTime(object obj)
        {
            try
            {
                DateTime dt = DateTime.Parse(ToObjectString(obj));
                if (dt > DateTime.MinValue && DateTime.MaxValue > dt)
                    return true;
                return false;
            }
            catch
            { return false; }
        }

        /// <summary>
        /// 判断对象是否为正确的Int32值。
        /// </summary>
        /// <param name="obj">对象。</param>
        /// <returns>Int32值。</returns>
        public static bool IsInt(object obj)
        {
            try
            {
                int.Parse(ToObjectString(obj));
                return true;
            }
            catch
            { return false; }
        }

        /// <summary>
        /// 判断对象是否为正确的Long值。
        /// </summary>
        /// <param name="obj">对象。</param>
        /// <returns>Long值。</returns>
        public static bool IsLong(object obj)
        {
            try
            {
                long.Parse(ToObjectString(obj));
                return true;
            }
            catch
            { return false; }
        }

        /// <summary>
        /// 判断对象是否为正确的Float值。
        /// </summary>
        /// <param name="obj">对象。</param>
        /// <returns>Float值。</returns>
        public static bool IsFloat(object obj)
        {
            try
            {
                float.Parse(ToObjectString(obj));
                return true;
            }
            catch
            { return false; }
        }

        /// <summary>
        /// 判断对象是否为正确的Double值。
        /// </summary>
        /// <param name="obj">对象。</param>
        /// <returns>Double值。</returns>
        public static bool IsDouble(object obj)
        {
            try
            {
                double.Parse(ToObjectString(obj));
                return true;
            }
            catch
            { return false; }
        }

        /// <summary>
        /// 判断对象是否为正确的Decimal值。
        /// </summary>
        /// <param name="obj">对象。</param>
        /// <returns>Decimal值。</returns>
        public static bool IsDecimal(object obj)
        {
            try
            {
                decimal.Parse(ToObjectString(obj));
                return true;
            }
            catch
            { return false; }
        }

        /// <summary>
        /// 去除字符串的所有空格。
        /// </summary>
        /// <param name="text">字符串</param>
        /// <returns>字符串</returns>
        public static string StringTrimAll(string text)
        {
            string _text = ToObjectString(text);
            string returnText = String.Empty;
            char[] chars = _text.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i].ToString() != string.Empty)
                    returnText += chars[i].ToString();
            }
            return returnText;
        }

        /// <summary>
        /// 去除数值字符串的所有空格。
        /// </summary>
        /// <param name="numricString">数值字符串</param>
        /// <returns>String</returns>
        public static string NumricTrimAll(string numricString)
        {
            string text = ToObjectString(numricString).Trim();
            string returnText = String.Empty;
            char[] chars = text.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i].ToString() == "+" || chars[i].ToString() == "-" || IsDouble(chars[i].ToString()))
                    returnText += chars[i].ToString();
            }
            return returnText;
        }

        /// <summary>
        /// 在数组中查找匹配对象类型
        /// </summary>
        /// <param name="array">数组</param>
        /// <param name="obj">对象</param>
        /// <returns>Boolean</returns>
        public static bool ArrayFind(Array array, object obj)
        {
            bool b = false;
            foreach (object obj1 in array)
            {
                if (obj.Equals(obj1))
                {
                    b = true;
                    break;
                }
            }
            return b;
        }

        /// <summary>
        /// 在数组中查找匹配字符串
        /// </summary>
        /// <param name="array">数组</param>
        /// <param name="obj">对象</param>
        /// <param name="unUpLower">是否忽略大小写</param>
        /// <returns>Boolean</returns>
        public static bool ArrayFind(Array array, string obj, bool unUpLower)
        {
            bool b = false;
            foreach (string obj1 in array)
            {
                if (!unUpLower)
                {
                    if (obj.Trim().Equals(obj1.ToString().Trim()))
                    {
                        b = true;
                        break;
                    }
                }
                else
                {
                    if (obj.Trim().ToUpper().Equals(obj1.ToString().Trim().ToUpper()))
                    {
                        b = true;
                        break;
                    }
                }
            }
            return b;
        }
        /// <summary>
        /// 替换字符串中的单引号。
        /// </summary>
        /// <param name="inputString">字符串</param>
        /// <returns>String</returns>
        public static string ReplaceInvertedComma(string inputString)
        {
            return inputString.Replace("'", "''");
        }


        /// <summary>
        /// 判断两个字节数组是否具有相同值.
        /// </summary>
        /// <param name="bytea">字节1</param>
        /// <param name="byteb">字节2</param>
        /// <returns>Boolean</returns>
        public static bool CompareByteArray(byte[] bytea, byte[] byteb)
        {
            if (null == bytea || null == byteb)
            {
                return false;
            }
            else
            {
                int aLength = bytea.Length;
                int bLength = byteb.Length;
                if (aLength != bLength)
                    return false;
                else
                {
                    bool compare = true;
                    for (int index = 0; index < aLength; index++)
                    {
                        if (bytea[index].CompareTo(byteb[index]) != 0)
                        {
                            compare = false;
                            break;
                        }
                    }
                    return compare;
                }
            }
        }


        /// <summary>
        /// 日期智能生成。
        /// </summary>
        /// <param name="inputText">字符串</param>
        /// <returns>DateTime</returns>
        public static string BuildDate(string inputText)
        {
            try
            {
                return DateTime.Parse(inputText).ToShortDateString();
            }
            catch
            {
                string text = NumricTrimAll(inputText);
                string year = DateTime.Now.Year.ToString();
                string month = DateTime.Now.Month.ToString();
                string day = DateTime.Now.Day.ToString();
                int length = text.Length;
                if (length == 0)
                    return String.Empty;
                else
                {
                    if (length <= 2)
                        day = text;
                    else if (length <= 4)
                    {
                        month = text.Substring(0, 2);
                        day = text.Substring(2, length - 2);
                    }
                    else if (length <= 6)
                    {
                        year = text.Substring(0, 4);
                        month = text.Substring(4, length - 4);
                    }
                    else if (length > 6)
                    {
                        year = text.Substring(0, 4);
                        month = text.Substring(4, 2);
                        day = text.Substring(6, length - 6);
                    }
                    try
                    {
                        return DateTime.Parse(year + "-" + month + "-" + day).ToShortDateString();
                    }
                    catch
                    {
                        return String.Empty;
                    }
                }
            }
        }

    }

}
