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
        public PRResp AdminLogin(PRReq objPRReq)
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
        public PRResp EmpLogin(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Employee where  EmpID='" + objPRReq.EmpID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp ProjStaffLogin(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_ProjectStaff where EmpID='" + objPRReq.EmpID + "'  and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp SGLogin(PRReq objPRReq)
        {
            string s = "select * from Security_tbl_SecurityGuard where SGNo='" + objPRReq.SGNO + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getDepartments(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Department where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' order by DeptID Asc ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp SearchEmpNamebyGroup(PRReq objPRReq)
        {
            string s = "select distinct Name,EmpID from PR_tbl_Employee where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and EmpGroup='" + objPRReq.EmpGroup + "' and Name like'%" + objPRReq.Name + "%' order by Name Asc";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp SearchPSEmpDetails_EmpID(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_ProjectStaff where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and Name like '%" + objPRReq.Name + "%'";
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
        public PRResp getEmployee_EmpID_DID(PRReq objPRReq)
        {
            string s = "(select EmpID,Name,DID,DeptID,Design,Photo,Email,Mobile,RoomNo,Floor,Block from PR_tbl_Employee  where Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' and OID='" + objPRReq.OID + "')union(select EmpID,Name,DID,DeptID,Design,Photo,Email,Mobile,RoomNo,Floor,Block from PR_tbl_ProjectStaff  where Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' and OID='" + objPRReq.OID + "') ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getEmp_MonthlySalayByEmpID_Status(PRReq objPRReq)
        {
            string s = "select * from PR_tbl_Employee_Master_Salary where OID='" + objPRReq.OID + "' and EmpID='" + objPRReq.EmpID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAdmin_Roles_EmpID(PRReq objPRReq)
        {
            string s = "select * from tbl_Admin where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and EmpID='" + objPRReq.EmpID + "' ";
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

        // Models/Manufacturers Bhubhanshu Gurjar START

        public PRResp getAllManufacturers(PRReq objPRReq)
        {
            string s = "select * from CIT_tbl_Manufacturer";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp AddManufacturers(PRReq objPRReq)
        {
            string insert = "insert into CIT_tbl_Manufacturer (Name) values('" + objPRReq.Manufacturer + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getManufacturersByName(PRReq objPRReq)
        {
            string s = "select * from CIT_tbl_Manufacturer where Name='" + objPRReq.Manufacturer + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getManufacturerByMID(PRReq objPRReq)
        {
            string s = "select * from CIT_tbl_Manufacturer where MID='" + objPRReq.ID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp EditManufacturerByMID(PRReq objPRReq)
        {
            string update = "update CIT_tbl_Manufacturer set Name='" + objPRReq.Manufacturer + "' where MID='" + objPRReq.ID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp DelManufacturers(PRReq objPRReq)
        {
            string hod = "delete from CIT_tbl_Manufacturer where MID='" + objPRReq.ID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }
        public PRResp AddModel(PRReq objPRReq)
        {
            string insert = "insert into CIT_tbl_Models (Model,Manufacturer) values('" + objPRReq.ModelType + "' , '" + objPRReq.Manufacturer + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getModelByName(PRReq objPRReq)
        {
            string s = "select * from CIT_tbl_Models where Model='" + objPRReq.ModelType + "' and Manufacturer='" + objPRReq.Manufacturer + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getModelByMID(PRReq objPRReq)
        {
            string s = "select * from CIT_tbl_Models where MID='" + objPRReq.ID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getModelByManufacturer(PRReq objPRReq)
        {
            string s = "select * from CIT_tbl_Models where Manufacturer='" + objPRReq.Manufacturer + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp EditModelByMID(PRReq objPRReq)
        {
            string update = "update CIT_tbl_Models set Manufacturer='" + objPRReq.Manufacturer + "', Model='" + objPRReq.ModelType + "' where MID='" + objPRReq.ID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp DelModel(PRReq objPRReq)
        {
            string hod = "delete from CIT_tbl_Models where MID='" + objPRReq.ID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }

        // Bhubhanshu Gurjar END

        public PRResp getAllItemInventory_ITemNameNoWarranty_Dept(PRReq objPRReq) // Bhubhanshu Gurjar added flag1=1
        {
            string s = "select distinct * from CIT_tbl_InventoryMapping where Flag1=1 and Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ItemName='" + objPRReq.ItemName + "' and DeptID='" + objPRReq.DeptID + "' and Warranty!='Warranty' and Warranty!='AMC' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllItemInventory_DeptWise_NameWise(PRReq objPRReq) // Bhubhanshu Gurjar added flag1=1
        {
            string s = "select distinct * from CIT_tbl_InventoryMapping where Flag1=1 and Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' order by DeptID,Name,ItemName ASC ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllItemInventory_DeptWise_NameWise_ITID(PRReq objPRReq) // Bhubhanshu Gurjar added flag1=1
        {
            string s = "select distinct * from CIT_tbl_InventoryMapping where Flag1=1 and Status='" + objPRReq.Status + "' and ITID='" + objPRReq.ITID + "' and OID='" + objPRReq.OID + "' order by DeptID,Name,ItemName ASC ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllItemInventory_ITemName_Dept_AMC(PRReq objPRReq) // Bhubhanshu Gurjar added flag1=1
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
        // Bhubhanshu Gurjar START

        public PRResp getAllItemInventoryByDeptID(PRReq objPRReq)
        {
            string s = "select * from CIT_tbl_InventoryMapping where Flag1=1 and Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and DeptID='" + objPRReq.DeptID + "' order by Name ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllItemInventory_DeptID_ItemName(PRReq objPRReq)
        {
            string s = "select * from CIT_tbl_InventoryMapping where Flag1=1 and Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ItemName='" + objPRReq.ItemName + "' and DeptID='" + objPRReq.DeptID + "' order by Name";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        // Bhubhanshu Gurjar END
        public PRResp getAllItemInventory_Manufacturer(PRReq objPRReq)  // Bhubhanshu Gurjar added Status!='Abandoned'
        {
            string s = "select distinct Manufacturer from CIT_tbl_ItemInventory where Status!='Abandoned' and OID='" + objPRReq.OID + "' and ItemName='" + objPRReq.ItemName + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllItemInventory_ITemNameNoWarranty(PRReq objPRReq) // Bhubhanshu Gurjar added Status!='Abandoned'
        {
            string s = "select distinct * from CIT_tbl_ItemInventory where Status!='Abandoned' and OID='" + objPRReq.OID + "' and ItemName='" + objPRReq.ItemName + "' and Warranty!='Warranty' and Warranty!='AMC' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getItemInventory_ITID_SerialNo(PRReq objPRReq) // Bhubhanshu Gurjar added Status!='Abandoned'
        {
            string s = "select distinct * from CIT_tbl_ItemInventory where Status='Idle' and OID='" + objPRReq.OID + "' and ITID='" + objPRReq.ITID + "' and SerialNo='" + objPRReq.SerialNo + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getItemInventorySerialNo(PRReq objPRReq) // Bhubhanshu Gurjar added Status!='Abandoned'
        {
            string s = "select distinct * from CIT_tbl_ItemInventory where Status='Idle' and OID='" + objPRReq.OID +  "' and SerialNo='" + objPRReq.SerialNo + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllItemInventory_ITemNameAMC(PRReq objPRReq) // Bhubhanshu Gurjar added Status!='Abandoned'
        {
            string s = "select distinct * from CIT_tbl_ItemInventory where Status!='Abandoned' and OID='" + objPRReq.OID + "' and ItemName='" + objPRReq.ItemName + "' and Warranty='" + objPRReq.Warranty + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllItemInventory_ITemNameNoWarranty_manufacturer(PRReq objPRReq) // Bhubhanshu Gurjar added Status!='Abandoned'
        {
            string s = "select distinct * from CIT_tbl_ItemInventory where Status!='Abandoned' and OID='" + objPRReq.OID + "' and ItemName='" + objPRReq.ItemName + "' and Manufacturer='" + objPRReq.Manufacturer + "' and Warranty!='Warranty' and Warranty!='AMC' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllItemInventory_ITemName_Manufacturer_AMC(PRReq objPRReq) // Bhubhanshu Gurjar added Status!='Abandoned'
        {
            string s = "select distinct * from CIT_tbl_ItemInventory where Status!='Abandoned' and OID='" + objPRReq.OID + "' and ItemName='" + objPRReq.ItemName + "' and Warranty='" + objPRReq.Warranty + "' and Manufacturer='" + objPRReq.Manufacturer + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        // Bhubhanshu Gurjar START
        public PRResp getAllItemInventory_ITemName_Status(PRReq objPRReq) // Bhubhanshu Gurjar added Status!='Abandoned'
        {
            string s = "select * from CIT_tbl_ItemInventory where Status='" + objPRReq.Status + "' and OID='" + objPRReq.OID + "' and ItemName='" + objPRReq.ItemName +  "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getItemInventory_Manufacturer(PRReq objPRReq)
        {
            string s = "select * from CIT_tbl_ItemInventory where Status!='Abandoned' and OID='" + objPRReq.OID + "' and Manufacturer='" + objPRReq.Manufacturer + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getItemInventory_Manufacturer_ItemName(PRReq objPRReq)
        {
            string s = "select * from CIT_tbl_ItemInventory where Status!='Abandoned' and OID='" + objPRReq.OID + "' and ItemName='" + objPRReq.ItemName + "' and Manufacturer='" + objPRReq.Manufacturer + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        // Bhubhanshu Gurjar END

        public PRResp AddItemInventory(PRReq objPRReq) // Bhubhanshu Gurjar Updated insert query according to new columns 
        {
            string insert = "insert into CIT_tbl_ItemInventory (OID,ITID,ItemName,ItemType,Model,SerialNo,Manufacturer,ComputerNumber,DOP,Warranty,WarrantyDate,Vendor,Status,Dated,UID,UName,eFile,Bill,SectionofCenter,Price) values('" + objPRReq.OID + "','" + objPRReq.ITID + "','" + objPRReq.ItemName + "','" + objPRReq.ItemType + "','" + objPRReq.ModelType + "','" + objPRReq.SerialNo + "','" + objPRReq.Manufacturer + "','" + objPRReq.ComputerNo + "','" + objPRReq.DOP + "','" + objPRReq.Warranty + "','" + objPRReq.WarrantyDate + "','" + objPRReq.Vendor + "','" + objPRReq.Status + "','" + objPRReq.Dated + "','" + objPRReq.UID + "','" + objPRReq.UName + "','" + objPRReq.EID + "','" + objPRReq.InvoiceNumber + "','" + objPRReq.Department + "','" + objPRReq.APrice + "')";
            objPRResp.Count = Connections.ProcessQuery(insert);
            return objPRResp;
        }
        public PRResp getAllItemInventory(PRReq objPRReq)
        {
            string s = "select * from CIT_tbl_ItemInventory where OID='" + objPRReq.OID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        // asset not abandoned Bhubhanshu Gurjar START
        public PRResp getAllItemInventoryNotAbandoned(PRReq objPRReq)
        {
            string s = "select * from CIT_tbl_ItemInventory where Status!='Abandoned' and OID='" + objPRReq.OID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllItemInventoryNotAbandonedByDate(PRReq objPRReq)
        {
            string s = "select * from CIT_tbl_ItemInventory where Status!='Abandoned' and OID='" + objPRReq.OID + "' and Dated>='" + objPRReq.StartDate + "' and Dated<='" + objPRReq.EndDate + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        // Bhubhanshu Gurjar END

        public PRResp getAllItemInventory_ITID(PRReq objPRReq) // Bhubhanshu Gurjar added status!='Abandoned'
        {
            string s = "select * from CIT_tbl_ItemInventory where Status!='Abandoned' and OID='" + objPRReq.OID + "' and ITID='" + objPRReq.ITID + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAvailableItemInventory(PRReq objPRReq)
        {
            string s = "select * from CIT_tbl_ItemInventory where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        public PRResp getDisposedItemInventoryByDate(PRReq objPRReq) // Bhubhanshu Gurjar check disposed assets query
        {
            string s = "select * from CIT_tbl_ItemInventory where OID='" + objPRReq.OID + "' and Status='" + objPRReq.Status + "' and DisposedOn >='" + objPRReq.StartDate + "' and DisposedOn <='" + objPRReq.EndDate + "' ";
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

        public PRResp getItemInventory4SerialNobyStatus(PRReq objPRReq) // Bhubhanshu Gurjar 
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
        public PRResp EditItemInventory_SerialNo(PRReq objPRReq) // Bhubhanshu Gurjar updated query according to new columns
        {
            string update = "update CIT_tbl_ItemInventory set ItemName='" + objPRReq.ItemName + "',ItemType='" + objPRReq.ItemType + "',Model='" + objPRReq.ModelType + "',SerialNo='" + objPRReq.SerialNo + "',Manufacturer='" + objPRReq.Manufacturer + "',ComputerNumber='" + objPRReq.ComputerNo + "',Warranty='" + objPRReq.Warranty + "',WarrantyDate='" + objPRReq.WarrantyDate + "',Vendor='" + objPRReq.Vendor + "',DOP='" + objPRReq.DOP + "',ITID='" + objPRReq.ITID + "',Status='" + objPRReq.Status + "',eFile='" + objPRReq.EID + "',Bill='" + objPRReq.InvoiceNumber + "',SectionofCenter='" + objPRReq.Department + "',Price='" + objPRReq.APrice + "' where OID='" + objPRReq.OID + "' and IID='" + objPRReq.IID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp EditItemInventoryDisposal(PRReq objPRReq) // Bhubhanshu Gurjar new query to dispose assets
        {
            string update = "update CIT_tbl_ItemInventory set Status='" + objPRReq.Status + "',SalePrice='" + objPRReq.APrice + "' ,DisposalRemark='" + objPRReq.Remarks + "', DisposalFile ='" + objPRReq.FileName + "', DisposedOn='" + DateTime.Now + "' where OID='" + objPRReq.OID + "' and IID='" + objPRReq.IID + "' ";
            objPRResp.Count = Connections.ProcessQuery(update);
            return objPRResp;
        }
        public PRResp DelItemInventory(PRReq objPRReq)
        {
            string hod = "delete from CIT_tbl_ItemInventory where  OID='" + objPRReq.OID + "' and IID='" + objPRReq.IID + "' ";
            objPRResp.GetTable = Connections.GetTable(hod);
            return objPRResp;
        }

        // Bhubhanshu Gurjar START
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
        public PRResp getMappedInventoryMakeWise(PRReq objPRReq)
        {
            string s = @"SELECT Manufacturer
                , SUM(case when[ItemName] = 'Desktop' then 1 else 0 end) as Desktop
                ,SUM(case when[ItemName] = 'Laptop' then 1 else 0 end) as Laptop
                ,SUM(case when[ItemName] = 'Printer' then 1 else 0 end) as Printer
                ,SUM(case when[ItemName] = 'Scanner' then 1 else 0 end) as Scanner
                ,SUM(case when[ItemName] = 'All-in-One' then 1 else 0 end) as 'All-in-One'
                ,SUM(case when[ItemName] = 'Tablet' then 1 else 0 end) as Tablet
                FROM CIT_tbl_ItemInventory where Status!='Abandoned' group by Manufacturer";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        // Bhubhanshu Gurjar END

        // Map CIT Inventory to Emp

        public PRResp MapITInventorytoEmp(PRReq objPRReq) // Bhubhanshu Gurjar added query to change status to active after alloting asset
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

        public PRResp ReleaseMappedItem_EmpID(PRReq objPRReq) // Bhubhanshu Gurjar added query to change status to idle after releasing asset
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


        // Roles Bhubhanshu Gurjar START
        public PRResp getRoles(PRReq objPRReq)
        {
            string s = "select * from  tbl_Roles";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp AddRoleTable(PRReq objPRReq)
        {
            string s = "INSERT INTO tbl_Roles VALUES ('"+ objPRReq.Role +"','"+ objPRReq.RoleType +"')";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getMaxRole(PRReq objPRReq)
        {
            string s = "select max(Role) from tbl_Roles";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getARole(PRReq objPRReq)
        {
            string s = "select * from tbl_Roles where Application='"+ objPRReq.RoleType+"'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAllAdmins(PRReq objPRReq)
        {
            string s = "select * from  tbl_Admin where Status='" + objPRReq.Status + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp getAdminRoleEmpID(PRReq objPRReq)
        {
            string s = "select * from  tbl_Admin where Status='" + objPRReq.Status + "' and Role='" + objPRReq.Role + "' and EmpID='" + objPRReq.EmpID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp DeleteRole(PRReq objPRReq)
        {
            string s = "DELETE from  tbl_Admin where UID='" + objPRReq.UID + "'";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp AddRole(PRReq objPRReq)
        {
            string s = "insert into tbl_Admin(UserID, EmpID, Name, DSID, Design, Email, Password, Mobile, OID, OrgName, Application, Role, Status, Photo) values('" + objPRReq.EmpID + "', '" + objPRReq.EmpID + "', '" + objPRReq.Name + "', '" + objPRReq.DSID + "', '" + objPRReq.Design + "', '" + objPRReq.Email + "', '" + objPRReq.Password + "', '" + objPRReq.Mobile + "', '" + objPRReq.OID + "', '" + objPRReq.OrgName + "', '" + objPRReq.Application + "', '" + objPRReq.Role + "', '" + objPRReq.Status + "', '" + objPRReq.Photo + "')";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }

        // Bhubhanshu Gurjar END


        // Not related to Assets but required for other features
        public PRResp StoreUserLogin(PRReq objPRReq)
        {
            string s = "select * from Store_tbl_User where UserID='" + objPRReq.UserID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp CITSSLogin(PRReq objPRReq)
        {
            string s = "select * from CIT_tbl_SupportingStaff where Email='" + objPRReq.Email + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
        public PRResp eLDALogin(PRReq objPRReq)
        {
            string s = "select * from eL_tbl_DealingAssistants where UserID='" + objPRReq.UserID + "' and Status='" + objPRReq.Status + "' ";
            objPRResp.GetTable = Connections.GetTable(s);
            return objPRResp;
        }
    }
}