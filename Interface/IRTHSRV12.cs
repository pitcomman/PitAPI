using System;
using System.Data;
using Microsoft.AspNetCore.Mvc;



namespace PitAPI.Interface
{
    public interface IRTHSRV12
    {
        byte[] GetEmployeePictureByOPID(string strLotNo);
    }
}
