using System;
using System.Windows.Forms;

namespace BankSystem
{
    public partial class MainForm : Form
    {
        public Form userForm;

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            User.ReadSystem();
        }

        private void textBoxUserName_KeyDown(object sender, KeyEventArgs e)
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
                buttonLogin_Click(sender, null);
            }
        }


        private void buttonLogin_Click(object sender, EventArgs e)
        {
            String userName = textBoxUserName.Text;
            String password = textBoxPassword.Text;

            if (userName.Length != 0 && password.Length != 0)
            {
                User lgnUser = User.FindUser(userName, password);

                if (lgnUser == null)
                {
                    labelInfo.Text = "Kullanıcı adı ve ya şifre yanlış!.";
                    return;
                }

                labelInfo.Text = "Giriş başarılı, lütfen bekleyiniz.";

                Form UIform = new UIForm(lgnUser.id);
                userForm = UIform;
                UIform.Show();

                labelInfo.Text = "";

            }
            else
            {
                labelInfo.Text = "Kullanıcı adı ve ya şifre girilmedi!.";
                return;
            }

        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            String userName = textBoxUserName.Text;
            String password = textBoxPassword.Text;

            if (userName.Length == 0 || password.Length == 0)
            {
                labelInfo.Text = "Kullanıcı adı ve ya şifre girilmedi!.";
                return;
            }

            if (User.RegisterUser(new User(userName, password)))
            {
                labelInfo.Text = "Başarıyla kayıt olundu, giriş yapabilirsiniz.";
            }
            else
            {
                labelInfo.Text = "Kayıt işlemi sırasında bir hata oluştu.";
            }
        }
    }
}
