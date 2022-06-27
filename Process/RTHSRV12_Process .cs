using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using System.Net;



namespace PitAPI.Process
{
    public class RTHSRV12_Process  : MarshalByRefObject
    {

        // Constructor & Initial Value OGI Mixing Checked System
        public RTHSRV12_Process()
        {
            // nothing
        }

        public byte[] GetEmployeePictureByOPID(string opid)
        {
            WebClient request = new WebClient();
            String ImageUrl = "ftp://rthsrv12/" + opid + ".jpg";

            try
            {
                byte [] newFileData = request.DownloadData(ImageUrl);
                // Byte[] b = System.IO.File.ReadAllBytes(ImageUrl);

                string fileString = System.Text.Encoding.UTF8.GetString(newFileData);
                
                return newFileData;
                //return Ok(JsonConvert.SerializeObject(ImageUrl));

            }
            catch (WebException e)
            {
                Console.WriteLine(e.ToString());

                return null;
            }
        }
    }
}
