using System.Windows.Forms;

namespace BankSystem
{
    public class UIAdmin : Form
    {
        private Button buttonExit;
        private Button buttonResetUser;
        private GroupBox groupBoxDangerZone;
        private Button buttonResetLogs;
        private GroupBox groupBoxAdmin;
        private GroupBox groupBoxInfo;
        private TextBox textBoxUsername;
        private TextBox textBoxPassword;
        private Button buttonSave;
        private Button buttonResetMe;
        private Button buttonAllUsers;
        private Button buttonLog;
        private Button buttonLoginAsUser;
        private User user;

        public UIAdmin(User user)
        {
            this.user = user;
            InitializeComponent();
            InitUser();
        }

        private void InitializeComponent()
        {
            this.buttonAllUsers = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonResetUser = new System.Windows.Forms.Button();
            this.groupBoxDangerZone = new System.Windows.Forms.GroupBox();
            this.buttonResetLogs = new System.Windows.Forms.Button();
            this.groupBoxAdmin = new System.Windows.Forms.GroupBox();
            this.buttonLog = new System.Windows.Forms.Button();
            this.buttonLoginAsUser = new System.Windows.Forms.Button();
            this.groupBoxInfo = new System.Windows.Forms.GroupBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonResetMe = new System.Windows.Forms.Button();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.groupBoxDangerZone.SuspendLayout();
            this.groupBoxAdmin.SuspendLayout();
            this.groupBoxInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonAllUsers
            // 
            this.buttonAllUsers.Location = new System.Drawing.Point(6, 19);
            this.buttonAllUsers.Name = "buttonAllUsers";
            this.buttonAllUsers.Size = new System.Drawing.Size(104, 23);
            this.buttonAllUsers.TabIndex = 0;
            this.buttonAllUsers.Text = "Tüm Kullanıcılar";
            this.buttonAllUsers.UseVisualStyleBackColor = true;
            this.buttonAllUsers.Click += new System.EventHandler(this.buttonAllUsers_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(115, 48);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(104, 23);
            this.buttonExit.TabIndex = 3;
            this.buttonExit.Text = "Çıkış Yap";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonResetUser
            // 
            this.buttonResetUser.Location = new System.Drawing.Point(6, 19);
            this.buttonResetUser.Name = "buttonResetUser";
            this.buttonResetUser.Size = new System.Drawing.Size(104, 23);
            this.buttonResetUser.TabIndex = 8;
            this.buttonResetUser.Text = "Kullanıcıları Sıfırla";
            this.buttonResetUser.UseVisualStyleBackColor = true;
            this.buttonResetUser.Click += new System.EventHandler(this.buttonResetUser_Click);
            // 
            // groupBoxDangerZone
            // 
            this.groupBoxDangerZone.Controls.Add(this.buttonResetLogs);
            this.groupBoxDangerZone.Controls.Add(this.buttonResetUser);
            this.groupBoxDangerZone.Location = new System.Drawing.Point(12, 183);
            this.groupBoxDangerZone.Name = "groupBoxDangerZone";
            this.groupBoxDangerZone.Size = new System.Drawing.Size(228, 51);
            this.groupBoxDangerZone.TabIndex = 2;
            this.groupBoxDangerZone.TabStop = false;
            this.groupBoxDangerZone.Text = "Tehlikeli Bölge";
            // 
            // buttonResetLogs
            // 
            this.buttonResetLogs.Location = new System.Drawing.Point(116, 19);
            this.buttonResetLogs.Name = "buttonResetLogs";
            this.buttonResetLogs.Size = new System.Drawing.Size(104, 23);
            this.buttonResetLogs.TabIndex = 9;
            this.buttonResetLogs.Text = "Logları Sıfırla";
            this.buttonResetLogs.UseVisualStyleBackColor = true;
            this.buttonResetLogs.Click += new System.EventHandler(this.buttonResetLogs_Click);
            // 
            // groupBoxAdmin
            // 
            this.groupBoxAdmin.Controls.Add(this.buttonLog);
            this.groupBoxAdmin.Controls.Add(this.buttonLoginAsUser);
            this.groupBoxAdmin.Controls.Add(this.buttonAllUsers);
            this.groupBoxAdmin.Controls.Add(this.buttonExit);
            this.groupBoxAdmin.Location = new System.Drawing.Point(12, 13);
            this.groupBoxAdmin.Name = "groupBoxAdmin";
            this.groupBoxAdmin.Size = new System.Drawing.Size(228, 81);
            this.groupBoxAdmin.TabIndex = 0;
            this.groupBoxAdmin.TabStop = false;
            this.groupBoxAdmin.Text = "Adminname #1";
            // 
            // buttonLog
            // 
            this.buttonLog.Location = new System.Drawing.Point(115, 19);
            this.buttonLog.Name = "buttonLog";
            this.buttonLog.Size = new System.Drawing.Size(104, 23);
            this.buttonLog.TabIndex = 1;
            this.buttonLog.Text = "İşlem Geçmişi";
            this.buttonLog.UseVisualStyleBackColor = true;
            this.buttonLog.Click += new System.EventHandler(this.buttonLog_Click);
            // 
            // buttonLoginAsUser
            // 
            this.buttonLoginAsUser.Location = new System.Drawing.Point(6, 48);
            this.buttonLoginAsUser.Name = "buttonLoginAsUser";
            this.buttonLoginAsUser.Size = new System.Drawing.Size(104, 23);
            this.buttonLoginAsUser.TabIndex = 2;
            this.buttonLoginAsUser.Text = "Kullanıcı Girişi";
            this.buttonLoginAsUser.UseVisualStyleBackColor = true;
            this.buttonLoginAsUser.Click += new System.EventHandler(this.buttonLoginAsUser_Click);
            // 
            // groupBoxInfo
            // 
            this.groupBoxInfo.Controls.Add(this.buttonSave);
            this.groupBoxInfo.Controls.Add(this.buttonResetMe);
            this.groupBoxInfo.Controls.Add(this.textBoxPassword);
            this.groupBoxInfo.Controls.Add(this.textBoxUsername);
            this.groupBoxInfo.Location = new System.Drawing.Point(12, 100);
            this.groupBoxInfo.Name = "groupBoxInfo";
            this.groupBoxInfo.Size = new System.Drawing.Size(226, 77);
            this.groupBoxInfo.TabIndex = 1;
            this.groupBoxInfo.TabStop = false;
            this.groupBoxInfo.Text = "Bilgilerim";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(115, 46);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(104, 23);
            this.buttonSave.TabIndex = 7;
            this.buttonSave.Text = "Kaydet";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonResetMe
            // 
            this.buttonResetMe.Enabled = false;
            this.buttonResetMe.Location = new System.Drawing.Point(7, 46);
            this.buttonResetMe.Name = "buttonResetMe";
            this.buttonResetMe.Size = new System.Drawing.Size(104, 23);
            this.buttonResetMe.TabIndex = 6;
            this.buttonResetMe.Text = "Eski Haline Al";
            this.buttonResetMe.UseVisualStyleBackColor = true;
            this.buttonResetMe.Click += new System.EventHandler(this.buttonResetMe_Click);
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(115, 20);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(104, 20);
            this.textBoxPassword.TabIndex = 5;
            this.textBoxPassword.TextChanged += new System.EventHandler(this.textBoxPassword_TextChanged);
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new System.Drawing.Point(7, 20);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(102, 20);
            this.textBoxUsername.TabIndex = 4;
            this.textBoxUsername.TextChanged += new System.EventHandler(this.textBoxUsername_TextChanged);
            // 
            // UIAdmin
            // 
            this.ClientSize = new System.Drawing.Size(251, 244);
            this.Controls.Add(this.groupBoxInfo);
            this.Controls.Add(this.groupBoxAdmin);
            this.Controls.Add(this.groupBoxDangerZone);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "UIAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Yönetici";
            this.Load += new System.EventHandler(this.UIAdmin_Load);
            this.groupBoxDangerZone.ResumeLayout(false);
            this.groupBoxAdmin.ResumeLayout(false);
            this.groupBoxInfo.ResumeLayout(false);
            this.groupBoxInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        private void InitUser()
        {
            groupBoxAdmin.Text = string.Format("{0} #{1}", user.username, user.id);

            textBoxPassword.Text = user.password;
            textBoxUsername.Text = user.username;
        }

        private void buttonResetMe_Click(object sender, System.EventArgs e)
        {
            InitUser();
        }

        private void buttonSave_Click(object sender, System.EventArgs e)
        {
            user.password = textBoxPassword.Text;
            user.username = textBoxUsername.Text;

            new Log(user, "Yönetici hesap bilgileri değişimi.");

            User.SaveSystem();

            InitUser();
            ControlResetButton();
        }

        private void textBoxUsername_TextChanged(object sender, System.EventArgs e)
        {
            ControlResetButton();
        }
        private void textBoxPassword_TextChanged(object sender, System.EventArgs e)
        {
            ControlResetButton();
        }
        private void ControlResetButton()
        {
            if (textBoxUsername.Text != user.username || textBoxPassword.Text != user.password)
            {
                buttonResetMe.Enabled = true;
                buttonSave.Enabled = true;
            }
            else
            {
                buttonResetMe.Enabled = false;
                buttonSave.Enabled = false;
            }
        }

        private void buttonExit_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void buttonResetUser_Click(object sender, System.EventArgs e)
        {
            User.Reset();
            new Log(user, "Kullanıcıları sıfırlama işlemi.");
        }

        private void buttonResetLogs_Click(object sender, System.EventArgs e)
        {
            Log.Reset();
            new Log(user, "Logları sıfırlama işlemi.");
        }

        private void buttonLoginAsUser_Click(object sender, System.EventArgs e)
        {
            Form UIform = new UIForm(user.id)
            {
                Owner = this
            };
            UIform.Show();
        }

        private void buttonLog_Click(object sender, System.EventArgs e)
        {
            Form logForm = new UILog()
            {
                Owner = this
            };
            logForm.Show();
        }

        private void buttonAllUsers_Click(object sender, System.EventArgs e)
        {
            Form form = new UIUserMan()
            {
                Owner = this
            };
            form.Show();
        }

        private void UIAdmin_Load(object sender, System.EventArgs e)
        {
            ToolTip toolTip = new ToolTip();

            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 1000;
            toolTip.ReshowDelay = 500;
            toolTip.ShowAlways = true;

            toolTip.SetToolTip(this.buttonAllUsers, "Tüm kullanıcıların bilgilerinin görüntülendiği alana git.");
            toolTip.SetToolTip(this.buttonLog, "Tüm kullanıcıların loglarını görüntüle.");
            toolTip.SetToolTip(this.buttonLoginAsUser, "Bu kullanıcının standart paneline gir.");
            toolTip.SetToolTip(this.buttonResetLogs, "Tüm hesaplaraın tüm logları sil.");
            toolTip.SetToolTip(this.buttonResetMe, "Değiştirdiğin bilgileri geri al.");
            toolTip.SetToolTip(this.buttonSave, "Değiştirdiğin bilgileri kaydet.");
            toolTip.SetToolTip(this.buttonResetUser, "Yönetici dışındaki tüm hesapları ve bu hesaplara ait logları sil.");
        }
    }
}
