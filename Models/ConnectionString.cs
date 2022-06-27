using System;

namespace PitAPI.Models
{
    using System.Data;
    using System.Data.SqlClient;
    public class ConnectionString
    {
        private readonly string FilenameValue;
        private readonly string SectionValue;
        private string ServernameValue;
        private string DBNameValue;
        private string UserValue;
        private string PasswordValue;
        private string VersionValue;
        private string CompanyValue;
        private string ConnectionStrvalue;
        private string ConnectionStrvalueW;

        private string DefaultPathValue;

        // Private CompanyValue As String
        public ConnectionString(string Section="")
        {
          
                FilenameValue = "C:\\Class\\ConfigWeb.xml";
                // Warning!!! Optional parameters not supported
                SectionValue = Section;
                this.GetConnString();
          

        }

        public object StrConnect { get; set; }
        public object Connection { get; set; }
        public string ConnectionStr { get; set; }
        public string ConnectionStrW { get; set; }
        public string FactoryName { get; set; }
        public string AppVersion { get; set; }

        private void GetConnString()
        {
            DataSet ds = new DataSet();
            ds.ReadXml(FilenameValue);
            //DataRow dr;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (dr["AppSystem"].ToString() == SectionValue)
                {
                    ServernameValue = dr["SRVName"].ToString();
                    DBNameValue = dr["DBName"].ToString();
                    UserValue = dr["user"].ToString();
                    PasswordValue = dr["password"].ToString();
                    VersionValue = dr["version"].ToString();
                    CompanyValue = dr["Company"].ToString();
                    DefaultPathValue = dr["DefaultPath"].ToString();

                    // ===>> Set Connection String For SQL Mode <<===
                    if (UserValue.Trim() != "" & PasswordValue.Trim() != "")
                        ConnectionStrvalue = "Persist Security Info=False;" + "User ID=" + UserValue.Trim() + ";" + "Password=" + PasswordValue.Trim() + ";" + "Initial Catalog=" + DBNameValue.Trim() + ";" + "Data Source=" + ServernameValue.Trim();
                        ConnectionStr = ConnectionStrvalue;
                    // ===>> Set Connection String For Windows Mode <<===
                    if (PasswordValue.Trim() == "" & PasswordValue.Trim() == "")
                        ConnectionStrvalueW = "Persist Security Info=False;" + "Integrated Security=SSPI;" + "Initial Catalog=" + DBNameValue.Trim() + ";" + "Data Source=" + ServernameValue.Trim();
                    ConnectionStrW = ConnectionStrvalueW;
                    break;
                }
            }
        }

    }
}
