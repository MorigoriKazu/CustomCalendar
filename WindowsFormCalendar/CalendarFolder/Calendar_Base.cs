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
    public partial class Calendar_Base : UserControl
    {
        private Calendar_Year[] C_Years = new Calendar_Year[16];
        private Calendar_Month[] C_Month = new Calendar_Month[12];
        private Calendar_Day[] C_Days = new Calendar_Day[37];   //日パネル用配列
        private List<Calendar_Day> ActivePanel = new List<Calendar_Day>();  //アクティブな日パネルを格納する
        private List<byte> C_PanelNum = new List<byte>();       //選択した日パネルリスト
        private CalendarForm CalendarForm = null;

        private ushort SelectYear = 0;

        public Calendar_Base()
        {
            InitializeComponent();

            //カレンダー表示効率化のために配列に代入
            C_Years[0] = calendar_Year1;
            C_Years[1] = calendar_Year2;
            C_Years[2] = calendar_Year3;
            C_Years[3] = calendar_Year4;
            C_Years[4] = calendar_Year5;
            C_Years[5] = calendar_Year6;
            C_Years[6] = calendar_Year7;
            C_Years[7] = calendar_Year8;
            C_Years[8] = calendar_Year9;
            C_Years[9] = calendar_Year10;
            C_Years[10] = calendar_Year11;
            C_Years[11] = calendar_Year12;
            C_Years[12] = calendar_Year13;
            C_Years[13] = calendar_Year14;
            C_Years[14] = calendar_Year15;
            C_Years[15] = calendar_Year16;

            C_Month[0] = calendar_Month1;
            C_Month[1] = calendar_Month2;
            C_Month[2] = calendar_Month3;
            C_Month[3] = calendar_Month4;
            C_Month[4] = calendar_Month5;
            C_Month[5] = calendar_Month6;
            C_Month[6] = calendar_Month7;
            C_Month[7] = calendar_Month8;
            C_Month[8] = calendar_Month9;
            C_Month[9] = calendar_Month10;
            C_Month[10] = calendar_Month11;
            C_Month[11] = calendar_Month12;

            C_Days[0] = calendar_Day1;
            C_Days[1] = calendar_Day2;
            C_Days[2] = calendar_Day3;
            C_Days[3] = calendar_Day4;
            C_Days[4] = calendar_Day5;
            C_Days[5] = calendar_Day6;
            C_Days[6] = calendar_Day7;
            C_Days[7] = calendar_Day8;
            C_Days[8] = calendar_Day9;
            C_Days[9] = calendar_Day10;
            C_Days[10] = calendar_Day11;
            C_Days[11] = calendar_Day12;
            C_Days[12] = calendar_Day13;
            C_Days[13] = calendar_Day14;
            C_Days[14] = calendar_Day15;
            C_Days[15] = calendar_Day16;
            C_Days[16] = calendar_Day17;
            C_Days[17] = calendar_Day18;
            C_Days[18] = calendar_Day19;
            C_Days[19] = calendar_Day20;
            C_Days[20] = calendar_Day21;
            C_Days[21] = calendar_Day22;
            C_Days[22] = calendar_Day23;
            C_Days[23] = calendar_Day24;
            C_Days[24] = calendar_Day25;
            C_Days[25] = calendar_Day26;
            C_Days[26] = calendar_Day27;
            C_Days[27] = calendar_Day28;
            C_Days[28] = calendar_Day29;
            C_Days[29] = calendar_Day30;
            C_Days[30] = calendar_Day31;
            C_Days[31] = calendar_Day32;
            C_Days[32] = calendar_Day33;
            C_Days[33] = calendar_Day34;
            C_Days[34] = calendar_Day35;
            C_Days[35] = calendar_Day36;
            C_Days[36] = calendar_Day37;
        }

        //日コントロール全表示（初期起動時）
        internal void DisplayDays(ushort thisyear, byte thismonth, byte today, CalendarForm calendarform)
        {
            CalendarForm = calendarform;
            FalseVisible_Year();
            FalseVisible_Month();
            YearLabelVisible(thisyear);
            MonthLabelVisible(thismonth);
            DayPanelVisible(thisyear, thismonth);
            ActivePanel[today - 1].SelectDay();
            SelectYear = thisyear;
        }

        //単一のパネルを選ぶ場合の処理
        private void OnePanelSelect(byte panelnumber, byte day)
        {
            //パネル単体を選んだ時（パネルリストが１つあり、選択したパネルナンバーが違う場合）
            if ((C_PanelNum.Count == 1) && (C_PanelNum[0] != panelnumber))
            {
                C_Days[C_PanelNum[0]].DeselectDay();        //他で選んでいたパネルのバックカラーを戻す。
                C_PanelNum[0] = panelnumber;        //パネルリストに選択したパネルの番号を格納
            }
            //複数選択後に単一で選んだ場合の処理
            else if(C_PanelNum.Count >= 2)
            {
                //選択したパネル以外のすべてのパネルのバックカラーを戻す。
                foreach (byte count in C_PanelNum)
                {
                    C_Days[count].DeselectDay();
                }
                C_PanelNum.Clear();     //一度パネルリストをすべて削除
                C_PanelNum.Add(panelnumber);    //新たに選んだパネルの番号を格納
            }
            else if (C_PanelNum.Count == 0)
            {
                C_PanelNum.Add(panelnumber);        //パネルリストに選択したパネルの番号を格納
            }
            CalendarForm.OneDaySelect(day);     //メインフォームに選択した日を格納する。
        }

        //複数のパネルを選ぶ場合の処理
        private void MultiPanelSelect(byte panelnumber, byte day)
        {
            byte panelnum = (byte)C_PanelNum.IndexOf(panelnumber);      //選択したパネルのリストに同じものがないかを参照する

            //パネルリストにない場合
            if (panelnum == 255)
            {
                C_PanelNum.Add(panelnumber);    //パネルリストに選択したパネルの番号を追加する。
            }
            else  //パネルリストにあった場合
            {
                C_Days[C_PanelNum[panelnum]].DeselectDay();     //選択したパネルのバックカラーを戻す。
                C_PanelNum.RemoveAt(panelnum);      //パネルリストから削除
            }
            CalendarForm.MultiDaySelect(day);     //メインフォームに選択した日を格納する。
        }

        //パネルを選ぶ際に単一か複数かを判断する処理
        internal void PanelSelect(byte panelnumber, byte day)
        {
            //ctrlキーを押したまま選択すると複数
            if ((ModifierKeys & Keys.Control) == Keys.Control)
            {
                MultiPanelSelect(panelnumber, day);
            }
            else //何もキーを押さずに選択すると単一
            {
                OnePanelSelect(panelnumber, day);
            }
        }

    /**
     * ラベル、パネル表示系
     */

        //年ラベルを表示
        internal void YearLabelVisible(ushort year)
        {
            Year_Label.Text = year.ToString() + "年";
            CalendarForm.YearSelect(year);
            Year_Label.Visible = true;
        }

        //月ラベルを表示
        internal void MonthLabelVisible(byte month)
        {
            Month_Label.Text = month.ToString() + "月";
            CalendarForm.MonthSelect(month);
            Month_Label.Visible = true;
        }

        //年パネルを表示
        private void YearPanelVisible(ushort year)
        {
            YearLabelFalseVisible();
            MonthLabelFalseVisible();
            FalseVisible_Month();
            WeakLabelFalseVisible();
            FalseVisible_Day();
            YearControlVisible();
            year -= 4;
            foreach (Calendar_Year count in C_Years)
            {
                count.DisplayYear(year, this);
                count.Visible = true;
                year++;
            }
        }

        //月パネルを表示
        internal void MonthPanelVisible(ushort year)
        {
            WeakLabelFalseVisible();
            MonthLabelFalseVisible();
            FalseVisible_Day();
            FalseVisible_Year();
            YearControlFalseVisible();
            byte month = 1;
            SelectYear = year;
            foreach (Calendar_Month count in C_Month)
            {
                count.DisplayMonth(year, month, this);
                count.Visible = true;
                month++;
            }
        }

        //日パネルを表示
        internal void DayPanelVisible(ushort year, byte month)
        {
            FalseVisible_Year();
            FalseVisible_Month();
            ActivePanel.Clear();
            WeakLabelVisible();
            YearControlFalseVisible();
            byte displayday = 1;   //月初めの日
            byte EndofMonthDay = (byte)DateTime.DaysInMonth(year, month);   //月の最後の日
            DateTime Weak = new DateTime(year, month, displayday);     //月初めの曜日を出す
            byte weeknumber = (byte)Weak.DayOfWeek;     //月初めの曜日
            foreach (byte count in C_PanelNum)
            {
                C_Days[count].DeselectDay();
            }
            for (byte count = weeknumber; count <= EndofMonthDay + weeknumber - 1; count++)
            {
                ActivePanel.Add(C_Days[count]);
                ActivePanel[displayday - 1].InsertDay(displayday, count, this);
                displayday++;
            }
            C_PanelNum.Clear();     //一度パネルリストをすべて削除
        }

        //曜日ラベルを非表示にする。
        private void WeakLabelVisible()
        {
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
        }

        //年操作のパネルを表示
        private void YearControlVisible()
        {
            nextYearButton1.Visible = true;
            backYearButton1.Visible = true;
        }

    /**
    *  ラベル、パネルの非表示系 
    */

        //年パネルを非表示にする
        private void FalseVisible_Year()
        {
            foreach (Calendar_Year count in C_Years)
            {
                count.Visible = false;
            }
        }

        //月パネルを非表示にする
        private void FalseVisible_Month()
        {
            foreach (Calendar_Month count in C_Month)
            {
                count.Visible = false;
            }
        }

        //日パネルを非表示にする
        private void FalseVisible_Day()
        {
            foreach (Calendar_Day count in C_Days)
            {
                count.Visible = false;
            }
        }

        //年ラベルを非表示
        private void YearLabelFalseVisible()
        {
            Year_Label.Visible = false;
        }

        //月ラベルを非表示
        private void MonthLabelFalseVisible()
        {
            Month_Label.Visible = false;
        }

        //曜日ラベルを非表示にする。
        private void WeakLabelFalseVisible()
        {
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
        }

        //年操作のパネルを非表示
        private void YearControlFalseVisible()
        {
            nextYearButton1.Visible = false;
            backYearButton1.Visible = false;
        }

    /**
    * ボタン機能群
    */

        //年のラベルを押したとき:年のパネルを表示
        private void Year_Label_Click(object sender, EventArgs e)
        {
            YearPanelVisible(SelectYear);
        }

        //月のラベルを押したとき:月のパネルを表示
        private void Month_Label_Click(object sender, EventArgs e)
        {
            MonthPanelVisible(SelectYear);
        }

        //年を選ぶ際の１年スクロール：次年
        private void nextYearButton1_Click_1(object sender, EventArgs e)
        {
            SelectYear += 1;
            YearPanelVisible(SelectYear);
        }

        //年を選ぶ際の１年スクロール：戻年
        private void backYearButton1_Click_1(object sender, EventArgs e)
        {
            SelectYear -= 1;
            YearPanelVisible(SelectYear);
        }
    }
}
