using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace PitAPI.Process
{
    public class HRMS_Employee_Management_process : MarshalByRefObject
    {

        private Models.EmployeeDetail objEmployee;

        // Constructor & Initial Value OGI Mixing Checked System
        public HRMS_Employee_Management_process()
        {
            // nothing
        }

        public DataSet GetEmployeeDetailByOPID(string opid, SqlConnection objConn)
        {
            try
            {
                string strSql;
                strSql = ("Select * From HRMS_Employee Where CODEMPID = \'"
                            + (opid.Trim() + "\'"));
                
                SqlDataAdapter mySqlAdapter = new SqlDataAdapter(strSql, objConn);
                DataSet myDataset = new DataSet();
                DataTable myDataTable;
                mySqlAdapter.Fill(myDataset, "EmployeeDetail");
                if ((myDataset.Tables["EmployeeDetail"].Rows.Count == 0))
                {
                    return null;
                }
                else
                {
                    return myDataset;
                } 
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                objConn.Close();
                objConn = null;
            }
        }

        
    }
}
