using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankSystem
{
    abstract class Log
    {
        public ulong user_id;
        public DateTime date;
        public String comment;
        public ulong cash;

        protected Log() { } // For json
        protected Log(User user)
        {
            this.user_id = user.id;
            this.date = DateTime.Now;
            this.cash = user.cash;
        }

        protected void SetComment(String comment)
        {
            this.comment = comment;
        }
    }
    
    class LogManager
    {
        protected class JsonLog : Log
        {
            public JsonLog() : base()
            {
            }
            public JsonLog(User user) : base(user)
            {
            }
        }

        protected class LoginLog : JsonLog
        {
            static readonly String STR = "Hesaba giriş yapıldı.";
            public LoginLog(User user) : base(user)
            {
                SetComment(String.Format(STR));
            }
        }
        
        protected class AdminChangeInformationLog : JsonLog
        {
            static readonly String STR = "Yönetici hesap bilgileri değişimi.";
            public AdminChangeInformationLog(User user) : base(user)
            {
                SetComment(String.Format(STR));
            }
        }
        protected class ResetUsersLog : JsonLog
        {
            static readonly String STR = "Kullanıcıları sıfırlama işlemi.";
            public ResetUsersLog(User user) : base(user)
            {
                SetComment(String.Format(STR));
            }
        }
        protected class ResetLogsLog : JsonLog
        {
            static readonly String STR = "Logları sıfırlama işlemi.";
            public ResetLogsLog(User user) : base(user)
            {
                SetComment(String.Format(STR));
            }
        }

        private List<JsonLog> LogData;

        private static LogManager instance = new LogManager();
        public static LogManager GetInstance() { return instance; }

        public enum LogType
        {
            LOGIN,
            ADMIN_CHANGE_INFORMATION,
            RESET_USERS,
            RESET_LOGS,
        }

        public void CreateLog(User user, LogType logType)
        {
            ReadSystem();

            switch (logType)
            {
                case LogType.LOGIN:
                    LogData.Add(new LoginLog(user));
                    break;
                case LogType.ADMIN_CHANGE_INFORMATION:
                    LogData.Add(new AdminChangeInformationLog(user));
                    break;
                case LogType.RESET_USERS:
                    LogData.Add(new ResetUsersLog(user));
                    break;
                case LogType.RESET_LOGS:
                    LogData.Add(new ResetLogsLog(user));
                    break;
            }

            SaveSystem();
        }

        public const string logJsonFileName = @"log.json";
        public void ReadSystem()
        {
            if (!File.Exists(logJsonFileName))
                File.Create(logJsonFileName).Close();

            try
            {
                LogData = Newtonsoft.Json.JsonConvert.DeserializeObject<List<JsonLog>>(File.ReadAllText(logJsonFileName));

                if (LogData == null)
                    LogData = new List<JsonLog>();
            }
            catch
            {
                string message = "json dosyalarında hata oluştu.";
                string caption = "Sistem kapatılıyor.";

                MessageBox.Show(message, caption);

                Application.ExitThread();
            }
        }
        public void SaveSystem()
        {
            try
            {
                File.WriteAllText(logJsonFileName, Newtonsoft.Json.JsonConvert.SerializeObject(LogData));
            }
            catch
            {
                string message = "json dosyalarında hata oluştu.";
                string caption = "Sistem kapatılıyor.";

                MessageBox.Show(message, caption);

                Application.ExitThread();
            }
        }
        public void GetAllLog(ulong pid, ref List<Log> output)
        {
            ReadSystem();

            foreach (Log log in LogData)
            {
                if (log.user_id == pid || pid == 0)
                    output.Add(log);
            }
        }

        public void Reset()
        {
            ReadSystem();

            // LogData.RemoveAll(log => !User.IsAdmin(log.user_id));

            LogData.Clear();

            SaveSystem();
        }

    }
}
