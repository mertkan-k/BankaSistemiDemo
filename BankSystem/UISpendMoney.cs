using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using static BankSystem.BusinessManager;

namespace BankSystem
{
    public partial class UISpendMoney : Form
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
        public ulong targetBusinessID;
        public ulong cash;

        public bool validTarget = false;
        private Label labelInfo;
        private Label labelInf3;
        private TextBox textBoxPassword;
        public bool validCash = false;
        private Label labelBank;
        private PictureBox pictureBoxBank;
        private UIForm _Owner;

        public UISpendMoney(UIForm _Owner, ulong sourceUser)
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
            this.labelBank = new System.Windows.Forms.Label();
            this.pictureBoxBank = new System.Windows.Forms.PictureBox();
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
            this.labelInf1.Size = new System.Drawing.Size(223, 13);
            this.labelInf1.TabIndex = 1;
            this.labelInf1.Text = "Ödeme yapılacak iş merkezi numarasını giriniz.";
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
            this.labelInf2.Size = new System.Drawing.Size(122, 13);
            this.labelInf2.TabIndex = 4;
            this.labelInf2.Text = "Ödenecek miktarı giriniz.";
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
            // labelBank
            // 
            this.labelBank.AutoSize = true;
            this.labelBank.Location = new System.Drawing.Point(59, 92);
            this.labelBank.Name = "labelBank";
            this.labelBank.Size = new System.Drawing.Size(27, 13);
            this.labelBank.TabIndex = 10;
            this.labelBank.Text = "N11";
            this.labelBank.Visible = false;
            // 
            // pictureBoxBank
            // 
            this.pictureBoxBank.Image = global::BankSystem.Properties.Resources.n11;
            this.pictureBoxBank.Location = new System.Drawing.Point(26, 88);
            this.pictureBoxBank.Name = "pictureBoxBank";
            this.pictureBoxBank.Size = new System.Drawing.Size(27, 26);
            this.pictureBoxBank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxBank.TabIndex = 11;
            this.pictureBoxBank.TabStop = false;
            this.pictureBoxBank.Visible = false;
            // 
            // UISpendMoney
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 285);
            this.Controls.Add(this.pictureBoxBank);
            this.Controls.Add(this.labelBank);
            this.Controls.Add(this.labelInf3);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxSendCash);
            this.Controls.Add(this.labelCash);
            this.Controls.Add(this.labelUserInfo);
            this.Controls.Add(this.labelSendCash);
            this.Controls.Add(this.labelInf2);
            this.Controls.Add(this.textBoxTargetNo);
            this.Controls.Add(this.labelInf1);
            this.Controls.Add(this.buttonSendMoney);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "UISpendMoney";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ödeme Yap";
            this.Load += new System.EventHandler(this.UISpendMoney_Load);
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
            Business targetBusiness = default;

            if (UInt64.TryParse(textBoxTargetNo.Text, out targetBusinessID))
            {
                if (BusinessManager.Instance.Find(targetBusinessID, out targetBusiness))
                {
                    labelBank.Text = targetBusiness.name;

                    pictureBoxBank.Visible = true;
                    pictureBoxBank.Image = targetBusiness.image;

                    labelBank.Visible = true;
                    textBoxSendCash.Enabled = true;
                    validTarget = true;
                    ControlButton();

                    return;
                }
            }

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

        private void UISpendMoney_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
        }

        private void buttonSendMoney_Click(object sender, EventArgs e)
        {
            User.PaymentRet processRet = User.Payment(srcUserID, targetBusinessID, cash, textBoxPassword.Text);

            if (processRet == User.PaymentRet.SUCCES)
            {
                labelInfo.Text = "Ödeme başarılı.";
                textBoxPassword.Text = "";
            }
            else if (processRet == User.PaymentRet.WRONG_PASSWORD)
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

