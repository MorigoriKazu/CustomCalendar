namespace WindowsFormCalendar
{
    partial class CalendarForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.calendar_Base1 = new WindowsFormCalendar.CalendarFolder.Calendar_Base();
            this.SuspendLayout();
            // 
            // calendar_Base1
            // 
            this.calendar_Base1.AutoSize = true;
            this.calendar_Base1.Location = new System.Drawing.Point(12, 13);
            this.calendar_Base1.Name = "calendar_Base1";
            this.calendar_Base1.Size = new System.Drawing.Size(644, 690);
            this.calendar_Base1.TabIndex = 0;
            // 
            // CalendarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(668, 715);
            this.Controls.Add(this.calendar_Base1);
            this.Name = "CalendarForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CalendarFolder.Calendar_Base calendar_Base1;
    }
}

