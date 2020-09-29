using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RK.Connections;
using System.Data;
using RK.HCConnections;
namespace NIRDPR.RK.PRReferences
{
    public class PRIBC
    {
        PRResp objPRResp = new PRResp();
        public PRResp CreateSQLBackup_ERP(PRReq objPRReq)
        {
            string insert = "backup database NIRDPR_PAYROLLS to disk='" + objPRReq.SqlBackupPath + "' ";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp CreateSQLBackup_HC(PRReq objPRReq)
        {
            string insert = "backup database NIRDPR_IIS to disk='" + objPRReq.SqlBackupPath + "' ";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp CreateSQLBackup_PSCareers(PRReq objPRReq)
        {
            string insert = "backup database RK_Careers to disk='" + objPRReq.SqlBackupPath + "' ";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp CreateSQLBackup_SRMS(PRReq objPRReq)
        {
            string insert = "backup database NIRD_Research to disk='" + objPRReq.SqlBackupPath + "' ";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp CreateSQLBackup_DDUGKYTicketing(PRReq objPRReq)
        {
            string insert = "backup database eTicket to disk='" + objPRReq.SqlBackupPath + "' ";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp AdminLogin(PRReq objPRReq)
        {
            string s = "select * from tbl_Admin where UserID='" + objPRReq.UserID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp Admin_EmpID(PRReq objPRReq)
        {
            string s = "select * from tbl_Admin where EmpID='" + objPRReq.EmpID + "' and OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAdmin_Roles_EmpID(PRReq objPRReq)
        {
            string s = "select * from tbl_Admin where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAdminUserInfo(PRReq objPRReq)
        {
            string s = "select * from tbl_Admin where UserID='" + objPRReq.UserID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAdminData(PRReq objPRReq)
        {
            string s = "select * from tbl_Admin where UID='" + objPRReq.UID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAdminsPassword(PRReq objPRReq)
        {
            string s = "select * from tbl_Admin where Status='" + objPRReq.Status + "' and UID='" + objPRReq.UID + "' and Password='" + objPRReq.Password + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getSGsPassword(PRReq objPRReq)
        {
            string s = "select * from Security_tbl_SecurityGuard where Status='" + objPRReq.Status + "' and SGID='" + objPRReq.SGID + "' and Password='" + objPRReq.Password + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmployee_EmpID(PRReq objPRReq)
        {
            string s = "(select EmpID,Name,DeptID,Design,Photo,Email,Mobile,OTP from PR_tbl_Employee  where Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' and OID='" + objPRReq.OID + "')union(select EmpID,Name,DeptID,Design,Photo,Email,Mobile,OTP from PR_tbl_ProjectStaff  where Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' and OID='" + objPRReq.OID + "') ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp getEmployee_EmpID_DID(PRReq objPRReq)
        {
            string s = "(select EmpID,Name,DID,DeptID,Design,Photo,Email,Mobile from PR_tbl_Employee  where Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' and OID='" + objPRReq.OID + "')union(select EmpID,Name,DID,DeptID,Design,Photo,Email,Mobile from PR_tbl_ProjectStaff  where Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' and OID='" + objPRReq.OID + "') ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmployeeDetails_EmpID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Employee where Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' and OID='" + objPRReq.OID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getRegEmployee_Gender(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Employee  where Status='" + objPRReq.Status + "' and Gender='" + objPRReq.Gender + "' and OID='" + objPRReq.OID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getProjEmployee_Gender(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_ProjectStaff  where Status='" + objPRReq.Status + "' and Gender='" + objPRReq.Gender + "' and OID='" + objPRReq.OID + "' and DSID is not null";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmployeeDetails_ECID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Employee  where Status='" + objPRReq.Status + "' and ECID='" + objPRReq.ECID + "' and OID='" + objPRReq.OID + "' order by EmpID Asc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmployeeDetails_EGID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Employee  where Status='" + objPRReq.Status + "' and EGID='" + objPRReq.EGID + "' and OID='" + objPRReq.OID + "' order by EmpID Asc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmployeeDetails_DID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Employee  where Status='" + objPRReq.Status + "' and DID='" + objPRReq.DID + "' and OID='" + objPRReq.OID + "' order by EmpID Asc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmployeeDetails_DID_EmpID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Employee  where Status='" + objPRReq.Status + "' and DID='" + objPRReq.DID + "' and OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getResetEmpPassword(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Employee where Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' and Mobile='" + objPRReq.Mobile + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getResetProjEmpPassword(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_ProjectStaff  where Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' and Mobile='" + objPRReq.Mobile + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllRegularStaffContacts_SMS(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Employee  where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' order by DeptID Asc ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllProjectStaff_Active(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_ProjectStaff  where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' order by DID Asc ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllProjectStaff_Active_DDUGKY(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_ProjectStaff  where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and DID='26'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllProjectStaff_Active_NonDDUGKY(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_ProjectStaff  where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and Flag1='1' and DID!='26'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp updatePSEmpLeaves_YearlyOnce(PRReq objPRReq)
        {
            string update = "update PR_tbl_ProjectStaff_CLs set " + objPRReq.ColumnName + "='" + objPRReq.NoofLeaves + "', Year='" + objPRReq.Year + "' where OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp getAllProjectStaff_Active_NotDDUGKY(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_ProjectStaff  where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and DID!='26'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllHOCContacts_SMS(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Employee  where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ISHOC='Yes' order by DeptID Asc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllFacultyContacts_SMS(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Employee  where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and EmpGroup='Academic' order by DeptID Asc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllNonFacultyContacts_SMS(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Employee  where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and EmpGroup='Non-Academic' order by DeptID Asc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp ResetEmpPassword(PRReq objPRReq)
        {
            string update = "update PR_tbl_Employee set Password='" + objPRReq.NewPassword + "' where EmpID='" + objPRReq.EmpID + "' and Status='" + objPRReq.Status + "' and Mobile='" + objPRReq.Mobile + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp ResetProjEmpPassword(PRReq objPRReq)
        {
            string update = "update PR_tbl_ProjectStaff set Password='" + objPRReq.NewPassword + "' where EmpID='" + objPRReq.EmpID + "' and Status='" + objPRReq.Status + "' and Mobile='" + objPRReq.Mobile + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp ChangePS_CentreHead(PRReq objPRReq)
        {
            string update = "update PR_tbl_ProjectStaff set HEmpID='" + objPRReq.HEmpID + "',CentreHead='" + objPRReq.HName + "' where EmpID='" + objPRReq.EmpID + "' and Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp ChangePS_CentreHead_CLs(PRReq objPRReq)
        {
            string update = "update PR_tbl_ProjectStaff_CLs set HEmpID='" + objPRReq.HEmpID + "',HName='" + objPRReq.HName + "' where EmpID='" + objPRReq.EmpID + "' and Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp ChangePS_Department(PRReq objPRReq)
        {
            string update = "update PR_tbl_ProjectStaff set DID='" + objPRReq.DID + "',DeptID='" + objPRReq.DeptID + "' where EmpID='" + objPRReq.EmpID + "' and Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp RegisterUserLogs(PRReq objPRReq)
        {
            string insert = "insert into erp_tbl_UserLogs (OID,EmpID,Name,InTime,Status) values('" + objPRReq.OID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.InTime + "','" + objPRReq.Status + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp CloseUserLogs(PRReq objPRReq)
        {
            string update = "update erp_tbl_UserLogs set OutTime='" + objPRReq.OutTime + "', Status='Closed' where EmpID='" + objPRReq.EmpID + "' and Status='" + objPRReq.Status + "' and OutTime is NULL ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp getOpenUserLogs(PRReq objPRReq)
        {
            string s = "select * from erp_tbl_UserLogs  where Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' and OutTime is NULL ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp AddIntercomNumber(PRReq objPRReq)
        {
            string update = "update PR_tbl_Employee set Mobile='" + objPRReq.Mobile + "', Block='" + objPRReq.BlockName + "', Floor='" + objPRReq.Floor + "',Intercom='" + objPRReq.Intercom + "',RoomNo='" + objPRReq.RoomNo + "' where EmpID='" + objPRReq.EmpID + "' and Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp AddPSIntercomNumber(PRReq objPRReq)
        {
            string update = "update PR_tbl_ProjectStaff set Mobile='" + objPRReq.Mobile + "', Block='" + objPRReq.BlockName + "', Floor='" + objPRReq.Floor + "',Intercom='" + objPRReq.Intercom + "',RoomNo='" + objPRReq.RoomNo + "' where EmpID='" + objPRReq.EmpID + "' and Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp getEmpPassword(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Employee  where Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.UID + "' and Password='" + objPRReq.Password + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getActivePSEmployeeByEmpID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_ProjectStaff where OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllPSbyREportingOfficer_HEMPID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_ProjectStaff  where Status='" + objPRReq.Status + "' and HEmpID='" + objPRReq.HEmpID + "' and OID='" + objPRReq.OID + "' and Flag1='" + objPRReq.Flag1 + "' and (Flag2 is NULL or Flag2!='1') ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllPSbyREportingOfficer_HEMPID_DelegationUser(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_ProjectStaff  where Status='" + objPRReq.Status + "' and DID='" + objPRReq.DID + "' and OID='" + objPRReq.OID + "' and Flag1='" + objPRReq.Flag1 + "' and (Flag2 is NULL or Flag2!='1') ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllValidPSbyREportingOfficer_HEMPID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_ProjectStaff  where Status='" + objPRReq.Status + "' and HEmpID='" + objPRReq.HEmpID + "' and OID='" + objPRReq.OID + "' and Flag1='" + objPRReq.Flag1 + "' and Flag2 ='" + objPRReq.Flag2 + "' order by EmpID Asc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllValidPSbyREportingOfficer_HEMPID_EmpIDDetails(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_ProjectStaff  where Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' and HEmpID='" + objPRReq.HEmpID + "' and OID='" + objPRReq.OID + "' and Flag1='" + objPRReq.Flag1 + "' and Flag2 ='" + objPRReq.Flag2 + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllPSbyValidated_HEMPID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_ProjectStaff  where Status='" + objPRReq.Status + "' and HEmpID='" + objPRReq.HEmpID + "' and OID='" + objPRReq.OID + "' and Flag1='" + objPRReq.Flag1 + "' and Flag2='" + objPRReq.Flag2 + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllPSbyValidated_HEMPID_DelegatedUser(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_ProjectStaff  where Status='" + objPRReq.Status + "' and DID='" + objPRReq.DID + "' and OID='" + objPRReq.OID + "' and Flag1='" + objPRReq.Flag1 + "' and Flag2='" + objPRReq.Flag2 + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp ValidPSbyHEmpID(PRReq objPRReq)
        {
            string update = "update PR_tbl_ProjectStaff set Flag2='" + objPRReq.Flag2 + "' where HEmpID='" + objPRReq.HEmpID + "' and EmpID='" + objPRReq.EmpID + "' and Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and Flag1=1";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp ValidPSbyHEmpID_DelegateUser(PRReq objPRReq)
        {
            string update = "update PR_tbl_ProjectStaff set Flag2='" + objPRReq.Flag2 + "',HEmpID='" + objPRReq.HEmpID + "' where DID='" + objPRReq.DID + "' and EmpID='" + objPRReq.EmpID + "' and Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and Flag1=1";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp getAllREmpBDays(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Employee  where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllREmp_DID_DSID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Employee  where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' order by DID, Name, DSID Asc ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllTodaysREmpBDays(PRReq objPRReq)
        {
            string s = "(select distinct Name,Design,DeptID,Email,Mobile,DOB,Photo from PR_tbl_Employee  where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and month(DOB)= month(getDate()) and day(DOB)= day(getDate()))union(select distinct Name,Design,DeptID,Email,Mobile,DOB,Photo from PR_tbl_ProjectStaff where Status='" + objPRReq.Status + "' and Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and month(DOB)= month(getDate()) and day(DOB)= day(getDate())) ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllMonthlyREmpBDays(PRReq objPRReq)
        {
            string s = "(select Name,Design,DeptID,Email,Mobile,DOB,Photo from PR_tbl_Employee  where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and month(DOB)= month(getDate()))union(select Name,Design,DeptID,Email,Mobile,DOB,Photo from PR_tbl_ProjectStaff  where Status='" + objPRReq.Status + "' and Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and month(DOB)= month(getDate())) ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        // Update Employee Department
        public PRResp ChangeEmpDept_tbl_ProjEmployee(PRReq objPRReq)
        {
            string update = "update PR_tbl_ProjectStaff set DID='" + objPRReq.DID + "',DeptID='" + objPRReq.DeptID + "' where EmpID='" + objPRReq.EmpID + "' and Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp ChangeEmpDept_tbl_ProjEmployeeCls(PRReq objPRReq)
        {
            string update = "update PR_tbl_ProjectStaff_CLs set DID='" + objPRReq.DID + "',DeptID='" + objPRReq.DeptID + "' where EmpID='" + objPRReq.EmpID + "' and Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp ChangeEmpDept_tbl_Employee(PRReq objPRReq)
        {
            string update = "update PR_tbl_Employee set DID='" + objPRReq.DID + "',DeptID='" + objPRReq.DeptID + "' where EmpID='" + objPRReq.EmpID + "' and Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp ChangeEmpDept_tbl_EmpLeaves(PRReq objPRReq)
        {
            string update = "update eL_tbl_EmpLeaves set DID='" + objPRReq.DID + "',DeptID='" + objPRReq.DeptID + "' where EmpID='" + objPRReq.EmpID + "' and Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp ChangeEmpEssentialStatus(PRReq objPRReq)
        {
            string update = "update eL_tbl_EmpLeaves set Essential='" + objPRReq.EssentialStatus + "' where EmpID='" + objPRReq.EmpID + "' and Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp ChangeEmpCL_tbl_EmpLeaves(PRReq objPRReq)
        {
            string update = "update eL_tbl_EmpLeaves set CL='" + objPRReq.NoofLeaves + "' where EmpID='" + objPRReq.EmpID + "' and Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp ChangePSEmpCL_tbl_EmpLeaves(PRReq objPRReq)
        {
            string update = "update PR_tbl_ProjectStaff_CLs set CL='" + objPRReq.NoofLeaves + "' where EmpID='" + objPRReq.EmpID + "' and Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp ChangePSEmpSL_tbl_EmpLeaves(PRReq objPRReq)
        {
            string update = "update PR_tbl_ProjectStaff_CLs set SL='" + objPRReq.NoofLeaves + "' where EmpID='" + objPRReq.EmpID + "' and Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp ChangeEmpRH_tbl_EmpLeaves(PRReq objPRReq)
        {
            string update = "update eL_tbl_EmpLeaves set RH='" + objPRReq.NoofLeaves + "' where EmpID='" + objPRReq.EmpID + "' and Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp ChangeEmpDept_tbl_Employee_Master_Salary(PRReq objPRReq)
        {
            string update = "update PR_tbl_Employee_Master_Salary set DID='" + objPRReq.DID + "',DeptID='" + objPRReq.DeptID + "' where EmpID='" + objPRReq.EmpID + "' and Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp ChangeEmpDept_tbl_EmpLeaveFlow(PRReq objPRReq)
        {
            string update = "update eL_tbl_EmpLeaveFlow set DID='" + objPRReq.DID + "',DeptID='" + objPRReq.DeptID + "' where EmpID='" + objPRReq.EmpID + "' and Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }

        public PRResp ChangeEmpDept_tbl_InventoryMapping(PRReq objPRReq)
        {
            string update = "update CIT_tbl_InventoryMapping set DID='" + objPRReq.DID + "',DeptID='" + objPRReq.DeptID + "' where EmpID='" + objPRReq.EmpID + "' and Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }

        public PRResp ChangeEmpDesign_tbl_Employee(PRReq objPRReq)
        {
            string update = "update PR_tbl_Employee set DSID='" + objPRReq.DSID + "',Design='" + objPRReq.Design + "' where EmpID='" + objPRReq.EmpID + "' and Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp ChangeEmpDesign_tbl_ProjEmployee(PRReq objPRReq)
        {
            string update = "update PR_tbl_ProjectStaff set DSID='" + objPRReq.DSID + "',Design='" + objPRReq.Design + "' where EmpID='" + objPRReq.EmpID + "' and Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp ChangeEmpDesign_tbl_ProjEmployeeCls(PRReq objPRReq)
        {
            string update = "update PR_tbl_ProjectStaff_CLs set DSID='" + objPRReq.DSID + "',Design='" + objPRReq.Design + "' where EmpID='" + objPRReq.EmpID + "' and Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp ChangeEmpDesign_tbl_EmpLeaves(PRReq objPRReq)
        {
            string update = "update eL_tbl_EmpLeaves set DSID='" + objPRReq.DSID + "',Design='" + objPRReq.Design + "' where EmpID='" + objPRReq.EmpID + "' and Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp ChangeEmpDesign_tbl_Employee_Master_Salary(PRReq objPRReq)
        {
            string update = "update PR_tbl_Employee_Master_Salary set DSID='" + objPRReq.DSID + "',Design='" + objPRReq.Design + "' where EmpID='" + objPRReq.EmpID + "' and Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp ChangeEmpDesign_tbl_EmpLeaveFlow(PRReq objPRReq)
        {
            string update = "update eL_tbl_EmpLeaveFlow set DSID='" + objPRReq.DSID + "',Design='" + objPRReq.Design + "' where EmpID='" + objPRReq.EmpID + "' and Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp ChangeEmpDesign_tbl_InventoryMapping(PRReq objPRReq)
        {
            string update = "update CIT_tbl_InventoryMapping set Design='" + objPRReq.Design + "' where EmpID='" + objPRReq.EmpID + "' and Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }

        public PRResp ChangeEmpDOB_tbl_Employee(PRReq objPRReq)
        {
            string update = "update PR_tbl_Employee set DOB='" + objPRReq.DOB + "' where EmpID='" + objPRReq.EmpID + "' and Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp ChangeEmpDOB_tbl_EmpLeaves(PRReq objPRReq)
        {
            string update = "update eL_tbl_EmpLeaves set DOB='" + objPRReq.DOB + "', DOR='" + objPRReq.DOR + "' where EmpID='" + objPRReq.EmpID + "' and Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp ChangeEmpDOB_tbl_Employee_Master_Salary(PRReq objPRReq)
        {
            string update = "update PR_tbl_Employee_Master_Salary set DOB='" + objPRReq.DOB + "', DOR='" + objPRReq.DOR + "' where EmpID='" + objPRReq.EmpID + "' and Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }

        public PRResp ChangeEmpDOJ_tbl_Employee(PRReq objPRReq)
        {
            string update = "update PR_tbl_Employee set DOJ='" + objPRReq.DOJ + "' where EmpID='" + objPRReq.EmpID + "' and Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp ChangeRegStaff_Password(PRReq objPRReq)
        {
            string update = "update PR_tbl_Employee set Password='" + objPRReq.Password + "' where EmpID='" + objPRReq.EmpID + "' and Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp ChangeRegStaff_HeadStatus(PRReq objPRReq)
        {
            string update = "update PR_tbl_Employee set ISHOC='" + objPRReq.CentreHead + "' where EmpID='" + objPRReq.EmpID + "' and Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp ChangeProjStaff_Password(PRReq objPRReq)
        {
            string update = "update PR_tbl_ProjectStaff set Password='" + objPRReq.Password + "' where EmpID='" + objPRReq.EmpID + "' and Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp ChangeProjStaff_HeadStatus(PRReq objPRReq)
        {
            string update = "update PR_tbl_ProjectStaff set ISHOC='" + objPRReq.CentreHead + "' where EmpID='" + objPRReq.EmpID + "' and Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp ChangeEmpDOJ_tbl_EmpLeaves(PRReq objPRReq)
        {
            string update = "update eL_tbl_EmpLeaves set DOJ='" + objPRReq.DOJ + "' where EmpID='" + objPRReq.EmpID + "' and Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp ChangeEmpDOJ_tbl_Employee_Master_Salary(PRReq objPRReq)
        {
            string update = "update PR_tbl_Employee_Master_Salary set DOJ='" + objPRReq.DOJ + "' where EmpID='" + objPRReq.EmpID + "' and Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }

        public PRResp getAllCentreEmpInfo(PRReq objPRReq)
        {
            string s = "(select Distinct EmpID,Name,Design,DeptID from PR_tbl_Employee where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "') Union (select Distinct EmpID,Name,Design,DeptID from PR_tbl_ProjectStaff where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ISHOC='Yes') order by Name Asc ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllCentreEmpInfo_ECID(PRReq objPRReq)
        {
            string s = "select Distinct EmpID,Name,Design,DeptID,ECID from PR_tbl_Employee where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ECID='" + objPRReq.ECID + "' order by Name Asc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp get_Emp_LeaveBalance(PRReq objPRReq)
        {
            string s = "select " + objPRReq.ColumnName + " as LBalance  from eL_tbl_EmpLeaves  where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp get_PSEmp_LeaveBalance(PRReq objPRReq)
        {
            string s = "select " + objPRReq.ColumnName + " as LBalance  from PR_tbl_ProjectStaff_CLs where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllHOCNames(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Employee  where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ISHOC='" + objPRReq.IsHOC + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllHocs(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Employee  where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ISHOC='" + objPRReq.IsHOC + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllHocEmps(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Employee  where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and DID='" + objPRReq.DID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp ChangeAdminsPassword(PRReq objPRReq)
        {
            string update = "update tbl_Admin set Password='" + objPRReq.NewPassword + "' where UID='" + objPRReq.UID + "' and Status='" + objPRReq.Status + "' and Password='" + objPRReq.Password + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp ChangeSGsPassword(PRReq objPRReq)
        {
            string update = "update Security_tbl_SecurityGuard set Password='" + objPRReq.NewPassword + "' where SGID='" + objPRReq.SGID + "' and Status='" + objPRReq.Status + "' and Password='" + objPRReq.Password + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp ChangeEmpPassword(PRReq objPRReq)
        {
            string update = "update PR_tbl_Employee set Password='" + objPRReq.NewPassword + "' where EmpID='" + objPRReq.EmpID + "' and Status='" + objPRReq.Status + "' and Password='" + objPRReq.Password + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp getReportingOfficeDetails_OEmpID(PRReq objPRReq)
        {
            string s = "(select distinct EmpID,Name,Design,DeptID,Email,Mobile from PR_tbl_Employee  where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.OEmpID + "') union(select distinct EmpID,Name,Design,DeptID,Email,Mobile from PR_tbl_ProjectStaff where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.OEmpID + "') ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        // VEhicle Admin
        public PRResp VehicleAdminLogin(PRReq objPRReq)
        {
            string s = "select * from tbl_Admin where UserID='" + objPRReq.UserID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getVehicleAdminData(PRReq objPRReq)
        {
            string s = "select * from tbl_Admin where UID='" + objPRReq.UID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        // Employee
        public PRResp getEmployeeDesignsET1A(PRReq objPRReq)
        {
            string s = "select distinct DSID,Design,EGID,ECID,ETID from PR_tbl_Employee where ECID='" + objPRReq.ECID + "' and ETID='" + objPRReq.ETID + "' and (EGID='1' or EGID='2') and Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' order by Design Asc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmployeeDesignsET1(PRReq objPRReq)
        {
            string s = "select distinct DSID,Design,EGID,ECID,ETID from PR_tbl_Employee where ECID='" + objPRReq.ECID + "' and ETID='" + objPRReq.ETID + "' and EGID!='3' and Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' order by Design Asc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getPSEmployeeDetails_DID(PRReq objPRReq)
        {
            string s = "select distinct * from PR_tbl_ProjectStaff where DID='" + objPRReq.DID + "' and Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and DSID is not null and Design is not NULL  order by Design Asc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getPSEmployeeDetails_DID_EmpID(PRReq objPRReq)
        {
            string s = "select distinct * from PR_tbl_ProjectStaff where DID='" + objPRReq.DID + "' and Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' and DSID is not null and Design is not NULL  order by Design Asc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getPSEmployeeDesignsET1(PRReq objPRReq)
        {
            string s = "select distinct DSID,Design,EGID,ETID,ECID from PR_tbl_ProjectStaff where EGID='" + objPRReq.EGID + "' and Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and DSID is not null and Design is not NULL  order by Design Asc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmployeeDesignsET2(PRReq objPRReq)
        {
            string s = "select distinct DSID, Design from PR_tbl_Employee where ECID='" + objPRReq.ECID + "' and ETID='" + objPRReq.ETID + "' and Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' order by Design Asc ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp EmpLogin(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Employee where  EmpID='" + objPRReq.EmpID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpData(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Employee where EmpID='" + objPRReq.EmpID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp ProjStaffLogin(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_ProjectStaff where EmpID='" + objPRReq.EmpID + "'  and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getProjStffData(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_ProjectStaff where EmpID='" + objPRReq.EmpID + "'  and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getPEmpPassword(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_ProjectStaff  where Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' and Password='" + objPRReq.Password + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp ChangePEmpContactDetails(PRReq objPRReq)
        {
            string update = "update PR_tbl_ProjectStaff set Email='" + objPRReq.Email + "', Mobile='" + objPRReq.Mobile + "' where EmpID='" + objPRReq.EmpID + "' and Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp BlockProjectStaff(PRReq objPRReq)
        {
            string update = "update PR_tbl_ProjectStaff set Status='" + objPRReq.Status + "' where EmpID='" + objPRReq.EmpID + "' and OID='" + objPRReq.OID + "' and HEmpID='" + objPRReq.HEmpID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp ChangePEmpPassword(PRReq objPRReq)
        {
            string update = "update PR_tbl_ProjectStaff set Password='" + objPRReq.NewPassword + "' where EmpID='" + objPRReq.EmpID + "' and Status='" + objPRReq.Status + "' and Password='" + objPRReq.Password + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp getEmpDatails(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Employee where EID='" + objPRReq.EID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpDatailsbyEMPID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Employee where EmpID='" + objPRReq.EmpID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmployees(PRReq objPRReq)
        {
            string s = "select distinct * from PR_tbl_Employee where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' order by Name Asc ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp SearchAllEmployees(PRReq objPRReq)
        {
            string s = "(select distinct EmpID,Name from PR_tbl_Employee where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and Name like '%" + objPRReq.Name + "%')union(select distinct EmpID,Name from PR_tbl_ProjectStaff where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and Name like '%" + objPRReq.Name + "%') order by Name Asc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp ShowAllEmployees_DID(PRReq objPRReq)
        {
            string s = "(select distinct EmpID,Name,Design,DeptID,Email,Mobile,Photo,Gender,DOB,DOJ,EGID from PR_tbl_Employee where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and DID='" + objPRReq.DID + "')union(select distinct EmpID,Name,Design,DeptID,Email,Mobile,Photo,Gender,DOB,DOJ,EGID from PR_tbl_ProjectStaff where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and DID='" + objPRReq.DID + "') order by EmpID Asc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp SGLogin(PRReq objPRReq)
        {
            string s = "select * from Security_tbl_SecurityGuard where SGNo='" + objPRReq.SGNO + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getSGData(PRReq objPRReq)
        {
            string s = "select * from Security_tbl_SecurityGuard where (SGID='" + objPRReq.SGID + "' or SGNo='" + objPRReq.SGNO + "') and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        // Payscal 
        public PRResp getPayScale_ProjectStaff(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Payscale where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and PSID='3'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getPayscales(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Payscale where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp AddPayscale(PRReq objPRReq)
        {
            string insert = "insert into PR_tbl_Payscale (OID,Payscale,Status) values('" + objPRReq.OID + "','" + objPRReq.Payscale + "','" + objPRReq.Status + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getPayscaleByName(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Payscale where Payscale='" + objPRReq.Payscale + "' and OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getPayscaleByOID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Payscale where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and PSID='" + objPRReq.PSID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp EditPayscaleByOID(PRReq objPRReq)
        {
            string update = "update PR_tbl_Payscale set Payscale='" + objPRReq.Payscale + "' where OID='" + objPRReq.OID + "' and PSID='" + objPRReq.PSID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp DelPayscale(PRReq objPRReq)
        {
            string hod = "delete from PR_tbl_Payscale where  OID='" + objPRReq.OID + "' and PSID='" + objPRReq.PSID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }
        public PRResp PayscaleSearch(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Payscale where Payscale like '%" + objPRReq.Payscale + "%' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        //Employee Goups
        public PRResp getEmpGroups(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_EmpGroup where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpGroupsProjectStaff(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_EmpGroup where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and EGID='3' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        // Employee Type
        public PRResp getEmpTypes(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_EmpType where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp AddEmpType(PRReq objPRReq)
        {
            string insert = "insert into PR_tbl_EmpType (OID,EmpType,Status) values('" + objPRReq.OID + "','" + objPRReq.EmpType + "','" + objPRReq.Status + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getEmpTypeByName(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_EmpType where EmpType='" + objPRReq.EmpType + "' and OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpTypeByOID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_EmpType where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ETID='" + objPRReq.ETID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp EditEmpTypeByOID(PRReq objPRReq)
        {
            string update = "update PR_tbl_EmpType set EmpType='" + objPRReq.EmpType + "' where OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp DelEmpType(PRReq objPRReq)
        {
            string hod = "delete from PR_tbl_EmpType where  OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }
        public PRResp EmpTypeSearch(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_EmpType where EmpType like '%" + objPRReq.EmpType + "%' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        // Employee Category
        public PRResp getEmpCategory_ExceptProjectStaff(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_EmpCategory where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ECID!='5'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpCategory_ProjectStaff(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_EmpCategory where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ECID='5'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpCategorys(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_EmpCategory where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpCategorys_Project(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_EmpCategory where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ECID=5 ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpCategorys_da1(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_EmpCategory where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ECID=1 or ECID=4 ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpCategorys_da2(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_EmpCategory where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ECID=2 or ECID=3 ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp AddEmpCategory(PRReq objPRReq)
        {
            string insert = "insert into PR_tbl_EmpCategory (OID,EmpCategory,Status) values('" + objPRReq.OID + "','" + objPRReq.EmpCategory + "','" + objPRReq.Status + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getEmpCategoryByName(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_EmpCategory where EmpCategory='" + objPRReq.EmpCategory + "' and OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpCategoryByOID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_EmpCategory where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ECID='" + objPRReq.ECID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp EditEmpCategoryByOID(PRReq objPRReq)
        {
            string update = "update PR_tbl_EmpCategory set EmpCategory='" + objPRReq.EmpCategory + "' where OID='" + objPRReq.OID + "' and ECID='" + objPRReq.ECID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp DelEmpCategory(PRReq objPRReq)
        {
            string hod = "delete from PR_tbl_EmpCategory where  OID='" + objPRReq.OID + "' and ECID='" + objPRReq.ECID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }
        public PRResp EmpCategorySearch(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_EmpCategory where EmpCategory like '%" + objPRReq.EmpCategory + "%' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }


        // Employee Designation

        public PRResp getDesigns(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Design where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' order by Design Asc ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp AddDesign(PRReq objPRReq)
        {
            string insert = "insert into PR_tbl_Design (OID,Design,Status) values('" + objPRReq.OID + "','" + objPRReq.Design + "','" + objPRReq.Status + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getDesignByName(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Design where Design='" + objPRReq.Design + "' and OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getDesignByOID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Design where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and DSID='" + objPRReq.DSID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp EditDesignByOID(PRReq objPRReq)
        {
            string update = "update PR_tbl_Design set Design='" + objPRReq.Design + "' where OID='" + objPRReq.OID + "' and DSID='" + objPRReq.DSID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp DelDesign(PRReq objPRReq)
        {
            string hod = "delete from PR_tbl_Design where  OID='" + objPRReq.OID + "' and DSID='" + objPRReq.DSID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }
        public PRResp DesignSearch(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Design where Design like '%" + objPRReq.Design + "%' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        // Department
        public PRResp getPS_ELDepts(PRReq objPRReq)
        {
            string s = "select * from eL_PS_tbl_Depts where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' order by DeptID Asc ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getPS_ELDepts_DID(PRReq objPRReq)
        {
            string s = "select * from eL_PS_tbl_Depts where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and DID='" + objPRReq.DID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getDepartments(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Department where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' order by DeptID Asc ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp AddDepartment(PRReq objPRReq)
        {
            string insert = "insert into PR_tbl_Department (OID,DeptID,Department,Status) values('" + objPRReq.OID + "','" + objPRReq.DeptID + "','" + objPRReq.Department + "','" + objPRReq.Status + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }

        public PRResp getDepartmentByName(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Department where DeptID='" + objPRReq.DeptID + "' and Department='" + objPRReq.Department + "' and OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getDepartmentByOID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Department where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and DID='" + objPRReq.DID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp EditDepartmentByOID(PRReq objPRReq)
        {
            string update = "update PR_tbl_Department set DeptID='" + objPRReq.DeptID + "', Department='" + objPRReq.Department + "' where OID='" + objPRReq.OID + "' and DID='" + objPRReq.DID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp DelDepartment(PRReq objPRReq)
        {
            string hod = "delete from PR_tbl_Department where  OID='" + objPRReq.OID + "' and DID='" + objPRReq.DID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }
        public PRResp DepartmentSearch(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Department where Department like '%" + objPRReq.Department + "%' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        // Financial Year
        public PRResp getFinYearbyToday(PRReq objPRReq)
        {
            //string s = "select GETDATE() AS Today,FID,FinYear from tbl_FinYear WHERE FromDate='"+objUserReq.FromDate+"' AND EndDate='"+objUserReq.EndDate+"' ";
            string s = "DECLARE @FIYear VARCHAR(20) SELECT @FIYear = (CASE WHEN (MONTH(GETDATE())) <= 3 THEN convert(varchar(4), YEAR(GETDATE())-1) + '-' + convert(varchar(4), YEAR(GETDATE())%100) ELSE convert(varchar(4),YEAR(GETDATE()))+ '-' + convert(varchar(4),(YEAR(GETDATE())%100)+1)END)  SELECT @FIYear AS F_YEAR ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp getFinancialYears(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_FinancialYear where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' order by FYID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp AddFinancialYear(PRReq objPRReq)
        {
            string insert = "insert into PR_tbl_FinancialYear (OID,FinancialYear,StartDate,EndDate,Status,UID,UName,Dated) values('" + objPRReq.OID + "','" + objPRReq.FinancialYear + "','" + objPRReq.StartDate + "','" + objPRReq.EndDate + "','" + objPRReq.Status + "','" + objPRReq.UID + "','" + objPRReq.UName + "','" + objPRReq.Dated + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getFinancialYearByName(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_FinancialYear where FinancialYear='" + objPRReq.FinancialYear + "' and OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getFinancialYearByFYID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_FinancialYear where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and FYID='" + objPRReq.FYID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp EditFinancialYearByFYID(PRReq objPRReq)
        {
            string update = "update PR_tbl_FinancialYear set FinancialYear='" + objPRReq.FinancialYear + "',StartDate='" + objPRReq.StartDate + "',EndDate='" + objPRReq.EndDate + "',UID='" + objPRReq.UID + "',UName='" + objPRReq.UName + "' where OID='" + objPRReq.OID + "' and FYID='" + objPRReq.FYID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp DelFinancialYear(PRReq objPRReq)
        {
            string hod = "delete from PR_tbl_FinancialYear where  OID='" + objPRReq.OID + "' and FYID='" + objPRReq.FYID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }
        public PRResp FinancialYearSearch(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_FinancialYear where FinancialYear like '%" + objPRReq.FinancialYear + "%' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp FinancialYear_FYID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_FinancialYear where FYID='" + objPRReq.FYID + "' and Status='Active' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        // State
        public PRResp getAllStates(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_State where Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        // DA Table
        public PRResp getAllDAs(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_DA where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllDAs_PSID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_DA where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and PSID='" + objPRReq.PSID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp AddDA(PRReq objPRReq)
        {
            string insert = "insert into PR_tbl_DA (OID,PSID,Payscale,DA,FromDate,Status,UID,UName,Dated) values('" + objPRReq.OID + "','" + objPRReq.PSID + "','" + objPRReq.Payscale + "','" + objPRReq.DA + "','" + objPRReq.FromDate + "','" + objPRReq.Status + "','" + objPRReq.UID + "','" + objPRReq.UName + "','" + objPRReq.Dated + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getDAByName(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_DA where PSID='" + objPRReq.PSID + "' and DA='" + objPRReq.DA + "' and OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getDAByDAID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_DA where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and DAID='" + objPRReq.DAID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp BlockDAByDAID(PRReq objPRReq)
        {
            string update = "update PR_tbl_DA set Status='" + objPRReq.Status + "', UID='" + objPRReq.UID + "',UName='" + objPRReq.UName + "',Dated='" + objPRReq.Dated + "' where OID='" + objPRReq.OID + "' and DAID='" + objPRReq.DAID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }

        public PRResp getDAByEmp(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_DA where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' and ECID='" + objPRReq.ECID + "' and PSID='" + objPRReq.PSID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }


        // HRA Table
        public PRResp getHRAByEmp(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_HRA where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' and ECID='" + objPRReq.ECID + "' and PSID='" + objPRReq.PSID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllHRAs(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_HRA where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllHRAs_ETID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_HRA where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp AddHRA(PRReq objPRReq)
        {
            string insert = "insert into PR_tbl_HRA (OID,ETID,ECID,EmpCategory,PSID,Payscale,HRA,Status,UID,UName,Dated) values('" + objPRReq.OID + "','" + objPRReq.ETID + "','" + objPRReq.ECID + "','" + objPRReq.EmpCategory + "','" + objPRReq.PSID + "','" + objPRReq.Payscale + "','" + objPRReq.HRA + "','" + objPRReq.Status + "','" + objPRReq.UID + "','" + objPRReq.UName + "','" + objPRReq.Dated + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getHRAByName(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_HRA where ETID='" + objPRReq.ETID + "' and ECID='" + objPRReq.ECID + "' and PSID='" + objPRReq.PSID + "' and HRA='" + objPRReq.HRA + "' and OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getHRAByHRAID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_HRA where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and HRAID='" + objPRReq.HRAID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp EditHRAByOID(PRReq objPRReq)
        {
            string update = "update PR_tbl_DA set ETID='" + objPRReq.ETID + "',ECID='" + objPRReq.ECID + "',EmpCategory='" + objPRReq.EmpCategory + "', PSID='" + objPRReq.PSID + "',Payscale='" + objPRReq.Payscale + "', HRA='" + objPRReq.HRA + "',UID='" + objPRReq.UID + "',UName='" + objPRReq.UName + "',Dated='" + objPRReq.Dated + "' where OID='" + objPRReq.OID + "' and HRAID='" + objPRReq.HRAID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp DelHRA(PRReq objPRReq)
        {
            string hod = "delete from PR_tbl_HRA where  OID='" + objPRReq.OID + "' and HRAID='" + objPRReq.HRAID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }
        public PRResp HRASearch(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_HRA where HRA like '%" + objPRReq.HRA + "%' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        // TRA Table
        public PRResp getTRAByEmp(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_TRA where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' and ECID='" + objPRReq.ECID + "' and PSID='" + objPRReq.PSID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getTRAByEmp_BP(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_TRA where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' and ECID='" + objPRReq.ECID + "' and PSID='" + objPRReq.PSID + "' and MinBasicPay>='" + objPRReq.MinBasicPay + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getTRAByEmp_BPSlabs(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_TRA where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' and ECID='" + objPRReq.ECID + "' and PSID='" + objPRReq.PSID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllTRAs(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_TRA where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllTRAs_ETID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_TRA where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp AddTRA(PRReq objPRReq)
        {
            string insert = "insert into PR_tbl_TRA (OID,ETID,ECID,EmpCategory,PSID,Payscale,MinBasicPay,MinGradePay,TRA,Status,UID,UName,Dated) values('" + objPRReq.OID + "','" + objPRReq.ETID + "','" + objPRReq.ECID + "','" + objPRReq.EmpCategory + "','" + objPRReq.PSID + "','" + objPRReq.Payscale + "','" + objPRReq.MinBasicPay + "','" + objPRReq.MinGradePay + "','" + objPRReq.TRA + "','" + objPRReq.Status + "','" + objPRReq.UID + "','" + objPRReq.UName + "','" + objPRReq.Dated + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getTRAByName(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_TRA where ETID='" + objPRReq.ETID + "' and ECID='" + objPRReq.ECID + "' and PSID='" + objPRReq.PSID + "' and TRA='" + objPRReq.TRA + "' and OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and MinBasicPay='" + objPRReq.MinBasicPay + "' and MinGradePay='" + objPRReq.MinGradePay + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getTRAByTRAID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_TRA where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and TRAID='" + objPRReq.TRAID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp EditTRAByOID(PRReq objPRReq)
        {
            string update = "update PR_tbl_DA set ETID='" + objPRReq.ETID + "',ECID='" + objPRReq.ECID + "',EmpCategory='" + objPRReq.EmpCategory + "', PSID='" + objPRReq.PSID + "',Payscale='" + objPRReq.Payscale + "', MinBasicPay='" + objPRReq.MinBasicPay + "', MinGradePay='" + objPRReq.MinGradePay + "', TRA='" + objPRReq.TRA + "',UID='" + objPRReq.UID + "',UName='" + objPRReq.UName + "',Dated='" + objPRReq.Dated + "' where OID='" + objPRReq.OID + "' and TRAID='" + objPRReq.TRAID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp DelTRA(PRReq objPRReq)
        {
            string hod = "delete from PR_tbl_TRA where  OID='" + objPRReq.OID + "' and TRAID='" + objPRReq.TRAID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }
        public PRResp TRASearch(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_TRA where TRA like '%" + objPRReq.TRA + "%' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        // tbl_NPA
        public PRResp getNPAByEmp(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_NPA where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' and ECID='" + objPRReq.ECID + "' and PSID='" + objPRReq.PSID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllNPAs(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_NPA where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllNPAs_ETID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_NPA where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp AddNPA(PRReq objPRReq)
        {
            string insert = "insert into PR_tbl_NPA (OID,ETID,ECID,EmpCategory,PSID,Payscale,NPA,Status,UID,UName,Dated) values('" + objPRReq.OID + "','" + objPRReq.ETID + "','" + objPRReq.ECID + "','" + objPRReq.EmpCategory + "','" + objPRReq.PSID + "','" + objPRReq.Payscale + "','" + objPRReq.NPA + "','" + objPRReq.Status + "','" + objPRReq.UID + "','" + objPRReq.UName + "','" + objPRReq.Dated + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getNPAByName(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_NPA where ETID='" + objPRReq.ETID + "' and ECID='" + objPRReq.ECID + "' and PSID='" + objPRReq.PSID + "' and NPA='" + objPRReq.NPA + "' and OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getNPAByNPAID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_NPA where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and NPAID='" + objPRReq.NPAID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp EditNPAByOID(PRReq objPRReq)
        {
            string update = "update PR_tbl_DA set ETID='" + objPRReq.ETID + "',ECID='" + objPRReq.ECID + "',EmpCategory='" + objPRReq.EmpCategory + "', PSID='" + objPRReq.PSID + "',Payscale='" + objPRReq.Payscale + "', NPA='" + objPRReq.NPA + "',UID='" + objPRReq.UID + "',UName='" + objPRReq.UName + "',Dated='" + objPRReq.Dated + "' where OID='" + objPRReq.OID + "' and NPAID='" + objPRReq.NPAID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp DelNPA(PRReq objPRReq)
        {
            string hod = "delete from PR_tbl_NPA where  OID='" + objPRReq.OID + "' and NPAID='" + objPRReq.NPAID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }
        public PRResp NPASearch(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_NPA where NPA like '%" + objPRReq.NPA + "%' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        // Project Titles


        public PRResp getAllProjects(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Projects where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllProjects_UID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Projects where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and UID='" + objPRReq.UID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllProjects_PID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Projects where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and PID='" + objPRReq.PID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp AddProjectTitle(PRReq objPRReq)
        {
            string insert = "insert into PR_tbl_Projects (OID,DID,DeptID,ProjectCode,ProjectTitle,StartDate,EndDate,ProjectCoordinator,CentreHead,Status,UID,UName,Dated) values('" + objPRReq.OID + "','" + objPRReq.DID + "','" + objPRReq.DeptID + "','" + objPRReq.ProjectCode + "','" + objPRReq.ProjectTitle + "','" + objPRReq.StartDate + "','" + objPRReq.EndDate + "','" + objPRReq.ProjectCoordinator + "','" + objPRReq.CentreHead + "','" + objPRReq.Status + "','" + objPRReq.UID + "','" + objPRReq.UName + "','" + objPRReq.Dated + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getProjectByTitle(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Projects where ProjectCode='" + objPRReq.ProjectCode + "' and ProjectTitle='" + objPRReq.ProjectTitle + "' and ProjectCoordinator='" + objPRReq.ProjectCoordinator + "' and DID='" + objPRReq.DID + "' and OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getProjectByPID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Projects where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and PID='" + objPRReq.PID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp EditProjectByPID(PRReq objPRReq)
        {
            string update = "update PR_tbl_Projects set DID='" + objPRReq.DID + "',DeptID='" + objPRReq.DeptID + "',ProjectCode='" + objPRReq.ProjectCode + "',ProjectTitle='" + objPRReq.ProjectTitle + "', ProjectCoordinator='" + objPRReq.ProjectCoordinator + "',StartDate='" + objPRReq.StartDate + "', EndDate='" + objPRReq.EndDate + "', CentreHead='" + objPRReq.CentreHead + "',UID='" + objPRReq.UID + "',UName='" + objPRReq.UName + "',Dated='" + objPRReq.Dated + "' where OID='" + objPRReq.OID + "' and PID='" + objPRReq.PID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp DelProjectTitle(PRReq objPRReq)
        {
            string hod = "delete from PR_tbl_Projects where  OID='" + objPRReq.OID + "' and PID='" + objPRReq.PID + "' and UID='" + objPRReq.UID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }
        public PRResp ProjectSearch(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Projects where ProjectTitle like '%" + objPRReq.ProjectTitle + "%' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }


        // tbl Employee
        public PRResp getREmpCount_DID(PRReq objPRReq)
        {
            string s = "select distinct Count(EmpID) as rcount from PR_tbl_Employee where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and DID='" + objPRReq.DID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getPSEmpCount_DID(PRReq objPRReq)
        {
            string s = "select distinct Count(EmpID) as pscount from PR_tbl_ProjectStaff where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and DID='" + objPRReq.DID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp SearchEmpNamebyGroup(PRReq objPRReq)
        {
            string s = "select distinct Name,EmpID from PR_tbl_Employee where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and EmpGroup='" + objPRReq.EmpGroup + "' and Name like'%" + objPRReq.Name + "%' order by Name Asc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpNamebyGroup(PRReq objPRReq)
        {
            string s = "select distinct Name,EmpID from PR_tbl_Employee where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and EmpGroup='" + objPRReq.EmpGroup + "' order by Name Asc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getPSEmpNamebyGroup(PRReq objPRReq)
        {
            string s = "select distinct Name,EmpID from PR_tbl_ProjectStaff where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and EGID='3' order by Name Asc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getDepartments_UID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Employee where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllRegStaff_EGID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Employee where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and EGID='" + objPRReq.EGID + "' order by EmpID Asc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllRegStaff_EGID_DIDs(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Employee where Status='" + objPRReq.Status + "' and DID='" + objPRReq.DID + "' and OID='" + objPRReq.OID + "' and EGID='" + objPRReq.EGID + "' order by EmpID Asc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllPSStaff_DID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_ProjectStaff where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and DID='" + objPRReq.DID + "' order by Name Asc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllRegStaff_EGID_DID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Employee where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and EGID='" + objPRReq.EGID + "' order by DeptID Asc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllProjStaff_EGID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_ProjectStaff where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and EGID='" + objPRReq.EGID + "' and Flag1='" + objPRReq.Flag1 + "' order by DID Asc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllProjStaff_EGID_DID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_ProjectStaff where Status='" + objPRReq.Status + "' and DID='" + objPRReq.DID + "' and OID='" + objPRReq.OID + "' and EGID='" + objPRReq.EGID + "' and Flag1='" + objPRReq.Flag1 + "' order by DID Asc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllProjStaff_EGID_DOJ(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_ProjectStaff where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and EGID='" + objPRReq.EGID + "' and Flag1='" + objPRReq.Flag1 + "' order by FDOJ,DeptID Asc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp EditEmpByNewEmpID_DOJ(PRReq objPRReq)
        {
            string update = "update PR_tbl_ProjectStaff set NewEmpID='" + objPRReq.OEmpID + "' where OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp Set_DeptIncharge_EmpID(PRReq objPRReq)
        {
            string update = "update PR_tbl_ProjectStaff set IsIncharge='" + objPRReq.IsHOC + "' where OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp getAllDeptIncharges_DeptID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_ProjectStaff where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and IsIncharge='Yes' order by DeptID Asc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllDeptIncharges_EmpID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_ProjectStaff where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and IsIncharge='Yes' and EmpID='" + objPRReq.EmpID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getPSDepartments_UID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_ProjectStaff where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpDetails_EmpID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Employee where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getPSEmpDetails_EmpID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_ProjectStaff where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp SearchHallsByName(PRReq objPRReq)
        {
            string s = "select * from CIT_tbl_Halls where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and HallName like '%" + objPRReq.Name + "%'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp SearchPSEmpDetails_EmpID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_ProjectStaff where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and Name like '%" + objPRReq.Name + "%'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getPSContacts(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_ProjectStaff where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and Flag1='1'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getPSEmpProfile_EmpID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_ProjectStaff where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' and Flag1='" + objPRReq.Flag1 + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getRegularETypes(PRReq objPRReq)
        {
            string s = "select distinct ETID, EmpType,ECID,EmpCategory from PR_tbl_Employee where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ETID<" + objPRReq.ETID + " ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmps(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Employee where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmp_EMPID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Employee where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmp_EMPID_UID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Employee where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' and UID='" + objPRReq.UID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpbyETID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Employee where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpbyETID_ECID_EGID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Employee where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' and ECID='" + objPRReq.ECID + "' and EGID='" + objPRReq.EGID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp AddEmp(PRReq objPRReq)
        {
            string insert = "insert into PR_tbl_Employee (OID,ETID,EmpType,ECID,EmpCategory,EGID,EmpGroup,DID,DeptID,DSID,Design,EmpID,Name,FathersName,Email,Password,Mobile,Aadhar,DOB,DOJ,Gender,PAN,BankAcType,BankName,BankBranch,BankAccNo,IFSCCode,Address,State,Photo,Role,Status,UID,UName,Dated) values('" + objPRReq.OID + "','" + objPRReq.ETID + "','" + objPRReq.EmpType + "','" + objPRReq.ECID + "','" + objPRReq.EmpCategory + "','" + objPRReq.EGID + "','" + objPRReq.EmpGroup + "','" + objPRReq.DID + "','" + objPRReq.DeptID + "','" + objPRReq.DSID + "','" + objPRReq.Design + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.FathersName + "','" + objPRReq.Email + "','" + objPRReq.Password + "','" + objPRReq.Mobile + "','" + objPRReq.Aadhar + "','" + objPRReq.DOB + "','" + objPRReq.DOJ + "','" + objPRReq.Gender + "','" + objPRReq.PAN + "','" + objPRReq.BankAcType + "','" + objPRReq.BankName + "','" + objPRReq.BankBranchName + "','" + objPRReq.BankAccNo + "','" + objPRReq.IFSCCode + "','" + objPRReq.Address + "','" + objPRReq.State + "','" + objPRReq.Photo + "','" + objPRReq.Role + "','" + objPRReq.Status + "','" + objPRReq.UID + "','" + objPRReq.UName + "','" + objPRReq.Dated + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp AddEmpbyDA12(PRReq objPRReq)
        {
            string insert = "insert into PR_tbl_Employee (OID,ETID,EmpType,ECID,EmpCategory,EGID,EmpGroup,DID,DeptID,DSID,Design,EmpID,Name,Email,Password,Mobile,Aadhar,DOB,DOJ,Gender,PAN,BankAcType,BankName,BankBranch,BankAccNo,IFSCCode,Photo,Role,Status,UID,UName,Dated,ISHOC) values('" + objPRReq.OID + "','" + objPRReq.ETID + "','" + objPRReq.EmpType + "','" + objPRReq.ECID + "','" + objPRReq.EmpCategory + "','" + objPRReq.EGID + "','" + objPRReq.EmpGroup + "','" + objPRReq.DID + "','" + objPRReq.DeptID + "','" + objPRReq.DSID + "','" + objPRReq.Design + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.Email + "','" + objPRReq.Password + "','" + objPRReq.Mobile + "','"+objPRReq.Aadhar+"','" + objPRReq.DOB + "','" + objPRReq.DOJ + "','" + objPRReq.Gender + "','" + objPRReq.PAN + "','" + objPRReq.BankAcType + "','" + objPRReq.BankName + "','" + objPRReq.BankBranchName + "','" + objPRReq.BankAccNo + "','" + objPRReq.IFSCCode + "','" + objPRReq.Photo + "','" + objPRReq.Role + "','" + objPRReq.Status + "','" + objPRReq.UID + "','" + objPRReq.UName + "','" + objPRReq.Dated + "','" + objPRReq.IsHOC + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getEmpByName(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Employee where PAN='" + objPRReq.PAN + "' and EmpID='" + objPRReq.EmpID + "' and OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpByEID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Employee where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EID='" + objPRReq.EID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpByEmpID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Employee where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpByEmpID_UID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Employee where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' and UID='" + objPRReq.UID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpMasterSalaryByEmpID_UID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Employee_Master_Salary where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' and UID='" + objPRReq.UID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpMasterSalaryBy_EmpID_forLeave(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Employee_Master_Salary where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpMasterSalaryBy_Ded_Sum_EmpID(PRReq objPRReq)
        {
            string s = "select LOPAmount,GPF,CPF,NPS,PFA,MS,SF,GC,QR,EC,WC,BF,LIC,GI,IT,PT,SC,HBA_NIRD,HBA_HDFC,HBA_Others,HBA_Adv_Int,INTA,TA,CABTV,VA,VAI,BL,PLI,COMPL,COMPLInt,Others,BFA,BFAI,CourtAt,HC, (LOPAmount+GPF+CPF+NPS+PFA+MS+SF+GC+QR+EC+WC+BF+LIC+GI+IT+PT+SC+HBA_NIRD+HBA_HDFC+HBA_Others+HBA_Adv_Int+INTA+TA+CABTV+VA+VAI+BL+PLI+COMPL+COMPLInt+Others+BFA+BFAI+CourtAt+HC) as totdud, GrossPay from PR_tbl_Employee_Master_Salary where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpByDID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Employee where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and DID='" + objPRReq.DID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp EditEmpByEID(PRReq objPRReq)
        {
            string update = "update PR_tbl_Employee set OID='" + objPRReq.OID + "',ETID='" + objPRReq.ETID + "',EmpType='" + objPRReq.EmpType + "',ECID='" + objPRReq.ECID + "',EmpCategory='" + objPRReq.EmpCategory + "',DID='" + objPRReq.DID + "',DeptID='" + objPRReq.DeptID + "',DSID='" + objPRReq.DSID + "',Design='" + objPRReq.Design + "',EmpID='" + objPRReq.EmpID + "',Name='" + objPRReq.Name + "',FathersName='" + objPRReq.FathersName + "',Email='" + objPRReq.Email + "',Mobile='" + objPRReq.Mobile + "',Aadhar='" + objPRReq.Aadhar + "',DOB='" + objPRReq.DOB + "',DOJ='" + objPRReq.DOJ + "',Gender='" + objPRReq.Gender + "',PAN='" + objPRReq.PAN + "',BankAcType='" + objPRReq.BankAcType + "',BankName='" + objPRReq.BankName + "',BankBranch='" + objPRReq.BankBranchName + "',BankAccNo='" + objPRReq.BankAccNo + "',IFSCCode='" + objPRReq.IFSCCode + "',Address='" + objPRReq.Address + "',State='" + objPRReq.State + "', Photo='" + objPRReq.Photo + "',UID='" + objPRReq.UID + "',UName='" + objPRReq.UName + "',Dated='" + objPRReq.Dated + "' where OID='" + objPRReq.OID + "' and EID='" + objPRReq.EID + "' and EmpID='" + objPRReq.EmpID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp EditDesignEmpByEID(PRReq objPRReq)
        {
            string update = "update PR_tbl_Employee_Master_Salary set OID='" + objPRReq.OID + "',ETID='" + objPRReq.ETID + "',EmpType='" + objPRReq.EmpType + "',ECID='" + objPRReq.ECID + "',EmpCategory='" + objPRReq.EmpCategory + "',DID='" + objPRReq.DID + "',DeptID='" + objPRReq.DeptID + "',DSID='" + objPRReq.DSID + "',Design='" + objPRReq.Design + "',Name='" + objPRReq.Name + "',Email='" + objPRReq.Email + "',Mobile='" + objPRReq.Mobile + "',Aadhar='" + objPRReq.Aadhar + "',DOB='" + objPRReq.DOB + "',DOJ='" + objPRReq.DOJ + "',Gender='" + objPRReq.Gender + "',PAN='" + objPRReq.PAN + "',BankAcType='" + objPRReq.BankAcType + "',BankName='" + objPRReq.BankName + "',BankBranch='" + objPRReq.BankBranchName + "',BankAccNo='" + objPRReq.BankAccNo + "',IFSCCode='" + objPRReq.IFSCCode + "', Photo='" + objPRReq.Photo + "',Dated='" + objPRReq.Dated + "' where OID='" + objPRReq.OID + "' and EID='" + objPRReq.EID + "' and EmpID='" + objPRReq.EmpID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp UpdateEmpByEmpID(PRReq objPRReq)
        {
            string update = "update PR_tbl_Employee set DID='" + objPRReq.DID + "',DeptID='" + objPRReq.DeptID + "',Name='" + objPRReq.Name + "', Design='" + objPRReq.Design + "', FathersName='" + objPRReq.FathersName + "',Email='" + objPRReq.Email + "',Mobile='" + objPRReq.Mobile + "',Aadhar='" + objPRReq.Aadhar + "',DOB='" + objPRReq.DOB + "',DOJ='" + objPRReq.DOJ + "',PAN='" + objPRReq.PAN + "',BankAcType='" + objPRReq.BankAcType + "',BankName='" + objPRReq.BankName + "',BankBranch='" + objPRReq.BankBranchName + "',IFSCCode='" + objPRReq.IFSCCode + "',Address='" + objPRReq.Address + "',State='" + objPRReq.State + "', Photo='" + objPRReq.Photo + "' where OID='" + objPRReq.OID + "' and (EmpID='" + objPRReq.EmpID + "' or EID='" + objPRReq.EID + "') and Status='" + objPRReq.Status + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp BlockEmpByEID(PRReq objPRReq)
        {
            string update = "update PR_tbl_Employee set Status='" + objPRReq.Status + "' where EmpID='" + objPRReq.EmpID + "' and OID='" + objPRReq.OID + "' and UID='" + objPRReq.UID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp BlockRegStaffBy_EmpID(PRReq objPRReq)
        {
            string update = "update PR_tbl_Employee set Status='" + objPRReq.Status + "' where EmpID='" + objPRReq.EmpID + "' and OID='" + objPRReq.OID + "' and EGID='" + objPRReq.EGID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }

        public PRResp BlockRegStaff_SalBy_EmpID(PRReq objPRReq)
        {
            string update = "update PR_tbl_Employee_Master_Salary set Status='" + objPRReq.Status + "' where EmpID='" + objPRReq.EmpID + "' and OID='" + objPRReq.OID + "' and EGID='" + objPRReq.EGID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp BlockProjStaffBy_EmpID(PRReq objPRReq)
        {
            string update = "update PR_tbl_ProjectStaff  set Status='" + objPRReq.Status + "' where EmpID='" + objPRReq.EmpID + "' and OID='" + objPRReq.OID + "' and EGID='" + objPRReq.EGID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp BlockProjStaffCLsBy_EmpID(PRReq objPRReq)
        {
            string update = "update PR_tbl_ProjectStaff_CLs  set Status='" + objPRReq.Status + "' where EmpID='" + objPRReq.EmpID + "' and OID='" + objPRReq.OID + "' and EGID='" + objPRReq.EGID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp UpdateOTPByEmpID(PRReq objPRReq)
        {
            string update = "update PR_tbl_Employee set OTP='" + objPRReq.OTP + "' where EmpID='" + objPRReq.EmpID + "' and OID='" + objPRReq.OID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp UpdateOTPByPEmpID(PRReq objPRReq)
        {
            string update = "update PR_tbl_ProjectStaff set OTP='" + objPRReq.OTP + "' where EmpID='" + objPRReq.EmpID + "' and OID='" + objPRReq.OID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp UpdatePhotoPEmpID(PRReq objPRReq)
        {
            string update = "update PR_tbl_ProjectStaff set Photo='" + objPRReq.Photo + "' where EmpID='" + objPRReq.EmpID + "' and OID='" + objPRReq.OID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp UpdatePhotoREmpID(PRReq objPRReq)
        {
            string update = "update PR_tbl_Employee set Photo='" + objPRReq.Photo + "' where EmpID='" + objPRReq.EmpID + "' and OID='" + objPRReq.OID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp UpdatePhotoREmpLeaves(PRReq objPRReq)
        {
            string update = "update eL_tbl_EmpLeaves set Photo='" + objPRReq.Photo + "' where EmpID='" + objPRReq.EmpID + "' and OID='" + objPRReq.OID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp UpdatePSEmpPhoto(PRReq objPRReq)
        {
            string update = "update PR_tbl_ProjectStaff set Photo='" + objPRReq.Photo + "' where EmpID='" + objPRReq.EmpID + "' and OID='" + objPRReq.OID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp UpdatePSEmpPhotoCls(PRReq objPRReq)
        {
            string update = "update PR_tbl_ProjectStaff_CLs set Photo='" + objPRReq.Photo + "' where EmpID='" + objPRReq.EmpID + "' and OID='" + objPRReq.OID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp DelEmp(PRReq objPRReq)
        {
            string hod = "delete from PR_tbl_Employee where  OID='" + objPRReq.OID + "' and EID='" + objPRReq.EID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }
        public PRResp DelProjectStaff(PRReq objPRReq)
        {
            string hod = "delete from PR_tbl_ProjectStaff where  OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }
        public PRResp EmpSearch(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Employee where Name like '%" + objPRReq.Name + "%' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpCount(PRReq objPRReq)
        {
            string s = "select count(ECID) as empCount from PR_tbl_Employee where OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' and ECID='" + objPRReq.ECID + "' and Status='Active' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpCountActive(PRReq objPRReq)
        {
            string s = "select count(EID) as empCount from PR_tbl_Employee where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllActiveEmployees_EGID_DSID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Employee where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and DSID='" + objPRReq.DSID + "' and EGID='" + objPRReq.EGID + "' and ECID='" + objPRReq.ECID + "' and ETID='" + objPRReq.ETID + "' order by EmpID Asc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllActivePSEmployees_EGID_DSID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_ProjectStaff where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and DSID='" + objPRReq.DSID + "' and EGID='" + objPRReq.EGID + "' order by Name Asc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllActiveEmployees(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Employee where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' order by DeptID,Design Asc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpDSCount(PRReq objPRReq)
        {
            string s = "select count(EID) as empCount from PR_tbl_Employee where OID='" + objPRReq.OID + "' and ECID='" + objPRReq.ECID + "' and ETID='" + objPRReq.ETID + "' and DSID='" + objPRReq.DSID + "' and EGID='" + objPRReq.EGID + "' and Status='Active' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getPSEmpDSCount(PRReq objPRReq)
        {
            string s = "select count(EmpID) as empCount from PR_tbl_ProjectStaff where OID='" + objPRReq.OID + "' and EGID='" + objPRReq.EGID + "' and DSID='" + objPRReq.DSID + "' and Status='Active' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getProjectETypes(PRReq objPRReq)
        {
            string s = "select distinct ECID,EmpCategory from PR_tbl_ProjectStaff where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getPSGroups(PRReq objPRReq)
        {
            string s = "select distinct EGID,EmpGroup from PR_tbl_ProjectStaff where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getPSEmpCount(PRReq objPRReq)
        {
            string s = "select count(PSID) as empCount from PR_tbl_ProjectStaff where OID='" + objPRReq.OID + "' and ECID='" + objPRReq.ECID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getPSEGEmpCount(PRReq objPRReq)
        {
            string s = "select count(EGID) as empCount from PR_tbl_ProjectStaff where OID='" + objPRReq.OID + "' and Status='Active' and EGID='" + objPRReq.EGID + "'  and DSID is not null and Design is not NULL ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        // Master Emp Sal
        public PRResp getEmpMSalayByEmpID_UID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Employee_Master_Salary where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' and UID='" + objPRReq.UID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpMSalayforNewStatement(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Employee_Master_Salary where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpMSalayforNewMonth(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Employee_Monthly_Salary where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpProfilebyEID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Employee where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and (EID='" + objPRReq.EID + "' or EmpID='" + objPRReq.EmpID + "')";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpNewSalbyEID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Employee_Master_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and (EID='" + objPRReq.EID + "' or EmpID='" + objPRReq.EmpID + "')";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpNewSalbyETID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Employee_Master_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpNewSalbyETID_UID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Employee_Master_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' and UID='" + objPRReq.UID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpNewSalbyETID_ECID_EGID_UID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Employee_Master_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' and ECID='" + objPRReq.ECID + "' and EGID='" + objPRReq.EGID + "' order by EmpID ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp EditDesignEmpByEID_DAHike(PRReq objPRReq)
        {
            string update = "update PR_tbl_Employee_Master_Salary set DA='" + objPRReq.DA + "',LOPDays='" + objPRReq.LopDays + "',LOPAmount='" + objPRReq.LopAmount + "', GrossPay='" + objPRReq.GrossSal + "',GrossPayWords='" + objPRReq.GrossSalWords + "',NetPay='" + objPRReq.NetPay + "',NetPayInWords='" + objPRReq.NetPayInWords + "',LOPDA='" + objPRReq.LOPDA + "',LOPBasicPay='" + objPRReq.LOPBasicPay + "',LOPGrossPay='" + objPRReq.LOPGrossPay + "',LOPGrossPayInwords='" + objPRReq.LopGrossPayinWords + "', TRA='" + objPRReq.TRA + "'  where OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' and ETID='" + objPRReq.ETID + "' and ECID='" + objPRReq.ECID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp getEmpNewSalbyETID_ECID_EGIDbyUID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Employee_Master_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' and ECID='" + objPRReq.ECID + "' and EGID='" + objPRReq.EGID + "' and UID='" + objPRReq.UID + "' order by EmpID ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpNewSalbyETID_ECID_EGID(PRReq objPRReq)
        {
            string s = "select EmpCategory,EmpID,Name,BankAccNo,PPB,GRP,BasicPay,DA,HRA,TRA,TRGA,NPA,OTPay,SpecialDutyAllowances,PatientCareAllowances,BookAllowances,SCA,WashingAllowances,DPA,SumptuaryAllowances,OtherAllowances,Arrears,GrossPay from PR_tbl_Employee_Master_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' and ECID='" + objPRReq.ECID + "' and EGID='" + objPRReq.EGID + "' order by EmpID ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpSumOfGrossSalbyETID_ECID_EGID_UID(PRReq objPRReq)
        {
            string s = "select sum(GrossPay) as grosspay from PR_tbl_Employee_Master_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' and ECID='" + objPRReq.ECID + "' and EGID='" + objPRReq.EGID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp BlockEmpNewSalByEMSID(PRReq objPRReq)
        {
            string update = "update PR_tbl_Employee_Master_Salary set Status='" + objPRReq.Status + "' where OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' and UID='" + objPRReq.UID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }

        public PRResp getEmpByEMSID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Employee_Master_Salary where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EMSID='" + objPRReq.EMSID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getProjectStaffEmpByEmpID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_ProjectStaff where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getProjectStaffEmpByEmpID_HEmpID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_ProjectStaff where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' and HEmpID='" + objPRReq.HEmpID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        // Project Staff Employee
        public PRResp AddProjectStaff(PRReq objPRReq)
        {
            string insert = "insert into PR_tbl_ProjectStaff (SNo,OID,EGID,EmpGroup,PSID,PayScale,DID,DeptID,DSID,Design,EmpID,Name,Email,Mobile,Aadhar,DOJ,DOR,Gender,PAN,BankAcType,BankName,BankBranch,BankAccNo,IFSCCode,Photo,PID,ProjectCode,ProjectTitle,ProjectCoordinator,CentreHead,StartDate,EndDate,BasicPay,GrossSal,QuarterAllotted,QuarterType,OfficeOrderNo,OfficeOrderDate,OOIssuingAuthority,Status,UID,UName,Dated,FDOJ,EDate,CitizenType) values('" + objPRReq.SNO + "','" + objPRReq.OID + "','" + objPRReq.ECID + "','" + objPRReq.EmpCategory + "','" + objPRReq.PSID + "','" + objPRReq.Payscale + "','" + objPRReq.DID + "','" + objPRReq.DeptID + "','" + objPRReq.DSID + "','" + objPRReq.Design + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.Email + "','" + objPRReq.Mobile + "','" + objPRReq.Aadhar + "','" + objPRReq.DOJ + "','" + objPRReq.DOR + "','" + objPRReq.Gender + "','" + objPRReq.PAN + "','" + objPRReq.BankAcType + "','" + objPRReq.BankName + "','" + objPRReq.BankBranchName + "','" + objPRReq.BankAccNo + "','" + objPRReq.IFSCCode + "','" + objPRReq.Photo + "','" + objPRReq.PID + "','" + objPRReq.ProjectCode + "','" + objPRReq.ProjectTitle + "','" + objPRReq.ProjectCoordinator + "','" + objPRReq.CentreHead + "','" + objPRReq.StartDate + "','" + objPRReq.EndDate + "','" + objPRReq.BasicPay + "','" + objPRReq.GrossSal + "','" + objPRReq.QuarterAllotted + "','" + objPRReq.QuarterType + "','" + objPRReq.OffOrderNo + "','" + objPRReq.OffOrderDate + "','" + objPRReq.OffOrderIssuingAuthority + "','" + objPRReq.Status + "','" + objPRReq.UID + "','" + objPRReq.UName + "','" + objPRReq.Dated + "','" + objPRReq.FDOJ + "','" + objPRReq.EDate + "','" + objPRReq.CitizenType + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp AddProjectStaff_Admin(PRReq objPRReq)
        {
            string insert = "insert into PR_tbl_ProjectStaff (SNo,OID,ETID,ECID,EGID,EmpGroup,PSID,PayScale,DID,DeptID,DSID,Design,AttendanceID,EmpID,Name,Password,Mobile,DOJ,DOR,StartDate,EndDate,Role,Status,UID,UName,Dated) values('" + objPRReq.SNO + "','" + objPRReq.OID + "','" + objPRReq.ETID + "','" + objPRReq.ECID + "','" + objPRReq.EGID + "','" + objPRReq.EmpGroup + "','" + objPRReq.PSID + "','" + objPRReq.Payscale + "','" + objPRReq.DID + "','" + objPRReq.DeptID + "','" + objPRReq.DSID + "','" + objPRReq.Design + "','" + objPRReq.AttendanceID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.Password + "','" + objPRReq.Mobile + "','" + objPRReq.DOJ + "','" + objPRReq.EndDate + "','" + objPRReq.DOJ + "','" + objPRReq.EndDate + "','" + objPRReq.Role + "','" + objPRReq.Status + "','" + objPRReq.UID + "','" + objPRReq.UName + "','" + objPRReq.Dated + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getProjectStaff_EmpID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_ProjectStaff where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllProjectStaff_Active_Flag1(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_ProjectStaff  where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and Flag1='1' and DID!='26' order by DID Asc ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getProjectStaff_EmpID_Flag1(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_ProjectStaff where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and Flag1 is NULL";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp get_Approved_PSEmpLeave_DatesEmpID_SLDate_LeaveType(PRReq objPRReq)
        {
            string s = "select Sum(SLNoofDays) as LCount from eL_tbl_ProjStaff_eLeave_Applied where OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' and Approval='1' and (SLFromDate >= convert(datetime, '" + objPRReq.SLFromDate + "',105) and SLFromDate < convert(datetime, '" + objPRReq.SLToDate + "',105))  and LeaveCategory='" + objPRReq.LeaveCategory + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp AddProjectStaff_CLs(PRReq objPRReq)
        {
            string insert = "insert into PR_tbl_ProjectStaff_CLs (OID,EGID,EmpGroup,DID,DeptID,DSID,Design,AttendanceID,EmpID,Name,Photo,Year,StartDate,EndDate,CL,SL,BasicPay,GrossSal,HEmpID,HName,Status,Dated) values('" + objPRReq.OID + "','" + objPRReq.EGID + "','" + objPRReq.EmpGroup + "','" + objPRReq.DID + "','" + objPRReq.DeptID + "','" + objPRReq.DSID + "','" + objPRReq.Design + "','" + objPRReq.AttendanceID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.Photo + "','" + objPRReq.Year + "','" + objPRReq.StartDate + "','" + objPRReq.EndDate + "','" + objPRReq.CL + "','" + objPRReq.SL + "','" + objPRReq.BasicPay + "','" + objPRReq.BasicPay + "','" + objPRReq.HEmpID + "','" + objPRReq.HName + "','" + objPRReq.Status + "','" + objPRReq.Dated + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp UpdaetPSEmpSL_tbl_EmpLeaves_Admin(PRReq objPRReq)
        {
            string update = "update PR_tbl_ProjectStaff_CLs set DID='" + objPRReq.DID + "',DeptID='" + objPRReq.DeptID + "', DSID='" + objPRReq.DSID + "',Design='" + objPRReq.Design + "', StartDate='" + objPRReq.StartDate + "', EndDate='" + objPRReq.EndDate + "', CL='" + objPRReq.CL + "', SL='" + objPRReq.SL + "', BasicPay='" + objPRReq.BasicPay + "', GrossSal='" + objPRReq.BasicPay + "', Year='" + objPRReq.Year + "' where EmpID='" + objPRReq.EmpID + "' and Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp Add_LT_SMSAlert(PRReq objPRReq)
        {
            string insert = "insert into tbl_LT_SMS_Alert (OID,EmpID,Name,Mobile,Dated,Status,SentTime) values('" + objPRReq.OID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.Mobile + "','" + objPRReq.Dates + "','" + objPRReq.Status + "','" + DateTime.Now + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getLT_SMSAlert(PRReq objPRReq)
        {
            string s = "select * from tbl_LT_SMS_Alert where EmpID='" + objPRReq.EmpID + "' and OID='" + objPRReq.OID + "' and Mobile='" + objPRReq.Mobile + "' and Dated='" + objPRReq.Dates + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getProjectStaff_CLs(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_ProjectStaff_CLs where EmpID='" + objPRReq.EmpID + "' and OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and Year='" + objPRReq.Year + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp getProjectStaff_CLsforEdit(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_ProjectStaff_CLs where HEmpID='" + objPRReq.HEmpID + "' and EmpID='" + objPRReq.EmpID + "' and OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and Year='" + objPRReq.Year + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getProjectStaff_CLs_HEmpID(PRReq objPRReq)
        {
            string s = "select distinct * from PR_tbl_ProjectStaff_CLs where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and HEmpID='" + objPRReq.HEmpID + "' and Year='" + DateTime.Now.Year + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getProjectStaff_CLs_HEmpID_Year(PRReq objPRReq)
        {
            string s = "select distinct * from PR_tbl_ProjectStaff_CLs where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' and Year='" + objPRReq.Year + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getProjectStaff__HEmpID(PRReq objPRReq)
        {
            string s = "select distinct * from PR_tbl_ProjectStaff where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and Flag1='1' and HEmpID='" + objPRReq.HEmpID + "' order by EmpID Asc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getProjectStaff_CLs_Year(PRReq objPRReq)
        {
            string s = "select distinct * from PR_tbl_ProjectStaff_CLs where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and Year='" + objPRReq.Year + "' and HEmpID='" + objPRReq.HEmpID + "' order by EmpID Asc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getProjectStaff_CLs_Year_EmpID(PRReq objPRReq)
        {
            string s = "select distinct * from PR_tbl_ProjectStaff_CLs where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and Year='" + objPRReq.Year + "' and EmpID='" + objPRReq.EmpID + "' and HEmpID='" + objPRReq.HEmpID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp UpdateProjStaff_CLs_ByEmpID(PRReq objPRReq)
        {
            string update = "update PR_tbl_ProjectStaff_CLs set DID='" + objPRReq.DID + "',DeptID='" + objPRReq.DeptID + "',DSID='" + objPRReq.DSID + "',Design='" + objPRReq.Design + "',CL='" + objPRReq.CL + "',SL='" + objPRReq.SL + "' where OID='" + objPRReq.OID + "' and  EmpID='" + objPRReq.EmpID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp UpdateProjStaff_ApprovedCLs_ByEmpID(PRReq objPRReq)
        {
            string update = "update PR_tbl_ProjectStaff_CLs set CL='" + objPRReq.SLNoofDays + "' where OID='" + objPRReq.OID + "' and  EmpID='" + objPRReq.EmpID + "' and Status='" + objPRReq.Status + "' and Year='" + objPRReq.Year + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp UpdateProjStaff_ApprovedSLs_ByEmpID(PRReq objPRReq)
        {
            string update = "update PR_tbl_ProjectStaff_CLs set SL='" + objPRReq.SLNoofDays + "' where OID='" + objPRReq.OID + "' and  EmpID='" + objPRReq.EmpID + "' and Status='" + objPRReq.Status + "' and Year='" + objPRReq.Year + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp DelProjStaff_CLs_ByPSTID(PRReq objPRReq)
        {
            string hod = "delete from PR_tbl_ProjectStaff_CLs where PSTID='" + objPRReq.PSTID + "' and OID='" + objPRReq.OID + "' and HEmpID='" + objPRReq.HEmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }




        public PRResp AddProjectStaffExcel(PRReq objPRReq)
        {
            string insert = "insert into PR_tbl_ProjectStaff (SNo,OID,EGID,EmpGroup,PSID,PayScale,EmpID,Name,Password,Mobile,Photo,Status,Role,UID,UName,Dated) values('" + objPRReq.SNO + "','" + objPRReq.OID + "','" + objPRReq.EGID + "','" + objPRReq.EmpGroup + "','" + objPRReq.PSID + "','" + objPRReq.Payscale + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.Password + "','" + objPRReq.Mobile + "','" + objPRReq.Photo + "','" + objPRReq.Status + "','" + objPRReq.Role + "','" + objPRReq.UEmpID + "','" + objPRReq.UName + "','" + objPRReq.Dated + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getProjectStaffName(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_ProjectStaff where PAN='" + objPRReq.PAN + "' and EmpID='" + objPRReq.EmpID + "' and OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllPSCentreHeads(PRReq objPRReq)
        {
            string s = "(select Distinct EmpID,Name from PR_tbl_Employee where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ISHOC='Yes') Union (select Distinct EmpID,Name from PR_tbl_ProjectStaff where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ISHOC='Yes') order by Name Asc ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllCentreHeadsInfo_Exception(PRReq objPRReq)
        {
            string s = "(select Distinct EmpID,Name,Design,DeptID from PR_tbl_Employee where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ISHOC='Yes' and EmpID!='772') Union (select Distinct EmpID,Name,Design,DeptID from PR_tbl_ProjectStaff where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ISHOC='Yes') order by Name Asc  ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllCentreHeadsInfo_StoreIndent(PRReq objPRReq)
        {
            string s = "(select Distinct EmpID,Name,Design,DeptID from PR_tbl_Employee where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ISHOC='Yes' and EmpID!='731') Union (select Distinct EmpID,Name,Design,DeptID from PR_tbl_ProjectStaff where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ISHOC='Yes') order by Name Asc ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllCentreHeadsInfo(PRReq objPRReq)
        {
            string s = "(select Distinct EmpID,Name,Design,DeptID from PR_tbl_Employee where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ISHOC='Yes') Union (select Distinct EmpID,Name,Design,DeptID from PR_tbl_ProjectStaff where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ISHOC='Yes')  ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpInfo_OEmpID(PRReq objPRReq)
        {
            string s = "(select Distinct EmpID,Name,Design,DeptID,Photo from PR_tbl_Employee where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.OEmpID + "') Union (select Distinct EmpID,Name,Design,DeptID,Photo from PR_tbl_ProjectStaff where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.OEmpID + "')  ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpInfo_EmpID(PRReq objPRReq)
        {
            string s = "(select Distinct EmpID,Name,Design,DeptID,Photo from PR_tbl_Employee where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "') Union (select Distinct EmpID,Name,Design,DeptID,Photo from PR_tbl_ProjectStaff where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "')  ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllCentreHeadsInfo_Search(PRReq objPRReq)
        {
            string s = "(select Distinct EmpID,Name,Design,DeptID from PR_tbl_Employee where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ISHOC='Yes' and Name like '%" + objPRReq.Name + "%') Union (select Distinct EmpID,Name,Design,DeptID from PR_tbl_ProjectStaff where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ISHOC='Yes' and Name like '%" + objPRReq.Name + "%')  ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllOHeadsInfo_SearchforSMS(PRReq objPRReq)
        {
            string s = "(select Distinct EmpID,Name,Design,DeptID,Mobile,Email from PR_tbl_Employee where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.OEmpID + "') Union (select Distinct EmpID,Name,Design,DeptID,Mobile,Email from PR_tbl_ProjectStaff where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.OEmpID + "')  ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllProjCoordnators(PRReq objPRReq)
        {
            string s = "(select Distinct EmpID,Name,Design,DeptID from PR_tbl_Employee where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ECID!='4' and ECID!='5') Union (select Distinct EmpID,Name,Design,DeptID from PR_tbl_ProjectStaff where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "')  ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllProjCoordnators_Search(PRReq objPRReq)
        {
            string s = "(select Distinct EmpID,Name,Design,DeptID from PR_tbl_Employee where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ECID!='4' and ECID!='5' and Name like '%" + objPRReq.Name + "%') Union (select Distinct EmpID,Name,Design,DeptID from PR_tbl_ProjectStaff where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ISHOC='Yes' and Name like '%" + objPRReq.Name + "%')  ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllStaffNames_Regular_PS_EmpID(PRReq objPRReq)
        {
            string s = "(select Distinct EmpID,Name,DID,DeptID,Email,Design,Mobile from PR_tbl_Employee where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "') Union (select Distinct EmpID,Name,DID,DeptID,Email,Design,Mobile from PR_tbl_ProjectStaff where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "') ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp SearchAllStaffNames_Regular_PS(PRReq objPRReq)
        {
            string s = "(select Distinct EmpID,Name from PR_tbl_Employee where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and (Name like '%" + objPRReq.Name + "%') or (EmpID like '%" + objPRReq.Name + "%')) Union (select Distinct EmpID,Name from PR_tbl_ProjectStaff where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and (Name like '%" + objPRReq.Name + "%')or(EmpID like '%" + objPRReq.Name + "%')) ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp SearchAllNames_Regular_PS(PRReq objPRReq)
        {
            string s = "(select Distinct EmpID,Name,DID,DeptID,Email,Design,Mobile from PR_tbl_Employee where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and Name like '%" + objPRReq.Name + "%') Union (select Distinct EmpID,Name,DID,DeptID,Email,Design,Mobile from PR_tbl_ProjectStaff where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and Name like '%" + objPRReq.Name + "%') ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllStaffNames_Regular_PS(PRReq objPRReq)
        {
            string s = "(select Distinct EmpID,Name,[Name]+' - '+CAST( EmpID as nvarchar(50)) as Data from PR_tbl_Employee where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "') Union (select Distinct EmpID,Name,[Name]+' - '+CAST( EmpID as nvarchar(50)) as Data from PR_tbl_ProjectStaff where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "') ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllStaffContacts(PRReq objPRReq)
        {
            string s = "(select distinct EmpID,EGID,Name,Design,DeptID,Mobile,Intercom,Block,Floor,RoomNo,Photo,Email from PR_tbl_Employee  where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "')union(select distinct EmpID,EGID,Name,Design,DeptID,Mobile,Intercom,Block,Floor,RoomNo,Photo,Email from PR_tbl_ProjectStaff  where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "') order by EGID,DeptID,Name Asc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp UpdateProjStaffByEmpID(PRReq objPRReq)
        {
            string update = "update PR_tbl_ProjectStaff set Flag1='" + objPRReq.Flag1 + "',FDOJ='" + objPRReq.StartDate + "',EDate='" + objPRReq.EndDate + "', DID='" + objPRReq.DID + "',DeptID='" + objPRReq.DeptID + "',DSID='" + objPRReq.DSID + "',Design='" + objPRReq.Design + "',Email='" + objPRReq.Email + "',Aadhar='" + objPRReq.Aadhar + "', DOR='" + objPRReq.EndDate + "',Gender='" + objPRReq.Gender + "',PAN='" + objPRReq.PAN + "',BankAcType='" + objPRReq.BankAcType + "',BankName='" + objPRReq.BankName + "',BankBranch='" + objPRReq.BankBranchName + "',BankAccNo='" + objPRReq.BankAccountNumber + "',IFSCCode='" + objPRReq.IFSCCode + "',Photo='" + objPRReq.Photo + "',ProjectTitle='" + objPRReq.ProjectTitle + "',ProjectCoordinator='" + objPRReq.ProjectCoordinator + "',HEmpID='" + objPRReq.HEmpID + "',	CentreHead='" + objPRReq.CentreHead + "',	DOB='" + objPRReq.DOB + "',	StartDate='" + objPRReq.StartDate + "',EndDate='" + objPRReq.EndDate + "',BasicPay='" + objPRReq.BasicPay + "',GrossSal='" + objPRReq.GrossSal + "',QuarterAllotted='" + objPRReq.QuarterAllotted + "',QuarterType='" + objPRReq.QuarterType + "',QuarterNo='" + objPRReq.QuarterNumber + "',OfficeOrderNo='" + objPRReq.OffOrderNo + "',OfficeOrderDate='" + objPRReq.OffOrderDate + "',OOIssuingAuthority='" + objPRReq.OffOrderIssuingAuthority + "',AppointmentOrder='" + objPRReq.OfferLetter + "' where OID='" + objPRReq.OID + "' and  EmpID='" + objPRReq.EmpID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp getPS_EMPID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_ProjectStaff where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getPSEmpByEID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_ProjectStaff where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and PSTID='" + objPRReq.PSTID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getPSbyUID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_ProjectStaff where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' order by EmpID Asc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllPSbyUID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_ProjectStaff where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' order by Name Asc ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllPSbyEmpID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_ProjectStaff where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getPSbyUID_DID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_ProjectStaff where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and UID='" + objPRReq.UID + "' and DID='" + objPRReq.DID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getPSbyUID_EDate(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_ProjectStaff where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and UID='" + objPRReq.UID + "' and EDate>='" + objPRReq.Now + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getPSbyUIDbyValidDate(PRReq objPRReq)
        {
            string s = "select distinct * from PR_tbl_PS_NewSal where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and UID='" + objPRReq.UID + "' and DID='" + objPRReq.DID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp getPSbyUID_DID_Calc(PRReq objPRReq)
        {
            string s = "select distinct * from PR_tbl_PS_NewSal where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and UID='" + objPRReq.UID + "' and DID='" + objPRReq.DID + "' and PSTID='" + objPRReq.PSTID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllPS_NewSalbyUIDAutoCal(PRReq objPRReq)
        {
            string s = "select distinct * from PR_tbl_PS_NewSal where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and UID='" + objPRReq.UID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getPSByEmpID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_ProjectStaff where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getPSSNo(PRReq objPRReq)
        {
            string s = "select max(" + objPRReq.ColumnName + ") from PR_tbl_ProjectStaff where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.SingleValue = Connections.GetSingleValue(s);
            return objPRResp;
        }
        public PRResp EditProjStaffByPSTID(PRReq objPRReq)
        {
            string update = "update PR_tbl_ProjectStaff set CitizenType='" + objPRReq.CitizenType + "', OID='" + objPRReq.OID + "',PSID='" + objPRReq.PSID + "',PayScale='" + objPRReq.Payscale + "',ECID='" + objPRReq.ECID + "',EmpCategory='" + objPRReq.EmpCategory + "',DID='" + objPRReq.DID + "',DeptID='" + objPRReq.DeptID + "',DSID='" + objPRReq.DSID + "',Design='" + objPRReq.Design + "',EmpID='" + objPRReq.EmpID + "',Name='" + objPRReq.Name + "',Email='" + objPRReq.Email + "',Mobile='" + objPRReq.Mobile + "',Aadhar='" + objPRReq.Aadhar + "',OfficeOrderNo='" + objPRReq.OffOrderNo + "',OfficeOrderDate='" + objPRReq.OffOrderDate + "',OOIssuingAuthority='" + objPRReq.OffOrderIssuingAuthority + "', DOJ='" + objPRReq.DOJ + "',Gender='" + objPRReq.Gender + "',PAN='" + objPRReq.PAN + "',BankAcType='" + objPRReq.BankAcType + "',BankName='" + objPRReq.BankName + "',BankBranch='" + objPRReq.BankBranchName + "',BankAccNo='" + objPRReq.BankAccNo + "',IFSCCode='" + objPRReq.IFSCCode + "',DOR='" + objPRReq.DOR + "',BasicPay='" + objPRReq.BasicPay + "', PID='" + objPRReq.PID + "', ProjectCode='" + objPRReq.ProjectCode + "', ProjectTitle='" + objPRReq.ProjectTitle + "', ProjectCoordinator='" + objPRReq.ProjectCoordinator + "', CentreHead='" + objPRReq.CentreHead + "', GrossSal='" + objPRReq.GrossSal + "', QuarterAllotted='" + objPRReq.QuarterAllotted + "', QuarterType='" + objPRReq.QuarterType + "', Photo='" + objPRReq.Photo + "',UID='" + objPRReq.UID + "',UName='" + objPRReq.UName + "',Dated='" + objPRReq.Dated + "',FDOJ='" + objPRReq.FDOJ + "', EDate='" + objPRReq.EDate + "' where OID='" + objPRReq.OID + "' and PSTID='" + objPRReq.PSTID + "' and EmpID='" + objPRReq.EmpID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp DelProjStaffByPSTID(PRReq objPRReq)
        {
            string hod = "delete from PR_tbl_ProjectStaff where   where PSTID='" + objPRReq.PSTID + "' and OID='" + objPRReq.OID + "' and UID='" + objPRReq.UID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }
        public PRResp BlockProjStaffByPSTID(PRReq objPRReq)
        {
            string update = "update PR_tbl_ProjectStaff set Status='" + objPRReq.Status + "' where PSTID='" + objPRReq.PSTID + "' and OID='" + objPRReq.OID + "' and UID='" + objPRReq.UID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp UpDatePSMonthlySalary(PRReq objPRReq)
        {
            string update = "update PR_tbl_PS_NewSal set UID='" + objPRReq.UID + "',UName='" + objPRReq.UName + "',Dated='" + objPRReq.Dated + "',Arrears='" + objPRReq.Arrears + "', ProfessionTax='" + objPRReq.ProfTax + "', IncomeTax='" + objPRReq.IncomeTax + "',LicenceFee='" + objPRReq.LicenceFee + "',WaterCharges='" + objPRReq.WaterCharges + "',ElectricityCharges='" + objPRReq.ElectricityCharges + "',GarbageCharges='" + objPRReq.GarbageCharges + "',GarriageCharges='" + objPRReq.GarageCharges + "',TARecovery='" + objPRReq.TARecovery + "',Others='" + objPRReq.OtherDeductions + "',CGrossSal='" + objPRReq.GradePay + "',TDeducations='" + objPRReq.TotDeductions + "',NetSalary='" + objPRReq.NetPay + "', TotalDays='" + objPRReq.TotDays + "', LOPDays='" + objPRReq.LopDays + "', LOPAmount='" + objPRReq.LopAmount + "',NetSalInWords='" + objPRReq.GrossSalWords + "', Flag1='" + objPRReq.Flag1 + "' where OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        // PS new Sal
        public PRResp getPSByEmpID_UID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_PS_NewSal where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp AddPS_NewSal(PRReq objPRReq)
        {
            string insert = "INSERT INTO PR_tbl_PS_NewSal (Month,Year,SNo,OID,ECID,EmpCategory,PSID,PayScale,DID,DeptID,DSID,Design,EmpID,Name,Email,Mobile,Aadhar,DOJ,DOR,Gender,PAN,BankAcType,BankName,BankBranch,BankAccNo,IFSCCode,Photo,PID,ProjectCode,ProjectTitle,ProjectCoordinator,CentreHead,StartDate,EndDate,BasicPay,GrossSal,QuarterAllotted,QuarterType,OfficeOrderNo,OfficeOrderDate,OOIssuingAuthority,Status,UID,UName,Dated,FDOJ,EDate,Flag1,CitizenType) values('" + objPRReq.Month + "','" + objPRReq.Year + "','" + objPRReq.SNO + "','" + objPRReq.OID + "','" + objPRReq.ECID + "','" + objPRReq.EmpCategory + "','" + objPRReq.PSID + "','" + objPRReq.Payscale + "','" + objPRReq.DID + "','" + objPRReq.DeptID + "','" + objPRReq.DSID + "','" + objPRReq.Design + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.Email + "','" + objPRReq.Mobile + "','" + objPRReq.Aadhar + "','" + objPRReq.DOJ + "','" + objPRReq.DOR + "','" + objPRReq.Gender + "','" + objPRReq.PAN + "','" + objPRReq.BankAcType + "','" + objPRReq.BankName + "','" + objPRReq.BankBranchName + "','" + objPRReq.BankAccNo + "','" + objPRReq.IFSCCode + "','" + objPRReq.Photo + "','" + objPRReq.PID + "','" + objPRReq.ProjectCode + "','" + objPRReq.ProjectTitle + "','" + objPRReq.ProjectCoordinator + "','" + objPRReq.CentreHead + "','" + objPRReq.StartDate + "','" + objPRReq.EndDate + "','" + objPRReq.BasicPay + "','" + objPRReq.GrossSal + "','" + objPRReq.QuarterAllotted + "','" + objPRReq.QuarterType + "','" + objPRReq.OffOrderNo + "','" + objPRReq.OffOrderDate + "','" + objPRReq.OffOrderIssuingAuthority + "','" + objPRReq.Status + "','" + objPRReq.UID + "','" + objPRReq.UName + "','" + objPRReq.Dated + "','" + objPRReq.FDOJ + "','" + objPRReq.EDate + "','" + objPRReq.Flag1 + "','" + objPRReq.CitizenType + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp TruncatePR_tbl_PS_NewSal()
        {
            string s = "truncate table PR_tbl_PS_NewSal  ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getPSByEmpID_NewSal(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_PS_NewSal where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getPSNewSalbyUID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_PS_NewSal where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and UID='" + objPRReq.UID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getPSNewSalbyUID_DID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_PS_NewSal where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and UID='" + objPRReq.UID + "' and DID='" + objPRReq.DID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getPSEmpCountByProjectCode(PRReq objPRReq)
        {
            string s = "select count(ProjectCode) as pc from PR_tbl_PS_NewSal where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and UID='" + objPRReq.UID + "' and Projectcode='" + objPRReq.ProjectCode + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getPSEmpSumNetPayByProjectCode(PRReq objPRReq)
        {
            string s = "select sum(NetSalary) as snetPay from PR_tbl_PS_NewSal where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and UID='" + objPRReq.UID + "' and Projectcode='" + objPRReq.ProjectCode + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getPSByEmpID_NewSal_UID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_PS_NewSal where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and UID='" + objPRReq.UID + "' order by DeptID,PID ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getPSByEmpID_NewSals_UID(PRReq objPRReq)
        {
            string s = "select distinct PID,ProjectCode,ProjectTitle,Month,Year,UName,UID from PR_tbl_PS_NewSal where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and UID='" + objPRReq.UID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getPSByEmpID_NewSalsTotal_UID(PRReq objPRReq)
        {
            string s = "select sum(NetSalary) as TotNetPay from PR_tbl_PS_NewSal where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and UID='" + objPRReq.UID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getPSByEmpID_NewSal_UID_SBH(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_PS_NewSal where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and UID='" + objPRReq.UID + "' and BankName='" + objPRReq.BankName + "' order by DeptID,PID ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getPSByEmpID_NewSal_UID_RTGS(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_PS_NewSal where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and UID='" + objPRReq.UID + "' and BankName!='" + objPRReq.BankName + "' order by DeptID,PID ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp BackupNewSal(PRReq objPRReq)
        {
            string s = "INSERT INTO PR_tbl_PS_BackupSal SELECT * FROM PR_tbl_PS_NewSal where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and UID='" + objPRReq.UID + "' and EmpID='" + objPRReq.EmpID + "' and Month='" + objPRReq.Month + "' and Year='" + objPRReq.Year + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp GetAllBackupNewSal(PRReq objPRReq)
        {
            string s = "SELECT * FROM PR_tbl_PS_BackupSal where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and UID='" + objPRReq.UID + "' and Month='" + objPRReq.Month + "' and Year='" + objPRReq.Year + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp DeleteFromNewSal_UID(PRReq objPRReq)
        {
            string s = "delete FROM PR_tbl_PS_NewSal where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and UID='" + objPRReq.UID + "' and Month='" + objPRReq.Month + "' and Year='" + objPRReq.Year + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp getTempEmailFromNIRDServer_EmpID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_TempEmpID where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp getPSVocherSNo(PRReq objPRReq)
        {
            string s = "select max(" + objPRReq.ColumnName + ") from PR_tbl_PS_Vochers where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.SingleValue = Connections.GetSingleValue(s);
            return objPRResp;
        }
        public PRResp getPSByEmpID_NewSal_UID_VoucherID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_PS_Vochers where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and UID='" + objPRReq.UID + "' and VoucherID='" + objPRReq.VoucherID + "' order by ProjectCode ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getPSBankStment_VoucherID(PRReq objPRReq)
        {
            string s = "select Month,Year,EmpID,Name,BankName,BankBranch,IFSCCode,BankAccNo,NetSalary from PR_tbl_PS_Vochers where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and UID='" + objPRReq.UID + "' and VoucherID='" + objPRReq.VoucherID + "' order by ProjectCode ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        // New Monthly Vouchers
        public PRResp AddPS_NewSalVoucher(PRReq objPRReq)
        {
            string insert = "INSERT INTO PR_tbl_PS_Vochers(SNo,OID,VoucherID,ECID,EmpCategory,PSID,PayScale,DID,DeptID,DSID,Design,EmpID,Name,Email,Mobile,Aadhar,DOJ,DOR,Gender,PAN,BankAcType,BankName,BankBranch,BankAccNo,IFSCCode,Photo,PID,ProjectCode,ProjectTitle,ProjectCoordinator,CentreHead,StartDate,EndDate,BasicPay,GrossSal,QuarterAllotted,QuarterType,OfficeOrderNo,OfficeOrderDate,OOIssuingAuthority,Status,UID,UName,Dated,Month,Year,Arrears,ProfessionTax,IncomeTax,LicenceFee,WaterCharges,ElectricityCharges,GarbageCharges,GarriageCharges,TARecovery,Others,TotalDays,LOPDays,LOPAmount,CGrossSal,TDeducations,NetSalary,NetSalInWords,VNetSalary,VNetSalInWords,Flag1) values('" + objPRReq.SNO + "','" + objPRReq.OID + "','" + objPRReq.VoucherID + "','" + objPRReq.ECID + "','" + objPRReq.EmpCategory + "','" + objPRReq.PSID + "','" + objPRReq.Payscale + "','" + objPRReq.DID + "','" + objPRReq.DeptID + "','" + objPRReq.DSID + "','" + objPRReq.Design + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.Email + "','" + objPRReq.Mobile + "','" + objPRReq.Aadhar + "','" + objPRReq.DOJ + "','" + objPRReq.DOR + "','" + objPRReq.Gender + "','" + objPRReq.PAN + "','" + objPRReq.BankAcType + "','" + objPRReq.BankName + "','" + objPRReq.BankBranchName + "','" + objPRReq.BankAccNo + "','" + objPRReq.IFSCCode + "','" + objPRReq.Photo + "','" + objPRReq.PID + "','" + objPRReq.ProjectCode + "','" + objPRReq.ProjectTitle + "','" + objPRReq.ProjectCoordinator + "','" + objPRReq.CentreHead + "','" + objPRReq.StartDate + "','" + objPRReq.EndDate + "','" + objPRReq.BasicPay + "','" + objPRReq.GrossSal + "','" + objPRReq.QuarterAllotted + "','" + objPRReq.QuarterType + "','" + objPRReq.OffOrderNo + "','" + objPRReq.OffOrderDate + "','" + objPRReq.OffOrderIssuingAuthority + "','" + objPRReq.Status + "','" + objPRReq.UID + "','" + objPRReq.UName + "','" + objPRReq.Dated + "','" + objPRReq.Month + "','" + objPRReq.Year + "','" + objPRReq.Arrears + "','" + objPRReq.ProfTax + "','" + objPRReq.IncomeTax + "','" + objPRReq.LicenceFee + "','" + objPRReq.WaterCharges + "','" + objPRReq.ElectricityCharges + "','" + objPRReq.GarbageCharges + "','" + objPRReq.GarageCharges + "','" + objPRReq.TARecovery + "','" + objPRReq.OtherDeductions + "','" + objPRReq.TotDays + "','" + objPRReq.LopDays + "','" + objPRReq.LopAmount + "','" + objPRReq.GrossSal + "','" + objPRReq.TotDeductions + "','" + objPRReq.NetPay + "','" + objPRReq.GrossSalWords + "','" + objPRReq.VNetSal + "','" + objPRReq.VNetSalInWords + "','" + objPRReq.Flag1 + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getPSNewSalbyUID_Voucher(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_PS_Vochers where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and UID='" + objPRReq.UID + "' and EmpID='" + objPRReq.EmpID + "' and Month='" + objPRReq.Month + "' and Year='" + objPRReq.Year + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getVoucherbyUID_VoucherID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_PS_Vochers where OID='" + objPRReq.OID + "' and UID='" + objPRReq.UID + "' and VoucherID='" + objPRReq.VoucherID + "' and Flag1='" + objPRReq.Flag1 + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp SaveVoucherDataPermanently(PRReq objPRReq)
        {
            string update = "update PR_tbl_PS_Vochers set ChequeNo='" + objPRReq.ChequeNo + "', ChequeDate='" + objPRReq.ChequeDate + "',PrimaryUnit='" + objPRReq.PrimaryUnit + "', SecondaryUnit='" + objPRReq.SecondaryUnit + "',AmountPayable='" + objPRReq.AmountPayable + "',UDated='" + objPRReq.Udated + "', Flag1='" + objPRReq.Flag1 + "'  where OID='" + objPRReq.OID + "' and UID='" + objPRReq.UID + "' and VoucherID='" + objPRReq.VoucherID + "' and Flag1='0' and Status='" + objPRReq.Status + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp getSumNetSal_VocherID(PRReq objPRReq)
        {
            string s = "select sum(NetSalary) as nsal from PR_tbl_PS_Vochers where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and UID='" + objPRReq.UID + "' and VoucherID='" + objPRReq.VoucherID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp updateVoucherTNetSalay(PRReq objPRReq)
        {
            string update = "update PR_tbl_PS_Vochers set VNetSalary='" + objPRReq.VNetSal + "',VNetSalInWords='" + objPRReq.VNetSalInWords + "' where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and UID='" + objPRReq.UID + "' and VoucherID='" + objPRReq.VoucherID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp getAllVouhcers_UID(PRReq objPRReq)
        {
            string s = "select distinct VoucherID,Dated,Month,Year,VNetSalary from PR_tbl_PS_Vochers where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and UID='" + objPRReq.UID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp getVoucherDetails_VoucherID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_PS_Vochers where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and UID='" + objPRReq.UID + "' and VoucherID='" + objPRReq.VoucherID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getProjectcodes_VoucherID(PRReq objPRReq)
        {
            string s = "select distinct ProjectCode from PR_tbl_PS_Vochers where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and UID='" + objPRReq.UID + "' and VoucherID='" + objPRReq.VoucherID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        // Add Employee Master Salary
        public PRResp AddEmpMasterSal(PRReq objPRReq)
        {
            string insert = "insert into PR_tbl_Employee_Master_Salary (EID,OID,ETID,EmpType,ECID,EmpCategory,EGID,EmpGroup,DID,DeptID,DSID,Design,EmpID,Name,Email,Mobile,Aadhar,DOB,DOJ,DOR,Gender,PAN,BankAcType,BankName,BankBranch,BankAccNo,IFSCCode,Photo,PSID,PayScale,PPB,GRP,BasicPay,PayLevel,DA,TRAEligible,TRA,TRGEligible,TRGA,NPAEligible,NPA,PFAccType,PFAccNo,PHCStatus,QuarterAllotted,RentFreeAccom,HRA,OTPay,SpecialDutyAllowances,PatientCareAllowances,BookAllowances,SCA,WashingAllowances,DPAType,DPA,SumptuaryAllowances,OtherAllowances,Arrears,StaffBus,GrossPay,GrossPayWords,Status,UID,UName,Dated) values('" + objPRReq.EID + "','" + objPRReq.OID + "','" + objPRReq.ETID + "','" + objPRReq.EmpType + "','" + objPRReq.ECID + "','" + objPRReq.EmpCategory + "','" + objPRReq.EGID + "','" + objPRReq.EmpGroup + "','" + objPRReq.DID + "','" + objPRReq.DeptID + "','" + objPRReq.DSID + "','" + objPRReq.Design + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.Email + "','" + objPRReq.Mobile + "','" + objPRReq.Aadhar + "','" + objPRReq.DOB + "','" + objPRReq.DOJ + "','" + objPRReq.DOR + "','" + objPRReq.Gender + "','" + objPRReq.PAN + "','" + objPRReq.BankAcType + "','" + objPRReq.BankName + "','" + objPRReq.BankBranchName + "','" + objPRReq.BankAccNo + "','" + objPRReq.IFSCCode + "','" + objPRReq.Photo + "','" + objPRReq.PSID + "','" + objPRReq.Payscale + "','" + objPRReq.PPB + "','" + objPRReq.GradePay + "','" + objPRReq.BasicPay + "','" + objPRReq.PayLevel + "','" + objPRReq.DA + "','" + objPRReq.TRAEligible + "','" + objPRReq.TRA + "','" + objPRReq.TRGEligible + "','" + objPRReq.TRGA + "','" + objPRReq.NPAEligible + "','" + objPRReq.NPA + "','" + objPRReq.PFAccType + "','" + objPRReq.PFAccNo + "','" + objPRReq.PHCStatus + "','" + objPRReq.QuarterAllotted + "','" + objPRReq.RentFreeAccom + "','" + objPRReq.HRA + "','" + objPRReq.OTPay + "','" + objPRReq.SpecialDutyAllow + "','" + objPRReq.PatientCareAllow + "','" + objPRReq.BookAllow + "','" + objPRReq.SCA + "','" + objPRReq.WashingAllow + "','" + objPRReq.DPAType + "','" + objPRReq.DPA + "','" + objPRReq.SumptuaryAllow + "','" + objPRReq.OtherAllow + "','" + objPRReq.Arrears + "','" + objPRReq.StaffBus + "','" + objPRReq.GrossSal + "','" + objPRReq.GrossSalWords + "','" + objPRReq.Status + "','" + objPRReq.UID + "','" + objPRReq.UName + "','" + objPRReq.Dated + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp updateEmpMonthlySalay(PRReq objPRReq)
        {
            string update = "update PR_tbl_Employee_Monthly_Salary set ETID='" + objPRReq.ETID + "',EmpType='" + objPRReq.EmpType + "',ECID='" + objPRReq.ECID + "',EmpCategory='" + objPRReq.EmpCategory + "',EGID='" + objPRReq.EGID + "',EmpGroup='" + objPRReq.EmpGroup + "',BankAccNo='" + objPRReq.BankAccNo + "',IFSCCode='" + objPRReq.IFSCCode + "',PSID='" + objPRReq.PSID + "',PayScale='" + objPRReq.Payscale + "',PPB='" + objPRReq.PPB + "',GRP='" + objPRReq.GradePay + "',BasicPay='" + objPRReq.BasicPay + "',PayLevel='" + objPRReq.PayLevel + "',DA='" + objPRReq.DA + "',TRAEligible='" + objPRReq.TRAEligible + "',TRA='" + objPRReq.TRA + "',TRGEligible='" + objPRReq.TRGEligible + "',TRGA='" + objPRReq.TRGA + "',NPAEligible='" + objPRReq.NPAEligible + "',NPA='" + objPRReq.NPA + "',PFAccType='" + objPRReq.PFAccType + "',PFAccNo='" + objPRReq.PFAccNo + "',PHCStatus='" + objPRReq.PHCStatus + "',QuarterAllotted='" + objPRReq.QuarterAllotted + "',RentFreeAccom='" + objPRReq.RentFreeAccom + "',HRA='" + objPRReq.HRA + "',OTPay='" + objPRReq.OTPay + "',SpecialDutyAllowances='" + objPRReq.SpecialDutyAllow + "',PatientCareAllowances='" + objPRReq.PatientCareAllow + "',BookAllowances='" + objPRReq.BookAllow + "',SCA='" + objPRReq.SCA + "',WashingAllowances='" + objPRReq.WashingAllow + "',DPAType='" + objPRReq.DPAType + "',DPA='" + objPRReq.DPA + "',SumptuaryAllowances='" + objPRReq.SumptuaryAllow + "',OtherAllowances='" + objPRReq.OtherAllow + "',Arrears='" + objPRReq.Arrears + "',StaffBus='" + objPRReq.StaffBus + "',GrossPay='" + objPRReq.GrossSal + "',GrossPayWords='" + objPRReq.GrossSalWords + "',Status='" + objPRReq.Status + "',UID='" + objPRReq.UID + "',UName='" + objPRReq.UName + "',Dated='" + objPRReq.Dated + "' where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and EID='" + objPRReq.EID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp updateEmpNewSalay(PRReq objPRReq)
        {
            string update = "update PR_tbl_Employee_Master_Salary set ETID='" + objPRReq.ETID + "',EmpType='" + objPRReq.EmpType + "',ECID='" + objPRReq.ECID + "',EmpCategory='" + objPRReq.EmpCategory + "',EGID='" + objPRReq.EGID + "',EmpGroup='" + objPRReq.EmpGroup + "',BankAccNo='" + objPRReq.BankAccNo + "',IFSCCode='" + objPRReq.IFSCCode + "',PSID='" + objPRReq.PSID + "',PayScale='" + objPRReq.Payscale + "',PPB='" + objPRReq.PPB + "',GRP='" + objPRReq.GradePay + "',BasicPay='" + objPRReq.BasicPay + "',PayLevel='" + objPRReq.PayLevel + "',DA='" + objPRReq.DA + "',TRAEligible='" + objPRReq.TRAEligible + "',TRA='" + objPRReq.TRA + "',TRGEligible='" + objPRReq.TRGEligible + "',TRGA='" + objPRReq.TRGA + "',NPAEligible='" + objPRReq.NPAEligible + "',NPA='" + objPRReq.NPA + "',PFAccType='" + objPRReq.PFAccType + "',PFAccNo='" + objPRReq.PFAccNo + "',PHCStatus='" + objPRReq.PHCStatus + "',QuarterAllotted='" + objPRReq.QuarterAllotted + "',RentFreeAccom='" + objPRReq.RentFreeAccom + "',HRA='" + objPRReq.HRA + "',OTPay='" + objPRReq.OTPay + "',SpecialDutyAllowances='" + objPRReq.SpecialDutyAllow + "',PatientCareAllowances='" + objPRReq.PatientCareAllow + "',BookAllowances='" + objPRReq.BookAllow + "',SCA='" + objPRReq.SCA + "',WashingAllowances='" + objPRReq.WashingAllow + "',DPAType='" + objPRReq.DPAType + "',DPA='" + objPRReq.DPA + "',SumptuaryAllowances='" + objPRReq.SumptuaryAllow + "',OtherAllowances='" + objPRReq.OtherAllow + "',Arrears='" + objPRReq.Arrears + "',StaffBus='" + objPRReq.StaffBus + "',GrossPay='" + objPRReq.GrossSal + "',GrossPayWords='" + objPRReq.GrossSalWords + "',Status='" + objPRReq.Status + "',UID='" + objPRReq.UID + "',UName='" + objPRReq.UName + "',Dated='" + objPRReq.Dated + "' where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and EID='" + objPRReq.EID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp updateEmpNewSalayDetailsbyEmpID(PRReq objPRReq)
        {
            string update = "update PR_tbl_Employee_Master_Salary set IFSCCode='" + objPRReq.IFSCCode + "',PFAccType='" + objPRReq.PFAccType + "',PFAccNo='" + objPRReq.PFAccNo + "', Email='" + objPRReq.Email + "', Mobile='" + objPRReq.Mobile + "', Aadhar='" + objPRReq.Aadhar + "', DOB='" + objPRReq.DOB + "', DOJ='" + objPRReq.DOJ + "',DOR='" + objPRReq.DOR + "', PAN='" + objPRReq.PAN + "',BankName='" + objPRReq.BankName + "',BankBranch='" + objPRReq.BankBranchName + "',Photo='" + objPRReq.Photo + "' where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and (EmpID='" + objPRReq.EmpID + "' or EID='" + objPRReq.EID + "') ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp getEmpByName_EmpID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Employee_Master_Salary where PAN='" + objPRReq.PAN + "' and EmpID='" + objPRReq.EmpID + "' and OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpSalbyETID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Employee_Master_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        // Payslips

        public PRResp getEmpPaySlipMonth()
        {
            string s = "select distinct Month from tbl_OLDMonthlyPayBackup ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpPaySlipYear()
        {
            string s = "select distinct Year from tbl_OLDMonthlyPayBackup";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        // Mail Service
        public PRResp getMailServices_OID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_MailService where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        // Store_tbl_Vendor
        public PRResp getVendors(PRReq objPRReq)
        {
            string s = "select * from Store_tbl_Vendor where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp AddVendor(PRReq objPRReq)
        {
            string insert = "insert into Store_tbl_Vendor (OID,Vendor,Email,Phone,Address,DLNo,TIN,Status,UID,UName,Dated) values('" + objPRReq.OID + "','" + objPRReq.Vendor + "','" + objPRReq.Email + "','" + objPRReq.Phone + "','" + objPRReq.Phone + "','" + objPRReq.DLNo + "','" + objPRReq.TIN + "','" + objPRReq.Status + "','" + objPRReq.UID + "','" + objPRReq.UName + "','" + objPRReq.Dated + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getVendorByName(PRReq objPRReq)
        {
            string s = "select * from Store_tbl_Vendor where Vendor='" + objPRReq.Vendor + "' and OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and Email='" + objPRReq.Email + "' and Phone='" + objPRReq.Phone + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getVendorByVID(PRReq objPRReq)
        {
            string s = "select * from Store_tbl_Vendor where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and VID='" + objPRReq.VID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp EditVendorByVID(PRReq objPRReq)
        {
            string update = "update Store_tbl_Vendor set Vendor='" + objPRReq.Vendor + "',Email='" + objPRReq.Email + "',Phone='" + objPRReq.Phone + "',Address='" + objPRReq.Address + "',DLNo='" + objPRReq.DLNo + "',TIN='" + objPRReq.TIN + "',UID='" + objPRReq.UID + "',UName='" + objPRReq.UName + "' where OID='" + objPRReq.OID + "' and VID='" + objPRReq.VID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp DelVendor(PRReq objPRReq)
        {
            string hod = "delete from Store_tbl_Vendor where  OID='" + objPRReq.OID + "' and VID='" + objPRReq.VID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }
        public PRResp VendorSearch(PRReq objPRReq)
        {
            string s = "select * from Store_tbl_Vendor where Vendor like '%" + objPRReq.Vendor + "%' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        // Store_tbl_Category
        public PRResp getItemCategorys(PRReq objPRReq)
        {
            string s = "select * from Store_tbl_ItemCategory where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getItemCategorys_Cost(PRReq objPRReq)
        {
            string s = "select sum(Rate) as cost from Store_tbl_StoreStock where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ICID='" + objPRReq.ICID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp AddItemCategory(PRReq objPRReq)
        {
            string insert = "insert into Store_tbl_ItemCategory (OID,ItemCategory,Status,UID,UName,Dated) values('" + objPRReq.OID + "','" + objPRReq.ItemCategory + "','" + objPRReq.Status + "','" + objPRReq.UID + "','" + objPRReq.UName + "','" + objPRReq.Dated + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getItemCategoryByName(PRReq objPRReq)
        {
            string s = "select * from Store_tbl_ItemCategory where ItemCategory='" + objPRReq.ItemCategory + "' and OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getItemCategoryByICID(PRReq objPRReq)
        {
            string s = "select * from Store_tbl_ItemCategory where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ICID='" + objPRReq.ICID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp EditItemCategoryByICID(PRReq objPRReq)
        {
            string update = "update Store_tbl_ItemCategory set ItemCategory='" + objPRReq.ItemCategory + "',UID='" + objPRReq.UID + "',UName='" + objPRReq.UName + "' where OID='" + objPRReq.OID + "' and ICID='" + objPRReq.ICID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp DelItemCategory(PRReq objPRReq)
        {
            string hod = "delete from Store_tbl_ItemCategory where  OID='" + objPRReq.OID + "' and ICID='" + objPRReq.ICID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }
        public PRResp ItemCategorySearch(PRReq objPRReq)
        {
            string s = "select * from Store_tbl_ItemCategory where ItemCategory like '%" + objPRReq.ItemCategory + "%' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }


        // Store_tbl_Category
        public PRResp getManufacturers(PRReq objPRReq)
        {
            string s = "select * from Store_tbl_Manufacturer where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp AddManufacturer(PRReq objPRReq)
        {
            string insert = "insert into Store_tbl_Manufacturer (OID,Manufacturer,Status,UID,UName,Dated) values('" + objPRReq.OID + "','" + objPRReq.Manufacturer + "','" + objPRReq.Status + "','" + objPRReq.UID + "','" + objPRReq.UName + "','" + objPRReq.Dated + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getManufacturerByName(PRReq objPRReq)
        {
            string s = "select * from Store_tbl_Manufacturer where Manufacturer='" + objPRReq.Manufacturer + "' and OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getManufacturerByIMID(PRReq objPRReq)
        {
            string s = "select * from Store_tbl_Manufacturer where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and IMID='" + objPRReq.IMID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp EditManufacturerByIMID(PRReq objPRReq)
        {
            string update = "update Store_tbl_Manufacturer set Manufacturer='" + objPRReq.Manufacturer + "',UID='" + objPRReq.UID + "',UName='" + objPRReq.UName + "' where OID='" + objPRReq.OID + "' and IMID='" + objPRReq.IMID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp DelManufacturer(PRReq objPRReq)
        {
            string hod = "delete from Store_tbl_Manufacturer where  OID='" + objPRReq.OID + "' and IMID='" + objPRReq.IMID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }
        public PRResp ManufacturerSearch(PRReq objPRReq)
        {
            string s = "select * from Store_tbl_Manufacturer where Manufacturer like '%" + objPRReq.ItemCategory + "%' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getItemsByManufacturer(PRReq objPRReq)
        {
            string s = "select * from Store_tbl_Manufacturer where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and Manufacturer='" + objPRReq.Manufacturer + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        // Store_tbl_ItemName
        public PRResp getItemNames(PRReq objPRReq)
        {
            string s = "select * from Store_tbl_Items where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ICID='" + objPRReq.ICID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp AddItemName(PRReq objPRReq)
        {
            string insert = "insert into Store_tbl_Items (OID,ICID,ItemCategory,ItemName,Status,UID,UName,Dated) values('" + objPRReq.OID + "','" + objPRReq.ICID + "','" + objPRReq.ItemCategory + "','" + objPRReq.ItemName + "','" + objPRReq.Status + "','" + objPRReq.UID + "','" + objPRReq.UName + "','" + objPRReq.Dated + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getItemNameByName(PRReq objPRReq)
        {
            string s = "select * from Store_tbl_Items where ItemName='" + objPRReq.ItemName + "' and ICID='" + objPRReq.ICID + "' and OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getItemNameByITID(PRReq objPRReq)
        {
            string s = "select * from Store_tbl_Items where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ITID='" + objPRReq.ITID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp EditItemNameByITID(PRReq objPRReq)
        {
            string update = "update Store_tbl_Items set ICID='" + objPRReq.ICID + "', ItemCategory='" + objPRReq.ItemCategory + "', ItemName='" + objPRReq.ItemName + "',UID='" + objPRReq.UID + "',UName='" + objPRReq.UName + "' where OID='" + objPRReq.OID + "' and ITID='" + objPRReq.ITID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp DelItemName(PRReq objPRReq)
        {
            string hod = "delete from Store_tbl_Items where  OID='" + objPRReq.OID + "' and ITID='" + objPRReq.ITID + "' and ICID='" + objPRReq.ICID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }
        public PRResp ItemNameSearch(PRReq objPRReq)
        {
            string s = "select * from Store_tbl_Items where ItemName like '%" + objPRReq.ItemName + "%' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getItemsByItemName(PRReq objPRReq)
        {
            string s = "select * from Store_tbl_Items where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ItemName='" + objPRReq.ItemName + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        // Temporarty Stock Entry

        public PRResp AddTStock(PRReq objPRReq)
        {
            string insert = "insert into Store_tbl_TempStock (OID,VID,Vendor,InvoiceNo,InvoiceDate,DLNo,TIN,VEmail,VPhone,ICID,ItemCategory,ITID,ItemName,ItemType,IMID,Manufacturer,PurchaseOrderNo,PurchaseDate,FileNo,BatchNo,Quantity,Rate,UnitCost,MinQty,Status,UID,UName,Dated) values('" + objPRReq.OID + "','" + objPRReq.VID + "','" + objPRReq.Vendor + "','" + objPRReq.InvoiceNo + "','" + objPRReq.InvoiceDate + "','" + objPRReq.DLNo + "','" + objPRReq.TIN + "','" + objPRReq.Email + "','" + objPRReq.Phone + "','" + objPRReq.ICID + "','" + objPRReq.ItemCategory + "','" + objPRReq.ITID + "','" + objPRReq.ItemName + "','" + objPRReq.ItemType + "','" + objPRReq.IMID + "','" + objPRReq.Manufacturer + "','" + objPRReq.PONo + "','" + objPRReq.PurchaseDate + "','" + objPRReq.FileNo + "','" + objPRReq.BatchNo + "','" + objPRReq.Quantity + "','" + objPRReq.Rate + "','" + objPRReq.UnitCost + "','" + objPRReq.MinQty + "','" + objPRReq.Status + "','" + objPRReq.UID + "','" + objPRReq.UName + "','" + objPRReq.Dated + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getTStockByName(PRReq objPRReq)
        {
            string s = "select * from Store_tbl_TempStock where ItemName='" + objPRReq.ItemName + "' and ICID='" + objPRReq.ICID + "' and OID='" + objPRReq.OID + "' and BatchNo='" + objPRReq.BatchNo + "' and ItemName='" + objPRReq.ItemName + "' and UnitCost='" + objPRReq.UnitCost + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getTStockItems(PRReq objPRReq)
        {
            string s = "select * from Store_tbl_TempStock where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and UID='" + objPRReq.UID + "' order by TSID desc ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getTStockItems_UID(PRReq objPRReq)
        {
            string s = "select * from Store_tbl_TempStock where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and UID='" + objPRReq.UID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp DelTStockItem(PRReq objPRReq)
        {
            string hod = "delete from Store_tbl_TempStock where  OID='" + objPRReq.OID + "' and TSID='" + objPRReq.TSID + "' and UID='" + objPRReq.UID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }
        public PRResp getItemTotals(PRReq objPRReq)
        {
            string hod = "select sum(Rate) as tRate from Store_tbl_TempStock where  OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and UID='" + objPRReq.UID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }

        // Stock Table

        public PRResp getStoreStockDetails_ICID_ITID(PRReq objPRReq)
        {
            string s = "select * from Store_tbl_StoreStock where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ICID='" + objPRReq.ICID + "' and ITID='" + objPRReq.ITID + "' and Quantity>=0 ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getItemTotal(PRReq objPRReq)
        {
            string hod = "select sum(Rate) as tRate from Store_tbl_StoreStock where  OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ICID='" + objPRReq.ICID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }
        public PRResp AddStockMonthlyClosing(PRReq objPRReq)
        {
            string insert = "insert into Store_tbl_StoreClosingStock (STID,MonthYear,OID,VID,Vendor,InvoiceNo,ICID,ItemCategory,ITID,ItemName,ItemType,FileNo,BatchNo,Quantity,Rate,UnitCost,MinQty,Status,UID,UName,Dated) values('" + objPRReq.STID + "','" + objPRReq.MonthYear + "','" + objPRReq.OID + "','" + objPRReq.VID + "','" + objPRReq.Vendor + "','" + objPRReq.InvoiceNo + "','" + objPRReq.ICID + "','" + objPRReq.ItemCategory + "','" + objPRReq.ITID + "','" + objPRReq.ItemName + "','" + objPRReq.ItemType + "','" + objPRReq.FileNo + "','" + objPRReq.BatchNo + "','" + objPRReq.Quantity + "','" + objPRReq.Rate + "','" + objPRReq.UnitCost + "','" + objPRReq.MinQty + "','" + objPRReq.Status + "','" + objPRReq.UID + "','" + objPRReq.UName + "','" + objPRReq.Dated + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getStockMonthlyClosing(PRReq objPRReq)
        {
            string s = "select * from Store_tbl_StoreClosingStock where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ICID='" + objPRReq.ICID + "' and ITID='" + objPRReq.ITID + "' and FileNo='" + objPRReq.FileNo + "' and Quantity='" + objPRReq.Quantity + "' and UnitCost='" + objPRReq.UnitCost + "' and InvoiceNo='" + objPRReq.InvoiceNo + "' and MonthYear='" + objPRReq.MonthYear + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp AddStock(PRReq objPRReq)
        {
            string insert = "insert into Store_tbl_StoreStock (TSID,OID,VID,Vendor,InvoiceNo,InvoiceDate,DLNo,TIN,VEmail,VPhone,ICID,ItemCategory,ITID,ItemName,ItemType,IMID,Manufacturer,PurchaseOrderNo,PurchaseDate,FileNo,BatchNo,Quantity,Rate,UnitCost,MinQty,Status,UID,UName,Dated) values('" + objPRReq.TSID + "','" + objPRReq.OID + "','" + objPRReq.VID + "','" + objPRReq.Vendor + "','" + objPRReq.InvoiceNo + "','" + objPRReq.InvoiceDate + "','" + objPRReq.DLNo + "','" + objPRReq.TIN + "','" + objPRReq.Email + "','" + objPRReq.Phone + "','" + objPRReq.ICID + "','" + objPRReq.ItemCategory + "','" + objPRReq.ITID + "','" + objPRReq.ItemName + "','" + objPRReq.ItemType + "','" + objPRReq.IMID + "','" + objPRReq.Manufacturer + "','" + objPRReq.PONo + "','" + objPRReq.PurchaseDate + "','" + objPRReq.FileNo + "','" + objPRReq.BatchNo + "','" + objPRReq.Quantity + "','" + objPRReq.Rate + "','" + objPRReq.UnitCost + "','" + objPRReq.MinQty + "','" + objPRReq.Status + "','" + objPRReq.UID + "','" + objPRReq.UName + "','" + objPRReq.Dated + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getStoreStock_ICID(PRReq objPRReq)
        {
            string s = "select * from Store_tbl_StoreStock where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ICID='" + objPRReq.ICID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getStoreStock(PRReq objPRReq)
        {
            string s = "select * from Store_tbl_StoreStock where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getItemInfoBy_ICID_ITID(PRReq objPRReq)
        {
            string s = "select * from Store_tbl_StoreStock where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ITID='" + objPRReq.ITID + "' and ICID='" + objPRReq.ICID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getCountofPendingStoreIndents(PRReq objPRReq)
        {
            string s = "select distinct RIndentNo as INo from Store_tbl_EmpIndent where DID='" + objPRReq.DID + "' and OID='" + objPRReq.OID + "' and Flag1='0' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getCountofPendingStoreIndents_DG(PRReq objPRReq)
        {
            string s = "select distinct RIndentNo as INo from Store_tbl_EmpIndent where DID='" + objPRReq.DID + "' and OID='" + objPRReq.OID + "' and Flag1='0' and (CONVERT(DATETIME,'" + objPRReq.ToDate + "')>=ReqDate AND CONVERT(DATETIME,'" + objPRReq.FromDate + "')<=ReqDate) ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getCountofApprovedStoreIndents(PRReq objPRReq)
        {
            string s = "select distinct AIndentNo as INo from Store_tbl_FinalApprovedEmpIndent where DID='" + objPRReq.DID + "' and Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getCountofApprovedStoreIndents_DG(PRReq objPRReq)
        {
            string s = "select distinct AIndentNo as INo from Store_tbl_FinalApprovedEmpIndent where DID='" + objPRReq.DID + "' and Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and (CONVERT(DATETIME,'" + objPRReq.ToDate + "')>=ReqDate AND CONVERT(DATETIME,'" + objPRReq.FromDate + "')<=ReqDate) ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllHEmpIDIndents(PRReq objPRReq)
        {
            string s = "select distinct DID,RIndentNo from Store_tbl_EmpIndent where HEmpID='" + objPRReq.EmpID + "' and Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpNameApprovedStoreRIndents_DID(PRReq objPRReq)
        {
            string s = "select distinct EmpID,Name from Store_tbl_FinalApprovedEmpIndent where DID='" + objPRReq.DID + "' and Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and RIndentNo='" + objPRReq.RIndentNo + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpNameApprovedStoreIndents(PRReq objPRReq)
        {
            string s = "select distinct EmpID,Name from Store_tbl_FinalApprovedEmpIndent where DID='" + objPRReq.DID + "' and Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getCountofApprovedEmpWiseStoreIndents(PRReq objPRReq)
        {
            string s = "select distinct AIndentNo as INo from Store_tbl_FinalApprovedEmpIndent where DID='" + objPRReq.DID + "' and Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getCostofApprovedEmpWiseStoreIndents(PRReq objPRReq)
        {
            string s = "select sum(APrice) as Cost from Store_tbl_FinalApprovedEmpIndent where DID='" + objPRReq.DID + "' and Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getCostofApprovedStoreIndents(PRReq objPRReq)
        {
            string s = "select sum(APrice) as Cost from Store_tbl_FinalApprovedEmpIndent where DID='" + objPRReq.DID + "' and Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getCostofApprovedStoreIndents_DG(PRReq objPRReq)
        {
            string s = "select sum(APrice) as Cost from Store_tbl_FinalApprovedEmpIndent where DID='" + objPRReq.DID + "' and Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and (CONVERT(DATETIME,'" + objPRReq.ToDate + "')>=ReqDate AND CONVERT(DATETIME,'" + objPRReq.FromDate + "')<=ReqDate) ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getITIDbyEIID(PRReq objPRReq)
        {
            string s = "select distinct ITID from Store_tbl_EmpIndent where EIID='" + objPRReq.EIID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllITIDbyEIID(PRReq objPRReq)
        {
            string s = "select * from Store_tbl_EmpIndent where EIID='" + objPRReq.EIID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getItemInfoByITID(PRReq objPRReq)
        {
            string s = "select * from Store_tbl_StoreStock where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ITID='" + objPRReq.ITID + "' and Quantity>0 ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getMinStockItems(PRReq objPRReq)
        {
            string s = "select * from Store_tbl_StoreStock where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and Quantity<=MinQty ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getStockItembySTID(PRReq objPRReq)
        {
            string s = "select * from Store_tbl_StoreStock where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and STID='" + objPRReq.STID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getStockItemby_ICID_ITID_BatchNo(PRReq objPRReq)
        {
            string s = "select * from Store_tbl_StoreStock where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ITID='" + objPRReq.ITID + "' and ICID='" + objPRReq.ICID + "' and BatchNo='" + objPRReq.BatchNo + "' and VID='" + objPRReq.VID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getStockItemby_ICID_Total(PRReq objPRReq)
        {
            string s = "select sum(Quantity) as Quantity from Store_tbl_StoreStock where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ITID='" + objPRReq.ITID + "' and ICID='" + objPRReq.ICID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getStockItembySTID_ICID_ITID_BatchNo(PRReq objPRReq)
        {
            string s = "select * from Store_tbl_StoreStock where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and STID='" + objPRReq.STID + "' and ITID='" + objPRReq.ITID + "' and ICID='" + objPRReq.ICID + "' and BatchNo='" + objPRReq.BatchNo + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp updateStockItembySTID_ICID_ITID_BatchNo(PRReq objPRReq)
        {
            string update = "update Store_tbl_StoreStock set Quantity='" + objPRReq.Quantity + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and STID='" + objPRReq.STID + "' and ITID='" + objPRReq.ITID + "' and ICID='" + objPRReq.ICID + "' and BatchNo='" + objPRReq.BatchNo + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }

        public PRResp updateStockItembyVID_STID_ICID_ITID_BatchNo(PRReq objPRReq)
        {
            string update = "update Store_tbl_StoreStock set Quantity='" + objPRReq.Quantity + "',UnitCost='" + objPRReq.UnitCost + "',BatchNo='" + objPRReq.BatchNo + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ITID='" + objPRReq.ITID + "' and ICID='" + objPRReq.ICID + "' and FileNo='" + objPRReq.FileNo + "' and VID='" + objPRReq.VID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        // Store_tbl_User
        public PRResp getStoreUserData(PRReq objPRReq)
        {
            string s = "select * from Store_tbl_User where SUID='" + objPRReq.SUID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp StoreUserLogin(PRReq objPRReq)
        {
            string s = "select * from Store_tbl_User where UserID='" + objPRReq.UserID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getUsers(PRReq objPRReq)
        {
            string s = "select * from Store_tbl_User where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp AddUser(PRReq objPRReq)
        {
            string insert = "insert into Store_tbl_User (OID,UserID,Name,Designation,Email,Password,Mobile,Role,Photo,Status,UID,UName,Dated) values('" + objPRReq.OID + "','" + objPRReq.UserID + "','" + objPRReq.Name + "','" + objPRReq.Design + "','" + objPRReq.Email + "','" + objPRReq.Password + "','" + objPRReq.Mobile + "','" + objPRReq.Role + "','" + objPRReq.Photo + "','" + objPRReq.Status + "','" + objPRReq.UID + "','" + objPRReq.UName + "','" + objPRReq.Dated + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getUserByName(PRReq objPRReq)
        {
            string s = "select * from Store_tbl_User where UserID='" + objPRReq.UserID + "' and Name='" + objPRReq.Name + "' and Email='" + objPRReq.Email + "' and OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getUserBySUID(PRReq objPRReq)
        {
            string s = "select * from Store_tbl_User where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and SUID='" + objPRReq.SUID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp EditUserBySUID(PRReq objPRReq)
        {
            string update = "update Store_tbl_User set UserID='" + objPRReq.UserID + "',Name='" + objPRReq.Name + "',Email='" + objPRReq.Email + "',Mobile='" + objPRReq.Mobile + "',Designation='" + objPRReq.Design + "',Photo='" + objPRReq.Photo + "',UID='" + objPRReq.UID + "',UName='" + objPRReq.UName + "' where OID='" + objPRReq.OID + "' and SUID='" + objPRReq.SUID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp DelUser(PRReq objPRReq)
        {
            string hod = "delete from Store_tbl_User where  OID='" + objPRReq.OID + "' and SUID='" + objPRReq.SUID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }
        public PRResp UserSearch(PRReq objPRReq)
        {
            string s = "select * from Store_tbl_User where Name like '%" + objPRReq.Name + "%' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        // Emp Store Indent
        public PRResp AddEmpTempStoreIndent(PRReq objPRReq)
        {
            string insert = "insert into Store_tbl_ETIndent (OID,EID,EmpID,DID,DeptID,Name,SPID,Purpose,PCode,PTitle,VID,BatchNo,ICID,ItemCategory,ITID,ItemName,RQuantity,Status,UID,UName,ReqDate) values('" + objPRReq.OID + "','" + objPRReq.EID + "','" + objPRReq.EmpID + "','" + objPRReq.DID + "','" + objPRReq.DeptID + "','" + objPRReq.Name + "','" + objPRReq.SPID + "','" + objPRReq.Purpose + "','" + objPRReq.PCode + "','" + objPRReq.PTitle + "','" + objPRReq.VID + "','" + objPRReq.BatchNo + "','" + objPRReq.ICID + "','" + objPRReq.ItemCategory + "','" + objPRReq.ITID + "','" + objPRReq.ItemName + "','" + objPRReq.RQuantity + "','" + objPRReq.Status + "','" + objPRReq.UID + "','" + objPRReq.UName + "','" + objPRReq.ReqDate + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getEISNo(PRReq objPRReq)
        {
            string s = "select max(" + objPRReq.ColumnName + ") from Store_tbl_EmpIndent where OID='" + objPRReq.OID + "' ";
            objPRResp.SingleValue = Connections.GetSingleValue(s);
            return objPRResp;
        }
        public PRResp getAllRepeatedTempItemsbyUID(PRReq objPRReq)
        {
            string s = "select * from Store_tbl_ETIndent where EmpID='" + objPRReq.EmpID + "' and Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and PCode='" + objPRReq.PCode + "' and ITID='" + objPRReq.ITID + "' and ICID='" + objPRReq.ICID + "' and RQuantity='" + objPRReq.RQuantity + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllTempItemsbyUID(PRReq objPRReq)
        {
            string s = "select * from Store_tbl_ETIndent where (UID='" + objPRReq.UID + "' or EmpID='" + objPRReq.EmpID + "') and Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp DelTempItemsbyUID(PRReq objPRReq)
        {
            string hod = "delete from Store_tbl_ETIndent where  OID='" + objPRReq.OID + "' and TEIID='" + objPRReq.TEIID + "' and UID='" + objPRReq.UID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }

        public PRResp SaveEmpStoreIndent(PRReq objPRReq)
        {
            string insert = "insert into Store_tbl_EmpIndent (ISNo,RIndentNo,TEIID,QRCode,OID,EID,EmpID,DID,DeptID,Name,Email,Mobile,SPID,Purpose,PCode,PTitle,VID,BatchNo,ICID,ItemCategory,ITID,ItemName,RQuantity,UQuantity,Status,UID,UName,ReqDate,Flag1,Flag2,Flag3,Flag4,HEmpID,HName,HMobile,HEmail) values('" + objPRReq.ISNo + "','" + objPRReq.RIndentNo + "','" + objPRReq.TEIID + "','" + objPRReq.QRCode + "','" + objPRReq.OID + "','" + objPRReq.EID + "','" + objPRReq.EmpID + "','" + objPRReq.DID + "','" + objPRReq.DeptID + "','" + objPRReq.Name + "','" + objPRReq.Email + "','" + objPRReq.Mobile + "','" + objPRReq.SPID + "','" + objPRReq.Purpose + "','" + objPRReq.PCode + "','" + objPRReq.PTitle + "','" + objPRReq.VID + "','" + objPRReq.BatchNo + "','" + objPRReq.ICID + "','" + objPRReq.ItemCategory + "','" + objPRReq.ITID + "','" + objPRReq.ItemName + "','" + objPRReq.RQuantity + "','" + objPRReq.RQuantity + "','" + objPRReq.Status + "','" + objPRReq.UID + "','" + objPRReq.UName + "','" + objPRReq.ReqDate + "','" + objPRReq.Flag1 + "','" + objPRReq.Flag2 + "','" + objPRReq.Flag3 + "','" + objPRReq.Flag4 + "','" + objPRReq.HEmpID + "','" + objPRReq.HName + "','" + objPRReq.HMobile + "','" + objPRReq.HEmail + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getAllIndentssbyUID(PRReq objPRReq)
        {
            string s = "select distinct PTitle,Purpose,RIndentNo,ReqDate,Status,DeptID,Flag1,Flag2,Flag3,Flag4,HName from Store_tbl_EmpIndent where (UID='" + objPRReq.UID + "' or EmpID='" + objPRReq.EmpID + "') and OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' order by RIndentNo Desc ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllIndentssbyUID_Flag2(PRReq objPRReq)
        {
            string s = "select distinct PTitle,Purpose,RIndentNo,ReqDate,Status,DeptID,Flag1,Flag2,Flag3,Flag4,HName from Store_tbl_EmpIndent where (UID='" + objPRReq.UID + "' or EmpID='" + objPRReq.EmpID + "') and Flag2='" + objPRReq.Flag2 + "' and OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' order by RIndentNo Desc ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllOtherIndentssbyHEmpID(PRReq objPRReq)
        {
            string s = "select distinct Name, PTitle,Purpose,RIndentNo,ReqDate,Status,DeptID,Flag1,Flag2,Flag3,Flag4,HName from Store_tbl_EmpIndent where HEmpID='" + objPRReq.HEmpID + "' and OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' order by RIndentNo Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllOtherIndentssbyHEmpID_Flag2(PRReq objPRReq)
        {
            string s = "select distinct Name, PTitle,Purpose,RIndentNo,ReqDate,Status,DeptID,Flag1,Flag2,Flag3,Flag4,HName from Store_tbl_EmpIndent where HEmpID='" + objPRReq.HEmpID + "' and OID='" + objPRReq.OID + "' and Flag2='" + objPRReq.Flag2 + "' and Status='" + objPRReq.Status + "' order by RIndentNo Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllIndentssbyUIDItemsCount(PRReq objPRReq)
        {
            string s = "select Count(RIndentNo) as icount from Store_tbl_EmpIndent where (UID='" + objPRReq.UID + "' or EmpID='" + objPRReq.EmpID + "')  and OID='" + objPRReq.OID + "' and RIndentNo='" + objPRReq.RIndentNo + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllIndentssbyStore(PRReq objPRReq)
        {
            string s = "select distinct PTitle,PCode,Purpose,RIndentNo,ReqDate,Status,Name,Email,Mobile,DeptID,Flag1,Flag2,Flag3,Flag4,HName from Store_tbl_EmpIndent where  Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' order by RIndentNo Desc ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllIndentssbyStore_HOC_ART_Approved(PRReq objPRReq)
        {
            string s = "select distinct PTitle,PCode,Purpose,RIndentNo,ReqDate,Status,Name,Email,Mobile,DeptID,Flag1,Flag2,Flag3,Flag4,HName from Store_tbl_EmpIndent where  Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and Flag2='" + objPRReq.Flag2 + "' and Flag3='" + objPRReq.Flag3 + "' order by RIndentNo Desc ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllIndentssbyStore_forARTApproval(PRReq objPRReq)
        {
            string s = "select distinct PTitle,PCode,Purpose,RIndentNo,ReqDate,Status,Name,Email,Mobile,DeptID,Flag1,Flag2,Flag3,Flag4,HName from Store_tbl_EmpIndent where  Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and Flag1='" + objPRReq.Flag1 + "' and Flag2='" + objPRReq.Flag2 + "' and Flag3='" + objPRReq.Flag3 + "' order by RIndentNo Desc ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllIndentssbyStore_forARTApproval_Count(PRReq objPRReq)
        {
            string s = "select * from Store_tbl_EmpIndent where  Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and Flag1='" + objPRReq.Flag1 + "' and Flag2='" + objPRReq.Flag2 + "' and Flag3='" + objPRReq.Flag3 + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getIndentsDatabyRIndentNo(PRReq objPRReq)
        {
            string s = "select distinct PTitle,PCode,Purpose,RIndentNo,ReqDate,Status,Name,Email,EmpID,Mobile,QRCode,DeptID from Store_tbl_EmpIndent where  Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and RIndentNo='" + objPRReq.RIndentNo + "' and Flag1='" + objPRReq.Flag1 + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getALLIndentsDatabyRIndentNo(PRReq objPRReq)
        {
            string s = "select * from Store_tbl_EmpIndent where  Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and RIndentNo='" + objPRReq.RIndentNo + "' and Flag1='" + objPRReq.Flag1 + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllIndentssbyStoreItemsCount(PRReq objPRReq)
        {
            string s = "select Count(RIndentNo) as icount from Store_tbl_EmpIndent where  Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and RIndentNo='" + objPRReq.RIndentNo + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllIndentsbyRIndentID(PRReq objPRReq)
        {
            string s = "select * from Store_tbl_EmpIndent where OID='" + objPRReq.OID + "' and RIndentNo='" + objPRReq.RIndentNo + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllIndentsbyRIndentID_EmpID(PRReq objPRReq)
        {
            string s = "select distinct RIndentNo  from Store_tbl_EmpIndent where HEmpID='" + objPRReq.EmpID + "' and Flag2='" + objPRReq.Flag2 + "' and Flag3='" + objPRReq.Flag3 + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp DelRIndentItem(PRReq objPRReq)
        {
            string hod = "delete from Store_tbl_EmpIndent where  EIID='" + objPRReq.EIID + "' and EmpID='" + objPRReq.EmpID + "' and OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }
        public PRResp GetAllHOC_PendingIndents(PRReq objPRReq)
        {
            string hod = "select distinct HEmpID from Store_tbl_EmpIndent where  HEmpID='" + objPRReq.HEmpID + "' and OID='" + objPRReq.OID + "' and Flag2='" + objPRReq.Flag2 + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }
        public PRResp getAllApprovedIndentsbyAIndentID(PRReq objPRReq)
        {
            string s = "select * from Store_tbl_FinalApprovedEmpIndent where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and AIndentNo='" + objPRReq.ApprvdIndentNo + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp OthersIndentApproved_byHOC(PRReq objPRReq)
        {
            string update = "update Store_tbl_EmpIndent set Flag2='" + objPRReq.Flag2 + "',HOCEmpID='" + objPRReq.HEmpID + "',HOCName='" + objPRReq.HName + "',HApprovedDate='" + objPRReq.Dated + "' where HEmpID='" + objPRReq.HEmpID + "' and OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and RIndentNo='" + objPRReq.RIndentNo + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }

        public PRResp EditRIndentQty_ART(PRReq objPRReq)
        {
            string update = "update Store_tbl_EmpIndent set UQuantity='" + objPRReq.RQuantity + "' where EmpID='" + objPRReq.EmpID + "' and OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and RIndentNo='" + objPRReq.RIndentNo + "' and EIID='" + objPRReq.EIID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp OthersIndentApproved_byART(PRReq objPRReq)
        {
            string update = "update Store_tbl_EmpIndent set Flag3='" + objPRReq.Flag3 + "',ARTID='" + objPRReq.HEmpID + "',ARTName='" + objPRReq.HName + "',ARTApprovedDate='" + objPRReq.Dated + "' where Flag1='" + objPRReq.Flag1 + "' and Flag2='" + objPRReq.Flag2 + "' and OID='" + objPRReq.OID + "' and RIndentNo='" + objPRReq.RIndentNo + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        // Drivers

        public PRResp getAllDrivers(PRReq objPRReq)
        {
            string s = "select * from Vehicle_tbl_Drivers where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getDriver_VDID(PRReq objPRReq)
        {
            string s = "select * from Vehicle_tbl_Drivers where Status='" + objPRReq.Status + "' and VDID='" + objPRReq.VDID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp AddDriver(PRReq objPRReq)
        {
            string insert = "insert into Vehicle_tbl_Drivers (OID,Name,Designation,Email,Mobile,Address,DriverType,LicenceNo,LicenceValidDate,Status,UID,UName) values('" + objPRReq.OID + "','" + objPRReq.Name + "','" + objPRReq.Design + "','" + objPRReq.Email + "','" + objPRReq.Mobile + "','" + objPRReq.Address + "','" + objPRReq.DriverType + "','" + objPRReq.LicenceNo + "','" + objPRReq.LicenceValidDate + "','" + objPRReq.Status + "','" + objPRReq.UID + "','" + objPRReq.UName + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getDriversbyTypeName(PRReq objPRReq)
        {
            string s = "select * from Vehicle_tbl_Drivers where DriverType='" + objPRReq.DriverType + "' and OID='" + objPRReq.OID + "' and Name='" + objPRReq.Name + "' and LicenceNo='" + objPRReq.LicenceNo + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp EditDriversByVDID(PRReq objPRReq)
        {
            string update = "update Vehicle_tbl_Drivers set OID='" + objPRReq.OID + "', Name='" + objPRReq.Name + "', Designation='" + objPRReq.Design + "', Email='" + objPRReq.Email + "', Mobile='" + objPRReq.Mobile + "', Address='" + objPRReq.Address + "', DriverType='" + objPRReq.DriverType + "', LicenceNo='" + objPRReq.LicenceNo + "', LicenceValidDate='" + objPRReq.LicenceValidDate + "', Status='" + objPRReq.Status + "', UID='" + objPRReq.UID + "', UName='" + objPRReq.UName + "' where VDID='" + objPRReq.VDID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp DelDriver(PRReq objPRReq)
        {
            string hod = "delete from Vehicle_tbl_Drivers where  VDID='" + objPRReq.VDID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }
        public PRResp DriverSearch(PRReq objPRReq)
        {
            string s = "select * from Vehicle_tbl_Drivers where Name like '%" + objPRReq.Name + "%' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        // Vehicles

        public PRResp getAllVehicles(PRReq objPRReq)
        {
            string s = "select * from Vehicle_tbl_Vehicles where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllVehicleTypes(PRReq objPRReq)
        {
            string s = "select distinct VehicleType from Vehicle_tbl_Vehicles where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllVehicle_VType(PRReq objPRReq)
        {
            string s = "select distinct * from Vehicle_tbl_Vehicles where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and VehicleType='" + objPRReq.VehicleType + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getVehicle_VID(PRReq objPRReq)
        {
            string s = "select * from Vehicle_tbl_Vehicles where Status='" + objPRReq.Status + "' and VID='" + objPRReq.VID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp AddVehicle(PRReq objPRReq)
        {
            string insert = "insert into Vehicle_tbl_Vehicles (OID,VehicleName,VehicleModel,VehicleNumber,SeatCapacity,VehicleType,Status,UID,UName) values('" + objPRReq.OID + "','" + objPRReq.VehicleName + "','" + objPRReq.ModelType + "','" + objPRReq.VehicleNumber + "','" + objPRReq.SeatCapacity + "','" + objPRReq.VehicleType + "','" + objPRReq.Status + "','" + objPRReq.UID + "','" + objPRReq.UName + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getVehiclesbyTypeName(PRReq objPRReq)
        {
            string s = "select * from Vehicle_tbl_Vehicles where VehicleType='" + objPRReq.VehicleType + "' and OID='" + objPRReq.OID + "' and VehicleName='" + objPRReq.VehicleName + "' and VehicleNumber='" + objPRReq.VehicleNumber + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp EditVehiclesByVID(PRReq objPRReq)
        {
            string update = "update Vehicle_tbl_Vehicles set OID='" + objPRReq.OID + "',VehicleName='" + objPRReq.VehicleName + "',VehicleModel='" + objPRReq.ModelType + "', VehicleNumber='" + objPRReq.VehicleNumber + "', SeatCapacity='" + objPRReq.SeatCapacity + "', VehicleType='" + objPRReq.VehicleType + "', Status='" + objPRReq.Status + "', UID='" + objPRReq.UID + "', UName='" + objPRReq.UName + "' where VID='" + objPRReq.VID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp DelVehicle(PRReq objPRReq)
        {
            string hod = "delete from Vehicle_tbl_Vehicles where  VID='" + objPRReq.VID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }
        public PRResp VehicleSearch(PRReq objPRReq)
        {
            string s = "select * from Vehicle_tbl_Vehicles where VehicleName like '%" + objPRReq.VehicleName + "%' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        // Research Projects Info
        public PRResp AddRPTitle(PRReq objPRReq)
        {
            string insert = "insert into PR_tbl_RPTitles (OID,FYID,FinancialYear,DID,DeptID,ProgType,ProgramID,ProgramName,ProgramTitle,Duration,CoordinatorName,Venue,Clientele,RPCode,Status,UID,UName,Dated) values('" + objPRReq.OID + "','" + objPRReq.FYID + "','" + objPRReq.FinancialYear + "','" + objPRReq.DID + "','" + objPRReq.DeptID + "','" + objPRReq.ProgType + "','" + objPRReq.ProgramID + "','" + objPRReq.ProgType + "','" + objPRReq.ProgTitle + "','" + objPRReq.ProgDuration + "','" + objPRReq.ProgCoordinator + "','" + objPRReq.ProgVenue + "','" + objPRReq.ProgClientele + "','" + objPRReq.RPCode + "','" + objPRReq.Status + "','" + objPRReq.UID + "','" + objPRReq.UName + "','" + objPRReq.Dated + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getAllRPCodes_Title(PRReq objPRReq)
        {
            string s = "select distinct * from PR_tbl_RPTitles where Status='" + objPRReq.Status + "' and DID='" + objPRReq.DID + "' and FYID='" + objPRReq.FYID + "' and ProgramTitle='" + objPRReq.ProgTitle + "' and Duration='" + objPRReq.ProgDuration + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllRPCodesbyYear(PRReq objPRReq)
        {
            string s = "select distinct * from PR_tbl_RPTitles where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and DID='" + objPRReq.DID + "' and FYID='" + objPRReq.FYID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllRPCodes(PRReq objPRReq)
        {
            string s = "select distinct * from PR_tbl_RPTitles where Status='" + objPRReq.Status + "' and DID='" + objPRReq.DID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllRPCodesbyProgID(PRReq objPRReq)
        {
            string s = "select distinct * from PR_tbl_RPTitles where Status='" + objPRReq.Status + "' and ProgramID='" + objPRReq.ProjectCode + "' and DID='" + objPRReq.DID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllRPCodeTitles(PRReq objPRReq)
        {
            string s = "select distinct ProgramTitle from PR_tbl_RPTitles where Status='" + objPRReq.Status + "' and DID='" + objPRReq.DID + "' and ProgType='" + objPRReq.ProgType + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllRPCodeDurationsbyProgTitle(PRReq objPRReq)
        {
            string s = "select distinct Duration,ProgramID from PR_tbl_RPTitles where Status='" + objPRReq.Status + "' and ProgramTitle='" + objPRReq.ProgTitle + "' and DID='" + objPRReq.DID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllRPCodesFromDuration(PRReq objPRReq)
        {
            string s = "select distinct * from PR_tbl_RPTitles where Status='" + objPRReq.Status + "' and DID='" + objPRReq.DID + "' and ProgramID='" + objPRReq.ProgCode + "' and Duration='" + objPRReq.Duration + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        // ADmin Circulars

        public PRResp getCircularSNo(PRReq objPRReq)
        {
            string s = "select max(" + objPRReq.ColumnName + ") from PR_tbl_Circulars where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.SingleValue = Connections.GetSingleValue(s);
            return objPRResp;
        }

        public PRResp PostCircular(PRReq objPRReq)
        {
            string insert = "insert into PR_tbl_Circulars (OID,EGID,EmpGroup,CType,Title,Dated,FileName,UID,UName,UDesign,Status) values('" + objPRReq.OID + "','" + objPRReq.EGID + "','" + objPRReq.EmpGroup + "','" + objPRReq.CircularType + "','" + objPRReq.Title + "','" + objPRReq.Dated + "','" + objPRReq.FileName + "','" + objPRReq.UID + "','" + objPRReq.UName + "','" + objPRReq.Design + "','" + objPRReq.Status + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getFilesbyPCID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Circulars where PCID='" + objPRReq.PCID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getFilesbyUID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Circulars where UID='" + objPRReq.UID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getCirculars(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Circulars where OID='" + objPRReq.OID + "' and CType='" + objPRReq.CircularType + "' and Title='" + objPRReq.Title + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp DisplayCirculars(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Circulars where OID='" + objPRReq.OID + "' and CType='" + objPRReq.CircularType + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp DisplayCirculars_Emp(PRReq objPRReq)
        {
            string s = "select distinct * from PR_tbl_Circulars where OID='" + objPRReq.OID + "' and CType='" + objPRReq.CircularType + "' and Status='" + objPRReq.Status + "' and EGID='" + objPRReq.EGID + "' or EGID='3' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp DisplayOfficeOrders_Emp(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Circulars where OID='" + objPRReq.OID + "' and CType='" + objPRReq.CircularType + "' and Status='" + objPRReq.Status + "' and EGID='" + objPRReq.EGID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp DisplayNotifications_Emp(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Circulars where OID='" + objPRReq.OID + "' and CType='" + objPRReq.CircularType + "' and Status='" + objPRReq.Status + "' and EGID='" + objPRReq.EGID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp BlockCircularsPCID(PRReq objPRReq)
        {
            string update = "update PR_tbl_Circulars set Status='" + objPRReq.BlockStatus + "' where UID='" + objPRReq.UID + "' and PCID='" + objPRReq.PCID + "' and Status='" + objPRReq.Status + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp DeleteCircularsPCID(PRReq objPRReq)
        {
            string hod = "delete from PR_tbl_Circulars  where  PCID='" + objPRReq.PCID + "' and UID='" + objPRReq.UID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }


        // Visitor Vehicles
        public PRResp getVehicleTypes(PRReq objPRReq)
        {
            string s = "select * from Security_tbl_VehicleType where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp AddVehicleType(PRReq objPRReq)
        {
            string insert = "insert into Security_tbl_VehicleType (OID,VehicleType,Status,UID,UName,Dated) values('" + objPRReq.OID + "','" + objPRReq.VehicleType + "','" + objPRReq.Status + "','" + objPRReq.UID + "','" + objPRReq.UName + "','" + objPRReq.Dated + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getVehicleTypeByName(PRReq objPRReq)
        {
            string s = "select * from Security_tbl_VehicleType where VehicleType='" + objPRReq.VehicleType + "' and OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getVehicleTypeByVVID(PRReq objPRReq)
        {
            string s = "select * from Security_tbl_VehicleType where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and VVID='" + objPRReq.VVID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp EditVehicleTypeByVVID(PRReq objPRReq)
        {
            string update = "update Security_tbl_VehicleType set VehicleType='" + objPRReq.VehicleType + "' where OID='" + objPRReq.OID + "' and VVID='" + objPRReq.VVID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp DelVehicleType(PRReq objPRReq)
        {
            string hod = "delete from Security_tbl_VehicleType where  OID='" + objPRReq.OID + "' and VVID='" + objPRReq.VVID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }
        public PRResp VehicleTypeSearch(PRReq objPRReq)
        {
            string s = "select * from Security_tbl_VehicleType where VehicleType like '%" + objPRReq.VehicleType + "%' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        // Visitor Cards
        public PRResp getVCardNosbyFlag(PRReq objPRReq)
        {
            string s = "select * from Security_tbl_VCards where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and Flag1='" + objPRReq.Flag1 + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getVCardNos(PRReq objPRReq)
        {
            string s = "select * from Security_tbl_VCards where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp AddVCardNo(PRReq objPRReq)
        {
            string insert = "insert into Security_tbl_VCards (OID,VCardNo,Status,Flag1,UID,UName,Dated) values('" + objPRReq.OID + "','" + objPRReq.VCardNo + "','" + objPRReq.Status + "','" + objPRReq.Flag1 + "','" + objPRReq.UID + "','" + objPRReq.UName + "','" + objPRReq.Dated + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getVCardNoByName(PRReq objPRReq)
        {
            string s = "select * from Security_tbl_VCards where VCardNo='" + objPRReq.VCardNo + "' and OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getVCardNoByVCID(PRReq objPRReq)
        {
            string s = "select * from Security_tbl_VCards where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and VCID='" + objPRReq.VCID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp EditVCardNoByVCID(PRReq objPRReq)
        {
            string update = "update Security_tbl_VCards set VCardNo='" + objPRReq.VCardNo + "' where OID='" + objPRReq.OID + "' and VCID='" + objPRReq.VCID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp UpdateVCardNoByVVID(PRReq objPRReq)
        {
            string update = "update Security_tbl_VCards set Status='" + objPRReq.Status + "',Flag1='" + objPRReq.Flag1 + "',DVID='" + objPRReq.DVID + "', Dated='" + objPRReq.Dated + "' where OID='" + objPRReq.OID + "' and VCID='" + objPRReq.VCID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp ReleaseVCardNo(PRReq objPRReq)
        {
            string update = "update Security_tbl_VCards set Status='" + objPRReq.Status + "',Flag1='" + objPRReq.Flag1 + "',DVID='" + objPRReq.DVID + "', Dated='" + objPRReq.Dated + "' where OID='" + objPRReq.OID + "' and VCardNo='" + objPRReq.VCardNo + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp DelVCardNo(PRReq objPRReq)
        {
            string hod = "delete from Security_tbl_VCards where  OID='" + objPRReq.OID + "' and VCID='" + objPRReq.VCID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }
        public PRResp VCardNoSearch(PRReq objPRReq)
        {
            string s = "select * from Security_tbl_VCards where VCardNo like '%" + objPRReq.VCardNo + "%' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        // Security_Visitor
        public PRResp AddVisitor(PRReq objPRReq)
        {
            string insert = "insert into Security_tbl_Visitors (OID,VisitID,Name,Mobile,Email,VisitBy,VVID,VehicleType,VehicleNumber,VehicleName,VisitorType,FromDate,ToDate,CPType,EmpID,ContactPerson,DeptID,CPMobile,CPEmail,VCardNo,Purpose,CampusStay,Address,Photo,QRCode,Status,Flag1,SGNo,UName,Dated) values('" + objPRReq.OID + "','" + objPRReq.VisitID + "','" + objPRReq.Name + "','" + objPRReq.Mobile + "','" + objPRReq.Email + "','" + objPRReq.VisitBy + "','" + objPRReq.VVID + "','" + objPRReq.VehicleType + "','" + objPRReq.VehicleNumber + "','" + objPRReq.VehicleName + "','" + objPRReq.VisitorType + "','" + objPRReq.FromDate + "','" + objPRReq.ToDate + "','" + objPRReq.CPType + "','" + objPRReq.EmpID + "','" + objPRReq.ContactPerson + "','" + objPRReq.DeptID + "','" + objPRReq.CPMobile + "','" + objPRReq.CPEmail + "','" + objPRReq.VCardNo + "','" + objPRReq.Purpose + "','" + objPRReq.CampusStay + "','" + objPRReq.Address + "','" + objPRReq.Photo + "','" + objPRReq.QRCode + "','" + objPRReq.Status + "','" + objPRReq.Flag1 + "','" + objPRReq.SGNO + "','" + objPRReq.UName + "','" + objPRReq.Dated + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getVisitSNo(PRReq objPRReq)
        {
            string s = "select max(" + objPRReq.ColumnName + ") from Security_tbl_Visitors where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.SingleValue = Connections.GetSingleValue(s);
            return objPRResp;
        }
        public PRResp getVisitors(PRReq objPRReq)
        {
            string s = "select * from Security_tbl_Visitors where Mobile='" + objPRReq.Mobile + "' and Name='" + objPRReq.Name + "' and Status='Active' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getVisitor_Mobile(PRReq objPRReq)
        {
            string s = "select distinct * from Security_tbl_Visitors where Mobile='" + objPRReq.Mobile + "' and OID='" + objPRReq.OID + "' Order by DVID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getVisitorHistory(PRReq objPRReq)
        {
            string s = "select * from Security_tbl_Visitors where Mobile='" + objPRReq.Mobile + "' and OID='" + objPRReq.OID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getVisitorsbyToday(PRReq objPRReq)
        {
            string s = "SELECT * FROM Security_tbl_Visitors WHERE Dated>='" + objPRReq.LastDate + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getVisitorsbyDates(PRReq objPRReq)
        {
            string s = "SELECT * FROM Security_tbl_Visitors WHERE CONVERT(DATETIME,'" + objPRReq.LastDate + "')>=Dated AND CONVERT(DATETIME,'" + objPRReq.FromDate + "')<=Dated";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp SearchVisitorsbyDates(PRReq objPRReq)
        {
            string s = "SELECT * FROM Security_tbl_Visitors WHERE (VehicleType like '%" + objPRReq.VehicleNumber + "%' or VehicleName  like '%" + objPRReq.VehicleNumber + "%' or Purpose like '%" + objPRReq.VehicleNumber + "%') and CONVERT(DATETIME,'" + objPRReq.EndDate + "')>=Dated  and CONVERT(DATETIME,'" + objPRReq.StartDate + "')<=Dated  order by Dated asc ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getTodaysVisitors(PRReq objPRReq)
        {
            string s = "select * from Security_tbl_Visitors where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and Flag1='" + objPRReq.Flag1 + "' and Dated >=  DateAdd(d, Datediff(d,1, current_timestamp), 1) and Dated < DateAdd(d, Datediff(d,0, current_timestamp), 1); ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getTodaysVisitorsFlag(PRReq objPRReq)
        {
            string s = "select * from Security_tbl_Visitors where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and Flag1='" + objPRReq.Flag1 + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getTodaysVisitorsbyDVID(PRReq objPRReq)
        {
            string s = "select * from Security_tbl_Visitors where OID='" + objPRReq.OID + "' and DVID='" + objPRReq.DVID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getTodaysVisitorsbyDates(PRReq objPRReq)
        {
            string s = "select distinct VisitorType from Security_tbl_Visitors where OID='" + objPRReq.OID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getTodaysVisitorsbyVT(PRReq objPRReq)
        {
            string s = "select count(VisitorType) as count from Security_tbl_Visitors where OID='" + objPRReq.OID + "' and VisitorType='" + objPRReq.VisitorType + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp ReleaseVCardNoforVisitor(PRReq objPRReq)
        {
            string update = "update Security_tbl_Visitors  set Flag1='" + objPRReq.Flag1 + "', Status='" + objPRReq.Status + "', RUID='" + objPRReq.RUID + "', RUName='" + objPRReq.RUName + "', RUDate='" + objPRReq.Dated + "' where OID='" + objPRReq.OID + "' and VCardNo='" + objPRReq.VCardNo + "' and Flag1='1' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp getVisitorbyToday(PRReq objPRReq)
        {
            string s = "select * from Security_tbl_Visitors where OID='" + objPRReq.OID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        // Temp Emp Issue Items Indent
        public PRResp getTempApprovedIndentsbyRIndentandSTID(PRReq objPRReq)
        {
            string s = "select * from Store_tbl_TAEmpIndent where OID='" + objPRReq.OID + "' and STID='" + objPRReq.STID + "' and ITID='" + objPRReq.ITID + "' and RIndentNo='" + objPRReq.RIndentNo + "' and UID='" + objPRReq.UID + "' and EmpID='" + objPRReq.EmpID + "' and  BatchNo='" + objPRReq.BatchNo + "' and IMID='" + objPRReq.IMID + "' and ICID='" + objPRReq.ICID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp AddTAItemtoIssue(PRReq objPRReq)
        {
            string insert = "insert into Store_tbl_TAEmpIndent (EIID,RIndentNo,OID,EID,EmpID,DID,DeptID,Name,Email,Mobile,SPID,Purpose,PCode,PTitle,ICID,ItemCategory,STID,ITID,ItemName,ItemType,IMID,Manufacturer,PurchaseOrderNo,PurchaseDate,FileNo,BatchNo,Quantity,Rate,UnitCost,RQuantity,AQuantity,APrice,Status,UID,UName,ReqDate,Dated) values('" + objPRReq.EIID + "','" + objPRReq.RIndentNo + "','" + objPRReq.OID + "','" + objPRReq.EID + "','" + objPRReq.EmpID + "','" + objPRReq.DID + "','" + objPRReq.DeptID + "','" + objPRReq.Name + "','" + objPRReq.Email + "','" + objPRReq.Mobile + "','" + objPRReq.SPID + "','" + objPRReq.Purpose + "','" + objPRReq.PCode + "','" + objPRReq.PTitle + "','" + objPRReq.ICID + "','" + objPRReq.ItemCategory + "','" + objPRReq.STID + "','" + objPRReq.ITID + "','" + objPRReq.ItemName + "','" + objPRReq.ItemType + "','" + objPRReq.IMID + "','" + objPRReq.Manufacturer + "','" + objPRReq.PONo + "','" + objPRReq.PurchaseDate + "','" + objPRReq.FileNo + "','" + objPRReq.BatchNo + "','" + objPRReq.Quantity + "','" + objPRReq.Rate + "','" + objPRReq.UnitCost + "','" + objPRReq.RQuantity + "','" + objPRReq.AQuantity + "','" + objPRReq.APrice + "','" + objPRReq.Status + "','" + objPRReq.UID + "','" + objPRReq.UName + "','" + objPRReq.ReqDate + "','" + objPRReq.Dated + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }

        public PRResp getAllTempAIndentsbyRIndents(PRReq objPRReq)
        {
            string s = "select * from Store_tbl_TAEmpIndent where OID='" + objPRReq.OID + "' and RIndentNo='" + objPRReq.RIndentNo + "' and UID='" + objPRReq.UID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllApprovedTempItemsbyUID(PRReq objPRReq)
        {
            string s = "select * from Store_tbl_TAEmpIndent where (UID='" + objPRReq.UID + "' or EmpID='" + objPRReq.EmpID + "') and Status!='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp DelItembyTAEIID(PRReq objPRReq)
        {
            string hod = "delete from Store_tbl_TAEmpIndent where  OID='" + objPRReq.OID + "' and TAEIID='" + objPRReq.TAEIID + "' and UID='" + objPRReq.UID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }

        public PRResp AddFinalApprovedItemtoIssue(PRReq objPRReq)
        {
            string insert = "insert into Store_tbl_FinalApprovedEmpIndent (TAEIID,ISNo,AIndentNo,AQRCode,EIID,RIndentNo,OID,EID,EmpID,DID,DeptID,Name,Email,Mobile,SPID,Purpose,PCode,PTitle,ICID,ItemCategory,STID,ITID,ItemName,ItemType,IMID,Manufacturer,PurchaseOrderNo,PurchaseDate,FileNo,BatchNo,Quantity,Rate,UnitCost,RQuantity,AQuantity,APrice,Status,UID,UName,ReqDate,IssuedDate) values('" + objPRReq.TAEIID + "','" + objPRReq.ISNo + "','" + objPRReq.ApprvdIndentNo + "','" + objPRReq.AQRCode + "','" + objPRReq.EIID + "','" + objPRReq.RIndentNo + "','" + objPRReq.OID + "','" + objPRReq.EID + "','" + objPRReq.EmpID + "','" + objPRReq.DID + "','" + objPRReq.DeptID + "','" + objPRReq.Name + "','" + objPRReq.Email + "','" + objPRReq.Mobile + "','" + objPRReq.SPID + "','" + objPRReq.Purpose + "','" + objPRReq.PCode + "','" + objPRReq.PTitle + "','" + objPRReq.ICID + "','" + objPRReq.ItemCategory + "','" + objPRReq.STID + "','" + objPRReq.ITID + "','" + objPRReq.ItemName + "','" + objPRReq.ItemType + "','" + objPRReq.IMID + "','" + objPRReq.Manufacturer + "','" + objPRReq.PONo + "','" + objPRReq.PurchaseDate + "','" + objPRReq.FileNo + "','" + objPRReq.BatchNo + "','" + objPRReq.Quantity + "','" + objPRReq.Rate + "','" + objPRReq.UnitCost + "','" + objPRReq.RQuantity + "','" + objPRReq.AQuantity + "','" + objPRReq.APrice + "','" + objPRReq.Status + "','" + objPRReq.UID + "','" + objPRReq.UName + "','" + objPRReq.ReqDate + "','" + objPRReq.IssuedDate + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getEAISNo(PRReq objPRReq)
        {
            string s = "select max(" + objPRReq.ColumnName + ") from Store_tbl_FinalApprovedEmpIndent where OID='" + objPRReq.OID + "' and Status!='" + objPRReq.Status + "' ";
            objPRResp.SingleValue = Connections.GetSingleValue(s);
            return objPRResp;
        }
        public PRResp SendMail2ApprovedIndentssbyStore(PRReq objPRReq)
        {
            string s = "select * from Store_tbl_FinalApprovedEmpIndent where  Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and AIndentNo='" + objPRReq.ApprvdIndentNo + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp SendMail2ReqIndentssbyStore(PRReq objPRReq)
        {
            string s = "select * from Store_tbl_EmpIndent where  Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and RIndentNo='" + objPRReq.RIndentNo + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp UpdateApprvedStatusofRIndent(PRReq objPRReq)
        {
            string update = "update Store_tbl_EmpIndent  set Flag1='" + objPRReq.Flag1 + "', Status='" + objPRReq.Status + "', IssuedDate='" + objPRReq.IssuedDate + "' where OID='" + objPRReq.OID + "' and EIID='" + objPRReq.EIID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp UpdateStoreStockRate(PRReq objPRReq)
        {
            string update = "update Store_tbl_StoreStock set Rate='" + objPRReq.Rate + "' where OID='" + objPRReq.OID + "' and ICID='" + objPRReq.ICID + "' and ITID='" + objPRReq.ITID + "' and IMID='" + objPRReq.IMID + "' and VID='" + objPRReq.VID + "' and BatchNo='" + objPRReq.BatchNo + "' and FileNo='" + objPRReq.FileNo + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp getStoreClosingStock(PRReq objPRReq)
        {
            string s = "select * from Store_tbl_StoreStock where  Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and Quantity>0 ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllApprovedIndentssbyStore(PRReq objPRReq)
        {
            string s = "select distinct PTitle,PCode,Purpose,RIndentNo,ReqDate,Status,Name,Email,Mobile,AIndentNo,IssuedDate,DeptID from Store_tbl_FinalApprovedEmpIndent where  Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' order by AIndentNo Desc ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllApprovedIndentssbyStore_IndentNo(PRReq objPRReq)
        {
            string s = "select distinct PTitle,PCode,Purpose,RIndentNo,ReqDate,Status,Name,Email,Mobile,AIndentNo,IssuedDate,DeptID from Store_tbl_FinalApprovedEmpIndent where  Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and (RIndentNo='" + objPRReq.IndentNo + "' or AIndentNo='" + objPRReq.IndentNo + "') ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllApprovedIndentssbyStore_byDates(PRReq objPRReq)
        {
            string s = "select distinct PTitle,PCode,Purpose,RIndentNo,ReqDate,Status,Name,Email,Mobile,AIndentNo,IssuedDate,DeptID from Store_tbl_FinalApprovedEmpIndent where  Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and  IssuedDate >='" + objPRReq.StartDate + "' and IssuedDate<='" + objPRReq.EndDate + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllApprovedIndentssbyStore_byEmpID(PRReq objPRReq)
        {
            string s = "select distinct PTitle,PCode,Purpose,RIndentNo,ReqDate,Status,Name,Email,Mobile,AIndentNo,IssuedDate,DeptID from Store_tbl_FinalApprovedEmpIndent where  Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' order by AIndentNo Desc ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllApprovedIndentssbyStoreItemsCount(PRReq objPRReq)
        {
            string s = "select Count(AIndentNo) as icount from Store_tbl_FinalApprovedEmpIndent where  Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and AIndentNo='" + objPRReq.ApprvdIndentNo + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        // Guest Houses 

        //House Types
        public PRResp getHTypes(PRReq objPRReq)
        {
            string s = "select * from GH_tbl_HTypes where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp AddHType(PRReq objPRReq)
        {
            string insert = "insert into GH_tbl_HTypes (OID,HName,Status) values('" + objPRReq.OID + "','" + objPRReq.HType + "','" + objPRReq.Status + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getHTypeByName(PRReq objPRReq)
        {
            string s = "select * from GH_tbl_HTypes where HName='" + objPRReq.HType + "' and OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getHTypeByGHID(PRReq objPRReq)
        {
            string s = "select * from GH_tbl_HTypes where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and GHID='" + objPRReq.GHID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp EditHTypeByGHID(PRReq objPRReq)
        {
            string update = "update GH_tbl_HTypes set HName='" + objPRReq.HType + "' where OID='" + objPRReq.OID + "' and GHID='" + objPRReq.GHID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp DelHType(PRReq objPRReq)
        {
            string hod = "delete from GH_tbl_HTypes where  OID='" + objPRReq.OID + "' and GHID='" + objPRReq.GHID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }
        public PRResp HTypeSearch(PRReq objPRReq)
        {
            string s = "select * from GH_tbl_HTypes where HType like '%" + objPRReq.HType + "%' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        //Floor Types
        public PRResp getHFloors(PRReq objPRReq)
        {
            string s = "select * from GH_tbl_HFloors where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp AddHFloor(PRReq objPRReq)
        {
            string insert = "insert into GH_tbl_HFloors (OID,HFloor,Status) values('" + objPRReq.OID + "','" + objPRReq.HFloor + "','" + objPRReq.Status + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getHFloorByName(PRReq objPRReq)
        {
            string s = "select * from GH_tbl_HFloors where HFloor='" + objPRReq.HFloor + "' and OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getHFloorByHFID(PRReq objPRReq)
        {
            string s = "select * from GH_tbl_HFloors where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and HFID='" + objPRReq.HFID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp EditHFloorByHFID(PRReq objPRReq)
        {
            string update = "update GH_tbl_HFloors set HFloor='" + objPRReq.HFloor + "' where OID='" + objPRReq.OID + "' and HFID='" + objPRReq.HFID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp DelHFloor(PRReq objPRReq)
        {
            string hod = "delete from GH_tbl_HFloors where  OID='" + objPRReq.OID + "' and HFID='" + objPRReq.HFID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }
        public PRResp HFloorSearch(PRReq objPRReq)
        {
            string s = "select * from GH_tbl_HFloors where HFloor like '%" + objPRReq.HFloor + "%' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        //Room Types
        public PRResp getRoomTypes(PRReq objPRReq)
        {
            string s = "select * from GH_tbl_RoomTypes where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp AddRoomType(PRReq objPRReq)
        {
            string insert = "insert into GH_tbl_RoomTypes (OID,RoomType,Status) values('" + objPRReq.OID + "','" + objPRReq.RoomType + "','" + objPRReq.Status + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getRoomTypeByName(PRReq objPRReq)
        {
            string s = "select * from GH_tbl_RoomTypes where RoomType='" + objPRReq.RoomType + "' and OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getRoomTypeByRTID(PRReq objPRReq)
        {
            string s = "select * from GH_tbl_RoomTypes where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and RTID='" + objPRReq.RTID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp EditRoomTypeByRTID(PRReq objPRReq)
        {
            string update = "update GH_tbl_RoomTypes set RoomType='" + objPRReq.RoomType + "' where OID='" + objPRReq.OID + "' and RTID='" + objPRReq.RTID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp DelRoomType(PRReq objPRReq)
        {
            string hod = "delete from GH_tbl_RoomTypes where  OID='" + objPRReq.OID + "' and RTID='" + objPRReq.RTID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }
        public PRResp RoomTypeSearch(PRReq objPRReq)
        {
            string s = "select * from GH_tbl_RoomTypes where RoomType like '%" + objPRReq.RoomType + "%' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        // RoomNo

        public PRResp getAllRoomNos(PRReq objPRReq)
        {
            string s = "select * from GH_tbl_RoomNo where OID='" + objPRReq.OID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp AddRoomNo(PRReq objPRReq)
        {
            string insert = "insert into GH_tbl_RoomNo (OID,GHID,HName,HFID,HFloor,RTID,RoomType,RoomNo,Status) values('" + objPRReq.OID + "','" + objPRReq.GHID + "','" + objPRReq.HType + "','" + objPRReq.HFID + "','" + objPRReq.HFloor + "','" + objPRReq.RTID + "','" + objPRReq.RoomType + "','" + objPRReq.RoomNo + "','" + objPRReq.Status + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }

        public PRResp getRegisteredRoomNo(PRReq objPRReq)
        {
            string s = "select * from GH_tbl_RoomNo where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and GHID='" + objPRReq.GHID + "' and HFID='" + objPRReq.HFID + "' and RTID='" + objPRReq.RTID + "' and RoomNo='" + objPRReq.RoomNo + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp EditRoomNoByHRID(PRReq objPRReq)
        {
            string update = "update GH_tbl_RoomNo set RoomNo='" + objPRReq.RoomNo + "' where OID='" + objPRReq.OID + "' and RTID='" + objPRReq.RTID + "' and GHID='" + objPRReq.GHID + "' and HFID='" + objPRReq.HFID + "' and Status='" + objPRReq.Status + "' and HRID='" + objPRReq.HRID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp DelHRoomNo(PRReq objPRReq)
        {
            string hod = "delete from GH_tbl_RoomNo where  OID='" + objPRReq.OID + "' and HRID='" + objPRReq.HRID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }

        public PRResp getFloor_Room_HostelInfo(PRReq objPRReq)
        {
            string s = "select distinct HFID,HFloor from GH_tbl_RoomNo where OID='" + objPRReq.OID + "' and GHID='" + objPRReq.GHID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp getAllRoomNosbyHFID(PRReq objPRReq)
        {
            string s = "select * from GH_tbl_RoomNo where OID='" + objPRReq.OID + "' and HFID='" + objPRReq.HFID + "' and GHID='" + objPRReq.GHID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        // New Monthly Salary Generation
        public PRResp NewMonthlySalaryStmtGeneration(PRReq objPRReq)
        {
            string insert = "insert into PR_tbl_Employee_Monthly_Salary (Month,Year,EID,OID,ETID,EmpType,ECID,EmpCategory,EGID,EmpGroup,DID,DeptID,DSID,Design,EmpID,Name,Email,Mobile,Aadhar,DOB,DOJ,DOR,Gender,PAN,BankAcType,BankName,BankBranch,BankAccNo,IFSCCode,Photo,PSID,PayScale,PPB,GRP,BasicPay,PayLevel,DA,TRAEligible,TRA,TRGEligible,TRGA,NPAEligible,NPA,PFAccType,PFAccNo,PHCStatus,QuarterAllotted,RentFreeAccom,HRA,OTPay,SpecialDutyAllowances,PatientCareAllowances,BookAllowances,SCA,WashingAllowances,DPAType,DPA,SumptuaryAllowances,OtherAllowances,Arrears,StaffBus,GrossPay,GrossPayWords,DaysInMonth,LOPDays,LOPAmount,LOPPPB,LOPGRP,LOPBasicPay,LOPDA,LOPHRA,LOPTRA,LOPGrossPay,LOPGrossPayInwords,GPF,CPF,NPS,PFA,MS,SF,GC,QR,EC,WC,BF,LIC,GI,IT,PT,SC,HBA_NIRD,HBA_HDFC,HBA_Others,HBA_Adv_Int,INTA,TA,CABTV,VA,VAI,BL,CDLNO,PLI,COMPL,COMPLInt,Others,BFA,BFAI,CourtAt,HC,TotDeductions,NetPay,NetPayInWords,Status,UID,UName,Dated) values('" + objPRReq.Month + "','" + objPRReq.Year + "','" + objPRReq.EID + "','" + objPRReq.OID + "','" + objPRReq.ETID + "','" + objPRReq.EmpType + "','" + objPRReq.ECID + "','" + objPRReq.EmpCategory + "','" + objPRReq.EGID + "','" + objPRReq.EmpGroup + "','" + objPRReq.DID + "','" + objPRReq.DeptID + "','" + objPRReq.DSID + "','" + objPRReq.Design + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.Email + "','" + objPRReq.Mobile + "','" + objPRReq.Aadhar + "','" + objPRReq.DOB + "','" + objPRReq.DOJ + "','" + objPRReq.DOR + "','" + objPRReq.Gender + "','" + objPRReq.PAN + "','" + objPRReq.BankAcType + "','" + objPRReq.BankName + "','" + objPRReq.BankBranchName + "','" + objPRReq.BankAccNo + "','" + objPRReq.IFSCCode + "','" + objPRReq.Photo + "','" + objPRReq.PSID + "','" + objPRReq.Payscale + "','" + objPRReq.PPB + "','" + objPRReq.GradePay + "','" + objPRReq.BasicPay + "','" + objPRReq.PayLevel + "','" + objPRReq.DA + "','" + objPRReq.TRAEligible + "','" + objPRReq.TRA + "','" + objPRReq.TRGEligible + "','" + objPRReq.TRGA + "','" + objPRReq.NPAEligible + "','" + objPRReq.NPA + "','" + objPRReq.PFAccType + "','" + objPRReq.PFAccNo + "','" + objPRReq.PHCStatus + "','" + objPRReq.QuarterAllotted + "','" + objPRReq.RentFreeAccom + "','" + objPRReq.HRA + "','" + objPRReq.OTPay + "','" + objPRReq.SpecialDutyAllow + "','" + objPRReq.PatientCareAllow + "','" + objPRReq.BookAllow + "','" + objPRReq.SCA + "','" + objPRReq.WashingAllow + "','" + objPRReq.DPAType + "','" + objPRReq.DPA + "','" + objPRReq.SumptuaryAllow + "','" + objPRReq.OtherAllow + "','" + objPRReq.Arrears + "','" + objPRReq.StaffBus + "','" + objPRReq.GrossSal + "','" + objPRReq.GrossSalWords + "','" + objPRReq.DaysInMonth + "','" + objPRReq.LopDays + "','" + objPRReq.LopAmount + "','" + objPRReq.LOPPPB + "','" + objPRReq.LOPGRP + "','" + objPRReq.LOPBasicPay + "','" + objPRReq.LOPDA + "','" + objPRReq.LOPHRA + "','" + objPRReq.LOPTRA + "','" + objPRReq.LOPGrossPay + "','" + objPRReq.LopGrossPayinWords + "','" + objPRReq.GPF + "','" + objPRReq.CPF + "','" + objPRReq.NPS + "','" + objPRReq.PFA + "','" + objPRReq.MS + "','" + objPRReq.SF + "','" + objPRReq.GC + "','" + objPRReq.QR + "','" + objPRReq.EC + "','" + objPRReq.WC + "','" + objPRReq.BF + "','" + objPRReq.LIC + "','" + objPRReq.GI + "','" + objPRReq.IT + "','" + objPRReq.PT + "','" + objPRReq.SC + "','" + objPRReq.HBA_NIRD + "','" + objPRReq.HBA_HDFC + "','" + objPRReq.HBA_Others + "','" + objPRReq.HBA_Adv_Int + "','" + objPRReq.INTA + "','" + objPRReq.TAdv + "','" + objPRReq.CabTV + "','" + objPRReq.VAdv + "','" + objPRReq.VAdvInt + "','" + objPRReq.BankLoan + "','" + objPRReq.CDLNo + "','" + objPRReq.PLI + "','" + objPRReq.CompL + "','" + objPRReq.CompLInt + "','" + objPRReq.Others + "','" + objPRReq.BFA + "','" + objPRReq.BFAInt + "','" + objPRReq.CourtAt + "','" + objPRReq.HC + "','" + objPRReq.TotDeductions + "','" + objPRReq.NetPay + "','" + objPRReq.NetPayInWords + "','" + objPRReq.Status + "','" + objPRReq.UID + "','" + objPRReq.UName + "','" + objPRReq.Dated + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getMonthYearForMailPayslips(PRReq objPRReq)
        {
            string s = "select distinct Month,Year from PR_tbl_Employee_Monthly_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getOldMonthForMailPayslips(PRReq objPRReq)
        {
            string s = "select distinct Month from PR_tbl_Employee_Monthly_BackupSalary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getCurrentMonthForMailPayslips(PRReq objPRReq)
        {
            string s = "select distinct Month from PR_tbl_Employee_Monthly_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getCurrentYearForMailPayslips(PRReq objPRReq)
        {
            string s = "select distinct Year from PR_tbl_Employee_Monthly_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getOldEmpPayslips(PRReq objPRReq)
        {
            string s = "select distinct EMBSID,Month,Year,GrossPay,LOPGrossPay,TotDeductions,NetPay from PR_tbl_Employee_Monthly_BackupSalary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getOldEmpPayslipsByEMBSID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Employee_Monthly_BackupSalary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' and EMBSID='" + objPRReq.EMBSID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getOldYearForMailPayslips(PRReq objPRReq)
        {
            string s = "select distinct Year from PR_tbl_Employee_Monthly_BackupSalary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getOldMonthlyPayDetails(PRReq objPRReq)
        {
            string s = "select distinct Month,Year,Dated from PR_tbl_Employee_Monthly_BackupSalary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getOldMonthlyPayDetails_DG(PRReq objPRReq)
        {
            string s = "select distinct Month,Year,Dated from PR_tbl_Employee_Monthly_BackupSalary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and (CONVERT(DATETIME,'" + objPRReq.ToDate + "')>=Dated AND CONVERT(DATETIME,'" + objPRReq.FromDate + "')<=Dated) order by Dated Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getOldMonthlySumOfGross(PRReq objPRReq)
        {
            string s = "select sum(LOPGrossPay) as tGross from PR_tbl_Employee_Monthly_BackupSalary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and Month='" + objPRReq.Month + "' and Year='" + objPRReq.Year + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getOldMonthlySumOfGross_DG(PRReq objPRReq)
        {
            string s = "select sum(LOPGrossPay) as tGross from PR_tbl_Employee_Monthly_BackupSalary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and Month='" + objPRReq.Month + "' and Year='" + objPRReq.Year + "' and (CONVERT(DATETIME,'" + objPRReq.ToDate + "')>=Dated AND CONVERT(DATETIME,'" + objPRReq.FromDate + "')<=Dated)";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getOldMonthlySumOfDeductions(PRReq objPRReq)
        {
            string s = "select sum(TotDeductions) as tdedu from PR_tbl_Employee_Monthly_BackupSalary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and Month='" + objPRReq.Month + "' and Year='" + objPRReq.Year + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getOldMonthlySumOfDeductions_DG(PRReq objPRReq)
        {
            string s = "select sum(TotDeductions) as tdedu from PR_tbl_Employee_Monthly_BackupSalary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and Month='" + objPRReq.Month + "' and Year='" + objPRReq.Year + "' and (CONVERT(DATETIME,'" + objPRReq.ToDate + "')>=Dated AND CONVERT(DATETIME,'" + objPRReq.FromDate + "')<=Dated)";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getOldMonthlySumOfNetPays(PRReq objPRReq)
        {
            string s = "select sum(NetPay) as tnetPay from PR_tbl_Employee_Monthly_BackupSalary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and Month='" + objPRReq.Month + "' and Year='" + objPRReq.Year + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getOldMonthlySumOfNetPays_DG(PRReq objPRReq)
        {
            string s = "select sum(NetPay) as tnetPay from PR_tbl_Employee_Monthly_BackupSalary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and Month='" + objPRReq.Month + "' and Year='" + objPRReq.Year + "' and (CONVERT(DATETIME,'" + objPRReq.ToDate + "')>=Dated AND CONVERT(DATETIME,'" + objPRReq.FromDate + "')<=Dated)";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getIndivMailPayslips(PRReq objPRReq)
        {
            string s = "select distinct * from PR_tbl_Employee_Monthly_BackupSalary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' and Month='" + objPRReq.Month + "' and Year='" + objPRReq.Year + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getCurrentIndivMailPayslips(PRReq objPRReq)
        {
            string s = "select distinct * from PR_tbl_Employee_Monthly_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' and Month='" + objPRReq.Month + "' and Year='" + objPRReq.Year + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getCurrentIndivMailPayslips_EmpID(PRReq objPRReq)
        {
            string s = "select distinct * from PR_tbl_Employee_Monthly_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllPayslipsforNewMonth(PRReq objPRReq)
        {
            string s = "select distinct * from PR_tbl_Employee_Monthly_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getCurrentMonthIndivMailPayslips(PRReq objPRReq)
        {
            string s = "select distinct * from PR_tbl_Employee_Monthly_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' and Month='" + objPRReq.Month + "' and Year='" + objPRReq.Year + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp SendMailPayslips(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Employee_Monthly_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and Month='" + objPRReq.Month + "' and Year='" + objPRReq.Year + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        //Backup Sal
        public PRResp getPEmployee_Monthly_Salary(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Employee_Monthly_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp GetAllPEmployee_Monthly_Salary(PRReq objPRReq)
        {
            string s = "SELECT * FROM PR_tbl_Employee_Monthly_BackupSalary where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and Month='" + objPRReq.Month + "' and Year='" + objPRReq.Year + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp AddBackUp_Monthly_Emp_Sal(PRReq objPRReq)
        {
            string s = "insert into PR_tbl_Employee_Monthly_BackupSalary select * from PR_tbl_Employee_Monthly_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' ";
            objPRResp.Count = Connections.ProcessQuery(s);
            return objPRResp;
        }
        public PRResp TruncatePR_tbl_Employee_Monthly_Salary()
        {
            string s = "truncate table PR_tbl_Employee_Monthly_Salary  ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmp_MonthlySalayByEmpID_UID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Employee_Master_Salary where OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' and UID='" + objPRReq.UID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getActiveRegEmployeeByEmpID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Employee where OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getActiveRegEmployeeBy_EmpID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Employee where OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getActiveRegularEmployeeByEmpID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Employee where OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmp_MonthlySalayByEmpID_Status(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Employee_Master_Salary where OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmp_MonthlySalayByHead_Status(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Employee where OID='" + objPRReq.OID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpMonthlySalayByEmpID_UID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Employee_Monthly_Salary where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' and UID='" + objPRReq.UID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpMonthYearofSalary_UID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Employee_Monthly_Salary where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpMonthlySalByEmpID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Employee_Monthly_Salary where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp UpdateMonthlySalaryforNewMonth(PRReq objPRReq)
        {
            string update = "update PR_tbl_Employee_Monthly_Salary set TRA='" + objPRReq.TRA + "', Month='" + objPRReq.Month + "',Year='" + objPRReq.Year + "',EID='" + objPRReq.EID + "',ETID='" + objPRReq.ETID + "',EmpType='" + objPRReq.EmpType + "',ECID='" + objPRReq.ECID + "',EmpCategory='" + objPRReq.EmpCategory + "',EGID='" + objPRReq.EGID + "',EmpGroup='" + objPRReq.EmpGroup + "',DID='" + objPRReq.DID + "',DeptID='" + objPRReq.DeptID + "',DSID='" + objPRReq.DSID + "',Design='" + objPRReq.Design + "',Name='" + objPRReq.Name + "',Email='" + objPRReq.Email + "',Mobile='" + objPRReq.Mobile + "',Aadhar='" + objPRReq.Aadhar + "',DOB='" + objPRReq.DOB + "',DOJ='" + objPRReq.DOJ + "',DOR='" + objPRReq.DOR + "',Gender='" + objPRReq.Gender + "',PAN='" + objPRReq.PAN + "',BankAcType='" + objPRReq.BankAcType + "',BankName='" + objPRReq.BankName + "',BankBranch='" + objPRReq.BankBranchName + "',BankAccNo='" + objPRReq.BankAccNo + "',IFSCCode='" + objPRReq.IFSCCode + "',Photo='" + objPRReq.Photo + "',PSID='" + objPRReq.PSID + "',PayScale='" + objPRReq.Payscale + "',PPB='" + objPRReq.PPB + "',GRP='" + objPRReq.GradePay + "',BasicPay='" + objPRReq.BasicPay + "',PayLevel='" + objPRReq.PayLevel + "',DA='" + objPRReq.DA + "',TRAEligible='" + objPRReq.TRAEligible + "',TRA='" + objPRReq.TRA + "',TRGEligible='" + objPRReq.TRGEligible + "',TRGA='" + objPRReq.TRGA + "',NPAEligible='" + objPRReq.NPAEligible + "',NPA='" + objPRReq.NPA + "',PFAccType='" + objPRReq.PFAccType + "',PFAccNo='" + objPRReq.PFAccNo + "',PHCStatus='" + objPRReq.PHCStatus + "',QuarterAllotted='" + objPRReq.QuarterAllotted + "',RentFreeAccom='" + objPRReq.RentFreeAccom + "',HRA='" + objPRReq.HRA + "',OTPay='" + objPRReq.OTPay + "',SpecialDutyAllowances='" + objPRReq.SA + "',PatientCareAllowances='" + objPRReq.PCA + "',BookAllowances='" + objPRReq.BA + "',SCA='" + objPRReq.SCA + "',WashingAllowances='" + objPRReq.WA + "',DPAType='" + objPRReq.DPAType + "',DPA='" + objPRReq.DPA + "',SumptuaryAllowances='" + objPRReq.SumptuaryAllow + "',OtherAllowances='" + objPRReq.OtherAllow + "',Arrears='" + objPRReq.Arrears + "',StaffBus='" + objPRReq.StaffBus + "',GrossPay='" + objPRReq.GrossSal + "',GrossPayWords='" + objPRReq.GrossSalWords + "',DaysInMonth='" + objPRReq.DaysInMonth + "',LOPDays='" + objPRReq.LopDays + "',LOPAmount='" + objPRReq.LopAmount + "'  where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }

        public PRResp UpdateMasterSalaryDeductions(PRReq objPRReq)
        {
            string update = "update PR_tbl_Employee_Master_Salary set  PayLevel='" + objPRReq.PayLevel + "',TRA='" + objPRReq.TRA + "', TRGA='" + objPRReq.TRGA + "',NPA='" + objPRReq.NPA + "',OTPay='" + objPRReq.OTPay + "',SpecialDutyAllowances='" + objPRReq.SDA + "',PatientCareAllowances='" + objPRReq.PCA + "',DPA='" + objPRReq.DPA + "',SCA='" + objPRReq.SCA + "',BookAllowances='" + objPRReq.BA + "',WashingAllowances='" + objPRReq.WA + "',SumptuaryAllowances='" + objPRReq.SA + "',OtherAllowances='" + objPRReq.OtherAllow + "',Arrears='" + objPRReq.Arrears + "',PFAccNo='" + objPRReq.PFAccNo + "',GrossPayWords='" + objPRReq.GrossSalWords + "',DaysInMonth='" + objPRReq.DaysInMonth + "',LOPDays='" + objPRReq.LopDays + "',LOPAmount='" + objPRReq.LopAmount + "',LOPPPB='" + objPRReq.LOPPPB + "',LOPGRP='" + objPRReq.LOPGRP + "',LOPBasicPay='" + objPRReq.LOPBasicPay + "',LOPDA='" + objPRReq.LOPDA + "',LOPHRA='" + objPRReq.LOPHRA + "',LOPTRA='" + objPRReq.LOPTRA + "',LOPGrossPay='" + objPRReq.LOPGrossPay + "',GPF='" + objPRReq.GPF + "',CPF='" + objPRReq.CPF + "',NPS='" + objPRReq.NPS + "',PFA='" + objPRReq.PFA + "',MS='" + objPRReq.MS + "',SF='" + objPRReq.SF + "',GC='" + objPRReq.GC + "',QR='" + objPRReq.QR + "',EC='" + objPRReq.EC + "',WC='" + objPRReq.WC + "',BF='" + objPRReq.BF + "',LIC='" + objPRReq.LIC + "',GI='" + objPRReq.GI + "',IT='" + objPRReq.IT + "',PT='" + objPRReq.PT + "',SC='" + objPRReq.SC + "',HBA_NIRD='" + objPRReq.HBA_NIRD + "',HBA_HDFC='" + objPRReq.HBA_HDFC + "',HBA_Others='" + objPRReq.HBA_Others + "',HBA_Adv_Int='" + objPRReq.HBA_Adv_Int + "',INTA='" + objPRReq.INTA + "',TA='" + objPRReq.TA + "',CABTV='" + objPRReq.CabTV + "',VA='" + objPRReq.VAdv + "',VAI='" + objPRReq.VAdvInt + "',BL='" + objPRReq.BankLoan + "',CDLNO='" + objPRReq.CDLNo + "',PLI='" + objPRReq.PLI + "',COMPL='" + objPRReq.CompL + "',COMPLInt='" + objPRReq.CompLInt + "',Others='" + objPRReq.Others + "',BFA='" + objPRReq.BFA + "',BFAI='" + objPRReq.BFAInt + "',CourtAt='" + objPRReq.CourtAt + "',HC='" + objPRReq.HC + "',TotDeductions='" + objPRReq.TotDeductions + "',NetPay='" + objPRReq.NetPay + "',NetPayInWords='" + objPRReq.NetPayInWords + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' and UID='" + objPRReq.UID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }

        public PRResp UpdateMonthlySalaryDeductions(PRReq objPRReq)
        {
            string update = "update PR_tbl_Employee_Monthly_Salary set  PayLevel='" + objPRReq.PayLevel + "',TRA='" + objPRReq.TRA + "', TRGA='" + objPRReq.TRGA + "',NPA='" + objPRReq.NPA + "',OTPay='" + objPRReq.OTPay + "',SpecialDutyAllowances='" + objPRReq.SDA + "',PatientCareAllowances='" + objPRReq.PCA + "',DPA='" + objPRReq.DPA + "',SCA='" + objPRReq.SCA + "',BookAllowances='" + objPRReq.BA + "',WashingAllowances='" + objPRReq.WA + "',SumptuaryAllowances='" + objPRReq.SA + "',OtherAllowances='" + objPRReq.OtherAllow + "',Arrears='" + objPRReq.Arrears + "',PFAccNo='" + objPRReq.PFAccNo + "',GrossPayWords='" + objPRReq.GrossSalWords + "',DaysInMonth='" + objPRReq.DaysInMonth + "',LOPDays='" + objPRReq.LopDays + "',LOPAmount='" + objPRReq.LopAmount + "',LOPPPB='" + objPRReq.LOPPPB + "',LOPGRP='" + objPRReq.LOPGRP + "',LOPBasicPay='" + objPRReq.LOPBasicPay + "',LOPDA='" + objPRReq.LOPDA + "',LOPHRA='" + objPRReq.LOPHRA + "',LOPTRA='" + objPRReq.LOPTRA + "',LOPGrossPay='" + objPRReq.LOPGrossPay + "',GPF='" + objPRReq.GPF + "',CPF='" + objPRReq.CPF + "',NPS='" + objPRReq.NPS + "',PFA='" + objPRReq.PFA + "',MS='" + objPRReq.MS + "',SF='" + objPRReq.SF + "',GC='" + objPRReq.GC + "',QR='" + objPRReq.QR + "',EC='" + objPRReq.EC + "',WC='" + objPRReq.WC + "',BF='" + objPRReq.BF + "',LIC='" + objPRReq.LIC + "',GI='" + objPRReq.GI + "',IT='" + objPRReq.IT + "',PT='" + objPRReq.PT + "',SC='" + objPRReq.SC + "',HBA_NIRD='" + objPRReq.HBA_NIRD + "',HBA_HDFC='" + objPRReq.HBA_HDFC + "',HBA_Others='" + objPRReq.HBA_Others + "',HBA_Adv_Int='" + objPRReq.HBA_Adv_Int + "',INTA='" + objPRReq.INTA + "',TA='" + objPRReq.TA + "',CABTV='" + objPRReq.CabTV + "',VA='" + objPRReq.VAdv + "',VAI='" + objPRReq.VAdvInt + "',BL='" + objPRReq.BankLoan + "',CDLNO='" + objPRReq.CDLNo + "',PLI='" + objPRReq.PLI + "',COMPL='" + objPRReq.CompL + "',COMPLInt='" + objPRReq.CompLInt + "',Others='" + objPRReq.Others + "',BFA='" + objPRReq.BFA + "',BFAI='" + objPRReq.BFAInt + "',CourtAt='" + objPRReq.CourtAt + "',HC='" + objPRReq.HC + "',TotDeductions='" + objPRReq.TotDeductions + "',NetPay='" + objPRReq.NetPay + "',NetPayInWords='" + objPRReq.NetPayInWords + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' and UID='" + objPRReq.UID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }

        public PRResp getEmpMonthlySalbyETID_ECID_EGID_UID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Employee_Monthly_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' and ECID='" + objPRReq.ECID + "' and EGID='" + objPRReq.EGID + "' order by EmpID ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpGIbyETID_ECID_EGID_UID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Employee_Monthly_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' and ECID='" + objPRReq.ECID + "' and EGID='" + objPRReq.EGID + "' and GI>0 order by EmpID ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpITbyETID_ECID_EGID_UID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Employee_Monthly_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' and ECID='" + objPRReq.ECID + "' and EGID='" + objPRReq.EGID + "' and IT>0 order by EmpID ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpSumOf_GI_byETID_ECID_EGID_UID(PRReq objPRReq)
        {
            string s = "select sum(GI) as GI from PR_tbl_Employee_Monthly_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' and ECID='" + objPRReq.ECID + "' and EGID='" + objPRReq.EGID + "' and GI>0 ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpSumOf_IT_byETID_ECID_EGID_UID(PRReq objPRReq)
        {
            string s = "select sum(IT) as IT from PR_tbl_Employee_Monthly_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' and ECID='" + objPRReq.ECID + "' and EGID='" + objPRReq.EGID + "' and IT>0 ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpSumOf_GrossSal_byETID_ECID_EGID_UID(PRReq objPRReq)
        {
            string s = "select sum(LOPGrossPay) as LOPGrossPay from PR_tbl_Employee_Monthly_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' and ECID='" + objPRReq.ECID + "' and EGID='" + objPRReq.EGID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpSumOf_TotDeductions_byETID_ECID_EGID_UID(PRReq objPRReq)
        {
            string s = "select sum(TotDeductions) as TotDeductions from PR_tbl_Employee_Monthly_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' and ECID='" + objPRReq.ECID + "' and EGID='" + objPRReq.EGID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpSumOf_NetPay_byETID_ECID_EGID_UID(PRReq objPRReq)
        {
            string s = "select sum(NetPay) as NetPay from PR_tbl_Employee_Monthly_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' and ECID='" + objPRReq.ECID + "' and EGID='" + objPRReq.EGID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp getExcelMonthly_SalbyETID_ECID_EGID(PRReq objPRReq)
        {
            string s = "select Month,Year,EmpCategory,EmpID,Name,LOPGrossPay,TotDeductions,NetPay from PR_tbl_Employee_Monthly_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' and ECID='" + objPRReq.ECID + "' and EGID='" + objPRReq.EGID + "' order by EmpID ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getExcelMonthly_BankSTMTbyETID_ECID_EGID(PRReq objPRReq)
        {
            string s = "select BankAccNo,Name,NetPay from PR_tbl_Employee_Monthly_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and UID='" + objPRReq.UID + "' and ECID='" + objPRReq.ECID + "' order by EmpID ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getExcelEmpLIC(PRReq objPRReq)
        {
            string s = "select EmpID,Name,PolicyNumber,PolicyAmount from PR_tbl_LICMaster where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ECID='" + objPRReq.ECID + "' order by EmpID ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getExcelEmpBL(PRReq objPRReq)
        {
            string s = "select EmpID,Name,CDLNo,LoanAmount from PR_tbl_BLMaster where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ECID='" + objPRReq.ECID + "' order by EmpID ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getOverallMonthlySummarybyOID(PRReq objPRReq)
        {
            string s = "select distinct EGID,EmpGroup,ETID,EmpType,ECID,EmpCategory,Month,Year from PR_tbl_Employee_Monthly_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' order by EmpGroup,EmpType,EmpCategory Asc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getGrossSummaryTotalbyETID_ECID_EGID(PRReq objPRReq)
        {
            string s = "select sum(LOPGrossPay) as LOPGrossPay from PR_tbl_Employee_Monthly_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' and ECID='" + objPRReq.ECID + "' and EGID='" + objPRReq.EGID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getGrossSummaryTotal_OID(PRReq objPRReq)
        {
            string s = "select sum(LOPGrossPay) as LOPGrossPay from PR_tbl_Employee_Monthly_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getTotDeduSummaryTotalbyETID_ECID_EGID(PRReq objPRReq)
        {
            string s = "select sum(TotDeductions) as TotDeductions from PR_tbl_Employee_Monthly_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' and ECID='" + objPRReq.ECID + "' and EGID='" + objPRReq.EGID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getTotDeduSummaryTotal_OID(PRReq objPRReq)
        {
            string s = "select sum(TotDeductions) as TotDeductions from PR_tbl_Employee_Monthly_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getTotNetPaySummaryTotalbyETID_ECID_EGID(PRReq objPRReq)
        {
            string s = "select sum(NetPay) as NetPay from PR_tbl_Employee_Monthly_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' and ECID='" + objPRReq.ECID + "' and EGID='" + objPRReq.EGID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getTotNetPaySummaryTotal_OID(PRReq objPRReq)
        {
            string s = "select sum(NetPay) as NetPay from PR_tbl_Employee_Monthly_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpDetailsbyUID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Employee_Monthly_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and UID='" + objPRReq.UID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        ///// Deducations summary statement

        public PRResp getTot_GPF_byETID_ECID_EGID(PRReq objPRReq)
        {
            string s = "select sum(GPF) as GPF from PR_tbl_Employee_Monthly_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' and ECID='" + objPRReq.ECID + "' and EGID='" + objPRReq.EGID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getTot_CPF_byETID_ECID_EGID(PRReq objPRReq)
        {
            string s = "select sum(CPF) as CPF from PR_tbl_Employee_Monthly_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' and ECID='" + objPRReq.ECID + "' and EGID='" + objPRReq.EGID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getTot_NPS_byETID_ECID_EGID(PRReq objPRReq)
        {
            string s = "select sum(NPS) as NPS from PR_tbl_Employee_Monthly_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' and ECID='" + objPRReq.ECID + "' and EGID='" + objPRReq.EGID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp getTot_PFA_byETID_ECID_EGID(PRReq objPRReq)
        {
            string s = "select sum(PFA) as PFA from PR_tbl_Employee_Monthly_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' and ECID='" + objPRReq.ECID + "' and EGID='" + objPRReq.EGID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getTot_MS_byETID_ECID_EGID(PRReq objPRReq)
        {
            string s = "select sum(MS) as MS from PR_tbl_Employee_Monthly_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' and ECID='" + objPRReq.ECID + "' and EGID='" + objPRReq.EGID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getTot_SF_byETID_ECID_EGID(PRReq objPRReq)
        {
            string s = "select sum(SF) as SF from PR_tbl_Employee_Monthly_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' and ECID='" + objPRReq.ECID + "' and EGID='" + objPRReq.EGID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getTot_GC_byETID_ECID_EGID(PRReq objPRReq)
        {
            string s = "select sum(GC) as GC from PR_tbl_Employee_Monthly_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' and ECID='" + objPRReq.ECID + "' and EGID='" + objPRReq.EGID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getTot_QR_byETID_ECID_EGID(PRReq objPRReq)
        {
            string s = "select sum(QR) as QR from PR_tbl_Employee_Monthly_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' and ECID='" + objPRReq.ECID + "' and EGID='" + objPRReq.EGID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getTot_EC_byETID_ECID_EGID(PRReq objPRReq)
        {
            string s = "select sum(EC) as EC from PR_tbl_Employee_Monthly_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' and ECID='" + objPRReq.ECID + "' and EGID='" + objPRReq.EGID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp getTot_WC_byETID_ECID_EGID(PRReq objPRReq)
        {
            string s = "select sum(WC) as WC from PR_tbl_Employee_Monthly_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' and ECID='" + objPRReq.ECID + "' and EGID='" + objPRReq.EGID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getTot_BF_byETID_ECID_EGID(PRReq objPRReq)
        {
            string s = "select sum(BF) as BF from PR_tbl_Employee_Monthly_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' and ECID='" + objPRReq.ECID + "' and EGID='" + objPRReq.EGID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp getTot_LIC_byETID_ECID_EGID(PRReq objPRReq)
        {
            string s = "select sum(LIC) as LIC from PR_tbl_Employee_Monthly_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' and ECID='" + objPRReq.ECID + "' and EGID='" + objPRReq.EGID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getTot_GI_byETID_ECID_EGID(PRReq objPRReq)
        {
            string s = "select sum(GI) as GI from PR_tbl_Employee_Monthly_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' and ECID='" + objPRReq.ECID + "' and EGID='" + objPRReq.EGID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getTot_IT_byETID_ECID_EGID(PRReq objPRReq)
        {
            string s = "select sum(IT) as IT from PR_tbl_Employee_Monthly_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' and ECID='" + objPRReq.ECID + "' and EGID='" + objPRReq.EGID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getTot_PT_byETID_ECID_EGID(PRReq objPRReq)
        {
            string s = "select sum(PT) as PT from PR_tbl_Employee_Monthly_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' and ECID='" + objPRReq.ECID + "' and EGID='" + objPRReq.EGID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getTot_SC_byETID_ECID_EGID(PRReq objPRReq)
        {
            string s = "select sum(SC) as SC from PR_tbl_Employee_Monthly_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' and ECID='" + objPRReq.ECID + "' and EGID='" + objPRReq.EGID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getTot_HBA_NIRD_byETID_ECID_EGID(PRReq objPRReq)
        {
            string s = "select sum(HBA_NIRD) as HBA_NIRD from PR_tbl_Employee_Monthly_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' and ECID='" + objPRReq.ECID + "' and EGID='" + objPRReq.EGID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getTot_HBA_HDFC_byETID_ECID_EGID(PRReq objPRReq)
        {
            string s = "select sum(HBA_HDFC) as HBA_HDFC from PR_tbl_Employee_Monthly_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' and ECID='" + objPRReq.ECID + "' and EGID='" + objPRReq.EGID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getTot_HBA_Others_byETID_ECID_EGID(PRReq objPRReq)
        {
            string s = "select sum(HBA_Others) as HBA_Others from PR_tbl_Employee_Monthly_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' and ECID='" + objPRReq.ECID + "' and EGID='" + objPRReq.EGID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getTot_HBA_Adv_Int_byETID_ECID_EGID(PRReq objPRReq)
        {
            string s = "select sum(HBA_Adv_Int) as HBA_Adv_Int from PR_tbl_Employee_Monthly_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' and ECID='" + objPRReq.ECID + "' and EGID='" + objPRReq.EGID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getTot_INTA_byETID_ECID_EGID(PRReq objPRReq)
        {
            string s = "select sum(INTA) as INTA from PR_tbl_Employee_Monthly_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' and ECID='" + objPRReq.ECID + "' and EGID='" + objPRReq.EGID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getTot_TA_byETID_ECID_EGID(PRReq objPRReq)
        {
            string s = "select sum(TA) as TA from PR_tbl_Employee_Monthly_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' and ECID='" + objPRReq.ECID + "' and EGID='" + objPRReq.EGID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp getTot_CABTV_byETID_ECID_EGID(PRReq objPRReq)
        {
            string s = "select sum(CABTV) as CABTV from PR_tbl_Employee_Monthly_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' and ECID='" + objPRReq.ECID + "' and EGID='" + objPRReq.EGID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getTot_VA_byETID_ECID_EGID(PRReq objPRReq)
        {
            string s = "select sum(VA) as VA from PR_tbl_Employee_Monthly_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' and ECID='" + objPRReq.ECID + "' and EGID='" + objPRReq.EGID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp getTot_VAI_byETID_ECID_EGID(PRReq objPRReq)
        {
            string s = "select sum(VAI) as VAI from PR_tbl_Employee_Monthly_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' and ECID='" + objPRReq.ECID + "' and EGID='" + objPRReq.EGID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getTot_BL_byETID_ECID_EGID(PRReq objPRReq)
        {
            string s = "select sum(BL) as BL from PR_tbl_Employee_Monthly_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' and ECID='" + objPRReq.ECID + "' and EGID='" + objPRReq.EGID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getTot_CDLNO_byETID_ECID_EGID(PRReq objPRReq)
        {
            string s = "select sum(CDLNO) as CDLNO from PR_tbl_Employee_Monthly_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' and ECID='" + objPRReq.ECID + "' and EGID='" + objPRReq.EGID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp getTot_PLI_byETID_ECID_EGID(PRReq objPRReq)
        {
            string s = "select sum(PLI) as PLI from PR_tbl_Employee_Monthly_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' and ECID='" + objPRReq.ECID + "' and EGID='" + objPRReq.EGID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getTot_COMPL_byETID_ECID_EGID(PRReq objPRReq)
        {
            string s = "select sum(COMPL) as COMPL from PR_tbl_Employee_Monthly_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' and ECID='" + objPRReq.ECID + "' and EGID='" + objPRReq.EGID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getTot_COMPLInt_byETID_ECID_EGID(PRReq objPRReq)
        {
            string s = "select sum(COMPLInt) as COMPLInt from PR_tbl_Employee_Monthly_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' and ECID='" + objPRReq.ECID + "' and EGID='" + objPRReq.EGID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getTot_Others_byETID_ECID_EGID(PRReq objPRReq)
        {
            string s = "select sum(Others) as Others from PR_tbl_Employee_Monthly_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' and ECID='" + objPRReq.ECID + "' and EGID='" + objPRReq.EGID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getTot_BFA_byETID_ECID_EGID(PRReq objPRReq)
        {
            string s = "select sum(BFA) as BFA from PR_tbl_Employee_Monthly_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' and ECID='" + objPRReq.ECID + "' and EGID='" + objPRReq.EGID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp getTot_BFAI_byETID_ECID_EGID(PRReq objPRReq)
        {
            string s = "select sum(BFAI) as BFAI from PR_tbl_Employee_Monthly_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' and ECID='" + objPRReq.ECID + "' and EGID='" + objPRReq.EGID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getTot_CourtAt_byETID_ECID_EGID(PRReq objPRReq)
        {
            string s = "select sum(CourtAt) as CourtAt from PR_tbl_Employee_Monthly_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' and ECID='" + objPRReq.ECID + "' and EGID='" + objPRReq.EGID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getTot_HC_byETID_ECID_EGID(PRReq objPRReq)
        {
            string s = "select sum(HC) as HC from PR_tbl_Employee_Monthly_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' and ECID='" + objPRReq.ECID + "' and EGID='" + objPRReq.EGID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp getTot_TotDeductions_byETID_ECID_EGID(PRReq objPRReq)
        {
            string s = "select sum(TotDeductions) as TotDeductions from PR_tbl_Employee_Monthly_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' and ECID='" + objPRReq.ECID + "' and EGID='" + objPRReq.EGID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }







        // Profession Tax

        public PRResp AddPT(PRReq objPRReq)
        {
            string s = "insert into PR_tbl_PT values('" + objPRReq.MinGSal + "','" + objPRReq.MaxGSal + "','" + objPRReq.PT + "','" + objPRReq.Status + "')";
            objPRResp.Count = Connections.ProcessQuery(s);
            return objPRResp;

        }
        public PRResp getPT(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_PT where  ProfTax='" + objPRReq.PT + "' and Min_Sal='" + objPRReq.MinGSal + "' and Max_Sal='" + objPRReq.MaxGSal + "' and Status='" + objPRReq.Status + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllPTs(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_PT where Status='" + objPRReq.Status + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getPTByID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_PT where PT_ID='" + objPRReq.PT_ID + "' and Status='" + objPRReq.Status + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp EditPTByID(PRReq objPRReq)
        {
            string s = "update PR_tbl_PT  set Min_Sal='" + objPRReq.MinGSal + "',Max_Sal='" + objPRReq.MaxGSal + "',ProfTax='" + objPRReq.PT + "'  where PT_ID='" + objPRReq.PT_ID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.Count = Connections.ProcessQuery(s);
            return objPRResp;
        }
        public PRResp DelPTByID(PRReq objPRReq)
        {
            string s = "delete from PR_tbl_PT where PT_ID='" + objPRReq.PT_ID + "' ";
            objPRResp.Count = Connections.ProcessQuery(s);
            return objPRResp;
        }


        // LIC

        public PRResp AddEmpLIC_MonthlyContribution(PRReq objPRReq)
        {
            string insert = "insert into PR_tbl_LICMonthlyContribution (Month,Year,OID,ECID,EmpCategory,EmpID,Name,PolicyNumber,PolicyAmount,Status,UID,UName,Dated) values('" + objPRReq.Month + "','" + objPRReq.Year + "','" + objPRReq.OID + "','" + objPRReq.ECID + "','" + objPRReq.EmpCategory + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.LICPolicyNumber + "','" + objPRReq.LICPolicyAmount + "','" + objPRReq.Status + "','" + objPRReq.UID + "','" + objPRReq.UName + "','" + objPRReq.Dated + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getLICPolicyContributionMonthYearBYEmpID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_LICMonthlyContribution where OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' and PolicyNumber='" + objPRReq.LICPolicyNumber + "' and PolicyAmount='" + objPRReq.LICPolicyAmount + "' and Month='" + objPRReq.Month + "' and Year='" + objPRReq.Year + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getPR_tbl_LICMonthlyContributionby_ECID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_LICMonthlyContribution where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and  ECID='" + objPRReq.ECID + "' and Month='" + objPRReq.Month + "' and Year='" + objPRReq.Year + "' order by EmpID ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getPR_tbl_LICMonthYears(PRReq objPRReq)
        {
            string s = "select distinct Month,Year from PR_tbl_LICMonthlyContribution where Status='" + objPRReq.Status + "' order by Month Asc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp DelLICMasterPLID(PRReq objPRReq)
        {
            string s = "delete from PR_tbl_LICMaster where OID='" + objPRReq.OID + "' and LPID='" + objPRReq.LPID + "' and UID='" + objPRReq.UID + "' ";
            objPRResp.Count = Connections.ProcessQuery(s);
            return objPRResp;
        }
        public PRResp getPR_tbl_LICEntryby_ECID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_LICMaster where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and  ECID='" + objPRReq.ECID + "' order by EmpID ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getPR_tbl_LICEntrySumBYECID(PRReq objPRReq)
        {
            string s = "select sum(PolicyAmount) as PolicyAmount from PR_tbl_LICMaster where OID='" + objPRReq.OID + "' and ECID='" + objPRReq.ECID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getPR_tbl_LICEntrySumEMPID(PRReq objPRReq)
        {
            string s = "select sum(PolicyAmount) as PolicyAmount from PR_tbl_LICMaster where OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' and UID='" + objPRReq.UID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getPR_tbl_LICMonthlyContributionBYECID(PRReq objPRReq)
        {
            string s = "select sum(PolicyAmount) as PolicyAmount from PR_tbl_LICMonthlyContribution where OID='" + objPRReq.OID + "' and ECID='" + objPRReq.ECID + "' and Status='" + objPRReq.Status + "' and Month='" + objPRReq.Month + "' and Year='" + objPRReq.Year + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp AddEmpLICPolicyDetails(PRReq objPRReq)
        {
            string insert = "insert into PR_tbl_LICMaster (OID,ECID,EmpCategory,EmpID,Name,PolicyNumber,PolicyAmount,Status,UID,UName,Dated) values('" + objPRReq.OID + "','" + objPRReq.ECID + "','" + objPRReq.EmpCategory + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.LICPolicyNumber + "','" + objPRReq.LICPolicyAmount + "','" + objPRReq.Status + "','" + objPRReq.UID + "','" + objPRReq.UName + "','" + objPRReq.Dated + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getLICPolicyNoBYEmpID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_LICMaster where OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' and PolicyNumber='" + objPRReq.LICPolicyNumber + "' and PolicyAmount='" + objPRReq.LICPolicyAmount + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllLICPolicyNosBYEmpID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_LICMaster where OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAll_Active_LICPolicyNosBYEmpID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_LICMaster where OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllLICPolicyTotalBYEmpID(PRReq objPRReq)
        {
            string s = "select sum(PolicyAmount) as PolicyAmount from PR_tbl_LICMaster where OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllLICPolicyNosBYLPID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_LICMaster where OID='" + objPRReq.OID + "' and LPID='" + objPRReq.LPID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp EditPolicyNosBYLPID(PRReq objPRReq)
        {
            string s = "update PR_tbl_LICMaster  set Status='" + objPRReq.Status + "', PolicyNumber='" + objPRReq.LICPolicyNumber + "', PolicyAmount='" + objPRReq.LICPolicyAmount + "'  where LPID='" + objPRReq.LPID + "' and OID='" + objPRReq.OID + "' and UID='" + objPRReq.UID + "' ";
            objPRResp.Count = Connections.ProcessQuery(s);
            return objPRResp;
        }

        // Bank Loan

        public PRResp AddEmpBL_MonthlyContribution(PRReq objPRReq)
        {
            string insert = "insert into PR_tbl_BLMonthlyContribution (Month,Year,OID,ECID,EmpCategory,EmpID,Name,CDLNo,LoanAmount,Status,UID,UName,Dated) values('" + objPRReq.Month + "','" + objPRReq.Year + "','" + objPRReq.OID + "','" + objPRReq.ECID + "','" + objPRReq.EmpCategory + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.CDLNo + "','" + objPRReq.LoanAmount + "','" + objPRReq.Status + "','" + objPRReq.UID + "','" + objPRReq.UName + "','" + objPRReq.Dated + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getBLContributionMonthYearBYEmpID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_BLMonthlyContribution where OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' and CDLNo='" + objPRReq.CDLNo + "' and LoanAmount='" + objPRReq.LoanAmount + "' and Month='" + objPRReq.Month + "' and Year='" + objPRReq.Year + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getPR_tbl_BLMonthlyContributionby_ECID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_BLMonthlyContribution where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and  ECID='" + objPRReq.ECID + "' and Month='" + objPRReq.Month + "' and Year='" + objPRReq.Year + "' order by EmpID ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getSalMonth(PRReq objPRReq)
        {
            string s = "select distinct Month from PR_tbl_Employee_Monthly_Salary where Status='" + objPRReq.Status + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getSalYear(PRReq objPRReq)
        {
            string s = "select distinct Year from PR_tbl_Employee_Monthly_Salary where Status='" + objPRReq.Status + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getPR_tbl_BLMonthYears(PRReq objPRReq)
        {
            string s = "select distinct Month,Year from PR_tbl_BLMonthlyContribution where Status='" + objPRReq.Status + "' order by Month Asc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp DelBLMasterPLID(PRReq objPRReq)
        {
            string s = "delete from PR_tbl_BLMaster where OID='" + objPRReq.OID + "' and BLID='" + objPRReq.BLID + "' and UID='" + objPRReq.UID + "' ";
            objPRResp.Count = Connections.ProcessQuery(s);
            return objPRResp;
        }
        public PRResp getPR_tbl_BLEntryby_ECID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_BLMaster where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and  ECID='" + objPRReq.ECID + "' order by EmpID ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getPR_tbl_BLEntrySumBYECID(PRReq objPRReq)
        {
            string s = "select sum(LoanAmount) as LoanAmount from PR_tbl_BLMaster where OID='" + objPRReq.OID + "' and ECID='" + objPRReq.ECID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getPR_tbl_BLEntrySumEMPID(PRReq objPRReq)
        {
            string s = "select sum(LoanAmount) as LoanAmount from PR_tbl_BLMaster where OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' and UID='" + objPRReq.UID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getPR_tbl_BLMonthlyContributionBYECID(PRReq objPRReq)
        {
            string s = "select sum(LoanAmount) as LoanAmount from PR_tbl_BLMonthlyContribution where OID='" + objPRReq.OID + "' and ECID='" + objPRReq.ECID + "' and Status='" + objPRReq.Status + "' and Month='" + objPRReq.Month + "' and Year='" + objPRReq.Year + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp AddEmpBLDetails(PRReq objPRReq)
        {
            string insert = "insert into PR_tbl_BLMaster (OID,ECID,EmpCategory,EmpID,Name,CDLNo,LoanAmount,Status,UID,UName,Dated) values('" + objPRReq.OID + "','" + objPRReq.ECID + "','" + objPRReq.EmpCategory + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.CDLNo + "','" + objPRReq.LoanAmount + "','" + objPRReq.Status + "','" + objPRReq.UID + "','" + objPRReq.UName + "','" + objPRReq.Dated + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getBLNoBYEmpID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_BLMaster where OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' and CDLNo='" + objPRReq.CDLNo + "' and LoanAmount='" + objPRReq.LoanAmount + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllBLNosBYEmpID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_BLMaster where OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAll_Active_BLNosBYEmpID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_BLMaster where OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllBLTotalBYEmpID(PRReq objPRReq)
        {
            string s = "select sum(LoanAmount) as LoanAmount from PR_tbl_BLMaster where OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllBLNosBYBLID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_BLMaster where OID='" + objPRReq.OID + "' and BLID='" + objPRReq.BLID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp EditBLyNosBYBLID(PRReq objPRReq)
        {
            string s = "update PR_tbl_BLMaster  set Status='" + objPRReq.Status + "', CDLNo='" + objPRReq.CDLNo + "', LoanAmount='" + objPRReq.LoanAmount + "'  where BLID='" + objPRReq.BLID + "' and OID='" + objPRReq.OID + "' and UID='" + objPRReq.UID + "' ";
            objPRResp.Count = Connections.ProcessQuery(s);
            return objPRResp;
        }



        // Allowances

        public PRResp getEmpSumOf_LOPPPB_byETID_ECID_EGID_UID(PRReq objPRReq)
        {
            string s = "select sum(LOPPPB) as LOPPPB from PR_tbl_Employee_Monthly_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' and ECID='" + objPRReq.ECID + "' and EGID='" + objPRReq.EGID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpSumOf_LOPGRP_byETID_ECID_EGID_UID(PRReq objPRReq)
        {
            string s = "select sum(LOPGRP) as LOPGRP from PR_tbl_Employee_Monthly_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' and ECID='" + objPRReq.ECID + "' and EGID='" + objPRReq.EGID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpSumOf_LOPBasicPay_byETID_ECID_EGID_UID(PRReq objPRReq)
        {
            string s = "select sum(LOPBasicPay) as LOPBasicPay from PR_tbl_Employee_Monthly_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' and ECID='" + objPRReq.ECID + "' and EGID='" + objPRReq.EGID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpSumOf_LOPDA_byETID_ECID_EGID_UID(PRReq objPRReq)
        {
            string s = "select sum(LOPDA) as LOPDA from PR_tbl_Employee_Monthly_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' and ECID='" + objPRReq.ECID + "' and EGID='" + objPRReq.EGID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp getEmpSumOf_LOPHRA_byETID_ECID_EGID_UID(PRReq objPRReq)
        {
            string s = "select sum(LOPHRA) as LOPHRA from PR_tbl_Employee_Monthly_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' and ECID='" + objPRReq.ECID + "' and EGID='" + objPRReq.EGID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp getEmpSumOf_LOPTRA_byETID_ECID_EGID_UID(PRReq objPRReq)
        {
            string s = "select sum(LOPTRA) as LOPTRA from PR_tbl_Employee_Monthly_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' and ECID='" + objPRReq.ECID + "' and EGID='" + objPRReq.EGID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp getEmpSumOf_TRGA_byETID_ECID_EGID_UID(PRReq objPRReq)
        {
            string s = "select sum(TRGA) as TRGA from PR_tbl_Employee_Monthly_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' and ECID='" + objPRReq.ECID + "' and EGID='" + objPRReq.EGID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp getEmpSumOf_SCA_byETID_ECID_EGID_UID(PRReq objPRReq)
        {
            string s = "select sum(SCA) as SCA from PR_tbl_Employee_Monthly_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' and ECID='" + objPRReq.ECID + "' and EGID='" + objPRReq.EGID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp getEmpSumOf_WA_byETID_ECID_EGID_UID(PRReq objPRReq)
        {
            string s = "select sum(WashingAllowances) as WA from PR_tbl_Employee_Monthly_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' and ECID='" + objPRReq.ECID + "' and EGID='" + objPRReq.EGID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp getEmpSumOf_DPA_byETID_ECID_EGID_UID(PRReq objPRReq)
        {
            string s = "select sum(DPA) as DPA from PR_tbl_Employee_Monthly_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' and ECID='" + objPRReq.ECID + "' and EGID='" + objPRReq.EGID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpSumOf_NPA_byETID_ECID_EGID_UID(PRReq objPRReq)
        {
            string s = "select sum(NPA) as NPA from PR_tbl_Employee_Monthly_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' and ECID='" + objPRReq.ECID + "' and EGID='" + objPRReq.EGID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpSumOf_PCA_byETID_ECID_EGID_UID(PRReq objPRReq)
        {
            string s = "select sum(PatientCareAllowances) as PCA from PR_tbl_Employee_Monthly_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' and ECID='" + objPRReq.ECID + "' and EGID='" + objPRReq.EGID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp getEmpSumOf_OTPay_byETID_ECID_EGID_UID(PRReq objPRReq)
        {
            string s = "select sum(OTPay) as OTPay from PR_tbl_Employee_Monthly_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' and ECID='" + objPRReq.ECID + "' and EGID='" + objPRReq.EGID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp getEmpSumOf_OtherAllowances_byETID_ECID_EGID_UID(PRReq objPRReq)
        {
            string s = "select sum(OtherAllowances) as OtherAllowances from PR_tbl_Employee_Monthly_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' and ECID='" + objPRReq.ECID + "' and EGID='" + objPRReq.EGID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp getEmpSumOf_Arrears_byETID_ECID_EGID_UID(PRReq objPRReq)
        {
            string s = "select sum(Arrears) as Arrears from PR_tbl_Employee_Monthly_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' and ECID='" + objPRReq.ECID + "' and EGID='" + objPRReq.EGID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp getEmpSumOf_SpecialDutyAllowances_byETID_ECID_EGID_UID(PRReq objPRReq)
        {
            string s = "select sum(SpecialDutyAllowances) as SpecialDutyAllowances from PR_tbl_Employee_Monthly_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' and ECID='" + objPRReq.ECID + "' and EGID='" + objPRReq.EGID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpSumOf_PatientCareAllowances_byETID_ECID_EGID_UID(PRReq objPRReq)
        {
            string s = "select sum(PatientCareAllowances) as PatientCareAllowances from PR_tbl_Employee_Monthly_Salary where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' and ECID='" + objPRReq.ECID + "' and EGID='" + objPRReq.EGID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp AddTVIndent(PRReq objPRReq)
        {
            string insert = "insert into Vehicle_tbl_TVIndent (OID,EmpID,Name,Design,DID,DeptID,Email,Mobile,PurposeofJourney,JourneyDetails,NoofPersons,ProgCode,ProgType,ProgTitle,ProgCoordinator,ProgDept,PPDate,PPTime,PPAddress,PlacetoVisit,VisitDate,VisitTime,TrainDetails,FlightDetails,TotalHaltingTime,ReturnDate,ReturnTime,Dated,Status,UID,UEmpID,UName,UDesign,UEmail,UMobile) values('" + objPRReq.OID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.Design + "','" + objPRReq.DID + "','" + objPRReq.DeptID + "','" + objPRReq.Email + "','" + objPRReq.Mobile + "','" + objPRReq.PurposeofJourney + "','" + objPRReq.JourneyDetails + "','" + objPRReq.NoofPersons + "','" + objPRReq.ProgCode + "','" + objPRReq.ProgType + "','" + objPRReq.ProgTitle + "','" + objPRReq.ProgCoordinator + "','" + objPRReq.ProgDept + "','" + objPRReq.PPDate + "','" + objPRReq.PPTime + "','" + objPRReq.PPAddress + "','" + objPRReq.PlacetoVisit + "','" + objPRReq.VisitDate + "','" + objPRReq.VisitTime + "','" + objPRReq.TrainDetails + "','" + objPRReq.FlightDetails + "','" + objPRReq.TotHaltingTime + "','" + objPRReq.ReturnDate + "','" + objPRReq.ReturnTime + "','" + objPRReq.Dated + "','" + objPRReq.Status + "','" + objPRReq.UID + "','" + objPRReq.UEmpID + "','" + objPRReq.UName + "','" + objPRReq.UDesign + "','" + objPRReq.UEmail + "','" + objPRReq.UMobile + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getTVIndent_UID_EmpID(PRReq objPRReq)
        {
            string s = "select * from Vehicle_tbl_TVIndent where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "'and UID='" + objPRReq.UID + "' and EmpID='" + objPRReq.EmpID + "' and PPDate='" + objPRReq.PPDate + "' and PPTime='" + objPRReq.PPTime + "' and JourneyDetails='" + objPRReq.JourneyDetails + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getTVIndent_TVIID_EmpID(PRReq objPRReq)
        {
            string s = "select * from Vehicle_tbl_TVIndent where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "'and UEmpID='" + objPRReq.EmpID + "' and TVIID='" + objPRReq.TVIID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getTVIndentmaxTVIID_EmpID(PRReq objPRReq)
        {
            string s = "select max(TVIID) as TVIID from Vehicle_tbl_TVIndent where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "'and UEmpID='" + objPRReq.EmpID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getTVIndentPending_UID_EmpID(PRReq objPRReq)
        {
            string s = "select * from Vehicle_tbl_TVIndent where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' or UID='" + objPRReq.UID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getHocDetailsbyEmpID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Employee  where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ISHOC='" + objPRReq.IsHOC + "' and EmpID='" + objPRReq.HEmpID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getHDetailsbyEmpID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Employee  where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and DID='" + objPRReq.DID + "' and EmpID='" + objPRReq.HEmpID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getVehicleISNo(PRReq objPRReq)
        {
            string s = "select max(" + objPRReq.ColumnName + ") from Vehicle_tbl_VIndent where OID='" + objPRReq.OID + "' ";
            objPRResp.SingleValue = Connections.GetSingleValue(s);
            return objPRResp;
        }
        public PRResp DelTVIndentPending_UID_EmpID(PRReq objPRReq)
        {
            string hod = "delete from Vehicle_tbl_TVIndent where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "'and EmpID='" + objPRReq.EmpID + "' and TVIID='" + objPRReq.TVIID + "'";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }
        // Submit Vehicle Indent
        public PRResp SubmitAREVIndent(PRReq objPRReq)
        {
            string insert = "insert into Vehicle_tbl_AREVIndent (SNo,VIndentNo,TripType,HEmpID,HName,HDesign,HDept,HEmail,HMobile,TVIID,OID,EmpID,Name,Design,DID,DeptID,Email,Mobile,PurposeofJourney,JourneyDetails,NoofPersons,ProgCode,ProgType,ProgTitle,ProgCoordinator,ProgDept,PPDate,PPTime,PPAddress,PlacetoVisit,VisitDate,VisitTime,ArrType,TrainDetails,FlightDetails,TotalHaltingTime,ReturnDate,ReturnTime,Dated,Status,UID,UEmpID,UName,UDesign,UEmail,UMobile,HOC_Approval,HOC_Status,ARE_Approval,ARE_Status,VS_Approval,VS_Status,VS_FinalApproval) values('" + objPRReq.SNO + "','" + objPRReq.RIndentNo + "','" + objPRReq.TripType + "','" + objPRReq.HEmpID + "','" + objPRReq.HName + "','" + objPRReq.HDesign + "','" + objPRReq.HDeptID + "','" + objPRReq.HEmail + "','" + objPRReq.HMobile + "','" + objPRReq.TVIID + "','" + objPRReq.OID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.Design + "','" + objPRReq.DID + "','" + objPRReq.DeptID + "','" + objPRReq.Email + "','" + objPRReq.Mobile + "','" + objPRReq.PurposeofJourney + "','" + objPRReq.JourneyDetails + "','" + objPRReq.NoofPersons + "','" + objPRReq.ProgCode + "','" + objPRReq.ProgType + "','" + objPRReq.ProgTitle + "','" + objPRReq.ProgCoordinator + "','" + objPRReq.ProgDept + "','" + objPRReq.PPDate + "','" + objPRReq.PPTime + "','" + objPRReq.PPAddress + "','" + objPRReq.PlacetoVisit + "','" + objPRReq.VisitDate + "','" + objPRReq.VisitTime + "','" + objPRReq.ArrType + "','" + objPRReq.TrainDetails + "','" + objPRReq.FlightDetails + "','" + objPRReq.TotHaltingTime + "','" + objPRReq.ReturnDate + "','" + objPRReq.ReturnTime + "','" + objPRReq.Dated + "','" + objPRReq.Status + "','" + objPRReq.UID + "','" + objPRReq.UEmpID + "','" + objPRReq.UName + "','" + objPRReq.UDesign + "','" + objPRReq.UEmail + "','" + objPRReq.UMobile + "','" + objPRReq.HoC_Approval + "','" + objPRReq.HoC_Status + "','" + objPRReq.ARE_Approval + "','" + objPRReq.ARE_Approval + "','" + objPRReq.VS_Approval + "','" + objPRReq.VS_Status + "','" + objPRReq.VS_FinalApproval + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp SubmitVIndent(PRReq objPRReq)
        {
            string insert = "insert into Vehicle_tbl_VIndent (SNo,VIndentNo,TripType,HEmpID,HName,HDesign,HDept,HEmail,HMobile,TVIID,OID,EmpID,Name,Design,DID,DeptID,Email,Mobile,PurposeofJourney,JourneyDetails,NoofPersons,ProgCode,ProgType,ProgTitle,ProgCoordinator,ProgDept,PPDate,PPTime,PPAddress,PlacetoVisit,VisitDate,VisitTime,ArrType,TrainDetails,FlightDetails,TotalHaltingTime,ReturnDate,ReturnTime,Dated,Status,UID,UEmpID,UName,UDesign,UEmail,UMobile,HOC_Approval,HOC_Status,ARE_Approval,ARE_Status,VS_Approval,VS_Status,VS_FinalApproval) values('" + objPRReq.SNO + "','" + objPRReq.RIndentNo + "','" + objPRReq.TripType + "','" + objPRReq.HEmpID + "','" + objPRReq.HName + "','" + objPRReq.HDesign + "','" + objPRReq.HDeptID + "','" + objPRReq.HEmail + "','" + objPRReq.HMobile + "','" + objPRReq.TVIID + "','" + objPRReq.OID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.Design + "','" + objPRReq.DID + "','" + objPRReq.DeptID + "','" + objPRReq.Email + "','" + objPRReq.Mobile + "','" + objPRReq.PurposeofJourney + "','" + objPRReq.JourneyDetails + "','" + objPRReq.NoofPersons + "','" + objPRReq.ProgCode + "','" + objPRReq.ProgType + "','" + objPRReq.ProgTitle + "','" + objPRReq.ProgCoordinator + "','" + objPRReq.ProgDept + "','" + objPRReq.PPDate + "','" + objPRReq.PPTime + "','" + objPRReq.PPAddress + "','" + objPRReq.PlacetoVisit + "','" + objPRReq.VisitDate + "','" + objPRReq.VisitTime + "','" + objPRReq.ArrType + "','" + objPRReq.TrainDetails + "','" + objPRReq.FlightDetails + "','" + objPRReq.TotHaltingTime + "','" + objPRReq.ReturnDate + "','" + objPRReq.ReturnTime + "','" + objPRReq.Dated + "','" + objPRReq.Status + "','" + objPRReq.UID + "','" + objPRReq.UEmpID + "','" + objPRReq.UName + "','" + objPRReq.UDesign + "','" + objPRReq.UEmail + "','" + objPRReq.UMobile + "','" + objPRReq.HoC_Approval + "','" + objPRReq.HoC_Status + "','" + objPRReq.ARE_Approval + "','" + objPRReq.ARE_Approval + "','" + objPRReq.VS_Approval + "','" + objPRReq.VS_Status + "','" + objPRReq.VS_FinalApproval + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getVIndentPending_UID_EmpID_VSA_Pending(PRReq objPRReq)
        {
            string s = "select * from Vehicle_tbl_VIndent where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "'and EmpID='" + objPRReq.EmpID + "' and VS_Approval='" + objPRReq.VS_Approval + "' and HOC_Approval='" + objPRReq.HoC_Approval + "' order by VIndentNo Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getVIndentPending_UID_EmpID_Status(PRReq objPRReq)
        {
            string s = "select * from Vehicle_tbl_VIndent where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "'and UEmpID='" + objPRReq.EmpID + "' and VS_FinalApproval='" + objPRReq.VS_FinalApproval + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getVIndentPending_HOCApproval(PRReq objPRReq)
        {
            string s = "select * from Vehicle_tbl_VIndent where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "'and HEmpID='" + objPRReq.EmpID + "' and VS_Approval='" + objPRReq.VS_Approval + "' and HOC_Approval='" + objPRReq.HoC_Approval + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getVIndentPending_HOC_byPickupDate(PRReq objPRReq)
        {
            string s = "select * from Vehicle_tbl_VIndent where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and VS_Approval='" + objPRReq.VS_Approval + "' and HOC_Approval='" + objPRReq.HoC_Approval + "' and (HOC_Approval='" + objPRReq.HoC_Approval + "' or ARE_Approval='" + objPRReq.ARE_Approval + "') and PPDate='" + objPRReq.PPDate + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getConfirmedIndentsbyDate(PRReq objPRReq)
        {
            string s = "select * from Vehicle_tbl_VIndent where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and VS_Approval='" + objPRReq.VS_Approval + "' and HOC_Approval='" + objPRReq.HoC_Approval + "' and (HOC_Approval='" + objPRReq.HoC_Approval + "' or ARE_Approval='" + objPRReq.ARE_Approval + "') and PPDate='" + objPRReq.PPDate + "' and VS_FinalApproval='" + objPRReq.VS_FinalApproval + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getVSApprovedIndentsbyPickupDate(PRReq objPRReq)
        {
            string s = "select * from Vehicle_tbl_VIndent where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and VS_Approval='" + objPRReq.VS_Approval + "' and (HOC_Approval='" + objPRReq.HoC_Approval + "' or ARE_Approval='" + objPRReq.ARE_Approval + "') and VS_Approval='" + objPRReq.VS_Approval + "' and PPDate='" + objPRReq.PPDate + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getVSApprovedIndentsbyPickupDateforVehicleAllot(PRReq objPRReq)
        {
            string s = "select distinct VIndentNo,EmpID,Name,Design,Mobile,PPDate,PPTime,NoofPersons,PlacetoVisit,JourneyDetails from Vehicle_tbl_VIndent where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and VS_Approval='" + objPRReq.VS_Approval + "' and (HOC_Approval='" + objPRReq.HoC_Approval + "' or ARE_Approval='" + objPRReq.ARE_Approval + "') and VS_Approval='" + objPRReq.VS_Approval + "' and PPDate='" + objPRReq.PPDate + "' and VS_FinalApproval='" + objPRReq.VS_FinalApproval + "' order by PPDate,PPTime";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getVIndentPending_UID_VSA_ARE_Pending(PRReq objPRReq)
        {
            string s = "select * from Vehicle_tbl_AREVIndent where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and VS_Approval='" + objPRReq.VS_Approval + "' and ARE_Approval='" + objPRReq.ARE_Approval + "' and HOC_Approval='" + objPRReq.HoC_Approval + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getVIndentApproved(PRReq objPRReq)
        {
            string s = "select * from Vehicle_tbl_VIndent where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ARE_Approval='" + objPRReq.ARE_Approval + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllIndentssbyVehicle(PRReq objPRReq)
        {
            string s = "select distinct * from Vehicle_tbl_AREVIndent where  Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ARE_Approval='" + objPRReq.ARE_Approval + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp AREVehicleApproval(PRReq objPRReq)
        {
            string update = "update Vehicle_tbl_AREVIndent set ARE_Approval='" + objPRReq.ARE_Approval + "', ARE_Status='" + objPRReq.ARE_Status + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and VIndentNo='" + objPRReq.RIndentNo + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp ARE_VehicleApproval(PRReq objPRReq)
        {
            string update = "update Vehicle_tbl_VIndent set ARE_Approval='" + objPRReq.ARE_Approval + "', ARE_Status='" + objPRReq.ARE_Status + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and VIndentNo='" + objPRReq.RIndentNo + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }

        public PRResp HOCVehicleApproval(PRReq objPRReq)
        {
            string update = "update Vehicle_tbl_AREVIndent set HOC_Approval='" + objPRReq.HoC_Approval + "', HOC_Status='" + objPRReq.HoC_Status + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and VIndentNo='" + objPRReq.RIndentNo + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp HOC_VehicleApproval(PRReq objPRReq)
        {
            string update = "update Vehicle_tbl_VIndent set HOC_Approval='" + objPRReq.HoC_Approval + "', HOC_Status='" + objPRReq.HoC_Status + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and VIndentNo='" + objPRReq.RIndentNo + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp VS_VehicleApproval(PRReq objPRReq)
        {
            string update = "update Vehicle_tbl_VIndent set VS_FinalApproval='" + objPRReq.VS_FinalApproval + "', VS_Approval='" + objPRReq.VS_Approval + "', VS_Status='" + objPRReq.VS_Status + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and VIndentNo='" + objPRReq.RIndentNo + "' and HOC_Approval='" + objPRReq.HoC_Approval + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }

        public PRResp CornfirmVehicleBooking(PRReq objPRReq)
        {
            string update = "update Vehicle_tbl_VIndent set VUName='" + objPRReq.UName + "',VUID='" + objPRReq.UID + "', VS_FinalStatus='" + objPRReq.VS_FinalStatus + "', VS_FinalApproval='" + objPRReq.VS_FinalApproval + "',VehicleName='" + objPRReq.VehicleName + "',VehicleNumber='" + objPRReq.VehicleNumber + "',VDID='" + objPRReq.VDID + "',DriverName='" + objPRReq.DriverName + "',DriverMobile='" + objPRReq.DriverMobile + "',JourneyStatus='" + objPRReq.JourneyStatus + "' where VIndentNo='" + objPRReq.RIndentNo + "' and OID='" + objPRReq.OID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp getDataForConfirmedSMS(PRReq objPRReq)
        {
            string s = "select * from Vehicle_tbl_VIndent where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and VS_FinalApproval='" + objPRReq.VS_FinalApproval + "' and VIndentNo='" + objPRReq.RIndentNo + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getConfirmedIndentsbyDate_EmpID(PRReq objPRReq)
        {
            string s = "select * from Vehicle_tbl_VIndent where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and VS_Approval='" + objPRReq.VS_Approval + "' and HOC_Approval='" + objPRReq.HoC_Approval + "' and (HOC_Approval='" + objPRReq.HoC_Approval + "' or ARE_Approval='" + objPRReq.ARE_Approval + "') and PPDate='" + objPRReq.PPDate + "' and VS_FinalApproval='" + objPRReq.VS_FinalApproval + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }


        // Security Place
        public PRResp AddSPlace(PRReq objPRReq)
        {
            string insert = "insert into Security_tbl_SPlace (OID,SPlace,Status) values('" + objPRReq.OID + "','" + objPRReq.SPlace + "','" + objPRReq.Status + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getSPlaceByName(PRReq objPRReq)
        {
            string s = "select * from Security_tbl_SPlace where SPlace='" + objPRReq.SPlace + "' and OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getSPlaceByOID(PRReq objPRReq)
        {
            string s = "select * from Security_tbl_SPlace where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and SPID='" + objPRReq.SPID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllSPlaces(PRReq objPRReq)
        {
            string s = "select * from Security_tbl_SPlace where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "'  ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp EditSPlaceBySPID(PRReq objPRReq)
        {
            string update = "update Security_tbl_SPlace set SPlace='" + objPRReq.SPlace + "' where OID='" + objPRReq.OID + "' and SPID='" + objPRReq.SPID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp DelSPlace(PRReq objPRReq)
        {
            string hod = "delete from Security_tbl_SPlace where  OID='" + objPRReq.OID + "' and SPID='" + objPRReq.SPID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }
        public PRResp SPlaceSearch(PRReq objPRReq)
        {
            string s = "select * from Security_tbl_SPlace where SPlace like '%" + objPRReq.SPlace + "%' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }


        // Security Guard
        public PRResp AddSGuard(PRReq objPRReq)
        {
            string insert = "insert into Security_tbl_SecurityGuard (OID,SGNo,Name,Surname,Password,Designation,Mobile,Email,Address,Photo,QRCode,Status,Dated,Role) values('" + objPRReq.OID + "','" + objPRReq.SGNO + "','" + objPRReq.Name + "','" + objPRReq.SurName + "','" + objPRReq.Password + "','" + objPRReq.Design + "','" + objPRReq.Mobile + "','" + objPRReq.Email + "','" + objPRReq.Address + "','" + objPRReq.Photo + "','" + objPRReq.QRCode + "','" + objPRReq.Status + "','" + objPRReq.Dated + "','" + objPRReq.Role + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getSGuardByName(PRReq objPRReq)
        {
            string s = "select * from Security_tbl_SecurityGuard where Name='" + objPRReq.Name + "' and Surname='" + objPRReq.SurName + "' and Mobile='" + objPRReq.Mobile + "' and OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getSGuardBySGID(PRReq objPRReq)
        {
            string s = "select * from Security_tbl_SecurityGuard where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and SGID='" + objPRReq.SGID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllSGuards(PRReq objPRReq)
        {
            string s = "select * from Security_tbl_SecurityGuard where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp DelSGuard(PRReq objPRReq)
        {
            string d = "delete from Security_tbl_SecurityGuard where  OID='" + objPRReq.OID + "' and SGID='" + objPRReq.SGID + "' ";
            objPRResp.GetTable = Connections.GetTable(d);
            return objPRResp;
        }
        public PRResp SGuardSearch(PRReq objPRReq)
        {
            string s = "select * from Security_tbl_SecurityGuard where Name like '%" + objPRReq.Name + "%' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getSGNo(PRReq objPRReq)
        {
            string s = "select max(" + objPRReq.ColumnName + ") from Security_tbl_SecurityGuard where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.SingleValue = Connections.GetSingleValue(s);
            return objPRResp;
        }
        public PRResp getIDCardSGID(PRReq objPRReq)
        {
            string s = "select * from Security_tbl_SecurityGuard where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and SGID='" + objPRReq.SGID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp BlockSGBySGID(PRReq objPRReq)
        {
            string update = "update Security_tbl_SecurityGuard set Status='" + objPRReq.Status + "' where OID='" + objPRReq.OID + "' and SGID='" + objPRReq.SGID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }

        public PRResp getAllVisitPurposes(PRReq objPRReq)
        {
            string s = "select * from Security_tbl_VisitPurpose where Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }


        // Emp Tour Report
        public PRResp AddTourReport(PRReq objPRReq)
        {
            string insert = "insert into PR_tbl_EmpTourReport (EID,OID,ETID,EmpType,ECID,EmpCategory,EGID,EmpGroup,DID,DeptID,DSID,Design,EmpID,Name,Email,Mobile,TourType,TourCategory,TourTitle,TourPlace,FromDate,ToDate,TourReport,Status,UID,UName,Dated,BriefNote,ActionItems,Observations,ETourID) values('" + objPRReq.EID + "','" + objPRReq.OID + "','" + objPRReq.ETID + "','" + objPRReq.EmpType + "','" + objPRReq.ECID + "','" + objPRReq.EmpCategory + "','" + objPRReq.EGID + "','" + objPRReq.EmpGroup + "','" + objPRReq.DID + "','" + objPRReq.DeptID + "','" + objPRReq.DSID + "','" + objPRReq.Design + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.Email + "','" + objPRReq.Mobile + "','" + objPRReq.TourType + "','" + objPRReq.TourCategory + "','" + objPRReq.TourTitle + "','" + objPRReq.TourPlaces + "','" + objPRReq.FromDate + "','" + objPRReq.LastDate + "','" + objPRReq.Report + "','" + objPRReq.Status + "','" + objPRReq.UID + "','" + objPRReq.UName + "','" + objPRReq.Dated + "','" + objPRReq.BriefNote + "','" + objPRReq.ActionItems + "','" + objPRReq.Observations + "','" + objPRReq.ETourID + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getTourReport(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_EmpTourReport where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' and TourTitle='" + objPRReq.TourTitle + "' and TourPlace='" + objPRReq.TourPlaces + "' and TourType='" + objPRReq.TourType + "' and TourCategory='" + objPRReq.TourCategory + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getTourReport_ETRID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_EmpTourReport where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ETRID='" + objPRReq.ETRID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getTourReportEmpID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_EmpTourReport where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getTourReportDID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_EmpTourReport where Status='" + objPRReq.Status + "' and DID='" + objPRReq.DID + "' and OID='" + objPRReq.OID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getTourReport_EmpDID(PRReq objPRReq)
        {
            string s = "select distinct DID,DeptID,EmpID,Name,Design from PR_tbl_EmpTourReport where Status='" + objPRReq.Status + "' and DID='" + objPRReq.DID + "' and OID='" + objPRReq.OID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getTourReportDID_EmpID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_EmpTourReport where Status='" + objPRReq.Status + "' and DID='" + objPRReq.DID + "' and OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getTourReportInfo_EmpID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_EmpTourReport where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' order by ETRID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp DelTourReportEmpID(PRReq objPRReq)
        {
            string hod = "delete from PR_tbl_EmpTourReport where  OID='" + objPRReq.OID + "' and ETRID='" + objPRReq.ETRID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }


        // PS Payroll
        public PRResp getProjectTitles(PRReq objPRReq)
        {
            string s = "select * from PS_tbl_ProjectTitles where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp AddPSProjectTitle(PRReq objPRReq)
        {
            string insert = "insert into PS_tbl_ProjectTitles (OID,ProjectCode,ProjectTitle,Status,UID,UName,Dated) values('" + objPRReq.OID + "','" + objPRReq.ProjectCode + "','" + objPRReq.ProjectTitle + "','" + objPRReq.Status + "','" + objPRReq.UID + "', '" + objPRReq.UName + "','" + objPRReq.Dated + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getProjectTitleByName(PRReq objPRReq)
        {
            string s = "select * from PS_tbl_ProjectTitles where ProjectCode='" + objPRReq.ProjectCode + "' and ProjectTitle='" + objPRReq.ProjectTitle + "' and OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getProjectTitleByOID(PRReq objPRReq)
        {
            string s = "select * from PS_tbl_ProjectTitles where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and PTID='" + objPRReq.PTID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp EditProjectTitleByOID(PRReq objPRReq)
        {
            string update = "update PS_tbl_ProjectTitles set ProjectCode='" + objPRReq.ProjectCode + "', ProjectTitle='" + objPRReq.ProjectTitle + "' where OID='" + objPRReq.OID + "' and PTID='" + objPRReq.PTID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp DelPSProjectTitle(PRReq objPRReq)
        {
            string hod = "delete from PS_tbl_ProjectTitles where  OID='" + objPRReq.OID + "' and PTID='" + objPRReq.PTID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }
        public PRResp ProjectTitleSearch(PRReq objPRReq)
        {
            string s = "select * from PS_tbl_ProjectTitles where ProjectTitle like '%" + objPRReq.ProjectTitle + "%' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }


        // Form16
        public PRResp UpdatePAN_EMPID(PRReq objPRReq)
        {
            string update = "update PR_tbl_Employee set PAN='" + objPRReq.PAN + "' where EmpID='" + objPRReq.EmpID + "' and OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and UID='" + objPRReq.UID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp UpdateSalPAN_EMPID(PRReq objPRReq)
        {
            string update = "update PR_tbl_Employee_Master_Salary set PAN='" + objPRReq.PAN + "' where EmpID='" + objPRReq.EmpID + "' and OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and UID='" + objPRReq.UID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp Addfor16MasterEmpData(PRReq objPRReq)
        {
            string insert = "insert into PR_tbl_Form16_Master_Regular (OID,FinancialYear,AssessmentYear,EmpID,Name,Design,PAN,Gender,Age,Status,UID,UName) values('" + objPRReq.OID + "','" + objPRReq.FinancialYear + "','" + objPRReq.AssessmentYear + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.Design + "','" + objPRReq.PAN + "','" + objPRReq.Gender + "','" + objPRReq.Age + "','" + objPRReq.Status + "','" + objPRReq.UID + "','" + objPRReq.UName + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }

        public PRResp getEmpDataFromForm16Master(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Form16_Master_Regular where OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' and FinancialYear='" + objPRReq.FinancialYear + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpDataFromForm16Master_PrintRegular(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Form16_Master_Regular where OID='" + objPRReq.OID + "' and FinancialYear='" + objPRReq.FinancialYear + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpDataFromForm16Master_PrintRetired(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Form16_Master_Retired where OID='" + objPRReq.OID + "' and FinancialYear='" + objPRReq.FinancialYear + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp Addfor16MasterEmpData_Retired(PRReq objPRReq)
        {
            string insert = "insert into PR_tbl_Form16_Master_Retired (OID,FinancialYear,AssessmentYear,EmpID,Name,Design,PAN,Gender,Age,Status,UID,UName) values('" + objPRReq.OID + "','" + objPRReq.FinancialYear + "','" + objPRReq.AssessmentYear + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.Design + "','" + objPRReq.PAN + "','" + objPRReq.Gender + "','" + objPRReq.Age + "','" + objPRReq.Status + "','" + objPRReq.UID + "','" + objPRReq.UName + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }

        public PRResp getEmpDataFromForm16Master_Retired(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Form16_Master_Retired where OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' and FinancialYear='" + objPRReq.FinancialYear + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp update_FromForm16Master_Regular(PRReq objPRReq)
        {
            string update = "update PR_tbl_Form16_Master_Regular set Aggregate_IV_A='" + objPRReq.Aggregate_IV_A + "', PAN='" + objPRReq.PAN + "', Age='" + objPRReq.Age + "',TGrossSal='" + objPRReq.TGrossSal + "',THRA='" + objPRReq.THRA + "',TotalGSal='" + objPRReq.TotalGSal1 + "',StandardDeduction='" + objPRReq.StandardDeduction + "',ProfTax='" + objPRReq.ProfTax + "',GrandTotalGrossSal='" + objPRReq.GrandTotalGrossSal + "',IRH_Loan_Max='" + objPRReq.IRH_Loan_Max + "',IRH_Loan_Actual='" + objPRReq.IRH_Loan_Actual + "',IRH_Loan_Allowed='" + objPRReq.IRH_Loan_Allowed + "',PHC_80U_Max='" + objPRReq.PHC_80U_Max + "',PHC_80U_Actual='" + objPRReq.PHC_80U_Actual + "',PHC_80U_Allowed='" + objPRReq.PHC_80U_Allowed + "',MedIP_80D_Max='" + objPRReq.MedIP_80D_Max + "',MedIP_80D_Actual='" + objPRReq.MedIP_80D_Actual + "',	MedIP_80D_Allowed='" + objPRReq.MedIP_80D_Allowed + "',	MTHD_80MTHD_Max='" + objPRReq.MTHD_80MTHD_Max + "',	MTHD_80MTHD_Actual='" + objPRReq.MTHD_80MTHD_Actual + "',MTHD_80MTHD_Allowed='" + objPRReq.MTHD_80MTHD_Allowed + "',Med_80DDB_Max='" + objPRReq.Med_80DDB_Max + "',	Med_80DDB_Actual='" + objPRReq.Med_80DDB_Actual + "',Med_80DDB_Allowed='" + objPRReq.Med_80DDB_Allowed + "',Repayment_80E_Max='" + objPRReq.Repayment_80E_Max + "',	Repayment_80E_Actual='" + objPRReq.Repayment_80E_Actual + "',Repayment_80E_Allowed='" + objPRReq.Repayment_80E_Allowed + "',	Donations_80G_Max='" + objPRReq.Donations_80G_Max + "',	Donations_80G_Actual='" + objPRReq.Donations_80G_Actual + "',Donations_80G_Allowed='" + objPRReq.Donations_80G_Allowed + "',NPS_80CCD_Max='" + objPRReq.NPS_80CCD_Max + "',	NPS_80CCD_Actual='" + objPRReq.NPS_80CCD_Actual + "',NPS_80CCD_Allowed='" + objPRReq.NPS_80CCD_Allowed + "',Infracture_80CCF_Max='" + objPRReq.Infracture_80CCF_Max + "',Infracture_80CCF_Actual='" + objPRReq.Infracture_80CCF_Actual + "',Infracture_80CCF_Allowed='" + objPRReq.Infracture_80CCF_Allowed + "',TotalIncomeRebate='" + objPRReq.TotalIncomeRebate + "',MaxAllowedRebate='" + objPRReq.MaxAllowedRebate + "',GPF_Max='" + objPRReq.GPF_Max + "',	GPF_Actual='" + objPRReq.GPF_Actual + "',GPF_Allowed='" + objPRReq.GPF_Allowed + "',LIC_Max='" + objPRReq.LIC_Max + "',	LIC_Actual='" + objPRReq.LIC_Actual + "',LIC_Allowed='" + objPRReq.LIC_Allowed + "',PostSS_Max='" + objPRReq.PostSS_Max + "',PostSS_Actual='" + objPRReq.PostSS_Actual + "',PostSS_Allowed='" + objPRReq.PostSS_Allowed + "',NSC_Max='" + objPRReq.NSC_Max + "',	NSC_Actual='" + objPRReq.NSC_Actual + "',NSC_Allowed='" + objPRReq.NSC_Allowed + "',	ULIP_Max='" + objPRReq.ULIP_Max + "',ULIP_Actual='" + objPRReq.ULIP_Actual + "',ULIP_Allowed='" + objPRReq.ULIP_Allowed + "',TutionFee_Max='" + objPRReq.TutionFee_Max + "',TutionFee_Actual='" + objPRReq.TutionFee_Actual + "',TutionFee_Allowed='" + objPRReq.TutionFee_Allowed + "',PPHouseLoan_Max='" + objPRReq.PPHouseLoan_Max + "',	PPHouseLoan_Actual='" + objPRReq.PPHouseLoan_Actual + "',	PPHouseLoan_Allowed='" + objPRReq.PPHouseLoan_Allowed + "',	Bonds_Max='" + objPRReq.Bonds_Max + "',	Bonds_Actual='" + objPRReq.Bonds_Actual + "',Bonds_Allowed='" + objPRReq.Bonds_Allowed + "',MutualFunds_Max='" + objPRReq.MutualFunds_Max + "',	MutualFunds_Actual='" + objPRReq.MutualFunds_Actual + "',	MutualFunds_Allowed='" + objPRReq.MutualFunds_Allowed + "',	GI_Max='" + objPRReq.GI_Max + "',	GI_Actual='" + objPRReq.GI_Actual + "',	GI_Allowed='" + objPRReq.GI_Allowed + "',PublicPF_Max='" + objPRReq.PublicPF_Max + "',	PublicPF_Actual='" + objPRReq.PublicPF_Actual + "',	PublicPF_Allowed='" + objPRReq.PublicPF_Allowed + "',TotalTaxRebate='" + objPRReq.TotalTaxRebate + "', TotalTaxableIncome='" + objPRReq.TotalTaxableIncome + "',	TaxonTotIncome='" + objPRReq.TaxonTotIncome + "',Rebate_87A='" + objPRReq.Rebate_87A + "',	SurChargePercentage='" + objPRReq.SurChargePercentage + "',	TotalTax='" + objPRReq.TotalTax + "',EducationCess='" + objPRReq.EducationCess + "',NetTaxPayble='" + objPRReq.NetTaxPayble + "',TaxRecovered='" + objPRReq.TaxRecovered + "',	TaxRecovered_inwords='" + objPRReq.TaxRecoveredinWords + "',TaxTobeRecovered='" + objPRReq.TaxTobeRecovered + "',Dated='" + objPRReq.Dated + "' where OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' and FinancialYear='" + objPRReq.FinancialYear + "' and Status='" + objPRReq.Status + "'  ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp update_FromForm16Master_Retired(PRReq objPRReq)
        {
            string update = "update PR_tbl_Form16_Master_Retired set Aggregate_IV_A='" + objPRReq.Aggregate_IV_A + "', PAN='" + objPRReq.PAN + "', Age='" + objPRReq.Age + "', TGrossSal='" + objPRReq.TGrossSal + "',THRA='" + objPRReq.THRA + "',TotalGSal='" + objPRReq.TotalGSal1 + "',StandardDeduction='" + objPRReq.StandardDeduction + "',ProfTax='" + objPRReq.ProfTax + "',GrandTotalGrossSal='" + objPRReq.GrandTotalGrossSal + "',IRH_Loan_Max='" + objPRReq.IRH_Loan_Max + "',IRH_Loan_Actual='" + objPRReq.IRH_Loan_Actual + "',IRH_Loan_Allowed='" + objPRReq.IRH_Loan_Allowed + "',PHC_80U_Max='" + objPRReq.PHC_80U_Max + "',PHC_80U_Actual='" + objPRReq.PHC_80U_Actual + "',PHC_80U_Allowed='" + objPRReq.PHC_80U_Allowed + "',MedIP_80D_Max='" + objPRReq.MedIP_80D_Max + "',MedIP_80D_Actual='" + objPRReq.MedIP_80D_Actual + "',	MedIP_80D_Allowed='" + objPRReq.MedIP_80D_Allowed + "',	MTHD_80MTHD_Max='" + objPRReq.MTHD_80MTHD_Max + "',	MTHD_80MTHD_Actual='" + objPRReq.MTHD_80MTHD_Actual + "',MTHD_80MTHD_Allowed='" + objPRReq.MTHD_80MTHD_Allowed + "',Med_80DDB_Max='" + objPRReq.Med_80DDB_Max + "',	Med_80DDB_Actual='" + objPRReq.Med_80DDB_Actual + "',Med_80DDB_Allowed='" + objPRReq.Med_80DDB_Allowed + "',Repayment_80E_Max='" + objPRReq.Repayment_80E_Max + "',	Repayment_80E_Actual='" + objPRReq.Repayment_80E_Actual + "',Repayment_80E_Allowed='" + objPRReq.Repayment_80E_Allowed + "',	Donations_80G_Max='" + objPRReq.Donations_80G_Max + "',	Donations_80G_Actual='" + objPRReq.Donations_80G_Actual + "',Donations_80G_Allowed='" + objPRReq.Donations_80G_Allowed + "',NPS_80CCD_Max='" + objPRReq.NPS_80CCD_Max + "',	NPS_80CCD_Actual='" + objPRReq.NPS_80CCD_Actual + "',NPS_80CCD_Allowed='" + objPRReq.NPS_80CCD_Allowed + "',Infracture_80CCF_Max='" + objPRReq.Infracture_80CCF_Max + "',Infracture_80CCF_Actual='" + objPRReq.Infracture_80CCF_Actual + "',Infracture_80CCF_Allowed='" + objPRReq.Infracture_80CCF_Allowed + "',TotalIncomeRebate='" + objPRReq.TotalIncomeRebate + "',MaxAllowedRebate='" + objPRReq.MaxAllowedRebate + "',GPF_Max='" + objPRReq.GPF_Max + "',	GPF_Actual='" + objPRReq.GPF_Actual + "',GPF_Allowed='" + objPRReq.GPF_Allowed + "',LIC_Max='" + objPRReq.LIC_Max + "',	LIC_Actual='" + objPRReq.LIC_Actual + "',LIC_Allowed='" + objPRReq.LIC_Allowed + "',PostSS_Max='" + objPRReq.PostSS_Max + "',PostSS_Actual='" + objPRReq.PostSS_Actual + "',PostSS_Allowed='" + objPRReq.PostSS_Allowed + "',NSC_Max='" + objPRReq.NSC_Max + "',	NSC_Actual='" + objPRReq.NSC_Actual + "',NSC_Allowed='" + objPRReq.NSC_Allowed + "',	ULIP_Max='" + objPRReq.ULIP_Max + "',ULIP_Actual='" + objPRReq.ULIP_Actual + "',ULIP_Allowed='" + objPRReq.ULIP_Allowed + "',TutionFee_Max='" + objPRReq.TutionFee_Max + "',TutionFee_Actual='" + objPRReq.TutionFee_Actual + "',TutionFee_Allowed='" + objPRReq.TutionFee_Allowed + "',PPHouseLoan_Max='" + objPRReq.PPHouseLoan_Max + "',	PPHouseLoan_Actual='" + objPRReq.PPHouseLoan_Actual + "',	PPHouseLoan_Allowed='" + objPRReq.PPHouseLoan_Allowed + "',	Bonds_Max='" + objPRReq.Bonds_Max + "',	Bonds_Actual='" + objPRReq.Bonds_Actual + "',Bonds_Allowed='" + objPRReq.Bonds_Allowed + "',MutualFunds_Max='" + objPRReq.MutualFunds_Max + "',	MutualFunds_Actual='" + objPRReq.MutualFunds_Actual + "',	MutualFunds_Allowed='" + objPRReq.MutualFunds_Allowed + "',	GI_Max='" + objPRReq.GI_Max + "',	GI_Actual='" + objPRReq.GI_Actual + "',	GI_Allowed='" + objPRReq.GI_Allowed + "',PublicPF_Max='" + objPRReq.PublicPF_Max + "',	PublicPF_Actual='" + objPRReq.PublicPF_Actual + "',	PublicPF_Allowed='" + objPRReq.PublicPF_Allowed + "',TotalTaxRebate='" + objPRReq.TotalTaxRebate + "', TotalTaxableIncome='" + objPRReq.TotalTaxableIncome + "',	TaxonTotIncome='" + objPRReq.TaxonTotIncome + "',Rebate_87A='" + objPRReq.Rebate_87A + "',	SurChargePercentage='" + objPRReq.SurChargePercentage + "',	TotalTax='" + objPRReq.TotalTax + "',EducationCess='" + objPRReq.EducationCess + "',NetTaxPayble='" + objPRReq.NetTaxPayble + "',TaxRecovered='" + objPRReq.TaxRecovered + "',	TaxRecovered_inwords='" + objPRReq.TaxRecoveredinWords + "',TaxTobeRecovered='" + objPRReq.TaxTobeRecovered + "',Dated='" + objPRReq.Dated + "' where OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' and FinancialYear='" + objPRReq.FinancialYear + "' and Status='" + objPRReq.Status + "'  ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }

        public PRResp update_FromForm16Master_RegularEntry(PRReq objPRReq)
        {
            string update = "update PR_tbl_Form16_Master_Regular set AYFromDate='" + objPRReq.FromDate + "',AYToDate='" + objPRReq.LastDate + "',Quarter1='" + objPRReq.TDSQuarter1 + "',Quarter2='" + objPRReq.TDSQuarter2 + "',Quarter3='" + objPRReq.TDSQuarter3 + "',Quarter4='" + objPRReq.TDSQuarter4 + "',Auth_Name='" + objPRReq.Name + "',Auth_FatherName='" + objPRReq.FathersName + "',Auth_Design='" + objPRReq.Design + "',Place='" + objPRReq.SPlace + "' where OID='" + objPRReq.OID + "' and FinancialYear='" + objPRReq.FinancialYear + "' and Status='" + objPRReq.Status + "'  ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp update_FromForm16Master_RetiredEntry(PRReq objPRReq)
        {
            string update = "update PR_tbl_Form16_Master_Retired set AYFromDate='" + objPRReq.FromDate + "',AYToDate='" + objPRReq.LastDate + "',Quarter1='" + objPRReq.TDSQuarter1 + "',Quarter2='" + objPRReq.TDSQuarter2 + "',Quarter3='" + objPRReq.TDSQuarter3 + "',Quarter4='" + objPRReq.TDSQuarter4 + "',Auth_Name='" + objPRReq.Name + "',Auth_FatherName='" + objPRReq.FathersName + "',Auth_Design='" + objPRReq.Design + "',Place='" + objPRReq.SPlace + "' where OID='" + objPRReq.OID + "' and FinancialYear='" + objPRReq.FinancialYear + "' and Status='" + objPRReq.Status + "'  ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }

        public PRResp getMasterDATA_Form16(PRReq objPRReq)
        {
            string s = "select distinct FinancialYear,AssessmentYear,AYFromDate,AYToDate,Quarter1,Quarter2,Quarter3,Quarter4,Auth_Name,Auth_FatherName,Auth_Design,Place from PR_tbl_Form16_Master_Regular where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        // SMS Alert

        public PRResp AddSentSMS(PRReq objPRReq)
        {
            string insert = "insert into SMS_tbl_SMS (OID,EmpID,Name,JobID,Mobile,Message,SMSCount,SentTime,DLRStatus,Dated) values('" + objPRReq.OID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.JobID + "','" + objPRReq.Mobile + "','" + objPRReq.Message + "','" + objPRReq.SmsCount + "','" + objPRReq.SmsSentTime + "','" + objPRReq.DLRStatus + "','" + objPRReq.ToDate + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getSentSMSInfo_Mobile_Msg(PRReq objPRReq)
        {
            string s = "select distinct * from SMS_tbl_SMS where Mobile='" + objPRReq.Mobile + "' and Message='" + objPRReq.Message + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getSentSMSInfo_EMPID(PRReq objPRReq)
        {
            string s = "select distinct EmpID,Message,SMSCount,Dated from SMS_tbl_SMS where OID='" + objPRReq.OID + "' and EMPID='" + objPRReq.EmpID + "' order by Dated Desc ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllSentSMSInfo_EMPID(PRReq objPRReq)
        {
            string s = "select * from SMS_tbl_SMS where OID='" + objPRReq.OID + "' and EMPID='" + objPRReq.EmpID + "' and Dated='" + objPRReq.ToDate + "' order by Dated Desc ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp update_AllSentSMS_EMPID_Dated(PRReq objPRReq)
        {
            string update = "update SMS_tbl_SMS set DLRTime='" + objPRReq.DLRTime + "',DLRStatus='" + objPRReq.DLRStatus + "' where OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' and Dated='" + objPRReq.ToDate + "' and JobID='" + objPRReq.JobID + "'  ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }

        // Request for Gov Mail

        public PRResp AddRequestforGovMail(PRReq objPRReq)
        {
            string insert = "insert into tbl_GovMailRequest (OID,DID,DeptID,EmpType,EmpID,SurName,Name,Designation,Email,Mobile,GovMail,ProjectTitle,DOB,DOJ,DOR,Status,Dated) values('" + objPRReq.OID + "','" + objPRReq.DID + "','" + objPRReq.DeptID + "','" + objPRReq.EmpType + "','" + objPRReq.EmpID + "','" + objPRReq.SurName + "','" + objPRReq.Name + "','" + objPRReq.Design + "','" + objPRReq.Email + "','" + objPRReq.Mobile + "','" + objPRReq.GovMail + "','" + objPRReq.ProjectTitle + "','" + objPRReq.DOB + "','" + objPRReq.DOJ + "','" + objPRReq.DOR + "','" + objPRReq.Status + "','" + objPRReq.Dated + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getRequestforGovMail_EMPID(PRReq objPRReq)
        {
            string s = "select * from tbl_GovMailRequest where OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' and Mobile='" + objPRReq.Mobile + "' and GovMail='" + objPRReq.GovMail + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp getAllRequestforGovMail(PRReq objPRReq)
        {
            string s = "select * from tbl_GovMailRequest where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' order by DeptID ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }


        // Item Type

        // Employee Type

        public PRResp getAllHWItemTypes(PRReq objPRReq)
        {
            string s = "select distinct * from CIT_tbl_ItemType where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ITID in (1,2,3,4,5,26) ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getItemTypes(PRReq objPRReq)
        {
            string s = "select * from CIT_tbl_ItemType where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp AddItemType(PRReq objPRReq)
        {
            string insert = "insert into CIT_tbl_ItemType (OID,ItemType,Status) values('" + objPRReq.OID + "','" + objPRReq.ItemType + "','" + objPRReq.Status + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getItemTypeByName(PRReq objPRReq)
        {
            string s = "select * from CIT_tbl_ItemType where ItemType='" + objPRReq.ItemType + "' and OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getItemTypeByOID(PRReq objPRReq)
        {
            string s = "select * from CIT_tbl_ItemType where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ITID='" + objPRReq.ITID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp EditItemTypeByOID(PRReq objPRReq)
        {
            string update = "update CIT_tbl_ItemType set ItemType='" + objPRReq.ItemType + "' where OID='" + objPRReq.OID + "' and ITID='" + objPRReq.ITID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp DelItemType(PRReq objPRReq)
        {
            string hod = "delete from CIT_tbl_ItemType where  OID='" + objPRReq.OID + "' and ITID='" + objPRReq.ITID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }
        public PRResp ItemTypeSearch(PRReq objPRReq)
        {
            string s = "select * from CIT_tbl_ItemType where ItemType like '%" + objPRReq.ItemType + "%' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        // CIT ItemInventory
        public PRResp getAllItemInventory_ITemNameNoWarranty_Dept(PRReq objPRReq)
        {
            string s = "select distinct * from CIT_tbl_InventoryMapping where Flag1=1 and Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ItemName='" + objPRReq.ItemName + "' and DeptID='" + objPRReq.DeptID + "' and Warranty!='Warranty' and Warranty!='AMC' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllItemInventory_DeptWise_NameWise(PRReq objPRReq)
        {
            string s = "select distinct * from CIT_tbl_InventoryMapping where Flag1=1 and Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' order by DeptID,Name,ItemName ASC ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllItemInventory_DeptWise_NameWise_ITID(PRReq objPRReq)
        {
            string s = "select distinct * from CIT_tbl_InventoryMapping where Flag1=1 and Status='" + objPRReq.Status + "' and ITID='" + objPRReq.ITID + "' and OID='" + objPRReq.OID + "' order by DeptID,Name,ItemName ASC ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllItemInventory_ITemName_Dept_AMC(PRReq objPRReq)
        {
            string s = "select distinct * from CIT_tbl_InventoryMapping where Flag1=1 and Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ItemName='" + objPRReq.ItemName + "' and Warranty='" + objPRReq.Warranty + "' and DeptID='" + objPRReq.DeptID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllItemInventory_DeptID(PRReq objPRReq)
        {
            string s = "select distinct DeptID from CIT_tbl_InventoryMapping where Flag1=1 and Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ItemName='" + objPRReq.ItemName + "' order by DeptID Asc  ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllItemInventory_Manufacturer(PRReq objPRReq)
        {
            string s = "select distinct Manufacturer from CIT_tbl_ItemInventory where Status!='Abandoned' and OID='" + objPRReq.OID + "' and ItemName='" + objPRReq.ItemName + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllItemInventory_ITemNameNoWarranty(PRReq objPRReq)
        {
            string s = "select distinct * from CIT_tbl_ItemInventory where Status!='Abandoned' and OID='" + objPRReq.OID + "' and ItemName='" + objPRReq.ItemName + "' and Warranty!='Warranty' and Warranty!='AMC' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getItemInventory_ITID_SerialNo(PRReq objPRReq)
        {
            string s = "select distinct * from CIT_tbl_ItemInventory where Status='Idle' and OID='" + objPRReq.OID + "' and ITID='" + objPRReq.ITID + "' and SerialNo='" + objPRReq.SerialNo + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllItemInventory_ITemNameAMC(PRReq objPRReq)
        {
            string s = "select distinct * from CIT_tbl_ItemInventory where Status!='Abandoned' and OID='" + objPRReq.OID + "' and ItemName='" + objPRReq.ItemName + "' and Warranty='" + objPRReq.Warranty + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllItemInventory_ITemNameNoWarranty_manufacturer(PRReq objPRReq)
        {
            string s = "select distinct * from CIT_tbl_ItemInventory where Status!='Abandoned' and OID='" + objPRReq.OID + "' and ItemName='" + objPRReq.ItemName + "' and Manufacturer='" + objPRReq.Manufacturer + "' and Warranty!='Warranty' and Warranty!='AMC' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllItemInventory_ITemName_Manufacturer_AMC(PRReq objPRReq)
        {
            string s = "select distinct * from CIT_tbl_ItemInventory where Status!='Abandoned' and OID='" + objPRReq.OID + "' and ItemName='" + objPRReq.ItemName + "' and Warranty='" + objPRReq.Warranty + "' and Manufacturer='" + objPRReq.Manufacturer + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp AddItemInventory(PRReq objPRReq)
        {
            string insert = "insert into CIT_tbl_ItemInventory (OID,ITID,ItemName,ItemType,Model,SerialNo,Manufacturer,ComputerNumber,DOP,Warranty,WarrantyDate,Vendor,Status,Dated,UID,UName) values('" + objPRReq.OID + "','" + objPRReq.ITID + "','" + objPRReq.ItemName + "','" + objPRReq.ItemType + "','" + objPRReq.ModelType + "','" + objPRReq.SerialNo + "','" + objPRReq.Manufacturer + "','" + objPRReq.ComputerNo + "','" + objPRReq.DOP + "','" + objPRReq.Warranty + "','" + objPRReq.WarrantyDate + "','" + objPRReq.Vendor + "','" + objPRReq.Status + "','" + objPRReq.Dated + "','" + objPRReq.UID + "','" + objPRReq.UName + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getAllItemInventory(PRReq objPRReq)
        {
            string s = "select * from CIT_tbl_ItemInventory where OID='" + objPRReq.OID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllItemInventory_ITID(PRReq objPRReq)
        {
            string s = "select * from CIT_tbl_ItemInventory where OID='" + objPRReq.OID + "' and ITID='" + objPRReq.ITID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAvailableItemInventory(PRReq objPRReq)
        {
            string s = "select * from CIT_tbl_ItemInventory where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAvailableItemInventory_ITID(PRReq objPRReq)
        {
            string s = "select * from CIT_tbl_ItemInventory where OID='" + objPRReq.OID + "' and ITID='" + objPRReq.ITID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getItemInventory_IID(PRReq objPRReq)
        {
            string s = "select * from CIT_tbl_ItemInventory where OID='" + objPRReq.OID + "' and IID='" + objPRReq.IID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getItemInventory_SerialNo(PRReq objPRReq)
        {
            string s = "select * from CIT_tbl_ItemInventory where SerialNo='" + objPRReq.SerialNo + "' and ITID='" + objPRReq.ITID + "' and OID='" + objPRReq.OID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp getItemInventory4SerialNo(PRReq objPRReq)
        {
            string s = "select distinct * from CIT_tbl_ItemInventory where ITID='" + objPRReq.ITID + "' and OID='" + objPRReq.OID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp getItemInventory4SerialNobyStatus(PRReq objPRReq)
        {
            string s = "select distinct * from CIT_tbl_ItemInventory where ITID='" + objPRReq.ITID + "' and OID='" + objPRReq.OID + "' and Status = '" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getItemInventory4SerialNo_EmpID(PRReq objPRReq)
        {
            string s = "select distinct * from CIT_tbl_ItemInventory where ITID='" + objPRReq.ITID + "' and EmpID='" + objPRReq.EmpID + "' and OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp EditItemInventory_SerialNo(PRReq objPRReq)
        {
            string update = "update CIT_tbl_ItemInventory set ItemName='" + objPRReq.ItemName + "',ItemType='" + objPRReq.ItemType + "',Model='" + objPRReq.ModelType + "',SerialNo='" + objPRReq.SerialNo + "',Manufacturer='" + objPRReq.Manufacturer + "',ComputerNumber='" + objPRReq.ComputerNo + "',Warranty='" + objPRReq.Warranty + "',WarrantyDate='" + objPRReq.WarrantyDate + "',Vendor='" + objPRReq.Vendor + "',DOP='" + objPRReq.DOP + "',ITID='" + objPRReq.ITID + "',Status='" + objPRReq.Status + "' where OID='" + objPRReq.OID + "' and IID='" + objPRReq.IID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp DelItemInventory(PRReq objPRReq)
        {
            string hod = "delete from CIT_tbl_ItemInventory where  OID='" + objPRReq.OID + "' and IID='" + objPRReq.IID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }

        public PRResp getMappedInventoryDeptWise(PRReq objPRReq)
        {
            string s = @"SELECT DeptID
                , SUM(case when[ItemName] = 'Desktop' then 1 else 0 end) as Desktop
                ,SUM(case when[ItemName] = 'Laptop' then 1 else 0 end) as Laptop
                ,SUM(case when[ItemName] = 'Printer' then 1 else 0 end) as Printer
                ,SUM(case when[ItemName] = 'Scanner' then 1 else 0 end) as Scanner
                ,SUM(case when[ItemName] = 'All-in-One' then 1 else 0 end) as 'All-in-One'
                ,SUM(case when[ItemName] = 'Tablet' then 1 else 0 end) as Tablet
                FROM CIT_tbl_InventoryMapping where Flag1=1 group by DeptID";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        // Location / Buildings

        public PRResp getLocation(PRReq objPRReq)
        {
            string s = "select * from CIT_tbl_Location where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp AddLocation(PRReq objPRReq)
        {
            string insert = "insert into CIT_tbl_Location (OID,Location,Status) values('" + objPRReq.OID + "','" + objPRReq.Location + "','" + objPRReq.Status + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getLocationByName(PRReq objPRReq)
        {
            string s = "select * from CIT_tbl_Location where Location='" + objPRReq.Location + "' and OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getLocationByLID(PRReq objPRReq)
        {
            string s = "select * from CIT_tbl_Location where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and LID='" + objPRReq.LID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp EditLocationByLID(PRReq objPRReq)
        {
            string update = "update CIT_tbl_Location set OID='" + objPRReq.OID + "', Location='" + objPRReq.Location + "' where OID='" + objPRReq.OID + "' and LID='" + objPRReq.LID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp DelLocation(PRReq objPRReq)
        {
            string hod = "delete from CIT_tbl_Location where  OID='" + objPRReq.OID + "' and LID='" + objPRReq.LID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }
        public PRResp Locationsearch(PRReq objPRReq)
        {
            string s = "select * from CIT_tbl_Location where Location like '%" + objPRReq.Location + "%' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        // Floors

        public PRResp getFloors(PRReq objPRReq)
        {
            string s = "select * from CIT_tbl_Floors where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp AddFloor(PRReq objPRReq)
        {
            string insert = "insert into CIT_tbl_Floors (OID,Floor,Status) values('" + objPRReq.OID + "','" + objPRReq.Floor + "','" + objPRReq.Status + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getFloorByName(PRReq objPRReq)
        {
            string s = "select * from CIT_tbl_Floors where Floor='" + objPRReq.Floor + "' and OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getFloorByFLID(PRReq objPRReq)
        {
            string s = "select * from CIT_tbl_Floors where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and FLID='" + objPRReq.FLID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp EditFloorByFLID(PRReq objPRReq)
        {
            string update = "update CIT_tbl_Floors set Floor='" + objPRReq.Floor + "' where OID='" + objPRReq.OID + "' and FLID='" + objPRReq.FLID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp DelFloor(PRReq objPRReq)
        {
            string hod = "delete from CIT_tbl_Floors where  OID='" + objPRReq.OID + "' and FLID='" + objPRReq.FLID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }
        public PRResp Floorsearch(PRReq objPRReq)
        {
            string s = "select * from CIT_tbl_Floors where Floor like '%" + objPRReq.Floor + "%' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }


        // Rooms

        public PRResp getRoomNos(PRReq objPRReq)
        {
            string s = "select * from CIT_tbl_Rooms where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp AddRoomNos(PRReq objPRReq)
        {
            string insert = "insert into CIT_tbl_Rooms (OID,LID,Location,FLID,Floor,RoomNo,Status) values('" + objPRReq.OID + "','" + objPRReq.LID + "','" + objPRReq.Location + "','" + objPRReq.FLID + "','" + objPRReq.Floor + "','" + objPRReq.RoomNo + "','" + objPRReq.Status + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getRoomNoByName(PRReq objPRReq)
        {
            string s = "select * from CIT_tbl_Rooms where RoomNo='" + objPRReq.RoomNo + "' and OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getRoomNoByRMID(PRReq objPRReq)
        {
            string s = "select * from CIT_tbl_Rooms where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and RMID='" + objPRReq.RMID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp EditRoomNoByRMID(PRReq objPRReq)
        {
            string update = "update CIT_tbl_Rooms set LID='" + objPRReq.LID + "',Location='" + objPRReq.Location + "',FLID='" + objPRReq.FLID + "',Floor='" + objPRReq.Floor + "', RoomNo='" + objPRReq.RoomNo + "' where OID='" + objPRReq.OID + "' and RMID='" + objPRReq.RMID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp DelRoomNo(PRReq objPRReq)
        {
            string hod = "delete from CIT_tbl_Rooms where  OID='" + objPRReq.OID + "' and RMID='" + objPRReq.RMID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }
        public PRResp RoomNoSearch(PRReq objPRReq)
        {
            string s = "select * from CIT_tbl_Rooms where RoomNo like '%" + objPRReq.RoomNo + "%' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        // Halls & Hostels


        public PRResp getHalls(PRReq objPRReq)
        {
            string s = "select * from CIT_tbl_Halls where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp AddHalls(PRReq objPRReq)
        {
            string insert = "insert into CIT_tbl_Halls (OID,LID,Location,HallName,Status) values('" + objPRReq.OID + "','" + objPRReq.LID + "','" + objPRReq.Location + "','" + objPRReq.Hall + "','" + objPRReq.Status + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getHallByName(PRReq objPRReq)
        {
            string s = "select * from CIT_tbl_Halls where HallName='" + objPRReq.Hall + "' and OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getHallDetails_HID(PRReq objPRReq)
        {
            string s = "select * from CIT_tbl_Halls where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and HID='" + objPRReq.EmpID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getHallByHID(PRReq objPRReq)
        {
            string s = "select * from CIT_tbl_Halls where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and HID='" + objPRReq.HID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp EditHallByHID(PRReq objPRReq)
        {
            string update = "update CIT_tbl_Halls set LID='" + objPRReq.LID + "',Location='" + objPRReq.Location + "', HallName='" + objPRReq.Hall + "' where OID='" + objPRReq.OID + "' and HID='" + objPRReq.HID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp DelHall(PRReq objPRReq)
        {
            string hod = "delete from CIT_tbl_Halls where  OID='" + objPRReq.OID + "' and HID='" + objPRReq.HID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }
        public PRResp HallSearch(PRReq objPRReq)
        {
            string s = "select * from CIT_tbl_Halls where Hall like '%" + objPRReq.Hall + "%' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        // Map CIT Inventory to Emp

        public PRResp MapITInventorytoEmp(PRReq objPRReq)
        {
            string insert = "insert into CIT_tbl_InventoryMapping (OID,ITID,ItemName,Model,SerialNo,Manufacturer,ComputerNumber,Warranty,EmpID,Name,Design,Email,Mobile,DID,DeptID,Location,Status,Dated,UID,UName,Flag1) values('" + objPRReq.OID + "','" + objPRReq.ITID + "','" + objPRReq.ItemName + "','" + objPRReq.ModelType + "','" + objPRReq.SerialNo + "','" + objPRReq.Manufacturer + "','" + objPRReq.ComputerNo + "','" + objPRReq.Warranty + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.Design + "','" + objPRReq.Email + "','" + objPRReq.Mobile + "','" + objPRReq.DID + "','" + objPRReq.DeptID + "','" + objPRReq.Location + "','" + objPRReq.Status + "','" + objPRReq.Dated + "','" + objPRReq.UID + "','" + objPRReq.UName + "','" + objPRReq.Flag1 + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            string update = "update CIT_tbl_ItemInventory set Status = 'Active' where SerialNo = '" + objPRReq.SerialNo + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }

        public PRResp getMappedInventory_SerialNo(PRReq objPRReq)
        {
            string s = "select * from CIT_tbl_InventoryMapping where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and SerialNo='" + objPRReq.SerialNo + "' and Flag1='" + objPRReq.Flag1 + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getMappedInventory_MIID(PRReq objPRReq)
        {
            string s = "select * from CIT_tbl_InventoryMapping where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and MIID='" + objPRReq.MIID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllMappedInventory_ITID(PRReq objPRReq)
        {
            string s = "select distinct * from CIT_tbl_InventoryMapping where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ITID='" + objPRReq.ITID + "' and Flag1='1' order by EmpID Asc ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllMappedInventory_ITID_SNo(PRReq objPRReq)
        {
            string s = "select distinct * from CIT_tbl_ItemInventory where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ITID='" + objPRReq.ITID + "' and SerialNo like '%" + objPRReq.SerialNo + "%' order by SerialNo Asc ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllMappedInventory_ITID_EmpID(PRReq objPRReq)
        {
            string s = "select distinct * from CIT_tbl_InventoryMapping where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ITID='" + objPRReq.ITID + "' and EmpID='" + objPRReq.EmpID + "' and Flag1='1' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp updateMappedItemtoOthers(PRReq objPRReq)
        {
            string update = "update CIT_tbl_InventoryMapping set ITID='" + objPRReq.ITID + "',ItemName='" + objPRReq.ItemName + "',Model='" + objPRReq.ModelType + "',SerialNo='" + objPRReq.SerialNo + "',Manufacturer='" + objPRReq.Manufacturer + "',ComputerNumber='" + objPRReq.ComputerNo + "',Warranty='" + objPRReq.Warranty + "',EmpID='" + objPRReq.EmpID + "',Name='" + objPRReq.Name + "',Design='" + objPRReq.Design + "',Email='" + objPRReq.Email + "',Mobile='" + objPRReq.Mobile + "',DID='" + objPRReq.DID + "',DeptID='" + objPRReq.DeptID + "',Status='" + objPRReq.Status + "',Dated='" + objPRReq.Dated + "',UID='" + objPRReq.UID + "',UName='" + objPRReq.UName + "'  where OID='" + objPRReq.OID + "' and MIID='" + objPRReq.MIID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }

        public PRResp ReleaseMappedItem_EmpID(PRReq objPRReq)
        {
            string update = "update CIT_tbl_InventoryMapping set Flag1='" + objPRReq.Flag1 + "' , Returned ='" + DateTime.Now + "' where OID='" + objPRReq.OID + "' and MIID='" + objPRReq.MIID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            update = "update CIT_tbl_ItemInventory set Status = 'Idle' where SerialNo = (Select SerialNo from CIT_tbl_InventoryMapping where MIID ='" + objPRReq.MIID + "')";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp DelMappedITInvetoryItem(PRReq objPRReq)
        {
            string hod = "delete from CIT_tbl_InventoryMapping where  OID='" + objPRReq.OID + "' and MIID='" + objPRReq.MIID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }

        public PRResp getAllMappedInventory_EmpID(PRReq objPRReq)
        {
            string s = "select distinct ITID,ItemName from CIT_tbl_InventoryMapping where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' and Flag1='" + objPRReq.Flag1 + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllMappedInventory_EmpIDITID(PRReq objPRReq)
        {
            string s = "select distinct ITID,ItemName from CIT_tbl_InventoryMapping where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' and Flag1='" + objPRReq.Flag1 + "' and ITID='" + objPRReq.ITID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp getAllMappedInventory_SerialNo(PRReq objPRReq)
        {
            string s = "select * from CIT_tbl_InventoryMapping where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and SerialNo='" + objPRReq.SerialNo + "' order by MIID desc ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp getAllPendingAssetRequests(PRReq objPRReq)
        {
            string s = "select * from CIT_tbl_Request as c join PR_tbl_Employee as p on c.EmpID=p.EmpID where c.Status='Active'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp getAllPastAssetRequests(PRReq objPRReq)
        {
            string s = "select * from CIT_tbl_Request as c join PR_tbl_Employee as p on c.EmpID=p.EmpID where c.Status!='Active'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp changeRequest(PRReq objPRReq)
        {
            string s = "update CIT_tbl_Request set Status='" + objPRReq.Status + "' , Remark ='" + objPRReq.Remarks + "' where RID ='" + objPRReq.RID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp editRemark(PRReq objPRReq)
        {
            string s = "update CIT_tbl_Request set Remark ='" + objPRReq.Remarks + "' where RID ='" + objPRReq.RID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        // CIT Supporting Staff Registration
        public PRResp RegisterCITSupporintStaff(PRReq objPRReq)
        {
            string insert = "insert into CIT_tbl_SupportingStaff (OID,DID,DeptID,EmpID,Name,Design,Email,Password,Mobile,Role,Status,Photo,Dated,UID,UName) values('" + objPRReq.OID + "','" + objPRReq.DID + "','" + objPRReq.DeptID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.Design + "','" + objPRReq.Email + "','" + objPRReq.Password + "','" + objPRReq.Mobile + "','" + objPRReq.Role + "','" + objPRReq.Status + "','" + objPRReq.Photo + "','" + objPRReq.Dated + "','" + objPRReq.UID + "','" + objPRReq.UName + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }

        public PRResp getCITSupporintStaff(PRReq objPRReq)
        {
            string s = "select * from CIT_tbl_SupportingStaff where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and Email='" + objPRReq.Email + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getCITSupporintStaff_CSID(PRReq objPRReq)
        {
            string s = "select * from CIT_tbl_SupportingStaff where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and CSID='" + objPRReq.CSID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllCITSupporintStaff_CSID(PRReq objPRReq)
        {
            string s = "select * from CIT_tbl_SupportingStaff where OID='" + objPRReq.OID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllCITSupporintStaff(PRReq objPRReq)
        {
            string s = "select * from CIT_tbl_SupportingStaff where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp updateCITSupporintStaff_CSID(PRReq objPRReq)
        {
            string update = "update CIT_tbl_SupportingStaff set EmpID='" + objPRReq.EmpID + "',Name='" + objPRReq.Name + "',Design='" + objPRReq.Design + "',Email='" + objPRReq.Email + "',Password='" + objPRReq.Password + "',Mobile='" + objPRReq.Mobile + "',Role='" + objPRReq.Role + "',Photo='" + objPRReq.Photo + "',Dated='" + objPRReq.Dated + "',UID='" + objPRReq.UID + "',UName='" + objPRReq.UName + "' where OID='" + objPRReq.OID + "' and CSID='" + objPRReq.CSID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp BlockCITSupporintStaff_CSID(PRReq objPRReq)
        {
            string update = "update CIT_tbl_SupportingStaff set Status='" + objPRReq.Status + "', Dated='" + objPRReq.Dated + "',UID='" + objPRReq.UID + "',UName='" + objPRReq.UName + "' where OID='" + objPRReq.OID + "' and CSID='" + objPRReq.CSID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp DelCITSupporintStaff_CSID(PRReq objPRReq)
        {
            string hod = "delete from  CIT_tbl_SupportingStaff where  OID='" + objPRReq.OID + "' and CSID='" + objPRReq.CSID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }
        public PRResp CITSSLogin(PRReq objPRReq)
        {
            string s = "select * from CIT_tbl_SupportingStaff where Email='" + objPRReq.Email + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getCITSS_EmpID(PRReq objPRReq)
        {
            string s = "select * from CIT_tbl_SupportingStaff where EmpID='" + objPRReq.EmpID + "' and Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getCITSSInfo(PRReq objPRReq)
        {
            string s = "select * from  CIT_tbl_SupportingStaff where CSID='" + objPRReq.CSID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getCITUserPwd(PRReq objPRReq)
        {
            string s = "select * from CIT_tbl_SupportingStaff where Status='" + objPRReq.Status + "' and CSID='" + objPRReq.CSID + "' and Password='" + objPRReq.Password + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp ChangeCITUserPassword(PRReq objPRReq)
        {
            string update = "update CIT_tbl_SupportingStaff set Password='" + objPRReq.NewPassword + "' where CSID='" + objPRReq.CSID + "' and Status='" + objPRReq.Status + "' and Password='" + objPRReq.Password + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }

        // CIT E ticketing

        public PRResp RegisterCIT_eTicket(PRReq objPRReq)
        {
            string insert = "insert into CIT_tbl_Tickets (OID,TicketNo,DID,DeptID,EmpID,Name,Design,Mobile,Email,LID,Location,FLID,Floor,RMID,RoomNo,ITID,ItemName,AvailableTime,ProblemDescription,Dated,Flag1,Flag2,Flag3,Flag4,Status) values('" + objPRReq.OID + "','" + objPRReq.TicketNo + "','" + objPRReq.DID + "','" + objPRReq.DeptID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.Design + "','" + objPRReq.Mobile + "','" + objPRReq.Email + "','" + objPRReq.LID + "','" + objPRReq.Location + "','" + objPRReq.FLID + "','" + objPRReq.Floor + "','" + objPRReq.RMID + "','" + objPRReq.RoomNo + "','" + objPRReq.ITID + "','" + objPRReq.ItemName + "','" + objPRReq.AvailableTime + "','" + objPRReq.ProblemDescription + "','" + objPRReq.Dated + "','" + objPRReq.Flag1 + "','" + objPRReq.Flag2 + "','" + objPRReq.Flag3 + "','" + objPRReq.Flag4 + "','" + objPRReq.Status + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getCIT_eTicket(PRReq objPRReq)
        {
            string s = "select * from CIT_tbl_Tickets where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ITID='" + objPRReq.ITID + "' and ProblemDescription='" + objPRReq.ProblemDescription + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getCIT_eTicket_EmpID(PRReq objPRReq)
        {
            string s = "select distinct * from CIT_tbl_Tickets where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' and Flag1='" + objPRReq.Flag1 + "' order by TicketNo desc ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getCIT_eTicket_All(PRReq objPRReq)
        {
            string s = "select distinct * from CIT_tbl_Tickets where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "'  and Flag1='" + objPRReq.Flag1 + "' order by TicketNo desc ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getCIT_eTicket_UEmpID(PRReq objPRReq)
        {
            string s = "select distinct * from CIT_tbl_Tickets where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and UEmpID='" + objPRReq.UEmpID + "' and Flag1='" + objPRReq.Flag1 + "' and Flag2='" + objPRReq.Flag2 + "' and Flag4='" + objPRReq.Flag4 + "' order by TicketNo desc ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getCIT_eTicket_Head(PRReq objPRReq)
        {
            string s = "select distinct * from CIT_tbl_Tickets where  OID='" + objPRReq.OID + "' and Flag1='" + objPRReq.Flag1 + "' and Flag2='" + objPRReq.Flag2 + "' and Flag4='" + objPRReq.Flag4 + "' order by TicketNo desc ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllClosedCIT_eTicket_EmpID(PRReq objPRReq)
        {
            string s = "select distinct * from CIT_tbl_Tickets where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' and Flag1='" + objPRReq.Flag1 + "' and Flag2='" + objPRReq.Flag2 + "' and Flag4='" + objPRReq.Flag4 + "' order by TicketNo desc ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllHoldCIT_eTicket_EmpID(PRReq objPRReq)
        {
            string s = "select distinct * from CIT_tbl_Tickets where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' and Flag1='" + objPRReq.Flag1 + "' and Flag2='" + objPRReq.Flag2 + "' and Flag3='" + objPRReq.Flag3 + "' order by TicketNo desc ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getCIT_eTicket_UEmpID_TicketNo(PRReq objPRReq)
        {
            string s = "select distinct * from CIT_tbl_Tickets where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and UEmpID='" + objPRReq.UEmpID + "' and TicketNo='" + objPRReq.TicketNo + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllCIT_eTicket_EmpID(PRReq objPRReq)
        {
            string s = "select distinct * from CIT_tbl_Tickets where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' and Flag1='" + objPRReq.Flag1 + "' and Flag2='" + objPRReq.Flag2 + "' order by TicketNo desc ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllCIT_eTicket(PRReq objPRReq)
        {
            string s = "select * from CIT_tbl_Tickets where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllunMappedCIT_eTicket(PRReq objPRReq)
        {
            string s = "select * from CIT_tbl_Tickets where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and Flag1='" + objPRReq.Flag1 + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getMappedCIT_eTicketDetails(PRReq objPRReq)
        {
            string s = "select * from CIT_tbl_Tickets where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and Flag1='" + objPRReq.Flag1 + "' and TicketNo='" + objPRReq.TicketNo + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getMappedCIT_eTicketDetails_TicketNo(PRReq objPRReq)
        {
            string s = "select * from CIT_tbl_Tickets where OID='" + objPRReq.OID + "' and TicketNo='" + objPRReq.TicketNo + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getMappedHoldCIT_eTicketDetails(PRReq objPRReq)
        {
            string s = "select distinct * from CIT_tbl_Tickets where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and Flag1='" + objPRReq.Flag1 + "' and Flag2='" + objPRReq.Flag2 + "' and Flag3='" + objPRReq.Flag3 + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllCIT_eTicketDetails_Dates(PRReq objPRReq)
        {
            string s = "select distinct * from CIT_tbl_Tickets where OID='" + objPRReq.OID + "' AND CONVERT(DATETIME,'" + objPRReq.EndDate + "')>=Dated  and CONVERT(DATETIME,'" + objPRReq.StartDate + "')<=Dated ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllCIT_eTicketDetails_Dates_EmpID(PRReq objPRReq)
        {
            string s = "select distinct * from CIT_tbl_Tickets where OID='" + objPRReq.OID + "' and UEmpID='" + objPRReq.EmpID + "' AND CONVERT(DATETIME,'" + objPRReq.EndDate + "')>=Dated  and CONVERT(DATETIME,'" + objPRReq.StartDate + "')<=Dated ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp AssigneTicket2CITStaff(PRReq objPRReq)
        {
            string update = "update CIT_tbl_Tickets set UEmpID='" + objPRReq.UEmpID + "',UName='" + objPRReq.UName + "',UEmail='" + objPRReq.UEmail + "',UMobile='" + objPRReq.UMobile + "',Flag1='" + objPRReq.Flag1 + "',UDated='" + objPRReq.Dated + "' where OID='" + objPRReq.OID + "' and TicketNo='" + objPRReq.TicketNo + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp AcceptTicket_CITStaff(PRReq objPRReq)
        {
            string update = "update CIT_tbl_Tickets set Flag2='" + objPRReq.Flag2 + "' where OID='" + objPRReq.OID + "' and TicketNo='" + objPRReq.TicketNo + "' and UEmpID='" + objPRReq.EmpID + "' and OID='" + objPRReq.OID + "' and Flag1='" + objPRReq.Flag1 + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }

        //Dashboard UEmp
        public PRResp getCIT_eTicket_Dashboard_rows_UEmpID(PRReq objPRReq)
        {
            string s = "select distinct ITID,ItemName from CIT_tbl_Tickets where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and UEmpID='" + objPRReq.UEmpID + "' and Flag1='" + objPRReq.Flag1 + "' and Flag2='" + objPRReq.Flag2 + "' AND CONVERT(DATETIME,'" + objPRReq.EndDate + "')>=Dated  and CONVERT(DATETIME,'" + objPRReq.StartDate + "')<=Dated  ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getCIT_eTicket_Dashboard_cols_UEmpID(PRReq objPRReq)
        {
            string s = "select distinct CAST(FLOOR(CAST(Dated as FLOAT)) as DateTime) as Dated from CIT_tbl_Tickets where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and UEmpID='" + objPRReq.UEmpID + "' and Flag1='" + objPRReq.Flag1 + "' and Flag2='" + objPRReq.Flag2 + "' AND CONVERT(DATETIME,'" + objPRReq.EndDate + "')>=Dated  and CONVERT(DATETIME,'" + objPRReq.StartDate + "')<=Dated  ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getCIT_eTicket_Dashboard_colsCount_UEmpID_ITID(PRReq objPRReq)
        {
            string s = "select count(ITID) as ITID from CIT_tbl_Tickets where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and UEmpID='" + objPRReq.UEmpID + "' and ITID='" + objPRReq.ITID + "' and Flag1='" + objPRReq.Flag1 + "' and Flag2='" + objPRReq.Flag2 + "' and datediff(day, Dated, '" + objPRReq.Dated + "') = 0";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getCIT_eTicket_Dashboard_colsSum_UEmpID_ITID(PRReq objPRReq)
        {
            string s = "select count(ITID) as count from CIT_tbl_Tickets where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and UEmpID='" + objPRReq.UEmpID + "' and Flag1='" + objPRReq.Flag1 + "' and Flag2='" + objPRReq.Flag2 + "' and datediff(day, Dated, '" + objPRReq.Dated + "') = 0";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp DelCIT_eTicket_TID(PRReq objPRReq)
        {
            string hod = "delete from  CIT_tbl_Tickets where  OID='" + objPRReq.OID + "' and TID='" + objPRReq.TID + "' and Flag1='" + objPRReq.Flag1 + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }

        public PRResp BlockCIT_eTicket_TID(PRReq objPRReq)
        {
            string update = "update CIT_tbl_Tickets set Status='" + objPRReq.Status + "' where TID='" + objPRReq.TID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp ResetCIT_eTicket_TicketNo(PRReq objPRReq)
        {
            string update = "update CIT_tbl_Tickets set Flag1='" + objPRReq.Flag1 + "',Flag2='" + objPRReq.Flag2 + "' where TicketNo='" + objPRReq.TicketNo + "' and OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp CloseCIT_eTicket_TicketNo(PRReq objPRReq)
        {
            string update = "update CIT_tbl_Tickets set Flag4='" + objPRReq.Flag4 + "',Status='" + objPRReq.Status + "',CDated='" + objPRReq.Dated + "' where TicketNo='" + objPRReq.TicketNo + "' and OID='" + objPRReq.OID + "'  and UEmpID='" + objPRReq.UEmpID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp HoldCIT_eTicket_TicketNo(PRReq objPRReq)
        {
            string update = "update CIT_tbl_Tickets set Flag3='" + objPRReq.Flag3 + "' where TicketNo='" + objPRReq.TicketNo + "' and OID='" + objPRReq.OID + "' and UEmpID='" + objPRReq.UEmpID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp TransferCIT_eTicket_TicketNo(PRReq objPRReq)
        {
            string update = "update CIT_tbl_Tickets set Flag2='" + objPRReq.Flag2 + "' where TicketNo='" + objPRReq.TicketNo + "' and OID='" + objPRReq.OID + "' and UEmpID='" + objPRReq.UEmpID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp getTID(PRReq objPRReq)
        {
            string s = "select max(" + objPRReq.ColumnName + ") from CIT_tbl_Tickets where OID='" + objPRReq.OID + "' ";
            objPRResp.SingleValue = Connections.GetSingleValue(s);
            return objPRResp;
        }
        public PRResp getClosedTicketInfo(PRReq objPRReq)
        {
            string s = "select distinct * from CIT_tbl_Tickets where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and TicketNo='" + objPRReq.TicketNo + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getActiveTicketInfo(PRReq objPRReq)
        {
            string s = "select distinct * from CIT_tbl_Tickets where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and TicketNo='" + objPRReq.TicketNo + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }


        // Ticket History or Comments
        public PRResp AddeTicketComment(PRReq objPRReq)
        {
            string insert = "insert into CIT_tbl_TicketComments (OID,TicketNo,EmpID,Name,ITID,ItemName,ProblemDescription,Dated,UEmpID,UName,Comment,Status) values('" + objPRReq.OID + "','" + objPRReq.TicketNo + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.ITID + "','" + objPRReq.ItemName + "','" + objPRReq.ProblemDescription + "','" + objPRReq.Dated + "','" + objPRReq.UEmpID + "','" + objPRReq.UName + "','" + objPRReq.Comment + "','" + objPRReq.Status + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }

        public PRResp getAllTicketComment_UEmpID(PRReq objPRReq)
        {
            string s = "select * from CIT_tbl_TicketComments where OID='" + objPRReq.OID + "' and TicketNo='" + objPRReq.TicketNo + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllTicketComment_UEmpID_ITID_Comment(PRReq objPRReq)
        {
            string s = "select * from CIT_tbl_TicketComments where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and UEmpID='" + objPRReq.UEmpID + "' and Comment='" + objPRReq.Comment + "'  and ITID='" + objPRReq.ITID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp getHistoryCIT_eTicketDetails(PRReq objPRReq)
        {
            string s = "select * from CIT_tbl_TicketComments where  OID='" + objPRReq.OID + "' and TicketNo='" + objPRReq.TicketNo + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        // CIT User Dashboard
        public PRResp getAllTotalTickets_UEmpID(PRReq objPRReq)
        {
            string s = "select count(UEmpID) as count from CIT_tbl_Tickets where OID='" + objPRReq.OID + "' and UEmpID='" + objPRReq.UEmpID + "' and Flag1='" + objPRReq.Flag1 + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllNewTickets_UEmpID(PRReq objPRReq)
        {
            string s = "select count(UEmpID) as count from CIT_tbl_Tickets where OID='" + objPRReq.OID + "' and UEmpID='" + objPRReq.UEmpID + "' and Flag1='" + objPRReq.Flag1 + "' and Flag2=0 ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllInprogressTickets_UEmpID(PRReq objPRReq)
        {
            string s = "select count(UEmpID) as count from CIT_tbl_Tickets where  OID='" + objPRReq.OID + "' and UEmpID='" + objPRReq.UEmpID + "' and Flag1='" + objPRReq.Flag1 + "' and Flag2='" + objPRReq.Flag2 + "' and Flag3='" + objPRReq.Flag3 + "' and Flag4='" + objPRReq.Flag4 + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllCountTickets_UEmpID_DID(PRReq objPRReq)
        {
            string s = "select count(UEmpID) as count from CIT_tbl_Tickets where  OID='" + objPRReq.OID + "' and DID='" + objPRReq.DID + "' and UEmpID='" + objPRReq.UEmpID + "' and Flag1='" + objPRReq.Flag1 + "' and Flag2='" + objPRReq.Flag2 + "' and Flag3='" + objPRReq.Flag3 + "' and Flag4='" + objPRReq.Flag4 + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllTotCountTickets_UEmpID_DID(PRReq objPRReq)
        {
            string s = "select count(UEmpID) as count from CIT_tbl_Tickets where  OID='" + objPRReq.OID + "' and DID='" + objPRReq.DID + "' and UEmpID='" + objPRReq.UEmpID + "' and Flag1='" + objPRReq.Flag1 + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllDepts_UEmpID(PRReq objPRReq)
        {
            string s = "select distinct DID,DeptID from CIT_tbl_Tickets where OID='" + objPRReq.OID + "' and UEmpID='" + objPRReq.UEmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        // Dept Dashboard
        public PRResp getAllTotalTickets_Head(PRReq objPRReq)
        {
            string s = "select count(TicketNo) as count from CIT_tbl_Tickets where OID='" + objPRReq.OID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllUnAssignedTickets_Head(PRReq objPRReq)
        {
            string s = "select count(TicketNo) as count from CIT_tbl_Tickets where OID='" + objPRReq.OID + "' and Flag1='0' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllInprogressTickets_Head(PRReq objPRReq)
        {
            string s = "select count(TicketNo) as count from CIT_tbl_Tickets where  OID='" + objPRReq.OID + "' and Flag1='" + objPRReq.Flag1 + "' and Flag2='" + objPRReq.Flag2 + "' and Flag3='" + objPRReq.Flag3 + "' and Flag4='" + objPRReq.Flag4 + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllCountTickets_Head_DID(PRReq objPRReq)
        {
            string s = "select count(TicketNo) as count from CIT_tbl_Tickets where  OID='" + objPRReq.OID + "' and DID='" + objPRReq.DID + "' and Flag1='" + objPRReq.Flag1 + "' and Flag2='" + objPRReq.Flag2 + "' and Flag3='" + objPRReq.Flag3 + "' and Flag4='" + objPRReq.Flag4 + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllTotCountTickets_Head_DID(PRReq objPRReq)
        {
            string s = "select count(TicketNo) as count from CIT_tbl_Tickets where  OID='" + objPRReq.OID + "' and DID='" + objPRReq.DID + "' and Flag1='" + objPRReq.Flag1 + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        //Engineer DB
        public PRResp getTotalUnAssignedTickets_UEmpID(PRReq objPRReq)
        {
            string s = "select count(TicketNo) as count from CIT_tbl_Tickets where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and Flag1='" + objPRReq.Flag1 + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp getTotalNewTickets_UEmpID(PRReq objPRReq)
        {
            string s = "select count(TicketNo) as count from CIT_tbl_Tickets where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and Flag1='" + objPRReq.Flag1 + "' and UEmpID='" + objPRReq.UEmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getTotalInProgressTickets_UEmpID(PRReq objPRReq)
        {
            string s = "select count(TicketNo) as count from CIT_tbl_Tickets where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and Flag1='" + objPRReq.Flag1 + "' and Flag2='" + objPRReq.Flag2 + "' and UEmpID='" + objPRReq.UEmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp getTotalClosedTickets_UEmpID(PRReq objPRReq)
        {
            string s = "select count(TicketNo) as count from CIT_tbl_Tickets where OID='" + objPRReq.OID + "' and Flag1='" + objPRReq.Flag1 + "' and Flag2='" + objPRReq.Flag2 + "' and Flag4='" + objPRReq.Flag4 + "' and UEmpID='" + objPRReq.UEmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }


        // Leave Management
        public PRResp getGovtHolidaysbyYear(PRReq objPRReq)
        {
            string s = "select * from eL_tbl_GovtHolidays where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and (Year='" + objPRReq.Year + "' or Year='" + objPRReq.NextYear + "') and HDate>='" + objPRReq.ToDate + "' order by HDate Asc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpLeavesforApprovalProcessFlow_OEmpID_EmpID_ELeaveID_Review(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_ApprovalProcess where OID='" + objPRReq.OID + "' and OEmpID='" + objPRReq.OEmpID + "' and EleaveID='" + objPRReq.ELeaveID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpLeavesforApprovalProcessFlow_OEmpID_EmpID_ELeaveID_Recomended(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_ApprovalProcess where OID='" + objPRReq.OID + "' and OEmpID='" + objPRReq.OEmpID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getGovtHolidays(PRReq objPRReq)
        {
            string s = "select * from eL_tbl_GovtHolidays where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getGovtHolidays_PH_forProjectStaff(PRReq objPRReq)
        {
            string s = "select * from eL_tbl_GovtHolidays where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and HType='" + objPRReq.HType + "' and Year='" + objPRReq.Year + "' and (HDate='" + objPRReq.SLFromDate + "' or HDate ='" + objPRReq.SLToDate + "') ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getClosedHolidays_DDUGKY_forProjectStaff(PRReq objPRReq)
        {
            string s = "select * from eL_tbl_RegularStaff_NonEssential_ClosedHolidays where OID='" + objPRReq.OID + "' and Year='" + objPRReq.Year + "' and (HDate='" + objPRReq.SLFromDate + "' or HDate ='" + objPRReq.SLToDate + "') ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getClosedHolidays_Others_forProjectStaff(PRReq objPRReq)
        {
            string s = "select * from eL_tbl_ProjectStaff_ClosedHolidays where OID='" + objPRReq.OID + "' and Year='" + objPRReq.Year + "' and (HDate='" + objPRReq.SLFromDate + "' or HDate ='" + objPRReq.SLToDate + "') ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getGovtHolidays_PH_forRegularStaff_FromDate(PRReq objPRReq)
        {
            string s = "select * from eL_tbl_GovtHolidays where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and HType='" + objPRReq.HType + "' and (Year='" + objPRReq.Year + "' or Year='" + objPRReq.NextYear + "') and HDate='" + objPRReq.SLFromDate + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getGovtHolidays_PH_forRegularStaff_FromDate_Combi(PRReq objPRReq)
        {
            string s = "select * from eL_tbl_GovtHolidays where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and HType='" + objPRReq.HType + "' and (Year='" + objPRReq.Year + "' or Year='" + objPRReq.NextYear + "') and HDate='" + objPRReq.CLFromDate + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getGovtHolidays_PH_forRegularStaff_ToDate(PRReq objPRReq)
        {
            string s = "select * from eL_tbl_GovtHolidays where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and HType='" + objPRReq.HType + "' and (Year='" + objPRReq.Year + "' or Year='" + objPRReq.NextYear + "') and HDate ='" + objPRReq.SLToDate + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getGovtHolidays_PH_forRegularStaff_ToDate_Combi(PRReq objPRReq)
        {
            string s = "select * from eL_tbl_GovtHolidays where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and HType='" + objPRReq.HType + "' and (Year='" + objPRReq.Year + "' or Year='" + objPRReq.NextYear + "') and HDate ='" + objPRReq.CLToDate + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getWeekDayOff_forProjectStaff(PRReq objPRReq)
        {
            string s = "select * from eL_tbl_ProjectStaff_ClosedHolidays where OID='" + objPRReq.OID + "' and (Year='" + objPRReq.Year + "' or Year='" + objPRReq.NextYear + "') and (HDate>='" + objPRReq.SLFromDate + "' and HDate <='" + objPRReq.SLToDate + "') ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp AddProject_Closedholiday(PRReq objPRReq)
        {
            string insert = "insert into eL_tbl_ProjectStaff_ClosedHolidays (OID,Year,HDate,Dayno) values('" + objPRReq.OID + "','" + objPRReq.Year + "','" + objPRReq.FromDate + "','" + objPRReq.DayNo + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp get_PH_forProjectStaff(PRReq objPRReq)
        {
            string s = "select * from eL_tbl_ProjectStaff_ClosedHolidays where OID='" + objPRReq.OID + "' and HDate='" + objPRReq.FromDate + "' and Year='" + objPRReq.Year + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAll_RS_Essential_Closedholidays_Only(PRReq objPRReq)
        {
            string s = "select distinct HDate from eL_tbl_RegularStaff_Essential_ClosedHolidays where OID='" + objPRReq.OID + "' and Year='" + DateTime.Now.Year + "' and HDate='" + objPRReq.MyDate + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAll_RS_Non_Essential_Closedholidays_Only(PRReq objPRReq)
        {
            string s = "select distinct HDate from eL_tbl_RegularStaff_NonEssential_ClosedHolidays where OID='" + objPRReq.OID + "' and Year='" + DateTime.Now.Year + "' and HDate='" + objPRReq.MyDate + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAll_ProjectStaff_Closedholidays_Only(PRReq objPRReq)
        {
            string s = "select distinct HDate from eL_tbl_ProjectStaff_ClosedHolidays where OID='" + objPRReq.OID + "' and Year='" + DateTime.Now.Year + "' and HDate='" + objPRReq.MyDate + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAll_RS_Essential_Closedholidays_prefix(PRReq objPRReq)
        {
            string s = "(select distinct HDate from eL_tbl_RegularStaff_Essential_ClosedHolidays where OID='" + objPRReq.OID + "' and Year='" + objPRReq.Year + "' and (HDate <'" + objPRReq.SLFromDate + "'))union(select distinct HDate from eL_tbl_GovtHolidays where OID='" + objPRReq.OID + "' and Year='" + objPRReq.Year + "' and HType='PH' and (HDate <'" + objPRReq.SLFromDate + "')) ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAll_RS_Essential_Closedholidays_prefix_Combi(PRReq objPRReq)
        {
            string s = "(select distinct HDate from eL_tbl_RegularStaff_Essential_ClosedHolidays where OID='" + objPRReq.OID + "' and Year='" + objPRReq.Year + "' and (HDate <'" + objPRReq.CLFromDate + "'))union(select distinct HDate from eL_tbl_GovtHolidays where OID='" + objPRReq.OID + "' and Year='" + objPRReq.Year + "' and HType='PH' and (HDate <'" + objPRReq.CLFromDate + "')) ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAll_RS_Essential_Closedholidays_suffix(PRReq objPRReq)
        {
            string s = "(select distinct HDate from eL_tbl_RegularStaff_Essential_ClosedHolidays where OID='" + objPRReq.OID + "' and Year='" + objPRReq.Year + "' and (HDate >'" + objPRReq.SLToDate + "'))union(select distinct HDate from eL_tbl_GovtHolidays where OID='" + objPRReq.OID + "' and Year='" + objPRReq.Year + "' and HType='PH' and (HDate >'" + objPRReq.SLToDate + "')) ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAll_RS_Essential_Closedholidays_suffix_Combi(PRReq objPRReq)
        {
            string s = "(select distinct HDate from eL_tbl_RegularStaff_Essential_ClosedHolidays where OID='" + objPRReq.OID + "' and Year='" + objPRReq.Year + "' and (HDate >'" + objPRReq.CLToDate + "'))union(select distinct HDate from eL_tbl_GovtHolidays where OID='" + objPRReq.OID + "' and Year='" + objPRReq.Year + "' and HType='PH' and (HDate >'" + objPRReq.CLToDate + "')) ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp Add_RS_Essential_Closedholiday(PRReq objPRReq)
        {
            string insert = "insert into eL_tbl_RegularStaff_Essential_ClosedHolidays (OID,Year,HDate,Dayno) values('" + objPRReq.OID + "','" + objPRReq.Year + "','" + objPRReq.FromDate + "','" + objPRReq.DayNo + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp get_RS_Essential_Closedholidays(PRReq objPRReq)
        {
            string s = "select * from eL_tbl_RegularStaff_Essential_ClosedHolidays where OID='" + objPRReq.OID + "' and HDate='" + objPRReq.FromDate + "' and Year='" + objPRReq.Year + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp getAll_RS_Non_Essential_Closedholidays_prefix(PRReq objPRReq)
        {
            string s = "(select distinct HDate from eL_tbl_RegularStaff_NonEssential_ClosedHolidays where OID='" + objPRReq.OID + "' and Year='" + objPRReq.Year + "' and (HDate <'" + objPRReq.SLFromDate + "'))union(select distinct HDate from eL_tbl_GovtHolidays where OID='" + objPRReq.OID + "' and Year='" + objPRReq.Year + "' and HType='PH' and (HDate <'" + objPRReq.SLFromDate + "')) ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAll_RS_Non_Essential_Closedholidays_prefix_Combi(PRReq objPRReq)
        {
            string s = "(select distinct HDate from eL_tbl_RegularStaff_NonEssential_ClosedHolidays where OID='" + objPRReq.OID + "' and Year='" + objPRReq.Year + "' and (HDate <'" + objPRReq.CLFromDate + "'))union(select distinct HDate from eL_tbl_GovtHolidays where OID='" + objPRReq.OID + "' and Year='" + objPRReq.Year + "' and HType='PH' and (HDate <'" + objPRReq.CLFromDate + "')) ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAll_RS_Non_Essential_Closedholidays_suffix(PRReq objPRReq)
        {
            string s = "(select distinct HDate from eL_tbl_RegularStaff_NonEssential_ClosedHolidays where OID='" + objPRReq.OID + "' and Year='" + objPRReq.Year + "' and (HDate >'" + objPRReq.SLToDate + "'))union(select distinct HDate from eL_tbl_GovtHolidays where OID='" + objPRReq.OID + "' and Year='" + objPRReq.Year + "' and HType='PH' and (HDate >'" + objPRReq.SLToDate + "')) ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAll_RS_Non_Essential_Closedholidays_suffix_Combi(PRReq objPRReq)
        {
            string s = "(select distinct HDate from eL_tbl_RegularStaff_NonEssential_ClosedHolidays where OID='" + objPRReq.OID + "' and Year='" + objPRReq.Year + "' and (HDate >'" + objPRReq.CLToDate + "'))union(select distinct HDate from eL_tbl_GovtHolidays where OID='" + objPRReq.OID + "' and Year='" + objPRReq.Year + "' and HType='PH' and (HDate >'" + objPRReq.CLToDate + "')) ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAll_RS_Non_Essential_Closedholidays_PH(PRReq objPRReq)
        {
            string s = "(select distinct HDate from eL_tbl_RegularStaff_NonEssential_ClosedHolidays where OID='" + objPRReq.OID + "' and Year='" + objPRReq.Year + "' and (HDate >'" + objPRReq.SLFromDate + "' and HDate <'" + objPRReq.SLToDate + "')) union(select distinct HDate from eL_tbl_GovtHolidays where OID='" + objPRReq.OID + "' and Year='" + objPRReq.Year + "' and HType='PH' and (HDate >'" + objPRReq.SLFromDate + "' and HDate <'" + objPRReq.SLToDate + "')) ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAll_ProjectStaff_Closedholidays_PH(PRReq objPRReq)
        {
            string s = "(select distinct HDate from eL_tbl_ProjectStaff_ClosedHolidays where OID='" + objPRReq.OID + "' and Year='" + objPRReq.Year + "' and (HDate >'" + objPRReq.SLFromDate + "' and HDate <'" + objPRReq.SLToDate + "')) union(select distinct HDate from eL_tbl_GovtHolidays where OID='" + objPRReq.OID + "' and Year='" + objPRReq.Year + "' and HType='PH' and (HDate >'" + objPRReq.SLFromDate + "' and HDate <'" + objPRReq.SLToDate + "')) ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAll_ProjectStaff_Closedholidays_PH_MissedDates(PRReq objPRReq)
        {
            string s = "(select distinct HDate from eL_tbl_ProjectStaff_ClosedHolidays where OID='" + objPRReq.OID + "' and Year='" + objPRReq.Year + "' and HDate='" + objPRReq.Dated + "') union(select distinct HDate from eL_tbl_GovtHolidays where OID='" + objPRReq.OID + "' and Year='" + objPRReq.Year + "' and HType='PH' and HDate='" + objPRReq.Dated + "') ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAll_ProjectStaff_Closedholidays_suffix(PRReq objPRReq)
        {
            string s = "(select distinct HDate from eL_tbl_ProjectStaff_ClosedHolidays where OID='" + objPRReq.OID + "' and Year='" + objPRReq.Year + "' and (HDate >'" + objPRReq.SLToDate + "'))union(select distinct HDate from eL_tbl_GovtHolidays where OID='" + objPRReq.OID + "' and Year='" + objPRReq.Year + "' and HType='PH' and (HDate >'" + objPRReq.SLToDate + "')) ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAll_ProjectStaff_Closedholidays_prefix(PRReq objPRReq)
        {
            string s = "(select distinct HDate from eL_tbl_ProjectStaff_ClosedHolidays where OID='" + objPRReq.OID + "' and Year='" + objPRReq.Year + "' and (HDate <'" + objPRReq.SLFromDate + "'))union(select distinct HDate from eL_tbl_GovtHolidays where OID='" + objPRReq.OID + "' and Year='" + objPRReq.Year + "' and HType='PH' and (HDate <'" + objPRReq.SLFromDate + "')) ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAll_RS_Non_Essential_Closedholidays_PH_Combi(PRReq objPRReq)
        {
            string s = "(select distinct HDate from eL_tbl_RegularStaff_NonEssential_ClosedHolidays where OID='" + objPRReq.OID + "' and Year='" + objPRReq.Year + "' and (HDate >'" + objPRReq.CLFromDate + "' and HDate <'" + objPRReq.CLToDate + "')) union(select distinct HDate from eL_tbl_GovtHolidays where OID='" + objPRReq.OID + "' and Year='" + objPRReq.Year + "' and HType='PH' and (HDate >'" + objPRReq.CLFromDate + "' and HDate <'" + objPRReq.CLToDate + "')) ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAll_RS_NON_Essential_Closedholidays(PRReq objPRReq)
        {
            string s = "select * from eL_tbl_RegularStaff_NonEssential_ClosedHolidays where OID='" + objPRReq.OID + "' and Year='" + objPRReq.Year + "' and (HDate>='" + objPRReq.SLFromDate + "' and HDate <='" + objPRReq.SLToDate + "') ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp Add_RS_NON_Essential_Closedholiday(PRReq objPRReq)
        {
            string insert = "insert into eL_tbl_RegularStaff_NonEssential_ClosedHolidays (OID,Year,HDate,Dayno) values('" + objPRReq.OID + "','" + objPRReq.Year + "','" + objPRReq.FromDate + "','" + objPRReq.DayNo + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp get_RS_NON_Essential_Closedholidays(PRReq objPRReq)
        {
            string s = "select * from eL_tbl_RegularStaff_NonEssential_ClosedHolidays where OID='" + objPRReq.OID + "' and HDate='" + objPRReq.FromDate + "' and Year='" + objPRReq.Year + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp AddGovtHoliday(PRReq objPRReq)
        {
            string insert = "insert into eL_tbl_GovtHolidays (OID,Year,HTID,HType,HolidayType,Holiday,HDate,Status) values('" + objPRReq.OID + "','" + objPRReq.Year + "','" + objPRReq.HTID + "','" + objPRReq.HType + "','" + objPRReq.HolidayType + "','" + objPRReq.Holiday + "','" + objPRReq.HDate + "','" + objPRReq.Status + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getGovtHolidayByDate(PRReq objPRReq)
        {
            string s = "select * from eL_tbl_GovtHolidays where HTID='" + objPRReq.HTID + "' and HDate='" + objPRReq.HDate + "' and OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getGovtHolidayByLHID(PRReq objPRReq)
        {
            string s = "select * from eL_tbl_GovtHolidays where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and LHID='" + objPRReq.LHID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp EditGovtHolidaybyHTId(PRReq objPRReq)
        {
            string update = "update eL_tbl_GovtHolidays set HTID='" + objPRReq.HTID + "', HolidayType='" + objPRReq.HolidayType + "',Holiday='" + objPRReq.Holiday + "', HDate='" + objPRReq.HDate + "' where OID='" + objPRReq.OID + "' and LHID='" + objPRReq.LHID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp DelGovtHoliday(PRReq objPRReq)
        {
            string hod = "delete from eL_tbl_GovtHolidays where  OID='" + objPRReq.OID + "' and LHID='" + objPRReq.LHID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }
        public PRResp GovtHolidaySearch(PRReq objPRReq)
        {
            string s = "select * from eL_tbl_GovtHolidays where HDate like '%" + objPRReq.HDate + "%' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getHolidayTypes(PRReq objPRReq)
        {
            string s = "select * from eL_tbl_HolidayType where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        //PS Leave Types
        public PRResp getPSLeaveTypes(PRReq objPRReq)
        {
            string s = "select * from eL_tbl_PSLeaveTypes where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and LTID!='2'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getPS_LeaveTypes(PRReq objPRReq)
        {
            string s = "select * from eL_tbl_PSLeaveTypes where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and LTID!='3'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        // Leave Types
        public PRResp getLeaveTypes(PRReq objPRReq)
        {
            string s = "select * from eL_tbl_LeaveTypes where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and LTID!='12' and LTID!='15' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getLeaveTypes_Male(PRReq objPRReq)
        {
            string s = "select * from eL_tbl_LeaveTypes where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and LTID!='12' and LTID!='15' and LTID!='9' and LTID!='11' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getLeaveTypes_Female(PRReq objPRReq)
        {
            string s = "select * from eL_tbl_LeaveTypes where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and LTID!='12' and LTID!='15' and LTID!='8' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getLeaveTypesBalance(PRReq objPRReq)
        {
            string s = "select * from eL_tbl_LeaveTypes where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and (LTID='1' or LTID='2' or LTID='3' or LTID='5')";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getLeaveTypesBalance_Female(PRReq objPRReq)
        {
            string s = "select * from eL_tbl_LeaveTypes where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and (LTID='1' or LTID='2' or LTID='3' or LTID='5' or LTId='11')";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getLeaveTypesBalance_ProjectStaff(PRReq objPRReq)
        {
            string s = "select * from eL_tbl_PSLeaveTypes where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and LTID!='3'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp get_CL_CombiLeaveTypes(PRReq objPRReq)
        {
            string s = "select * from eL_tbl_LeaveTypes where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and LeaveType!='" + objPRReq.ColumnName + "' and (LeaveType='RH' or LeaveType='CPL') ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp get_RH_CombiLeaveTypes(PRReq objPRReq)
        {
            string s = "select * from eL_tbl_LeaveTypes where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and LeaveType!='" + objPRReq.ColumnName + "' and (LeaveType='CL' or LeaveType='EL' or LeaveType='CPL') ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp get_EL_CombiLeaveTypes(PRReq objPRReq)
        {
            string s = "select * from eL_tbl_LeaveTypes where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and LeaveType!='" + objPRReq.ColumnName + "' and (LeaveType='RH' or LeaveType='CML' or LeaveType='HPL' or LeaveType='EOL') ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp get_HPL_CombiLeaveTypes(PRReq objPRReq)
        {
            string s = "select * from eL_tbl_LeaveTypes where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and LeaveType!='" + objPRReq.ColumnName + "' and (LeaveType='EL' or LeaveType='ML') ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp get_CML_CombiLeaveTypes(PRReq objPRReq)
        {
            string s = "select * from eL_tbl_LeaveTypes where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and LeaveType!='" + objPRReq.ColumnName + "' and (LeaveType='EL' or LeaveType='EOL' or LeaveType='CCL') ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp get_EOL_CombiLeaveTypes(PRReq objPRReq)
        {
            string s = "select * from eL_tbl_LeaveTypes where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and LeaveType!='" + objPRReq.ColumnName + "' and (LeaveType='SL') ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp get_ML_CombiLeaveTypes(PRReq objPRReq)
        {
            string s = "select * from eL_tbl_LeaveTypes where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and LeaveType!='" + objPRReq.ColumnName + "' and (LeaveType='CCL' or LeaveType='EL' or LeaveType='CML') ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp get_PL_CombiLeaveTypes(PRReq objPRReq)
        {
            string s = "select * from eL_tbl_LeaveTypes where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and LeaveType!='" + objPRReq.ColumnName + "' and (LeaveType='CL' or LeaveType='EL') ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp get_CCL_CombiLeaveTypes(PRReq objPRReq)
        {
            string s = "select * from eL_tbl_LeaveTypes where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and LeaveType!='" + objPRReq.ColumnName + "' and (LeaveType='ML' or LeaveType='EL' or LeaveType='HPL') ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp get_CPL_CombiLeaveTypes(PRReq objPRReq)
        {
            string s = "select * from eL_tbl_LeaveTypes where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and LeaveType!='" + objPRReq.ColumnName + "' and (LeaveType='CL' or LeaveType='RH') ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp get_SL_CombiLeaveTypes(PRReq objPRReq)
        {
            string s = "select * from eL_tbl_LeaveTypes where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and LeaveType!='" + objPRReq.ColumnName + "' and (LeaveType='EL' or LeaveType='EOL') ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp AddLeaveType(PRReq objPRReq)
        {
            string insert = "insert into eL_tbl_LeaveTypes (OID,LeaveType,LeaveFullForm,LTMaxDays,AvailDays,Status) values('" + objPRReq.OID + "','" + objPRReq.LeaveType + "','" + objPRReq.LeaveTypeFullform + "','" + objPRReq.LTMaxDays + "','" + objPRReq.AvailDays + "','" + objPRReq.Status + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getLeaveTypeByLeaveType(PRReq objPRReq)
        {
            string s = "select * from eL_tbl_LeaveTypes where LTID='" + objPRReq.LTID + "' and LeaveType='" + objPRReq.LeaveType + "' and OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getLeaveTypeByLTID(PRReq objPRReq)
        {
            string s = "select * from eL_tbl_LeaveTypes where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and LTID='" + objPRReq.LTID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp EditLeaveTypebyLTID(PRReq objPRReq)
        {
            string update = "update eL_tbl_LeaveTypes set LeaveType='" + objPRReq.LeaveType + "', LeaveFullForm='" + objPRReq.LeaveTypeFullform + "',LTMaxDays='" + objPRReq.LTMaxDays + "',AvailDays='" + objPRReq.AvailDays + "' where OID='" + objPRReq.OID + "' and LTID='" + objPRReq.LTID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp DelLeaveType(PRReq objPRReq)
        {
            string hod = "delete from eL_tbl_LeaveTypes where  OID='" + objPRReq.OID + "' and LTID='" + objPRReq.LTID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }
        public PRResp LeaveTypeSearch(PRReq objPRReq)
        {
            string s = "select * from eL_tbl_LeaveTypes where LeaveType like '%" + objPRReq.HDate + "%' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }


        // Officer Levels

        public PRResp getOfficerLevels(PRReq objPRReq)
        {
            string s = "select * from eL_tbl_OfficerLevel where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp AddOfficerLevel(PRReq objPRReq)
        {
            string insert = "insert into eL_tbl_OfficerLevel (OID,OfficerLevel,Status) values('" + objPRReq.OID + "','" + objPRReq.OfficerLevel + "','" + objPRReq.Status + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getOfficerLevelByName(PRReq objPRReq)
        {
            string s = "select * from eL_tbl_OfficerLevel where OfficerLevel='" + objPRReq.OfficerLevel + "' and OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getOfficerLevelByOLID(PRReq objPRReq)
        {
            string s = "select * from eL_tbl_OfficerLevel where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and OLID='" + objPRReq.OLID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp EditOfficerLevelByOLID(PRReq objPRReq)
        {
            string update = "update eL_tbl_OfficerLevel set OfficerLevel='" + objPRReq.OfficerLevel + "' where OID='" + objPRReq.OID + "' and OLID='" + objPRReq.OLID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp DelOfficerLevel(PRReq objPRReq)
        {
            string hod = "delete from eL_tbl_OfficerLevel where  OID='" + objPRReq.OID + "' and OLID='" + objPRReq.OLID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }
        public PRResp OfficerLevelSearch(PRReq objPRReq)
        {
            string s = "select * from eL_tbl_OfficerLevel where OfficerLevel like '%" + objPRReq.OfficerLevel + "%' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        // Dealing Asst
        public PRResp AddLeaveDealingAssts(PRReq objPRReq)
        {
            string insert = "INSERT INTO eL_tbl_DealingAssistants(OID,UserID,Password,EmpID,Name,Design,DeptID,Email,Mobile,Photo,Role,Status,UID,UName) values('" + objPRReq.OID + "','" + objPRReq.UserID + "','" + objPRReq.Password + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.Design + "','" + objPRReq.DeptID + "','" + objPRReq.Email + "','" + objPRReq.Mobile + "','" + objPRReq.Photo + "','" + objPRReq.Role + "','" + objPRReq.Status + "','" + objPRReq.UID + "','" + objPRReq.UName + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getLeaveDealingAssts(PRReq objPRReq)
        {
            string s = "select * from eL_tbl_DealingAssistants where OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllLeaveDealingAssts(PRReq objPRReq)
        {
            string s = "select * from eL_tbl_DealingAssistants where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp EditLeaveDealingAsstLDAID(PRReq objPRReq)
        {
            string update = "update eL_tbl_OfficerLevel set UserID='" + objPRReq.UserID + "',EmpID='" + objPRReq.EmpID + "',Name='" + objPRReq.Name + "',Design='" + objPRReq.Design + "',DeptID='" + objPRReq.DeptID + "',Email='" + objPRReq.Email + "',Mobile='" + objPRReq.Mobile + "',Photo='" + objPRReq.Photo + "',Role='" + objPRReq.Role + "',Status='" + objPRReq.Status + "',UID='" + objPRReq.UID + "',UName='" + objPRReq.UName + "' where OID='" + objPRReq.OID + "' and LDAID='" + objPRReq.LDAID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp BlockLeaveDealingAsstLDAID(PRReq objPRReq)
        {
            string update = "update eL_tbl_OfficerLevel set Status='" + objPRReq.Status + "',UID='" + objPRReq.UID + "',UName='" + objPRReq.UName + "' where OID='" + objPRReq.OID + "' and LDAID='" + objPRReq.LDAID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }

        // Map Employee to LDA
        public PRResp Add_Emp2LDA(PRReq objPRReq)
        {
            string insert = "INSERT INTO eL_tbl_EmpLeaves(OID,ETID,EmpType,ECID,EmpCategory,EGID,EmpGroup,DID,DeptID,EmpID,Name,DSID,Design,Email,Mobile,DOB,DOJ,DOR,Gender,Photo,Status) values('" + objPRReq.OID + "','" + objPRReq.ETID + "','" + objPRReq.EmpType + "','" + objPRReq.ECID + "','" + objPRReq.EmpCategory + "','" + objPRReq.EGID + "','" + objPRReq.EmpGroup + "','" + objPRReq.DID + "','" + objPRReq.DeptID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.DSID + "','" + objPRReq.Design + "','" + objPRReq.Email + "','" + objPRReq.Mobile + "','" + objPRReq.DOB + "','" + objPRReq.DOJ + "','" + objPRReq.DOR + "','" + objPRReq.Gender + "','" + objPRReq.Photo + "','" + objPRReq.Status + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getEmpLeavesByEmpID_UID(PRReq objPRReq)
        {
            string s = "select * from eL_tbl_EmpLeaves where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp getEmpLeavesByEmpID_UIDBalance(PRReq objPRReq)
        {
            string s = "select distinct CL,RH,EL,HPL from eL_tbl_EmpLeaves where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getPSEmpLeavesByEmpID_UIDBalance(PRReq objPRReq)
        {
            string s = "select distinct CL,SL from PR_tbl_ProjectStaff_CLs where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpLeavesByEmpID_LBalance(PRReq objPRReq)
        {
            string s = "select distinct " + objPRReq.ColumnName + " as LBalance from eL_tbl_EmpLeaves where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' and " + objPRReq.ColumnName + ">=0 ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp getEmpLeavesByEmpID_LDAID(PRReq objPRReq)
        {
            string s = "select * from eL_tbl_EmpLeaves where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' and LDAID='" + objPRReq.UserID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpLeavesByEmpID_eLDA_UID(PRReq objPRReq)
        {
            string s = "select * from eL_tbl_EmpLeaves where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and LDAID='" + objPRReq.UserID + "' order by EmpID Asc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpLeavesByEmpID_DG(PRReq objPRReq)
        {
            string s = "select * from eL_tbl_EmpLeaves where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "'  order by EmpID Asc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getDeprtment_WiseEmpLeavesAvailedBy_HOC(PRReq objPRReq)
        {
            string s = "select * from eL_tbl_EmpLeaves where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and DID='" + objPRReq.DID + "' order by EmpID Asc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpLeavesByEmpID_eLDA(PRReq objPRReq)
        {
            string s = "select * from eL_tbl_EmpLeaves where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and LDAID='" + objPRReq.UserID + "' and Essential is Null order by EmpID Asc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpLeavesByEmpID_eLDAID(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_EmpLeaves where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and LDAID='" + objPRReq.UserID + "' order by EmpID Asc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpLeavesByEmpID_eLDAID_ECID(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_EmpLeaves where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ECID='" + objPRReq.ECID + "' and LDAID='" + objPRReq.UserID + "' order by EmpID Asc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpLeavesByEmpID_Column(PRReq objPRReq)
        {
            string s = "select " + objPRReq.ColumnName + " as col from eL_tbl_EmpLeaves where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' and " + objPRReq.ColumnName + ">=0 ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getPSEmpLeavesByEmpID_Column(PRReq objPRReq)
        {
            string s = "select " + objPRReq.ColumnName + " as col,DID from PR_tbl_ProjectStaff_CLs where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpLeavesByEmpID_LeaveColumn(PRReq objPRReq)
        {
            string s = "select distinct " + objPRReq.ColumnName + " as col, Name, Design from eL_tbl_EmpLeaves where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' and " + objPRReq.ColumnName + ">=0 ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpLeavesByEmpID_LeaveType(PRReq objPRReq)
        {
            string s = "select distinct EmpID,Name,Design,DeptID,CL,RH,EL,CML,HPL,EOL,SL,PL,ML,SCL,CCL,STL,CPL,DL,VL from eL_tbl_EmpLeaves where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmp_EssentialStatus(PRReq objPRReq)
        {
            string s = "select distinct Essential from eL_tbl_EmpLeaves where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp updateEmpLeavesByEmpID_Column(PRReq objPRReq)
        {
            string update = "update eL_tbl_EmpLeaves set " + objPRReq.ColumnName + "='" + objPRReq.NoofLeaves + "' where OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }

        public PRResp updatePSEmpLeavesByEmpID_Column(PRReq objPRReq)
        {
            string update = "update PR_tbl_ProjectStaff_CLs set " + objPRReq.ColumnName + "='" + objPRReq.NoofLeaves + "' where OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' and Status='" + objPRReq.Status + "' and Year='" + DateTime.Now.Year + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp update_REmp_CL_RH_YearlyOnce(PRReq objPRReq)
        {
            string update = "update eL_tbl_EmpLeaves set CL='" + objPRReq.CL + "',RH='" + objPRReq.RH + "' where OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp update_REmp_ColName_Balance(PRReq objPRReq)
        {
            string update = "update eL_tbl_EmpLeaves set " + objPRReq.ColumnName + "='" + objPRReq.NoofLeaves + "' where OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' and Status='" + objPRReq.Status + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp update_REmp_EL_HPL_HalfYearlyOnce(PRReq objPRReq)
        {
            string update = "update eL_tbl_EmpLeaves set EL='" + objPRReq.EL + "',HPL='" + objPRReq.HPL + "' where OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp Map_Emp2LDA_EmpID(PRReq objPRReq)
        {
            string update = "update eL_tbl_EmpLeaves set UID='" + objPRReq.UID + "',UName='" + objPRReq.UName + "',Dated='" + objPRReq.Dated + "' where OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp UpdateEssentialStatusofEmp_Emp2LDA_EmpID(PRReq objPRReq)
        {
            string update = "update eL_tbl_EmpLeaves set Essential='" + objPRReq.EssentialStatus + "' where OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp getAllun_mappedEmp2LDA(PRReq objPRReq)
        {
            string s = "select * from eL_tbl_EmpLeaves where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and LDAID is NULL order by EmpID Asc ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAll_mappedEmp2LDA_EmpID(PRReq objPRReq)
        {
            string s = "select * from eL_tbl_EmpLeaves where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAll_EmpEleaves(PRReq objPRReq)
        {
            string s = "select distinct EmpID,Name,Design,CL,RH,EL,CML,HPL,EOL,SL,PL,ML,SCL,CCL,STL,CPL,DL,VL from eL_tbl_EmpLeaves where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAll_EmpEleaves_LDAID(PRReq objPRReq)
        {
            string s = "select distinct EmpID,Name,Design,CL,RH,EL,CML,HPL,EOL,SL,PL,ML,SCL,CCL,STL,CPL,DL,VL from eL_tbl_EmpLeaves where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and LDAID='" + objPRReq.UserID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp BlockEmp2LDA_EmpID(PRReq objPRReq)
        {
            string update = "update eL_tbl_EmpLeaves set Status='" + objPRReq.Status + "' where OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }

        public PRResp UpdateLeavesEmp2LDA_EmpID(PRReq objPRReq)
        {
            string update = "update eL_tbl_EmpLeaves set CL='" + objPRReq.CL + "',RH='" + objPRReq.RH + "',EL='" + objPRReq.EL + "',CML='" + objPRReq.CML + "',HPL='" + objPRReq.HPL + "',EOL='" + objPRReq.EOL + "',SL='" + objPRReq.SL + "',PL='" + objPRReq.PL + "',ML='" + objPRReq.ML + "',SCL='" + objPRReq.SCL + "',CCL='" + objPRReq.CCL + "',STL='" + objPRReq.STL + "',CPL='" + objPRReq.CPL + "',DL='" + objPRReq.DL + "',VL='" + objPRReq.VL + "',LDAID='" + objPRReq.UserID + "',DAName='" + objPRReq.Name + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }

        public PRResp Update_Deduct_LeavesEmp2LDA_EmpID(PRReq objPRReq)
        {
            string update = "update eL_tbl_RegStaff_eLeave_Applied set LDeduct='1' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' and ELeaveID='" + objPRReq.ELeaveID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }

        public PRResp AddColumn_Emp2LDA_EmpID(PRReq objPRReq)
        {
            string s = "if not exists (select * from INFORMATION_SCHEMA.columns where table_name = 'eL_tbl_EmpLeaves' and column_name = '" + objPRReq.ColumnName + "') alter table eL_tbl_EmpLeaves add " + objPRReq.ColumnName + " [decimal](18, 1) DEFAULT (0) with values ";
            objPRResp.SingleValue = Connections.GetSingleValue(s);
            return objPRResp;
        }

        public PRResp Add_EmpApproved_Leaves_Deducation_AvailedStatus(PRReq objPRReq)
        {
            string insert = "INSERT INTO eL_tbl_RegStaff_Apprvd_eLeave_Availed(OID,ELeaveID,EmpID,Name,Design,LeaveType,ActualDays,AvailedDays,RemainingDays,LApprovalFile,Remarks,LDAID,LDAName,Dated,Status) values('" + objPRReq.OID + "','" + objPRReq.ELeaveID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.Design + "','" + objPRReq.LeaveType + "','" + objPRReq.ActualDays + "','" + objPRReq.AvailedDays + "','" + objPRReq.RemainingDays + "','" + objPRReq.SLFileName + "','" + objPRReq.Remarks + "','" + objPRReq.UserID + "','" + objPRReq.LDAName + "','" + objPRReq.Dated + "','" + objPRReq.Status + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getEmpApproved_Leaves_Deducation_AvailedStatus(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_Apprvd_eLeave_Availed where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' and ELeaveID='" + objPRReq.ELeaveID + "' and LeaveType='" + objPRReq.AvailedDays + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp Update_Status_AvailedLeavesEmp2LDA_EmpID_ELeaveID(PRReq objPRReq)
        {
            string update = "update eL_tbl_EmpLeaves set " + objPRReq.ColumnName + "='" + objPRReq.RemainingDays + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }

        // Add Emp Leave Flow
        public PRResp Add_EmpLeaveWorkFlow(PRReq objPRReq)
        {
            string insert = "INSERT INTO eL_tbl_EmpLeaveFlow(OID,DID,DeptID,EmpID,Name,DSID,Design,Email,Mobile,OfficerLevel,Action,OEmpID,OName,Status,UID,UName,Dated) values('" + objPRReq.OID + "','" + objPRReq.DID + "','" + objPRReq.DeptID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.DSID + "','" + objPRReq.Design + "','" + objPRReq.Email + "','" + objPRReq.Mobile + "','" + objPRReq.OfficerLevel + "','" + objPRReq.LAction + "','" + objPRReq.OEmpID + "','" + objPRReq.OEmpName + "','" + objPRReq.Status + "','" + objPRReq.UID + "','" + objPRReq.UName + "','" + objPRReq.Dated + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getEmpLeaveWorkFlow_EmpID_OEmpID_Level(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_EmpLeaveFlow where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' and OfficerLevel='" + objPRReq.OfficerLevel + "' and Action='" + objPRReq.LAction + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpLeaveWorkFlow_EmpID_OEmpID(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_EmpLeaveFlow where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' and OEmpID='" + objPRReq.OEmpID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpLeaveWorkFlow_EmpID__WFLevel(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_EmpLeaveFlow where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' and OfficerLevel='" + objPRReq.OfficerLevel + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpLeaveWorkFlow_EmpID_ELID(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_EmpLeaveFlow where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ELID='" + objPRReq.ELID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpLeaveWorkFlow_EmpID_OEmpID_Level_forUpdate(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_EmpLeaveFlow where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and OEmpID='" + objPRReq.OEmpID + "' and OfficerLevel='" + objPRReq.OfficerLevel + "' order by EmpID Asc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp getEmpeL_tbl_EmpLeaves_LDA_forUpdate(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_EmpLeaves where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and LDAID='" + objPRReq.UserID + "' order by EmpID Asc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAll_EmpWorkflows_EmpID(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_EmpLeaveFlow where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' order by OfficerLevel Asc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpLeaveWorkFlow_EmpID(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_EmpLeaveFlow where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp getEmpLeaveWorkFlow_EmpID_L1(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_EmpLeaveFlow where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' and OfficerLevel='" + objPRReq.OfficerLevel + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp getEmpLeaveWorkFlow_EmpID_OEmpID_OLevel(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_EmpLeaveFlow where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' and OfficerLevel='" + objPRReq.OLevel + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp UpdateEmpLeaveWorkFlow_EmpID_OEmpID_Level_ELID(PRReq objPRReq)
        {
            string update = "update eL_tbl_EmpLeaveFlow set DID='" + objPRReq.DID + "',DeptID='" + objPRReq.DeptID + "',DSID='" + objPRReq.DSID + "',Design='" + objPRReq.Design + "',Email='" + objPRReq.Email + "',Mobile='" + objPRReq.Mobile + "',OfficerLevel='" + objPRReq.OfficerLevel + "',Action='" + objPRReq.LAction + "',OEmpID='" + objPRReq.OEmpID + "',OName='" + objPRReq.OEmpName + "',UID='" + objPRReq.UserID + "', UName='" + objPRReq.UName + "',Dated='" + objPRReq.Dated + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ELID='" + objPRReq.ELID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp DelEmpLeaveWorkFlow_ELID(PRReq objPRReq)
        {
            string hod = "delete from eL_tbl_EmpLeaveFlow where  OID='" + objPRReq.OID + "' and ELID='" + objPRReq.ELID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }
        public PRResp UpdateEmpLeaveWorkFlow_EmpID_OEmpID_Level_BulkUpdate(PRReq objPRReq)
        {
            string update = "update eL_tbl_EmpLeaveFlow set OEmpID='" + objPRReq.OEmpID + "', OName='" + objPRReq.OName + "' where OfficerLevel='" + objPRReq.OfficerLevel + "' and EmpID='" + objPRReq.EmpID + "'and OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }

        public PRResp ChangeOldLDA_NewLDA(PRReq objPRReq)
        {
            string update = "update eL_tbl_EmpLeaves set LDAID='" + objPRReq.UserID + "', DAName='" + objPRReq.OName + "' where LDAID='" + objPRReq.OLevel + "' and OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' and Status='" + objPRReq.Status + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp getEmpLeaveWorkFlow_ELeaveID_OEmpID(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_ApprovalProcess where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ELeaveID='" + objPRReq.ELeaveID + "' and OEmpID='" + objPRReq.OEmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        // E Leve Approval Process
        public PRResp Add_EmpLeaveApprovalProcess(PRReq objPRReq)
        {
            string insert = "INSERT INTO eL_tbl_RegStaff_eLeave_ApprovalProcess(OID,ELeaveID,Dated,EmpID,Name,OEmpID,OName,OLevel,Decision,Action,Remarks,Status,UID,UName,Flag1,Flag2,Flag3,Flag4,Flag5,Approval,Reject,LSO,LDA,LCancel,LPullBack) values('" + objPRReq.OID + "','" + objPRReq.ELeaveID + "','" + objPRReq.Dated + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.OEmpID + "','" + objPRReq.OName + "','" + objPRReq.OLevel + "','" + objPRReq.LDecision + "','" + objPRReq.LAction + "','" + objPRReq.Remarks + "','" + objPRReq.Status + "','" + objPRReq.UID + "','" + objPRReq.UName + "','" + objPRReq.Flag1 + "','" + objPRReq.Flag2 + "','" + objPRReq.Flag3 + "','" + objPRReq.Flag4 + "','" + objPRReq.Flag5 + "','" + objPRReq.Approval + "','" + objPRReq.Reject + "','" + objPRReq.LSO + "','" + objPRReq.LDA + "','" + objPRReq.LCancel + "','" + objPRReq.LPullBack + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp Add_EmpLeave_Extension_ApprovalProcess(PRReq objPRReq)
        {
            string insert = "INSERT INTO eL_tbl_RegStaff_eLeave_JR_Ext_Curt_Cancel_ApprovalProcess(OID,ELeaveID,Dated,EmpID,Name,OEmpID,OName,OLevel,Decision,Action,Remarks,Status,UID,UName,Flag1,Flag2,Flag3,Flag4,Flag5,Approval,Reject,LSO,LDA,LCancel,LPullBack) values('" + objPRReq.OID + "','" + objPRReq.ELeaveID + "','" + objPRReq.Dated + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.OEmpID + "','" + objPRReq.OName + "','" + objPRReq.OLevel + "','" + objPRReq.LDecision + "','" + objPRReq.LAction + "','" + objPRReq.Remarks + "','" + objPRReq.Status + "','" + objPRReq.UID + "','" + objPRReq.UName + "','" + objPRReq.Flag1 + "','" + objPRReq.Flag2 + "','" + objPRReq.Flag3 + "','" + objPRReq.Flag4 + "','" + objPRReq.Flag5 + "','" + objPRReq.Approval + "','" + objPRReq.Reject + "','" + objPRReq.LSO + "','" + objPRReq.LDA + "','" + objPRReq.LCancel + "','" + objPRReq.LPullBack + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp UpdateEmpLeaveApplied_EmpID_OEmpID_Flag1_ReIniateRejectedLeave(PRReq objPRReq)
        {
            string update = "update eL_tbl_RegStaff_eLeave_Applied set Flag1='" + objPRReq.Flag1 + "', Reject='0', CurrentStatus='" + objPRReq.CurrentLeaveStatus + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "'  and ELeaveID='" + objPRReq.ELeaveID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp UpdateEmpLeaveApplied_EmpID_OEmpID_Flag1(PRReq objPRReq)
        {
            string update = "update eL_tbl_RegStaff_eLeave_Applied set Flag1='" + objPRReq.Flag1 + "',CurrentStatus='" + objPRReq.CurrentLeaveStatus + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "'  and ELeaveID='" + objPRReq.ELeaveID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp UpdateEmpLeave_JR_Curt_Ext_Applied_EmpID_OEmpID_Flag1(PRReq objPRReq)
        {
            string update = "update eL_tbl_RegStaff_eLeave_JR_Ext_Curt_Cancel set Flag1='" + objPRReq.Flag1 + "',CurrentStatus='" + objPRReq.CurrentLeaveStatus + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "'  and ELeaveID='" + objPRReq.ELeaveID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp UpdateEmpLeaveApplied_EmpID_OEmpID_JR_Extend_Curtail(PRReq objPRReq)
        {
            string update = "update eL_tbl_RegStaff_eLeave_Applied set " + objPRReq.ColumnName + "='1', CurrentStatus='" + objPRReq.CurrentLeaveStatus + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "'  and ELeaveID='" + objPRReq.ELeaveID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp UpdateEmpLeaveApplied_EmpID_OEmpID_Flag2(PRReq objPRReq)
        {
            string update = "update eL_tbl_RegStaff_eLeave_Applied set Flag2='" + objPRReq.Flag2 + "',CurrentStatus='" + objPRReq.CurrentLeaveStatus + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ELeaveID='" + objPRReq.ELeaveID + "' and Flag1='1' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp UpdateEmpLeave_JR_Curt_Ext_Applied_EmpID_OEmpID_Flag2(PRReq objPRReq)
        {
            string update = "update eL_tbl_RegStaff_eLeave_JR_Ext_Curt_Cancel set Flag2='" + objPRReq.Flag2 + "',CurrentStatus='" + objPRReq.CurrentLeaveStatus + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ELeaveID='" + objPRReq.ELeaveID + "' and Flag1='1' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp UpdateEmpLeaveApplied_EmpID_OEmpID_Flag3(PRReq objPRReq)
        {
            string update = "update eL_tbl_RegStaff_eLeave_Applied set Flag3='" + objPRReq.Flag3 + "',CurrentStatus='" + objPRReq.CurrentLeaveStatus + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ELeaveID='" + objPRReq.ELeaveID + "' and Flag1='1' and Flag2='1' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp UpdateEmpLeave_JR_Curt_Ext_Applied_EmpID_OEmpID_Flag3(PRReq objPRReq)
        {
            string update = "update eL_tbl_RegStaff_eLeave_JR_Ext_Curt_Cancel set Flag3='" + objPRReq.Flag3 + "',CurrentStatus='" + objPRReq.CurrentLeaveStatus + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ELeaveID='" + objPRReq.ELeaveID + "' and Flag1='1' and Flag2='1' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp UpdateEmpLeaveApplied_EmpID_OEmpID_Flag4(PRReq objPRReq)
        {
            string update = "update eL_tbl_RegStaff_eLeave_Applied set Flag4='" + objPRReq.Flag4 + "',CurrentStatus='" + objPRReq.CurrentLeaveStatus + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "'  and ELeaveID='" + objPRReq.ELeaveID + "' and Flag1='1' and Flag2='1' and Flag3='1' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp UpdateEmpLeave_JR_Curt_Ext_Applied_EmpID_OEmpID_Flag4(PRReq objPRReq)
        {
            string update = "update eL_tbl_RegStaff_eLeave_JR_Ext_Curt_Cancel set Flag4='" + objPRReq.Flag4 + "',CurrentStatus='" + objPRReq.CurrentLeaveStatus + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "'  and ELeaveID='" + objPRReq.ELeaveID + "' and Flag1='1' and Flag2='1' and Flag3='1' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp UpdateEmpLeaveApplied_EmpID_OEmpID_Flag5(PRReq objPRReq)
        {
            string update = "update eL_tbl_RegStaff_eLeave_Applied set Flag5='" + objPRReq.Flag5 + "',CurrentStatus='" + objPRReq.CurrentLeaveStatus + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ELeaveID='" + objPRReq.ELeaveID + "' and Flag1='1' and Flag2='1' and Flag3='1' and Flag4='1' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp UpdateEmpLeave_JR_Curt_Ext_Applied_EmpID_OEmpID_Flag5(PRReq objPRReq)
        {
            string update = "update eL_tbl_RegStaff_eLeave_JR_Ext_Curt_Cancel set Flag5='" + objPRReq.Flag5 + "',CurrentStatus='" + objPRReq.CurrentLeaveStatus + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ELeaveID='" + objPRReq.ELeaveID + "' and Flag1='1' and Flag2='1' and Flag3='1' and Flag4='1' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp UpdateEmpLeaveAppliedSanction_ELeaveID_Approval(PRReq objPRReq)
        {
            string update = "update eL_tbl_RegStaff_eLeave_Applied set Approval='" + objPRReq.Approval + "',CurrentStatus='" + objPRReq.CurrentLeaveStatus + "' where OID='" + objPRReq.OID + "' and ELeaveID='" + objPRReq.ELeaveID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp UpdateEmpLeave_JR_Curt_Extx_AppliedSanction_ELeaveID_Approval_ToDate_Noofdays(PRReq objPRReq)
        {
            string update = "update eL_tbl_RegStaff_eLeave_Applied set SLToDate='" + objPRReq.SLToDate + "', SLNoofDays='" + objPRReq.SLNoofDays + "',CurrentStatus='" + objPRReq.CurrentLeaveStatus + "', JoinDate='" + objPRReq.JoinDate + "', SLSufixDates='" + objPRReq.SLSufixDates + "' where OID='" + objPRReq.OID + "' and ELeaveID='" + objPRReq.ELeaveID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp UpdateEmpLeave_JR_Curt_Extx_AppliedSanction_ELeaveID_Approval_ToDate_Noofdays_JR(PRReq objPRReq)
        {
            string update = "update eL_tbl_RegStaff_eLeave_Applied set SLToDate='" + objPRReq.SLToDate + "', SLNoofDays='" + objPRReq.SLNoofDays + "',CurrentStatus='" + objPRReq.CurrentLeaveStatus + "', JR='2', JoinDate='" + objPRReq.JoinDate + "', SLSufixDates='" + objPRReq.SLSufixDates + "' where OID='" + objPRReq.OID + "' and ELeaveID='" + objPRReq.ELeaveID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp UpdateEmpLeave_JR_Curt_Extx_AppliedSanction_ELeaveID_Approval_ToDate_Noofdays_Ext(PRReq objPRReq)
        {
            string update = "update eL_tbl_RegStaff_eLeave_Applied set SLToDate='" + objPRReq.SLToDate + "', SLNoofDays='" + objPRReq.SLNoofDays + "',CurrentStatus='" + objPRReq.CurrentLeaveStatus + "', Ext='2', JoinDate='" + objPRReq.JoinDate + "', SLSufixDates='" + objPRReq.SLSufixDates + "' where OID='" + objPRReq.OID + "' and ELeaveID='" + objPRReq.ELeaveID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp UpdateEmpLeave_JR_Curt_Extx_AppliedSanction_ELeaveID_Approval_ToDate_Noofdays_Curt(PRReq objPRReq)
        {
            string update = "update eL_tbl_RegStaff_eLeave_Applied set SLToDate='" + objPRReq.SLToDate + "', SLNoofDays='" + objPRReq.SLNoofDays + "',CurrentStatus='" + objPRReq.CurrentLeaveStatus + "', Curt='2', JoinDate='" + objPRReq.JoinDate + "', SLSufixDates='" + objPRReq.SLSufixDates + "' where OID='" + objPRReq.OID + "' and ELeaveID='" + objPRReq.ELeaveID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp UpdateEmpLeave_JR_Curt_Extx_AppliedSanction_ELeaveID_Approval(PRReq objPRReq)
        {
            string update = "update eL_tbl_RegStaff_eLeave_JR_Ext_Curt_Cancel set Approval='" + objPRReq.Approval + "',CurrentStatus='" + objPRReq.CurrentLeaveStatus + "' where OID='" + objPRReq.OID + "' and ELeaveID='" + objPRReq.ELeaveID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp UpdateEmpLeaveProcess_EmpID_OEmpID_Flag1(PRReq objPRReq)
        {
            string update = "update eL_tbl_RegStaff_eLeave_ApprovalProcess set Flag1='" + objPRReq.Flag1 + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "'  and ELeaveID='" + objPRReq.ELeaveID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp UpdateEmpLeave_JR_Curt_Ext_Process_EmpID_OEmpID_Flag1(PRReq objPRReq)
        {
            string update = "update eL_tbl_RegStaff_eLeave_JR_Ext_Curt_Cancel_ApprovalProcess set Flag1='" + objPRReq.Flag1 + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "'  and ELeaveID='" + objPRReq.ELeaveID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp UpdateEmpLeaveProcess_EmpID_OEmpID_Flag2(PRReq objPRReq)
        {
            string update = "update eL_tbl_RegStaff_eLeave_ApprovalProcess set Flag2='" + objPRReq.Flag2 + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ELeaveID='" + objPRReq.ELeaveID + "' and Flag1='1' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp UpdateEmpLeave_JR_Curt_Ext_Process_EmpID_OEmpID_Flag2(PRReq objPRReq)
        {
            string update = "update eL_tbl_RegStaff_eLeave_JR_Ext_Curt_Cancel_ApprovalProcess set Flag2='" + objPRReq.Flag2 + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ELeaveID='" + objPRReq.ELeaveID + "' and Flag1='1' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp UpdateEmpLeaveProcess_EmpID_OEmpID_Flag3(PRReq objPRReq)
        {
            string update = "update eL_tbl_RegStaff_eLeave_ApprovalProcess set Flag3='" + objPRReq.Flag3 + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ELeaveID='" + objPRReq.ELeaveID + "' and Flag1='1' and Flag2='1' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp UpdateEmpLeave_JR_Curt_Ext_Process_EmpID_OEmpID_Flag3(PRReq objPRReq)
        {
            string update = "update eL_tbl_RegStaff_eLeave_JR_Ext_Curt_Cancel_ApprovalProcess set Flag3='" + objPRReq.Flag3 + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ELeaveID='" + objPRReq.ELeaveID + "' and Flag1='1' and Flag2='1' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp UpdateEmpLeaveProcess_EmpID_OEmpID_Flag4(PRReq objPRReq)
        {
            string update = "update eL_tbl_RegStaff_eLeave_ApprovalProcess set Flag4='" + objPRReq.Flag4 + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "'  and ELeaveID='" + objPRReq.ELeaveID + "' and Flag1='1' and Flag2='1' and Flag3='1' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp UpdateEmpLeave_JR_Curt_Ext_Process_EmpID_OEmpID_Flag4(PRReq objPRReq)
        {
            string update = "update eL_tbl_RegStaff_eLeave_JR_Ext_Curt_Cancel_ApprovalProcess set Flag4='" + objPRReq.Flag4 + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "'  and ELeaveID='" + objPRReq.ELeaveID + "' and Flag1='1' and Flag2='1' and Flag3='1' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp UpdateEmpLeaveProcess_EmpID_OEmpID_Flag5(PRReq objPRReq)
        {
            string update = "update eL_tbl_RegStaff_eLeave_ApprovalProcess set Flag5='" + objPRReq.Flag5 + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ELeaveID='" + objPRReq.ELeaveID + "' and Flag1='1' and Flag2='1' and Flag3='1' and Flag4='1' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp UpdateEmpLeave_JR_Curt_Ext_Process_EmpID_OEmpID_Flag5(PRReq objPRReq)
        {
            string update = "update eL_tbl_RegStaff_eLeave_JR_Ext_Curt_Cancel_ApprovalProcess set Flag5='" + objPRReq.Flag5 + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ELeaveID='" + objPRReq.ELeaveID + "' and Flag1='1' and Flag2='1' and Flag3='1' and Flag4='1' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp UpdateEmpLeave_JR_Curt_Ext_Process_CurrentStatus_ELeaveID(PRReq objPRReq)
        {
            string update = "update eL_tbl_RegStaff_eLeave_Applied set CurrentStatus='" + objPRReq.CurrentLeaveStatus + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ELeaveID='" + objPRReq.ELeaveID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            string updates = "update eL_tbl_RegStaff_eLeave_JR_Ext_Curt_Cancel set CurrentStatus='" + objPRReq.CurrentLeaveStatus + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ELeaveID='" + objPRReq.ELeaveID + "' ";
            objPRResp.Count = Connections.ProcessQuery(updates);
            return objPRResp;
        }
        public PRResp UpdateEmpLeaveProcess_ELeaveID_Approval(PRReq objPRReq)
        {
            string update = "update eL_tbl_RegStaff_eLeave_ApprovalProcess set Approval='" + objPRReq.Approval + "' where OID='" + objPRReq.OID + "' and ELeaveID='" + objPRReq.ELeaveID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp UpdateEmpLeave_JR_Curt_Ext_Process_ELeaveID_Approval(PRReq objPRReq)
        {
            string update = "update eL_tbl_RegStaff_eLeave_JR_Ext_Curt_Cancel_ApprovalProcess set Approval='" + objPRReq.Approval + "' where OID='" + objPRReq.OID + "' and ELeaveID='" + objPRReq.ELeaveID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        // Apply Leave Employee
        public PRResp AddEmpLeave_History(PRReq objPRReq)
        {
            string insert = "INSERT INTO eL_tbl_RegStaff_eLeave_History (OID,ELeaveID,Dated,EmpID,Name,OEmpID,OName,Action,Remarks) values('" + objPRReq.OID + "','" + objPRReq.ELeaveID + "','" + objPRReq.Dated + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.OEmpID + "','" + objPRReq.OName + "','" + objPRReq.LAction + "','" + objPRReq.Remarks + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getEmpLeave_History_Repeated_ELeaveID(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_History where OID='" + objPRReq.OID + "' and ELeaveID='" + objPRReq.ELeaveID + "' and Action='" + objPRReq.LAction + "' and OEmpID='" + objPRReq.OEmpID + "' and Remarks='" + objPRReq.Remarks + "' order by ELHID Desc ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpLeave_History_ELeaveID(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_History where OID='" + objPRReq.OID + "' and ELeaveID='" + objPRReq.ELeaveID + "' order by ELHID Desc ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpLeave_ApprovedBy_ELeaveID(PRReq objPRReq)
        {
            string s = "select distinct Name from eL_tbl_RegStaff_eLeave_History where OID='" + objPRReq.OID + "' and ELeaveID='" + objPRReq.ELeaveID + "' and Action='Sanctioned' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp getEmpTour_ApprovedBy_ETourID(PRReq objPRReq)
        {
            string s = "select distinct Name from eT_tbl_RegStaff_eTour_History where OID='" + objPRReq.OID + "' and ETourID='" + objPRReq.ETourID + "' and Action='Sanctioned' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpLeaves_Availed_EmpID(PRReq objPRReq)
        {
            string s = "select sum(SLNoofDays) as totL from eL_tbl_RegStaff_eLeave_Applied where OID='" + objPRReq.OID + "' and SLeaveType='" + objPRReq.SLeaveType + "' and Approval='1' and EmpID='" + objPRReq.EmpID + "' and (SLFromDate >= convert(datetime,'" + objPRReq.SLFromDate + "',105) and SLToDate<= convert(datetime,'" + objPRReq.SLToDate + "',105)) ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpLeaves_Availed_EmpID_Combi(PRReq objPRReq)
        {
            string s = "select sum(CLNoofDays) as totL from eL_tbl_RegStaff_eLeave_Applied where OID='" + objPRReq.OID + "' and CLeaveType='" + objPRReq.CLeaveType + "' and Approval='1' and EmpID='" + objPRReq.EmpID + "' and (CLFromDate >= convert(datetime,'" + objPRReq.SLFromDate + "',105) and CLToDate<= convert(datetime,'" + objPRReq.SLToDate + "',105)) ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getPSEmpLeaves_Availed_EmpID(PRReq objPRReq)
        {
            string s = "select sum(SLNoofDays) as totL from eL_tbl_ProjStaff_eLeave_Applied where OID='" + objPRReq.OID + "' and LeaveCategory='" + objPRReq.SLeaveType + "' and Approval='1' and EmpID='" + objPRReq.EmpID + "' and SLFromDate>= convert(datetime,'" + objPRReq.MyDate + "',106)  ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp getRSCalYear(PRReq objPRReq)
        {
            string s = "select distinct CONVERT(CHAR(4), Dated, 120) as Year from eL_tbl_RegStaff_eLeave_Applied";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp getEmpLeave_Info_ELeaveID(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_Applied where OID='" + objPRReq.OID + "' and ELeaveID='" + objPRReq.ELeaveID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpLeave_JR_Curt_Ext_Info_ELeaveID(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_JR_Ext_Curt_Cancel where OID='" + objPRReq.OID + "' and ELeaveID='" + objPRReq.ELeaveID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAttendance_EmpLeave_DatesEmpID_onCLDate_SLDate(PRReq objPRReq)
        {
            string s = "select * from eL_tbl_RegStaff_eLeave_Applied where OID='" + objPRReq.OID + "' and LCancel='0' and Reject='0' and ((SLFromDate <= '" + objPRReq.SLFromDate + "' or SLToDate >= '" + objPRReq.SLToDate + "') or (CLFromDate <= '" + objPRReq.CLFromDate + "' or CLToDate >= '" + objPRReq.CLToDate + "')) order by EmpID Asc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAttendance_EmpLeave_DatesEmpID_onCLDate_SLDate_Att_Report(PRReq objPRReq)
        {
            string s = "select * from eL_tbl_RegStaff_eLeave_Applied where OID='" + objPRReq.OID + "' and LCancel='0' and Reject='0' order by EmpID Asc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAttendance_eL_tbl_RegStaff_eLeave_JR_Ext_Curt_Cancel_Att_Report(PRReq objPRReq)
        {
            string s = "select * from eL_tbl_RegStaff_eLeave_JR_Ext_Curt_Cancel where OID='" + objPRReq.OID + "' and LCancel='0' and Reject='0' order by EmpID Asc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp get_Approved_EmpLeave_DatesEmpID_onCLDate_SLDate(PRReq objPRReq)
        {
            string s = "select * from eL_tbl_RegStaff_eLeave_Applied where OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' and Approval='1' and (SLFromDate >= convert(datetime, '" + objPRReq.SLFromDate + "',105) and SLFromDate < convert(datetime, '" + objPRReq.SLToDate + "',105) or (CLFromDate >= convert(datetime, '" + objPRReq.CLFromDate + "',105) and CLFromDate < convert(datetime, '" + objPRReq.CLToDate + "',105))) order by ELeaveID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp get_Approved_EmpLeave_DatesEmpID_onCLDate_SLDate_LeaveType(PRReq objPRReq)
        {
            string s = "select * from eL_tbl_RegStaff_eLeave_Applied where OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' and Approval='1' and (SLFromDate >= convert(datetime, '" + objPRReq.SLFromDate + "',105) and SLFromDate < convert(datetime, '" + objPRReq.SLToDate + "',105) or (CLFromDate >= convert(datetime, '" + objPRReq.CLFromDate + "',105) and CLFromDate < convert(datetime, '" + objPRReq.CLToDate + "',105))) and (SLeaveType='" + objPRReq.LeaveType + "' or CLeaveType='" + objPRReq.LeaveType + "')";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp get_Officer_EmpLeave_Status_onCLDate_SLDate(PRReq objPRReq)
        {
            string s = "select * from eL_tbl_RegStaff_eLeave_Applied where OID='" + objPRReq.OID + "' and OEmpID='" + objPRReq.OEmpID + "'  and (SLFromDate >= convert(datetime, '" + objPRReq.SLFromDate + "',105) and SLFromDate < convert(datetime, '" + objPRReq.SLToDate + "',105) or (CLFromDate >= convert(datetime, '" + objPRReq.CLFromDate + "',105) and CLFromDate < convert(datetime, '" + objPRReq.CLToDate + "',105))) order by Dated Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp get_Officer_PSEmpLeave_Status_onCLDate_SLDate(PRReq objPRReq)
        {
            string s = "select * from eL_tbl_ProjStaff_eLeave_Applied where OID='" + objPRReq.OID + "' and (HEmpID='" + objPRReq.OEmpID + "' or PCEmpID='" + objPRReq.OEmpID + "') and (SLFromDate >= convert(datetime, '" + objPRReq.SLFromDate + "',105) and SLFromDate < convert(datetime, '" + objPRReq.SLToDate + "',105)) order by Dated Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp get_Approved_PSEmpLeave_DatesEmpID_on_SLDate_LeaveType(PRReq objPRReq)
        {
            string s = "select * from eL_tbl_ProjStaff_eLeave_Applied where OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' and Approval='1' and (SLFromDate >= convert(datetime, '" + objPRReq.SLFromDate + "',105) and SLFromDate < convert(datetime, '" + objPRReq.SLToDate + "',105)) and LeaveCategory='" + objPRReq.LeaveType + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp get_Approved_EmpLeave_Year_DG(PRReq objPRReq)
        {
            string s = "select * from eL_tbl_RegStaff_eLeave_Applied where OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' and YEAR(Dated)='" + objPRReq.Year + "' and Approval='1' order by SLeaveType Asc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp get_Approved_EmpTours_Year_DG(PRReq objPRReq)
        {
            string s = "select * from eT_tbl_RegStaff_eTour_Applied where OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' and YEAR(Dated)='" + objPRReq.Year + "' and Approval='1' order by Dated Asc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp get_AllApproved_EmpLeave_Dates_onCLDate_SLDate(PRReq objPRReq)
        {
            string s = "select * from eL_tbl_RegStaff_eLeave_Applied where OID='" + objPRReq.OID + "' and Approval='1' and (SLFromDate >= convert(datetime, '" + objPRReq.SLFromDate + "',105) and SLFromDate < convert(datetime, '" + objPRReq.SLToDate + "',105) or (CLFromDate >= convert(datetime, '" + objPRReq.CLFromDate + "',105) and CLFromDate < convert(datetime, '" + objPRReq.CLToDate + "',105))) order by ELeaveID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getApproved_EmpOnLeave_Today_DatesEmpID_onCLDate_SLDate(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_Applied where OID='" + objPRReq.OID + "' and LCancel='0' and Reject='0' and ((SLFromDate <= convert(datetime, '" + objPRReq.SLFromDate + "',105) and SLToDate >= convert(datetime, '" + objPRReq.SLToDate + "',105) or (CLFromDate <= convert(datetime, '" + objPRReq.CLFromDate + "',105) and CLToDate >= convert(datetime, '" + objPRReq.CLToDate + "',105))) or (CONVERT(DATETIME,SLFromDate)<=getdate() and CONVERT(DATETIME,SLToDate)>=getdate())or(CONVERT(DATETIME,CLFromDate)<=getdate() and CONVERT(DATETIME,CLToDate)>=getdate())) and Status='Active' order by DeptID Asc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getPSApproved_EmpOnLeave_Today_DatesEmpID_on_SLDate(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_ProjStaff_eLeave_Applied where OID='" + objPRReq.OID + "' and LCancel='0' and Reject='0' and ((SLFromDate <= convert(datetime, '" + objPRReq.SLFromDate + "',105) and SLToDate >= convert(datetime, '" + objPRReq.SLToDate + "',105)) or (CONVERT(DATETIME,SLFromDate)<=getdate() and CONVERT(DATETIME,SLToDate)>=getdate())) and Status='Active' order by DeptID Asc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAttendance_ProjEmpLeave_DatesEmpID_onCLDate_SLDate(PRReq objPRReq)
        {
            string s = "select * from eL_tbl_ProjStaff_eLeave_Applied where OID='" + objPRReq.OID + "' and LCancel='0' and Reject='0' and (SLFromDate >= '" + objPRReq.SLFromDate + "' or SLToDate <= '" + objPRReq.SLToDate + "' ) order by EmpID Asc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAttendance_ProjEmpLeave_DatesEmpID_onCLDate_SLDate_Att_Report(PRReq objPRReq)
        {
            string s = "select * from eL_tbl_ProjStaff_eLeave_Applied where OID='" + objPRReq.OID + "' and LCancel='0' and Reject='0' order by EmpID Asc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAttendance_AllApproved_LExpectionalRequests_onLDate(PRReq objPRReq)
        {
            string s = "select * from eL_tbl_EmpLateExceptions where OID='" + objPRReq.OID + "' and Flag1='1' and (LDate >= '" + objPRReq.SLFromDate + "'  or LDate <= '" + objPRReq.SLToDate + "' )";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAttendance_AllApproved_LExpectionalRequests_onLDate_Att_Report(PRReq objPRReq)
        {
            string s = "select * from eL_tbl_EmpLateExceptions where OID='" + objPRReq.OID + "' and Flag1='1' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp AddEmpLeaveDates(PRReq objPRReq)
        {
            string insert = "INSERT INTO ATT_eL_tbl_Dates (OID,EmpID,ELeaveID,LeaveType,Dates,Days,Status,MonthYear) values('" + objPRReq.OID + "','" + objPRReq.EmpID + "','" + objPRReq.ELeaveID + "','" + objPRReq.LeaveType + "','" + objPRReq.Dates + "','" + objPRReq.Days + "','" + objPRReq.Status + "','" + objPRReq.MonthYear + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp AddEmpLExceptionalDates(PRReq objPRReq)
        {
            string insert = "INSERT INTO ATT_eLExp_tbl_Dates (OID,EmpID,ELeaveID,LeaveType,LSession,Dates,Days,Status,MonthYear) values('" + objPRReq.OID + "','" + objPRReq.EmpID + "','" + objPRReq.ELeaveID + "','" + objPRReq.LeaveType + "','" + objPRReq.SLFromSession + "','" + objPRReq.Dates + "','" + objPRReq.Days + "','" + objPRReq.Status + "','" + objPRReq.MonthYear + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getEmpExpLeaveDates_Attendance_EmpID_onCLDate_SLDate(PRReq objPRReq)
        {
            string s = "select distinct * from ATT_eLExp_tbl_Dates where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' and Dates='" + objPRReq.Dates + "' and LSession='" + objPRReq.SLFromSession + "' and LeaveType='" + objPRReq.LeaveType + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpLeaveDates_Attendance_EmpID_onCLDate_SLDate(PRReq objPRReq)
        {
            string s = "select distinct * from ATT_eL_tbl_Dates where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' and Dates='" + objPRReq.Dates + "'  and LeaveType='" + objPRReq.LeaveType + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp gettruncate_EmpExceptionalsDates()
        {
            string s = "truncate table ATT_eLExp_tbl_Dates ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        //Re-Generating report
        public PRResp DelMissedDates_MonthYear(PRReq objPRReq)
        {
            string hod = "delete from ATT_tbl_MissedDates where MonthYear='" + objPRReq.MonthYear + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }
        public PRResp DelLeaveDates_MonthYear(PRReq objPRReq)
        {
            string hod = "delete from ATT_eL_tbl_Dates where MonthYear='" + objPRReq.MonthYear + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }
        public PRResp DelTourDates_MonthYear(PRReq objPRReq)
        {
            string hod = "delete from ATT_eT_tbl_Dates where MonthYear='" + objPRReq.MonthYear + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }

        public PRResp DelExceptionDates_MonthYear(PRReq objPRReq)
        {
            string hod = "delete from ATT_eLExp_tbl_Dates where MonthYear='" + objPRReq.MonthYear + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }
        public PRResp DelHoursReport_MonthYear(PRReq objPRReq)
        {
            string hod = "delete from ATT_tbl_Bio_Att_Monthly_HoursReport where MonthYear='" + objPRReq.MonthYear + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }
        public PRResp DelMonthlyAttReport_MonthYear(PRReq objPRReq)
        {
            string hod = "delete from ATT_tbl_Bio_Att_MonthlyReport where MonthYear='" + objPRReq.MonthYear + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }

        public PRResp gettruncate_EmpLeaves()
        {
            string s = "truncate table ATT_eL_tbl_Dates ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAttendance_ProjEmpTour_DatesEmpID_onCLDate_SLDate(PRReq objPRReq)
        {
            string s = "select * from eT_tbl_ProjStaff_eTour_Applied where OID='" + objPRReq.OID + "'  and TCancel='0' and Reject='0' and (SLFromDate <= '" + objPRReq.SLFromDate + "' or SLToDate >= '" + objPRReq.SLToDate + "' ) order by EmpID Asc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAttendance_ProjEmpTour_DatesEmpID_onCLDate_SLDate_Att_Report(PRReq objPRReq)
        {
            string s = "select * from eT_tbl_ProjStaff_eTour_Applied where OID='" + objPRReq.OID + "'  and TCancel='0' and Reject='0' order by EmpID Asc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAttendance_EmpTour_DatesEmpID_onCLDate_SLDate(PRReq objPRReq)
        {
            string s = "select * from eT_tbl_RegStaff_eTour_Applied where OID='" + objPRReq.OID + "'  and LCancel='0' and Reject='0' and (FromDate >= '" + objPRReq.SLFromDate + "' or ToDate <= '" + objPRReq.SLToDate + "') order by EmpID Asc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAttendance_EmpTour_DatesEmpID_onCLDate_SLDate_Att_Report(PRReq objPRReq)
        {
            string s = "select * from eT_tbl_RegStaff_eTour_Applied where OID='" + objPRReq.OID + "'  and LCancel='0' and Reject='0' order by EmpID Asc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getApproved_EmponTour_today_DatesEmpID_onCLDate_SLDate(PRReq objPRReq)
        {
            string s = "select distinct * from eT_tbl_RegStaff_eTour_Applied where OID='" + objPRReq.OID + "' and LCancel='0' and Reject='0' and (FromDate <= convert(datetime, '" + objPRReq.FromDate + "',105) and ToDate >= convert(datetime, '" + objPRReq.ToDate + "',105)) or (CONVERT(DATETIME,FromDate)<=getdate() and CONVERT(DATETIME,ToDate)>=getdate()) and Status='Active' order by DeptID Asc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getPSApproved_EmponTour_today_DatesEmpID_on_SLDate(PRReq objPRReq)
        {
            string s = "select distinct * from eT_tbl_ProjStaff_eTour_Applied where OID='" + objPRReq.OID + "' and TCancel='0' and Reject='0' and (SLFromDate <= convert(datetime, '" + objPRReq.SLFromDate + "',105) and SLToDate >= convert(datetime, '" + objPRReq.SLToDate + "',105)) or (CONVERT(DATETIME,SLFromDate)<=getdate() and CONVERT(DATETIME,SLToDate)>=getdate()) and Status='Active' order by DeptID Asc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp AddEmpMissingDates(PRReq objPRReq)
        {
            string insert = "INSERT INTO ATT_tbl_MissedDates (OID,EmpID,Dates,Days,Status,MonthYear) values('" + objPRReq.OID + "','" + objPRReq.EmpID + "','" + objPRReq.Dates + "','" + objPRReq.Days + "','" + objPRReq.Status + "','" + objPRReq.MonthYear + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getMissedDates_MonthYear_EmpID(PRReq objPRReq)
        {
            string s = "select distinct Dates from ATT_tbl_MissedDates where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' and MonthYear='" + objPRReq.MonthYear + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getMissedDates_MonthYear_EmpID_Dates(PRReq objPRReq)
        {
            string s = "select distinct Dates from ATT_tbl_MissedDates where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and Dates='" + objPRReq.Dated + "' and EmpID='" + objPRReq.EmpID + "' and MonthYear='" + objPRReq.MonthYear + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getLeaveDates_forMissingDate_MonthYear_EmpID(PRReq objPRReq)
        {
            string s = "select distinct Dates from ATT_eL_tbl_Dates where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' and MonthYear='" + objPRReq.MonthYear + "' and Dates='" + objPRReq.Dates + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getTourDates_forMissingDate_MonthYear_EmpID(PRReq objPRReq)
        {
            string s = "select distinct Dates from ATT_eT_tbl_Dates where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' and MonthYear='" + objPRReq.MonthYear + "'  and Dates='" + objPRReq.Dates + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getExceptionalDates_forMissingDate_MonthYear_EmpID(PRReq objPRReq)
        {
            string s = "select distinct Dates from ATT_eLExp_tbl_Dates where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' and MonthYear='" + objPRReq.MonthYear + "'  and Dates='" + objPRReq.Dates + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getPDates_forMissingDate_MonthYear_EmpID(PRReq objPRReq)
        {
            string s = "select distinct Date from ATT_tbl_Biometric_Attendance where Status='P' and EmpID='" + objPRReq.EmpID + "' and MonthYear='" + objPRReq.MonthYear + "' and  Date='" + objPRReq.Dates + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp AddEmpTourDates(PRReq objPRReq)
        {
            string insert = "INSERT INTO ATT_eT_tbl_Dates (OID,EmpID,ETourID,TourType,Dates,Days,Status,MonthYear) values('" + objPRReq.OID + "','" + objPRReq.EmpID + "','" + objPRReq.ETourID + "','" + objPRReq.TourType + "','" + objPRReq.Dates + "','" + objPRReq.Days + "','" + objPRReq.Status + "','" + objPRReq.MonthYear + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getEmpTourDates_Attendance_EmpID_onCLDate_SLDate(PRReq objPRReq)
        {
            string s = "select distinct * from ATT_eT_tbl_Dates where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' and Dates='" + objPRReq.Dates + "' and TourType='" + objPRReq.TourType + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp gettruncate_EmpTours()
        {
            string s = "truncate table ATT_eT_tbl_Dates ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpLeaveDates_SumforAttendnace(PRReq objPRReq)
        {
            string s = "select distinct sum(Days) as days from ATT_eL_tbl_Dates where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' and MonthYear='" + objPRReq.MonthYear + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpLeaveDates_Status(PRReq objPRReq)
        {
            string s = "select distinct * from ATT_eL_tbl_Dates where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' and MonthYear='" + objPRReq.MonthYear + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpLeaveDates_Status_NotLOP(PRReq objPRReq)
        {
            string s = "select distinct * from ATT_eL_tbl_Dates where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' and MonthYear='" + objPRReq.MonthYear + "' and LeaveType!='LOP' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpLeaveDates_Status_LOP(PRReq objPRReq)
        {
            string s = "select distinct * from ATT_eL_tbl_Dates where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' and MonthYear='" + objPRReq.MonthYear + "' and LeaveType='LOP' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpTourDates_Status(PRReq objPRReq)
        {
            string s = "select distinct * from ATT_eT_tbl_Dates where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' and MonthYear='" + objPRReq.MonthYear + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpExceptionalDates_Status(PRReq objPRReq)
        {
            string s = "select distinct * from ATT_eLExp_tbl_Dates where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' and MonthYear='" + objPRReq.MonthYear + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpTourDates_SumforAttendnace(PRReq objPRReq)
        {
            string s = "select distinct sum(Days) as days from ATT_eT_tbl_Dates where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' and MonthYear='" + objPRReq.MonthYear + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpExceptionalDates_SumforAttendnace(PRReq objPRReq)
        {
            string s = "select distinct sum(Days) as days from ATT_eLExp_tbl_Dates where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' and MonthYear='" + objPRReq.MonthYear + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp ApplyEmpLeave(PRReq objPRReq)
        {
            string insert = "INSERT INTO eL_tbl_RegStaff_eLeave_Applied (ELeaveID,OID,EmpID,Name,Design,DeptID,Email,Mobile,Status,Dated,LeaveCategory,SLeaveType,SLFileName,SLFromDate,SLToDate,SLDay,SLPrefixDates,SLSufixDates,SLNoofDays,SLFromSession,SLToSession,CLeaveType,CLFileName,CLFromDate,CLToDate,CLDay,CLPrefixDates,CLSufixDates,CLNoofDays,CLFromSession,CLToSession,StationLeaveStatus,STLFromDate,STLToDate,STLAfterOfficeHours,STLBeforeOfficeHours,LTCAvailStatus,ExtIndiaStatus,PurposeofLeave,OutStationContacts,CCMail,OEmpID,OName,OLevel,ODesign,ODeptID,OEmail,OMobile,CurrentStatus,Flag1,Flag2,Flag3,Flag4,Flag5,Approval,Reject,LSO,LDA,LCancel,LPullBack,JoinDate,LTCEncashment,CPLDate,CPLReason,WorkAssignTo) values('" + objPRReq.ELeaveID + "','" + objPRReq.OID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.Design + "','" + objPRReq.DeptID + "','" + objPRReq.Email + "','" + objPRReq.Mobile + "','" + objPRReq.Status + "','" + objPRReq.Dated + "','" + objPRReq.LeaveCategory + "','" + objPRReq.SLeaveType + "','" + objPRReq.SLFileName + "','" + objPRReq.SLFromDate + "','" + objPRReq.SLToDate + "','" + objPRReq.SLDay + "','" + objPRReq.SLPrefixDates + "','" + objPRReq.SLSufixDates + "','" + objPRReq.SLNoofDays + "','" + objPRReq.SLFromSession + "','" + objPRReq.SLToSession + "','" + objPRReq.CLeaveType + "','" + objPRReq.CLFileName + "','" + objPRReq.CLFromDate + "','" + objPRReq.CLToDate + "','" + objPRReq.CLDay + "','" + objPRReq.CLPrefixDates + "','" + objPRReq.CLSufixDates + "','" + objPRReq.CLNoofDays + "','" + objPRReq.CLFromSession + "','" + objPRReq.CLToSession + "','" + objPRReq.StationLeaveStatus + "','" + objPRReq.STLFromDate + "','" + objPRReq.STLToDate + "','" + objPRReq.STLAfterOfficeHours + "','" + objPRReq.STLBeforeOfficeHours + "','" + objPRReq.LTCAvailStatus + "','" + objPRReq.ExtIndiaStatus + "','" + objPRReq.PurposeofLeave + "','" + objPRReq.OutStationContacts + "','" + objPRReq.CCMail + "','" + objPRReq.OEmpID + "','" + objPRReq.OEmpName + "','" + objPRReq.OLevel + "','" + objPRReq.ODesign + "','" + objPRReq.ODeptID + "','" + objPRReq.OEmail + "','" + objPRReq.OMobile + "','" + objPRReq.CurrentLeaveStatus + "','" + objPRReq.Flag1 + "','" + objPRReq.Flag2 + "','" + objPRReq.Flag3 + "','" + objPRReq.Flag4 + "','" + objPRReq.Flag5 + "','" + objPRReq.Approval + "','" + objPRReq.Reject + "','" + objPRReq.LSO + "','" + objPRReq.LDA + "','" + objPRReq.LCancel + "','" + objPRReq.LPullBack + "','" + objPRReq.JoinDate + "','" + objPRReq.LTCEncashment + "','" + objPRReq.CPLDate + "','" + objPRReq.CPLReason + "','" + objPRReq.WorkAssignTo + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp ApplyEmpLeaveExtension(PRReq objPRReq)
        {
            string insert = "INSERT INTO eL_tbl_RegStaff_eLeave_JR_Ext_Curt_Cancel (ELeaveID,OID,EmpID,Name,Design,DeptID,Email,Mobile,Status,Dated,AvailedUptoDate,LeaveCategory,SLeaveType,SLFileName,SLFromDate,SLToDate,SLDay,SLPrefixDates,SLSufixDates,SLNoofDays,PurposeofLeave,OutStationContacts,CCMail,OEmpID,OName,OLevel,ODesign,ODeptID,OEmail,OMobile,CurrentStatus,Flag1,Flag2,Flag3,Flag4,Flag5,Approval,Reject,LSO,LDA,LCancel,LPullBack,JoinDate,LTCEncashment,CPLDate,CPLReason) values('" + objPRReq.ELeaveID + "','" + objPRReq.OID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.Design + "','" + objPRReq.DeptID + "','" + objPRReq.Email + "','" + objPRReq.Mobile + "','" + objPRReq.Status + "','" + objPRReq.Dated + "','" + objPRReq.AvailedUptoDate + "','" + objPRReq.LeaveCategory + "','" + objPRReq.SLeaveType + "','" + objPRReq.SLFileName + "','" + objPRReq.SLFromDate + "','" + objPRReq.SLToDate + "','" + objPRReq.SLDay + "','" + objPRReq.SLPrefixDates + "','" + objPRReq.SLSufixDates + "','" + objPRReq.SLNoofDays + "','" + objPRReq.PurposeofLeave + "','" + objPRReq.OutStationContacts + "','" + objPRReq.CCMail + "','" + objPRReq.OEmpID + "','" + objPRReq.OEmpName + "','" + objPRReq.OLevel + "','" + objPRReq.ODesign + "','" + objPRReq.ODeptID + "','" + objPRReq.OEmail + "','" + objPRReq.OMobile + "','" + objPRReq.CurrentLeaveStatus + "','" + objPRReq.Flag1 + "','" + objPRReq.Flag2 + "','" + objPRReq.Flag3 + "','" + objPRReq.Flag4 + "','" + objPRReq.Flag5 + "','" + objPRReq.Approval + "','" + objPRReq.Reject + "','" + objPRReq.LSO + "','" + objPRReq.LDA + "','" + objPRReq.LCancel + "','" + objPRReq.LPullBack + "','" + objPRReq.JoinDate + "','" + objPRReq.LTCEncashment + "','" + objPRReq.CPLDate + "','" + objPRReq.CPLReason + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getEmpLeave_EmpID_onCLDate_SLDate(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_Applied where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' and (SLFromDate <= convert(datetime,'" + objPRReq.SLFromDate + "',105) and SLToDate>= convert(datetime,'" + objPRReq.SLToDate + "',105)) and (CLFromDate <= convert(datetime,'" + objPRReq.CLFromDate + "',105) and CLToDate>= convert(datetime,'" + objPRReq.CLToDate + "',105)) and LCancel='0' and Reject='0' and (Approval='0' or Approval='1')";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpLeaveExtension_EmpID_onCLDate_SLDate(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_JR_Ext_Curt_Cancel where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' and SLFromDate='" + objPRReq.SLFromDate + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpLeaves_EmpID(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_Applied where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' and Approval='" + objPRReq.Approval + "' and Reject='" + objPRReq.Reject + "'  and LCancel='0'  order by ELeaveID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpLeaves_withanystatus_EmpID(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_Applied where OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' order by ELeaveID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpLeaves_Ext_Curt_Cancel_EmpID(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_JR_Ext_Curt_Cancel where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and OEmpID='" + objPRReq.EmpID + "' and Approval='" + objPRReq.Approval + "' and Reject='" + objPRReq.Reject + "'  and LCancel='0'  order by ELeaveID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpCancelledLeaves_EmpID(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_Applied where OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' and Approval='" + objPRReq.Approval + "' and Reject='" + objPRReq.Reject + "'  and LCancel='1'  order by ELeaveID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpRejectedLeaves_EmpID(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_Applied where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' and Approval='" + objPRReq.Approval + "' and Reject='1'  and LCancel='0' order by ELeaveID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpRejectedLeaves_ELeaveID(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_Applied where OID='" + objPRReq.OID + "' and OEmpID='" + objPRReq.OEmpID + "' and EleaveID='" + objPRReq.ELeaveID + "' and Approval='" + objPRReq.Approval + "' and Reject='1'  and LCancel='0' order by ELeaveID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpRejectedTours_ETourID(PRReq objPRReq)
        {
            string s = "select distinct * from eT_tbl_RegStaff_eTour_Applied where OID='" + objPRReq.OID + "'  and ETourID='" + objPRReq.ETourID + "' and Approval='" + objPRReq.Approval + "' and Reject='1'  and LCancel='0' order by ETourID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpLeavesforApproved_withoutFlag(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_Applied where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and Approval='1' and Reject='0' and ELeaveID='" + objPRReq.ELeaveID + "' order by ELeaveID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpLeavesforApproval_withoutFlag(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_Applied where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and Reject='0' and ELeaveID='" + objPRReq.ELeaveID + "' order by ELeaveID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpLeavesforCancelled_withoutFlag(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_Applied where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and LCancel='1' and Reject='0' and ELeaveID='" + objPRReq.ELeaveID + "' order by ELeaveID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpLeaves_Ext_Curt_Cancel_forApproval_withoutFlag(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_JR_Ext_Curt_Cancel where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and Approval='" + objPRReq.Approval + "' and ELeaveID='" + objPRReq.ELeaveID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpLeaves_JR_Curt_Ext_forApproval_withoutFlag(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_JR_Ext_Curt_Cancel where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and Approval='" + objPRReq.Approval + "' and ELeaveID='" + objPRReq.ELeaveID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpLeavesforApproval_ProjHead(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_Applied where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ELeaveID='" + objPRReq.ELeaveID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp UpdateEmpLeaveAppliedSanction_ELeaveID_Review(PRReq objPRReq)
        {
            string update = "update eL_tbl_RegStaff_eLeave_Applied set Approval='" + objPRReq.Approval + "',CurrentStatus='" + objPRReq.CurrentLeaveStatus + "',Flag3='" + objPRReq.Flag3 + "' where OID='" + objPRReq.OID + "' and ELeaveID='" + objPRReq.ELeaveID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp getAllEmpLeavesforApproval_EmpID_Flag1(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_Applied where OID='" + objPRReq.OID + "' and Reject='0' and Approval='0' and Status='" + objPRReq.Status + "' and ELeaveID='" + objPRReq.ELeaveID + "' and Flag1='" + objPRReq.Flag1 + "' and Flag2='" + objPRReq.Flag2 + "' and Flag3='" + objPRReq.Flag3 + "' and Flag4='" + objPRReq.Flag4 + "'  and Flag5='" + objPRReq.Flag5 + "' order by ELeaveID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpLeavesforApproval_EmpID_Flag1_OEmpID_SMS(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_ApprovalProcess where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ELeaveID='" + objPRReq.ELeaveID + "' and OEmpID='" + objPRReq.OEmpID + "' and  Approval='0' and Reject='0' and LCancel='0' and Flag1='" + objPRReq.Flag1 + "' and Flag2='" + objPRReq.Flag2 + "' and Flag3='" + objPRReq.Flag3 + "' and Flag4='" + objPRReq.Flag4 + "'  and Flag5='" + objPRReq.Flag5 + "' order by ELeaveID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getRejectedELeave_EmpID_forReLogin_OEmpID(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_ApprovalProcess where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ELeaveID='" + objPRReq.ELeaveID + "' and  Approval='0' and LCancel='0' order by ELeaveID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp DelRejectedELeave_EmpID_forReLogin_OEmpID_ELAID(PRReq objPRReq)
        {
            string hod = "delete from eL_tbl_RegStaff_eLeave_ApprovalProcess where  OID='" + objPRReq.OID + "' and ELeaveID='" + objPRReq.ELeaveID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }
        public PRResp getAllEmpLeavesforApproval_EmpID_Flag2_OEmpID_SMS(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_ApprovalProcess where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ELeaveID='" + objPRReq.ELeaveID + "' and OEmpID='" + objPRReq.OEmpID + "' and Approval='0' and Reject='0' and LCancel='0' and Flag1='" + objPRReq.Flag1 + "' and Flag2='" + objPRReq.Flag2 + "' and Flag3='" + objPRReq.Flag3 + "' and Flag4='" + objPRReq.Flag4 + "'  and Flag5='" + objPRReq.Flag5 + "' order by ELeaveID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpLeavesforApproval_EmpID_Flag3_OEmpID_SMS(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_ApprovalProcess where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ELeaveID='" + objPRReq.ELeaveID + "' and OEmpID='" + objPRReq.OEmpID + "' and Approval='0' and Reject='0' and LCancel='0' and Flag1='" + objPRReq.Flag1 + "' and Flag2='" + objPRReq.Flag2 + "' and Flag3='" + objPRReq.Flag3 + "' and Flag4='" + objPRReq.Flag4 + "'  and Flag5='" + objPRReq.Flag5 + "' order by ELeaveID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpLeavesforApproval_EmpID_Flag4_OEmpID_SMS(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_ApprovalProcess where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ELeaveID='" + objPRReq.ELeaveID + "' and OEmpID='" + objPRReq.OEmpID + "' and Approval='0' and Reject='0' and LCancel='0' and Flag1='" + objPRReq.Flag1 + "' and Flag2='" + objPRReq.Flag2 + "' and Flag3='" + objPRReq.Flag3 + "' and Flag4='" + objPRReq.Flag4 + "'  and Flag5='" + objPRReq.Flag5 + "' order by ELeaveID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpLeavesforApproval_EmpID_Flag5_OEmpID_SMS(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_ApprovalProcess where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ELeaveID='" + objPRReq.ELeaveID + "' and OEmpID='" + objPRReq.OEmpID + "' and Approval='0' and Reject='0' and LCancel='0' and Flag1='" + objPRReq.Flag1 + "' and Flag2='" + objPRReq.Flag2 + "' and Flag3='" + objPRReq.Flag3 + "' and Flag4='" + objPRReq.Flag4 + "'  and Flag5='" + objPRReq.Flag5 + "' order by ELeaveID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpLeavesforApproval_withoutFlag_SMS(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_ApprovalProcess where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and Approval='" + objPRReq.Approval + "' and ELeaveID='" + objPRReq.ELeaveID + "'  and OEmpID='" + objPRReq.OEmpID + "' and Approval='0' and Reject='0' and LCancel='0'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp getAllEmpLeaves_JR_Curt_Ext_forApproval_EmpID_Flag1(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_JR_Ext_Curt_Cancel where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ELeaveID='" + objPRReq.ELeaveID + "' and Flag1='" + objPRReq.Flag1 + "' and Flag2='" + objPRReq.Flag2 + "' and Flag3='" + objPRReq.Flag3 + "' and Flag4='" + objPRReq.Flag4 + "'  and Flag5='" + objPRReq.Flag5 + "' order by ELeaveID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpLeavesforApproval_EmpID_Flag2(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_Applied where OID='" + objPRReq.OID + "' and Reject='0' and Approval='0' and Status='" + objPRReq.Status + "' and ELeaveID='" + objPRReq.ELeaveID + "' and Flag1='" + objPRReq.Flag1 + "' and Flag2='" + objPRReq.Flag2 + "' and Flag3='" + objPRReq.Flag3 + "' and Flag4='" + objPRReq.Flag4 + "'  and Flag5='" + objPRReq.Flag5 + "' order by ELeaveID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpLeaves_JR_Curt_Ext_forApproval_EmpID_Flag2(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_JR_Ext_Curt_Cancel where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ELeaveID='" + objPRReq.ELeaveID + "' and Flag1='" + objPRReq.Flag1 + "' and Flag2='" + objPRReq.Flag2 + "' and Flag3='" + objPRReq.Flag3 + "' and Flag4='" + objPRReq.Flag4 + "'  and Flag5='" + objPRReq.Flag5 + "' order by ELeaveID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpLeavesforApproval_EmpID_Flag3(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_Applied where OID='" + objPRReq.OID + "' and Reject='0' and Approval='0' and Status='" + objPRReq.Status + "' and ELeaveID='" + objPRReq.ELeaveID + "' and Flag1='" + objPRReq.Flag1 + "' and Flag2='" + objPRReq.Flag2 + "' and Flag3='" + objPRReq.Flag3 + "' and Flag4='" + objPRReq.Flag4 + "'  and Flag5='" + objPRReq.Flag5 + "' order by ELeaveID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpLeaves_JR_Curt_Ext_forApproval_EmpID_Flag3(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_JR_Ext_Curt_Cancel where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ELeaveID='" + objPRReq.ELeaveID + "' and Flag1='" + objPRReq.Flag1 + "' and Flag2='" + objPRReq.Flag2 + "' and Flag3='" + objPRReq.Flag3 + "' and Flag4='" + objPRReq.Flag4 + "'  and Flag5='" + objPRReq.Flag5 + "' order by ELeaveID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpLeavesforApproval_EmpID_Flag4(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_Applied where OID='" + objPRReq.OID + "' and Reject='0' and Approval='0' and Status='" + objPRReq.Status + "' and ELeaveID='" + objPRReq.ELeaveID + "' and Flag1='" + objPRReq.Flag1 + "' and Flag2='" + objPRReq.Flag2 + "' and Flag3='" + objPRReq.Flag3 + "' and Flag4='" + objPRReq.Flag4 + "'  and Flag5='" + objPRReq.Flag5 + "' order by ELeaveID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpLeaves_JR_Curt_Ext_forApproval_EmpID_Flag4(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_JR_Ext_Curt_Cancel where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ELeaveID='" + objPRReq.ELeaveID + "' and Flag1='" + objPRReq.Flag1 + "' and Flag2='" + objPRReq.Flag2 + "' and Flag3='" + objPRReq.Flag3 + "' and Flag4='" + objPRReq.Flag4 + "'  and Flag5='" + objPRReq.Flag5 + "' order by ELeaveID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpLeavesforApproval_EmpID_Flag5(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_Applied where OID='" + objPRReq.OID + "' and Reject='0' and Approval='0' and Status='" + objPRReq.Status + "' and ELeaveID='" + objPRReq.ELeaveID + "' and Flag1='" + objPRReq.Flag1 + "' and Flag2='" + objPRReq.Flag2 + "' and Flag3='" + objPRReq.Flag3 + "' and Flag4='" + objPRReq.Flag4 + "'  and Flag5='" + objPRReq.Flag5 + "' order by ELeaveID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpLeaves_JR_Curt_Ext_forApproval_EmpID_Flag5(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_JR_Ext_Curt_Cancel where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ELeaveID='" + objPRReq.ELeaveID + "' and Flag1='" + objPRReq.Flag1 + "' and Flag2='" + objPRReq.Flag2 + "' and Flag3='" + objPRReq.Flag3 + "' and Flag4='" + objPRReq.Flag4 + "'  and Flag5='" + objPRReq.Flag5 + "' order by ELeaveID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpLeavesforApproval_OEmpID(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_Applied where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and OEmpID='" + objPRReq.OEmpID + "' order by ELeaveID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpLeavesforApprovalProcessFlow_OEmpID(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_ApprovalProcess where OID='" + objPRReq.OID + "' and OEmpID='" + objPRReq.OEmpID + "' and Approval='" + objPRReq.Approval + "' and Reject='" + objPRReq.Reject + "'  and LCancel='0'  order by ELAID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpLeavesforApprovalApplied_Reject_OEmpID(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_ApprovalProcess where OID='" + objPRReq.OID + "' and UID='" + objPRReq.OEmpID + "' and LCancel='0' and Reject='1'  order by ELAID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpLeavesforApprovalProcessFlow_OEmpID_recommend(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_ApprovalProcess where OID='" + objPRReq.OID + "' and OEmpID='" + objPRReq.OEmpID + "' order by ELAID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpLeavesforApproval_ProcessFlow_OEmpIDasUID(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_ApprovalProcess where OID='" + objPRReq.OID + "' and UID='" + objPRReq.OEmpID + "' and Reject='0' and Approval='0'  and ELeaveID='" + objPRReq.ELeaveID + "' order by ELeaveID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpLeaves_Ext_Curt_Cancel_forApprovalProcessFlow_OEmpID(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_JR_Ext_Curt_Cancel_ApprovalProcess where OID='" + objPRReq.OID + "' and OEmpID='" + objPRReq.OEmpID + "' and Approval='" + objPRReq.Approval + "' and Reject='" + objPRReq.Reject + "'  and LCancel='0'  order by ELeaveID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpLeaves_JR_Curt_Ext_forApprovalProcessFlow_OEmpID(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_JR_Ext_Curt_Cancel_ApprovalProcess where OID='" + objPRReq.OID + "' and (UID='" + objPRReq.OEmpID + "' or OEmpID='" + objPRReq.OEmpID + "') and Approval='" + objPRReq.Approval + "' and Reject='" + objPRReq.Reject + "'  and LCancel='0'  order by ELeaveID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpLeaves_JR_Curt_Ext_forApprovalProcessFlow_OEmpID_Repeate(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_JR_Ext_Curt_Cancel_ApprovalProcess where OID='" + objPRReq.OID + "' and OEmpID='" + objPRReq.OEmpID + "' and Approval='" + objPRReq.Approval + "' and Reject='" + objPRReq.Reject + "'  and LCancel='0'  order by ELeaveID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpLeavesforApprovalProcessFlow_SMS(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_ApprovalProcess where OID='" + objPRReq.OID + "' and Approval='" + objPRReq.Approval + "' and Reject='" + objPRReq.Reject + "' and LCancel='0' and Dated>='" + objPRReq.FromDate + "'  order by ELeaveID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpLeavesforApprovalProcessFlow_OEmpID_AS_UID(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_ApprovalProcess where OID='" + objPRReq.OID + "' and UID='" + objPRReq.OEmpID + "' and Approval='" + objPRReq.Approval + "' order by ELeaveID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp getAllRegularEmpApproved_Leaves_LSO_UID(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_Applied where OID='" + objPRReq.OID + "' and Approval='" + objPRReq.Approval + "' and EmpID='" + objPRReq.EmpID + "' order by ELeaveID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpLeaves_OEmpID_Apprved(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_Applied where OID='" + objPRReq.OID + "' and OEmpID='" + objPRReq.OEmpID + "' and Approval='1' and ELeaveID='" + objPRReq.ELeaveID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllPSEmpLeaves_OEmpID_Apprved(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_ProjStaff_eLeave_Applied where OID='" + objPRReq.OID + "' and (PCEmpID='" + objPRReq.OEmpID + "' or HEmpID='" + objPRReq.OEmpID + "') and Approval='1' and ELeaveID='" + objPRReq.ELeaveID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpLeaves_Apprved(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_Applied where OID='" + objPRReq.OID + "' and Approval='1' and ELeaveID='" + objPRReq.ELeaveID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpLeavesforApprovalProcessFlow_OEmpID_AS_UID_Rejected(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_ApprovalProcess where OID='" + objPRReq.OID + "' and UID='" + objPRReq.OEmpID + "' and Approval='" + objPRReq.Approval + "' and Reject='1' order by ELeaveID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpLeavesforApprovalProcessFlow_EmpID_ProjHead(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_ApprovalProcess where OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.OEmpID + "' order by ELeaveID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpLeavesApplied_Status_LSO(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_Applied where OID='" + objPRReq.OID + "' and (LDeduct is NULL or LDeduct='0') order by ELeaveID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllProjEmpLeavesApplied_LSO(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_ProjStaff_eLeave_Applied where OID='" + objPRReq.OID + "' and Flag1='1' and Approval='" + objPRReq.Approval + "' and Reject!='1' and  LCancel!='1' order by ELeaveID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllProjEmpLeaves_withanystatus_LSO(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_ProjStaff_eLeave_Applied where OID='" + objPRReq.OID + "' order by ELeaveID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllProjEmpLeaves_withanystatus_LSO_DID(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_ProjStaff_eLeave_Applied where OID='" + objPRReq.OID + "' and DeptID='" + objPRReq.DeptID + "' order by ELeaveID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllProjEmpToursApplied_LSO(PRReq objPRReq)
        {
            string s = "select distinct * from eT_tbl_ProjStaff_eTour_Applied where OID='" + objPRReq.OID + "' and Approval='" + objPRReq.Approval + "' and Reject!='1' and  TCancel!='1' order by ETourID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllProjEmpToursApplied_withanystatus_LSO(PRReq objPRReq)
        {
            string s = "select distinct * from eT_tbl_ProjStaff_eTour_Applied where OID='" + objPRReq.OID + "' order by ETourID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpTourssApplied_LSO(PRReq objPRReq)
        {
            string s = "select distinct * from eT_tbl_RegStaff_eTour_Applied where OID='" + objPRReq.OID + "' and Approval='" + objPRReq.Approval + "' and Reject!='1' and  LCancel!='1' order by ETourID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpLeavesApplied_LDAID(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_Applied where OID='" + objPRReq.OID + "' and Approval='" + objPRReq.Approval + "' and EmpID='" + objPRReq.EmpID + "' and Reject!='1' and  LCancel!='1' and (LDeduct is NULL or LDeduct='0') order by ELeaveID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpLeavesApplied_LDAID_Except_CL_RH(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_Applied where OID='" + objPRReq.OID + "' and Approval='" + objPRReq.Approval + "' and EmpID='" + objPRReq.EmpID + "' and Reject!='1' and  LCancel!='1' and (LDeduct is NULL or LDeduct='0') and ((SLeaveType!='CL' and SLeaveType!='RH' and SLeaveType!='DL' and SLeaveType!='CPL' or CLeaveType!='') and (CLeaveType!='CL' and CLeaveType!='RH' and CLeaveType!='DL' and CLeaveType!='CPL')) order by ELeaveID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpLeavesApplied_LDAID_JR_Curt_Ext_Except_CL_RH(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_JR_Ext_Curt_Cancel where OID='" + objPRReq.OID + "' and Approval='" + objPRReq.Approval + "' and EmpID='" + objPRReq.EmpID + "' and Reject!='1' and  LCancel!='1' and (LDeduct is NULL or LDeduct='0') and ((SLeaveType!='RH') and (SLeaveType!='CL' and SLeaveType!='RH' and SLeaveType!='DL' or SLeaveType!='CPL')) order by ELeaveID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpLeavesApplied_LDAID_Only_CL_RH(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_Applied where OID='" + objPRReq.OID + "' and Approval='" + objPRReq.Approval + "' and EmpID='" + objPRReq.EmpID + "' and Reject!='1' and  LCancel!='1' and (LDeduct is NULL or LDeduct='0') and ((SLeaveType='CL' or SLeaveType='RH' or SLeaveType='DL' or SLeaveType='CPL' and CLeaveType='') or (CLeaveType='CL' or CLeaveType='RH' or CLeaveType='CPL' or CLeaveType='DL')) order by ELeaveID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpLeaves_Deducted_LDAID(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_Applied where OID='" + objPRReq.OID + "' and Approval='" + objPRReq.Approval + "' and EmpID='" + objPRReq.EmpID + "' and Reject!='1' and  LCancel!='1' and LDeduct='1' order by ELeaveID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpLeavesApplied_LSO_Cancelled(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_Applied where OID='" + objPRReq.OID + "' and Approval='0' and Reject='0' and LCancel='1' and (LDeduct is NULL or LDeduct='0') order by ELeaveID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpLeavesApplied_LSO_Rejected(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_Applied where OID='" + objPRReq.OID + "' and Approval='0' and Reject='1' and LCancel='0' and (LDeduct is NULL or LDeduct='0') order by ELeaveID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpLeavesApplied_Leave_Count(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_Applied where OID='" + objPRReq.OID + "' and Approval='1' and Reject='0' and LCancel='0' and (LDeduct is NULL or LDeduct='0') and EmpID='" + objPRReq.EmpID + "' and (SLeaveType='" + objPRReq.LeaveType + "' or CLeaveType='" + objPRReq.LeaveType + "')  order by ELeaveID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpLeavesApplied_Leave_Count_DG(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_Applied where OID='" + objPRReq.OID + "' and YEAR(Dated)='" + objPRReq.Year + "' and Approval='1' and Reject='0' and LCancel='0' and EmpID='" + objPRReq.EmpID + "' and (SLeaveType='" + objPRReq.LeaveType + "' or CLeaveType='" + objPRReq.LeaveType + "')  order by ELeaveID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpLeavesApplied_Leave_Count_EmpID(PRReq objPRReq)
        {
            string s = "select sum(" + objPRReq.ColumnName + ") as count from eL_tbl_RegStaff_eLeave_Applied where OID='" + objPRReq.OID + "' and YEAR(SLFromDate)='" + objPRReq.Year + "' and Approval='1' and Reject='0' and LCancel='0' and EmpID='" + objPRReq.EmpID + "' and (SLeaveType='" + objPRReq.LeaveType + "' or CLeaveType='" + objPRReq.LeaveType + "')";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllPSEmpLeavesApplied_Leave_Count_EmpID(PRReq objPRReq)
        {
            string s = "select sum(" + objPRReq.ColumnName + ") as count from eL_tbl_ProjStaff_eLeave_Applied where OID='" + objPRReq.OID + "' and YEAR(SLFromDate)='" + objPRReq.Year + "' and Approval='1' and Reject='0' and LCancel='0' and EmpID='" + objPRReq.EmpID + "' and LeaveCategory='" + objPRReq.LeaveType + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAll_Years_DG(PRReq objPRReq)
        {
            string s = "select distinct Year(Dated) as Year from eL_tbl_RegStaff_eLeave_Applied where OID='" + objPRReq.OID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpLeavesApproved_LSO_ELeaveID(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_Applied where OID='" + objPRReq.OID + "' and Approval='" + objPRReq.Approval + "' and ELeaveID='" + objPRReq.ELeaveID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpID_LSO_ELeaveID(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_Applied where OID='" + objPRReq.OID + "' and ELeaveID='" + objPRReq.ELeaveID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpLeavesApprovedTypes_LSO_ELeaveID(PRReq objPRReq)
        {
            string s = "select distinct SLeaveType,CLeaveType from eL_tbl_RegStaff_eLeave_Applied where OID='" + objPRReq.OID + "' and Approval='1' and ELeaveID='" + objPRReq.ELeaveID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpLeavesApprovedSLNoofDays_LSO_ELeaveID(PRReq objPRReq)
        {
            string s = "select distinct SLNoofDays from eL_tbl_RegStaff_eLeave_Applied where OID='" + objPRReq.OID + "' and Approval='1' and ELeaveID='" + objPRReq.ELeaveID + "' and SLeaveType='" + objPRReq.SLeaveType + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpLeavesApprovedCLNoofDays_LSO_ELeaveID(PRReq objPRReq)
        {
            string s = "select distinct CLNoofDays from eL_tbl_RegStaff_eLeave_Applied where OID='" + objPRReq.OID + "' and Approval='1' and ELeaveID='" + objPRReq.ELeaveID + "' and CLeaveType='" + objPRReq.CLeaveType + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpLeavesApplied_LSO(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_Applied where OID='" + objPRReq.OID + "' and Approval='" + objPRReq.Approval + "' and Reject!='1' and  LCancel!='1' and (LDeduct is NULL or LDeduct='0') order by ELeaveID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpLeaves_JR_Curt_Ext_Applied_LSO(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_JR_Ext_Curt_Cancel where OID='" + objPRReq.OID + "' and Approval='" + objPRReq.Approval + "' and Reject!='1' and  LCancel!='1' and (LDeduct is NULL or LDeduct='0') order by ELeaveID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpLeavesApplied_LSO_Search(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_Applied where OID='" + objPRReq.OID + "' and Approval='" + objPRReq.Approval + "' and (ELeaveID='" + objPRReq.ELeaveID + "' or Name like '%" + objPRReq.ELeaveID + "%' ) order by ELeaveID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpLeavesApplied_Status_LSO_Search(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_Applied where OID='" + objPRReq.OID + "' and (ELeaveID='" + objPRReq.ELeaveID + "' or Name like '%" + objPRReq.ELeaveID + "%' ) order by ELeaveID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpToursApplied_LSO_Search(PRReq objPRReq)
        {
            string s = "select distinct * from eT_tbl_RegStaff_eTour_Applied where OID='" + objPRReq.OID + "' and Approval='" + objPRReq.Approval + "' and (ETourID='" + objPRReq.ETourID + "' or Name like '%" + objPRReq.ETourID + "%' ) order by ETourID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpLeavesforApprovalProcessFlow_OEmpIDasUID(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_ApprovalProcess where OID='" + objPRReq.OID + "' and UID='" + objPRReq.OEmpID + "' and ELeaveID='" + objPRReq.ELeaveID + "' order by ELeaveID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpLeavesforApprovalProcessFlow_OEmpIDasUID_s(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_ApprovalProcess where OID='" + objPRReq.OID + "' and (UID='" + objPRReq.OEmpID + "' or OEmpID='" + objPRReq.OEmpID + "') and ELeaveID='" + objPRReq.ELeaveID + "' and Reject='0' and Approval='0' order by ELeaveID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpLeavesforApprovalProcessFlow_OEmpID_Recomend(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_Applied where OID='" + objPRReq.OID + "' and ELeaveID='" + objPRReq.ELeaveID + "' and Reject='0' order by ELeaveID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpLeavesforApprovalProcessFlow_OEmpIDasUID_SMS(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_ApprovalProcess where OID='" + objPRReq.OID + "' and ELeaveID='" + objPRReq.ELeaveID + "' order by ELeaveID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpLeaves_Cancelled_OEmpIDasUID(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_Cancelled where OID='" + objPRReq.OID + "' and OEmpID='" + objPRReq.OEmpID + "' and ELeaveID='" + objPRReq.ELeaveID + "' order by ELeaveID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpLeaves_JR_Curt_ExtforApprovalProcessFlow_OEmpIDasUID(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_JR_Ext_Curt_Cancel_ApprovalProcess where OID='" + objPRReq.OID + "' and UID='" + objPRReq.OEmpID + "' and ELeaveID='" + objPRReq.ELeaveID + "'  order by ELeaveID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp getAllEmpLeavesforApprovalProcessFlow_OEmpIDasUID_SMS_OLevelDesc(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_ApprovalProcess where OID='" + objPRReq.OID + "' and ELeaveID='" + objPRReq.ELeaveID + "' order by OLevel Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpLeavesApplied_ELeaveID(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_Applied where OID='" + objPRReq.OID + "' and EleaveID='" + objPRReq.ELeaveID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpLeavesforApprovalProcessFlow_ELeaveID(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_ApprovalProcess where OID='" + objPRReq.OID + "' and EleaveID='" + objPRReq.ELeaveID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpLeavesforApprovalProcessFlow_OEmpID_ELeaveID(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_ApprovalProcess where OID='" + objPRReq.OID + "' and OEmpID='" + objPRReq.OEmpID + "' and EleaveID='" + objPRReq.ELeaveID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpLeavesApplied_OEmpID_ELeaveID_Review(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_Applied where OID='" + objPRReq.OID + "' and OEmpID='" + objPRReq.OEmpID + "' and EleaveID='" + objPRReq.ELeaveID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp getAllEmpLeaves_Curt_Ext_forApprovalProcessFlow_OEmpID_ELeaveID(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_JR_Ext_Curt_Cancel_ApprovalProcess where OID='" + objPRReq.OID + "' and OEmpID='" + objPRReq.OEmpID + "' and EleaveID='" + objPRReq.ELeaveID + "' and Approval!='1'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpLeavesforApproval_OEmpID_Flag2(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_Applied where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and Flag1='" + objPRReq.Flag1 + "'  order by ELeaveID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp CanceleLeaveby_EleaveID_EmpID(PRReq objPRReq)
        {
            string update = "update eL_tbl_RegStaff_eLeave_Applied set Status='" + objPRReq.Status + "',LCancel='" + objPRReq.LCancel + "', CurrentStatus='" + objPRReq.CurrentLeaveStatus + "' where ELeaveID='" + objPRReq.ELeaveID + "' and EmpID='" + objPRReq.EmpID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp UpDateJoingReport_EleaveID_EmpID(PRReq objPRReq)
        {
            string update = "update eL_tbl_RegStaff_eLeave_Applied set SLToDate='" + objPRReq.SLToDate + "', SLSufixDates='" + objPRReq.SLSufixDates + "', SLNoofDays='" + objPRReq.SLNoofDays + "', CurrentStatus='" + objPRReq.CurrentLeaveStatus + "' where ELeaveID='" + objPRReq.ELeaveID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp CanceleLeaveby_EleaveID_OEmpID(PRReq objPRReq)
        {
            string update = "update eL_tbl_RegStaff_eLeave_Applied set Status='" + objPRReq.Status + "',Approval='" + objPRReq.Approval + "',LCancel='" + objPRReq.LCancel + "', CurrentStatus='" + objPRReq.CurrentLeaveStatus + "' where ELeaveID='" + objPRReq.ELeaveID + "' and OID='" + objPRReq.OID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }

        public PRResp CancelePSLeaveby_EleaveID_OEmpID(PRReq objPRReq)
        {
            string update = "update eL_tbl_ProjStaff_eLeave_Applied set Status='" + objPRReq.Status + "',Approval='" + objPRReq.Approval + "',LCancel='" + objPRReq.LCancel + "', CurrentStatus='" + objPRReq.CurrentLeaveStatus + "' where ELeaveID='" + objPRReq.ELeaveID + "' and OID='" + objPRReq.OID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp CanceleLeaveProcessby_EleaveID_EmpID(PRReq objPRReq)
        {
            string update = "update eL_tbl_RegStaff_eLeave_ApprovalProcess set Status='" + objPRReq.Status + "',LCancel='" + objPRReq.LCancel + "' where ELeaveID='" + objPRReq.ELeaveID + "' and EmpID='" + objPRReq.EmpID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp getAllEmpLeavesforApprovalProcess_OEmpID(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_ApprovalProcess where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and OEmpID='" + objPRReq.OEmpID + "' order by ELeaveID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpLeaves_ELeaveID(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_Applied where OID='" + objPRReq.OID + "' and ELeaveID='" + objPRReq.ELeaveID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getELAIDSNo(PRReq objPRReq)
        {
            string s = "select max(" + objPRReq.ColumnName + ") from eL_tbl_RegStaff_eLeave_Applied where OID='" + objPRReq.OID + "' ";
            objPRResp.SingleValue = Connections.GetSingleValue(s);
            return objPRResp;
        }

        //Leave DA Login

        public PRResp eLDALogin(PRReq objPRReq)
        {
            string s = "select * from eL_tbl_DealingAssistants where UserID='" + objPRReq.UserID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp get_eLDAUserInfo(PRReq objPRReq)
        {
            string s = "select * from eL_tbl_DealingAssistants where UserID='" + objPRReq.UserID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp geteLDAUserPassword(PRReq objPRReq)
        {
            string s = "select * from eL_tbl_DealingAssistants where Status='" + objPRReq.Status + "' and UserID='" + objPRReq.UserID + "' and Password='" + objPRReq.Password + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp ChangeeLDAUserPassword(PRReq objPRReq)
        {
            string update = "update eL_tbl_DealingAssistants set Password='" + objPRReq.NewPassword + "' where UserID='" + objPRReq.UserID + "' and Status='" + objPRReq.Status + "' and Password='" + objPRReq.Password + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }

        // Bio-metric Attendance Upload
        public PRResp AddBioMetricAttendance(PRReq objPRReq)
        {
            string insert = "insert into ATT_tbl_Biometric_Attendance (MonthYear,AttendanceID,EmpID,Name,Date,Status,In_Time,Out_Time,OpenClosed,Duration,GT8Hours,LT8Hours,MLHours,EEHours,ActualDuration) values('" + objPRReq.MonthYear + "','" + objPRReq.AttendanceID + "','" + objPRReq.PAN + "','" + objPRReq.Name + "','" + objPRReq.RUDate + "','" + objPRReq.Status + "','" + objPRReq.FromDate + "','" + objPRReq.LastDate + "','" + objPRReq.BlockStatus + "','" + objPRReq.Duration + "','" + objPRReq.GT8Hours + "','" + objPRReq.LT8Hours + "','" + objPRReq.MLHours + "','" + objPRReq.EEHours + "','" + objPRReq.ActualDuration + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }

        public PRResp getAllBioMetricAttendance_EmpIDAttID(PRReq objPRReq)
        {
            string s = "select * from ATT_tbl_Biometric_Attendance where AttendanceID='" + objPRReq.AttendanceID + "' and EmpID='" + objPRReq.EmpID + "' and MonthYear='" + objPRReq.MonthYear + "' and Date='" + objPRReq.RUDate + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllBioMetricAttendance_MonthYear(PRReq objPRReq)
        {
            string s = "select * from ATT_tbl_Biometric_Attendance where MonthYear='" + objPRReq.MonthYear + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getBioMetricMonths(PRReq objPRReq)
        {
            string s = "select distinct MonthYear from ATT_tbl_Biometric_Attendance order by MonthYear Asc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getBioMetricData_ATMID_EmpID_AttID(PRReq objPRReq)
        {
            string s = "select distinct * from ATT_tbl_Biometric_Attendance where MonthYear='" + objPRReq.MonthYear + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getBioMetricData_ATMID_EmpID_AttID_Present(PRReq objPRReq)
        {
            string s = "select distinct * from ATT_tbl_Biometric_Attendance where MonthYear='" + objPRReq.MonthYear + "' and EmpID='" + objPRReq.EmpID + "' and Status='P' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getCountOfColumn_BioMetric(PRReq objPRReq)
        {
            string s = "select count(" + objPRReq.ColumnName + ") as count from ATT_tbl_Biometric_Attendance where MonthYear='" + objPRReq.MonthYear + "' and EmpID='" + objPRReq.EmpID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getHDates_OfColumn_EmpID_BioMetric(PRReq objPRReq)
        {
            string s = "select " + objPRReq.ColumnName + " as pHdate from ATT_tbl_Biometric_Attendance where MonthYear='" + objPRReq.MonthYear + "' and EmpID='" + objPRReq.EmpID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmployee_forBioMetricAtt(PRReq objPRReq)
        {
            string s = "(select distinct EmpID,Name,DID,DeptID,Design,Photo,EGID,EmpGroup from PR_tbl_Employee  where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "')union(select distinct EmpID,Name,DID,DeptID,Design,Photo,EGID,EmpGroup from PR_tbl_ProjectStaff  where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "') order by DeptID Asc ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }


        public PRResp getAllEmployee_byEmpID(PRReq objPRReq)
        {
            string s = "(select distinct EmpID,Name,DID,DeptID,Design,Photo,EGID,Email,Mobile,EmpGroup from PR_tbl_Employee  where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "')union(select distinct EmpID,Name,DID,DeptID,Design,Photo,EGID,Email,Mobile,EmpGroup from PR_tbl_ProjectStaff  where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "') ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmployee_byHEmpID(PRReq objPRReq)
        {
            string s = "(select distinct EmpID,Name,DID,DeptID,Design,Photo,EGID,Email,Mobile,EmpGroup from PR_tbl_Employee  where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.HEmpID + "')union(select distinct EmpID,Name,DID,DeptID,Design,Photo,EGID,Email,Mobile,EmpGroup from PR_tbl_ProjectStaff  where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.HEmpID + "') ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp AddBioMetricMonthlyReport(PRReq objPRReq)
        {
            string insert = "INSERT INTO ATT_tbl_Bio_Att_MonthlyReport (MonthYear,Duration,EmpID,Name,Design,DID,DeptID,EGID,EmpGroup,AttendanceID,Dated,TotDays,CHolidays,PDays,ADays,LDays,TDays,EDays,HDays,WDays,Status,HWDays,HTDays) values ('" + objPRReq.MonthYear + "','" + objPRReq.Duration + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.Design + "','" + objPRReq.DID + "','" + objPRReq.DeptID + "','" + objPRReq.EGID + "','" + objPRReq.EmpGroup + "','" + objPRReq.AttendanceID + "','" + objPRReq.FromDate + "','" + objPRReq.TotDays + "','" + objPRReq.CHolidays + "','" + objPRReq.PDays + "','" + objPRReq.ADays + "','" + objPRReq.LDays + "','" + objPRReq.TDays + "','" + objPRReq.ExpDays + "','" + objPRReq.HDays + "','" + objPRReq.WDays + "','" + objPRReq.Status + "','" + objPRReq.HWDays + "','" + objPRReq.HTDays + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp UpdateLOP_BioMetricDays_EmpID(PRReq objPRReq)
        {
            string update = "update ATT_tbl_Bio_Att_MonthlyReport set LOPReqDays='" + objPRReq.LOPReqDays + "',  LOPDays='" + objPRReq.LopDays + "' where EmpID='" + objPRReq.EmpID + "' and Status='" + objPRReq.Status + "' and MonthYear='" + objPRReq.MonthYear + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp Update_BioMetricMissedDays_EmpID(PRReq objPRReq)
        {
            string update = "update ATT_tbl_Bio_Att_MonthlyReport set MissedDates='" + objPRReq.MissedDates + "',LOPDays='" + objPRReq.LopDays + "' where EmpID='" + objPRReq.EmpID + "' and Status='" + objPRReq.Status + "' and MonthYear='" + objPRReq.MonthYear + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp EditBioMetricMonthlyReport(PRReq objPRReq)
        {
            string update = "update ATT_tbl_Bio_Att_MonthlyReport set Duration='" + objPRReq.Duration + "',TotDays='" + objPRReq.TotDays + "',CHolidays='" + objPRReq.CHolidays + "',PDays='" + objPRReq.PDays + "',ADays='" + objPRReq.ADays + "',LDays='" + objPRReq.LDays + "',TDays='" + objPRReq.TDays + "',EDays='" + objPRReq.ExpDays + "',HDays='" + objPRReq.HDays + "',WDays='" + objPRReq.WDays + "',HWDays='" + objPRReq.HWDays + "',HTDays='" + objPRReq.HTDays + "' where EmpID='" + objPRReq.EmpID + "' and AttendanceID='" + objPRReq.AttendanceID + "' and MonthYear='" + objPRReq.MonthYear + "' and Status='Active' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }

        public PRResp getBioMetricReport_MonthYear_EmpID_AttID(PRReq objPRReq)
        {
            string s = "select distinct * from ATT_tbl_Bio_Att_MonthlyReport where MonthYear='" + objPRReq.MonthYear + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getBioMetric_EmpID_AttID(PRReq objPRReq)
        {
            string s = "select distinct * from ATT_tbl_Bio_Att_MonthlyReport where EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getBioMetricReport_MonthYear_EGID(PRReq objPRReq)
        {
            string s = "select distinct * from ATT_tbl_Bio_Att_MonthlyReport where MonthYear='" + objPRReq.MonthYear + "' and EGID='" + objPRReq.EGID + "' order by DID,EmpID Asc ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getBioMetricReport_MonthYear_EGID_DID(PRReq objPRReq)
        {
            string s = "select distinct * from ATT_tbl_Bio_Att_MonthlyReport where MonthYear='" + objPRReq.MonthYear + "' and EGID='" + objPRReq.EGID + "' and DID='" + objPRReq.DID + "' order by DID,EmpID Asc ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp get_ALL_BioMetricReport_MonthYear_EGID_DID(PRReq objPRReq)
        {
            string s = "select distinct * from ATT_tbl_Bio_Att_MonthlyReport where MonthYear='" + objPRReq.MonthYear + "' and EGID='" + objPRReq.EGID + "' order by DID,EmpID Asc ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp get_ALL_BioMetricReport_MonthYear_EGID_Excel_LOP(PRReq objPRReq)
        {
            string s = "select distinct EmpID,Name,Design,DeptID,TotDays,CHolidays,PDays,ADays,LDays,TDays,EDays,LOPDays,MissedDates from ATT_tbl_Bio_Att_MonthlyReport where MonthYear='" + objPRReq.MonthYear + "' and EGID='" + objPRReq.EGID + "' and (MissedDates is NULL or LOPDays>0) order by DeptID Asc ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp get_ALL_BioMetricReport_MonthYear_EGID_Excel(PRReq objPRReq)
        {
            string s = "select distinct EmpID,Name,Design,DeptID,TotDays,CHolidays,PDays,ADays,LDays,TDays,EDays,LOPDays,MissedDates from ATT_tbl_Bio_Att_MonthlyReport where MonthYear='" + objPRReq.MonthYear + "' and EGID='" + objPRReq.EGID + "'  order by DeptID Asc ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp get_LOP_BioMetricReport_MonthYear_EGID_DID(PRReq objPRReq)
        {
            string s = "select distinct * from ATT_tbl_Bio_Att_MonthlyReport where MonthYear='" + objPRReq.MonthYear + "' and EGID='" + objPRReq.EGID + "' and (LOPDays>0 and MissedDates is NOT NULL) order by DID,EmpID Asc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp get_LOP_BioMetricReport_MonthYear_EGID_DID_EmpID(PRReq objPRReq)
        {
            string s = "select distinct * from ATT_tbl_Bio_Att_MonthlyReport where EmpID='" + objPRReq.EmpID + "' and MonthYear='" + objPRReq.MonthYear + "' and EGID='" + objPRReq.EGID + "' and (LOPDays>0 and MissedDates is NOT NULL) order by DID,EmpID Asc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getBioMetricReport_EmpID_AttID(PRReq objPRReq)
        {
            string s = "select distinct * from ATT_tbl_Bio_Att_MonthlyReport where EmpID='" + objPRReq.EmpID + "' order by ATMID Desc ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getBioMetricData_EmpID_MonthYear(PRReq objPRReq)
        {
            string s = "select distinct * from ATT_tbl_Biometric_Attendance where EmpID='" + objPRReq.EmpID + "' and MonthYear='" + objPRReq.MonthYear + "' and Status!='" + objPRReq.Status + "' order by Date Asc ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getBioMetricData_ATMID(PRReq objPRReq)
        {
            string s = "select distinct * from ATT_tbl_Bio_Att_MonthlyReport where ATMID='" + objPRReq.ATMID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp AddBioMetricMonthly_HoursReport(PRReq objPRReq)
        {
            string insert = "INSERT INTO ATT_tbl_Bio_Att_Monthly_HoursReport (OID,MonthYear,Duration,AttendanceID,EGID,EmpID,Name,Design,DID,DeptID,Dated,Status,TMLHours,TEEHours,TLateHours,TActualDuration,TDays,TWDays,TPDays,OtherDays,TWHours,SpentHours) values ('" + objPRReq.OID + "','" + objPRReq.MonthYear + "','" + objPRReq.Duration + "','" + objPRReq.AttendanceID + "','" + objPRReq.EGID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.Design + "','" + objPRReq.DID + "','" + objPRReq.DeptID + "','" + objPRReq.Dated + "','" + objPRReq.Status + "','" + objPRReq.TMLHours + "','" + objPRReq.TEEHours + "','" + objPRReq.TotLateHours + "','" + objPRReq.TActualDuration + "','" + objPRReq.TDays + "','" + objPRReq.WDays + "','" + objPRReq.TPDays + "','" + objPRReq.OtherDays + "','" + objPRReq.TWHours + "','" + objPRReq.SpentHours + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getBioMetricMonthly_HoursReport(PRReq objPRReq)
        {
            string s = "select distinct * from ATT_tbl_Bio_Att_Monthly_HoursReport where MonthYear='" + objPRReq.MonthYear + "' and AttendanceID='" + objPRReq.AttendanceID + "' and EmpID='" + objPRReq.EmpID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getBioMetricMonthly_HoursReport_EmpID(PRReq objPRReq)
        {
            string s = "select distinct * from ATT_tbl_Bio_Att_Monthly_HoursReport where OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' and Status='" + objPRReq.Status + "' and MonthYear='" + objPRReq.MonthYear + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        // Tour Modes

        public PRResp getTourModes(PRReq objPRReq)
        {
            string s = "select * from eT_tbl_TourMode where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp AddTourMode(PRReq objPRReq)
        {
            string insert = "insert into eT_tbl_TourMode (OID,TourMode,Status) values('" + objPRReq.OID + "','" + objPRReq.TourMode + "','" + objPRReq.Status + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getTourModeByName(PRReq objPRReq)
        {
            string s = "select * from eT_tbl_TourMode where TourMode='" + objPRReq.TourMode + "' and OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getTourModeByTMID(PRReq objPRReq)
        {
            string s = "select * from eT_tbl_TourMode where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and TMID='" + objPRReq.TMID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp EditTourModeByTMID(PRReq objPRReq)
        {
            string update = "update eT_tbl_TourMode set TourMode='" + objPRReq.TourMode + "' where OID='" + objPRReq.OID + "' and TMID='" + objPRReq.TMID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp DelTourMode(PRReq objPRReq)
        {
            string hod = "delete from eT_tbl_TourMode where  OID='" + objPRReq.OID + "' and TMID='" + objPRReq.TMID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }
        public PRResp TourModeSearch(PRReq objPRReq)
        {
            string s = "select * from eT_tbl_TourMode where TourMode like '%" + objPRReq.TourMode + "%' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }




        // PS Leave Management

        public PRResp ApplyNewPSLeave(PRReq objPRReq)
        {
            string s = "INSERT INTO eL_tbl_ProjStaff_eLeave_Applied (ELeaveID,OID,EmpID,Name,Design,DeptID,Email,Mobile,Status,Dated,LeaveCategory,SLFileName,SLFromDate,SLToDate,SLFromSession,SLToSession,SLPrefixDates,SLSufixDates,SLNoofDays,CPLDate,CPLReason,PCEmpID,PCName,PCLevel,PCDesign,PCDeptID,PCEmail,PCMobile,HEmpID,HName,HLevel,HDesign,HDeptID,HEmail,HMobile,CurrentStatus,PurposeofLeave,Flag1,Flag2,PCAction,PCStatus,PCApproved,PCADate,Flag3,Flag4,Flag5,Approval,Reject,LCancel,LPullBack,JoinDate) values('" + objPRReq.ELeaveID + "','" + objPRReq.OID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.Design + "','" + objPRReq.DeptID + "','" + objPRReq.Email + "','" + objPRReq.Mobile + "','" + objPRReq.Status + "','" + objPRReq.Dated + "','" + objPRReq.LeaveCategory + "','" + objPRReq.SLFileName + "','" + objPRReq.FromDate + "','" + objPRReq.ToDate + "','" + objPRReq.SLFromSession + "','" + objPRReq.SLToSession + "','" + objPRReq.SLPrefixDates + "','" + objPRReq.SLSufixDates + "','" + objPRReq.SLNoofDays + "','" + objPRReq.CPLDate + "','" + objPRReq.CPLReason + "','" + objPRReq.PCEmpID + "','" + objPRReq.PCEmpName + "','" + objPRReq.PCLevel + "','" + objPRReq.PCDesign + "','" + objPRReq.PCDeptID + "','" + objPRReq.PCEmail + "','" + objPRReq.PCMobile + "','" + objPRReq.HEmpID + "','" + objPRReq.HName + "','" + objPRReq.HLevel + "','" + objPRReq.HDesign + "','" + objPRReq.HDeptID + "','" + objPRReq.HEmail + "','" + objPRReq.HMobile + "','" + objPRReq.CurrentLeaveStatus + "','" + objPRReq.PurposeofLeave + "','" + objPRReq.Flag1 + "','" + objPRReq.Flag2 + "','" + objPRReq.PCAction + "','" + objPRReq.PCStatus + "','" + objPRReq.PCApproved + "','" + objPRReq.PCADate + "','" + objPRReq.Flag3 + "','" + objPRReq.Flag4 + "','" + objPRReq.Flag5 + "','" + objPRReq.Approval + "','" + objPRReq.Reject + "','" + objPRReq.LCancel + "','" + objPRReq.LPullBack + "','" + objPRReq.JoinDate + "')";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getPSELAIDSNo(PRReq objPRReq)
        {
            string s = "select max(" + objPRReq.ColumnName + ") from eL_tbl_ProjStaff_eLeave_Applied where OID='" + objPRReq.OID + "' ";
            objPRResp.SingleValue = Connections.GetSingleValue(s);
            return objPRResp;
        }

        public PRResp getMaxPSEmpID(PRReq objPRReq)
        {
            string s = "select max(" + objPRReq.ColumnName + ") as PSTID from PR_tbl_ProjectStaff where OID='" + objPRReq.OID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getPSEmpId_PSTID(PRReq objPRReq)
        {
            string s = "select distinct * from  PR_tbl_ProjectStaff where OID='" + objPRReq.OID + "' and PSTID='" + objPRReq.PSTID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        //public PRResp getPSLeave_Applied_EmpId_Approval(PRReq objPRReq)
        //{
        //    string s = "select distinct * from eL_tbl_ProjStaff_eLeave_Applied where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' and Approval='" + objPRReq.Approval + "' and LCancel='0'  and Flag1='" + objPRReq.Flag1 + "' and (CONVERT(DATETIME, '" + objPRReq.FromDate + "', 103) BETWEEN SLFromDate AND SLToDate) or (CONVERT(DATETIME, '" + objPRReq.ToDate + "', 103) BETWEEN SLFromDate AND SLToDate)";
        //    objPRResp.GetTable = Connections.GetTable(s);
        //    return objPRResp;
        //}
        public PRResp getPSLeave_Applied_EmpId_Approval(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_ProjStaff_eLeave_Applied where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' and (Approval='0' or Approval='1') and LCancel='0' and Reject='0' and Flag1='" + objPRReq.Flag1 + "' and (SLFromDate <= convert(datetime,'" + objPRReq.SLFromDate + "',105) and SLToDate>= convert(datetime,'" + objPRReq.SLToDate + "',105))";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllPS_EmpLeaves_EmpID(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_ProjStaff_eLeave_Applied where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' and Approval='" + objPRReq.Approval + "' and Reject='" + objPRReq.Reject + "'  and LCancel='0' and Flag1='" + objPRReq.Flag1 + "'  order by ELeaveID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllPS_EmpLeaves_ELeaveID(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_ProjStaff_eLeave_Applied where OID='" + objPRReq.OID + "' and ELeaveID='" + objPRReq.ELeaveID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp UpdatePS_EmpLeaveApplied_ELeaveID_Review(PRReq objPRReq)
        {
            string update = "update eL_tbl_ProjStaff_eLeave_Applied set Approval='" + objPRReq.Approval + "', Reject='" + objPRReq.Reject + "', CurrentStatus='" + objPRReq.CurrentLeaveStatus + "',Flag3='" + objPRReq.Flag3 + "', PCADate='" + objPRReq.PCADate + "',PCAction='" + objPRReq.PCAction + "' where OID='" + objPRReq.OID + "' and ELeaveID='" + objPRReq.ELeaveID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp UpdatePS_EmpLeaveProcess_ELeaveID_Approval(PRReq objPRReq)
        {
            string update = "update eL_tbl_ProjStaff_eLeave_Applied set CurrentStatus='" + objPRReq.CurrentLeaveStatus + "' where OID='" + objPRReq.OID + "' and ELeaveID='" + objPRReq.ELeaveID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }

        public PRResp getPSEmpLeave_ApprovedBy_ELeaveID(PRReq objPRReq)
        {
            string s = "select distinct Name from eL_tbl_ProjStaff_eLeave_History where OID='" + objPRReq.OID + "' and ELeaveID='" + objPRReq.ELeaveID + "' and Action='Sanctioned' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp get_Approved_PSEmpTours_DatesEmpID(PRReq objPRReq)
        {
            string s = "select * from eT_tbl_ProjStaff_eTour_Applied where OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' and Approval='1' and (SLFromDate >= convert(datetime, '" + objPRReq.SLFromDate + "',105) and SLFromDate < convert(datetime, '" + objPRReq.SLToDate + "',105)) order by ETourID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getPSEmpTour_ApprovedBy_ETourID(PRReq objPRReq)
        {
            string s = "select distinct Name from eT_tbl_ProjStaff_eTour_History where OID='" + objPRReq.OID + "' and ETourID='" + objPRReq.ETourID + "' and Action='Sanctioned' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp get_Approved_EmpTours_DatesEmpID(PRReq objPRReq)
        {
            string s = "select * from eT_tbl_RegStaff_eTour_Applied where OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' and Approval='1' and (FromDate >= convert(datetime, '" + objPRReq.SLFromDate + "',105) and (FromDate < convert(datetime, '" + objPRReq.SLToDate + "',105)) OR (FromDate > convert(datetime, '" + objPRReq.SLToDate + "',105))) order by ETourID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp get_Approved_PSEmpLeave_DatesEmpID_SLDate(PRReq objPRReq)
        {
            string s = "select * from eL_tbl_ProjStaff_eLeave_Applied where OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' and Approval='1' and (SLFromDate >= convert(datetime, '" + objPRReq.SLFromDate + "',105) and (SLFromDate < convert(datetime, '" + objPRReq.SLToDate + "',105)) OR (SLFromDate > convert(datetime, '" + objPRReq.SLToDate + "',105))) order by ELeaveID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp AddPS_EmpLeave_History(PRReq objPRReq)
        {
            string insert = "INSERT INTO eL_tbl_ProjStaff_eLeave_History (OID,ELeaveID,Dated,EmpID,Name,OEmpID,OName,Action,Remarks) values('" + objPRReq.OID + "','" + objPRReq.ELeaveID + "','" + objPRReq.Dated + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.OEmpID + "','" + objPRReq.OName + "','" + objPRReq.LAction + "','" + objPRReq.Remarks + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getPS_EmpLeave_History_Repeated_ELeaveID(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_ProjStaff_eLeave_History where OID='" + objPRReq.OID + "' and ELeaveID='" + objPRReq.ELeaveID + "' and Action='" + objPRReq.LAction + "' and OEmpID='" + objPRReq.OEmpID + "' and Remarks='" + objPRReq.Remarks + "' order by ELHID Desc ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getPS_EmpLeave_History_ELeaveID(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_ProjStaff_eLeave_History where OID='" + objPRReq.OID + "' and ELeaveID='" + objPRReq.ELeaveID + "' order by ELHID Desc ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpLeavesforApprovalProcessFlow_PCEmpID(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_ProjStaff_eLeave_Applied where OID='" + objPRReq.OID + "' and PCEmpID='" + objPRReq.PCEmpID + "' and (HEmpID!='" + objPRReq.PCEmpID + "' or HEmpID='" + objPRReq.PCEmpID + "')   and Approval='" + objPRReq.Approval + "' and Reject='" + objPRReq.Reject + "'  and LCancel='0' and Flag1='" + objPRReq.Flag1 + "' and Flag3='0' and (PCStatus='' or PCStatus is NULL or PCStatus='Reply') and (HStatus='' or HStatus is NULL) order by ELeaveID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllPSEmpLeavesforApprovalProcessFlow_SMS(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_ProjStaff_eLeave_Applied where OID='" + objPRReq.OID + "' and Approval='" + objPRReq.Approval + "' and Reject='" + objPRReq.Reject + "' and Dated>='" + objPRReq.FromDate + "'  and LCancel='0' and Flag1='" + objPRReq.Flag1 + "'  and (PCStatus='' or PCStatus is NULL) order by ELeaveID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpLeavesforApprovalProcessFlow_HEmpID(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_ProjStaff_eLeave_Applied where OID='" + objPRReq.OID + "' and HEmpID='" + objPRReq.HEmpID + "' and (PCEmpID!='" + objPRReq.PCEmpID + "' or PCEmpID='" + objPRReq.PCEmpID + "')  and Approval='" + objPRReq.Approval + "' and Reject='" + objPRReq.Reject + "'  and LCancel='0' and Flag1='" + objPRReq.Flag1 + "' and Flag3='0' and PCStatus!='' order by ELeaveID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllPSEmpLeavesforApprovalProcessFlow_HSMS(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_ProjStaff_eLeave_Applied where OID='" + objPRReq.OID + "' and Approval='" + objPRReq.Approval + "' and Reject='" + objPRReq.Reject + "'  and LCancel='0' and Flag1='" + objPRReq.Flag1 + "' and PCStatus!='' order by ELeaveID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpLeavesforApprovalProcessFlow_PCEmpID_Recommended(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_ProjStaff_eLeave_Applied where OID='" + objPRReq.OID + "' and PCEmpID='" + objPRReq.PCEmpID + "' and  HEmpID!='" + objPRReq.PCEmpID + "' and LCancel='0' and Flag1='" + objPRReq.Flag1 + "' and Flag2='" + objPRReq.Flag2 + "' order by ELeaveID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpLeaves_ApprovedByHEmpID(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_ProjStaff_eLeave_Applied where OID='" + objPRReq.OID + "' and (PCEmpID='" + objPRReq.PCEmpID + "' or HEmpID='" + objPRReq.PCEmpID + "') and LCancel='0' and Flag1='" + objPRReq.Flag1 + "' and Flag2='" + objPRReq.Flag2 + "' and Approval='1' order by ELeaveID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpLeavesforApprovalProcessFlow_HEmpID_Recommended(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_ProjStaff_eLeave_Applied where OID='" + objPRReq.OID + "' and HEmpID='" + objPRReq.HEmpID + "' and PCEmpID='" + objPRReq.PCEmpID + "' and LCancel='0' and Flag1='" + objPRReq.Flag1 + "' and Flag2='" + objPRReq.Flag2 + "' order by ELeaveID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpLeavesApproved_HEmpID(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_ProjStaff_eLeave_Applied where OID='" + objPRReq.OID + "' and HEmpID='" + objPRReq.HEmpID + "' and (PCEmpID!='" + objPRReq.PCEmpID + "' or HEmpID='" + objPRReq.HEmpID + "') and LCancel='0' and Flag1='" + objPRReq.Flag1 + "' and Flag2='" + objPRReq.Flag2 + "' and Approval='1' order by ELeaveID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpLeavesforApprovalProcessFlow_PCEmpID_Approved(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_ProjStaff_eLeave_Applied where OID='" + objPRReq.OID + "' and Approval='1' and PCEmpID='" + objPRReq.PCEmpID + "' and LCancel='0' and Flag1='" + objPRReq.Flag1 + "' and Flag2='" + objPRReq.Flag2 + "' order by ELeaveID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpLeavesforApprovalProcessFlow_HEmpID_Approved(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_ProjStaff_eLeave_Applied where OID='" + objPRReq.OID + "' and Approval='1' and HEmpID='" + objPRReq.HEmpID + "'  and LCancel='0' and Flag1='" + objPRReq.Flag1 + "' and Flag2='" + objPRReq.Flag2 + "' order by ELeaveID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpLeavesforApprovalProcessFlow_PCEmpID_Rej(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_ProjStaff_eLeave_Applied where OID='" + objPRReq.OID + "' and Reject='1' and PCEmpID='" + objPRReq.PCEmpID + "' and LCancel='0' and Flag1='" + objPRReq.Flag1 + "' and Flag2='" + objPRReq.Flag2 + "' order by ELeaveID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpLeavesforApprovalProcessFlow_HEmpID_Rej(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_ProjStaff_eLeave_Applied where OID='" + objPRReq.OID + "' and Reject='1' and HEmpID='" + objPRReq.HEmpID + "' and LCancel='0' and Flag1='" + objPRReq.Flag1 + "' and Flag2='" + objPRReq.Flag2 + "' order by ELeaveID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpLeavesforApprovalProcessFlow_PCEmpID_EleaveID(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_ProjStaff_eLeave_Applied where OID='" + objPRReq.OID + "' and Approval='" + objPRReq.Approval + "' and Flag1='" + objPRReq.Flag1 + "' and ELeaveID='" + objPRReq.ELeaveID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getPS_EmpLeaveWorkFlow_EmpID_ELeaveID(PRReq objPRReq)
        {
            string s = "select distinct OEmpID,OName from eL_tbl_ProjStaff_eLeave_History where OID='" + objPRReq.OID + "' and ELeaveID='" + objPRReq.ELeaveID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }


        public PRResp getPS_EmpLeavesByEmpID_LeaveType(PRReq objPRReq)
        {
            string s = "select distinct Year,EmpID,Name,Design,DeptID,CL,SL,CPL,LOP from PR_tbl_ProjectStaff_CLs where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' and Year='" + DateTime.Now.Year + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp getPS_EmpLeave_Info_ELeaveID(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_ProjStaff_eLeave_Applied where OID='" + objPRReq.OID + "' and ELeaveID='" + objPRReq.ELeaveID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp UpdatePS_EmpLeaveAppliedSanction_ELeaveID_Reply(PRReq objPRReq)
        {
            string update = "update eL_tbl_ProjStaff_eLeave_Applied set Approval='" + objPRReq.Approval + "', Reject='" + objPRReq.Reject + "', CurrentStatus='" + objPRReq.CurrentLeaveStatus + "',Flag3='" + objPRReq.Flag3 + "',PCStatus='" + objPRReq.PCStatus + "',PCApproved='" + objPRReq.PCApproved + "', PCADate='" + objPRReq.PCADate + "',PCAction='" + objPRReq.PCAction + "' where OID='" + objPRReq.OID + "' and ELeaveID='" + objPRReq.ELeaveID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp UpdatePS_EmpLeaveAppliedSanction_ELeaveID_Approval_F2(PRReq objPRReq)
        {
            string update = "update eL_tbl_ProjStaff_eLeave_Applied set Approval='" + objPRReq.Approval + "', Reject='" + objPRReq.Reject + "', CurrentStatus='" + objPRReq.CurrentLeaveStatus + "',Flag2='" + objPRReq.Flag2 + "',PCStatus='" + objPRReq.PCStatus + "',PCApproved='" + objPRReq.PCApproved + "', PCADate='" + objPRReq.PCADate + "',PCAction='" + objPRReq.PCAction + "' where OID='" + objPRReq.OID + "' and ELeaveID='" + objPRReq.ELeaveID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }

        public PRResp UpdatePS_EmpLeaveAppliedSanction_ELeaveID_Approval_Final(PRReq objPRReq)
        {
            string update = "update eL_tbl_ProjStaff_eLeave_Applied set Approval='" + objPRReq.Approval + "',Reject='" + objPRReq.Reject + "', CurrentStatus='" + objPRReq.CurrentLeaveStatus + "',Flag2='" + objPRReq.Flag2 + "',HStatus='" + objPRReq.HStatus + "',HApproved='" + objPRReq.HApproved + "', HADate='" + objPRReq.HADate + "',HAction='" + objPRReq.PCAction + "' where OID='" + objPRReq.OID + "' and ELeaveID='" + objPRReq.ELeaveID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }

        public PRResp AddApprovedPSLeaves(PRReq objPRReq)
        {
            string s = "INSERT INTO eL_tbl_ProjStaff_eLeave_Approved (ELeaveID,Year,OID,EmpID,Name,Design,DeptID,LeaveCategory,SLFromDate,SLToDate,SLFromSession,SLToSession,SLPrefixDates,SLSufixDates,SLNoofDays,PurposeofLeave,CurrentStatus,AEmpID,AName,ADate) values('" + objPRReq.ELeaveID + "','" + objPRReq.Year + "','" + objPRReq.OID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.Design + "','" + objPRReq.DeptID + "','" + objPRReq.LeaveCategory + "','" + objPRReq.FromDate + "','" + objPRReq.ToDate + "','" + objPRReq.SLFromSession + "','" + objPRReq.SLToSession + "','" + objPRReq.SLPrefixDates + "','" + objPRReq.SLSufixDates + "','" + objPRReq.CL + "','" + objPRReq.PurposeofLeave + "','" + objPRReq.CurrentLeaveStatus + "','" + objPRReq.AEmpID + "','" + objPRReq.AName + "','" + objPRReq.ADate + "')";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getPS_AllApprovedLeaves_EmpID(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_ProjStaff_eLeave_Approved where OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' and Status='" + objPRReq.Status + "' order by ELeaveID Desc ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp CancelPS_eLeaveby_EleaveID_EmpID(PRReq objPRReq)
        {
            string update = "update eL_tbl_ProjStaff_eLeave_Applied set Status='" + objPRReq.Status + "', LCancel='" + objPRReq.LCancel + "', CurrentStatus='" + objPRReq.CurrentLeaveStatus + "' where ELeaveID='" + objPRReq.ELeaveID + "' and EmpID='" + objPRReq.EmpID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp getAllPS_EmpLeaves_EmpID_Cancel(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_ProjStaff_eLeave_Applied where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' and Approval='" + objPRReq.Approval + "' and Reject='" + objPRReq.Reject + "'  and LCancel='1' and Flag1='" + objPRReq.Flag1 + "'  order by ELeaveID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getRS_EmpLeaveApprovalProces_Repeate_ELeaveID(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_ApprovalProcess where OID='" + objPRReq.OID + "' and ELeaveID='" + objPRReq.ELeaveID + "' and Action='" + objPRReq.LAction + "' and OEmpID='" + objPRReq.OEmpID + "' and Remarks='" + objPRReq.Remarks + "' order by ELAID desc ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getRS_EmpLeave_JR_ApprovalProces_Repeate_ELeaveID(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_JR_Ext_Curt_Cancel_ApprovalProcess where OID='" + objPRReq.OID + "' and ELeaveID='" + objPRReq.ELeaveID + "' and Action='" + objPRReq.LAction + "' and OEmpID='" + objPRReq.OEmpID + "' and Remarks='" + objPRReq.Remarks + "' order by ELAID desc ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getActive_RS_EmpLeaveApprovalProces_ChangeWorkFlowLevel_EmpID(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_ApprovalProcess where OID='" + objPRReq.OID + "' and Approval='0' and OLevel='" + objPRReq.OLevel + "' and EmpID='" + objPRReq.EmpID + "' and Status='Active' order by ELAID desc ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp Update_ProcessLeave_EmpLeaveWorkFlow_Level_ELAID_OLevel(PRReq objPRReq)
        {
            string update = "update eL_tbl_RegStaff_eLeave_ApprovalProcess set OEmpID='" + objPRReq.OEmpID + "',OName='" + objPRReq.OEmpName + "', Remarks='" + objPRReq.Remarks + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ELAID='" + objPRReq.ELAID + "' and OLevel='" + objPRReq.OLevel + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp Update_ProcessLeave_EmpLeaveWorkFlow_Level_ELAID_Other_Level(PRReq objPRReq)
        {
            string update = "update eL_tbl_RegStaff_eLeave_ApprovalProcess set OEmpID='" + objPRReq.OEmpID + "',OName='" + objPRReq.OEmpName + "', OLevel='" + objPRReq.OLevel + "', Remarks='" + objPRReq.Remarks + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ELAID='" + objPRReq.ELAID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        // PS e Tour Management 
        public PRResp ApplyNewPSTour(PRReq objPRReq)
        {
            string s = "INSERT INTO eT_tbl_ProjStaff_eTour_Applied (ETourID,OID,EmpID,Name,Design,DeptID,Email,Mobile,Status,Dated,TourCategory,FromLocation,ToLocation,SLFileName,SLFromDate,SLToDate,SLFromSession,SLToSession,SLPrefixDates,SLSufixDates,SLNoofDays,PCEmpID,PCName,PCLevel,PCDesign,PCDeptID,PCEmail,PCMobile,HEmpID,HName,HLevel,HDesign,HDeptID,HEmail,HMobile,CurrentStatus,PurposeofTour,Flag1,Flag2,Flag3,Flag4,Flag5,Approval,Reject,TCancel,TPullBack) values('" + objPRReq.ETourID + "','" + objPRReq.OID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.Design + "','" + objPRReq.DeptID + "','" + objPRReq.Email + "','" + objPRReq.Mobile + "','" + objPRReq.Status + "','" + objPRReq.Dated + "','" + objPRReq.TourCategory + "','" + objPRReq.FromLocation + "','" + objPRReq.ToLocation + "','" + objPRReq.SLFileName + "','" + objPRReq.FromDate + "','" + objPRReq.ToDate + "','" + objPRReq.SLFromSession + "','" + objPRReq.SLToSession + "','" + objPRReq.SLPrefixDates + "','" + objPRReq.SLSufixDates + "','" + objPRReq.SLNoofDays + "','" + objPRReq.PCEmpID + "','" + objPRReq.PCEmpName + "','" + objPRReq.PCLevel + "','" + objPRReq.PCDesign + "','" + objPRReq.PCDeptID + "','" + objPRReq.PCEmail + "','" + objPRReq.PCMobile + "','" + objPRReq.HEmpID + "','" + objPRReq.HName + "','" + objPRReq.HLevel + "','" + objPRReq.HDesign + "','" + objPRReq.HDeptID + "','" + objPRReq.HEmail + "','" + objPRReq.HMobile + "','" + objPRReq.CurrentTourStatus + "','" + objPRReq.PurposeofTour + "','" + objPRReq.Flag1 + "','" + objPRReq.Flag2 + "','" + objPRReq.Flag3 + "','" + objPRReq.Flag4 + "','" + objPRReq.Flag5 + "','" + objPRReq.Approval + "','" + objPRReq.Reject + "','" + objPRReq.TCancel + "','" + objPRReq.TPullBack + "')";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getPSETAID_SNo(PRReq objPRReq)
        {
            string s = "select max(" + objPRReq.ColumnName + ") from eT_tbl_ProjStaff_eTour_Applied where OID='" + objPRReq.OID + "' ";
            objPRResp.SingleValue = Connections.GetSingleValue(s);
            return objPRResp;
        }

        /* public PRResp getPSTour_Applied_EmpId_Approval(PRReq objPRReq)
         {
             string s = "select distinct * from eT_tbl_ProjStaff_eTour_Applied where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' and Approval='" + objPRReq.Approval + "' and TCancel!='1'  and Flag1='" + objPRReq.Flag1 + "' and (CONVERT(DATETIME, '" + objPRReq.FromDate + "', 103) BETWEEN SLFromDate AND SLToDate) or (CONVERT(DATETIME, '" + objPRReq.ToDate + "', 103) BETWEEN SLFromDate AND SLToDate)";
             objPRResp.GetTable = Connections.GetTable(s);
             return objPRResp;
         }*/
        public PRResp getPSTour_Applied_EmpId_Approval(PRReq objPRReq)
        {
            string s = "select distinct * from eT_tbl_ProjStaff_eTour_Applied where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' and (Approval='0' or Approval='1') and TCancel!='1' and Reject='0'  and Flag1='" + objPRReq.Flag1 + "' and (SLFromDate <= convert(datetime,'" + objPRReq.FromDate + "',105) and SLToDate>= convert(datetime,'" + objPRReq.ToDate + "',105))";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllPS_EmpTours_EmpID(PRReq objPRReq)
        {
            string s = "select distinct * from eT_tbl_ProjStaff_eTour_Applied where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' and Approval='" + objPRReq.Approval + "' and Reject='" + objPRReq.Reject + "'  and TCancel='0' and Flag1='" + objPRReq.Flag1 + "'  order by ETourID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllPS_EmpTours_EmpID_Cancel(PRReq objPRReq)
        {
            string s = "select distinct * from eT_tbl_ProjStaff_eTour_Applied where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' and Approval='" + objPRReq.Approval + "' and Reject='" + objPRReq.Reject + "'  and TCancel='1' and Flag1='" + objPRReq.Flag1 + "'  order by ETourID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllPS_EmpTours_ETourID(PRReq objPRReq)
        {
            string s = "select distinct * from eT_tbl_ProjStaff_eTour_Applied where OID='" + objPRReq.OID + "' and ETourID='" + objPRReq.ETourID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp AddPS_EmpTour_History(PRReq objPRReq)
        {
            string insert = "INSERT INTO eT_tbl_ProjStaff_eTour_History (OID,ETourID,Dated,EmpID,Name,OEmpID,OName,Action,Remarks) values('" + objPRReq.OID + "','" + objPRReq.ETourID + "','" + objPRReq.Dated + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.OEmpID + "','" + objPRReq.OName + "','" + objPRReq.TAction + "','" + objPRReq.Remarks + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getPS_EmpTour_History_Repeate_ETourID(PRReq objPRReq)
        {
            string s = "select distinct * from eT_tbl_ProjStaff_eTour_History where OID='" + objPRReq.OID + "' and ETourID='" + objPRReq.ETourID + "' and Action='" + objPRReq.LAction + "' and OEmpID='" + objPRReq.OEmpID + "' and Remarks='" + objPRReq.Remarks + "' order by ETHID Desc ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getPS_EmpTour_History_ETourID(PRReq objPRReq)
        {
            string s = "select distinct * from eT_tbl_ProjStaff_eTour_History where OID='" + objPRReq.OID + "' and ETourID='" + objPRReq.ETourID + "' order by ETHID Desc ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpToursforApprovalProcessFlow_PCEmpID(PRReq objPRReq)
        {
            string s = "select distinct * from eT_tbl_ProjStaff_eTour_Applied where OID='" + objPRReq.OID + "' and PCEmpID='" + objPRReq.PCEmpID + "' and  (HEmpID!='" + objPRReq.PCEmpID + "' or HEmpID='" + objPRReq.PCEmpID + "')  and Approval='" + objPRReq.Approval + "' and Reject='" + objPRReq.Reject + "' and TCancel='0' and Flag1='" + objPRReq.Flag1 + "' and (PCStatus='' or PCStatus is NULL)  order by ETourID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllPSEmpToursforApprovalProcessFlow_PCSMS(PRReq objPRReq)
        {
            string s = "select distinct * from eT_tbl_ProjStaff_eTour_Applied where OID='" + objPRReq.OID + "' and Approval='" + objPRReq.Approval + "' and Reject='" + objPRReq.Reject + "' and Dated>='" + objPRReq.FromDate + "' and TCancel='0' and Flag1='" + objPRReq.Flag1 + "' and (PCStatus='' or PCStatus is NULL) order by ETourID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpToursforApprovalProcessFlow_HEmpID(PRReq objPRReq)
        {
            string s = "select distinct * from eT_tbl_ProjStaff_eTour_Applied where OID='" + objPRReq.OID + "' and HEmpID='" + objPRReq.HEmpID + "' and (PCEmpID!='" + objPRReq.PCEmpID + "' or PCEmpID='" + objPRReq.PCEmpID + "') and Approval='" + objPRReq.Approval + "' and Reject='" + objPRReq.Reject + "' and TCancel='0' and Flag1='" + objPRReq.Flag1 + "' and PCStatus!='' order by ETourID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllPSEmpToursforApprovalProcessFlow_HSMS(PRReq objPRReq)
        {
            string s = "select distinct * from eT_tbl_ProjStaff_eTour_Applied where OID='" + objPRReq.OID + "' and Approval='" + objPRReq.Approval + "' and Reject='" + objPRReq.Reject + "' and TCancel='0' and Flag1='" + objPRReq.Flag1 + "' and PCStatus!='' order by ETourID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpToursforApprovalProcessFlow_PCEmpID_Recommended(PRReq objPRReq)
        {
            string s = "select distinct * from eT_tbl_ProjStaff_eTour_Applied where OID='" + objPRReq.OID + "' and PCEmpID='" + objPRReq.PCEmpID + "' and  HEmpID!='" + objPRReq.PCEmpID + "' and TCancel='0' and Flag1='" + objPRReq.Flag1 + "' and Flag2='" + objPRReq.Flag2 + "' order by ETourID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpToursforApprovedbyHEmpID(PRReq objPRReq)
        {
            string s = "select distinct * from eT_tbl_ProjStaff_eTour_Applied where OID='" + objPRReq.OID + "' and (PCEmpID='" + objPRReq.PCEmpID + "' or  HEmpID='" + objPRReq.PCEmpID + "') and TCancel='0' and Flag1='" + objPRReq.Flag1 + "' and Flag2='" + objPRReq.Flag2 + "' and Approval='1' order by ETourID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpToursforApprovalProcessFlow_HEmpID_Recommended(PRReq objPRReq)
        {
            string s = "select distinct * from eT_tbl_ProjStaff_eTour_Applied where OID='" + objPRReq.OID + "' and HEmpID='" + objPRReq.HEmpID + "' and PCEmpID='" + objPRReq.PCEmpID + "' and TCancel='0' and Flag1='" + objPRReq.Flag1 + "' and Flag2='" + objPRReq.Flag2 + "' order by ETourID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpToursApproved_HEmpID(PRReq objPRReq)
        {
            string s = "select distinct * from eT_tbl_ProjStaff_eTour_Applied where OID='" + objPRReq.OID + "' and HEmpID='" + objPRReq.HEmpID + "' and PCEmpID='" + objPRReq.PCEmpID + "' and TCancel='0' and Flag1='" + objPRReq.Flag1 + "' and Flag2='" + objPRReq.Flag2 + "' and Approval='1' order by ETourID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpToursforApprovalProcessFlow_PCEmpID_Approved(PRReq objPRReq)
        {
            string s = "select distinct * from eT_tbl_ProjStaff_eTour_Applied where OID='" + objPRReq.OID + "' and Approval='1' and PCEmpID='" + objPRReq.PCEmpID + "' and TCancel='0' and Flag1='" + objPRReq.Flag1 + "' and Flag2='" + objPRReq.Flag2 + "' order by ETourID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpTours_Cancelled_PCEmpID(PRReq objPRReq)
        {
            string s = "select distinct * from eT_tbl_ProjStaff_eTour_Applied where OID='" + objPRReq.OID + "' and Approval='0' and PCEmpID='" + objPRReq.PCEmpID + "' and TCancel='1' and Flag1='" + objPRReq.Flag1 + "' and Flag2='" + objPRReq.Flag2 + "' order by ETourID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpToursforApprovalProcessFlow_HEmpID_Approved(PRReq objPRReq)
        {
            string s = "select distinct * from eT_tbl_ProjStaff_eTour_Applied where OID='" + objPRReq.OID + "' and Approval='1' and HEmpID='" + objPRReq.HEmpID + "'  and TCancel='0' and Flag1='" + objPRReq.Flag1 + "' and Flag2='" + objPRReq.Flag2 + "' order by ETourID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpTours_Cancelled_HEmpID(PRReq objPRReq)
        {
            string s = "select distinct * from eT_tbl_ProjStaff_eTour_Applied where OID='" + objPRReq.OID + "' and Approval='0' and HEmpID='" + objPRReq.HEmpID + "'  and TCancel='1' and Flag1='" + objPRReq.Flag1 + "' and Flag2='" + objPRReq.Flag2 + "' order by ETourID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpToursforApprovalProcessFlow_PCEmpID_Rej(PRReq objPRReq)
        {
            string s = "select distinct * from eT_tbl_ProjStaff_eTour_Applied where OID='" + objPRReq.OID + "' and Reject='1' and PCEmpID='" + objPRReq.PCEmpID + "' and TCancel='0' and Flag1='" + objPRReq.Flag1 + "' and Flag2='" + objPRReq.Flag2 + "' order by ETourID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpToursforApprovalProcessFlow_HEmpID_Rej(PRReq objPRReq)
        {
            string s = "select distinct * from eT_tbl_ProjStaff_eTour_Applied where OID='" + objPRReq.OID + "' and Reject='1' and HEmpID='" + objPRReq.HEmpID + "' and TCancel='0' and Flag1='" + objPRReq.Flag1 + "' and Flag2='" + objPRReq.Flag2 + "' order by ETourID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpToursforApprovalProcessFlow_PCEmpID_ETourID(PRReq objPRReq)
        {
            string s = "select distinct * from eT_tbl_ProjStaff_eTour_Applied where OID='" + objPRReq.OID + "' and Approval='" + objPRReq.Approval + "' and Flag1='" + objPRReq.Flag1 + "' and ETourID='" + objPRReq.ETourID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp getPS_EmpTour_Info_ETourID(PRReq objPRReq)
        {
            string s = "select distinct * from eT_tbl_ProjStaff_eTour_Applied where OID='" + objPRReq.OID + "' and ETourID='" + objPRReq.ETourID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp UpdatePS_EmpTourAppliedSanction_ETourID_Approval_F2(PRReq objPRReq)
        {
            string update = "update eT_tbl_ProjStaff_eTour_Applied set Approval='" + objPRReq.Approval + "', Reject='" + objPRReq.Reject + "', CurrentStatus='" + objPRReq.CurrentTourStatus + "',Flag2='" + objPRReq.Flag2 + "',PCStatus='" + objPRReq.PCStatus + "',PCApproved='" + objPRReq.PCApproved + "', PCADate='" + objPRReq.PCADate + "',PCAction='" + objPRReq.PCAction + "' where OID='" + objPRReq.OID + "' and ETourID='" + objPRReq.ETourID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }

        public PRResp UpdatePS_EmpTourAppliedSanction_ETourID_Approval_Final(PRReq objPRReq)
        {
            string update = "update eT_tbl_ProjStaff_eTour_Applied set Approval='" + objPRReq.Approval + "',Reject='" + objPRReq.Reject + "', CurrentStatus='" + objPRReq.CurrentTourStatus + "',Flag2='" + objPRReq.Flag2 + "',HStatus='" + objPRReq.HStatus + "',HApproved='" + objPRReq.HApproved + "', HADate='" + objPRReq.HADate + "',HAction='" + objPRReq.PCAction + "' where OID='" + objPRReq.OID + "' and ETourID='" + objPRReq.ETourID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp UpdatePS_EmpTourApproved_ETourID_Cancel_Final(PRReq objPRReq)
        {
            string update = "update eT_tbl_ProjStaff_eTour_Applied set Approval='" + objPRReq.Approval + "',Reject='" + objPRReq.Reject + "', TCancel='" + objPRReq.TCancel + "', CurrentStatus='" + objPRReq.CurrentTourStatus + "',Flag2='" + objPRReq.Flag2 + "',HStatus='" + objPRReq.HStatus + "',HApproved='" + objPRReq.HApproved + "', HADate='" + objPRReq.HADate + "',HAction='" + objPRReq.PCAction + "' where OID='" + objPRReq.OID + "' and ETourID='" + objPRReq.ETourID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp AddApprovedPSTours(PRReq objPRReq)
        {
            string s = "INSERT INTO eT_tbl_ProjStaff_eTour_Approved (ETourID,Year,OID,EmpID,Name,Design,DeptID,TourCategory,FromLocation,ToLocation,SLFromDate,SLToDate,SLFromSession,SLToSession,SLPrefixDates,SLSufixDates,SLNoofDays,PurposeofTour,CurrentStatus,AEmpID,AName,ADate) values('" + objPRReq.ETourID + "','" + objPRReq.Year + "','" + objPRReq.OID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.Design + "','" + objPRReq.DeptID + "','" + objPRReq.TourCategory + "','" + objPRReq.FromLocation + "','" + objPRReq.ToLocation + "','" + objPRReq.FromDate + "','" + objPRReq.ToDate + "','" + objPRReq.SLFromSession + "','" + objPRReq.SLToSession + "','" + objPRReq.SLPrefixDates + "','" + objPRReq.SLSufixDates + "','" + objPRReq.CL + "','" + objPRReq.PurposeofTour + "','" + objPRReq.CurrentTourStatus + "','" + objPRReq.AEmpID + "','" + objPRReq.AName + "','" + objPRReq.ADate + "')";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getPS_AllApprovedTours_EmpID(PRReq objPRReq)
        {
            string s = "select distinct * from eT_tbl_ProjStaff_eTour_Approved where OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' and Status='" + objPRReq.Status + "' order by ETourID Desc ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getPS_AllCancelledTours_EmpID(PRReq objPRReq)
        {
            string s = "select distinct * from eT_tbl_ProjStaff_eTour_Applied where OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' and Status='" + objPRReq.Status + "' order by ETourID Desc ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp CancelPS_eTourby_ETourID_EmpID(PRReq objPRReq)
        {
            string update = "update eT_tbl_ProjStaff_eTour_Applied set Status='" + objPRReq.Status + "', TCancel='" + objPRReq.TCancel + "', CurrentStatus='" + objPRReq.CurrentTourStatus + "' where ETourID='" + objPRReq.ETourID + "' and EmpID='" + objPRReq.EmpID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }

        // Late Exceptions

        public PRResp AddLateException(PRReq objPRReq)
        {
            string s = "INSERT INTO eL_tbl_EmpLateExceptions (OID,EmpID,Name,Design,DID,DeptID,LDate,LTime,LSession,LReason,ProblemType,FileName,OEmpID,OName,Status,Dated,Flag1) values('" + objPRReq.OID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.Design + "','" + objPRReq.DID + "','" + objPRReq.DeptID + "','" + objPRReq.FromDate + "','" + objPRReq.PPTime + "','" + objPRReq.SLFromSession + "','" + objPRReq.Remarks + "','" + objPRReq.ProblemType + "','" + objPRReq.FileName + "','" + objPRReq.OEmpID + "','" + objPRReq.OEmpName + "','" + objPRReq.Status + "','" + objPRReq.Dated + "','" + objPRReq.Flag1 + "')";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp getPS_LateExceptions(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_EmpLateExceptions where OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' and LDate='" + objPRReq.FromDate + "' and LReason='" + objPRReq.Remarks + "' and LSession='" + objPRReq.SLFromSession + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getPS_LateExceptions_EmpID(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_EmpLateExceptions where OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' order by LEID Desc ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getPS_LateExceptions_Approval_OEmpID(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_EmpLateExceptions where OID='" + objPRReq.OID + "' and OEmpID='" + objPRReq.OEmpID + "' and Flag1='0' order by LEID Desc ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getPS_LateExceptions_Approved_OEmpID(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_EmpLateExceptions where OID='" + objPRReq.OID + "' and OEmpID='" + objPRReq.OEmpID + "' and Flag1!='0' order by LEID Desc ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp ApproveLateExeptionRequest_OEmpID(PRReq objPRReq)
        {
            string update = "update eL_tbl_EmpLateExceptions set Flag1='1' where LEID='" + objPRReq.LEID + "' and OEmpID='" + objPRReq.OEmpID + "' and OID='" + objPRReq.OID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp RejectLateExeptionRequest_OEmpID(PRReq objPRReq)
        {
            string update = "update eL_tbl_EmpLateExceptions set Flag1='2' where LEID='" + objPRReq.LEID + "' and OEmpID='" + objPRReq.OEmpID + "' and OID='" + objPRReq.OID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }

        public PRResp Cancel_Reg_ELeaveID_OHEmpID(PRReq objPRReq)
        {
            string insert = "insert into eL_tbl_RegStaff_eLeave_Cancelled(ELeaveID,OID,EmpID,Name,Design,DeptID,Status,Dated,SLeaveType,SLFromDate,SLToDate,SLNoofDays,CLeaveType,CLFromDate,CLToDate,CLNoofDays,FileName,OEmpID,OName) values('" + objPRReq.ELeaveID + "','" + objPRReq.OID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.Design + "','" + objPRReq.DeptID + "','" + objPRReq.Status + "','" + objPRReq.Dated + "','" + objPRReq.SLeaveType + "','" + objPRReq.SLFromDate + "','" + objPRReq.SLToDate + "','" + objPRReq.SLNoofDays + "','" + objPRReq.CLeaveType + "','" + objPRReq.CLFromDate + "','" + objPRReq.CLToDate + "','" + objPRReq.CLNoofDays + "','" + objPRReq.FileName + "','" + objPRReq.OEmpID + "','" + objPRReq.OName + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp Cancel_PS_ELeaveID_OHEmpID(PRReq objPRReq)
        {
            string insert = "insert into eL_tbl_ProjStaff_eLeave_Cancelled(ELeaveID,OID,EmpID,Name,Design,DeptID,Status,Dated,SLeaveType,SLFromDate,SLToDate,SLNoofDays,FileName,OEmpID,OName) values('" + objPRReq.ELeaveID + "','" + objPRReq.OID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.Design + "','" + objPRReq.DeptID + "','" + objPRReq.Status + "','" + objPRReq.Dated + "','" + objPRReq.SLeaveType + "','" + objPRReq.SLFromDate + "','" + objPRReq.SLToDate + "','" + objPRReq.SLNoofDays + "','" + objPRReq.FileName + "','" + objPRReq.OEmpID + "','" + objPRReq.OName + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        // REgular Staff Tour Management

        public PRResp ApplyEmpTour(PRReq objPRReq)
        {
            string insert = "INSERT INTO eT_tbl_RegStaff_eTour_Applied (ETourID,OID,EmpID,Name,Design,DeptID,Email,Mobile,Status,Dated,TourType,FromDate,ToDate,FromSession,ToSession,NoofDays,FromLocation,ToLocation,SLPrefixDates,SLSufixDates,SLFileName,PurposeofTour,CCMail,OEmpID,OName,OLevel,ODesign,ODeptID,OEmail,OMobile,CurrentStatus,Flag1,Flag2,Flag3,Flag4,Flag5,Approval,Reject,LSO,LDA,LCancel,LPullBack) values('" + objPRReq.ETourID + "','" + objPRReq.OID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.Design + "','" + objPRReq.DeptID + "','" + objPRReq.Email + "','" + objPRReq.Mobile + "','" + objPRReq.Status + "','" + objPRReq.Dated + "','" + objPRReq.TourType + "','" + objPRReq.FromDate + "','" + objPRReq.ToDate + "','" + objPRReq.SLFromSession + "','" + objPRReq.SLToSession + "','" + objPRReq.SLNoofDays + "','" + objPRReq.FromLocation + "','" + objPRReq.ToLocation + "','" + objPRReq.SLPrefixDates + "','" + objPRReq.SLSufixDates + "','" + objPRReq.SLFileName + "','" + objPRReq.PurposeofTour + "','" + objPRReq.CCMail + "','" + objPRReq.OEmpID + "','" + objPRReq.OEmpName + "','" + objPRReq.OLevel + "','" + objPRReq.ODesign + "','" + objPRReq.ODeptID + "','" + objPRReq.OEmail + "','" + objPRReq.OMobile + "','" + objPRReq.CurrentLeaveStatus + "','" + objPRReq.Flag1 + "','" + objPRReq.Flag2 + "','" + objPRReq.Flag3 + "','" + objPRReq.Flag4 + "','" + objPRReq.Flag5 + "','" + objPRReq.Approval + "','" + objPRReq.Reject + "','" + objPRReq.LSO + "','" + objPRReq.LDA + "','" + objPRReq.LCancel + "','" + objPRReq.LPullBack + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getEmpTour_EmpID_FromDate(PRReq objPRReq)
        {
            string s = "select distinct * from eT_tbl_RegStaff_eTour_Applied where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' and Approval='" + objPRReq.Approval + "' and FromDate='" + objPRReq.FromDate + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getRSETAIDSNo(PRReq objPRReq)
        {
            string s = "select max(" + objPRReq.ColumnName + ") from eT_tbl_RegStaff_eTour_Applied where OID='" + objPRReq.OID + "' ";
            objPRResp.SingleValue = Connections.GetSingleValue(s);
            return objPRResp;
        }

        public PRResp getEmpTour_EmpID_on_SLDate(PRReq objPRReq)
        {
            string s = "select distinct * from eT_tbl_RegStaff_eTour_Applied where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' and (FromDate <= convert(datetime,'" + objPRReq.FromDate + "',105) and ToDate>= convert(datetime,'" + objPRReq.ToDate + "',105)) and LCancel='0' and Reject='0' and (Approval='0' or Approval='1') ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp AddEmpTour_History(PRReq objPRReq)
        {
            string insert = "INSERT INTO eT_tbl_RegStaff_eTour_History (OID,ETourID,Dated,EmpID,Name,OEmpID,OName,Action,Remarks) values('" + objPRReq.OID + "','" + objPRReq.ETourID + "','" + objPRReq.Dated + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.OEmpID + "','" + objPRReq.OName + "','" + objPRReq.LAction + "','" + objPRReq.Remarks + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }

        public PRResp getRS_EmpTour_History_Repeate_ETourID(PRReq objPRReq)
        {
            string s = "select distinct * from eT_tbl_RegStaff_eTour_History where OID='" + objPRReq.OID + "' and ETourID='" + objPRReq.ETourID + "' and Action='" + objPRReq.LAction + "' and OEmpID='" + objPRReq.OEmpID + "' and Remarks='" + objPRReq.Remarks + "' order by ETHID desc ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp getRS_EmpTourApprovalProces_Repeate_ETourID(PRReq objPRReq)
        {
            string s = "select distinct * from eT_tbl_RegStaff_eTour_ApprovalProcess where OID='" + objPRReq.OID + "' and ETourID='" + objPRReq.ETourID + "' and Action='" + objPRReq.LAction + "' and OEmpID='" + objPRReq.OEmpID + "' and Remarks='" + objPRReq.Remarks + "' order by ETAID desc ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp Add_EmpTourApprovalProcess(PRReq objPRReq)
        {
            string insert = "INSERT INTO eT_tbl_RegStaff_eTour_ApprovalProcess(OID,ETourID,Dated,EmpID,Name,OEmpID,OName,OLevel,Decision,Action,Remarks,Status,UID,UName,Flag1,Flag2,Flag3,Flag4,Flag5,Approval,Reject,LSO,LDA,LCancel,LPullBack) values('" + objPRReq.OID + "','" + objPRReq.ETourID + "','" + objPRReq.Dated + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.OEmpID + "','" + objPRReq.OName + "','" + objPRReq.OLevel + "','" + objPRReq.LDecision + "','" + objPRReq.LAction + "','" + objPRReq.Remarks + "','" + objPRReq.Status + "','" + objPRReq.UID + "','" + objPRReq.UName + "','" + objPRReq.Flag1 + "','" + objPRReq.Flag2 + "','" + objPRReq.Flag3 + "','" + objPRReq.Flag4 + "','" + objPRReq.Flag5 + "','" + objPRReq.Approval + "','" + objPRReq.Reject + "','" + objPRReq.LSO + "','" + objPRReq.LDA + "','" + objPRReq.LCancel + "','" + objPRReq.LPullBack + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }

        public PRResp getAllEmpTours_EmpID(PRReq objPRReq)
        {
            string s = "select distinct * from eT_tbl_RegStaff_eTour_Applied where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' and Approval='" + objPRReq.Approval + "' and Reject='" + objPRReq.Reject + "'  and LCancel='0'  order by ETourID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp UpdateTourReportSubmissionStatus_ETourID(PRReq objPRReq)
        {
            string update = "update eT_tbl_RegStaff_eTour_Applied set TourReport='Yes' where OID='" + objPRReq.OID + "' and ETourID='" + objPRReq.ETourID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp getAllCancelledEmpTours_EmpID(PRReq objPRReq)
        {
            string s = "select distinct * from eT_tbl_RegStaff_eTour_Applied where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' and Approval='" + objPRReq.Approval + "' and Reject='" + objPRReq.Reject + "'  and LCancel='1'  order by ETourID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp CanceleTourby_ETourID_EmpID(PRReq objPRReq)
        {
            string update = "update eT_tbl_RegStaff_eTour_Applied set Status='" + objPRReq.Status + "',LCancel='" + objPRReq.LCancel + "', CurrentStatus='" + objPRReq.CurrentLeaveStatus + "' where ETourID='" + objPRReq.ETourID + "' and EmpID='" + objPRReq.EmpID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp CanceleTourProcessby_EleaveID_EmpID(PRReq objPRReq)
        {
            string update = "update eT_tbl_RegStaff_eTour_ApprovalProcess set Status='" + objPRReq.Status + "',LCancel='" + objPRReq.LCancel + "' where ETourID='" + objPRReq.ETourID + "' and EmpID='" + objPRReq.EmpID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp getAllEmpTours_ETourID(PRReq objPRReq)
        {
            string s = "select distinct * from eT_tbl_RegStaff_eTour_Applied where OID='" + objPRReq.OID + "' and ETourID='" + objPRReq.ETourID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp getEmpTour_History_ETourID(PRReq objPRReq)
        {
            string s = "select distinct * from eT_tbl_RegStaff_eTour_History where OID='" + objPRReq.OID + "' and ETourID='" + objPRReq.ETourID + "' order by ETHID Desc ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp getAllEmpToursforApprovalProcessFlow_OEmpID(PRReq objPRReq)
        {
            string s = "select distinct * from eT_tbl_RegStaff_eTour_ApprovalProcess where OID='" + objPRReq.OID + "' and OEmpID='" + objPRReq.OEmpID + "' and Approval='" + objPRReq.Approval + "' and Reject='" + objPRReq.Reject + "'  and LCancel='0'  order by ETourID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp getAllEmpToursforApprovalProcessFlow_LSO(PRReq objPRReq)
        {
            string s = "select distinct * from eT_tbl_RegStaff_eTour_Applied where OID='" + objPRReq.OID + "' and Approval='" + objPRReq.Approval + "' and Reject!='1' and  LCancel!='1' order by ETourID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp getAllEmpToursforApprovalProcessFlow_SMS(PRReq objPRReq)
        {
            string s = "select distinct * from eT_tbl_RegStaff_eTour_ApprovalProcess where OID='" + objPRReq.OID + "' and Approval='" + objPRReq.Approval + "' and Reject='" + objPRReq.Reject + "'  and LCancel='0' and Dated>='" + objPRReq.FromDate + "'  order by ETourID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpToursforApprovalProcessFlow_OEmpIDasUID(PRReq objPRReq)
        {
            string s = "select distinct * from  eT_tbl_RegStaff_eTour_ApprovalProcess where OID='" + objPRReq.OID + "' and UID='" + objPRReq.OEmpID + "' and ETourID='" + objPRReq.ETourID + "'  order by ETourID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpToursforApprovalProcessFlow_OEmpIDasUID_SMS(PRReq objPRReq)
        {
            string s = "select distinct * from  eT_tbl_RegStaff_eTour_ApprovalProcess where OID='" + objPRReq.OID + "' and ETourID='" + objPRReq.ETourID + "'  order by ETourID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpToursforApprovalProcessFlow_OEmpIDasUID_SMS_OLevelDesc(PRReq objPRReq)
        {
            string s = "select distinct * from  eT_tbl_RegStaff_eTour_ApprovalProcess where OID='" + objPRReq.OID + "' and ETourID='" + objPRReq.ETourID + "'  order by OLevel Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpToursforApproval_EmpID_Flag1(PRReq objPRReq)
        {
            string s = "select distinct * from eT_tbl_RegStaff_eTour_Applied where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ETourID='" + objPRReq.ETourID + "' and Flag1='" + objPRReq.Flag1 + "' and Flag2='" + objPRReq.Flag2 + "' and Flag3='" + objPRReq.Flag3 + "' and Flag4='" + objPRReq.Flag4 + "'  and Flag5='" + objPRReq.Flag5 + "' order by ETourID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpToursforApproval_EmpID_Flag1_OEmpID_SMS(PRReq objPRReq)
        {
            string s = "select distinct * from eT_tbl_RegStaff_eTour_ApprovalProcess where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ETourID='" + objPRReq.ETourID + "' and OEmpID='" + objPRReq.OEmpID + "' and Approval='0' and Reject='0' and LCancel='0' and Flag1='" + objPRReq.Flag1 + "' and Flag2='" + objPRReq.Flag2 + "' and Flag3='" + objPRReq.Flag3 + "' and Flag4='" + objPRReq.Flag4 + "'  and Flag5='" + objPRReq.Flag5 + "' order by ETourID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpToursforApproval_EmpID_Flag2_OEmpID_SMS(PRReq objPRReq)
        {
            string s = "select distinct * from eT_tbl_RegStaff_eTour_ApprovalProcess where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ETourID='" + objPRReq.ETourID + "' and OEmpID='" + objPRReq.OEmpID + "' and Approval='0' and Reject='0' and LCancel='0' and Flag1='" + objPRReq.Flag1 + "' and Flag2='" + objPRReq.Flag2 + "' and Flag3='" + objPRReq.Flag3 + "' and Flag4='" + objPRReq.Flag4 + "'  and Flag5='" + objPRReq.Flag5 + "' order by ETourID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpToursforApproval_EmpID_Flag3_OEmpID_SMS(PRReq objPRReq)
        {
            string s = "select distinct * from eT_tbl_RegStaff_eTour_ApprovalProcess where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ETourID='" + objPRReq.ETourID + "' and OEmpID='" + objPRReq.OEmpID + "' and Approval='0' and Reject='0' and LCancel='0' and Flag1='" + objPRReq.Flag1 + "' and Flag2='" + objPRReq.Flag2 + "' and Flag3='" + objPRReq.Flag3 + "' and Flag4='" + objPRReq.Flag4 + "'  and Flag5='" + objPRReq.Flag5 + "' order by ETourID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpToursforApproval_EmpID_Flag4_OEmpID_SMS(PRReq objPRReq)
        {
            string s = "select distinct * from eT_tbl_RegStaff_eTour_ApprovalProcess where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ETourID='" + objPRReq.ETourID + "' and OEmpID='" + objPRReq.OEmpID + "' and Approval='0' and Reject='0' and LCancel='0' and Flag1='" + objPRReq.Flag1 + "' and Flag2='" + objPRReq.Flag2 + "' and Flag3='" + objPRReq.Flag3 + "' and Flag4='" + objPRReq.Flag4 + "'  and Flag5='" + objPRReq.Flag5 + "' order by ETourID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpToursforApproval_EmpID_Flag2(PRReq objPRReq)
        {
            string s = "select distinct * from eT_tbl_RegStaff_eTour_Applied where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ETourID='" + objPRReq.ETourID + "' and Flag1='" + objPRReq.Flag1 + "' and Flag2='" + objPRReq.Flag2 + "' and Flag3='" + objPRReq.Flag3 + "' and Flag4='" + objPRReq.Flag4 + "'  and Flag5='" + objPRReq.Flag5 + "' order by ETourID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpToursforApproval_EmpID_Flag5_OEmpID_SMS(PRReq objPRReq)
        {
            string s = "select distinct * from eT_tbl_RegStaff_eTour_ApprovalProcess where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ETourID='" + objPRReq.ETourID + "' and OEmpID='" + objPRReq.OEmpID + "' and Approval='0' and Reject='0' and LCancel='0' and Flag1='" + objPRReq.Flag1 + "' and Flag2='" + objPRReq.Flag2 + "' and Flag3='" + objPRReq.Flag3 + "' and Flag4='" + objPRReq.Flag4 + "'  and Flag5='" + objPRReq.Flag5 + "' order by ETourID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpToursforApproval_EmpID_Flag3(PRReq objPRReq)
        {
            string s = "select distinct * from eT_tbl_RegStaff_eTour_Applied where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ETourID='" + objPRReq.ETourID + "' and Flag1='" + objPRReq.Flag1 + "' and Flag2='" + objPRReq.Flag2 + "' and Flag3='" + objPRReq.Flag3 + "' and Flag4='" + objPRReq.Flag4 + "'  and Flag5='" + objPRReq.Flag5 + "' order by ETourID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpToursforApproval_EmpID_Flag4(PRReq objPRReq)
        {
            string s = "select distinct * from eT_tbl_RegStaff_eTour_Applied where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ETourID='" + objPRReq.ETourID + "' and Flag1='" + objPRReq.Flag1 + "' and Flag2='" + objPRReq.Flag2 + "' and Flag3='" + objPRReq.Flag3 + "' and Flag4='" + objPRReq.Flag4 + "'  and Flag5='" + objPRReq.Flag5 + "' order by ETourID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpToursforApproval_EmpID_Flag5(PRReq objPRReq)
        {
            string s = "select distinct * from eT_tbl_RegStaff_eTour_Applied where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ETourID='" + objPRReq.ETourID + "' and Flag1='" + objPRReq.Flag1 + "' and Flag2='" + objPRReq.Flag2 + "' and Flag3='" + objPRReq.Flag3 + "' and Flag4='" + objPRReq.Flag4 + "'  and Flag5='" + objPRReq.Flag5 + "' order by ETourID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp getAllEmpToursforApproval_withoutFlag(PRReq objPRReq)
        {
            string s = "select distinct * from eT_tbl_RegStaff_eTour_Applied where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and Approval='" + objPRReq.Approval + "' and ETourID='" + objPRReq.ETourID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpToursforApproval_withoutFlag_SMS(PRReq objPRReq)
        {
            string s = "select distinct * from eT_tbl_RegStaff_eTour_ApprovalProcess where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and Approval='" + objPRReq.Approval + "' and ETourID='" + objPRReq.ETourID + "' OEmpID='" + objPRReq.OEmpID + "' and Approval='0' and Reject='0' and LCancel='0'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpTourWorkFlow_ETourID_OEmpID(PRReq objPRReq)
        {
            string s = "select distinct * from eT_tbl_RegStaff_eTour_ApprovalProcess where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ETourID='" + objPRReq.ETourID + "' and OEmpID='" + objPRReq.OEmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp getAllEmpToursforApprovalProcessFlow_OEmpID_ETourID(PRReq objPRReq)
        {
            string s = "select distinct * from eT_tbl_RegStaff_eTour_ApprovalProcess where OID='" + objPRReq.OID + "' and OEmpID='" + objPRReq.OEmpID + "' and ETourID='" + objPRReq.ETourID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpTour_Info_ETourID(PRReq objPRReq)
        {
            string s = "select distinct * from eT_tbl_RegStaff_eTour_Applied where OID='" + objPRReq.OID + "' and ETourID='" + objPRReq.ETourID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp UpdateEmpTourAppliedSanction_ETourID_Approval(PRReq objPRReq)
        {
            string update = "update eT_tbl_RegStaff_eTour_Applied set Approval='" + objPRReq.Approval + "',CurrentStatus='" + objPRReq.CurrentTourStatus + "' where OID='" + objPRReq.OID + "' and ETourID='" + objPRReq.ETourID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp UpdateEmpTourProcess_ETourID_Approval(PRReq objPRReq)
        {
            string update = "update eT_tbl_RegStaff_eTour_ApprovalProcess set Approval='" + objPRReq.Approval + "' where OID='" + objPRReq.OID + "' and ETourID='" + objPRReq.ETourID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }

        public PRResp UpdateEmpTourApplied_EmpID_OEmpID_Flag1(PRReq objPRReq)
        {
            string update = "update eT_tbl_RegStaff_eTour_Applied  set Flag1='" + objPRReq.Flag1 + "',CurrentStatus='" + objPRReq.CurrentTourStatus + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "'  and ETourID='" + objPRReq.ETourID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp UpdateEmpTourApplied_EmpID_OEmpID_Flag2(PRReq objPRReq)
        {
            string update = "update eT_tbl_RegStaff_eTour_Applied  set Flag2='" + objPRReq.Flag2 + "',CurrentStatus='" + objPRReq.CurrentTourStatus + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ETourID='" + objPRReq.ETourID + "' and Flag1='1' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp UpdateEmpTourApplied_EmpID_OEmpID_Flag3(PRReq objPRReq)
        {
            string update = "update eT_tbl_RegStaff_eTour_Applied  set Flag3='" + objPRReq.Flag3 + "',CurrentStatus='" + objPRReq.CurrentTourStatus + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ETourID='" + objPRReq.ETourID + "' and Flag1='1' and Flag2='1' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp UpdateEmpTourApplied_EmpID_OEmpID_Flag4(PRReq objPRReq)
        {
            string update = "update eT_tbl_RegStaff_eTour_Applied  set Flag4='" + objPRReq.Flag4 + "',CurrentStatus='" + objPRReq.CurrentTourStatus + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "'  and ETourID='" + objPRReq.ETourID + "' and Flag1='1' and Flag2='1' and Flag3='1' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp UpdateEmpTourApplied_EmpID_OEmpID_Flag5(PRReq objPRReq)
        {
            string update = "update eT_tbl_RegStaff_eTour_Applied set Flag5='" + objPRReq.Flag5 + "',CurrentStatus='" + objPRReq.CurrentTourStatus + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ETourID='" + objPRReq.ETourID + "' and Flag1='1' and Flag2='1' and Flag3='1' and Flag4='1' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }

        public PRResp UpdateEmpTourProcess_EmpID_OEmpID_Flag1(PRReq objPRReq)
        {
            string update = "update eT_tbl_RegStaff_eTour_ApprovalProcess set Flag1='" + objPRReq.Flag1 + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "'  and ETourID='" + objPRReq.ETourID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp UpdateEmpTourProcess_EmpID_OEmpID_Flag2(PRReq objPRReq)
        {
            string update = "update eT_tbl_RegStaff_eTour_ApprovalProcess set Flag2='" + objPRReq.Flag2 + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ETourID='" + objPRReq.ETourID + "' and Flag1='1' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp UpdateEmpTourProcess_EmpID_OEmpID_Flag3(PRReq objPRReq)
        {
            string update = "update eT_tbl_RegStaff_eTour_ApprovalProcess set Flag3='" + objPRReq.Flag3 + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ETourID='" + objPRReq.ETourID + "' and Flag1='1' and Flag2='1' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp UpdateEmpTourProcess_EmpID_OEmpID_Flag4(PRReq objPRReq)
        {
            string update = "update eT_tbl_RegStaff_eTour_ApprovalProcess set Flag4='" + objPRReq.Flag4 + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "'  and ETourID='" + objPRReq.ETourID + "' and Flag1='1' and Flag2='1' and Flag3='1' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp UpdateEmpTourProcess_EmpID_OEmpID_Flag5(PRReq objPRReq)
        {
            string update = "update eT_tbl_RegStaff_eTour_ApprovalProcess set Flag5='" + objPRReq.Flag5 + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ETourID='" + objPRReq.ETourID + "' and Flag1='1' and Flag2='1' and Flag3='1' and Flag4='1' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp CancelEmpTourApplied_EmpID_OEmpID(PRReq objPRReq)
        {
            string update = "update eT_tbl_RegStaff_eTour_Applied set LCancel='" + objPRReq.LCancel + "',CurrentStatus='" + objPRReq.CurrentTourStatus + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ETourID='" + objPRReq.ETourID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp getAllEmpToursforApprovalProcessFlow_OEmpID_AS_UID(PRReq objPRReq)
        {
            string s = "select distinct * from eT_tbl_RegStaff_eTour_ApprovalProcess where OID='" + objPRReq.OID + "' and UID='" + objPRReq.OEmpID + "' and Approval='" + objPRReq.Approval + "' and LCancel='0' and Reject='0' order by ETourID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpToursforApprovalProcessFlow_OEmpID_AS_UID_Rejected(PRReq objPRReq)
        {
            string s = "select distinct * from eT_tbl_RegStaff_eTour_ApprovalProcess where OID='" + objPRReq.OID + "' and UID='" + objPRReq.OEmpID + "' and Approval='" + objPRReq.Approval + "' and Reject='1' order by ETourID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpRejectedTours_EmpID(PRReq objPRReq)
        {
            string s = "select distinct * from eT_tbl_RegStaff_eTour_Applied where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' and Approval='" + objPRReq.Approval + "' and Reject='1'  and LCancel='0'  order by ETourID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp UpdateRejectedEmpTourApplied_EmpID_OEmpID(PRReq objPRReq)
        {
            string update = "update eT_tbl_RegStaff_eTour_Applied set Reject='" + objPRReq.Reject + "',CurrentStatus='" + objPRReq.CurrentTourStatus + "' where OID='" + objPRReq.OID + "'  and ETourID='" + objPRReq.ETourID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }

        public PRResp UpdateRejectedEmpLeaveApplied_EmpID_OEmpID(PRReq objPRReq)
        {
            string update = "update eL_tbl_RegStaff_eLeave_Applied set Reject='" + objPRReq.Reject + "',CurrentStatus='" + objPRReq.CurrentTourStatus + "' where OID='" + objPRReq.OID + "'  and ELeaveID='" + objPRReq.ELeaveID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }

        public PRResp AddApprovedRSLeaves(PRReq objPRReq)
        {
            string s = "INSERT INTO eL_tbl_RegStaff_eLeave_Approved (ELeaveID,Year,OID,EmpID,Name,Design,DeptID,LeaveCategory,SLFromDate,SLToDate,SLFromSession,SLToSession,SLPrefixDates,SLSufixDates,SLNoofDays,PurposeofLeave,CurrentStatus,PrevBalance,RemBalance,AEmpID,AName,ADate) values('" + objPRReq.ELeaveID + "','" + objPRReq.Year + "','" + objPRReq.OID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.Design + "','" + objPRReq.DeptID + "','" + objPRReq.LeaveCategory + "','" + objPRReq.SLFromDate + "','" + objPRReq.SLToDate + "','" + objPRReq.SLFromSession + "','" + objPRReq.SLToSession + "','" + objPRReq.SLPrefixDates + "','" + objPRReq.SLSufixDates + "','" + objPRReq.SLeaveType + "','" + objPRReq.PurposeofLeave + "','" + objPRReq.CurrentLeaveStatus + "','" + objPRReq.PrevBalance + "','" + objPRReq.RemBalance + "','" + objPRReq.AEmpID + "','" + objPRReq.AName + "','" + objPRReq.ADate + "')";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp AddApprovedRSTours(PRReq objPRReq)
        {
            string s = "INSERT INTO eT_tbl_RegStaff_eTour_Approved (ETourID,Year,OID,EmpID,Name,Design,DeptID,TourCategory,FromLocation,ToLocation,SLFromDate,SLToDate,SLFromSession,SLToSession,SLPrefixDates,SLSufixDates,SLNoofDays,PurposeofTour,CurrentStatus,AEmpID,AName,ADate) values('" + objPRReq.ETourID + "','" + objPRReq.Year + "','" + objPRReq.OID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.Design + "','" + objPRReq.DeptID + "','" + objPRReq.TourCategory + "','" + objPRReq.FromLocation + "','" + objPRReq.ToLocation + "','" + objPRReq.FromDate + "','" + objPRReq.ToDate + "','" + objPRReq.SLFromSession + "','" + objPRReq.SLToSession + "','" + objPRReq.SLPrefixDates + "','" + objPRReq.SLSufixDates + "','" + objPRReq.CL + "','" + objPRReq.PurposeofTour + "','" + objPRReq.CurrentTourStatus + "','" + objPRReq.AEmpID + "','" + objPRReq.AName + "','" + objPRReq.ADate + "')";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        // Project Staff Holidays

        public PRResp getAttendance_ProjHolidays_DatesEmpID(PRReq objPRReq)
        {
            string s = "select * from eL_tbl_ProjectStaff_ClosedHolidays where OID='" + objPRReq.OID + "' and ((HDate >= '" + objPRReq.SLFromDate + "' and HDate <= '" + objPRReq.SLToDate + "'))";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp getAttendance_EssentialHolidays_DatesEmpID(PRReq objPRReq)
        {
            string s = "select * from eL_tbl_RegularStaff_Essential_ClosedHolidays where OID='" + objPRReq.OID + "' and ((HDate >= '" + objPRReq.SLFromDate + "' and HDate <= '" + objPRReq.SLToDate + "'))";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp getAttendance_NonEssentialHolidays_DatesEmpID(PRReq objPRReq)
        {
            string s = "select * from eL_tbl_RegularStaff_NonEssential_ClosedHolidays where OID='" + objPRReq.OID + "' and ((HDate >= '" + objPRReq.SLFromDate + "' and HDate <= '" + objPRReq.SLToDate + "'))";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp getAttendance_AllPH_DatesEmpID(PRReq objPRReq)
        {
            string s = "select * from eL_tbl_GovtHolidays where OID='" + objPRReq.OID + "' and HType='PH' and HDate >= '" + objPRReq.SLFromDate + "' and HDate <= '" + objPRReq.SLToDate + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp getAttendance_NonEssential_With_Holidays_HDates(PRReq objPRReq)
        {
            string s = "(select HDate from eL_tbl_GovtHolidays where OID='" + objPRReq.OID + "' and HType='PH' and HDate= '" + objPRReq.Dated + "')union(select HDate from eL_tbl_RegularStaff_NonEssential_ClosedHolidays where OID='" + objPRReq.OID + "' and HDate = '" + objPRReq.Dated + "')";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;

        }
        public PRResp getAttendance_NonEssential_With_Holidays_MissedDates(PRReq objPRReq)
        {
            string s = "(select HDate from eL_tbl_GovtHolidays where OID='" + objPRReq.OID + "' and HType='PH' and Year='" + objPRReq.Year + "' and HDate= '" + objPRReq.Dated + "')union(select HDate from eL_tbl_RegularStaff_NonEssential_ClosedHolidays where OID='" + objPRReq.OID + "'  and Year='" + objPRReq.Year + "' and HDate = '" + objPRReq.Dated + "')";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;

        }
        public PRResp getAttendance_Essential_With_Holidays_HDates(PRReq objPRReq)
        {
            string s = "(select HDate from eL_tbl_GovtHolidays where OID='" + objPRReq.OID + "' and HType='PH' and HDate= '" + objPRReq.Dated + "')union(select HDate from eL_tbl_RegularStaff_Essential_ClosedHolidays where OID='" + objPRReq.OID + "' and HDate = '" + objPRReq.Dated + "')";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;

        }
        public PRResp getAttendance_Essential_With_Holidays_MissedDates(PRReq objPRReq)
        {
            string s = "(select HDate from eL_tbl_GovtHolidays where OID='" + objPRReq.OID + "' and HType='PH' and Year='" + objPRReq.Year + "' and HDate= '" + objPRReq.Dated + "')union(select HDate from eL_tbl_RegularStaff_Essential_ClosedHolidays where OID='" + objPRReq.OID + "' and Year='" + objPRReq.Year + "' and HDate = '" + objPRReq.Dated + "')";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;

        }
        public PRResp getAttendance_ProjStaf_With_Holidays_HDates(PRReq objPRReq)
        {
            string s = "(select HDate from eL_tbl_GovtHolidays where OID='" + objPRReq.OID + "' and HType='PH' and HDate= '" + objPRReq.Dated + "')union(select HDate from eL_tbl_ProjectStaff_ClosedHolidays where OID='" + objPRReq.OID + "' and HDate = '" + objPRReq.Dated + "')";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;

        }

        public PRResp getAllPS_AppliedTours_EmpTours_EmpID(PRReq objPRReq)
        {
            string s = "select distinct * from eT_tbl_ProjStaff_eTour_Applied where OID='" + objPRReq.OID + "' and Status='Active' and EmpID='" + objPRReq.EmpID + "' and Reject='0'  and TCancel='0' and  ((SLFromDate >= '" + objPRReq.SLFromDate + "' and SLToDate <= '" + objPRReq.SLFromDate + "'))  order by ETourID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp getAllRegStaff_AppliedTours_EmpTours_EmpID(PRReq objPRReq)
        {
            string s = "select distinct * from eT_tbl_RegStaff_eTour_Applied where OID='" + objPRReq.OID + "' and Status='Active' and EmpID='" + objPRReq.EmpID + "' and Reject='0'  and LCancel='0' and  ((FromDate >= '" + objPRReq.SLFromDate + "' and ToDate <= '" + objPRReq.SLFromDate + "'))  order by ETourID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        // ELeave Work Deligation

        public PRResp AddeLeaveWorkDeligation(PRReq objPRReq)
        {
            string s = "INSERT INTO eL_tbl_EmpLeaveDeligation (OID,ELeaveID,EmpID,Name,OEmpID,OName,UID,UName,Status,Dated) values('" + objPRReq.OID + "','" + objPRReq.ELeaveID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.OEmpID + "','" + objPRReq.OName + "','" + objPRReq.UID + "','" + objPRReq.UName + "','" + objPRReq.Status + "','" + objPRReq.Dated + "')";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp geteLeaveWorkDeligation_ELeaveID(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_EmpLeaveDeligation where OID='" + objPRReq.OID + "' and Status='Active' and ELeaveID='" + objPRReq.ELeaveID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp getEmpLeaveDeligationSNo(PRReq objPRReq)
        {
            string s = "select max(" + objPRReq.ColumnName + ") from eL_tbl_EmpLeaveDeligation where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.SingleValue = Connections.GetSingleValue(s);
            return objPRResp;
        }

        //
        public PRResp updateLeaveWorkDeligationStatus(PRReq objPRReq)
        {
            string update = "update eL_tbl_RegStaff_eLeave_Applied set WorkAssignTo='" + objPRReq.WorkAssignTo + "' where ELeaveID='" + objPRReq.ELeaveID + "' and Status='" + objPRReq.Status + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }

        public PRResp getAllEmpDetails_ELeaveID(PRReq objPRReq)
        {
            string s = "select distinct * from eL_tbl_RegStaff_eLeave_Applied where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ELeaveID='" + objPRReq.ELeaveID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getERIDSNo(PRReq objPRReq)
        {
            string s = "select max(" + objPRReq.ColumnName + ") from PR_tbl_ResumeResourcePool where OID='" + objPRReq.OID + "' ";
            objPRResp.SingleValue = Connections.GetSingleValue(s);
            return objPRResp;
        }

        public PRResp AddeResumeResourcePool(PRReq objPRReq)
        {
            string s = "INSERT INTO PR_tbl_ResumeResourcePool(OID,DID,DeptID,Name,Email,Mobile,Qualification,WorkArea,SkillSet,Age,Experience,OrgName,Design,ResumeTitle,FileName,Status,Dated,UID,UName) values('" + objPRReq.OID + "','" + objPRReq.DID + "','" + objPRReq.DeptID + "','" + objPRReq.Name + "','" + objPRReq.Email + "','" + objPRReq.OMobile + "','" + objPRReq.Qualification + "','" + objPRReq.WorkArea + "','" + objPRReq.SkillSet + "','" + objPRReq.UserAge + "','" + objPRReq.Experience + "','" + objPRReq.OrgName + "','" + objPRReq.Design + "','" + objPRReq.ResumeTitle + "','" + objPRReq.FileName + "','" + objPRReq.Status + "','" + objPRReq.Dated + "','" + objPRReq.UID + "','" + objPRReq.UName + "')";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp getResumeResourcePool(PRReq objPRReq)
        {
            string s = "select distinct * from PR_tbl_ResumeResourcePool where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and Name='" + objPRReq.Name + "' and ResumeTitle='" + objPRReq.ResumeTitle + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp getAllResumes_fromResourcePool(PRReq objPRReq)
        {
            string s = "select distinct * from PR_tbl_ResumeResourcePool where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp SearchAllResumes_fromResourcePool(PRReq objPRReq)
        {
            string s = "select distinct * from PR_tbl_ResumeResourcePool where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and (Name like '%" + objPRReq.ResumeTitle + "%' or Design like '%" + objPRReq.ResumeTitle + "%' or DeptID like '%" + objPRReq.ResumeTitle + "%' or Email like '%" + objPRReq.ResumeTitle + "%' or Mobile like '%" + objPRReq.ResumeTitle + "%' or WorkArea like '%" + objPRReq.ResumeTitle + "%' or SkillSet like '%" + objPRReq.ResumeTitle + "%' or ResumeTitle like '%" + objPRReq.ResumeTitle + "%' or Age like '%" + objPRReq.ResumeTitle + "%' or Experience like '%" + objPRReq.ResumeTitle + "%' or OrgName like '%" + objPRReq.ResumeTitle + "%' or Qualification like '%" + objPRReq.ResumeTitle + "%' )";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp AddResourcePersons(PRReq objPRReq)
        {
            string s = "INSERT INTO PR_tbl_ResourcePersons(OID,DID,DeptID,Name,Design,Email,Mobile,Qualification,WorkArea,SkillSet,OrgName,ResumeTitle,FileName,Status,Dated,UID,UName) values('" + objPRReq.OID + "','" + objPRReq.DID + "','" + objPRReq.DeptID + "','" + objPRReq.Name + "','" + objPRReq.Design + "','" + objPRReq.Email + "','" + objPRReq.OMobile + "','" + objPRReq.Qualification + "','" + objPRReq.WorkArea + "','" + objPRReq.SkillSet + "','" + objPRReq.OrgName + "','" + objPRReq.ResumeTitle + "','" + objPRReq.FileName + "','" + objPRReq.Status + "','" + objPRReq.Dated + "','" + objPRReq.UID + "','" + objPRReq.UName + "')";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getRIDSNo(PRReq objPRReq)
        {
            string s = "select max(" + objPRReq.ColumnName + ") from PR_tbl_ResourcePersons where OID='" + objPRReq.OID + "' ";
            objPRResp.SingleValue = Connections.GetSingleValue(s);
            return objPRResp;
        }

        public PRResp getResourcePersons(PRReq objPRReq)
        {
            string s = "select distinct * from PR_tbl_ResourcePersons where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and Name='" + objPRReq.Name + "' and ResumeTitle='" + objPRReq.ResumeTitle + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp getAllResumes_fromResourcePersons(PRReq objPRReq)
        {
            string s = "select distinct * from PR_tbl_ResourcePersons where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp SearchAllResumes_fromResourcePersons(PRReq objPRReq)
        {
            string s = "select distinct * from PR_tbl_ResourcePersons where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and (Name like '%" + objPRReq.ResumeTitle + "%' or Design like '%" + objPRReq.ResumeTitle + "%' or DeptID like '%" + objPRReq.ResumeTitle + "%' or Email like '%" + objPRReq.ResumeTitle + "%' or Mobile like '%" + objPRReq.ResumeTitle + "%' or WorkArea like '%" + objPRReq.ResumeTitle + "%' or SkillSet like '%" + objPRReq.ResumeTitle + "%' or ResumeTitle like '%" + objPRReq.ResumeTitle + "%' or OrgName like '%" + objPRReq.ResumeTitle + "%' or Qualification like '%" + objPRReq.ResumeTitle + "%' )";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        // Work Delegation

        public PRResp AddWorkDelegation(PRReq objPRReq)
        {
            string insert = "INSERT INTO tbl_EmpWorkDelegation (OID,OEmpID,OName,EmpID,Name,FileName,Dated,Status) values('" + objPRReq.OID + "','" + objPRReq.OEmpID + "','" + objPRReq.OName + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.FileName + "','" + objPRReq.Dated + "','" + objPRReq.Status + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getWorkDelegationName(PRReq objPRReq)
        {
            string s = "select distinct * from tbl_EmpWorkDelegation where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and OEmpID='" + objPRReq.OEmpID + "' and EmpID='" + objPRReq.EmpID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllWorkDelegations(PRReq objPRReq)
        {
            string s = "select distinct * from tbl_EmpWorkDelegation where OID='" + objPRReq.OID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmp_Workdelegation_EmpID(PRReq objPRReq)
        {
            string s = "select distinct * from tbl_EmpWorkDelegation where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp UpdateWorkDelegation(PRReq objPRReq)
        {
            string update = "update tbl_EmpWorkDelegation set Status='" + objPRReq.Status + "' where OID='" + objPRReq.OID + "' and  WDID='" + objPRReq.EmpID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }

        public PRResp getAllFinEntries(PRReq objPRReq)
        {
            string s = "select distinct * from FIN_tbl_InvoiceEntry where Status='" + objPRReq.Status + "' order by FID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp getInvoceEmpID(PRReq objPRReq)
        {
            string s = "select max(" + objPRReq.ColumnName + ") from FIN_tbl_InvoiceEntry where Status='" + objPRReq.Status + "' ";
            objPRResp.SingleValue = Connections.GetSingleValue(s);
            return objPRResp;
        }

        public PRResp AddInvoiceEntry(PRReq objPRReq)
        {
            string insert = "INSERT INTO FIN_tbl_InvoiceEntry (JStatus,JType,InvoiceNumber,InvoiceDate,DSNo,FromDate,ToDate,ProjectCode,UserType,UserID,Name,Place,Amount,Dated,Status,UID,UName) values('" + objPRReq.JStatus + "','" + objPRReq.JType + "','" + objPRReq.InvoiceNumber + "','" + objPRReq.InvoiceDate + "','" + objPRReq.DSNo + "','" + objPRReq.FromDate + "','" + objPRReq.ToDate + "','" + objPRReq.ProjectCode + "','" + objPRReq.UserType + "','" + objPRReq.UserID + "','" + objPRReq.Name + "','" + objPRReq.PlacetoVisit + "','" + objPRReq.AmountPayable + "','" + objPRReq.Dated + "','" + objPRReq.Status + "','" + objPRReq.UID + "','" + objPRReq.UName + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getAllFinEntries_Repeted(PRReq objPRReq)
        {
            string s = "select distinct * from FIN_tbl_InvoiceEntry where Status='" + objPRReq.Status + "' and JStatus='" + objPRReq.JStatus + "' and JType='" + objPRReq.JType + "' and InvoiceNumber='" + objPRReq.InvoiceNumber + "' and InvoiceDate='" + objPRReq.InvoiceDate + "' and FromDate='" + objPRReq.FromDate + "' and ToDate='" + objPRReq.ToDate + "' and DSNo='" + objPRReq.DSNo + "' and Name='" + objPRReq.Name + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllNIRDEmpList(PRReq objPRReq)
        {
            string s = "(select EmpID,Name,DeptID,Design,Photo from PR_tbl_Employee  where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "')union(select EmpID,Name,DeptID,Design,Photo from PR_tbl_ProjectStaff  where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "') order by Name Asc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp getAllNIRDEmpList_bySearch(PRReq objPRReq)
        {
            string s = "(select EmpID,Name,DeptID,Design,Photo from PR_tbl_Employee  where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and Name like '%" + objPRReq.Name + "%')union(select EmpID,Name,DeptID,Design,Photo from PR_tbl_ProjectStaff  where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "'  and Name like '%" + objPRReq.Name + "%') order by Name Asc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        // Popup Images

        public PRResp AddPopUpImage(PRReq objPRReq)
        {
            string insert = "insert into tbl_PopupImages (Title,FileName,StartDate,EndDate,Status,Dated) values('" + objPRReq.Title + "','" + objPRReq.FileName + "','" + objPRReq.StartDate + "','" + objPRReq.EndDate + "','" + objPRReq.Status + "','" + objPRReq.Dated + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }

        public PRResp getPopUpImage_Name_Repeted(PRReq objPRReq)
        {
            string s = "select distinct * from tbl_PopupImages where Status='" + objPRReq.Status + "' and FileName='" + objPRReq.FileName + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getPopupActiveImage(PRReq objPRReq)
        {
            string s = "select distinct * from tbl_PopupImages where Status='" + objPRReq.Status + "' and EndDate>='" + objPRReq.EndDate + "' order by ID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllPopupImages(PRReq objPRReq)
        {
            string s = "select distinct * from tbl_PopupImages where Status='" + objPRReq.Status + "' order by ID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp BlockPopupImage(PRReq objPRReq)
        {
            string update = "update tbl_PopupImages set Status='" + objPRReq.Status + "' where ID='" + objPRReq.IID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }

        public PRResp DelPopupImage(PRReq objPRReq)
        {
            string hod = "delete from tbl_PopupImages where ID='" + objPRReq.IID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }

        public PRResp AddGallery(PRReq objPRReq)
        {
            string insert = "insert into tbl_Gallery (OID,EmpID,Name,Design,ICID,ItemCategory,Title,FileName,ContentType,Data,Status) values('" + objPRReq.OID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.Design + "','" + objPRReq.ICID + "','" + objPRReq.ItemCategory + "','" + objPRReq.Title + "','" + objPRReq.FileName + "','" + objPRReq.ContentType + "', cast('" + objPRReq.Data + "' as varbinary(MAX)),'" + objPRReq.Status + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getGallery_EmpID_ICID_Title(PRReq objPRReq)
        {
            string s = "select distinct * from tbl_Gallery where Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' and OID='" + objPRReq.OID + "' and ICID='" + objPRReq.ICID + "' and Title='" + objPRReq.Title + "' order by ID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllGallery_EmpID(PRReq objPRReq)
        {
            string s = "select distinct * from tbl_Gallery where Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' and OID='" + objPRReq.OID + "' order by ID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllGallery_EmpID_ID(PRReq objPRReq)
        {
            string s = "select distinct Data from tbl_Gallery where ID='" + objPRReq.EmpID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        // Engineering Ticketing
        // Engineering Ticketing
        public PRResp getAllProblemCategorys(PRReq objPRReq)
        {
            string s = "select distinct PCID,ProblemCategory from ET_tbl_DealingOfficer where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' order by ProblemCategory Asc ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getProblemCategorys(PRReq objPRReq)
        {
            string s = "select * from ET_tbl_ProblemCategory where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' order by ProblemCategory Asc ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp AddProblemCategory(PRReq objPRReq)
        {
            string insert = "insert into ET_tbl_ProblemCategory (OID,ProblemCategory,Status) values('" + objPRReq.OID + "','" + objPRReq.ProblemCategory + "','" + objPRReq.Status + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getProblemCategoryByName(PRReq objPRReq)
        {
            string s = "select * from ET_tbl_ProblemCategory where  ProblemCategory='" + objPRReq.ProblemCategory + "' and OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getProblemCategoryByPCID(PRReq objPRReq)
        {
            string s = "select * from ET_tbl_ProblemCategory where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and PCID='" + objPRReq.PCID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp EditProblemCategoryByPCID(PRReq objPRReq)
        {
            string update = "update ET_tbl_ProblemCategory set ProblemCategory='" + objPRReq.ProblemCategory + "' where PCID='" + objPRReq.PCID + "' and OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp DelProblemCategory(PRReq objPRReq)
        {
            string hod = "delete from ET_tbl_ProblemCategory where  OID='" + objPRReq.OID + "' and PCID='" + objPRReq.PCID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }
        public PRResp ProblemCategorySearch(PRReq objPRReq)
        {
            string s = "select * from ET_tbl_ProblemCategory where ProblemCategory like '%" + objPRReq.ProblemCategory + "%' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        // Mapping to Dealing Officer
        public PRResp getET_DealingOfficers_PCID(PRReq objPRReq)
        {
            string s = "select * from ET_tbl_DealingOfficer where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and PCID='" + objPRReq.PCID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getET_DealingOfficers(PRReq objPRReq)
        {
            string s = "select * from ET_tbl_DealingOfficer where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' order by ProblemCategory Asc ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp AddET_DealingOfficer(PRReq objPRReq)
        {
            string insert = "insert into ET_tbl_DealingOfficer (OID,EmpID,Name,PCID,ProblemCategory,Status,Dated) values('" + objPRReq.OID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.PCID + "','" + objPRReq.ProblemCategory + "','" + objPRReq.Status + "','" + objPRReq.Dated + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }

        public PRResp getET_DealingOfficerByName(PRReq objPRReq)
        {
            string s = "select * from ET_tbl_DealingOfficer where  ProblemCategory='" + objPRReq.ProblemCategory + "' and Name='" + objPRReq.Name + "' and OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp EditET_DealingOfficerByETID(PRReq objPRReq)
        {
            string update = "update ET_tbl_DealingOfficer set ProblemCategory='" + objPRReq.ProblemCategory + "', PCID='" + objPRReq.PCID + "',EmpID='" + objPRReq.EmpID + "',Name='" + objPRReq.Name + "' where ETID='" + objPRReq.ETID + "' and OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        // Default User for Applications

        public PRResp AddDeFaultUserforApp(PRReq objPRReq)
        {
            string insert = "INSERT INTO tbl_App_DefaultUsers(OID,OEmpID,OName,Application,Status,Dated) values('" + objPRReq.OID + "','" + objPRReq.OEmpID + "','" + objPRReq.OName + "','" + objPRReq.Application + "','" + objPRReq.Status + "','" + objPRReq.Dated + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getDeFaultUserforAppName(PRReq objPRReq)
        {
            string s = "select * from tbl_App_DefaultUsers where OID='" + objPRReq.OID + "' and Application='" + objPRReq.Application + "' and Status='" + objPRReq.Status + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllDeFaultUserforAppName(PRReq objPRReq)
        {
            string s = "select * from tbl_App_DefaultUsers where OID='" + objPRReq.OID + "' order by Application Asc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getDeFaultUser_AppName(PRReq objPRReq)
        {
            string s = "select * from tbl_App_DefaultUsers where OID='" + objPRReq.OID + "' and Application='" + objPRReq.Application + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }


        //Add Complaint
        public PRResp AddET_Complaint(PRReq objPRReq)
        {
            string insert = "insert into ET_tbl_EComplaint (ComplaintID,OID,EmpID,Name,Location,PCID,ProblemCategory,ProblemDescription,OEmpID,OName,Dated,Status,Flag_New,Flag_Open,Flag_Hold,Flag_Close) values('" + objPRReq.ComplaintID + "','" + objPRReq.OID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.Location + "','" + objPRReq.PCID + "','" + objPRReq.ProblemCategory + "','" + objPRReq.ProblemDescription + "','" + objPRReq.OEmpID + "','" + objPRReq.OEmpName + "','" + objPRReq.Dated + "','" + objPRReq.Status + "','" + objPRReq.Flag_New + "','" + objPRReq.Flag_Open + "','" + objPRReq.Flag_Hold + "','" + objPRReq.Flag_Close + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getET_Complaint_Description(PRReq objPRReq)
        {
            string s = "select distinct * from ET_tbl_EComplaint where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and PCID='" + objPRReq.PCID + "' and EmpID='" + objPRReq.EmpID + "' and ProblemDescription='" + objPRReq.ProblemDescription + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getET_ComplaintSNo(PRReq objPRReq)
        {
            string s = "select max(" + objPRReq.ColumnName + ") from ET_tbl_EComplaint where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.SingleValue = Connections.GetSingleValue(s);
            return objPRResp;
        }
        public PRResp DelEmp_ET_DealingAsstETID(PRReq objPRReq)
        {
            string hod = "delete from ET_tbl_DealingOfficer where  OID='" + objPRReq.OID + "' and ETID='" + objPRReq.ETID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }
        public PRResp getAllET_Complaint_EmpID_New(PRReq objPRReq)
        {
            string s = "select distinct * from ET_tbl_EComplaint where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' and Flag_New='1'  and Flag_Hold='0' and Flag_Close='0' order by ComplaintID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllET_Complaint_EmpID_InProgress(PRReq objPRReq)
        {
            string s = "select distinct * from ET_tbl_EComplaint where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' and Flag_New='1'  and Flag_Hold='0' and Flag_Close='0' order by ComplaintID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllET_Complaint_EmpID_Hold(PRReq objPRReq)
        {
            string s = "select distinct * from ET_tbl_EComplaint where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' and Flag_New='1' and Flag_Hold='1' and Flag_Close='0' order by ComplaintID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllET_Complaint_Hold_Dashboard(PRReq objPRReq)
        {
            string s = "select distinct * from ET_tbl_EComplaint where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and Flag_New='1'  and Flag_Hold='1' and Flag_Close='0' order by ComplaintID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllET_Complaint_InProgress_Dashboard(PRReq objPRReq)
        {
            string s = "select distinct * from ET_tbl_EComplaint where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and Flag_New='1' and Flag_Open='1' and Flag_Hold='0' and Flag_Close='0' order by ComplaintID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllET_Complaints_Closed_Dashboard(PRReq objPRReq)
        {
            string s = "select distinct * from ET_tbl_EComplaint where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and Flag_New='1' and Flag_Close='1' order by ComplaintID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllET_Complaints_New_Dashboard(PRReq objPRReq)
        {
            string s = "select distinct * from ET_tbl_EComplaint where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and Flag_New='1' and Flag_Hold='0' and Flag_Close='0' order by ComplaintID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllET_Complaint_EmpID_Closed(PRReq objPRReq)
        {
            string s = "select distinct * from ET_tbl_EComplaint where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' and Flag_New='1' and Flag_Close='1' order by ComplaintID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllET_Complaint_Resolve_OEmpID(PRReq objPRReq)
        {
            string s = "select distinct * from ET_tbl_EComplaint where OID='" + objPRReq.OID + "' and OEmpID='" + objPRReq.OEmpID + "' and Flag_New='1' and Flag_Hold='" + objPRReq.Flag_Hold + "' and Flag_Close='" + objPRReq.Flag_Close + "' order by ComplaintID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllET_Complaint_Closed_OEmpID(PRReq objPRReq)
        {
            string s = "select distinct * from ET_tbl_EComplaint where OID='" + objPRReq.OID + "' and OEmpID='" + objPRReq.OEmpID + "' and Flag_New='1' and Flag_Close='" + objPRReq.Flag_Close + "' order by ComplaintID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllET_Complaint_Resolve_EmpID(PRReq objPRReq)
        {
            string s = "select distinct * from ET_tbl_EComplaint where  OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.OEmpID + "' and Flag_New='1' and Flag_Open='" + objPRReq.Flag_Open + "' and Flag_Hold='" + objPRReq.Flag_Hold + "' and Flag_Close='" + objPRReq.Flag_Close + "' order by ComplaintID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllET_Complaint_New_DB(PRReq objPRReq)
        {
            string s = "select distinct * from ET_tbl_EComplaint where  OID='" + objPRReq.OID + "'  and Flag_New='1' and Flag_Hold='" + objPRReq.Flag_Hold + "' and Flag_Close='" + objPRReq.Flag_Close + "' order by ComplaintID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllET_Complaint_IP_DB(PRReq objPRReq)
        {
            string s = "select distinct * from ET_tbl_EComplaint where  OID='" + objPRReq.OID + "' and Flag_New='1' and Flag_Open='1' and Flag_Hold='0' and Flag_Close='" + objPRReq.Flag_Close + "' order by ComplaintID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllET_Complaint_Hold_DB(PRReq objPRReq)
        {
            string s = "select distinct * from ET_tbl_EComplaint where  OID='" + objPRReq.OID + "'  and Flag_New='1' and Flag_Hold='1' and Flag_Close='" + objPRReq.Flag_Close + "' order by ComplaintID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllET_Complaint_Closed_DB(PRReq objPRReq)
        {
            string s = "select distinct * from ET_tbl_EComplaint where  OID='" + objPRReq.OID + "'  and Flag_New='1' and Flag_Close='1' order by ComplaintID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllET_Complaint_Closed_EmpID(PRReq objPRReq)
        {
            string s = "select distinct * from ET_tbl_EComplaint where  OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.OEmpID + "' and Flag_New='1' and Flag_Open='" + objPRReq.Flag_Open + "' and Flag_Close='" + objPRReq.Flag_Close + "' order by ComplaintID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getET_Complaints_ComplaintID(PRReq objPRReq)
        {
            string s = "select distinct * from ET_tbl_EComplaint where ComplaintID='" + objPRReq.ComplaintID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllET_Complaint_Resolve_Dashboard(PRReq objPRReq)
        {
            string s = "select distinct * from ET_tbl_EComplaint where  OID='" + objPRReq.OID + "' and PCID='" + objPRReq.PCID + "' and Flag_New='1'  and Flag_Hold='" + objPRReq.Flag_Hold + "' and Flag_Close='" + objPRReq.Flag_Close + "' order by ComplaintID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllET_Complaints_InProgress_Dashboard(PRReq objPRReq)
        {
            string s = "select distinct * from ET_tbl_EComplaint where  OID='" + objPRReq.OID + "' and PCID='" + objPRReq.PCID + "' and Flag_New='1' and Flag_Open='1' and Flag_Hold='" + objPRReq.Flag_Hold + "' and Flag_Close='" + objPRReq.Flag_Close + "' order by ComplaintID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllET_Complaints_Hold_Dashboard(PRReq objPRReq)
        {
            string s = "select distinct * from ET_tbl_EComplaint where  OID='" + objPRReq.OID + "' and PCID='" + objPRReq.PCID + "' and Flag_New='1'  and Flag_Hold='" + objPRReq.Flag_Hold + "' and Flag_Close='" + objPRReq.Flag_Close + "' order by ComplaintID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllET_Complaint_Closed_Dashboard(PRReq objPRReq)
        {
            string s = "select distinct * from ET_tbl_EComplaint where  OID='" + objPRReq.OID + "' and PCID='" + objPRReq.PCID + "' and Flag_New='1' and Flag_Close='" + objPRReq.Flag_Close + "' order by ComplaintID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp AssignEnggComplaint_User(PRReq objPRReq)
        {
            string update = "update ET_tbl_EComplaint set Flag_Open='1', AssignedUser='" + objPRReq.Name + "', AssignedMobile='" + objPRReq.OMobile + "', TargetedDate='" + objPRReq.ToDate + "', Priority='" + objPRReq.Priority + "' where ComplaintID='" + objPRReq.ComplaintID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp Update_EnggComplaint_User(PRReq objPRReq)
        {
            string update = "update ET_tbl_EComplaint set Flag_Hold='" + objPRReq.Flag_Hold + "', Flag_Close='" + objPRReq.Flag_Close + "', Status='" + objPRReq.Status + "',Dated='" + objPRReq.Dated + "' where ComplaintID='" + objPRReq.ComplaintID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        // Add Photos

        public PRResp AddETC_Images(PRReq objPRReq)
        {
            string insert = "insert into ET_tbl_ECImages (ComplaintID,Title,Image,Description,Status) values('" + objPRReq.ComplaintID + "','" + objPRReq.Title + "','" + objPRReq.Photo + "','" + objPRReq.Description + "','" + objPRReq.Status + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getETC_Images_ComplaintID(PRReq objPRReq)
        {
            string s = "select distinct * from ET_tbl_ECImages where ComplaintID='" + objPRReq.ComplaintID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }


        // EC History
        public PRResp AddETC_UserHistory(PRReq objPRReq)
        {
            string insert = "insert into ET_tbl_ECHistory (OID,ComplaintID,EmpID,Name,PCID,ProblemCategory,ProblemDescription,Dated,UEmpID,UName,Comment,Status,FileName) values('" + objPRReq.OID + "','" + objPRReq.ComplaintID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.PCID + "','" + objPRReq.ProblemCategory + "','" + objPRReq.ProblemDescription + "','" + objPRReq.Dated + "','" + objPRReq.UEmpID + "','" + objPRReq.UName + "','" + objPRReq.Comment + "','" + objPRReq.Status + "','" + objPRReq.FileName + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp AddETC_History(PRReq objPRReq)
        {
            string insert = "insert into ET_tbl_ECHistory (OID,ComplaintID,EmpID,Name,PCID,ProblemCategory,ProblemDescription,Dated,UEmpID,UName,Comment,Status,FileName) values('" + objPRReq.OID + "','" + objPRReq.ComplaintID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.PCID + "','" + objPRReq.ProblemCategory + "','" + objPRReq.ProblemDescription + "','" + objPRReq.Dated + "','" + objPRReq.UEmpID + "','" + objPRReq.UName + "','" + objPRReq.Comment + "','" + objPRReq.Status + "','" + objPRReq.FileName + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getETC_History_ComplaintID(PRReq objPRReq)
        {
            string s = "select * from ET_tbl_ECHistory where ComplaintID='" + objPRReq.ComplaintID + "' order by ECID Asc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getETC_AllHistory_ComplaintID(PRReq objPRReq)
        {
            string s = "select * from ET_tbl_ECHistory where ComplaintID='" + objPRReq.ComplaintID + "' and OID='" + objPRReq.OID + "' order by ECID Asc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp getETC_eTicket_UEmpID_ComplaintID(PRReq objPRReq)
        {
            string s = "select distinct * from ET_tbl_EComplaint where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and OEmpID='" + objPRReq.OEmpID + "' and ComplaintID='" + objPRReq.ComplaintID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getETC_eTicket_ComplaintID(PRReq objPRReq)
        {
            string s = "select distinct * from ET_tbl_EComplaint where OID='" + objPRReq.OID + "'  and ComplaintID='" + objPRReq.ComplaintID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getETC_eTicket_EmpID_ITID_Comment(PRReq objPRReq)
        {
            string s = "select * from ET_tbl_ECHistory where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "' and Comment='" + objPRReq.Comment + "'  and PCID='" + objPRReq.PCID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        // Health Centre
        public PRResp getFamilyDetails_EmpID(PRReq objPRReq)
        {
            string s = "select distinct * from hc_tbl_Patient where Status='" + objPRReq.Status + "' and (EmpID='" + objPRReq.CardNo + "' or CardNo='" + objPRReq.CardNo + "')";
            objPRResp.GetTable = HCConnections.GetTable(s);
            return objPRResp;
        }
        public PRResp getFamilyDetails_EmpID_Self(PRReq objPRReq)
        {
            string s = "select distinct * from hc_tbl_Patient where Status='" + objPRReq.Status + "' and Relation='Self' and (EmpID='" + objPRReq.CardNo + "' or CardNo='" + objPRReq.CardNo + "')";
            objPRResp.GetTable = HCConnections.GetTable(s);
            return objPRResp;
        }
        public PRResp getFamilyDetails_EmpID_NotSelf(PRReq objPRReq)
        {
            string s = "select distinct * from hc_tbl_Patient where Status='" + objPRReq.Status + "' and Relation!='Self' and (EmpID='" + objPRReq.CardNo + "' or CardNo='" + objPRReq.CardNo + "')";
            objPRResp.GetTable = HCConnections.GetTable(s);
            return objPRResp;
        }
        public PRResp getFamilyDetails_EmpID_PID(PRReq objPRReq)
        {
            string s = "select distinct * from hc_tbl_Patient where Status='" + objPRReq.Status + "' and PID='" + objPRReq.PID + "' and (EmpID='" + objPRReq.CardNo + "' or CardNo='" + objPRReq.CardNo + "')";
            objPRResp.GetTable = HCConnections.GetTable(s);
            return objPRResp;
        }
        public PRResp BlockFamilyMember_EmpID_PID(PRReq objPRReq)
        {
            string update = "update hc_tbl_Patient set Status='" + objPRReq.Status + "' where PID='" + objPRReq.PID + "' and (EmpID='" + objPRReq.CardNo + "' or CardNo='" + objPRReq.CardNo + "')";
            objPRResp.Count = HCConnections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp UpdateFamilyDetails_EmpID_PID(PRReq objPRReq)
        {
            string update = "update hc_tbl_Patient set PatientName='" + objPRReq.Name + "', Relation='" + objPRReq.Relation + "', Photo='" + objPRReq.Photo + "' where PID='" + objPRReq.PID + "' and (EmpID='" + objPRReq.CardNo + "' or CardNo='" + objPRReq.CardNo + "') and Status='" + objPRReq.Status + "'";
            objPRResp.Count = HCConnections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp UpdateFamilyDetails_EmpID_PID_HCard(PRReq objPRReq)
        {
            string update = "update hc_tbl_Patient set PatientName='" + objPRReq.Name + "', Relation='" + objPRReq.Relation + "', Photo='" + objPRReq.Photo + "', HealthCard='" + objPRReq.HealthCard + "' where PID='" + objPRReq.PID + "' and (EmpID='" + objPRReq.CardNo + "' or CardNo='" + objPRReq.CardNo + "') and Status='" + objPRReq.Status + "'";
            objPRResp.Count = HCConnections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp UpdateFamilyDetails_EmpID_HCard(PRReq objPRReq)
        {
            string update = "update hc_tbl_Patient set HealthCard='" + objPRReq.HealthCard + "' where (EmpID='" + objPRReq.CardNo + "' or CardNo='" + objPRReq.CardNo + "') and Status='" + objPRReq.Status + "'";
            objPRResp.Count = HCConnections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp getPatientDetails_PID(PRReq objPRReq)
        {
            string s = "select distinct * from hc_tbl_Patient where Status='" + objPRReq.Status + "' and PID='" + objPRReq.PID + "' and OID='" + objPRReq.OID + "'";
            objPRResp.GetTable = HCConnections.GetTable(s);
            return objPRResp;
        }
        public PRResp getHCFinYear(PRReq objPRReq)
        {
            string s = "select * from tbl_FinYear where Status='" + objPRReq.Status + "' order by FinYear Desc ";
            objPRResp.GetTable = HCConnections.GetTable(s);
            return objPRResp;
        }

        public PRResp getPatientInfo_byPID(PRReq objPRReq)
        {
            string s = "select * from hc_tbl_FinalMedDeliver where Status='" + objPRReq.Status + "' and FID='" + objPRReq.FYID + "' and PID='" + objPRReq.PID + "' order by VisitID Desc";
            objPRResp.GetTable = HCConnections.GetTable(s);
            return objPRResp;
        }

        public PRResp getPatient_Wise_MedUsageTotal(PRReq objPRReq)
        {
            string s = "select Sum(TotalAmount) as gtot from hc_tbl_FinalMedDeliver where Status='" + objPRReq.Status + "' and FID='" + objPRReq.FYID + "' and PID='" + objPRReq.PID + "' ";
            objPRResp.GetTable = HCConnections.GetTable(s);
            return objPRResp;
        }




        // Finance User Roles

        public PRResp AddFin_UserRole(PRReq objPRReq)
        {
            string s = "INSERT INTO Fin_tbl_UserRoles (OID,EmpID,Name,Role,RoleType,Status,Dated,UID,UName) values('" + objPRReq.OID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.Role + "','" + objPRReq.RoleType + "','" + objPRReq.Status + "','" + objPRReq.Dated + "','" + objPRReq.UID + "','" + objPRReq.UName + "')";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp getAllFinanceMappedRoles(PRReq objPRReq)
        {
            string s = "select * from Fin_tbl_UserRoles where OID='" + objPRReq.OID + "' order by RoleType Asc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp getFinanceMappedRoleName(PRReq objPRReq)
        {
            string s = "select * from Fin_tbl_UserRoles  where Role='" + objPRReq.Role + "' and OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp getFinanceMappedRole_EmpID(PRReq objPRReq)
        {
            string s = "select * from Fin_tbl_UserRoles where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getFinanceUser_Login(PRReq objPRReq)
        {
            string s = "select * from Fin_tbl_UserRoles where Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp Block_UnblockFinanceUser(PRReq objPRReq)
        {
            string update = "update Fin_tbl_UserRoles set  Status='" + objPRReq.Status + "' where OID='" + objPRReq.OID + "' and FUID='" + objPRReq.FUID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }

        public PRResp Block_UnBlockDefaultUser(PRReq objPRReq)
        {
            string update = "update tbl_App_DefaultUsers set  Status='" + objPRReq.Status + "' where OID='" + objPRReq.OID + "' and FUID='" + objPRReq.FUID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }


        // RACR

        public PRResp Add_EmpACRWorkFlow(PRReq objPRReq)
        {
            string insert = "INSERT INTO ACR_tbl_EmpWorkFlow(OID,DID,DeptID,EmpID,Name,DSID,Design,Email,Mobile,OfficerLevel,Action,OEmpID,OName,Status,UID,UName,Dated) values('" + objPRReq.OID + "','" + objPRReq.DID + "','" + objPRReq.DeptID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.DSID + "','" + objPRReq.Design + "','" + objPRReq.Email + "','" + objPRReq.Mobile + "','" + objPRReq.OfficerLevel + "','" + objPRReq.LAction + "','" + objPRReq.OEmpID + "','" + objPRReq.OEmpName + "','" + objPRReq.Status + "','" + objPRReq.UID + "','" + objPRReq.UName + "','" + objPRReq.Dated + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getEmpACRWorkFlow_EmpID_OEmpID_Level(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_EmpWorkFlow where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' and OfficerLevel='" + objPRReq.OfficerLevel + "' and Action='" + objPRReq.LAction + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpACRWorkFlow_EmpID_OEmpID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_EmpWorkFlow where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' and OEmpID='" + objPRReq.OEmpID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmp_Status_ACRWorkFlow_EmpID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_EmpWorkFlow where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and OEmpID='" + objPRReq.EmpID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpACRWorkFlow_EmpID__WFLevel(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_EmpWorkFlow where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' and OfficerLevel='" + objPRReq.OfficerLevel + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpACRWorkFlow_EmpID_AWID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_EmpWorkFlow where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and AWID='" + objPRReq.AWID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpACRWorkFlow_EmpID_OEmpID_Level_forUpdate(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_EmpWorkFlow where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and OEmpID='" + objPRReq.OEmpID + "' and OfficerLevel='" + objPRReq.OfficerLevel + "' order by EmpID Asc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAll_EmpACRWorkflows_EmpID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_EmpWorkFlow where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' order by OfficerLevel Asc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpACRWorkFlow_EmpID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_EmpWorkFlow where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp getEmpACRWorkFlow_EmpID_L1(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_EmpWorkFlow where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' and OfficerLevel='" + objPRReq.OfficerLevel + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpACRWorkFlow_EmpID_L2(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_EmpWorkFlow where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' and OfficerLevel='" + objPRReq.OfficerLevel + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpACRWorkFlow_EmpID_L3(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_EmpWorkFlow where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' and OfficerLevel='" + objPRReq.OfficerLevel + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmpACRWorkFlow_EmpID_OEmpID_OLevel(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_EmpWorkFlow where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' and OfficerLevel='" + objPRReq.OLevel + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp DelEmpACRWorkFlow_AWID(PRReq objPRReq)
        {
            string hod = "delete from ACR_tbl_EmpWorkFlow where  OID='" + objPRReq.OID + "' and AWID='" + objPRReq.AWID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }
        public PRResp UpdateEmpACRWorkFlow_EmpID_OEmpID_Level_AWID(PRReq objPRReq)
        {
            string update = "update ACR_tbl_EmpWorkFlow set DID='" + objPRReq.DID + "',DeptID='" + objPRReq.DeptID + "',DSID='" + objPRReq.DSID + "',Design='" + objPRReq.Design + "',Email='" + objPRReq.Email + "',Mobile='" + objPRReq.Mobile + "',OfficerLevel='" + objPRReq.OfficerLevel + "',Action='" + objPRReq.LAction + "',OEmpID='" + objPRReq.OEmpID + "',OName='" + objPRReq.OEmpName + "',UID='" + objPRReq.UserID + "', UName='" + objPRReq.UName + "',Dated='" + objPRReq.Dated + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and AWID='" + objPRReq.AWID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }

        public PRResp getAllEmpLeavesApplied_forACR_Count_EmpID(PRReq objPRReq)
        {
            string s = "select sum(" + objPRReq.ColumnName + ") as count from eL_tbl_RegStaff_eLeave_Applied where OID='" + objPRReq.OID + "' and Approval='1' and Reject='0' and LCancel='0' and EmpID='" + objPRReq.EmpID + "' and (SLeaveType='" + objPRReq.LeaveType + "' or CLeaveType='" + objPRReq.LeaveType + "') and (SLFromDate >= convert(datetime,'" + objPRReq.SLFromDate + "',105) and SLToDate<= convert(datetime,'" + objPRReq.SLToDate + "',105))";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllEmpToursAvailed_forACR_Count_EmpID(PRReq objPRReq)
        {
            string s = "select sum(" + objPRReq.ColumnName + ") as count from eT_tbl_RegStaff_eTour_Applied where OID='" + objPRReq.OID + "' and Approval='1' and Reject='0' and LCancel='0' and EmpID='" + objPRReq.EmpID + "' and TourType='" + objPRReq.TourType + "' and (FromDate >= convert(datetime,'" + objPRReq.SLFromDate + "',105) and ToDate<= convert(datetime,'" + objPRReq.SLToDate + "',105))";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllRACRs_ForSMSRemainder(PRReq objPRReq)
        {
            string s = "select distinct OEmpID from ACR_tbl_P1_PersonalData where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and Flag_Submit='1' and FinancialYear='" + objPRReq.FinancialYear + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp DelEmpACR_APDID(PRReq objPRReq)
        {
            string hod = "delete from ACR_tbl_P1_PersonalData where  OID='" + objPRReq.OID + "' and APDID='" + objPRReq.APDID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }
        public PRResp getACRSNo(PRReq objPRReq)
        {
            string s = "select max(" + objPRReq.ColumnName + ") from ACR_tbl_P1_PersonalData where OID='" + objPRReq.OID + "' ";
            objPRResp.SingleValue = Connections.GetSingleValue(s);
            return objPRResp;
        }
        public PRResp AddNewRACR(PRReq objPRReq)
        {
            string s = "INSERT INTO ACR_tbl_P1_PersonalData (SNO,ACRID,OID,FinancialYear,EGID,EmpID,Name,DID,DeptID,Design,HighestQualification,AreaOfSpecialisation,DOB,DOJ,BasicPay,PayLevelMatrix,APRSubmissionDate,Tour,EL,CML,HPL,CCL,PL,DL,EOL,Total,Status,Flag_Submit,Dated,OEmpID,OName) values('" + objPRReq.SNO + "','" + objPRReq.ACRID + "','" + objPRReq.OID + "','" + objPRReq.FinancialYear + "','" + objPRReq.EGID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.DID + "','" + objPRReq.DeptID + "','" + objPRReq.Design + "','" + objPRReq.HighestQualification + "','" + objPRReq.AreaOfSpecialisation + "','" + objPRReq.FromDate + "','" + objPRReq.ToDate + "','" + objPRReq.BasicPay + "','" + objPRReq.PayMatrixLevel + "','" + objPRReq.APRSubmissionDate + "','" + objPRReq.TourDays + "','" + objPRReq.EL + "','" + objPRReq.CML + "','" + objPRReq.HPL + "','" + objPRReq.CCL + "','" + objPRReq.PL + "','" + objPRReq.DL + "','" + objPRReq.EOL + "','" + objPRReq.TotalDays + "','" + objPRReq.Status + "','0','" + objPRReq.Dated + "','" + objPRReq.OEmpID + "','" + objPRReq.OName + "')";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp UpdateNewRACR_ACRID(PRReq objPRReq)
        {
            string update = "update ACR_tbl_P1_PersonalData set FinancialYear='" + objPRReq.FinancialYear + "',EGID='" + objPRReq.EGID + "',Name='" + objPRReq.Name + "',DID='" + objPRReq.DID + "',DeptID='" + objPRReq.DeptID + "',Design='" + objPRReq.Design + "',HighestQualification='" + objPRReq.HighestQualification + "',AreaOfSpecialisation='" + objPRReq.AreaOfSpecialisation + "',DOB='" + objPRReq.FromDate + "',DOJ='" + objPRReq.ToDate + "',BasicPay='" + objPRReq.BasicPay + "',PayLevelMatrix='" + objPRReq.PayMatrixLevel + "',APRSubmissionDate='" + objPRReq.APRSubmissionDate + "',Tour='" + objPRReq.TourDays + "',EL='" + objPRReq.EL + "',CML='" + objPRReq.CML + "',HPL='" + objPRReq.HPL + "',CCL='" + objPRReq.CCL + "',PL='" + objPRReq.PL + "',DL='" + objPRReq.DL + "',EOL='" + objPRReq.EOL + "',Total='" + objPRReq.TotalDays + "',Dated='" + objPRReq.Dated + "',OEmpID='" + objPRReq.OEmpID + "',OName='" + objPRReq.OName + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp getRACR_FinYear_EmpID(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P1_PersonalData where Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' and FinancialYear='" + objPRReq.FinancialYear + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllRACR_EmpID(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P1_PersonalData where Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' and OID='" + objPRReq.OID + "' and Flag_Submit='" + objPRReq.Flag_Submit + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllRACR_ACRID_History(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_History where ACRID='" + objPRReq.ACRID + "' and OID='" + objPRReq.OID + "' order by Dated Desc ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_History_Repeated_ACRID(PRReq objPRReq)
        {
            string s = "select distinct * from  ACR_tbl_History where OID='" + objPRReq.OID + "' and ACRID='" + objPRReq.ACRID + "' and Action='" + objPRReq.HAction + "' and OEmpID='" + objPRReq.EmpID + "' and Remarks='" + objPRReq.Remarks + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllRACR_ACRID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P1_PersonalData where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and OID='" + objPRReq.OID + "' order by ACRID Desc ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp FinalSubmit_ACRID(PRReq objPRReq)
        {
            string update = "update ACR_tbl_P1_PersonalData set Flag_RPTG_OFFICER='0',Flag_REVG_OFFICER='0',Flag_ACPT_OFFICER='0', CurrentStatus='" + objPRReq.CurrentStatus + "', Flag_Submit='" + objPRReq.Flag_Submit + "',Submit_Date='" + objPRReq.Dated + "',OfficerLevel='" + objPRReq.OfficerLevel + "', OEmpID='" + objPRReq.OEmpID + "',OName='" + objPRReq.OName + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp FinalSubmit_ACRID_RptOfficer(PRReq objPRReq)
        {
            string update = "update ACR_tbl_P1_PersonalData set CurrentStatus='" + objPRReq.CurrentStatus + "', Flag_RPTG_OFFICER='" + objPRReq.Flag_RPTG_OFFICER + "',RPTG_OFFICER_Dated='" + objPRReq.RPTG_OFFICER_Dated + "',OfficerLevel='" + objPRReq.OfficerLevel + "', OEmpID='" + objPRReq.OEmpID + "',OName='" + objPRReq.OName + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp FinalSubmit_ACRID_Reviewing_Officer(PRReq objPRReq)
        {
            string update = "update ACR_tbl_P1_PersonalData set CurrentStatus='" + objPRReq.CurrentStatus + "', Flag_REVG_OFFICER='" + objPRReq.Flag_REVG_OFFICER + "',REVG_OFFICER_Dated='" + objPRReq.REVG_OFFICER_Dated + "' ,OfficerLevel='" + objPRReq.OfficerLevel + "', OEmpID='" + objPRReq.OEmpID + "',OName='" + objPRReq.OName + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp FinalSubmit_ACRID_Accept_Officer(PRReq objPRReq)
        {
            string update = "update ACR_tbl_P1_PersonalData set CurrentStatus='" + objPRReq.CurrentStatus + "',Flag_ACPT_OFFICER='" + objPRReq.Flag_ACPT_OFFICER + "',ACPT_OFFICER_Dated='" + objPRReq.ACPT_OFFICER_Dated + "' ,OfficerLevel='" + objPRReq.OfficerLevel + "', OEmpID='" + objPRReq.OEmpID + "',OName='" + objPRReq.OName + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp getAllRACR_NotYetSubmitted(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P1_PersonalData where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and Flag_Submit='0' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllRACR_NotYetSubmitted_L1(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P1_PersonalData where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and Flag_Submit='1' and EmpID='" + objPRReq.EmpID + "' and (Flag_RPTG_OFFICER='0' or Flag_RPTG_OFFICER is NULL) and (Flag_REVG_OFFICER='0' or Flag_REVG_OFFICER is NULL) and (Flag_ACPT_OFFICER='0' or Flag_ACPT_OFFICER is NULL)";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllRACR_NotYetSubmitted_L2(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P1_PersonalData where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and Flag_Submit='1' and EmpID='" + objPRReq.EmpID + "' and Flag_RPTG_OFFICER='1'  and (Flag_REVG_OFFICER='0' or Flag_REVG_OFFICER is NULL) and (Flag_ACPT_OFFICER='0' or Flag_ACPT_OFFICER is NULL)";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllRACR_NotYetSubmitted_L3(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P1_PersonalData where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and Flag_Submit='1' and EmpID='" + objPRReq.EmpID + "' and Flag_RPTG_OFFICER='1'  and Flag_REVG_OFFICER='1' and (Flag_ACPT_OFFICER='0' or Flag_ACPT_OFFICER is NULL)";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllRACR_Rept_OEmpID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P1_PersonalData where Status='" + objPRReq.Status + "' and OEmpID='" + objPRReq.EmpID + "' and OID='" + objPRReq.OID + "' and Flag_Submit='" + objPRReq.Flag_Submit + "' and (Flag_RPTG_OFFICER!='1' or Flag_RPTG_OFFICER='' or Flag_RPTG_OFFICER is NULL) ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllRACR_Assessed_RPTO_OEmpID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P1_PersonalData where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ACRID='" + objPRReq.ACRID + "' order by FinancialYear,ACRID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllRACR_Assessed_As_Rept_OEmpID(PRReq objPRReq)
        {
            string s = "select distinct ACRID from ACR_tbl_P321_WorkOutPut where Status='" + objPRReq.Status + "' and OEmpID='" + objPRReq.EmpID + "' and OID='" + objPRReq.OID + "' and OfficerLevel='" + objPRReq.OLevel + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllRACR_Assessed_As_Revo_OEmpID(PRReq objPRReq)
        {
            string s = "select distinct ACRID from ACR_tbl_P441_Rev_Off_WorkOutPut where Status='" + objPRReq.Status + "' and OEmpID='" + objPRReq.EmpID + "' and OID='" + objPRReq.OID + "' and OfficerLevel='" + objPRReq.OLevel + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllRACR_Assessed_As_Acept_OEmpID(PRReq objPRReq)
        {
            string s = "select distinct ACRID from ACR_tbl_P54_FinalGrading where Status='" + objPRReq.Status + "' and OEmpID='" + objPRReq.EmpID + "' and OID='" + objPRReq.OID + "' and OfficerLevel='" + objPRReq.OLevel + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllRACR_Reviewing_OEmpID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P1_PersonalData where Status='" + objPRReq.Status + "' and OEmpID='" + objPRReq.EmpID + "' and OID='" + objPRReq.OID + "' and Flag_Submit='" + objPRReq.Flag_Submit + "' and Flag_RPTG_OFFICER='1' and ( Flag_REVG_OFFICER='' or Flag_REVG_OFFICER is NULL) ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllACRs_Accpting_OEmpID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P1_PersonalData where Status='" + objPRReq.Status + "' and OEmpID='" + objPRReq.EmpID + "' and OID='" + objPRReq.OID + "' and Flag_Submit='" + objPRReq.Flag_Submit + "' and Flag_RPTG_OFFICER='1' and Flag_REVG_OFFICER='1' and ( Flag_ACPT_OFFICER='' or Flag_ACPT_OFFICER is NULL) ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllRACR_Rept_ACRID_OEmpID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P1_PersonalData where Status='" + objPRReq.Status + "' and OEmpID='" + objPRReq.EmpID + "' and OID='" + objPRReq.OID + "' and ACRID='" + objPRReq.ACRID + "' and Flag_Submit='" + objPRReq.Flag_Submit + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllRACR_ReviewingOff_ACRID_OEmpID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P1_PersonalData where Status='" + objPRReq.Status + "' and OEmpID='" + objPRReq.EmpID + "' and OID='" + objPRReq.OID + "' and ACRID='" + objPRReq.ACRID + "' and Flag_Submit='" + objPRReq.Flag_Submit + "' and Flag_RPTG_OFFICER='" + objPRReq.Flag_RPTG_OFFICER + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        // 2.0 Self Appraisal Duties
        public PRResp AddSADuties(PRReq objPRReq)
        {
            string s = "INSERT INTO ACR_tbl_P21_SADuties (OID,FinancialYear,ACRID,EmpID,Name,Duties,Dated,Status) values('" + objPRReq.OID + "','" + objPRReq.FinancialYear + "','" + objPRReq.ACRID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.Duties + "','" + objPRReq.Dated + "','" + objPRReq.Status + "')";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp UpdateSADuties_ACRID(PRReq objPRReq)
        {
            string update = "update ACR_tbl_P21_SADuties set Duties='" + objPRReq.Duties + "',Dated='" + objPRReq.Dated + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and ADID='" + objPRReq.ADID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp getSADuties_EmpID(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P21_SADuties where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getSADuties_Name(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P21_SADuties where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and Duties='" + objPRReq.Duties + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllSADuties_EmpID_ACRID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P21_SADuties where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getSADuties_EmpID_ADID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P21_SADuties where Status='" + objPRReq.Status + "' and ADID='" + objPRReq.ADID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp DelSADuties_EmpID_ADID(PRReq objPRReq)
        {
            string hod = "delete from ACR_tbl_P21_SADuties where  OID='" + objPRReq.OID + "' and ADID='" + objPRReq.ADID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }

        // 2.1 Training Programmes / Events
        public PRResp AddTrainingProgrammes_Events(PRReq objPRReq)
        {
            string s = "INSERT INTO ACR_tbl_P221_TrainingProg_Events (OID,FinancialYear,ACRID,EmpID,Name,ITID,TrainingProgrammes_Events,Targeted,Achieved,Dated,Status) values('" + objPRReq.OID + "','" + objPRReq.FinancialYear + "','" + objPRReq.ACRID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.ITID + "','" + objPRReq.TrainingProgs_Events + "','" + objPRReq.Targeted + "','" + objPRReq.Achieved + "','" + objPRReq.Dated + "','" + objPRReq.Status + "')";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp UpdateTrainingProgrammes_Events_ITID_TPEID(PRReq objPRReq)
        {
            string update = "update ACR_tbl_P221_TrainingProg_Events set ITID='" + objPRReq.ITID + "',TrainingProgrammes_Events='" + objPRReq.TrainingProgs_Events + "',Targeted='" + objPRReq.Targeted + "',Achieved='" + objPRReq.Achieved + "',Dated='" + objPRReq.Dated + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and TPEID='" + objPRReq.TPEID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp getTrainingProgrammes_Events_EmpID(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P221_TrainingProg_Events where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllTrainingProgrammes_Events_ACRID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P221_TrainingProg_Events where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getTrainingProgrammes_Events_NameITID(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P221_TrainingProg_Events where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and ITID='" + objPRReq.ITID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getTrainingProgrammes_Events_TPEID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P221_TrainingProg_Events where Status='" + objPRReq.Status + "' and TPEID='" + objPRReq.TPEID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp DelTrainingProgrammes_Events_TPEID(PRReq objPRReq)
        {
            string hod = "delete from ACR_tbl_P221_TrainingProg_Events where  OID='" + objPRReq.OID + "' and TPEID='" + objPRReq.TPEID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }


        // 2.2.2 Research Taken Up
        public PRResp AddACR_tbl_P222_Research(PRReq objPRReq)
        {
            string s = "INSERT INTO ACR_tbl_P222_Research (OID,FinancialYear,ACRID,EmpID,Name,ITID,Research,Targeted,Achieved,Dated,Status) values('" + objPRReq.OID + "','" + objPRReq.FinancialYear + "','" + objPRReq.ACRID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.ITID + "','" + objPRReq.Research + "','" + objPRReq.Targeted + "','" + objPRReq.Achieved + "','" + objPRReq.Dated + "','" + objPRReq.Status + "')";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp UpdateACR_tbl_P222_Research_ITID_RID(PRReq objPRReq)
        {
            string update = "update ACR_tbl_P222_Research set ITID='" + objPRReq.ITID + "',Research='" + objPRReq.Research + "',Targeted='" + objPRReq.Targeted + "',Achieved='" + objPRReq.Achieved + "',Dated='" + objPRReq.Dated + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and RID='" + objPRReq.RID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp getACR_tbl_P222_Research_EmpID(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P222_Research where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllACR_tbl_P222_Research_ACRID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P222_Research where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P222_Research_NameITID(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P222_Research where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and ITID='" + objPRReq.ITID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P222_Research_RID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P222_Research where Status='" + objPRReq.Status + "' and RID='" + objPRReq.RID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp DelACR_tbl_P222_Research_RID(PRReq objPRReq)
        {
            string hod = "delete from ACR_tbl_P222_Research where  OID='" + objPRReq.OID + "' and RID='" + objPRReq.RID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }

        // 2.2.3 Research Papers Published
        public PRResp AddACR_tbl_P223_ResearchPapers(PRReq objPRReq)
        {
            string s = "INSERT INTO ACR_tbl_P223_ResearchPapers (OID,FinancialYear,ACRID,EmpID,Name,ITID,Research,Targeted,Achieved,Dated,Status) values('" + objPRReq.OID + "','" + objPRReq.FinancialYear + "','" + objPRReq.ACRID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.ITID + "','" + objPRReq.Research + "','" + objPRReq.Targeted + "','" + objPRReq.Achieved + "','" + objPRReq.Dated + "','" + objPRReq.Status + "')";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp UpdateACR_tbl_P223_ResearchPapers_ITID_RID(PRReq objPRReq)
        {
            string update = "update ACR_tbl_P223_ResearchPapers set ITID='" + objPRReq.ITID + "',Research='" + objPRReq.Research + "',Targeted='" + objPRReq.Targeted + "',Achieved='" + objPRReq.Achieved + "',Dated='" + objPRReq.Dated + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and RID='" + objPRReq.RID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp getACR_tbl_P223_ResearchPapers_EmpID(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P223_ResearchPapers where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllACR_tbl_P223_ResearchPapers_ACRID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P223_ResearchPapers where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P223_ResearchPapers_NameITID(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P223_ResearchPapers where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and ITID='" + objPRReq.ITID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P223_ResearchPapers_RID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P223_ResearchPapers where Status='" + objPRReq.Status + "' and RID='" + objPRReq.RID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp DelACR_tbl_P223_ResearchPapers_RID(PRReq objPRReq)
        {
            string hod = "delete from ACR_tbl_P223_ResearchPapers where  OID='" + objPRReq.OID + "' and RID='" + objPRReq.RID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }

        // 2.2.4 Policy Advocacy
        public PRResp AddACR_tbl_P224_PolicyAdvocacy(PRReq objPRReq)
        {
            string s = "INSERT INTO ACR_tbl_P224_PolicyAdvocacy (OID,FinancialYear,ACRID,EmpID,Name,ITID,Research,Targeted,Achieved,Dated,Status) values('" + objPRReq.OID + "','" + objPRReq.FinancialYear + "','" + objPRReq.ACRID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.ITID + "','" + objPRReq.Research + "','" + objPRReq.Targeted + "','" + objPRReq.Achieved + "','" + objPRReq.Dated + "','" + objPRReq.Status + "')";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp UpdateACR_tbl_P224_PolicyAdvocacy_ITID_RID(PRReq objPRReq)
        {
            string update = "update ACR_tbl_P224_PolicyAdvocacy set ITID='" + objPRReq.ITID + "',Research='" + objPRReq.Research + "',Targeted='" + objPRReq.Targeted + "',Achieved='" + objPRReq.Achieved + "',Dated='" + objPRReq.Dated + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and RID='" + objPRReq.RID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp getACR_tbl_P224_PolicyAdvocacy_EmpID(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P224_PolicyAdvocacy where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllACR_tbl_P224_PolicyAdvocacy_ACRID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P224_PolicyAdvocacy where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P224_PolicyAdvocacy_NameITID(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P224_PolicyAdvocacy where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and ITID='" + objPRReq.ITID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P224_PolicyAdvocacy_RID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P224_PolicyAdvocacy where Status='" + objPRReq.Status + "' and RID='" + objPRReq.RID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp DelACR_tbl_P224_PolicyAdvocacy_RID(PRReq objPRReq)
        {
            string hod = "delete from ACR_tbl_P224_PolicyAdvocacy where  OID='" + objPRReq.OID + "' and RID='" + objPRReq.RID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }


        // 2.2.5 Working Papers
        public PRResp AddACR_tbl_P225_WorkingPapers(PRReq objPRReq)
        {
            string s = "INSERT INTO ACR_tbl_P225_WorkingPapers (OID,FinancialYear,ACRID,EmpID,Name,ITID,Research,Targeted,Achieved,Dated,Status) values('" + objPRReq.OID + "','" + objPRReq.FinancialYear + "','" + objPRReq.ACRID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.ITID + "','" + objPRReq.Research + "','" + objPRReq.Targeted + "','" + objPRReq.Achieved + "','" + objPRReq.Dated + "','" + objPRReq.Status + "')";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp UpdateACR_tbl_P225_WorkingPapers_ITID_RID(PRReq objPRReq)
        {
            string update = "update ACR_tbl_P225_WorkingPapers set ITID='" + objPRReq.ITID + "',Research='" + objPRReq.Research + "',Targeted='" + objPRReq.Targeted + "',Achieved='" + objPRReq.Achieved + "',Dated='" + objPRReq.Dated + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and RID='" + objPRReq.RID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp getACR_tbl_P225_WorkingPapers_EmpID(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P225_WorkingPapers where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllACR_tbl_P225_WorkingPapers_ACRID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P225_WorkingPapers where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P225_WorkingPapers_NameITID(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P225_WorkingPapers where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and ITID='" + objPRReq.ITID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P225_WorkingPapers_RID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P225_WorkingPapers where Status='" + objPRReq.Status + "' and RID='" + objPRReq.RID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp DelACR_tbl_P225_WorkingPapers_RID(PRReq objPRReq)
        {
            string hod = "delete from ACR_tbl_P225_WorkingPapers where  OID='" + objPRReq.OID + "' and RID='" + objPRReq.RID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }


        // 2.2.6 Books/Chapters Authored
        public PRResp AddACR_tbl_P226_Books_Chapters(PRReq objPRReq)
        {
            string s = "INSERT INTO ACR_tbl_P226_Books_Chapters (OID,FinancialYear,ACRID,EmpID,Name,ITID,Research,Targeted,Achieved,Dated,Status) values('" + objPRReq.OID + "','" + objPRReq.FinancialYear + "','" + objPRReq.ACRID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.ITID + "','" + objPRReq.Research + "','" + objPRReq.Targeted + "','" + objPRReq.Achieved + "','" + objPRReq.Dated + "','" + objPRReq.Status + "')";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp UpdateACR_tbl_P226_Books_Chapters_ITID_RID(PRReq objPRReq)
        {
            string update = "update ACR_tbl_P226_Books_Chapters set ITID='" + objPRReq.ITID + "',Research='" + objPRReq.Research + "',Targeted='" + objPRReq.Targeted + "',Achieved='" + objPRReq.Achieved + "',Dated='" + objPRReq.Dated + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and RID='" + objPRReq.RID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp getACR_tbl_P226_Books_Chapters_EmpID(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P226_Books_Chapters where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllACR_tbl_P226_Books_Chapters_ACRID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P226_Books_Chapters where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P226_Books_Chapters_NameITID(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P226_Books_Chapters where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and ITID='" + objPRReq.ITID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P226_Books_Chapters_RID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P226_Books_Chapters where Status='" + objPRReq.Status + "' and RID='" + objPRReq.RID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp DelACR_tbl_P226_Books_Chapters_RID(PRReq objPRReq)
        {
            string hod = "delete from ACR_tbl_P226_Books_Chapters where  OID='" + objPRReq.OID + "' and RID='" + objPRReq.RID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }


        // 2.2.7 Seminars/conference/Workshops Attended
        public PRResp AddACR_tbl_P227_Seminars_Confs_Workshops(PRReq objPRReq)
        {
            string s = "INSERT INTO ACR_tbl_P227_Seminars_Confs_Workshops (OID,FinancialYear,ACRID,EmpID,Name,ITID,Research,Targeted,Achieved,Dated,Status) values('" + objPRReq.OID + "','" + objPRReq.FinancialYear + "','" + objPRReq.ACRID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.ITID + "','" + objPRReq.Research + "','" + objPRReq.Targeted + "','" + objPRReq.Achieved + "','" + objPRReq.Dated + "','" + objPRReq.Status + "')";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp UpdateACR_tbl_P227_Seminars_Confs_Workshops_ITID_RID(PRReq objPRReq)
        {
            string update = "update ACR_tbl_P227_Seminars_Confs_Workshops set ITID='" + objPRReq.ITID + "',Research='" + objPRReq.Research + "',Targeted='" + objPRReq.Targeted + "',Achieved='" + objPRReq.Achieved + "',Dated='" + objPRReq.Dated + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and RID='" + objPRReq.RID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp getACR_tbl_P227_Seminars_Confs_Workshops_EmpID(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P227_Seminars_Confs_Workshops where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllACR_tbl_P227_Seminars_Confs_Workshops_ACRID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P227_Seminars_Confs_Workshops where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P227_Seminars_Confs_Workshops_NameITID(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P227_Seminars_Confs_Workshops where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and ITID='" + objPRReq.ITID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P227_Seminars_Confs_Workshops_RID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P227_Seminars_Confs_Workshops where Status='" + objPRReq.Status + "' and RID='" + objPRReq.RID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp DelACR_tbl_P227_Seminars_Confs_Workshops_RID(PRReq objPRReq)
        {
            string hod = "delete from ACR_tbl_P227_Seminars_Confs_Workshops where  OID='" + objPRReq.OID + "' and RID='" + objPRReq.RID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }

        // 2.2.8 Reviews/Abstraction
        public PRResp AddACR_tbl_P228_Reviews_Abstraction(PRReq objPRReq)
        {
            string s = "INSERT INTO ACR_tbl_P228_Reviews_Abstraction (OID,FinancialYear,ACRID,EmpID,Name,ITID,Research,Targeted,Achieved,Dated,Status) values('" + objPRReq.OID + "','" + objPRReq.FinancialYear + "','" + objPRReq.ACRID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.ITID + "','" + objPRReq.Research + "','" + objPRReq.Targeted + "','" + objPRReq.Achieved + "','" + objPRReq.Dated + "','" + objPRReq.Status + "')";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp UpdateACR_tbl_P228_Reviews_Abstraction_ITID_RID(PRReq objPRReq)
        {
            string update = "update ACR_tbl_P228_Reviews_Abstraction set ITID='" + objPRReq.ITID + "',Research='" + objPRReq.Research + "',Targeted='" + objPRReq.Targeted + "',Achieved='" + objPRReq.Achieved + "',Dated='" + objPRReq.Dated + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and RID='" + objPRReq.RID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp getACR_tbl_P228_Reviews_Abstraction_EmpID(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P228_Reviews_Abstraction where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllACR_tbl_P228_Reviews_Abstraction_ACRID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P228_Reviews_Abstraction where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P228_Reviews_Abstraction_NameITID(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P228_Reviews_Abstraction where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and ITID='" + objPRReq.ITID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P228_Reviews_Abstraction_RID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P228_Reviews_Abstraction where Status='" + objPRReq.Status + "' and RID='" + objPRReq.RID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp DelACR_tbl_P228_Reviews_Abstraction_RID(PRReq objPRReq)
        {
            string hod = "delete from ACR_tbl_P228_Reviews_Abstraction where  OID='" + objPRReq.OID + "' and RID='" + objPRReq.RID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }

        // 2.2.9 Guidance
        public PRResp AddACR_tbl_P229_Guidance(PRReq objPRReq)
        {
            string s = "INSERT INTO ACR_tbl_P229_Guidance (OID,FinancialYear,ACRID,EmpID,Name,ITID,Research,Targeted,Achieved,Dated,Status) values('" + objPRReq.OID + "','" + objPRReq.FinancialYear + "','" + objPRReq.ACRID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.ITID + "','" + objPRReq.Research + "','" + objPRReq.Targeted + "','" + objPRReq.Achieved + "','" + objPRReq.Dated + "','" + objPRReq.Status + "')";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp UpdateACR_tbl_P229_Guidance_ITID_RID(PRReq objPRReq)
        {
            string update = "update ACR_tbl_P229_Guidance set ITID='" + objPRReq.ITID + "',Research='" + objPRReq.Research + "',Targeted='" + objPRReq.Targeted + "',Achieved='" + objPRReq.Achieved + "',Dated='" + objPRReq.Dated + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and RID='" + objPRReq.RID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp getACR_tbl_P229_Guidance_EmpID(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P229_Guidance where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllACR_tbl_P229_Guidance_ACRID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P229_Guidance where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P229_Guidance_NameITID(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P229_Guidance where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and ITID='" + objPRReq.ITID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P229_Guidance_RID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P229_Guidance where Status='" + objPRReq.Status + "' and RID='" + objPRReq.RID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp DelACR_tbl_P229_Guidance_RID(PRReq objPRReq)
        {
            string hod = "delete from ACR_tbl_P229_Guidance where  OID='" + objPRReq.OID + "' and RID='" + objPRReq.RID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }

        // 2.2.10 Specialization
        public PRResp AddACR_tbl_P2210_Specialization(PRReq objPRReq)
        {
            string s = "INSERT INTO ACR_tbl_P2210_Specialization (OID,FinancialYear,ACRID,EmpID,Name,ITID,Research,Targeted,Achieved,Dated,Status) values('" + objPRReq.OID + "','" + objPRReq.FinancialYear + "','" + objPRReq.ACRID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.ITID + "','" + objPRReq.Research + "','" + objPRReq.Targeted + "','" + objPRReq.Achieved + "','" + objPRReq.Dated + "','" + objPRReq.Status + "')";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp UpdateACR_tbl_P2210_Specialization_ITID_RID(PRReq objPRReq)
        {
            string update = "update ACR_tbl_P2210_Specialization set ITID='" + objPRReq.ITID + "',Research='" + objPRReq.Research + "',Targeted='" + objPRReq.Targeted + "',Achieved='" + objPRReq.Achieved + "',Dated='" + objPRReq.Dated + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and RID='" + objPRReq.RID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp getACR_tbl_P2210_Specialization_EmpID(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P2210_Specialization where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllACR_tbl_P2210_Specialization_ACRID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P2210_Specialization where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P2210_Specialization_NameITID(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P2210_Specialization where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and ITID='" + objPRReq.ITID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P2210_Specialization_RID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P2210_Specialization where Status='" + objPRReq.Status + "' and RID='" + objPRReq.RID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp DelACR_tbl_P2210_Specialization_RID(PRReq objPRReq)
        {
            string hod = "delete from ACR_tbl_P2210_Specialization where  OID='" + objPRReq.OID + "' and RID='" + objPRReq.RID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }

        // 2.2.11 Any Other Item
        public PRResp AddACR_tbl_P2211_AnyOther(PRReq objPRReq)
        {
            string s = "INSERT INTO ACR_tbl_P2211_AnyOther (OID,FinancialYear,ACRID,EmpID,Name,ItemName,Targeted,Achieved,Dated,Status) values('" + objPRReq.OID + "','" + objPRReq.FinancialYear + "','" + objPRReq.ACRID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.ItemName + "','" + objPRReq.Targeted + "','" + objPRReq.Achieved + "','" + objPRReq.Dated + "','" + objPRReq.Status + "')";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp UpdateACR_tbl_P2211_AnyOther_ITID(PRReq objPRReq)
        {
            string update = "update ACR_tbl_P2211_AnyOther set ItemName='" + objPRReq.ItemName + "',Targeted='" + objPRReq.Targeted + "',Achieved='" + objPRReq.Achieved + "',Dated='" + objPRReq.Dated + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and ITID='" + objPRReq.ITID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp getACR_tbl_P2211_AnyOther_EmpID(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P2211_AnyOther where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllACR_tbl_P2211_AnyOther_ACRID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P2211_AnyOther where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P2211_AnyOther_NameITID(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P2211_AnyOther where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and ItemName='" + objPRReq.ItemName + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P2211_AnyOther_ITID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P2211_AnyOther where Status='" + objPRReq.Status + "' and ITID='" + objPRReq.ITID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp DelACR_tbl_P2211_AnyOther_ITID(PRReq objPRReq)
        {
            string hod = "delete from ACR_tbl_P2211_AnyOther where  OID='" + objPRReq.OID + "' and ITID='" + objPRReq.ITID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }


        // 2.3.1.1A Training Programmes
        public PRResp AddACR_tbl_P2311A_TrainingProgs(PRReq objPRReq)
        {
            string s = "INSERT INTO ACR_tbl_P2311A_TrainingProgs (OID,FinancialYear,ACRID,EmpID,Name,Title,ITID,ItemName,Duration,NoofSessions,Rating,Dated,Status) values('" + objPRReq.OID + "','" + objPRReq.FinancialYear + "','" + objPRReq.ACRID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.Title + "','" + objPRReq.ITID + "','" + objPRReq.ItemName + "','" + objPRReq.Duration + "','" + objPRReq.NoofSessions + "','" + objPRReq.Rating + "','" + objPRReq.Dated + "','" + objPRReq.Status + "')";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp UpdateACR_tbl_P2311A_TrainingProgs_TPID(PRReq objPRReq)
        {
            string update = "update ACR_tbl_P2311A_TrainingProgs set Title='" + objPRReq.Title + "',ITID='" + objPRReq.ITID + "', ItemName='" + objPRReq.ItemName + "',Duration='" + objPRReq.Duration + "',NoofSessions='" + objPRReq.NoofSessions + "', Rating='" + objPRReq.Rating + "', Dated='" + objPRReq.Dated + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and TPID='" + objPRReq.TPID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp getACR_tbl_P2311A_TrainingProgs_EmpID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P2311A_TrainingProgs where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' order by ITID ASC ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllACR_tbl_P2311A_TrainingProgs_EmpID_ITID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P2311A_TrainingProgs where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and ITID='" + objPRReq.ITID + "' order by ITID ASC ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P2311A_TrainingProgs_EmpID_ITID(PRReq objPRReq)
        {
            string s = "select distinct ITID,ItemName from ACR_tbl_P2311A_TrainingProgs where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' order by ITID ASC ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllACR_tbl_P2311A_TrainingProgs_ACRID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P2311A_TrainingProgs where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' order by ITID ASC ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P2311A_TrainingProgs_NameITID(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P2311A_TrainingProgs where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and ITID='" + objPRReq.ITID + "' and Title='" + objPRReq.Title + "' and Duration='" + objPRReq.Duration + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P2311A_TrainingProgs_TPID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P2311A_TrainingProgs where Status='" + objPRReq.Status + "' and TPID='" + objPRReq.TPID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp DelACR_tbl_P2311A_TrainingProgs_TPID(PRReq objPRReq)
        {
            string hod = "delete from ACR_tbl_P2311A_TrainingProgs where  OID='" + objPRReq.OID + "' and TPID='" + objPRReq.TPID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }

        // 2.3.1.1B PG Courses
        public PRResp AddACR_tbl_P2311B_PGCourses(PRReq objPRReq)
        {
            string s = "INSERT INTO ACR_tbl_P2311B_PGCourses (OID,FinancialYear,ACRID,EmpID,Name,Title,ITID,ItemName,Duration,NoofSessions,Rating,Dated,Status) values('" + objPRReq.OID + "','" + objPRReq.FinancialYear + "','" + objPRReq.ACRID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.Title + "','" + objPRReq.ITID + "','" + objPRReq.ItemName + "','" + objPRReq.Duration + "','" + objPRReq.NoofSessions + "','" + objPRReq.Rating + "','" + objPRReq.Dated + "','" + objPRReq.Status + "')";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp UpdateACR_tbl_P2311B_PGCourses_TPID(PRReq objPRReq)
        {
            string update = "update ACR_tbl_P2311B_PGCourses set Title='" + objPRReq.Title + "',ITID='" + objPRReq.ITID + "', ItemName='" + objPRReq.ItemName + "',Duration='" + objPRReq.Duration + "',NoofSessions='" + objPRReq.NoofSessions + "', Rating='" + objPRReq.Rating + "', Dated='" + objPRReq.Dated + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and TPID='" + objPRReq.TPID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp getACR_tbl_P2311B_PGCourses_EmpID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P2311B_PGCourses where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' order by ITID ASC ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllACR_tbl_P2311B_PGCourses_EmpID_ITID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P2311B_PGCourses where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and ITID='" + objPRReq.ITID + "' order by ITID ASC ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P2311B_PGCourses_EmpID_ITID(PRReq objPRReq)
        {
            string s = "select distinct ITID,ItemName from ACR_tbl_P2311B_PGCourses where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' order by ITID ASC ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllACR_tbl_P2311B_PGCourses_ACRID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P2311B_PGCourses where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' order by ITID ASC ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P2311B_PGCourses_NameITID(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P2311B_PGCourses where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and ITID='" + objPRReq.ITID + "' and Title='" + objPRReq.Title + "' and Duration='" + objPRReq.Duration + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P2311B_PGCourses_TPID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P2311B_PGCourses where Status='" + objPRReq.Status + "' and TPID='" + objPRReq.TPID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp DelACR_tbl_P2311B_PGCourses_TPID(PRReq objPRReq)
        {
            string hod = "delete from ACR_tbl_P2311B_PGCourses where  OID='" + objPRReq.OID + "' and TPID='" + objPRReq.TPID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }

        // 2.3.1.2A Workshops
        public PRResp AddACR_tbl_P2312A_Workshops(PRReq objPRReq)
        {
            string s = "INSERT INTO ACR_tbl_P2312A_Workshops (OID,FinancialYear,ACRID,EmpID,Name,Title,ITID,ItemName,Duration,NoofSessions,Rating,Dated,Status) values('" + objPRReq.OID + "','" + objPRReq.FinancialYear + "','" + objPRReq.ACRID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.Title + "','" + objPRReq.ITID + "','" + objPRReq.ItemName + "','" + objPRReq.Duration + "','" + objPRReq.NoofSessions + "','" + objPRReq.Rating + "','" + objPRReq.Dated + "','" + objPRReq.Status + "')";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp UpdateACR_tbl_P2312A_Workshops_TPID(PRReq objPRReq)
        {
            string update = "update ACR_tbl_P2312A_Workshops set Title='" + objPRReq.Title + "',ITID='" + objPRReq.ITID + "', ItemName='" + objPRReq.ItemName + "',Duration='" + objPRReq.Duration + "',NoofSessions='" + objPRReq.NoofSessions + "', Rating='" + objPRReq.Rating + "', Dated='" + objPRReq.Dated + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and TPID='" + objPRReq.TPID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp getACR_tbl_P2312A_Workshops_EmpID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P2312A_Workshops where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' order by ITID ASC ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllACR_tbl_P2312A_Workshops_EmpID_ITID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P2312A_Workshops where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and ITID='" + objPRReq.ITID + "' order by ITID ASC ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P2312A_Workshops_EmpID_ITID(PRReq objPRReq)
        {
            string s = "select distinct ITID,ItemName from ACR_tbl_P2312A_Workshops where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' order by ITID ASC ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllACR_tbl_P2312A_Workshops_ACRID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P2312A_Workshops where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' order by ITID ASC ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P2312A_Workshops_NameITID(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P2312A_Workshops where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and ITID='" + objPRReq.ITID + "' and Title='" + objPRReq.Title + "' and Duration='" + objPRReq.Duration + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P2312A_Workshops_TPID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P2312A_Workshops where Status='" + objPRReq.Status + "' and TPID='" + objPRReq.TPID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp DelACR_tbl_P2312A_Workshops_TPID(PRReq objPRReq)
        {
            string hod = "delete from ACR_tbl_P2312A_Workshops where  OID='" + objPRReq.OID + "' and TPID='" + objPRReq.TPID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }


        // 2.3.1.2B Seminars
        public PRResp AddACR_tbl_P2312B_Seminars(PRReq objPRReq)
        {
            string s = "INSERT INTO ACR_tbl_P2312B_Seminars (OID,FinancialYear,ACRID,EmpID,Name,Title,ITID,ItemName,Duration,NoofSessions,Rating,Dated,Status) values('" + objPRReq.OID + "','" + objPRReq.FinancialYear + "','" + objPRReq.ACRID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.Title + "','" + objPRReq.ITID + "','" + objPRReq.ItemName + "','" + objPRReq.Duration + "','" + objPRReq.NoofSessions + "','" + objPRReq.Rating + "','" + objPRReq.Dated + "','" + objPRReq.Status + "')";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp UpdateACR_tbl_P2312B_Seminars_TPID(PRReq objPRReq)
        {
            string update = "update ACR_tbl_P2312B_Seminars set Title='" + objPRReq.Title + "',ITID='" + objPRReq.ITID + "', ItemName='" + objPRReq.ItemName + "',Duration='" + objPRReq.Duration + "',NoofSessions='" + objPRReq.NoofSessions + "', Rating='" + objPRReq.Rating + "', Dated='" + objPRReq.Dated + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and TPID='" + objPRReq.TPID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp getACR_tbl_P2312B_Seminars_EmpID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P2312B_Seminars where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' order by ITID ASC ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllACR_tbl_P2312B_Seminars_EmpID_ITID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P2312B_Seminars where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and ITID='" + objPRReq.ITID + "' order by ITID ASC ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P2312B_Seminars_EmpID_ITID(PRReq objPRReq)
        {
            string s = "select distinct ITID,ItemName from ACR_tbl_P2312B_Seminars where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' order by ITID ASC ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllACR_tbl_P2312B_Seminars_ACRID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P2312B_Seminars where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' order by ITID ASC ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P2312B_Seminars_NameITID(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P2312B_Seminars where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and ITID='" + objPRReq.ITID + "' and Title='" + objPRReq.Title + "' and Duration='" + objPRReq.Duration + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P2312B_Seminars_TPID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P2312B_Seminars where Status='" + objPRReq.Status + "' and TPID='" + objPRReq.TPID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp DelACR_tbl_P2312B_Seminars_TPID(PRReq objPRReq)
        {
            string hod = "delete from ACR_tbl_P2312B_Seminars where  OID='" + objPRReq.OID + "' and TPID='" + objPRReq.TPID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }

        // 2.3.1.3 New Training Programmes/Course
        public PRResp AddACR_tbl_P2313_NewTPC(PRReq objPRReq)
        {
            string s = "INSERT INTO ACR_tbl_P2313_NewTPC (OID,FinancialYear,ACRID,EmpID,Name,Title,ITID,ItemName,Duration,Clientele,Dated,Status) values('" + objPRReq.OID + "','" + objPRReq.FinancialYear + "','" + objPRReq.ACRID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.Title + "','" + objPRReq.ITID + "','" + objPRReq.ItemName + "','" + objPRReq.Duration + "','" + objPRReq.ProgClientele + "','" + objPRReq.Dated + "','" + objPRReq.Status + "')";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp UpdateACR_tbl_P2313_NewTPC_TPID(PRReq objPRReq)
        {
            string update = "update ACR_tbl_P2313_NewTPC set Title='" + objPRReq.Title + "',ITID='" + objPRReq.ITID + "', ItemName='" + objPRReq.ItemName + "',Duration='" + objPRReq.Duration + "',Clientele='" + objPRReq.ProgClientele + "', Dated='" + objPRReq.Dated + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and TPID='" + objPRReq.TPID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp getACR_tbl_P2313_NewTPC_EmpID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P2313_NewTPC where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' order by ITID ASC ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllACR_tbl_P2313_NewTPC_EmpID_ITID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P2313_NewTPC where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and ITID='" + objPRReq.ITID + "' order by ITID ASC ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P2313_NewTPC_EmpID_ITID(PRReq objPRReq)
        {
            string s = "select distinct ITID,ItemName from ACR_tbl_P2313_NewTPC where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' order by ITID ASC ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllACR_tbl_P2313_NewTPC_ACRID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P2313_NewTPC where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' order by ITID ASC ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P2313_NewTPC_NameITID(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P2313_NewTPC where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and ITID='" + objPRReq.ITID + "' and Title='" + objPRReq.Title + "' and Duration='" + objPRReq.Duration + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P2313_NewTPC_TPID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P2313_NewTPC where Status='" + objPRReq.Status + "' and TPID='" + objPRReq.TPID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp DelACR_tbl_P2313_NewTPC_TPID(PRReq objPRReq)
        {
            string hod = "delete from ACR_tbl_P2313_NewTPC where  OID='" + objPRReq.OID + "' and TPID='" + objPRReq.TPID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }

        // 2.3.1.4 New Course Material / Modules
        public PRResp AddACR_tbl_P2314_NewCMM(PRReq objPRReq)
        {
            string s = "INSERT INTO ACR_tbl_P2314_NewCMM (OID,FinancialYear,ACRID,EmpID,Name,Title,ITID,ItemName,Duration,Clientele,Dated,Status) values('" + objPRReq.OID + "','" + objPRReq.FinancialYear + "','" + objPRReq.ACRID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.Title + "','" + objPRReq.ITID + "','" + objPRReq.ItemName + "','" + objPRReq.Duration + "','" + objPRReq.ProgClientele + "','" + objPRReq.Dated + "','" + objPRReq.Status + "')";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp UpdateACR_tbl_P2314_NewCMM_TPID(PRReq objPRReq)
        {
            string update = "update ACR_tbl_P2314_NewCMM set Title='" + objPRReq.Title + "',ITID='" + objPRReq.ITID + "', ItemName='" + objPRReq.ItemName + "',Duration='" + objPRReq.Duration + "',Clientele='" + objPRReq.ProgClientele + "', Dated='" + objPRReq.Dated + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and TPID='" + objPRReq.TPID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp getACR_tbl_P2314_NewCMM_EmpID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P2314_NewCMM where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' order by ITID ASC ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllACR_tbl_P2314_NewCMM_EmpID_ITID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P2314_NewCMM where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and ITID='" + objPRReq.ITID + "' order by ITID ASC ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P2314_NewCMM_EmpID_ITID(PRReq objPRReq)
        {
            string s = "select distinct ITID,ItemName from ACR_tbl_P2314_NewCMM where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' order by ITID ASC ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllACR_tbl_P2314_NewCMM_ACRID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P2314_NewCMM where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' order by ITID ASC ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P2314_NewCMM_NameITID(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P2314_NewCMM where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and ITID='" + objPRReq.ITID + "' and Title='" + objPRReq.Title + "' and Duration='" + objPRReq.Duration + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P2314_NewCMM_TPID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P2314_NewCMM where Status='" + objPRReq.Status + "' and TPID='" + objPRReq.TPID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp DelACR_tbl_P2314_NewCMM_TPID(PRReq objPRReq)
        {
            string hod = "delete from ACR_tbl_P2314_NewCMM where  OID='" + objPRReq.OID + "' and TPID='" + objPRReq.TPID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }

        // 2.3.2 Details of NIRD Research
        public PRResp AddACR_tbl_P232_NIRDResearch(PRReq objPRReq)
        {
            string s = "INSERT INTO ACR_tbl_P232_NIRDResearch (OID,FinancialYear,ACRID,EmpID,Name,Title,ITID,ItemName,DateofInitiation,CompletionStatus,DateofCompletion,JournalStatus,Remarks,Dated,Status) values('" + objPRReq.OID + "','" + objPRReq.FinancialYear + "','" + objPRReq.ACRID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.Title + "','" + objPRReq.ITID + "','" + objPRReq.ItemName + "','" + objPRReq.DateofInitiation + "','" + objPRReq.CompletionStatus + "','" + objPRReq.DateofCompletion + "','" + objPRReq.JournalStatus + "','" + objPRReq.Remarks + "','" + objPRReq.Dated + "','" + objPRReq.Status + "')";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp UpdateACR_tbl_P232_NIRDResearch_RPID(PRReq objPRReq)
        {
            string update = "update ACR_tbl_P232_NIRDResearch set Title='" + objPRReq.Title + "',ITID='" + objPRReq.ITID + "', ItemName='" + objPRReq.ItemName + "',DateofInitiation='" + objPRReq.DateofInitiation + "',CompletionStatus='" + objPRReq.CompletionStatus + "',DateofCompletion='" + objPRReq.DateofCompletion + "',JournalStatus='" + objPRReq.JournalStatus + "',Remarks='" + objPRReq.Remarks + "', Dated='" + objPRReq.Dated + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and RPID='" + objPRReq.RPID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp getACR_tbl_P232_NIRDResearch_EmpID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P232_NIRDResearch where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' order by ITID ASC ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllACR_tbl_P232_NIRDResearch_EmpID_ITID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P232_NIRDResearch where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and ITID='" + objPRReq.ITID + "' order by ITID ASC ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P232_NIRDResearch_EmpID_ITID(PRReq objPRReq)
        {
            string s = "select distinct ITID,ItemName from ACR_tbl_P232_NIRDResearch where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' order by ITID ASC ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllACR_tbl_P232_NIRDResearch_ACRID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P232_NIRDResearch where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' order by ITID ASC ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P232_NIRDResearch_NameITID(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P232_NIRDResearch where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and ITID='" + objPRReq.ITID + "' and Title='" + objPRReq.Title + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P232_NIRDResearch_RPID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P232_NIRDResearch where Status='" + objPRReq.Status + "' and RPID='" + objPRReq.RPID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp DelACR_tbl_P232_NIRDResearch_RPID(PRReq objPRReq)
        {
            string hod = "delete from ACR_tbl_P232_NIRDResearch where  OID='" + objPRReq.OID + "' and RPID='" + objPRReq.RPID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }


        // 2.3.2B Details of Consultancy Research
        public PRResp AddACR_tbl_P232B_ConsultancyResearch(PRReq objPRReq)
        {
            string s = "INSERT INTO ACR_tbl_P232B_ConsultancyResearch (OID,FinancialYear,ACRID,EmpID,Name,Title,ITID,ItemName,DateofInitiation,CompletionStatus,DateofCompletion,JournalStatus,Remarks,Dated,Status) values('" + objPRReq.OID + "','" + objPRReq.FinancialYear + "','" + objPRReq.ACRID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.Title + "','" + objPRReq.ITID + "','" + objPRReq.ItemName + "','" + objPRReq.DateofInitiation + "','" + objPRReq.CompletionStatus + "','" + objPRReq.DateofCompletion + "','" + objPRReq.JournalStatus + "','" + objPRReq.Remarks + "','" + objPRReq.Dated + "','" + objPRReq.Status + "')";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp UpdateACR_tbl_P232B_ConsultancyResearch_RPID(PRReq objPRReq)
        {
            string update = "update ACR_tbl_P232B_ConsultancyResearch set Title='" + objPRReq.Title + "',ITID='" + objPRReq.ITID + "', ItemName='" + objPRReq.ItemName + "',DateofInitiation='" + objPRReq.DateofInitiation + "',CompletionStatus='" + objPRReq.CompletionStatus + "',DateofCompletion='" + objPRReq.DateofCompletion + "',JournalStatus='" + objPRReq.JournalStatus + "',Remarks='" + objPRReq.Remarks + "', Dated='" + objPRReq.Dated + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and RPID='" + objPRReq.RPID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp getACR_tbl_P232B_ConsultancyResearch_EmpID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P232B_ConsultancyResearch where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' order by ITID ASC ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllACR_tbl_P232B_ConsultancyResearch_EmpID_ITID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P232B_ConsultancyResearch where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and ITID='" + objPRReq.ITID + "' order by ITID ASC ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P232B_ConsultancyResearch_EmpID_ITID(PRReq objPRReq)
        {
            string s = "select distinct ITID,ItemName from ACR_tbl_P232B_ConsultancyResearch where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' order by ITID ASC ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllACR_tbl_P232B_ConsultancyResearch_ACRID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P232B_ConsultancyResearch where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' order by ITID ASC ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P232B_ConsultancyResearch_NameITID(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P232B_ConsultancyResearch where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and ITID='" + objPRReq.ITID + "' and Title='" + objPRReq.Title + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P232B_ConsultancyResearch_RPID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P232B_ConsultancyResearch where Status='" + objPRReq.Status + "' and RPID='" + objPRReq.RPID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp DelACR_tbl_P232B_ConsultancyResearch_RPID(PRReq objPRReq)
        {
            string hod = "delete from ACR_tbl_P232B_ConsultancyResearch where  OID='" + objPRReq.OID + "' and RPID='" + objPRReq.RPID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }


        // 2.3.2C Details of Action Research
        public PRResp AddACR_tbl_P232C_ActioinResearch(PRReq objPRReq)
        {
            string s = "INSERT INTO ACR_tbl_P232C_ActioinResearch (OID,FinancialYear,ACRID,EmpID,Name,Title,ITID,ItemName,DateofInitiation,CompletionStatus,DateofCompletion,JournalStatus,Remarks,Dated,Status) values('" + objPRReq.OID + "','" + objPRReq.FinancialYear + "','" + objPRReq.ACRID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.Title + "','" + objPRReq.ITID + "','" + objPRReq.ItemName + "','" + objPRReq.DateofInitiation + "','" + objPRReq.CompletionStatus + "','" + objPRReq.DateofCompletion + "','" + objPRReq.JournalStatus + "','" + objPRReq.Remarks + "','" + objPRReq.Dated + "','" + objPRReq.Status + "')";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp UpdateACR_tbl_P232C_ActioinResearch_RPID(PRReq objPRReq)
        {
            string update = "update ACR_tbl_P232C_ActioinResearch set Title='" + objPRReq.Title + "',ITID='" + objPRReq.ITID + "', ItemName='" + objPRReq.ItemName + "',DateofInitiation='" + objPRReq.DateofInitiation + "',CompletionStatus='" + objPRReq.CompletionStatus + "',DateofCompletion='" + objPRReq.DateofCompletion + "',JournalStatus='" + objPRReq.JournalStatus + "',Remarks='" + objPRReq.Remarks + "', Dated='" + objPRReq.Dated + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and RPID='" + objPRReq.RPID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp getACR_tbl_P232C_ActioinResearch_EmpID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P232C_ActioinResearch where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' order by ITID ASC ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllACR_tbl_P232C_ActioinResearch_EmpID_ITID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P232C_ActioinResearch where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and ITID='" + objPRReq.ITID + "' order by ITID ASC ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P232C_ActioinResearch_EmpID_ITID(PRReq objPRReq)
        {
            string s = "select distinct ITID,ItemName from ACR_tbl_P232C_ActioinResearch where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' order by ITID ASC ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllACR_tbl_P232C_ActioinResearch_ACRID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P232C_ActioinResearch where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' order by ITID ASC ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P232C_ActioinResearch_NameITID(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P232C_ActioinResearch where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and ITID='" + objPRReq.ITID + "' and Title='" + objPRReq.Title + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P232C_ActioinResearch_RPID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P232C_ActioinResearch where Status='" + objPRReq.Status + "' and RPID='" + objPRReq.RPID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp DelACR_tbl_P232C_ActioinResearch_RPID(PRReq objPRReq)
        {
            string hod = "delete from ACR_tbl_P232C_ActioinResearch where  OID='" + objPRReq.OID + "' and RPID='" + objPRReq.RPID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }

        // 2.3.3A Research Publications
        public PRResp AddACR_tbl_P233A_ResearchPublications(PRReq objPRReq)
        {
            string s = "INSERT INTO ACR_tbl_P233A_ResearchPublications (OID,FinancialYear,ACRID,EmpID,Name,Title,ITID,ItemName,NameoftheJournal,ISBNNumber,Dated,Status) values('" + objPRReq.OID + "','" + objPRReq.FinancialYear + "','" + objPRReq.ACRID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.Title + "','" + objPRReq.ITID + "','" + objPRReq.ItemName + "','" + objPRReq.NameoftheJournal + "','" + objPRReq.ISBNNumber + "','" + objPRReq.Dated + "','" + objPRReq.Status + "')";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp UpdateACR_tbl_P233A_ResearchPublications_RPID(PRReq objPRReq)
        {
            string update = "update ACR_tbl_P233A_ResearchPublications set Title='" + objPRReq.Title + "',ITID='" + objPRReq.ITID + "', ItemName='" + objPRReq.ItemName + "',NameoftheJournal='" + objPRReq.NameoftheJournal + "',ISBNNumber='" + objPRReq.ISBNNumber + "', Dated='" + objPRReq.Dated + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and RPID='" + objPRReq.RPID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp getACR_tbl_P233A_ResearchPublications_EmpID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P233A_ResearchPublications where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' order by ITID ASC ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllACR_tbl_P233A_ResearchPublications_EmpID_ITID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P233A_ResearchPublications where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and ITID='" + objPRReq.ITID + "' order by ITID ASC ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P233A_ResearchPublications_EmpID_ITID(PRReq objPRReq)
        {
            string s = "select distinct ITID,ItemName from ACR_tbl_P233A_ResearchPublications where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' order by ITID ASC ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllACR_tbl_P233A_ResearchPublications_ACRID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P233A_ResearchPublications where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' order by ITID ASC ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P233A_ResearchPublications_NameITID(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P233A_ResearchPublications where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and ITID='" + objPRReq.ITID + "' and Title='" + objPRReq.Title + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P233A_ResearchPublications_RPID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P233A_ResearchPublications where Status='" + objPRReq.Status + "' and RPID='" + objPRReq.RPID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp DelACR_tbl_P233A_ResearchPublications_RPID(PRReq objPRReq)
        {
            string hod = "delete from ACR_tbl_P233A_ResearchPublications where  OID='" + objPRReq.OID + "' and RPID='" + objPRReq.RPID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }

        // 2.3.3B Books
        public PRResp AddACR_tbl_P233B_Books(PRReq objPRReq)
        {
            string s = "INSERT INTO ACR_tbl_P233B_Books (OID,FinancialYear,ACRID,EmpID,Name,Title,ITID,ItemName,NameoftheJournal,ISBNNumber,Dated,Status) values('" + objPRReq.OID + "','" + objPRReq.FinancialYear + "','" + objPRReq.ACRID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.Title + "','" + objPRReq.ITID + "','" + objPRReq.ItemName + "','" + objPRReq.NameoftheJournal + "','" + objPRReq.ISBNNumber + "','" + objPRReq.Dated + "','" + objPRReq.Status + "')";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp UpdateACR_tbl_P233B_Books_RPID(PRReq objPRReq)
        {
            string update = "update ACR_tbl_P233B_Books set Title='" + objPRReq.Title + "',ITID='" + objPRReq.ITID + "', ItemName='" + objPRReq.ItemName + "',NameoftheJournal='" + objPRReq.NameoftheJournal + "',ISBNNumber='" + objPRReq.ISBNNumber + "', Dated='" + objPRReq.Dated + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and RPID='" + objPRReq.RPID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp getACR_tbl_P233B_Books_EmpID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P233B_Books where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' order by ITID ASC ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllACR_tbl_P233B_Books_EmpID_ITID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P233B_Books where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and ITID='" + objPRReq.ITID + "' order by ITID ASC ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P233B_Books_EmpID_ITID(PRReq objPRReq)
        {
            string s = "select distinct ITID,ItemName from ACR_tbl_P233B_Books where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' order by ITID ASC ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllACR_tbl_P233B_Books_ACRID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P233B_Books where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' order by ITID ASC ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P233B_Books_NameITID(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P233B_Books where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and ITID='" + objPRReq.ITID + "' and Title='" + objPRReq.Title + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P233B_Books_RPID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P233B_Books where Status='" + objPRReq.Status + "' and RPID='" + objPRReq.RPID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp DelACR_tbl_P233B_Books_RPID(PRReq objPRReq)
        {
            string hod = "delete from ACR_tbl_P233B_Books where  OID='" + objPRReq.OID + "' and RPID='" + objPRReq.RPID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }

        // 2.3.3C Chapters in Books
        public PRResp AddACR_tbl_P233C_ChaptersInBooks(PRReq objPRReq)
        {
            string s = "INSERT INTO ACR_tbl_P233C_ChaptersInBooks (OID,FinancialYear,ACRID,EmpID,Name,Title,ITID,ItemName,NameoftheJournal,ISBNNumber,Dated,Status) values('" + objPRReq.OID + "','" + objPRReq.FinancialYear + "','" + objPRReq.ACRID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.Title + "','" + objPRReq.ITID + "','" + objPRReq.ItemName + "','" + objPRReq.NameoftheJournal + "','" + objPRReq.ISBNNumber + "','" + objPRReq.Dated + "','" + objPRReq.Status + "')";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp UpdateACR_tbl_P233C_ChaptersInBooks_RPID(PRReq objPRReq)
        {
            string update = "update ACR_tbl_P233C_ChaptersInBooks set Title='" + objPRReq.Title + "',ITID='" + objPRReq.ITID + "', ItemName='" + objPRReq.ItemName + "',NameoftheJournal='" + objPRReq.NameoftheJournal + "',ISBNNumber='" + objPRReq.ISBNNumber + "', Dated='" + objPRReq.Dated + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and RPID='" + objPRReq.RPID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp getACR_tbl_P233C_ChaptersInBooks_EmpID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P233C_ChaptersInBooks where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' order by ITID ASC ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllACR_tbl_P233C_ChaptersInBooks_EmpID_ITID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P233C_ChaptersInBooks where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and ITID='" + objPRReq.ITID + "' order by ITID ASC ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P233C_ChaptersInBooks_EmpID_ITID(PRReq objPRReq)
        {
            string s = "select distinct ITID,ItemName from ACR_tbl_P233C_ChaptersInBooks where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' order by ITID ASC ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllACR_tbl_P233C_ChaptersInBooks_ACRID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P233C_ChaptersInBooks where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' order by ITID ASC ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P233C_ChaptersInBooks_NameITID(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P233C_ChaptersInBooks where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and ITID='" + objPRReq.ITID + "' and Title='" + objPRReq.Title + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P233C_ChaptersInBooks_RPID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P233C_ChaptersInBooks where Status='" + objPRReq.Status + "' and RPID='" + objPRReq.RPID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp DelACR_tbl_P233C_ChaptersInBooks_RPID(PRReq objPRReq)
        {
            string hod = "delete from ACR_tbl_P233C_ChaptersInBooks where  OID='" + objPRReq.OID + "' and RPID='" + objPRReq.RPID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }

        // 2.3.3.4 Policy Advocacy

        public PRResp AddACR_tbl_P233D_PolicyAdvocacy(PRReq objPRReq)
        {
            string s = "INSERT INTO ACR_tbl_P233D_PolicyAdvocacy (OID,FinancialYear,ACRID,EmpID,Name,Title,Description,Dated,Status) values('" + objPRReq.OID + "','" + objPRReq.FinancialYear + "','" + objPRReq.ACRID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.Title + "','" + objPRReq.Description + "','" + objPRReq.Dated + "','" + objPRReq.Status + "')";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp UpdateACR_tbl_P233D_PolicyAdvocacy_ACRID(PRReq objPRReq)
        {
            string update = "update ACR_tbl_P233D_PolicyAdvocacy set Title='" + objPRReq.Title + "',Description='" + objPRReq.Description + "', Dated='" + objPRReq.Dated + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and ADID='" + objPRReq.ADID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp getACR_tbl_P233D_PolicyAdvocacy_EmpID(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P233D_PolicyAdvocacy where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P233D_PolicyAdvocacy_Name(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P233D_PolicyAdvocacy where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and Title='" + objPRReq.Title + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllACR_tbl_P233D_PolicyAdvocacy_EmpID_ACRID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P233D_PolicyAdvocacy where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P233D_PolicyAdvocacy_EmpID_ADID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P233D_PolicyAdvocacy where Status='" + objPRReq.Status + "' and ADID='" + objPRReq.ADID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp DelACR_tbl_P233D_PolicyAdvocacy_EmpID_ADID(PRReq objPRReq)
        {
            string hod = "delete from ACR_tbl_P233D_PolicyAdvocacy where  OID='" + objPRReq.OID + "' and ADID='" + objPRReq.ADID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }

        // 2.3.4.1 Review
        public PRResp AddACR_tbl_P2341_BookReview(PRReq objPRReq)
        {
            string s = "INSERT INTO ACR_tbl_P2341_BookReview (OID,FinancialYear,ACRID,EmpID,Name,Title,ITID,ItemName,Author,ReviewTitle,NameoftheJournal,ISBNNumber,Dated,Status) values('" + objPRReq.OID + "','" + objPRReq.FinancialYear + "','" + objPRReq.ACRID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.Title + "','" + objPRReq.ITID + "','" + objPRReq.ItemName + "','" + objPRReq.AuthorName + "','" + objPRReq.ReviewTitle + "','" + objPRReq.NameoftheJournal + "','" + objPRReq.ISBNNumber + "','" + objPRReq.Dated + "','" + objPRReq.Status + "')";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp UpdateACR_tbl_P2341_BookReview_RPID(PRReq objPRReq)
        {
            string update = "update ACR_tbl_P2341_BookReview set Title='" + objPRReq.Title + "',ITID='" + objPRReq.ITID + "', ItemName='" + objPRReq.ItemName + "',Author='" + objPRReq.AuthorName + "',ReviewTitle='" + objPRReq.ReviewTitle + "', NameoftheJournal='" + objPRReq.NameoftheJournal + "',ISBNNumber='" + objPRReq.ISBNNumber + "', Dated='" + objPRReq.Dated + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and RPID='" + objPRReq.RPID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp getACR_tbl_P2341_BookReview_EmpID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P2341_BookReview where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' order by ITID ASC ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllACR_tbl_P2341_BookReview_EmpID_ITID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P2341_BookReview where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and ITID='" + objPRReq.ITID + "' order by ITID ASC ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P2341_BookReview_EmpID_ITID(PRReq objPRReq)
        {
            string s = "select distinct ITID,ItemName from ACR_tbl_P2341_BookReview where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' order by ITID ASC ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllACR_tbl_P2341_BookReview_ACRID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P2341_BookReview where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' order by ITID ASC ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P2341_BookReview_NameITID(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P2341_BookReview where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and ITID='" + objPRReq.ITID + "' and Title='" + objPRReq.Title + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P2341_BookReview_RPID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P2341_BookReview where Status='" + objPRReq.Status + "' and RPID='" + objPRReq.RPID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp DelACR_tbl_P2341_BookReview_RPID(PRReq objPRReq)
        {
            string hod = "delete from ACR_tbl_P2341_BookReview where  OID='" + objPRReq.OID + "' and RPID='" + objPRReq.RPID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }

        // 2.3.4.2 Abstracting
        public PRResp AddACR_tbl_P2342_BookAbstracting(PRReq objPRReq)
        {
            string s = "INSERT INTO ACR_tbl_P2342_BookAbstracting (OID,FinancialYear,ACRID,EmpID,Name,Title,ITID,ItemName,Author,ReviewTitle,NameoftheJournal,ISBNNumber,Dated,Status) values('" + objPRReq.OID + "','" + objPRReq.FinancialYear + "','" + objPRReq.ACRID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.Title + "','" + objPRReq.ITID + "','" + objPRReq.ItemName + "','" + objPRReq.AuthorName + "','" + objPRReq.ReviewTitle + "','" + objPRReq.NameoftheJournal + "','" + objPRReq.ISBNNumber + "','" + objPRReq.Dated + "','" + objPRReq.Status + "')";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp UpdateACR_tbl_P2342_BookAbstracting_RPID(PRReq objPRReq)
        {
            string update = "update ACR_tbl_P2342_BookAbstracting set Title='" + objPRReq.Title + "',ITID='" + objPRReq.ITID + "', ItemName='" + objPRReq.ItemName + "',Author='" + objPRReq.AuthorName + "',ReviewTitle='" + objPRReq.ReviewTitle + "', NameoftheJournal='" + objPRReq.NameoftheJournal + "',ISBNNumber='" + objPRReq.ISBNNumber + "', Dated='" + objPRReq.Dated + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and RPID='" + objPRReq.RPID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp getACR_tbl_P2342_BookAbstracting_EmpID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P2342_BookAbstracting where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' order by ITID ASC ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllACR_tbl_P2342_BookAbstracting_EmpID_ITID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P2342_BookAbstracting where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and ITID='" + objPRReq.ITID + "' order by ITID ASC ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P2342_BookAbstracting_EmpID_ITID(PRReq objPRReq)
        {
            string s = "select distinct ITID,ItemName from ACR_tbl_P2342_BookAbstracting where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' order by ITID ASC ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllACR_tbl_P2342_BookAbstracting_ACRID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P2342_BookAbstracting where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' order by ITID ASC ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P2342_BookAbstracting_NameITID(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P2342_BookAbstracting where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and ITID='" + objPRReq.ITID + "' and Title='" + objPRReq.Title + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P2342_BookAbstracting_RPID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P2342_BookAbstracting where Status='" + objPRReq.Status + "' and RPID='" + objPRReq.RPID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp DelACR_tbl_P2342_BookAbstracting_RPID(PRReq objPRReq)
        {
            string hod = "delete from ACR_tbl_P2342_BookAbstracting where  OID='" + objPRReq.OID + "' and RPID='" + objPRReq.RPID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }

        // ACR_tbl_P235_ProgAttPresented
        public PRResp AddACR_tbl_P235_ProgAttPresented(PRReq objPRReq)
        {
            string s = "INSERT INTO ACR_tbl_P235_ProgAttPresented (OID,FinancialYear,ACRID,EmpID,Name,Title,ITID,ItemName,ProgType,ProgName,Venue,Duration,Remarks,Dated,Status) values('" + objPRReq.OID + "','" + objPRReq.FinancialYear + "','" + objPRReq.ACRID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.Title + "','" + objPRReq.ITID + "','" + objPRReq.ItemName + "','" + objPRReq.ProgType + "','" + objPRReq.ProgTitle + "','" + objPRReq.ProgVenue + "','" + objPRReq.Duration + "','" + objPRReq.Remarks + "','" + objPRReq.Dated + "','" + objPRReq.Status + "')";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp UpdateACR_tbl_P235_ProgAttPresented_RPID(PRReq objPRReq)
        {
            string update = "update ACR_tbl_P235_ProgAttPresented set Title='" + objPRReq.Title + "',ITID='" + objPRReq.ITID + "', ItemName='" + objPRReq.ItemName + "', ProgType='" + objPRReq.ProgType + "',ProgName='" + objPRReq.ProgTitle + "',Venue='" + objPRReq.ProgVenue + "',Duration='" + objPRReq.Duration + "',Remarks='" + objPRReq.Remarks + "', Dated='" + objPRReq.Dated + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and RPID='" + objPRReq.RPID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp getACR_tbl_P235_ProgAttPresented_EmpID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P235_ProgAttPresented where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' order by ITID ASC ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllACR_tbl_P235_ProgAttPresented_EmpID_ITID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P235_ProgAttPresented where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and ITID='" + objPRReq.ITID + "' order by ITID ASC ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P235_ProgAttPresented_EmpID_ITID(PRReq objPRReq)
        {
            string s = "select distinct ITID,ItemName from ACR_tbl_P235_ProgAttPresented where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' order by ITID ASC ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllACR_tbl_P235_ProgAttPresented_ACRID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P235_ProgAttPresented where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' order by ITID ASC ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P235_ProgAttPresented_NameITID(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P235_ProgAttPresented where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and ITID='" + objPRReq.ITID + "' and Title='" + objPRReq.Title + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P235_ProgAttPresented_RPID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P235_ProgAttPresented where Status='" + objPRReq.Status + "' and RPID='" + objPRReq.RPID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp DelACR_tbl_P235_ProgAttPresented_RPID(PRReq objPRReq)
        {
            string hod = "delete from ACR_tbl_P235_ProgAttPresented where  OID='" + objPRReq.OID + "' and RPID='" + objPRReq.RPID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }

        // ACR_tbl_P236_Guidance
        public PRResp AddACR_tbl_P236_Guidance(PRReq objPRReq)
        {
            string s = "INSERT INTO ACR_tbl_P236_Guidance (OID,FinancialYear,ACRID,EmpID,Name,Title,ITID,ItemName,Duration,Outcome,Dated,Status) values('" + objPRReq.OID + "','" + objPRReq.FinancialYear + "','" + objPRReq.ACRID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.Title + "','" + objPRReq.ITID + "','" + objPRReq.ItemName + "','" + objPRReq.Duration + "','" + objPRReq.Outcome + "','" + objPRReq.Dated + "','" + objPRReq.Status + "')";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp UpdateACR_tbl_P236_Guidance_RPID(PRReq objPRReq)
        {
            string update = "update ACR_tbl_P236_Guidance set Title='" + objPRReq.Title + "',ITID='" + objPRReq.ITID + "', ItemName='" + objPRReq.ItemName + "',Duration='" + objPRReq.Duration + "',Outcome='" + objPRReq.Outcome + "', Dated='" + objPRReq.Dated + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and RPID='" + objPRReq.RPID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp getACR_tbl_P236_Guidance_EmpID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P236_Guidance where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' order by ITID ASC ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllACR_tbl_P236_Guidance_EmpID_ITID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P236_Guidance where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and ITID='" + objPRReq.ITID + "' order by ITID ASC ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P236_Guidance_EmpID_ITID(PRReq objPRReq)
        {
            string s = "select distinct ITID,ItemName from ACR_tbl_P236_Guidance where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' order by ITID ASC ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllACR_tbl_P236_Guidance_ACRID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P236_Guidance where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' order by ITID ASC ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P236_Guidance_NameITID(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P236_Guidance where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and ITID='" + objPRReq.ITID + "' and Title='" + objPRReq.Title + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P236_Guidance_RPID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P236_Guidance where Status='" + objPRReq.Status + "' and RPID='" + objPRReq.RPID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp DelACR_tbl_P236_Guidance_RPID(PRReq objPRReq)
        {
            string hod = "delete from ACR_tbl_P236_Guidance where  OID='" + objPRReq.OID + "' and RPID='" + objPRReq.RPID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }

        // ACR_tbl_P237_CertOnline  New Area of Specialization
        public PRResp AddACR_tbl_P237_CertOnline(PRReq objPRReq)
        {
            string s = "INSERT INTO ACR_tbl_P237_CertOnline (OID,FinancialYear,ACRID,EmpID,Name,Title,ITID,ItemName,Details,Remarks,Dated,Status) values('" + objPRReq.OID + "','" + objPRReq.FinancialYear + "','" + objPRReq.ACRID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.Title + "','" + objPRReq.ITID + "','" + objPRReq.ItemName + "','" + objPRReq.Details + "','" + objPRReq.Remarks + "','" + objPRReq.Dated + "','" + objPRReq.Status + "')";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp UpdateACR_tbl_P237_CertOnline_RPID(PRReq objPRReq)
        {
            string update = "update ACR_tbl_P237_CertOnline set Title='" + objPRReq.Title + "',ITID='" + objPRReq.ITID + "', ItemName='" + objPRReq.ItemName + "',Details='" + objPRReq.Details + "',Remarks='" + objPRReq.Remarks + "', Dated='" + objPRReq.Dated + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and RPID='" + objPRReq.RPID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp getACR_tbl_P237_CertOnline_EmpID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P237_CertOnline where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' order by ITID ASC ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllACR_tbl_P237_CertOnline_EmpID_ITID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P237_CertOnline where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and ITID='" + objPRReq.ITID + "' order by ITID ASC ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P237_CertOnline_EmpID_ITID(PRReq objPRReq)
        {
            string s = "select distinct ITID,ItemName from ACR_tbl_P237_CertOnline where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' order by ITID ASC ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllACR_tbl_P237_CertOnline_ACRID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P237_CertOnline where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' order by ITID ASC ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P237_CertOnline_NameITID(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P237_CertOnline where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and ITID='" + objPRReq.ITID + "' and Title='" + objPRReq.Title + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P237_CertOnline_RPID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P237_CertOnline where Status='" + objPRReq.Status + "' and RPID='" + objPRReq.RPID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp DelACR_tbl_P237_CertOnline_RPID(PRReq objPRReq)
        {
            string hod = "delete from ACR_tbl_P237_CertOnline where  OID='" + objPRReq.OID + "' and RPID='" + objPRReq.RPID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }

        // 2.4.1 ACR_tbl_P241_Extra_Cur_Act
        public PRResp AddACR_tbl_P241_Extra_Cur_Act(PRReq objPRReq)
        {
            string s = "INSERT INTO ACR_tbl_P241_Extra_Cur_Act (OID,FinancialYear,ACRID,EmpID,Name,ItemName,Dated,Status) values('" + objPRReq.OID + "','" + objPRReq.FinancialYear + "','" + objPRReq.ACRID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.ItemName + "','" + objPRReq.Dated + "','" + objPRReq.Status + "')";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp UpdateACR_tbl_P241_Extra_Cur_Act_ACRID(PRReq objPRReq)
        {
            string update = "update ACR_tbl_P241_Extra_Cur_Act set ItemName='" + objPRReq.ItemName + "',Dated='" + objPRReq.Dated + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and ADID='" + objPRReq.ADID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp getACR_tbl_P241_Extra_Cur_Act_EmpID(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P241_Extra_Cur_Act where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P241_Extra_Cur_Act_Name(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P241_Extra_Cur_Act where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and ItemName='" + objPRReq.ItemName + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllACR_tbl_P241_Extra_Cur_Act_EmpID_ACRID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P241_Extra_Cur_Act where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P241_Extra_Cur_Act_EmpID_ADID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P241_Extra_Cur_Act where Status='" + objPRReq.Status + "' and ADID='" + objPRReq.ADID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp DelACR_tbl_P241_Extra_Cur_Act_EmpID_ADID(PRReq objPRReq)
        {
            string hod = "delete from ACR_tbl_P241_Extra_Cur_Act where  OID='" + objPRReq.OID + "' and ADID='" + objPRReq.ADID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }

        // ACR_tbl_P242_ImpTasks
        public PRResp AddACR_tbl_P242_ImpTasks(PRReq objPRReq)
        {
            string s = "INSERT INTO ACR_tbl_P242_ImpTasks (OID,FinancialYear,ACRID,EmpID,Name,ItemName,Dated,Status) values('" + objPRReq.OID + "','" + objPRReq.FinancialYear + "','" + objPRReq.ACRID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.ItemName + "','" + objPRReq.Dated + "','" + objPRReq.Status + "')";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp UpdateACR_tbl_P242_ImpTasks_ACRID(PRReq objPRReq)
        {
            string update = "update ACR_tbl_P242_ImpTasks set ItemName='" + objPRReq.ItemName + "',Dated='" + objPRReq.Dated + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and ADID='" + objPRReq.ADID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp getACR_tbl_P242_ImpTasks_EmpID(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P242_ImpTasks where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P242_ImpTasks_Name(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P242_ImpTasks where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and ItemName='" + objPRReq.ItemName + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllACR_tbl_P242_ImpTasks_EmpID_ACRID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P242_ImpTasks where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P242_ImpTasks_EmpID_ADID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P242_ImpTasks where Status='" + objPRReq.Status + "' and ADID='" + objPRReq.ADID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp DelACR_tbl_P242_ImpTasks_EmpID_ADID(PRReq objPRReq)
        {
            string hod = "delete from ACR_tbl_P242_ImpTasks where  OID='" + objPRReq.OID + "' and ADID='" + objPRReq.ADID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }

        // ACR_tbl_P243_Achievements
        public PRResp AddACR_tbl_P243_Achievements(PRReq objPRReq)
        {
            string s = "INSERT INTO ACR_tbl_P243_Achievements (OID,FinancialYear,ACRID,EmpID,Name,ItemName,Dated,Status) values('" + objPRReq.OID + "','" + objPRReq.FinancialYear + "','" + objPRReq.ACRID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.ItemName + "','" + objPRReq.Dated + "','" + objPRReq.Status + "')";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp UpdateACR_tbl_P243_Achievements_ACRID(PRReq objPRReq)
        {
            string update = "update ACR_tbl_P243_Achievements set ItemName='" + objPRReq.ItemName + "',Dated='" + objPRReq.Dated + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and ADID='" + objPRReq.ADID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp getACR_tbl_P243_Achievements_EmpID(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P243_Achievements where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P243_Achievements_Name(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P243_Achievements where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and ItemName='" + objPRReq.ItemName + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllACR_tbl_P243_Achievements_EmpID_ACRID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P243_Achievements where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P243_Achievements_EmpID_ADID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P243_Achievements where Status='" + objPRReq.Status + "' and ADID='" + objPRReq.ADID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp DelACR_tbl_P243_Achievements_EmpID_ADID(PRReq objPRReq)
        {
            string hod = "delete from ACR_tbl_P243_Achievements where  OID='" + objPRReq.OID + "' and ADID='" + objPRReq.ADID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }

        // ACR_tbl_P244_Innovations
        public PRResp AddACR_tbl_P244_Innovations(PRReq objPRReq)
        {
            string s = "INSERT INTO ACR_tbl_P244_Innovations (OID,FinancialYear,ACRID,EmpID,Name,ItemName,Dated,Status) values('" + objPRReq.OID + "','" + objPRReq.FinancialYear + "','" + objPRReq.ACRID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.ItemName + "','" + objPRReq.Dated + "','" + objPRReq.Status + "')";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp UpdateACR_tbl_P244_Innovations_ACRID(PRReq objPRReq)
        {
            string update = "update ACR_tbl_P244_Innovations set ItemName='" + objPRReq.ItemName + "',Dated='" + objPRReq.Dated + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and ADID='" + objPRReq.ADID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp getACR_tbl_P244_Innovations_EmpID(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P244_Innovations where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P244_Innovations_Name(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P244_Innovations where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and ItemName='" + objPRReq.ItemName + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllACR_tbl_P244_Innovations_EmpID_ACRID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P244_Innovations where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P244_Innovations_EmpID_ADID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P244_Innovations where Status='" + objPRReq.Status + "' and ADID='" + objPRReq.ADID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp DelACR_tbl_P244_Innovations_EmpID_ADID(PRReq objPRReq)
        {
            string hod = "delete from ACR_tbl_P244_Innovations where  OID='" + objPRReq.OID + "' and ADID='" + objPRReq.ADID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }

        // ACR_tbl_P245_Constraints
        public PRResp AddACR_tbl_P245_Constraints(PRReq objPRReq)
        {
            string s = "INSERT INTO ACR_tbl_P245_Constraints (OID,FinancialYear,ACRID,EmpID,Name,ItemName,Dated,Status) values('" + objPRReq.OID + "','" + objPRReq.FinancialYear + "','" + objPRReq.ACRID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.ItemName + "','" + objPRReq.Dated + "','" + objPRReq.Status + "')";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp UpdateACR_tbl_P245_Constraints_ACRID(PRReq objPRReq)
        {
            string update = "update ACR_tbl_P245_Constraints set ItemName='" + objPRReq.ItemName + "',Dated='" + objPRReq.Dated + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and ADID='" + objPRReq.ADID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp getACR_tbl_P245_Constraints_EmpID(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P245_Constraints where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P245_Constraints_Name(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P245_Constraints where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and ItemName='" + objPRReq.ItemName + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllACR_tbl_P245_Constraints_EmpID_ACRID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P245_Constraints where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P245_Constraints_EmpID_ADID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P245_Constraints where Status='" + objPRReq.Status + "' and ADID='" + objPRReq.ADID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp DelACR_tbl_P245_Constraints_EmpID_ADID(PRReq objPRReq)
        {
            string hod = "delete from ACR_tbl_P245_Constraints where  OID='" + objPRReq.OID + "' and ADID='" + objPRReq.ADID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }

        // ACR_tbl_P27_AreaofInterest  you would like to develop
        public PRResp AddACR_tbl_P27_AreaofInterest(PRReq objPRReq)
        {
            string s = "INSERT INTO ACR_tbl_P27_AreaofInterest (OID,FinancialYear,ACRID,EmpID,Name,Title,ITID,ItemName,Details,Remarks,Dated,Status) values('" + objPRReq.OID + "','" + objPRReq.FinancialYear + "','" + objPRReq.ACRID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.Title + "','" + objPRReq.ITID + "','" + objPRReq.ItemName + "','" + objPRReq.Details + "','" + objPRReq.Remarks + "','" + objPRReq.Dated + "','" + objPRReq.Status + "')";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp UpdateACR_tbl_P27_AreaofInterest_RPID(PRReq objPRReq)
        {
            string update = "update ACR_tbl_P27_AreaofInterest set Title='" + objPRReq.Title + "',ITID='" + objPRReq.ITID + "', ItemName='" + objPRReq.ItemName + "',Details='" + objPRReq.Details + "',Remarks='" + objPRReq.Remarks + "', Dated='" + objPRReq.Dated + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and RPID='" + objPRReq.RPID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp getACR_tbl_P27_AreaofInterest_EmpID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P27_AreaofInterest where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' order by ITID ASC ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllACR_tbl_P27_AreaofInterest_EmpID_ITID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P27_AreaofInterest where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and ITID='" + objPRReq.ITID + "' order by ITID ASC ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P27_AreaofInterest_EmpID_ITID(PRReq objPRReq)
        {
            string s = "select distinct ITID,ItemName from ACR_tbl_P27_AreaofInterest where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' order by ITID ASC ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllACR_tbl_P27_AreaofInterest_ACRID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P27_AreaofInterest where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' order by ITID ASC ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P27_AreaofInterest_NameITID(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P27_AreaofInterest where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and EmpID='" + objPRReq.EmpID + "' and ITID='" + objPRReq.ITID + "' and Title='" + objPRReq.Title + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P27_AreaofInterest_RPID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P27_AreaofInterest where Status='" + objPRReq.Status + "' and RPID='" + objPRReq.RPID + "' and EmpID='" + objPRReq.EmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp DelACR_tbl_P27_AreaofInterest_RPID(PRReq objPRReq)
        {
            string hod = "delete from ACR_tbl_P27_AreaofInterest where  OID='" + objPRReq.OID + "' and RPID='" + objPRReq.RPID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }


        // Assessment Masters Part 3 & 4
        public PRResp AddACR_tbl_P34_AssmtOfWorkOutput_Master(PRReq objPRReq)
        {
            string s = "INSERT INTO ACR_tbl_P34_AssmtOfWorkOutput_Master (OID,AssessmentOfWorkOutput,Dated,Status) values('" + objPRReq.OID + "','" + objPRReq.AssmentOfWorkOutput + "','" + objPRReq.Dated + "','" + objPRReq.Status + "')";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp UpdateACR_tbl_P34_AssmtOfWorkOutput_Master_ADID(PRReq objPRReq)
        {
            string update = "update ACR_tbl_P34_AssmtOfWorkOutput_Master set AssessmentOfWorkOutput='" + objPRReq.AssmentOfWorkOutput + "',Dated='" + objPRReq.Dated + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ADID='" + objPRReq.ADID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp getACR_tbl_P34_AssmtOfWorkOutput_Master(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P34_AssmtOfWorkOutput_Master where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P34_AssmtOfWorkOutput_Master_Name(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P34_AssmtOfWorkOutput_Master where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and AssessmentOfWorkOutput='" + objPRReq.AssmentOfWorkOutput + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllACR_tbl_P34_AssmtOfWorkOutput_Master(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P34_AssmtOfWorkOutput_Master where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P34_AssmtOfWorkOutput_Master_ADID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P34_AssmtOfWorkOutput_Master where Status='" + objPRReq.Status + "' and ADID='" + objPRReq.ADID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp DelACR_tbl_P34_AssmtOfWorkOutput_Master_ADID(PRReq objPRReq)
        {
            string hod = "delete from ACR_tbl_P34_AssmtOfWorkOutput_Master where  OID='" + objPRReq.OID + "' and ADID='" + objPRReq.ADID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }


        // Assessment Masters Part 3 & 4 Financial competency
        public PRResp AddACR_tbl_P34_AssmtOfFinCompetency_Master(PRReq objPRReq)
        {
            string s = "INSERT INTO ACR_tbl_P34_AssmtOfFinCompetency_Master (OID,AssessmentOfFinCompetency,Dated,Status) values('" + objPRReq.OID + "','" + objPRReq.AssessmentOfFinCompetency + "','" + objPRReq.Dated + "','" + objPRReq.Status + "')";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp UpdateACR_tbl_P34_AssmtOfFinCompetency_Master_ADID(PRReq objPRReq)
        {
            string update = "update ACR_tbl_P34_AssmtOfFinCompetency_Master set AssessmentOfFinCompetency='" + objPRReq.AssessmentOfFinCompetency + "',Dated='" + objPRReq.Dated + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ADID='" + objPRReq.ADID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp getACR_tbl_P34_AssmtOfFinCompetency_Master(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P34_AssmtOfFinCompetency_Master where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P34_AssmtOfFinCompetency_Master_Name(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P34_AssmtOfFinCompetency_Master where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and AssessmentOfFinCompetency='" + objPRReq.AssessmentOfFinCompetency + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllACR_tbl_P34_AssmtOfFinCompetency_Master(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P34_AssmtOfFinCompetency_Master where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P34_AssmtOfFinCompetency_Master_ADID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P34_AssmtOfFinCompetency_Master where Status='" + objPRReq.Status + "' and ADID='" + objPRReq.ADID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp DelACR_tbl_P34_AssmtOfFinCompetency_Master_ADID(PRReq objPRReq)
        {
            string hod = "delete from ACR_tbl_P34_AssmtOfFinCompetency_Master where  OID='" + objPRReq.OID + "' and ADID='" + objPRReq.ADID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }

        // Assessment Masters ACR_tbl_P34_AssmtOfPersonalAttributes_Master
        public PRResp AddACR_tbl_P34_AssmtOfPersonalAttributes_Master(PRReq objPRReq)
        {
            string s = "INSERT INTO ACR_tbl_P34_AssmtOfPersonalAttributes_Master (OID,AssessmentOfPersonalAttributes,Dated,Status) values('" + objPRReq.OID + "','" + objPRReq.AssessmentOfPersonalAttributes + "','" + objPRReq.Dated + "','" + objPRReq.Status + "')";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp UpdateACR_tbl_P34_AssmtOfPersonalAttributes_Master_ADID(PRReq objPRReq)
        {
            string update = "update ACR_tbl_P34_AssmtOfPersonalAttributes_Master set AssessmentOfPersonalAttributes='" + objPRReq.AssessmentOfPersonalAttributes + "',Dated='" + objPRReq.Dated + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ADID='" + objPRReq.ADID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp getACR_tbl_P34_AssmtOfPersonalAttributes_Master(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P34_AssmtOfPersonalAttributes_Master where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P34_AssmtOfPersonalAttributes_Master_Name(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P34_AssmtOfPersonalAttributes_Master where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and AssessmentOfPersonalAttributes='" + objPRReq.AssessmentOfPersonalAttributes + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllACR_tbl_P34_AssmtOfPersonalAttributes_Master(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P34_AssmtOfPersonalAttributes_Master where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P34_AssmtOfPersonalAttributes_Master_ADID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P34_AssmtOfPersonalAttributes_Master where Status='" + objPRReq.Status + "' and ADID='" + objPRReq.ADID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp DelACR_tbl_P34_AssmtOfPersonalAttributes_Master_ADID(PRReq objPRReq)
        {
            string hod = "delete from ACR_tbl_P34_AssmtOfPersonalAttributes_Master where  OID='" + objPRReq.OID + "' and ADID='" + objPRReq.ADID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }

        // Assessment Masters ACR_tbl_P34_AssmtOfSpecialAttributes_Master
        public PRResp AddACR_tbl_P34_AssmtOfSpecialAttributes_Master(PRReq objPRReq)
        {
            string s = "INSERT INTO ACR_tbl_P34_AssmtOfSpecialAttributes_Master (OID,AssessmentOfSpecialAttributes,Dated,Status) values('" + objPRReq.OID + "','" + objPRReq.AssessmentOfSpecialAttributes + "','" + objPRReq.Dated + "','" + objPRReq.Status + "')";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp UpdateACR_tbl_P34_AssmtOfSpecialAttributes_Master_ADID(PRReq objPRReq)
        {
            string update = "update ACR_tbl_P34_AssmtOfSpecialAttributes_Master set AssessmentOfSpecialAttributes='" + objPRReq.AssessmentOfSpecialAttributes + "',Dated='" + objPRReq.Dated + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ADID='" + objPRReq.ADID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp getACR_tbl_P34_AssmtOfSpecialAttributes_Master(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P34_AssmtOfSpecialAttributes_Master where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P34_AssmtOfSpecialAttributes_Master_Name(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P34_AssmtOfSpecialAttributes_Master where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and AssessmentOfSpecialAttributes='" + objPRReq.AssessmentOfSpecialAttributes + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllACR_tbl_P34_AssmtOfSpecialAttributes_Master(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P34_AssmtOfSpecialAttributes_Master where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P34_AssmtOfSpecialAttributes_Master_ADID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P34_AssmtOfSpecialAttributes_Master where Status='" + objPRReq.Status + "' and ADID='" + objPRReq.ADID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp DelACR_tbl_P34_AssmtOfSpecialAttributes_Master_ADID(PRReq objPRReq)
        {
            string hod = "delete from ACR_tbl_P34_AssmtOfSpecialAttributes_Master where  OID='" + objPRReq.OID + "' and ADID='" + objPRReq.ADID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }

        // ACR History
        public PRResp AddACR_tbl_History(PRReq objPRReq)
        {
            string insert = "INSERT INTO ACR_tbl_History (OID,FinancialYear,ACRID,EmpID,Name,OfficerLevel,OEmpID,OName,Action,Remarks,Dated) values('" + objPRReq.OID + "','" + objPRReq.FinancialYear + "','" + objPRReq.ACRID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.OLevel + "','" + objPRReq.OEmpID + "','" + objPRReq.OName + "','" + objPRReq.HAction + "','" + objPRReq.Remarks + "','" + objPRReq.Dated + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getACR_tbl_History_ACRID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_History where OID='" + objPRReq.OID + "' and ACRID='" + objPRReq.ACRID + "' order by AHID Desc ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_History_ACRID_Action(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_History where OID='" + objPRReq.OID + "' and ACRID='" + objPRReq.ACRID + "' and Action='" + objPRReq.HAction + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        // Reporting/Reviewing officer
        public PRResp AddACR_tbl_P31_QualityOfWork(PRReq objPRReq)
        {
            string s = "INSERT INTO ACR_tbl_P31_QualityOfWork (OID,FinancialYear,ACRID,EmpID,Name,QualityOfWork,OfficerLevel,OEmpID,OName,Dated,Status) values('" + objPRReq.OID + "','" + objPRReq.FinancialYear + "','" + objPRReq.ACRID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.QualityOfWork + "','" + objPRReq.OLevel + "','" + objPRReq.OEmpID + "','" + objPRReq.OName + "','" + objPRReq.Dated + "','" + objPRReq.Status + "')";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp UpdateACR_tbl_P31_QualityOfWork_ACRID(PRReq objPRReq)
        {
            string update = "update ACR_tbl_P31_QualityOfWork set QualityOfWork='" + objPRReq.QualityOfWork + "',Dated='" + objPRReq.Dated + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and OEmpID='" + objPRReq.OEmpID + "' and ADID='" + objPRReq.ADID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp getACR_tbl_P31_QualityOfWork_OEmpID(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P31_QualityOfWork where Status='" + objPRReq.Status + "' and OEmpID='" + objPRReq.OEmpID + "' and ACRID='" + objPRReq.ACRID + "' and OfficerLevel='" + objPRReq.OLevel + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P31_QualityOfWork_Name(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P31_QualityOfWork where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and OEmpID='" + objPRReq.OEmpID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllACR_tbl_P31_QualityOfWork_OEmpID_ACRID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P31_QualityOfWork where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and OEmpID='" + objPRReq.OEmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P31_QualityOfWork_OEmpID_ADID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P31_QualityOfWork where Status='" + objPRReq.Status + "' and ADID='" + objPRReq.ADID + "' and OEmpID='" + objPRReq.OEmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp DelACR_tbl_P31_QualityOfWork_OEmpID_ADID(PRReq objPRReq)
        {
            string hod = "delete from ACR_tbl_P31_QualityOfWork where  OID='" + objPRReq.OID + "' and ADID='" + objPRReq.ADID + "' and OEmpID='" + objPRReq.OEmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }


        // Reporting/Reviewing officer
        public PRResp AddACR_tbl_P321_WorkOutPut(PRReq objPRReq)
        {
            string s = "INSERT INTO ACR_tbl_P321_WorkOutPut (OID,FinancialYear,ACRID,EmpID,Name,ITID,WorkOutputParameter,Grading,Grade,OfficerLevel,OEmpID,OName,Dated,Status) values('" + objPRReq.OID + "','" + objPRReq.FinancialYear + "','" + objPRReq.ACRID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.ITID + "','" + objPRReq.WorkOutputParameter + "','" + objPRReq.Grading + "','" + objPRReq.Grade + "','" + objPRReq.OLevel + "','" + objPRReq.OEmpID + "','" + objPRReq.OName + "','" + objPRReq.Dated + "','" + objPRReq.Status + "')";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp UpdateACR_tbl_P321_WorkOutPut_ACRID(PRReq objPRReq)
        {
            string update = "update ACR_tbl_P321_WorkOutPut set WorkOutputParameter='" + objPRReq.WorkOutputParameter + "', Grading='" + objPRReq.Grading + "',Grade='" + objPRReq.Grade + "', Dated='" + objPRReq.Dated + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and OEmpID='" + objPRReq.OEmpID + "' and OfficerLevel='" + objPRReq.OLevel + "' and ITID='" + objPRReq.ITID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp getACR_tbl_P321_WorkOutPut_OEmpID(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P321_WorkOutPut where Status='" + objPRReq.Status + "' and OEmpID='" + objPRReq.OEmpID + "' and ACRID='" + objPRReq.ACRID + "' and OfficerLevel='" + objPRReq.OLevel + "' order by ITID Asc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp getACR_tbl_P321_WorkOutPut_OEmpID_Sum(PRReq objPRReq)
        {
            string s = "select Sum(Grade) as Sum, Avg(Grade) as Avg from ACR_tbl_P321_WorkOutPut where Status='" + objPRReq.Status + "' and OEmpID='" + objPRReq.OEmpID + "' and ACRID='" + objPRReq.ACRID + "' and OfficerLevel='" + objPRReq.OLevel + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P321_WorkOutPut_OEmpID_ITID(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P321_WorkOutPut where Status='" + objPRReq.Status + "' and OEmpID='" + objPRReq.OEmpID + "' and ACRID='" + objPRReq.ACRID + "' and OfficerLevel='" + objPRReq.OLevel + "' and ITID='" + objPRReq.ITID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P321_WorkOutPut_Name(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P321_WorkOutPut where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and OEmpID='" + objPRReq.OEmpID + "' and WorkOutputParameter='" + objPRReq.WorkOutputParameter + "' and OfficerLevel='" + objPRReq.OLevel + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllACR_tbl_P321_WorkOutPut_OEmpID_ACRID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P321_WorkOutPut where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and OEmpID='" + objPRReq.OEmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P321_WorkOutPut_OEmpID_ADID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P321_WorkOutPut where Status='" + objPRReq.Status + "' and ADID='" + objPRReq.ADID + "' and OEmpID='" + objPRReq.OEmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp DelACR_tbl_P321_WorkOutPut_OEmpID_ACRID_OLevel(PRReq objPRReq)
        {
            string hod = "delete from ACR_tbl_P321_WorkOutPut where  OID='" + objPRReq.OID + "' and ACRID='" + objPRReq.ACRID + "' and OEmpID='" + objPRReq.OEmpID + "' and OfficerLevel='" + objPRReq.OLevel + "' and ITID='" + objPRReq.ITID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }


        // Reporting/Reviewing officer
        public PRResp AddACR_tbl_P322_FunctionalCompetency(PRReq objPRReq)
        {
            string s = "INSERT INTO ACR_tbl_P322_FunctionalCompetency (OID,FinancialYear,ACRID,EmpID,Name,ITID,FuntionalCompetencyParameter,Grading,Grade,OfficerLevel,OEmpID,OName,Dated,Status) values('" + objPRReq.OID + "','" + objPRReq.FinancialYear + "','" + objPRReq.ACRID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.ITID + "','" + objPRReq.FuntionalCompetencyParameter + "','" + objPRReq.Grading + "','" + objPRReq.Grade + "','" + objPRReq.OLevel + "','" + objPRReq.OEmpID + "','" + objPRReq.OName + "','" + objPRReq.Dated + "','" + objPRReq.Status + "')";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp UpdateACR_tbl_P322_FunctionalCompetency_ACRID(PRReq objPRReq)
        {
            string update = "update ACR_tbl_P322_FunctionalCompetency set FuntionalCompetencyParameter='" + objPRReq.FuntionalCompetencyParameter + "', Grading='" + objPRReq.Grading + "',Grade='" + objPRReq.Grade + "', Dated='" + objPRReq.Dated + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and OEmpID='" + objPRReq.OEmpID + "' and OfficerLevel='" + objPRReq.OLevel + "' and ITID='" + objPRReq.ITID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp getACR_tbl_P322_FunctionalCompetency_OEmpID(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P322_FunctionalCompetency where Status='" + objPRReq.Status + "' and OEmpID='" + objPRReq.OEmpID + "' and ACRID='" + objPRReq.ACRID + "' and OfficerLevel='" + objPRReq.OLevel + "' order by ITID Asc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P322_FunctionalCompetency_OEmpID_Sum(PRReq objPRReq)
        {
            string s = "select Sum(Grade) as Sum, Avg(Grade) as Avg from ACR_tbl_P322_FunctionalCompetency where Status='" + objPRReq.Status + "' and OEmpID='" + objPRReq.OEmpID + "' and ACRID='" + objPRReq.ACRID + "' and OfficerLevel='" + objPRReq.OLevel + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P322_FunctionalCompetency_OEmpID_ITID(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P322_FunctionalCompetency where Status='" + objPRReq.Status + "' and OEmpID='" + objPRReq.OEmpID + "' and ACRID='" + objPRReq.ACRID + "' and OfficerLevel='" + objPRReq.OLevel + "' and ITID='" + objPRReq.ITID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P322_FunctionalCompetency_Name(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P322_FunctionalCompetency where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and OEmpID='" + objPRReq.OEmpID + "' and FuntionalCompetencyParameter='" + objPRReq.FuntionalCompetencyParameter + "' and OfficerLevel='" + objPRReq.OLevel + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllACR_tbl_P322_FunctionalCompetency_OEmpID_ACRID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P322_FunctionalCompetency where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and OEmpID='" + objPRReq.OEmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P322_FunctionalCompetency_OEmpID_ADID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P322_FunctionalCompetency where Status='" + objPRReq.Status + "' and ADID='" + objPRReq.ADID + "' and OEmpID='" + objPRReq.OEmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp DelACR_tbl_P322_FunctionalCompetency_OEmpID_ACRID_OLevel(PRReq objPRReq)
        {
            string hod = "delete from ACR_tbl_P322_FunctionalCompetency where  OID='" + objPRReq.OID + "' and ACRID='" + objPRReq.ACRID + "' and OEmpID='" + objPRReq.OEmpID + "' and OfficerLevel='" + objPRReq.OLevel + "' and ITID='" + objPRReq.ITID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }


        // Reporting/Reviewing officer
        public PRResp AddACR_tbl_P323_PerAttributes(PRReq objPRReq)
        {
            string s = "INSERT INTO ACR_tbl_P323_PerAttributes (OID,FinancialYear,ACRID,EmpID,Name,ITID,PerAttributesParameter,Grading,Grade,OfficerLevel,OEmpID,OName,Dated,Status) values('" + objPRReq.OID + "','" + objPRReq.FinancialYear + "','" + objPRReq.ACRID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.ITID + "','" + objPRReq.PerAttributesParameter + "','" + objPRReq.Grading + "','" + objPRReq.Grade + "','" + objPRReq.OLevel + "','" + objPRReq.OEmpID + "','" + objPRReq.OName + "','" + objPRReq.Dated + "','" + objPRReq.Status + "')";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp UpdateACR_tbl_P323_PerAttributes_ACRID(PRReq objPRReq)
        {
            string update = "update ACR_tbl_P323_PerAttributes set PerAttributesParameter='" + objPRReq.PerAttributesParameter + "', Grading='" + objPRReq.Grading + "',Grade='" + objPRReq.Grade + "', Dated='" + objPRReq.Dated + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and OEmpID='" + objPRReq.OEmpID + "' and OfficerLevel='" + objPRReq.OLevel + "' and ITID='" + objPRReq.ITID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp getACR_tbl_P323_PerAttributes_OEmpID(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P323_PerAttributes where Status='" + objPRReq.Status + "' and OEmpID='" + objPRReq.OEmpID + "' and ACRID='" + objPRReq.ACRID + "' and OfficerLevel='" + objPRReq.OLevel + "' order by ITID Asc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P323_PerAttributes_OEmpID_Sum(PRReq objPRReq)
        {
            string s = "select Sum(Grade) as Sum, Avg(Grade) as Avg from ACR_tbl_P323_PerAttributes where Status='" + objPRReq.Status + "' and OEmpID='" + objPRReq.OEmpID + "' and ACRID='" + objPRReq.ACRID + "' and OfficerLevel='" + objPRReq.OLevel + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P323_PerAttributes_OEmpID_ITID(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P323_PerAttributes where Status='" + objPRReq.Status + "' and OEmpID='" + objPRReq.OEmpID + "' and ACRID='" + objPRReq.ACRID + "' and OfficerLevel='" + objPRReq.OLevel + "' and ITID='" + objPRReq.ITID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P323_PerAttributes_Name(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P323_PerAttributes where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and OEmpID='" + objPRReq.OEmpID + "' and PerAttributesParameter='" + objPRReq.PerAttributesParameter + "' and OfficerLevel='" + objPRReq.OLevel + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllACR_tbl_P323_PerAttributes_OEmpID_ACRID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P323_PerAttributes where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and OEmpID='" + objPRReq.OEmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P323_PerAttributes_OEmpID_ADID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P323_PerAttributes where Status='" + objPRReq.Status + "' and ADID='" + objPRReq.ADID + "' and OEmpID='" + objPRReq.OEmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp DelACR_tbl_P323_PerAttributes_OEmpID_ACRID_OLevel(PRReq objPRReq)
        {
            string hod = "delete from ACR_tbl_P323_PerAttributes where  OID='" + objPRReq.OID + "' and ACRID='" + objPRReq.ACRID + "' and OEmpID='" + objPRReq.OEmpID + "' and OfficerLevel='" + objPRReq.OLevel + "' and ITID='" + objPRReq.ITID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }


        // Reporting/Reviewing officer
        public PRResp AddACR_tbl_P324_SPLAttributes(PRReq objPRReq)
        {
            string s = "INSERT INTO ACR_tbl_P324_SPLAttributes (OID,FinancialYear,ACRID,EmpID,Name,ITID,SPLAttributesParameter,Grading,Grade,OfficerLevel,OEmpID,OName,Dated,Status) values('" + objPRReq.OID + "','" + objPRReq.FinancialYear + "','" + objPRReq.ACRID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.ITID + "','" + objPRReq.SPLAttributesParameter + "','" + objPRReq.Grading + "','" + objPRReq.Grade + "','" + objPRReq.OLevel + "','" + objPRReq.OEmpID + "','" + objPRReq.OName + "','" + objPRReq.Dated + "','" + objPRReq.Status + "')";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp UpdateACR_tbl_P324_SPLAttributes_ACRID(PRReq objPRReq)
        {
            string update = "update ACR_tbl_P324_SPLAttributes set SPLAttributesParameter='" + objPRReq.SPLAttributesParameter + "', Grading='" + objPRReq.Grading + "',Grade='" + objPRReq.Grade + "', Dated='" + objPRReq.Dated + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and OEmpID='" + objPRReq.OEmpID + "' and OfficerLevel='" + objPRReq.OLevel + "' and ITID='" + objPRReq.ITID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp getACR_tbl_P324_SPLAttributes_OEmpID(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P324_SPLAttributes where Status='" + objPRReq.Status + "' and OEmpID='" + objPRReq.OEmpID + "' and ACRID='" + objPRReq.ACRID + "' and OfficerLevel='" + objPRReq.OLevel + "' order by ITID Asc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P324_SPLAttributes_OEmpID_Sum(PRReq objPRReq)
        {
            string s = "select Sum(Grade) as Sum, Avg(Grade) as Avg from ACR_tbl_P324_SPLAttributes where Status='" + objPRReq.Status + "' and OEmpID='" + objPRReq.OEmpID + "' and ACRID='" + objPRReq.ACRID + "' and OfficerLevel='" + objPRReq.OLevel + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P324_SPLAttributes_OEmpID_ITID(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P324_SPLAttributes where Status='" + objPRReq.Status + "' and OEmpID='" + objPRReq.OEmpID + "' and ACRID='" + objPRReq.ACRID + "' and OfficerLevel='" + objPRReq.OLevel + "' and ITID='" + objPRReq.ITID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P324_SPLAttributes_Name(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P324_SPLAttributes where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and OEmpID='" + objPRReq.OEmpID + "' and SPLAttributesParameter='" + objPRReq.SPLAttributesParameter + "' and OfficerLevel='" + objPRReq.OLevel + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllACR_tbl_P324_SPLAttributes_OEmpID_ACRID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P324_SPLAttributes where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and OEmpID='" + objPRReq.OEmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P324_SPLAttributes_OEmpID_ADID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P324_SPLAttributes where Status='" + objPRReq.Status + "' and ADID='" + objPRReq.ADID + "' and OEmpID='" + objPRReq.OEmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp DelACR_tbl_P324_SPLAttributes_OEmpID_ACRID_OLevel(PRReq objPRReq)
        {
            string hod = "delete from ACR_tbl_P324_SPLAttributes where  OID='" + objPRReq.OID + "' and ACRID='" + objPRReq.ACRID + "' and OEmpID='" + objPRReq.OEmpID + "' and OfficerLevel='" + objPRReq.OLevel + "' and ITID='" + objPRReq.ITID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }

        //3.3 General (includes 3.3.1,3.3.2 and 3.3.3)
        // Reporting/Reviewing officer
        public PRResp AddACR_tbl_P33_General(PRReq objPRReq)
        {
            string s = "INSERT INTO ACR_tbl_P33_General (OID,FinancialYear,ACRID,EmpID,Name,StateofHealth,Integrity,GeneralAssessment,OfficerLevel,OEmpID,OName,Dated,Status) values('" + objPRReq.OID + "','" + objPRReq.FinancialYear + "','" + objPRReq.ACRID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.StateofHealth + "','" + objPRReq.Integrity + "','" + objPRReq.GeneralAssessment + "','" + objPRReq.OLevel + "','" + objPRReq.OEmpID + "','" + objPRReq.OName + "','" + objPRReq.Dated + "','" + objPRReq.Status + "')";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp UpdateACR_tbl_P33_General_ACRID(PRReq objPRReq)
        {
            string update = "update ACR_tbl_P33_General set StateofHealth='" + objPRReq.StateofHealth + "',Integrity='" + objPRReq.Integrity + "',GeneralAssessment='" + objPRReq.GeneralAssessment + "',Dated='" + objPRReq.Dated + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and OEmpID='" + objPRReq.OEmpID + "' and ADID='" + objPRReq.ADID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp getACR_tbl_P33_General_OEmpID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P33_General where Status='" + objPRReq.Status + "' and OEmpID='" + objPRReq.OEmpID + "' and ACRID='" + objPRReq.ACRID + "' and OfficerLevel='" + objPRReq.OLevel + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P33_General_Name(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P33_General where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and OEmpID='" + objPRReq.OEmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllACR_tbl_P33_General_OEmpID_ACRID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P33_General where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and OEmpID='" + objPRReq.OEmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P33_General_OEmpID_ADID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P33_General where Status='" + objPRReq.Status + "' and ADID='" + objPRReq.ADID + "' and OEmpID='" + objPRReq.OEmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp DelACR_tbl_P33_General_OEmpID_ADID(PRReq objPRReq)
        {
            string hod = "delete from ACR_tbl_P33_General where  OID='" + objPRReq.OID + "' and ADID='" + objPRReq.ADID + "' and OEmpID='" + objPRReq.OEmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }



        // Part-4 Reviewer Assessment
        // Reviewing officer
        public PRResp AddACR_tbl_P41_LengthOfService(PRReq objPRReq)
        {
            string s = "INSERT INTO ACR_tbl_P41_LengthOfService (OID,FinancialYear,ACRID,EmpID,Name,LengthOfService,OfficerLevel,OEmpID,OName,Dated,Status) values('" + objPRReq.OID + "','" + objPRReq.FinancialYear + "','" + objPRReq.ACRID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.LengthOfService + "','" + objPRReq.OLevel + "','" + objPRReq.OEmpID + "','" + objPRReq.OName + "','" + objPRReq.Dated + "','" + objPRReq.Status + "')";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp UpdateACR_tbl_P41_LengthOfService_ACRID(PRReq objPRReq)
        {
            string update = "update ACR_tbl_P41_LengthOfService set LengthOfService='" + objPRReq.LengthOfService + "',Dated='" + objPRReq.Dated + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and OEmpID='" + objPRReq.OEmpID + "' and ADID='" + objPRReq.ADID + "' and OfficerLevel='" + objPRReq.OLevel + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp getACR_tbl_P41_LengthOfService_OEmpID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P41_LengthOfService where Status='" + objPRReq.Status + "' and OEmpID='" + objPRReq.OEmpID + "' and ACRID='" + objPRReq.ACRID + "' and OfficerLevel='" + objPRReq.OLevel + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P41_LengthOfService_Name(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P41_LengthOfService where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and OEmpID='" + objPRReq.OEmpID + "'  and OfficerLevel='" + objPRReq.OLevel + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllACR_tbl_P41_LengthOfService_OEmpID_ACRID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P41_LengthOfService where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and OEmpID='" + objPRReq.OEmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P41_LengthOfService_OEmpID_ADID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P41_LengthOfService where Status='" + objPRReq.Status + "' and ADID='" + objPRReq.ADID + "' and OEmpID='" + objPRReq.OEmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P41_LengthOfService_OEmpID_OLevel(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P41_LengthOfService where Status='" + objPRReq.Status + "' and OfficerLevel='" + objPRReq.OLevel + "' and OEmpID='" + objPRReq.OEmpID + "' and ACRID='" + objPRReq.ACRID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp DelACR_tbl_P41_LengthOfService_OEmpID_ADID(PRReq objPRReq)
        {
            string hod = "delete from ACR_tbl_P41_LengthOfService where  OID='" + objPRReq.OID + "' and ADID='" + objPRReq.ADID + "' and OEmpID='" + objPRReq.OEmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }

        // Reviewing officer
        public PRResp AddACR_tbl_P42_Satisfy_RPT_Assmt(PRReq objPRReq)
        {
            string s = "INSERT INTO ACR_tbl_P42_Satisfy_RPT_Assmt (OID,FinancialYear,ACRID,EmpID,Name,RPTStatus,Reasons,OfficerLevel,OEmpID,OName,Dated,Status) values('" + objPRReq.OID + "','" + objPRReq.FinancialYear + "','" + objPRReq.ACRID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.RPTStatus + "','" + objPRReq.Reasons + "','" + objPRReq.OLevel + "','" + objPRReq.OEmpID + "','" + objPRReq.OName + "','" + objPRReq.Dated + "','" + objPRReq.Status + "')";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp UpdateACR_tbl_P42_Satisfy_RPT_Assmt_ACRID(PRReq objPRReq)
        {
            string update = "update ACR_tbl_P42_Satisfy_RPT_Assmt set RPTStatus='" + objPRReq.RPTStatus + "',Reasons='" + objPRReq.Reasons + "',Dated='" + objPRReq.Dated + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and OEmpID='" + objPRReq.OEmpID + "' and ADID='" + objPRReq.ADID + "' and OfficerLevel='" + objPRReq.OLevel + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp getACR_tbl_P42_Satisfy_RPT_Assmt_OEmpID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P42_Satisfy_RPT_Assmt where Status='" + objPRReq.Status + "' and OEmpID='" + objPRReq.OEmpID + "' and ACRID='" + objPRReq.ACRID + "' and OfficerLevel='" + objPRReq.OLevel + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P42_Satisfy_RPT_Assmt_Name(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P42_Satisfy_RPT_Assmt where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and OEmpID='" + objPRReq.OEmpID + "' and OfficerLevel='" + objPRReq.OLevel + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllACR_tbl_P42_Satisfy_RPT_Assmt_OEmpID_ACRID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P42_Satisfy_RPT_Assmt where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and OEmpID='" + objPRReq.OEmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P42_Satisfy_RPT_Assmt_OEmpID_ADID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P42_Satisfy_RPT_Assmt where Status='" + objPRReq.Status + "' and ADID='" + objPRReq.ADID + "' and OEmpID='" + objPRReq.OEmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P42_Satisfy_RPT_Assmt_OEmpID_OLevel(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P42_Satisfy_RPT_Assmt where Status='" + objPRReq.Status + "' and OfficerLevel='" + objPRReq.OLevel + "' and OEmpID='" + objPRReq.OEmpID + "' and ACRID='" + objPRReq.ACRID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp DelACR_tbl_P42_Satisfy_RPT_Assmt_OEmpID_ADID(PRReq objPRReq)
        {
            string hod = "delete from ACR_tbl_P42_Satisfy_RPT_Assmt where  OID='" + objPRReq.OID + "' and ADID='" + objPRReq.ADID + "' and OEmpID='" + objPRReq.OEmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }

        // Reviewing officer
        public PRResp AddACR_tbl_P43_PenPicture(PRReq objPRReq)
        {
            string s = "INSERT INTO ACR_tbl_P43_PenPicture (OID,FinancialYear,ACRID,EmpID,Name,Reasons,OfficerLevel,OEmpID,OName,Dated,Status) values('" + objPRReq.OID + "','" + objPRReq.FinancialYear + "','" + objPRReq.ACRID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.Reasons + "','" + objPRReq.OLevel + "','" + objPRReq.OEmpID + "','" + objPRReq.OName + "','" + objPRReq.Dated + "','" + objPRReq.Status + "')";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp UpdateACR_tbl_P43_PenPicture_ACRID(PRReq objPRReq)
        {
            string update = "update ACR_tbl_P43_PenPicture set Reasons='" + objPRReq.Reasons + "',Dated='" + objPRReq.Dated + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and OEmpID='" + objPRReq.OEmpID + "' and ADID='" + objPRReq.ADID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp getACR_tbl_P43_PenPicture_OEmpID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P43_PenPicture where Status='" + objPRReq.Status + "' and OEmpID='" + objPRReq.OEmpID + "' and ACRID='" + objPRReq.ACRID + "' and OfficerLevel='" + objPRReq.OLevel + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P43_PenPicture_Name(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P43_PenPicture where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and OEmpID='" + objPRReq.OEmpID + "' and OfficerLevel='" + objPRReq.OLevel + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllACR_tbl_P43_PenPicture_OEmpID_ACRID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P43_PenPicture where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and OEmpID='" + objPRReq.OEmpID + "' and OfficerLevel='" + objPRReq.OLevel + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P43_PenPicture_OEmpID_ADID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P43_PenPicture where Status='" + objPRReq.Status + "' and ADID='" + objPRReq.ADID + "' and OEmpID='" + objPRReq.OEmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P43_PenPicture_OEmpID_OLevel(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P43_PenPicture where Status='" + objPRReq.Status + "' and OfficerLevel='" + objPRReq.OLevel + "' and OEmpID='" + objPRReq.OEmpID + "' and ACRID='" + objPRReq.ACRID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp DelACR_tbl_P43_PenPicture_OEmpID_ADID(PRReq objPRReq)
        {
            string hod = "delete from ACR_tbl_P43_PenPicture where  OID='" + objPRReq.OID + "' and ADID='" + objPRReq.ADID + "' and OEmpID='" + objPRReq.OEmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }


        // Reporting/Reviewing officerACR_tbl_P441_Rev_Off_WorkOutPut
        public PRResp AddACR_tbl_P441_Rev_Off_WorkOutPut(PRReq objPRReq)
        {
            string s = "INSERT INTO ACR_tbl_P441_Rev_Off_WorkOutPut (OID,FinancialYear,ACRID,EmpID,Name,ITID,WorkOutputParameter,Grading,Grade,OfficerLevel,OEmpID,OName,Dated,Status) values('" + objPRReq.OID + "','" + objPRReq.FinancialYear + "','" + objPRReq.ACRID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.ITID + "','" + objPRReq.WorkOutputParameter + "','" + objPRReq.Grading + "','" + objPRReq.Grade + "','" + objPRReq.OLevel + "','" + objPRReq.OEmpID + "','" + objPRReq.OName + "','" + objPRReq.Dated + "','" + objPRReq.Status + "')";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp UpdateACR_tbl_P441_Rev_Off_WorkOutPut_ACRID(PRReq objPRReq)
        {
            string update = "update ACR_tbl_P441_Rev_Off_WorkOutPut set WorkOutputParameter='" + objPRReq.WorkOutputParameter + "', Grading='" + objPRReq.Grading + "',Grade='" + objPRReq.Grade + "', Dated='" + objPRReq.Dated + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and OEmpID='" + objPRReq.OEmpID + "' and OfficerLevel='" + objPRReq.OLevel + "' and ITID='" + objPRReq.ITID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp getACR_tbl_P441_Rev_Off_WorkOutPut_OEmpID(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P441_Rev_Off_WorkOutPut where Status='" + objPRReq.Status + "' and OEmpID='" + objPRReq.OEmpID + "' and ACRID='" + objPRReq.ACRID + "' and OfficerLevel='" + objPRReq.OLevel + "' order by ITID Asc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P441_Rev_Off_WorkOutPut_OEmpID_Sum(PRReq objPRReq)
        {
            string s = "select Sum(Grade) as Sum, Avg(Grade) as Avg from ACR_tbl_P441_Rev_Off_WorkOutPut where Status='" + objPRReq.Status + "' and OEmpID='" + objPRReq.OEmpID + "' and ACRID='" + objPRReq.ACRID + "' and OfficerLevel='" + objPRReq.OLevel + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P441_Rev_Off_WorkOutPut_OEmpID_ITID(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P441_Rev_Off_WorkOutPut where Status='" + objPRReq.Status + "' and OEmpID='" + objPRReq.OEmpID + "' and ACRID='" + objPRReq.ACRID + "' and OfficerLevel='" + objPRReq.OLevel + "' and ITID='" + objPRReq.ITID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P441_Rev_Off_WorkOutPut_Name(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P441_Rev_Off_WorkOutPut where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and OEmpID='" + objPRReq.OEmpID + "' and WorkOutputParameter='" + objPRReq.WorkOutputParameter + "' and OfficerLevel='" + objPRReq.OLevel + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllACR_tbl_P441_Rev_Off_WorkOutPut_OEmpID_ACRID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P441_Rev_Off_WorkOutPut where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and OEmpID='" + objPRReq.OEmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P441_Rev_Off_WorkOutPut_OEmpID_ADID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P441_Rev_Off_WorkOutPut where Status='" + objPRReq.Status + "' and ADID='" + objPRReq.ADID + "' and OEmpID='" + objPRReq.OEmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp DelACR_tbl_P441_Rev_Off_WorkOutPut_OEmpID_ACRID_OLevel(PRReq objPRReq)
        {
            string hod = "delete from ACR_tbl_P441_Rev_Off_WorkOutPut where  OID='" + objPRReq.OID + "' and ACRID='" + objPRReq.ACRID + "' and OEmpID='" + objPRReq.OEmpID + "' and OfficerLevel='" + objPRReq.OLevel + "' and ITID='" + objPRReq.ITID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }

        // Reporting/Reviewing officer
        public PRResp AddACR_tbl_P442_Rev_Off_FunctionalCompetency(PRReq objPRReq)
        {
            string s = "INSERT INTO ACR_tbl_P442_Rev_Off_FunctionalCompetency (OID,FinancialYear,ACRID,EmpID,Name,ITID,FuntionalCompetencyParameter,Grading,Grade,OfficerLevel,OEmpID,OName,Dated,Status) values('" + objPRReq.OID + "','" + objPRReq.FinancialYear + "','" + objPRReq.ACRID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.ITID + "','" + objPRReq.FuntionalCompetencyParameter + "','" + objPRReq.Grading + "','" + objPRReq.Grade + "','" + objPRReq.OLevel + "','" + objPRReq.OEmpID + "','" + objPRReq.OName + "','" + objPRReq.Dated + "','" + objPRReq.Status + "')";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp UpdateACR_tbl_P442_Rev_Off_FunctionalCompetency_ACRID(PRReq objPRReq)
        {
            string update = "update ACR_tbl_P442_Rev_Off_FunctionalCompetency set FuntionalCompetencyParameter='" + objPRReq.FuntionalCompetencyParameter + "', Grading='" + objPRReq.Grading + "',Grade='" + objPRReq.Grade + "', Dated='" + objPRReq.Dated + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and OEmpID='" + objPRReq.OEmpID + "' and OfficerLevel='" + objPRReq.OLevel + "' and ITID='" + objPRReq.ITID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp getACR_tbl_P442_Rev_Off_FunctionalCompetency_OEmpID(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P442_Rev_Off_FunctionalCompetency where Status='" + objPRReq.Status + "' and OEmpID='" + objPRReq.OEmpID + "' and ACRID='" + objPRReq.ACRID + "' and OfficerLevel='" + objPRReq.OLevel + "' order by ITID Asc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P442_Rev_Off_FunctionalCompetency_OEmpID_Sum(PRReq objPRReq)
        {
            string s = "select Sum(Grade) as Sum, Avg(Grade) as Avg from ACR_tbl_P442_Rev_Off_FunctionalCompetency where Status='" + objPRReq.Status + "' and OEmpID='" + objPRReq.OEmpID + "' and ACRID='" + objPRReq.ACRID + "' and OfficerLevel='" + objPRReq.OLevel + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P442_Rev_Off_FunctionalCompetency_OEmpID_ITID(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P442_Rev_Off_FunctionalCompetency where Status='" + objPRReq.Status + "' and OEmpID='" + objPRReq.OEmpID + "' and ACRID='" + objPRReq.ACRID + "' and OfficerLevel='" + objPRReq.OLevel + "' and ITID='" + objPRReq.ITID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P442_Rev_Off_FunctionalCompetency_Name(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P442_Rev_Off_FunctionalCompetency where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and OEmpID='" + objPRReq.OEmpID + "' and FuntionalCompetencyParameter='" + objPRReq.FuntionalCompetencyParameter + "' and OfficerLevel='" + objPRReq.OLevel + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllACR_tbl_P442_Rev_Off_FunctionalCompetency_OEmpID_ACRID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P442_Rev_Off_FunctionalCompetency where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and OEmpID='" + objPRReq.OEmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P442_Rev_Off_FunctionalCompetency_OEmpID_ADID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P442_Rev_Off_FunctionalCompetency where Status='" + objPRReq.Status + "' and ADID='" + objPRReq.ADID + "' and OEmpID='" + objPRReq.OEmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp DelACR_tbl_P442_Rev_Off_FunctionalCompetency_OEmpID_ACRID_OLevel(PRReq objPRReq)
        {
            string hod = "delete from ACR_tbl_P442_Rev_Off_FunctionalCompetency where  OID='" + objPRReq.OID + "' and ACRID='" + objPRReq.ACRID + "' and OEmpID='" + objPRReq.OEmpID + "' and OfficerLevel='" + objPRReq.OLevel + "' and ITID='" + objPRReq.ITID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }


        // Reporting/Reviewing officer
        public PRResp AddACR_tbl_P443_Rev_Off_PerAttributes(PRReq objPRReq)
        {
            string s = "INSERT INTO ACR_tbl_P443_Rev_Off_PerAttributes (OID,FinancialYear,ACRID,EmpID,Name,ITID,PerAttributesParameter,Grading,Grade,OfficerLevel,OEmpID,OName,Dated,Status) values('" + objPRReq.OID + "','" + objPRReq.FinancialYear + "','" + objPRReq.ACRID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.ITID + "','" + objPRReq.PerAttributesParameter + "','" + objPRReq.Grading + "','" + objPRReq.Grade + "','" + objPRReq.OLevel + "','" + objPRReq.OEmpID + "','" + objPRReq.OName + "','" + objPRReq.Dated + "','" + objPRReq.Status + "')";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp UpdateACR_tbl_P443_Rev_Off_PerAttributes_ACRID(PRReq objPRReq)
        {
            string update = "update ACR_tbl_P443_Rev_Off_PerAttributes set PerAttributesParameter='" + objPRReq.PerAttributesParameter + "', Grading='" + objPRReq.Grading + "',Grade='" + objPRReq.Grade + "', Dated='" + objPRReq.Dated + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and OEmpID='" + objPRReq.OEmpID + "' and OfficerLevel='" + objPRReq.OLevel + "' and ITID='" + objPRReq.ITID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp getACR_tbl_P443_Rev_Off_PerAttributes_OEmpID(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P443_Rev_Off_PerAttributes where Status='" + objPRReq.Status + "' and OEmpID='" + objPRReq.OEmpID + "' and ACRID='" + objPRReq.ACRID + "' and OfficerLevel='" + objPRReq.OLevel + "' order by ITID Asc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P443_Rev_Off_PerAttributes_OEmpID_Sum(PRReq objPRReq)
        {
            string s = "select Sum(Grade) as Sum, Avg(Grade) as Avg from ACR_tbl_P443_Rev_Off_PerAttributes where Status='" + objPRReq.Status + "' and OEmpID='" + objPRReq.OEmpID + "' and ACRID='" + objPRReq.ACRID + "' and OfficerLevel='" + objPRReq.OLevel + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P443_Rev_Off_PerAttributes_OEmpID_ITID(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P443_Rev_Off_PerAttributes where Status='" + objPRReq.Status + "' and OEmpID='" + objPRReq.OEmpID + "' and ACRID='" + objPRReq.ACRID + "' and OfficerLevel='" + objPRReq.OLevel + "' and ITID='" + objPRReq.ITID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P443_Rev_Off_PerAttributes_Name(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P443_Rev_Off_PerAttributes where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and OEmpID='" + objPRReq.OEmpID + "' and PerAttributesParameter='" + objPRReq.PerAttributesParameter + "' and OfficerLevel='" + objPRReq.OLevel + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllACR_tbl_P443_Rev_Off_PerAttributes_OEmpID_ACRID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P443_Rev_Off_PerAttributes where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and OEmpID='" + objPRReq.OEmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P443_Rev_Off_PerAttributes_OEmpID_ADID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P443_Rev_Off_PerAttributes where Status='" + objPRReq.Status + "' and ADID='" + objPRReq.ADID + "' and OEmpID='" + objPRReq.OEmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp DelACR_tbl_P443_Rev_Off_PerAttributes_OEmpID_ACRID_OLevel(PRReq objPRReq)
        {
            string hod = "delete from ACR_tbl_P443_Rev_Off_PerAttributes where  OID='" + objPRReq.OID + "' and ACRID='" + objPRReq.ACRID + "' and OEmpID='" + objPRReq.OEmpID + "' and OfficerLevel='" + objPRReq.OLevel + "' and ITID='" + objPRReq.ITID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }

        // Reporting/Reviewing officer
        public PRResp AddACR_tbl_P444_Rev_Off_SPLAttributes(PRReq objPRReq)
        {
            string s = "INSERT INTO ACR_tbl_P444_Rev_Off_SPLAttributes (OID,FinancialYear,ACRID,EmpID,Name,ITID,SPLAttributesParameter,Grading,Grade,OfficerLevel,OEmpID,OName,Dated,Status) values('" + objPRReq.OID + "','" + objPRReq.FinancialYear + "','" + objPRReq.ACRID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.ITID + "','" + objPRReq.SPLAttributesParameter + "','" + objPRReq.Grading + "','" + objPRReq.Grade + "','" + objPRReq.OLevel + "','" + objPRReq.OEmpID + "','" + objPRReq.OName + "','" + objPRReq.Dated + "','" + objPRReq.Status + "')";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp UpdateACR_tbl_P444_Rev_Off_SPLAttributes_ACRID(PRReq objPRReq)
        {
            string update = "update ACR_tbl_P444_Rev_Off_SPLAttributes set SPLAttributesParameter='" + objPRReq.SPLAttributesParameter + "', Grading='" + objPRReq.Grading + "',Grade='" + objPRReq.Grade + "', Dated='" + objPRReq.Dated + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and OEmpID='" + objPRReq.OEmpID + "' and OfficerLevel='" + objPRReq.OLevel + "' and ITID='" + objPRReq.ITID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp getACR_tbl_P444_Rev_Off_SPLAttributes_OEmpID(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P444_Rev_Off_SPLAttributes where Status='" + objPRReq.Status + "' and OEmpID='" + objPRReq.OEmpID + "' and ACRID='" + objPRReq.ACRID + "' and OfficerLevel='" + objPRReq.OLevel + "' order by ITID Asc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P444_Rev_Off_SPLAttributes_OEmpID_Sum(PRReq objPRReq)
        {
            string s = "select Sum(Grade) as Sum, Avg(Grade) as Avg from ACR_tbl_P444_Rev_Off_SPLAttributes where Status='" + objPRReq.Status + "' and OEmpID='" + objPRReq.OEmpID + "' and ACRID='" + objPRReq.ACRID + "' and OfficerLevel='" + objPRReq.OLevel + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P444_Rev_Off_SPLAttributes_OEmpID_ITID(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P444_Rev_Off_SPLAttributes where Status='" + objPRReq.Status + "' and OEmpID='" + objPRReq.OEmpID + "' and ACRID='" + objPRReq.ACRID + "' and OfficerLevel='" + objPRReq.OLevel + "' and ITID='" + objPRReq.ITID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P444_Rev_Off_SPLAttributes_Name(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P444_Rev_Off_SPLAttributes where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and OEmpID='" + objPRReq.OEmpID + "' and SPLAttributesParameter='" + objPRReq.SPLAttributesParameter + "' and OfficerLevel='" + objPRReq.OLevel + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllACR_tbl_P444_Rev_Off_SPLAttributes_OEmpID_ACRID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P444_Rev_Off_SPLAttributes where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and OEmpID='" + objPRReq.OEmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P444_Rev_Off_SPLAttributes_OEmpID_ADID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P444_Rev_Off_SPLAttributes where Status='" + objPRReq.Status + "' and ADID='" + objPRReq.ADID + "' and OEmpID='" + objPRReq.OEmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp DelACR_tbl_P444_Rev_Off_SPLAttributes_OEmpID_ACRID_OLevel(PRReq objPRReq)
        {
            string hod = "delete from ACR_tbl_P444_Rev_Off_SPLAttributes where  OID='" + objPRReq.OID + "' and ACRID='" + objPRReq.ACRID + "' and OEmpID='" + objPRReq.OEmpID + "' and OfficerLevel='" + objPRReq.OLevel + "' and ITID='" + objPRReq.ITID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }

        // Part-5 Accepting Authority Assessment

        public PRResp AddACR_tbl_P51_LengthOfService(PRReq objPRReq)
        {
            string s = "INSERT INTO ACR_tbl_P51_LengthOfService (OID,FinancialYear,ACRID,EmpID,Name,LengthOfService,OfficerLevel,OEmpID,OName,Dated,Status) values('" + objPRReq.OID + "','" + objPRReq.FinancialYear + "','" + objPRReq.ACRID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.LengthOfService + "','" + objPRReq.OLevel + "','" + objPRReq.OEmpID + "','" + objPRReq.OName + "','" + objPRReq.Dated + "','" + objPRReq.Status + "')";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp UpdateACR_tbl_P51_LengthOfService_ACRID(PRReq objPRReq)
        {
            string update = "update ACR_tbl_P51_LengthOfService set LengthOfService='" + objPRReq.LengthOfService + "',Dated='" + objPRReq.Dated + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and OEmpID='" + objPRReq.OEmpID + "' and ADID='" + objPRReq.ADID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp getACR_tbl_P51_LengthOfService_OEmpID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P51_LengthOfService where Status='" + objPRReq.Status + "' and OEmpID='" + objPRReq.OEmpID + "' and ACRID='" + objPRReq.ACRID + "' and OfficerLevel='" + objPRReq.OLevel + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P51_LengthOfService_Name(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P51_LengthOfService where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and OEmpID='" + objPRReq.OEmpID + "' and OfficerLevel='" + objPRReq.OLevel + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllACR_tbl_P51_LengthOfService_OEmpID_ACRID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P51_LengthOfService where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and OEmpID='" + objPRReq.OEmpID + "' and OfficerLevel='" + objPRReq.OLevel + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P51_LengthOfService_OEmpID_ADID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P51_LengthOfService where Status='" + objPRReq.Status + "' and ADID='" + objPRReq.ADID + "' and OEmpID='" + objPRReq.OEmpID + "' and OfficerLevel='" + objPRReq.OLevel + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp DelACR_tbl_P51_LengthOfService_OEmpID_ADID(PRReq objPRReq)
        {
            string hod = "delete from ACR_tbl_P51_LengthOfService where  OID='" + objPRReq.OID + "' and ADID='" + objPRReq.ADID + "' and OEmpID='" + objPRReq.OEmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }

        // Reviewing officer
        public PRResp AddACR_tbl_P52_Satisfy_RPT_Assmt(PRReq objPRReq)
        {
            string s = "INSERT INTO ACR_tbl_P52_Satisfy_RPT_Assmt (OID,FinancialYear,ACRID,EmpID,Name,RPTStatus,Reasons,OfficerLevel,OEmpID,OName,Dated,Status) values('" + objPRReq.OID + "','" + objPRReq.FinancialYear + "','" + objPRReq.ACRID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.RPTStatus + "','" + objPRReq.Reasons + "','" + objPRReq.OLevel + "','" + objPRReq.OEmpID + "','" + objPRReq.OName + "','" + objPRReq.Dated + "','" + objPRReq.Status + "')";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp UpdateACR_tbl_P52_Satisfy_RPT_Assmt_ACRID(PRReq objPRReq)
        {
            string update = "update ACR_tbl_P52_Satisfy_RPT_Assmt set RPTStatus='" + objPRReq.RPTStatus + "',Reasons='" + objPRReq.Reasons + "',Dated='" + objPRReq.Dated + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and OEmpID='" + objPRReq.OEmpID + "' and ADID='" + objPRReq.ADID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp getACR_tbl_P52_Satisfy_RPT_Assmt_OEmpID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P52_Satisfy_RPT_Assmt where Status='" + objPRReq.Status + "' and OEmpID='" + objPRReq.OEmpID + "' and ACRID='" + objPRReq.ACRID + "' and OfficerLevel='" + objPRReq.OLevel + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P52_Satisfy_RPT_Assmt_Name(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P52_Satisfy_RPT_Assmt where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and OEmpID='" + objPRReq.OEmpID + "' and OfficerLevel='" + objPRReq.OLevel + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllACR_tbl_P52_Satisfy_RPT_Assmt_OEmpID_ACRID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P52_Satisfy_RPT_Assmt where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and OEmpID='" + objPRReq.OEmpID + "' and OfficerLevel='" + objPRReq.OLevel + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P52_Satisfy_RPT_Assmt_OEmpID_ADID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P52_Satisfy_RPT_Assmt where Status='" + objPRReq.Status + "' and ADID='" + objPRReq.ADID + "' and OEmpID='" + objPRReq.OEmpID + "' and OfficerLevel='" + objPRReq.OLevel + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp DelACR_tbl_P52_Satisfy_RPT_Assmt_OEmpID_ADID(PRReq objPRReq)
        {
            string hod = "delete from ACR_tbl_P52_Satisfy_RPT_Assmt where  OID='" + objPRReq.OID + "' and ADID='" + objPRReq.ADID + "' and OEmpID='" + objPRReq.OEmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }

        // Reviewing officer
        public PRResp AddACR_tbl_P53_PenPicture(PRReq objPRReq)
        {
            string s = "INSERT INTO ACR_tbl_P53_PenPicture (OID,FinancialYear,ACRID,EmpID,Name,Reasons,OfficerLevel,OEmpID,OName,Dated,Status) values('" + objPRReq.OID + "','" + objPRReq.FinancialYear + "','" + objPRReq.ACRID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.Reasons + "','" + objPRReq.OLevel + "','" + objPRReq.OEmpID + "','" + objPRReq.OName + "','" + objPRReq.Dated + "','" + objPRReq.Status + "')";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp UpdateACR_tbl_P53_PenPicture_ACRID(PRReq objPRReq)
        {
            string update = "update ACR_tbl_P53_PenPicture set Reasons='" + objPRReq.Reasons + "',Dated='" + objPRReq.Dated + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and OEmpID='" + objPRReq.OEmpID + "' and ADID='" + objPRReq.ADID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp getACR_tbl_P53_PenPicture_OEmpID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P53_PenPicture where Status='" + objPRReq.Status + "' and OEmpID='" + objPRReq.OEmpID + "' and ACRID='" + objPRReq.ACRID + "' and OfficerLevel='" + objPRReq.OLevel + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P53_PenPicture_Name(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P53_PenPicture where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and OEmpID='" + objPRReq.OEmpID + "' and OfficerLevel='" + objPRReq.OLevel + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllACR_tbl_P53_PenPicture_OEmpID_ACRID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P53_PenPicture where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and OEmpID='" + objPRReq.OEmpID + "' and OfficerLevel='" + objPRReq.OLevel + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P53_PenPicture_OEmpID_ADID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P53_PenPicture where Status='" + objPRReq.Status + "' and ADID='" + objPRReq.ADID + "' and OEmpID='" + objPRReq.OEmpID + "' and OfficerLevel='" + objPRReq.OLevel + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp DelACR_tbl_P53_PenPicture_OEmpID_ADID(PRReq objPRReq)
        {
            string hod = "delete from ACR_tbl_P53_PenPicture where  OID='" + objPRReq.OID + "' and ADID='" + objPRReq.ADID + "' and OEmpID='" + objPRReq.OEmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }

        // Accepting officer
        public PRResp AddACR_tbl_P54_FinalGrading(PRReq objPRReq)
        {
            string s = "INSERT INTO ACR_tbl_P54_FinalGrading (OID,FinancialYear,ACRID,EmpID,Name,Grade,Grading,OfficerLevel,OEmpID,OName,Dated,Status) values('" + objPRReq.OID + "','" + objPRReq.FinancialYear + "','" + objPRReq.ACRID + "','" + objPRReq.EmpID + "','" + objPRReq.Name + "','" + objPRReq.Grade + "','" + objPRReq.Grading + "','" + objPRReq.OLevel + "','" + objPRReq.OEmpID + "','" + objPRReq.OName + "','" + objPRReq.Dated + "','" + objPRReq.Status + "')";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp UpdateACR_tbl_P54_FinalGrading_ACRID(PRReq objPRReq)
        {
            string update = "update ACR_tbl_P54_FinalGrading set Grade='" + objPRReq.Grade + "',Grading='" + objPRReq.Grading + "', Dated='" + objPRReq.Dated + "' where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and OEmpID='" + objPRReq.OEmpID + "' and ADID='" + objPRReq.ADID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp getACR_tbl_P54_FinalGrading_OEmpID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P54_FinalGrading where Status='" + objPRReq.Status + "' and OEmpID='" + objPRReq.OEmpID + "' and ACRID='" + objPRReq.ACRID + "' and OfficerLevel='" + objPRReq.OLevel + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P54_FinalGrading_Name(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P54_FinalGrading where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and OEmpID='" + objPRReq.OEmpID + "' and OfficerLevel='" + objPRReq.OLevel + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllACR_tbl_P54_FinalGrading_OEmpID_ACRID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P54_FinalGrading where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and OEmpID='" + objPRReq.OEmpID + "' and OfficerLevel='" + objPRReq.OLevel + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllACR_tbl_P54_FinalGrading_ACRID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P54_FinalGrading where Status='" + objPRReq.Status + "' and ACRID='" + objPRReq.ACRID + "' and OfficerLevel='" + objPRReq.OLevel + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getACR_tbl_P54_FinalGrading_OEmpID_ADID(PRReq objPRReq)
        {
            string s = "select distinct * from ACR_tbl_P54_FinalGrading where Status='" + objPRReq.Status + "' and ADID='" + objPRReq.ADID + "' and OEmpID='" + objPRReq.OEmpID + "' and OfficerLevel='" + objPRReq.OLevel + "'  ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp DelACR_tbl_P54_FinalGrading_OEmpID_ADID(PRReq objPRReq)
        {
            string hod = "delete from ACR_tbl_P54_FinalGrading where  OID='" + objPRReq.OID + "' and ADID='" + objPRReq.ADID + "' and OEmpID='" + objPRReq.OEmpID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }

        //Upload Video Tutorial
        public PRResp AddVidioTutorial(PRReq objPRReq)
        {
            string s = "INSERT INTO tbl_VideoFiles (Description,FileName,ContentType,Status) values('" + objPRReq.Description + "','" + objPRReq.FileName + "','" + objPRReq.ContentType + "','" + objPRReq.Status + "')";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllVidioTutorials(PRReq objPRReq)
        {
            string s = "select * from tbl_VideoFiles order by ID Desc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp UpdateVidioTutorial(PRReq objPRReq)
        {
            string update = "update tbl_VideoFiles set Status='" + objPRReq.Status + "' where ID='" + objPRReq.DID + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        // eACRAdmin Dashboard
        public PRResp getAllACRs_ACRID_Dashboard(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P1_PersonalData where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and FinancialYear='" + objPRReq.FinancialYear + "' order by FinancialYear,EmpID Asc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAll_atRPTOfficer_ACRs_ACRID_Dashboard(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P1_PersonalData where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and FinancialYear='" + objPRReq.FinancialYear + "' and OfficerLevel is NOT NULL and Flag_RPTG_OFFICER='0' and Flag_REVG_OFFICER='0' and Flag_ACPT_OFFICER='0'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAll_atREVOfficer_ACRs_ACRID_Dashboard(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P1_PersonalData where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and FinancialYear='" + objPRReq.FinancialYear + "' and OfficerLevel is NOT NULL and Flag_RPTG_OFFICER='1' and Flag_REVG_OFFICER='0' and Flag_ACPT_OFFICER='0'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAll_atACPTOfficer_ACRs_ACRID_Dashboard(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P1_PersonalData where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and FinancialYear='" + objPRReq.FinancialYear + "' and OfficerLevel is NOT NULL and Flag_RPTG_OFFICER='1' and Flag_REVG_OFFICER='1' and Flag_ACPT_OFFICER='0'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAll_Completed_ACRs_ACRID_Dashboard(PRReq objPRReq)
        {
            string s = "select * from ACR_tbl_P1_PersonalData where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and FinancialYear='" + objPRReq.FinancialYear + "' and OfficerLevel is NOT NULL and Flag_RPTG_OFFICER='1' and Flag_REVG_OFFICER='1' and Flag_ACPT_OFFICER='1'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        // CPR SMS
        public PRResp AddAllCPLMobileNos(PRReq objPRReq)
        {
            string s = "INSERT INTO CPR_tbl_SMS_PanchayatiRaj (Mobile,StateFileName,Message,State,Status,Sent,DeliveryID) values('" + objPRReq.Mobile + "','" + objPRReq.FileName + "',N'" + objPRReq.Message + "','" + objPRReq.State + "','" + objPRReq.Status + "','" + objPRReq.Flag1 + "','" + objPRReq.RPTStatus + "')";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp AddAllCPR_Repeated_MobileNos(PRReq objPRReq)
        {
            string s = "INSERT INTO CPR_tbl_SMS_Repeatednos_PanchayatiRaj (Mobile,StateFileName,Message,State,Status,Sent,DeliveryID) values('" + objPRReq.Mobile + "','" + objPRReq.FileName + "',N'" + objPRReq.Message + "','" + objPRReq.State + "','" + objPRReq.Status + "','" + objPRReq.Flag1 + "','" + objPRReq.RPTStatus + "')";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllStateFileNames(PRReq objPRReq)
        {
            string s = "select distinct State from CPR_tbl_SMS_PanchayatiRaj where Status='" + objPRReq.Status + "' order by State ASC";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllMobileNos(PRReq objPRReq)
        {
            string s = "select * from CPR_tbl_SMS_PanchayatiRaj where Status='" + objPRReq.Status + "' and Sent='0' and State='" + objPRReq.State + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAll_NonSent_MobileNos(PRReq objPRReq)
        {
            string s = "select * from CPR_tbl_SMS_PanchayatiRaj where Status='" + objPRReq.Status + "' and Sent='0' and Mobile='" + objPRReq.Mobile + "' and State='" + objPRReq.State + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp get_repted_MobileNos(PRReq objPRReq)
        {
            string s = "select * from CPR_tbl_SMS_PanchayatiRaj where Status='" + objPRReq.Status + "' and Mobile='" + objPRReq.Mobile + "'  and StateFileName='" + objPRReq.FileName + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp UpdateSent__MobileNos(PRReq objPRReq)
        {
            string update = "update CPR_tbl_SMS_PanchayatiRaj set Sent='" + objPRReq.Flag1 + "',DeliveryID='" + objPRReq.RPTStatus + "', Dated='" + DateTime.Now + "' where Mobile='" + objPRReq.Mobile + "'  and StateFileName='" + objPRReq.FileName + "'";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }

        // e-Certificate
        public PRResp uploadParticipantData(PRReq objPRReq)
        {
            //string insert = "insert into tbl_eCertificate_ParticipantsData (RegID,OID,EmpID,Title,Duration,Name,Email,Designation,Mobile,Organization,DisplayName,CoordinatorSign,DGSign,Status,Dated,Sent) values('"+objPRReq.RPCode +"','" + objPRReq.OID + "','" + objPRReq.EmpID + "','" + objPRReq.Title + "','" + objPRReq.Duration + "','" + objPRReq.Name + "','" + objPRReq.Email + "','"+objPRReq.Designation+"','"+objPRReq.Pho+"','"+objPRReq.OrgName+"','"+objPRReq.OEmpName+"','"+objPRReq.SLFileName+"','"+objPRReq.CLFileName+"','" + objPRReq.Status + "','"+DateTime.Now+"','0')";
            string insert = "insert into tbl_eCertificate_ParticipantsData (RegID,OID,EmpID,Title,Duration,Name,Email,Designation,Mobile,Organization,DisplayName,CoordinatorSign,DGSign,CoordinatorName,Status,Dated,Sent) values('" + objPRReq.RPCode + "','1','" + objPRReq.EmpID + "','" + objPRReq.Title + "','" + objPRReq.Duration + "','" + objPRReq.Name + "','" + objPRReq.Email + "','" + objPRReq.Designation + "','" + objPRReq.Pho + "','" + objPRReq.OrgName + "','" + objPRReq.OEmpName + "','" + objPRReq.SLFileName + "','" + objPRReq.CLFileName + "','" + objPRReq.OName + "','" + objPRReq.Status + "','" + DateTime.Now + "','0')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getParticipantData_name(PRReq objPRReq)
        {
            string s = "select * from tbl_eCertificate_ParticipantsData where Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' and Name='" + objPRReq.Name + "' and Email='" + objPRReq.Email + "' and Mobile='" + objPRReq.Mobile + "' and Duration='" + objPRReq.Duration + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getParticipantData_Sent(PRReq objPRReq)
        {
            string s = "select * from tbl_eCertificate_ParticipantsData where Status='" + objPRReq.Status + "'  and EmpID='" + objPRReq.EmpID + "' and Sent='" + objPRReq.Flag1 + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getParticipant_Duration_Sent(PRReq objPRReq)
        {
            string s = "select distinct Duration from tbl_eCertificate_ParticipantsData where Status='" + objPRReq.Status + "'  and EmpID='" + objPRReq.EmpID + "' order by Duration Asc ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllParticipants_Duration(PRReq objPRReq)
        {
            string s = "select distinct * from tbl_eCertificate_ParticipantsData where Status='" + objPRReq.Status + "'  and EmpID='" + objPRReq.EmpID + "' and Duration='" + objPRReq.Duration + "' order by Name Asc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getParticipantData_Preview(PRReq objPRReq)
        {
            string s = "select * from tbl_eCertificate_ParticipantsData where ID='" + objPRReq.ID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp DelParticipantData(PRReq objPRReq)
        {
            string hod = "delete from tbl_eCertificate_ParticipantsData where  OID='1' and ID='" + objPRReq.ID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }
        public PRResp getParticipantRegSNo(PRReq objPRReq)
        {
            string s = "select max(" + objPRReq.ColumnName + ") from tbl_eCertificate_ParticipantsData where OID='1' and Status='" + objPRReq.Status + "' ";
            objPRResp.SingleValue = Connections.GetSingleValue(s);
            return objPRResp;
        }
    }
}