using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormCalendar
{
    public partial class CalendarForm : Form
    {
        private ushort SelectYear = 0;
        private byte SelectMonth = 0;
        private List<byte> SelectDay = new List<byte>();

        public CalendarForm()
        {
            InitializeComponent();
            SelectDay.Add(0);
            Start();
        }

        //初期起動:本日を表示する
        private void Start()
        {
            DateTime Now = DateTime.Today;  //本日を定義する。
            ushort Year = (ushort)Now.Year; //本日の年
            byte Month = (byte)Now.Month;   //本日の月
            byte Day = (byte)Now.Day;       //本日
            calendar_Base1.DisplayDays(Year, Month, Day, this);
        }

        //年選択
        internal void YearSelect(ushort year)
        {
            SelectYear = year;
        }

        //月選択
        internal void MonthSelect(byte month)
        {
            SelectMonth = month;
        }

        //単日選択
        internal void OneDaySelect(byte day)
        {
            if (SelectDay.Count >= 2)
            {
                SelectDay.Clear();
                SelectDay.Add(day);
            }
            else
            {
                SelectDay[0] = day;
            }
        }

        //複数日選択
        internal void MultiDaySelect(byte day)
        {
            byte daynum = (byte)SelectDay.IndexOf(day);      //選択したパネルのリストに同じものがないかを参照する
            if (daynum == 255)
            {
                SelectDay.Add(day);
            }
            else
            {
                SelectDay.RemoveAt(daynum);
            }
        }
    }
}
