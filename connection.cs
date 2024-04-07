using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace connector;

    public class connection : IDisposable
{
        private MySqlConnection con;
        private string host = "localhost";
        private Int16 Port = 3306;
        private string user = "root";
        private string pwd = "vssql";
        private string db = "checklistDoc";

        public string Host { get => host; set => host = value; }
        public short Port1 { get => Port; set => Port = value; }
        public string User { get => user; set => user = value; }
        public string Pwd { get => pwd; set => pwd = value; }
        public string Db { get => db; set => db = value; }
        public MySqlConnection Con { get => con; set => con = value; }

        public connection()
        {
            this.con = new MySqlConnection($"Server={host};Port={Port};User Id={user};Password={pwd};Database={db}");
            con.Open();
        }

        ~connection()
        {
            con.Close();
        }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this.con);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            if (this.con != null)
            {
                this.Dispose();
                this.con = null;
            }
        }
    }

}


