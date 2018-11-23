using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormCalendar.CalendarFolder
{
    public partial class Calendar_Month : UserControl
    {
        private ushort Year = 0;
        private byte Month = 0;
        private Calendar_Base CalendarBase = null;

        public Calendar_Month()
        {
            InitializeComponent();
        }

        internal void DisplayMonth(ushort year, byte month, Calendar_Base calendarbase)
        {
            Year = year;
            Month = month;
            CalendarBase = calendarbase;
            label1.Text = month + "月";
        }

        private void SelectMonth()
        {
            CalendarBase.MonthLabelVisible(Month);
            CalendarBase.DayPanelVisible(Year, Month);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            SelectMonth();
        }

        private void Calendar_Month_Click(object sender, EventArgs e)
        {
            SelectMonth();
        }
    }
}
