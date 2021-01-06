using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankSystem
{
    partial class UILog : Form
    {
        private ulong pid;

        public UILog()
        {
            InitializeComponent();

            pid = 0;

            RefreshGUI();
        }

        public UILog(ulong pid_)
        {
            InitializeComponent();

            pid = pid_;

            RefreshGUI();
        }

        private void InitializeComponent()
        {
            this.listLog = new System.Windows.Forms.ListView();
            this.id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.comment = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cash = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listLog
            // 
            this.listLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.id,
            this.date,
            this.comment,
            this.cash});
            this.listLog.HideSelection = false;
            this.listLog.Location = new System.Drawing.Point(12, 12);
            this.listLog.Name = "listLog";
            this.listLog.Size = new System.Drawing.Size(588, 201);
            this.listLog.TabIndex = 0;
            this.listLog.UseCompatibleStateImageBehavior = false;
            this.listLog.View = System.Windows.Forms.View.Details;
            // 
            // id
            // 
            this.id.Text = "Kullanıcı No";
            this.id.Width = 80;
            // 
            // date
            // 
            this.date.Text = "Tarih";
            // 
            // comment
            // 
            this.comment.Text = "Açıklama";
            // 
            // cash
            // 
            this.cash.Text = "Son Bakiye";
            this.cash.Width = 80;
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(220, 229);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(140, 23);
            this.buttonRefresh.TabIndex = 1;
            this.buttonRefresh.Text = "Yenile";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // UILog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 264);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.listLog);
            this.MaximizeBox = false;
            this.Name = "UILog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "İşlem Geçmişi";
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.ListView listLog;
        private System.Windows.Forms.ColumnHeader date;
        private System.Windows.Forms.ColumnHeader comment;
        private Button buttonRefresh;
        private ColumnHeader id;
        private System.Windows.Forms.ColumnHeader cash;

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            RefreshGUI();
        }

        public void RefreshGUI()
        {
            List<Log> logData = new List<Log>();
            LogManager.GetInstance().GetAllLog(pid, ref logData);

            listLog.Items.Clear();

            foreach (Log log in logData)
            {
                ListViewItem listLogItem = new ListViewItem();
                listLogItem.Text = log.user_id.ToString();
                listLogItem.SubItems.Add(log.date.ToString());
                listLogItem.SubItems.Add(log.comment);
                listLogItem.SubItems.Add(log.cash.ToString("C", CultureInfo.CurrentCulture));

                listLog.Items.Add(listLogItem);
            }

            if (listLog.Items.Count == 0)
                listLog.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            else
                listLog.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

    }
}
