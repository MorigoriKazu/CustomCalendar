namespace WindowsFormCalendar.CalendarFolder
{
    partial class Calendar_Year
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.label_year = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_year
            // 
            this.label_year.AutoSize = true;
            this.label_year.Font = new System.Drawing.Font("MS UI Gothic", 18F);
            this.label_year.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_year.Location = new System.Drawing.Point(33, 43);
            this.label_year.Name = "label_year";
            this.label_year.Size = new System.Drawing.Size(82, 24);
            this.label_year.TabIndex = 0;
            this.label_year.Text = "9999年";
            this.label_year.Click += new System.EventHandler(this.label_year_Click);
            // 
            // Calendar_Year
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.label_year);
            this.Name = "Calendar_Year";
            this.Size = new System.Drawing.Size(148, 110);
            this.Click += new System.EventHandler(this.Calendar_Year_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_year;
    }
}
