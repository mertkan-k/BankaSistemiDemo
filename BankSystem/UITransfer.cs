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
    public partial class UITransfer : Form
    {
        private IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private Button buttonSendMoney;
        private Label labelInf1;
        private TextBox textBoxTargetNo;
        private TextBox textBoxSendCash;
        private Label labelInf2;
        private Label labelSendCash;

        public ulong srcUserID;
        public ulong targetUserID;
        public ulong cash;

        public bool validTarget = false;
        private Label labelInfo;
        private Label labelInf3;
        private TextBox textBoxPassword;
        public bool validCash = false;
        private PictureBox pictureBoxBank;
        private Label labelBank;
        private Label labelTargetName;
        private UIForm _Owner;

        public UITransfer(UIForm _Owner, ulong sourceUser)
        {
            this._Owner = _Owner;
            srcUserID = sourceUser;

            InitializeComponent();

            Rehresh();
        }

        private void Rehresh()
        {
            User srcUser = User.FindUser(srcUserID);
            labelUserInfo.Text = string.Format(@"{0} #{1}", srcUser.username, srcUser.id);
            labelCash.Text = srcUser.cash.ToString("C", CultureInfo.CurrentCulture);
        }

        private Label labelUserInfo;
        private Label labelCash;

        private void InitializeComponent()
        {
            this.labelUserInfo = new System.Windows.Forms.Label();
            this.labelCash = new System.Windows.Forms.Label();
            this.buttonSendMoney = new System.Windows.Forms.Button();
            this.labelInf1 = new System.Windows.Forms.Label();
            this.textBoxTargetNo = new System.Windows.Forms.TextBox();
            this.labelInf2 = new System.Windows.Forms.Label();
            this.labelSendCash = new System.Windows.Forms.Label();
            this.textBoxSendCash = new System.Windows.Forms.TextBox();
            this.labelInfo = new System.Windows.Forms.Label();
            this.labelInf3 = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.pictureBoxBank = new System.Windows.Forms.PictureBox();
            this.labelBank = new System.Windows.Forms.Label();
            this.labelTargetName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBank)).BeginInit();
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
            this.labelCash.Location = new System.Drawing.Point(253, 0);
            this.labelCash.Name = "labelCash";
            this.labelCash.Size = new System.Drawing.Size(0, 18);
            this.labelCash.TabIndex = 1;
            this.labelCash.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buttonSendMoney
            // 
            this.buttonSendMoney.Enabled = false;
            this.buttonSendMoney.Location = new System.Drawing.Point(26, 242);
            this.buttonSendMoney.Name = "buttonSendMoney";
            this.buttonSendMoney.Size = new System.Drawing.Size(107, 23);
            this.buttonSendMoney.TabIndex = 4;
            this.buttonSendMoney.Text = "Havale Yap";
            this.buttonSendMoney.UseVisualStyleBackColor = true;
            this.buttonSendMoney.Click += new System.EventHandler(this.buttonSendMoney_Click);
            // 
            // labelInf1
            // 
            this.labelInf1.AutoSize = true;
            this.labelInf1.Location = new System.Drawing.Point(23, 46);
            this.labelInf1.Name = "labelInf1";
            this.labelInf1.Size = new System.Drawing.Size(210, 13);
            this.labelInf1.TabIndex = 1;
            this.labelInf1.Text = "Para gönderilecek hesap numarasını giriniz.";
            // 
            // textBoxTargetNo
            // 
            this.textBoxTargetNo.Location = new System.Drawing.Point(26, 62);
            this.textBoxTargetNo.MaxLength = 15;
            this.textBoxTargetNo.Name = "textBoxTargetNo";
            this.textBoxTargetNo.Size = new System.Drawing.Size(100, 20);
            this.textBoxTargetNo.TabIndex = 1;
            this.textBoxTargetNo.TextChanged += new System.EventHandler(this.textBoxTargetNo_TextChanged);
            this.textBoxTargetNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxTargetNo_KeyDown);
            // 
            // labelInf2
            // 
            this.labelInf2.AutoSize = true;
            this.labelInf2.Location = new System.Drawing.Point(23, 122);
            this.labelInf2.Name = "labelInf2";
            this.labelInf2.Size = new System.Drawing.Size(135, 13);
            this.labelInf2.TabIndex = 4;
            this.labelInf2.Text = "Gönderilecek miktarı giriniz.";
            // 
            // labelSendCash
            // 
            this.labelSendCash.AutoSize = true;
            this.labelSendCash.Location = new System.Drawing.Point(142, 141);
            this.labelSendCash.Name = "labelSendCash";
            this.labelSendCash.Size = new System.Drawing.Size(0, 13);
            this.labelSendCash.TabIndex = 6;
            // 
            // textBoxSendCash
            // 
            this.textBoxSendCash.Enabled = false;
            this.textBoxSendCash.Location = new System.Drawing.Point(26, 138);
            this.textBoxSendCash.MaxLength = 15;
            this.textBoxSendCash.Name = "textBoxSendCash";
            this.textBoxSendCash.Size = new System.Drawing.Size(100, 20);
            this.textBoxSendCash.TabIndex = 2;
            this.textBoxSendCash.TextChanged += new System.EventHandler(this.textBoxSendCash_TextChanged);
            this.textBoxSendCash.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxSendCash_KeyDown);
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Location = new System.Drawing.Point(23, 221);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(0, 13);
            this.labelInfo.TabIndex = 7;
            // 
            // labelInf3
            // 
            this.labelInf3.AutoSize = true;
            this.labelInf3.Location = new System.Drawing.Point(23, 175);
            this.labelInf3.Name = "labelInf3";
            this.labelInf3.Size = new System.Drawing.Size(107, 13);
            this.labelInf3.TabIndex = 8;
            this.labelInf3.Text = "Hesap şifrenizi giriniz.";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Enabled = false;
            this.textBoxPassword.Location = new System.Drawing.Point(26, 191);
            this.textBoxPassword.MaxLength = 15;
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(100, 20);
            this.textBoxPassword.TabIndex = 3;
            this.textBoxPassword.TextChanged += new System.EventHandler(this.textBoxSendCash_TextChanged);
            this.textBoxPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxPassword_KeyDown);
            // 
            // pictureBoxBank
            // 
            this.pictureBoxBank.Image = global::BankSystem.Properties.Resources.aibu_32;
            this.pictureBoxBank.Location = new System.Drawing.Point(26, 87);
            this.pictureBoxBank.Name = "pictureBoxBank";
            this.pictureBoxBank.Size = new System.Drawing.Size(26, 22);
            this.pictureBoxBank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxBank.TabIndex = 9;
            this.pictureBoxBank.TabStop = false;
            this.pictureBoxBank.Visible = false;
            // 
            // labelBank
            // 
            this.labelBank.AutoSize = true;
            this.labelBank.Location = new System.Drawing.Point(59, 92);
            this.labelBank.Name = "labelBank";
            this.labelBank.Size = new System.Drawing.Size(56, 13);
            this.labelBank.TabIndex = 10;
            this.labelBank.Text = "Aibu Bank";
            this.labelBank.Visible = false;
            // 
            // labelTargetName
            // 
            this.labelTargetName.AutoSize = true;
            this.labelTargetName.Location = new System.Drawing.Point(142, 65);
            this.labelTargetName.Name = "labelTargetName";
            this.labelTargetName.Size = new System.Drawing.Size(0, 13);
            this.labelTargetName.TabIndex = 3;
            // 
            // UITransfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 285);
            this.Controls.Add(this.labelBank);
            this.Controls.Add(this.pictureBoxBank);
            this.Controls.Add(this.labelInf3);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxSendCash);
            this.Controls.Add(this.labelCash);
            this.Controls.Add(this.labelUserInfo);
            this.Controls.Add(this.labelSendCash);
            this.Controls.Add(this.labelInf2);
            this.Controls.Add(this.labelTargetName);
            this.Controls.Add(this.textBoxTargetNo);
            this.Controls.Add(this.labelInf1);
            this.Controls.Add(this.buttonSendMoney);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "UITransfer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Havale Yap";
            this.Load += new System.EventHandler(this.TransferUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBank)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private void textBoxTargetNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SelectNextControl(ActiveControl, true, true, true, true);
            }

        }
        private void textBoxSendCash_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SelectNextControl(ActiveControl, true, true, true, true);
            }

        }
        private void textBoxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SelectNextControl(ActiveControl, true, true, true, true);
            }

        }

        private void textBoxTargetNo_TextChanged(object sender, EventArgs e)
        {
            User targetUser = null;

            if (UInt64.TryParse(textBoxTargetNo.Text, out targetUserID))
            {
                targetUser = User.FindUser(targetUserID);

                if (targetUser != null)
                {
                    if (targetUser.id != srcUserID)
                    {
                        String maskedText = targetUser.username;

                        for (int i = 0; i < maskedText.Length; i++)
                        {
                            if (i != 0 && i != maskedText.Length-1)
                                maskedText = maskedText.Remove(i, 1).Insert(i, "_");
                        }

                        targetUserID = targetUser.id;
                        labelTargetName.Text = maskedText;

                        pictureBoxBank.Visible = true;
                        labelBank.Visible = true;
                        textBoxSendCash.Enabled = true;
                        validTarget = true;
                        ControlButton();

                        return;
                    }
                }
            }

            if (targetUser != null && targetUserID == srcUserID)
                labelTargetName.Text = targetUser.username;
            else
                labelTargetName.Text = "";

            pictureBoxBank.Visible = false;
            labelBank.Visible = false;
            textBoxSendCash.Enabled = false;
            validTarget = false;
            ControlButton();
        }

        private void textBoxSendCash_TextChanged(object sender, EventArgs e)
        {
            if (UInt64.TryParse(textBoxSendCash.Text, out cash) && cash > 0)
            {
                labelSendCash.Text = cash.ToString("C", CultureInfo.CurrentCulture);

                User srcUser = User.FindUser(srcUserID);

                if (cash <= srcUser.cash)
                {
                    labelSendCash.ForeColor = Color.Black;
                    validCash = true;
                }
                else
                {
                    labelSendCash.ForeColor = Color.Red;
                    validCash = false;
                }

                ControlButton();
                return;
            }

            validCash = false;
            labelSendCash.Text = "";
            ControlButton();
        }

        public void ControlButton()
        {
            if (validCash && validTarget)
            {
                if (textBoxPassword.TextLength > 0)
                    buttonSendMoney.Enabled = true;
                else
                    buttonSendMoney.Enabled = false;

                textBoxPassword.Enabled = true;
            }
            else
            {
                buttonSendMoney.Enabled = false;
                textBoxPassword.Enabled = false;
            }
        }

        private void TransferUI_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
        }

        private void buttonSendMoney_Click(object sender, EventArgs e)
        {
            User.SendMoneyRet processRet = User.SendMoney(srcUserID, targetUserID, cash, textBoxPassword.Text);

            if (processRet == User.SendMoneyRet.SUCCES)
            {
                labelInfo.Text = "İşlem başarılı.";
                textBoxPassword.Text = "";
            }
            else if (processRet == User.SendMoneyRet.WRONG_PASSWORD)
            {
                labelInfo.Text = "Hesap şifresi yanlış!";
                textBoxPassword.Focus();
            }
            else
                labelInfo.Text = String.Format("İşlem başarısız oldu! {0}", processRet.ToString());

            Rehresh();
            textBoxSendCash_TextChanged(sender, null);

            _Owner.InitializeUser();
        }
    }
}
