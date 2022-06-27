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


// using Newtonsoft.Json;
// using Newtonsoft.Json.Linq;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Mvc.Formatters.Json;

namespace PitAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RTHSRV12 : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly Interface.IHRMS_Employee_Management _HRMS_Employee_Manager;


        private readonly ILogger<RTHSRV12> _logger;


        private readonly string strConString;
        private readonly string strAppVersion;
        private readonly string strFactoryName;
        private Models.ConnectionString objConStr;
        private SqlConnection objConn;

        public RTHSRV12(Interface.IHRMS_Employee_Management HRMS_Employee_Manager)
        {
            _HRMS_Employee_Manager = HRMS_Employee_Manager;
        }

        [HttpGet]
        [Route("EmployeePicture")]
        public IActionResult GetEmployeePictureByOPID(String opid)
        {
            WebClient request = new WebClient();
            String ImageUrl = "ftp://rthsrv12/" + opid + ".jpg";

            try
            {
                byte [] newFileData = request.DownloadData(ImageUrl);
                // Byte[] b = System.IO.File.ReadAllBytes(ImageUrl);

                string fileString = System.Text.Encoding.UTF8.GetString(newFileData);
                
                return File(newFileData, "image/jpeg");
                //return Ok(JsonConvert.SerializeObject(ImageUrl));

            }
            catch (WebException e)
            {
                Console.WriteLine(e.ToString());

                return NotFound();
            }

        }
    }
}
