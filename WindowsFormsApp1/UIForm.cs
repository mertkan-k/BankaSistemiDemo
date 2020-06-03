using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace BankSystem
{
    public partial class UIForm : System.Windows.Forms.Form
    {
        private Label labelUserInfo;
        private Label labelCash;
        private Button buttonSendMoney;
        private Button buttonGetMoney;
        private Button buttonHistory;
        private Button buttonChangePassword;
        private Button buttonLogout;
        private Button buttonRefresh;

        private ulong UserID;

        public UIForm(ulong UserID)
        {
            this.UserID = UserID;
            
            if (UserID == 0)
            {
                string message = "Kullanıcı seçmeden bu form'u kullanamazsınız!";
                string caption = "Sistem kapatılıyor.";

                MessageBox.Show(message, caption);

                Application.ExitThread();
            }

            InitializeComponent();
            InitializeUser();
        }

        private void InitializeComponent()
        {
            this.labelUserInfo = new System.Windows.Forms.Label();
            this.labelCash = new System.Windows.Forms.Label();
            this.buttonSendMoney = new System.Windows.Forms.Button();
            this.buttonGetMoney = new System.Windows.Forms.Button();
            this.buttonHistory = new System.Windows.Forms.Button();
            this.buttonChangePassword = new System.Windows.Forms.Button();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelUserInfo
            // 
            this.labelUserInfo.AutoSize = true;
            this.labelUserInfo.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelUserInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelUserInfo.Location = new System.Drawing.Point(0, 0);
            this.labelUserInfo.Name = "labelUserInfo";
            this.labelUserInfo.Size = new System.Drawing.Size(0, 18);
            this.labelUserInfo.TabIndex = 0;
            // 
            // labelCash
            // 
            this.labelCash.AutoSize = true;
            this.labelCash.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelCash.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelCash.Location = new System.Drawing.Point(250, 0);
            this.labelCash.Name = "labelCash";
            this.labelCash.Size = new System.Drawing.Size(0, 18);
            this.labelCash.TabIndex = 1;
            // 
            // buttonSendMoney
            // 
            this.buttonSendMoney.Location = new System.Drawing.Point(12, 35);
            this.buttonSendMoney.Name = "buttonSendMoney";
            this.buttonSendMoney.Size = new System.Drawing.Size(109, 23);
            this.buttonSendMoney.TabIndex = 0;
            this.buttonSendMoney.Text = "Havale/Eft";
            this.buttonSendMoney.UseVisualStyleBackColor = true;
            this.buttonSendMoney.Click += new System.EventHandler(this.buttonSendMoney_Click);
            // 
            // buttonGetMoney
            // 
            this.buttonGetMoney.Location = new System.Drawing.Point(12, 64);
            this.buttonGetMoney.Name = "buttonGetMoney";
            this.buttonGetMoney.Size = new System.Drawing.Size(109, 23);
            this.buttonGetMoney.TabIndex = 1;
            this.buttonGetMoney.Text = "Ödeme Yap";
            this.buttonGetMoney.UseVisualStyleBackColor = true;
            this.buttonGetMoney.Click += new System.EventHandler(this.buttonGetMoney_Click);
            // 
            // buttonHistory
            // 
            this.buttonHistory.Location = new System.Drawing.Point(12, 93);
            this.buttonHistory.Name = "buttonHistory";
            this.buttonHistory.Size = new System.Drawing.Size(109, 23);
            this.buttonHistory.TabIndex = 2;
            this.buttonHistory.Text = "İşlem Geçmişi";
            this.buttonHistory.UseVisualStyleBackColor = true;
            this.buttonHistory.Click += new System.EventHandler(this.buttonHistory_Click);
            // 
            // buttonChangePassword
            // 
            this.buttonChangePassword.Location = new System.Drawing.Point(127, 64);
            this.buttonChangePassword.Name = "buttonChangePassword";
            this.buttonChangePassword.Size = new System.Drawing.Size(109, 23);
            this.buttonChangePassword.TabIndex = 4;
            this.buttonChangePassword.Text = "Şifre Değiştir";
            this.buttonChangePassword.UseVisualStyleBackColor = true;
            this.buttonChangePassword.Click += new System.EventHandler(this.buttonChangePassword_Click);
            // 
            // buttonLogout
            // 
            this.buttonLogout.Location = new System.Drawing.Point(127, 93);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(109, 23);
            this.buttonLogout.TabIndex = 5;
            this.buttonLogout.Text = "Çıkış Yap";
            this.buttonLogout.UseVisualStyleBackColor = true;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonRefresh.Location = new System.Drawing.Point(127, 35);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(109, 23);
            this.buttonRefresh.TabIndex = 3;
            this.buttonRefresh.Text = "Yenile";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // UIForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 123);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.buttonLogout);
            this.Controls.Add(this.buttonChangePassword);
            this.Controls.Add(this.buttonHistory);
            this.Controls.Add(this.buttonGetMoney);
            this.Controls.Add(this.buttonSendMoney);
            this.Controls.Add(this.labelCash);
            this.Controls.Add(this.labelUserInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "UIForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Banka Sistemi";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        /*private void CloseSubWindows(object sender, FormClosingEventArgs args)
        {
            foreach (var form in subForms)
                form.Close();
        }*/

        public void InitializeUser()
        {
            User user = User.FindUser(UserID);
            
            labelUserInfo.Text = string.Format(@"{0} #{1}", user.username, user.id);
            labelCash.Text = user.cash.ToString("C", CultureInfo.CurrentCulture);

            /*if (user.username == "root")
                buttonGetMoney.Text = "Para Yükle";
            else
                buttonGetMoney.Text = "Harcama Yap";*/
        }

        private void buttonLogout_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void buttonRefresh_Click(object sender, System.EventArgs e)
        {
            User.ReadSystem();
            User user = User.FindUser(UserID);
            user = User.FindUser(user.id);
            InitializeUser();
        }

        private void buttonHistory_Click(object sender, System.EventArgs e)
        {
            User user = User.FindUser(UserID);
            Form logForm = new UILog(user.id)
            {
                Owner = this
            };
            logForm.Show();
        }

        private void buttonSendMoney_Click(object sender, System.EventArgs e)
        {
            Form transferForm = new UITransfer(this, UserID)
            {
                Owner = this
            };
            transferForm.Show();
            //this.ShowDialog(transferForm);
        }

        private void buttonChangePassword_Click(object sender, System.EventArgs e)
        {
            Form changePassForm = new UIChangePass(UserID)
            {
                Owner = this
            };
            changePassForm.Show();
        }

        private void buttonGetMoney_Click(object sender, System.EventArgs e)
        {
            Form SpendMoneyForm = new UISpendMoney(this, UserID)
            {
                Owner = this
            };
            SpendMoneyForm.Show();
        }
    }
}
