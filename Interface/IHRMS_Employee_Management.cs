using System;
using System.Data;


namespace PitAPI.Interface
{
    public interface IHRMS_Employee_Management
    {
        DataSet GetEmployeeDetailByOPID(string strLotNo);
    }
}
