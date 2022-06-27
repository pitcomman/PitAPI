using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Data;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Newtonsoft.Json;
using System.Net;


namespace PitAPI.Services
{
    public class HRMS_Employee_Management : Interface.IHRMS_Employee_Management
    {

        private const string strSystem = "DB_HRMSLocal";

        private readonly string strConString;
        private readonly string strAppVersion;
        private readonly string strFactoryName;
        private Models.ConnectionString objConStr;
        private SqlConnection objConn;

        readonly Process.HRMS_Employee_Management_process ObjST;
        private readonly IConfiguration _configuration;
        public HRMS_Employee_Management(IConfiguration configuration)
        {
            _configuration = configuration;
            strConString = _configuration.GetConnectionString(strSystem);
            objConn = new SqlConnection(strConString);
            objConn.Open();
            ObjST = new Process.HRMS_Employee_Management_process();        
        }

        public DataSet GetEmployeeDetailByOPID(string opid)
        {
            if (objConn == null | objConn.State == ConnectionState.Closed)
            {
                objConn = new SqlConnection(strConString);
                objConn.Open();
            }

            return ObjST.GetEmployeeDetailByOPID(opid, objConn);
        }

        // public Lot GetDetailEmployeeByOPID(string opid, SqlConnection objConn)
        // {

        // }
    }
}
