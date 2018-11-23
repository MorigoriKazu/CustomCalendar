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
    public partial class Calendar_Year : UserControl
    {
        private ushort Year;
        private Calendar_Base CalendarBase = null;

        public Calendar_Year()
        {
            InitializeComponent();
        }

        internal void DisplayYear(ushort year, Calendar_Base calendarbase)
        {
            Year = year;
            CalendarBase = calendarbase;
            label_year.Text = year.ToString() + "年";
        }

        private void SelectYear()
        {
            CalendarBase.YearLabelVisible(Year);
            CalendarBase.MonthPanelVisible(Year);
        }

        private void label_year_Click(object sender, EventArgs e)
        {
            SelectYear();
        }

        private void Calendar_Year_Click(object sender, EventArgs e)
        {
            SelectYear();
        }
    }
}
