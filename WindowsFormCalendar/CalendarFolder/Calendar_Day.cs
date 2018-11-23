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
    public partial class Calendar_Day : UserControl
    {
        private byte Day = 0;
        private byte PanelNumber = 0;
        private Calendar_Base CBase = null;

        public Calendar_Day()
        {
            InitializeComponent();
            Visible = false;
        }

        internal void InsertDay(byte day, byte panelnumber, Calendar_Base cbase)
        {
            Day = day;
            PanelNumber = panelnumber;
            CBase = cbase;
            Day_label.Text = Day.ToString();
            DisplayDay();
        }

        private void DisplayDay()
        {
            Visible = true;
        }

        internal void SelectDay()
        {
            BackColor = Color.Aqua;
            CBase.PanelSelect(PanelNumber, Day);
        }

        internal void DeselectDay()
        {
            BackColor = SystemColors.Control;
        }
        
        private void Calendar_Day_MouseClick(object sender, MouseEventArgs e)
        {
            SelectDay();
        }

        private void Day_label_Click(object sender, EventArgs e)
        {
            SelectDay();
        }
    }
}
