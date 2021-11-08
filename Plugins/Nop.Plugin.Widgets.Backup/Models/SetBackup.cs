using Microsoft.AspNetCore.Hosting;
using Nop.Data;
using Nop.Plugin.Widgets.Backup.Components;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Nop.Plugin.Widgets.Backup.Models
{
    public class SetBackup : ISetBackup
    {

        public SetBackup()
        {
            Cron._thread = new Thread(Cron.ProcessTask);
            Cron._thread.Name = "Backup Plugin";
            Cron._thread.Start();
        }


        public  string Set(IHostingEnvironment hostingEnvironment,bool local = false)
        {
            var dbName = DataSettingsManager.LoadSettings().ConnectionString.Split(";")[1].Split("=")[1];
            string connectionstr = "";
            if (local) connectionstr = "Data Source=MSI\\SQLEXPRESS;Initial Catalog=NopDB;Integrated Security=False;Persist Security Info=False;User ID=sa;Password=adm123";
            else connectionstr = DataSettingsManager.LoadSettings().ConnectionString;

            SqlConnection sqlconn = new SqlConnection(connectionstr);
            SqlCommand sqlcmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            string backupDestination = hostingEnvironment.WebRootPath.Replace("\\wwwroot", "") + "\\Plugins\\Widgets.Backup\\Backup\\";
            if (!System.IO.Directory.Exists(backupDestination)) System.IO.Directory.CreateDirectory(backupDestination);

            try
            {
                sqlconn.Open();
                backupDestination += DateTime.Now.ToString("yyyyMMddHHmmss") + ".bak";
                sqlcmd = new SqlCommand("backup database " + dbName + " to disk='" + backupDestination + "\'", sqlconn);
                sqlcmd.ExecuteNonQuery();
                sqlconn.Close();
                return "Basarili";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
