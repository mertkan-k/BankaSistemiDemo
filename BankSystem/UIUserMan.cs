using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace BankSystem
{
    public class UIUserMan : Form
    {
        private ListView listViewUsers;
        private ColumnHeader id;
        private ColumnHeader username;
        private ColumnHeader password;
        private Button buttonDefault;
        private TextBox textBoxUsername;
        private TextBox textBoxPassword;
        private TextBox textBoxCash;
        private Button buttonSave;
        private Button buttonRefresh;
        private Button buttonLogin;
        private ColumnHeader cash;

        public UIUserMan()
        {
            InitializeComponent();

            RefreshGUI();
        }

        private void InitializeComponent()
        {
            this.listViewUsers = new System.Windows.Forms.ListView();
            this.id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.username = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.password = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cash = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonDefault = new System.Windows.Forms.Button();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxCash = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listViewUsers
            // 
            this.listViewUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.id,
            this.username,
            this.password,
            this.cash});
            this.listViewUsers.HideSelection = false;
            this.listViewUsers.Location = new System.Drawing.Point(12, 12);
            this.listViewUsers.Name = "listViewUsers";
            this.listViewUsers.Size = new System.Drawing.Size(313, 123);
            this.listViewUsers.TabIndex = 0;
            this.listViewUsers.UseCompatibleStateImageBehavior = false;
            this.listViewUsers.View = System.Windows.Forms.View.Details;
            this.listViewUsers.SelectedIndexChanged += new System.EventHandler(this.listViewUsers_SelectedIndexChanged);
            // 
            // id
            // 
            this.id.Text = "User ID";
            this.id.Width = 57;
            // 
            // username
            // 
            this.username.Text = "Kullanıcı Adı";
            this.username.Width = 85;
            // 
            // password
            // 
            this.password.Text = "Şifre";
            this.password.Width = 72;
            // 
            // cash
            // 
            this.cash.Text = "Bakiye";
            this.cash.Width = 94;
            // 
            // buttonDefault
            // 
            this.buttonDefault.Enabled = false;
            this.buttonDefault.Location = new System.Drawing.Point(180, 168);
            this.buttonDefault.Name = "buttonDefault";
            this.buttonDefault.Size = new System.Drawing.Size(100, 23);
            this.buttonDefault.TabIndex = 4;
            this.buttonDefault.Text = "Geri Al";
            this.buttonDefault.UseVisualStyleBackColor = true;
            this.buttonDefault.Click += new System.EventHandler(this.buttonDefault_Click);
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new System.Drawing.Point(13, 142);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(100, 20);
            this.textBoxUsername.TabIndex = 0;
            this.textBoxUsername.TextChanged += new System.EventHandler(this.textBoxUsername_TextChanged);
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(119, 142);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(100, 20);
            this.textBoxPassword.TabIndex = 1;
            this.textBoxPassword.TextChanged += new System.EventHandler(this.textBoxPassword_TextChanged);
            // 
            // textBoxCash
            // 
            this.textBoxCash.Location = new System.Drawing.Point(225, 142);
            this.textBoxCash.Name = "textBoxCash";
            this.textBoxCash.Size = new System.Drawing.Size(100, 20);
            this.textBoxCash.TabIndex = 2;
            this.textBoxCash.TextChanged += new System.EventHandler(this.textBoxCash_TextChanged);
            // 
            // buttonSave
            // 
            this.buttonSave.Enabled = false;
            this.buttonSave.Location = new System.Drawing.Point(180, 197);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(100, 23);
            this.buttonSave.TabIndex = 6;
            this.buttonSave.Text = "Kaydet";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(61, 168);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(100, 23);
            this.buttonRefresh.TabIndex = 3;
            this.buttonRefresh.Text = "Yenile";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new System.Drawing.Point(61, 197);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(100, 23);
            this.buttonLogin.TabIndex = 5;
            this.buttonLogin.Text = "Hesabına Gir";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // UIUserMan
            // 
            this.ClientSize = new System.Drawing.Size(339, 229);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxCash);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxUsername);
            this.Controls.Add(this.buttonDefault);
            this.Controls.Add(this.listViewUsers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "UIUserMan";
            this.Text = "Kullanıcı Yönetimi";
            this.Load += new System.EventHandler(this.UIUserMan_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private List<User> userData;

        public void RefreshGUI()
        {
            listViewUsers.Items.Clear();

            User.GetUserData(out userData);

            foreach (User user in userData)
            {
                ListViewItem listUserItem = new ListViewItem();
                listUserItem.Text = user.id.ToString();
                listUserItem.SubItems.Add(user.username);
                listUserItem.SubItems.Add(user.password);
                listUserItem.SubItems.Add(user.cash.ToString("C", CultureInfo.CurrentCulture));

                listViewUsers.Items.Add(listUserItem);
            }

            listViewUsers.Items[0].Selected = true;

            RefreshButtons();

            /*if (listViewUsers.Items.Count != 0)
                listViewUsers.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);*/
        }

        private User selectedUser;

        private void RefreshTextBoxes()
        {
            if (selectedUser == null)
                return;

            textBoxUsername.Text = selectedUser.username;
            textBoxPassword.Text = selectedUser.password;
            textBoxCash.Text = selectedUser.cash.ToString();
        }

        private void listViewUsers_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (listViewUsers.SelectedItems.Count <= 0)
                return;

            string Suserid = listViewUsers.SelectedItems[0].Text;
            ulong userID;
            if (UInt64.TryParse(Suserid, out userID))
            {
                selectedUser = User.FindUser(userID);
                RefreshTextBoxes();
            }


        }

        private void textBoxUsername_TextChanged(object sender, EventArgs e)
        {
            RefreshButtons();
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            RefreshButtons();
        }

        private void textBoxCash_TextChanged(object sender, EventArgs e)
        {
            RefreshButtons();
        }

        private void RefreshButtons()
        {
            if (selectedUser == null)
                return;

            if ( selectedUser.username != textBoxUsername.Text ||
                selectedUser.password != textBoxPassword.Text ||
                selectedUser.cash.ToString() != textBoxCash.Text )
            {
                buttonDefault.Enabled = true;
                buttonSave.Enabled = true;
            }
            else
            {
                buttonDefault.Enabled = false;
                buttonSave.Enabled = false;
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            listViewUsers.Items.Clear();
            RefreshGUI();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            selectedUser.username = textBoxUsername.Text;
            selectedUser.password = textBoxPassword.Text;
            selectedUser.cash = UInt64.Parse(textBoxCash.Text);

            new Log(selectedUser, "Yönetici tarafından bilgileri değiştirildi.");

            User.SaveSystem();
            RefreshGUI();
        }

        private void buttonDefault_Click(object sender, EventArgs e)
        {
            User.ReadSystem();
            RefreshGUI();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            Form UIform = new UIForm(selectedUser.id)
            {
                Owner = this
            };

            new Log(selectedUser, "Yönetici tarafından hesabına girildi.");

            UIform.Show();
        }

        private void UIUserMan_Load(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();

            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 1000;
            toolTip.ReshowDelay = 500;
            toolTip.ShowAlways = true;

            toolTip.SetToolTip(this.buttonLogin, "Seçilen kullanıcının paneline doğrudan giriş yap.");
            toolTip.SetToolTip(this.buttonDefault, "Değiştirdiğin bilgileri eski haline geri getir.");
            toolTip.SetToolTip(this.buttonRefresh, "Kullanıcıları tekrar oku ve listeye ekle.");
            toolTip.SetToolTip(this.buttonSave, "Değişikliklerini kaydet.");
        }
    }
}
