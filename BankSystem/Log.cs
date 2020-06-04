using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankSystem
{
    class Log
    {
        public ulong user_id;
        public DateTime date;
        public String comment;
        public ulong cash;

        private static List<Log> LogData;

        Log() { } // For json
        public Log(User user, String comment)
        {
            ReadSystem();

            this.user_id = user.id;
            this.date = DateTime.Now;
            this.comment= comment;
            this.cash = user.cash;

            LogData.Add(this);

            SaveSystem();
        }
        public Log(ulong user_id, String comment, ulong cash)
        {
            ReadSystem();

            this.user_id = user_id;
            this.date = DateTime.Now;
            this.comment= comment;
            this.cash = cash;

            LogData.Add(this);

            SaveSystem();
        }

        public const string logJsonFileName = @"log.json";
        public static void ReadSystem()
        {
            if (!File.Exists(logJsonFileName))
                File.Create(logJsonFileName).Close();

            try
            {
                LogData = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Log>>(File.ReadAllText(logJsonFileName));

                if (LogData == null)
                    LogData = new List<Log>();
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
        public static void GetAllLog(ulong pid, ref List<Log> output)
        {
            ReadSystem();

            foreach (Log log in LogData)
            {
                if (log.user_id == pid)
                    output.Add(log);
            }
        }

    }
}
