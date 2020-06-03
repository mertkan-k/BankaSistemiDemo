using System.Drawing;
using System.Windows.Forms;

namespace BankSystem
{
    public partial class UIChangePass : System.Windows.Forms.Form
    {
        private TextBox textBoxPrevPass;
        private TextBox textBoxNewPass1;
        private Label labelInf1;
        private Label label1;
        private Label label2;
        private TextBox textBoxNewPass2;
        private Button buttonAccept;
        private Label labelResult;
        private ulong UserID;

        public UIChangePass(ulong UserID)
        {
            this.UserID = UserID;
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            this.textBoxPrevPass = new System.Windows.Forms.TextBox();
            this.textBoxNewPass1 = new System.Windows.Forms.TextBox();
            this.labelInf1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxNewPass2 = new System.Windows.Forms.TextBox();
            this.buttonAccept = new System.Windows.Forms.Button();
            this.labelResult = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxPrevPass
            // 
            this.textBoxPrevPass.Location = new System.Drawing.Point(115, 13);
            this.textBoxPrevPass.MaxLength = 15;
            this.textBoxPrevPass.Name = "textBoxPrevPass";
            this.textBoxPrevPass.PasswordChar = '*';
            this.textBoxPrevPass.Size = new System.Drawing.Size(100, 20);
            this.textBoxPrevPass.TabIndex = 0;
            this.textBoxPrevPass.TextChanged += new System.EventHandler(this.textBoxPrevPass_TextChanged);
            // 
            // textBoxNewPass1
            // 
            this.textBoxNewPass1.Enabled = false;
            this.textBoxNewPass1.Location = new System.Drawing.Point(115, 52);
            this.textBoxNewPass1.MaxLength = 15;
            this.textBoxNewPass1.Name = "textBoxNewPass1";
            this.textBoxNewPass1.PasswordChar = '*';
            this.textBoxNewPass1.Size = new System.Drawing.Size(100, 20);
            this.textBoxNewPass1.TabIndex = 1;
            this.textBoxNewPass1.TextChanged += new System.EventHandler(this.textBoxNewPass1_TextChanged);
            // 
            // labelInf1
            // 
            this.labelInf1.AutoSize = true;
            this.labelInf1.Location = new System.Drawing.Point(13, 13);
            this.labelInf1.Name = "labelInf1";
            this.labelInf1.Size = new System.Drawing.Size(96, 13);
            this.labelInf1.TabIndex = 2;
            this.labelInf1.Text = "Eski şifrenizi giriniz:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Yeni şifrenizi giriniz:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tekrar giriniz:";
            // 
            // textBoxNewPass2
            // 
            this.textBoxNewPass2.Enabled = false;
            this.textBoxNewPass2.Location = new System.Drawing.Point(115, 78);
            this.textBoxNewPass2.MaxLength = 15;
            this.textBoxNewPass2.Name = "textBoxNewPass2";
            this.textBoxNewPass2.PasswordChar = '*';
            this.textBoxNewPass2.Size = new System.Drawing.Size(100, 20);
            this.textBoxNewPass2.TabIndex = 2;
            this.textBoxNewPass2.TextChanged += new System.EventHandler(this.textBoxNewPass2_TextChanged);
            // 
            // buttonAccept
            // 
            this.buttonAccept.Enabled = false;
            this.buttonAccept.Location = new System.Drawing.Point(115, 116);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(100, 23);
            this.buttonAccept.TabIndex = 3;
            this.buttonAccept.Text = "Onayla";
            this.buttonAccept.UseVisualStyleBackColor = true;
            this.buttonAccept.Click += new System.EventHandler(this.buttonAccept_Click);
            // 
            // labelResult
            // 
            this.labelResult.AutoSize = true;
            this.labelResult.Location = new System.Drawing.Point(13, 121);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(0, 13);
            this.labelResult.TabIndex = 6;
            // 
            // UIChangePass
            // 
            this.ClientSize = new System.Drawing.Size(231, 150);
            this.Controls.Add(this.labelResult);
            this.Controls.Add(this.buttonAccept);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxNewPass2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelInf1);
            this.Controls.Add(this.textBoxNewPass1);
            this.Controls.Add(this.textBoxPrevPass);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "UIChangePass";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Şifre Değişikliği";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void textBoxPrevPass_TextChanged(object sender, System.EventArgs e)
        {
            if (textBoxPrevPass.Text.Length > 0)
            {
                textBoxNewPass1.Enabled = true;
                textBoxNewPass2.Enabled = true;
            }
            else
            {
                textBoxNewPass1.Enabled = false;
                textBoxNewPass2.Enabled = false;
            }
        }

        private void textBoxNewPass1_TextChanged(object sender, System.EventArgs e)
        {
            if (textBoxNewPass1.Text.Length > 0)
            {
                textBoxNewPass2.Enabled = true;
            }
            else
            {
                textBoxNewPass2.Enabled = false;
            }

            if (textBoxNewPass1.Text == textBoxNewPass2.Text)
            {
                buttonAccept.Enabled = true;
                textBoxNewPass1.BackColor = Color.White;
                textBoxNewPass2.BackColor = Color.White;
            }
            else
            {
                buttonAccept.Enabled = false;
                textBoxNewPass1.BackColor = Color.Red;
                textBoxNewPass2.BackColor = Color.Red;
            }
        }

        private void textBoxNewPass2_TextChanged(object sender, System.EventArgs e)
        {
            if (textBoxNewPass1.Text == textBoxNewPass2.Text)
            {
                buttonAccept.Enabled = true;
                textBoxNewPass1.BackColor = Color.White;
                textBoxNewPass2.BackColor = Color.White;
            }
            else
            {
                buttonAccept.Enabled = false;
                textBoxNewPass1.BackColor = Color.Red;
                textBoxNewPass2.BackColor = Color.Red;
            }
        }

        private void buttonAccept_Click(object sender, System.EventArgs e)
        {
            User.ChangePasswordRet ret = User.ChangePassword(UserID, textBoxPrevPass.Text, textBoxNewPass1.Text);
            if (ret == User.ChangePasswordRet.INVALID_PASS)
                labelResult.Text = "Geçersiz şifre!";
            else if (ret == User.ChangePasswordRet.INVALID_USER)
                labelResult.Text = "Geçersiz kullanıcı!";
            else if (ret == User.ChangePasswordRet.SAME_PASS)
            {
                textBoxNewPass1.Focus();
                labelResult.Text = "Şifreler zaten aynı!";
            }
            else if (ret == User.ChangePasswordRet.WRONG_PASS)
            {
                textBoxPrevPass.Focus();
                labelResult.Text = "Eski şifre yanlış!";
            }
            else if (ret == User.ChangePasswordRet.SUCCES)
            {
                textBoxPrevPass.Text = "";
                textBoxNewPass1.Text = "";
                textBoxNewPass2.Text = "";
                buttonAccept.Enabled = false;
                labelResult.Text = "İşlem  başarılı.";
            }

        }
    }
}
