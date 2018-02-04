using System;
using System.Collections.Generic;
using System.Text;

using ArkLight.Collection;
using ArkLight.Util;

namespace ArkLight.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var canlender = new ChineseCalendar(DateTime.Now);
            Console.WriteLine(canlender.WeekDayStr);
            ChineseCalendar c = new ChineseCalendar(DateTime.Now);
            StringBuilder dayInfo = new StringBuilder();
            dayInfo.Append("阳历：" + c.DateString + "\r\n");
            dayInfo.Append("农历：" + c.ChineseDateString + "\r\n");
            dayInfo.Append("星期：" + c.WeekDayStr);
            dayInfo.Append("时辰：" + c.ChineseHour + "\r\n");
            dayInfo.Append("属相：" + c.AnimalString + "\r\n");
            dayInfo.Append("节气：" + c.ChineseTwentyFourDay + "\r\n");
            dayInfo.Append("前一个节气：" + c.ChineseTwentyFourPrevDay + "\r\n");
            dayInfo.Append("下一个节气：" + c.ChineseTwentyFourNextDay + "\r\n");
            dayInfo.Append("节日：" + c.DateHoliday + "\r\n");
            dayInfo.Append("干支：" + c.GanZhiDateString + "\r\n");
            dayInfo.Append("星宿：" + c.ChineseConstellation + "\r\n");
            dayInfo.Append("星座：" + c.Constellation + "\r\n");
            Console.WriteLine(dayInfo.ToString());
            Console.WriteLine(RegexUtil.IsEmail("xpf6677@163.com"));
            Console.ReadLine();
        }
    }
}
