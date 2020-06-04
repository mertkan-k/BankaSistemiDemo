using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BankSystem.BusinessManager;

namespace BankSystem
{
    public class User
    {
        public const string accountJsonFileName = @"account.json";

        public const ulong defaultCash = 1000;

        private static List<User> UserData;

        User() { } // For json
        public User(String username, String password)
        {
            this.id = GenID();
            this.username = username;
            this.password = password;
            this.cash = defaultCash;

            new Log(id, "Yeni müşteri varsayılan(default) bakiye yüklemesi.", this.cash);

            this.createTime = DateTime.Now;
        }
        public User(ulong id, String username, String password)
        {
            this.id = id;
            this.username = username;
            this.password = password;
            this.cash = defaultCash;

            this.createTime = DateTime.Now;
        }
        private User(ulong id, String username, String password, ulong cash)
        {
            this.id = id;
            this.username = username;
            this.password = password;
            this.cash = cash;

            this.createTime = DateTime.Now;
        }

        //public Guid id { get; set; }
        public String username { get; set; }
        public String password { get; set; }
        public ulong cash { get; set; }
        public DateTime createTime { get; set; }
        public ulong id { get; set; }

        private static ulong LastID;
        private ulong GenID()
        {
            return LastID++;
        }

        public static void ReadLastID()
        {
            foreach (var user in UserData)
            {
                if (LastID <= user.id)
                    LastID = user.id + 1;
            }
        }
        public static void ReadSystem()
        {
            if (!File.Exists(accountJsonFileName))
                File.Create(accountJsonFileName).Close();

            try
            {
                UserData = Newtonsoft.Json.JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(accountJsonFileName));

                if (UserData == null)
                    UserData = new List<User>();

                if (User.FindUser("root") == null)
                {
                    UserData.Add(new User(1, "root", "12345", 100000));
                    SaveSystem();
                }

                ReadLastID();
            }
            catch
            {
                string message = "json dosyalarında hata oluştu.";
                string caption = "Sistem kapatılıyor.";

                MessageBox.Show(message, caption);

                Application.ExitThread();
            }
        }
        public static void SaveSystem()
        {
            try
            {
                File.WriteAllText(accountJsonFileName, Newtonsoft.Json.JsonConvert.SerializeObject(UserData));
            }
            catch
            {
                string message = "json dosyalarında hata oluştu.";
                string caption = "Sistem kapatılıyor.";

                MessageBox.Show(message, caption);

                Application.ExitThread();
            }
        }

        static public bool IsAdmin(ulong id)
        {
            return id == 1;
        }
        static public bool IsAdmin(User user)
        {
            return IsAdmin(user.id);
        }

        static public User FindUser(ulong id)
        {
            foreach (var user in UserData)
                if (id == user.id)
                    return user;

            return null;
        }
        static public User FindUser(String username)
        {
            foreach (var user in UserData)
                if (username == user.username)
                    return user;

            return null;
        }
        static public User FindUser(String username, String password)
        {
            foreach (var user in UserData)
            {
                if (username == user.username && password == user.password)
                {
                    return user;
                }
            }

            return null;
        }

        static public bool RegisterUser(User newUser)
        {
            /**
             * Check for if username already exists
             */
            if (FindUser(newUser.username) != null)
            {
                return false;
            }

            UserData.Add(newUser);
            SaveSystem();

            return true;
        }

        public enum SendMoneyRet
        {
            SUCCES,
            INVALID_USER,
            INVALID_CASH,
            SAME_USER,
            WRONG_PASSWORD,
            NOT_ENOUGH_CASH,
            TOO_MUCH_CASH,
        }
        static public SendMoneyRet SendMoney(ulong srcID, ulong targetID, ulong cash, String pass)
        {
            ReadSystem();

            User src = FindUser(srcID);
            User target = FindUser(targetID);

            if (src == null || target == null)
                return SendMoneyRet.INVALID_USER;

            if (cash <= 0)
                return SendMoneyRet.INVALID_CASH;

            if (src.id == target.id)
                return SendMoneyRet.SAME_USER;

            if (src.password != pass)
                return SendMoneyRet.WRONG_PASSWORD;

            if (src.cash < cash)
                return SendMoneyRet.NOT_ENOUGH_CASH;

            if (target.cash > UInt64.MaxValue - cash)
                return SendMoneyRet.TOO_MUCH_CASH;

            src.cash -= cash;
            target.cash += cash;

            SaveSystem();

            new Log(src, String.Format(@"{0} numaralı hesaba {1} havale gönderme işlemi.", target.id, cash.ToString("C", CultureInfo.CurrentCulture)));
            new Log(target, String.Format(@"{0} numaralı hesapdan {1} havale alma işlemi.", src.id, cash.ToString("C", CultureInfo.CurrentCulture)));

            return SendMoneyRet.SUCCES;
        }

        public enum ChangePasswordRet
        {
            SUCCES,
            INVALID_USER,
            INVALID_PASS,
            SAME_PASS,
            WRONG_PASS,
        }
        static public ChangePasswordRet ChangePassword(ulong userID, String prevPass, String newPass)
        {
            ReadSystem();

            User user = FindUser(userID);

            if (user == null)
                return ChangePasswordRet.INVALID_USER;

            if (newPass.Length == 0)
                return ChangePasswordRet.INVALID_PASS;

            if (newPass == prevPass)
                return ChangePasswordRet.SAME_PASS;

            if (user.password != prevPass)
                return ChangePasswordRet.WRONG_PASS;

            user.password = newPass;

            SaveSystem();

            new Log(user, String.Format(@"Şifre değişikliği işlemi."));

            return ChangePasswordRet.SUCCES;
        }
        public enum PaymentRet
        {
            SUCCES,
            INVALID_USER,
            INVALID_BUSINESS,
            WRONG_PASSWORD,
            NOT_ENOUGH_CASH,
        }
        static public PaymentRet Payment(ulong userID, ulong businesID, ulong cash, String pass)
        {
            ReadSystem();

            User user = FindUser(userID);
            Business business = default;

            if (user == null)
                return PaymentRet.INVALID_USER;

            if (!BusinessManager.Instance.Find(businesID, out business))
                return PaymentRet.INVALID_USER;

            if (user.password != pass)
                return PaymentRet.WRONG_PASSWORD;

            if (user.cash < cash)
                return PaymentRet.NOT_ENOUGH_CASH;

            user.cash -= cash;

            SaveSystem();

            new Log(user, String.Format(@"'{0}' işmerkezine {1} tutarında fatura ödemesi.", business.name, cash.ToString("C", CultureInfo.CurrentCulture)));

            return PaymentRet.SUCCES;
        }

        static public void GetUserData(out List<User> list)
        {
            list = UserData;
        }

        static public void Reset()
        {
            ReadSystem();

            UserData.RemoveAll(user => !IsAdmin(user.id));

            SaveSystem();
        }
    }
}
