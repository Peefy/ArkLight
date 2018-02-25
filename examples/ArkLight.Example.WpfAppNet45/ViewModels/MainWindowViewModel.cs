using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ArkLight.Mvvm;
using ArkLight.Util;

namespace ArkLight.Example.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private DateTime now = DateTime.Now;

        private string _todayInfo = "";
        public string TodayInfo
        {
            get => _todayInfo;
            set => SetProperty(ref _todayInfo, value);
        }
       
        public MainWindowViewModel()
        {
            Title = "人民币大小写转换器";
            RenewTodayInfo(now);
            YesterdayCommand = new Command(() =>
            {
                now -= TimeSpan.FromDays(1);
                RenewTodayInfo(now);
            });
            TomorrowCommand = new Command(() =>
            {
                now += TimeSpan.FromDays(1);
                RenewTodayInfo(now);
            });
        }

        public Command YesterdayCommand { get; set; }
        public Command TomorrowCommand { get; set; }

        public void RenewTodayInfo(DateTime time)
        {
            var c = new ChineseCalendar(time);
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
            TodayInfo = dayInfo.ToString();
        }

    }
}
