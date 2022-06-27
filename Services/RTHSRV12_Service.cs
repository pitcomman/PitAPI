using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;


namespace PitAPI.Services
{
    public class RTHSRV12 : Interface.IRTHSRV12
    {

        readonly Process.RTHSRV12_Process ObjST;
        private readonly IConfiguration _configuration;
        public RTHSRV12(IConfiguration configuration)
        {
            //Nothing
        }

        public byte[] GetEmployeePictureByOPID(string opid)
        {
            return ObjST.GetEmployeePictureByOPID(opid);
        }

        // public Lot GetDetailEmployeeByOPID(string opid, SqlConnection objConn)
        // {

        // }
    }
}
