namespace WindowsFormCalendar.CalendarFolder
{
    partial class Calendar_Day
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

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.Day_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Day_label
            // 
            this.Day_label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Day_label.AutoSize = true;
            this.Day_label.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Day_label.Location = new System.Drawing.Point(3, 0);
            this.Day_label.Name = "Day_label";
            this.Day_label.Size = new System.Drawing.Size(30, 36);
            this.Day_label.TabIndex = 0;
            this.Day_label.Text = "1";
            this.Day_label.Click += new System.EventHandler(this.Day_label_Click);
            // 
            // Calendar_Day
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.Day_label);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "Calendar_Day";
            this.Size = new System.Drawing.Size(148, 148);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Calendar_Day_MouseClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Day_label;
    }
}
