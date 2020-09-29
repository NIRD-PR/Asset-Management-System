<%@ Application Language="C#" %>
<%@ Import Namespace="System.Threading" %>
<%@ Import Namespace="System.Web.Routing" %>
<script runat="server">
    public static int count = 0;
    public static bool _leaves = false;
    public static bool _ran = false;
    public static bool _alert = false;
    public static bool _el_hpl_update = false;

    static DateTime dummy;
    void Application_Start(object sender, EventArgs e)
    {
        RegisterRoutes(RouteTable.Routes);
        //Application["NoOfVisitors"] = count;
    }
    static void RegisterRoutes(RouteCollection routes)
    {
        routes.MapPageRoute("Home", "Home", "~/Default.aspx");
        routes.MapPageRoute("Contact", "Contact", "~/Contact.aspx");
        routes.MapPageRoute("FP", "FP", "~/ForgotPassword.aspx");
        routes.MapPageRoute("News", "News", "~/News.aspx");
        routes.MapPageRoute("Reg", "Reg", "~/Registration.aspx");
        routes.MapPageRoute("SMS", "SMS", "~/SMS.aspx");
        routes.MapPageRoute("FB", "FB", "~/Feedback.aspx");

        routes.MapPageRoute("HEmpHome/{UID}", "HEmpHome/{UID}", "~/HOC/HOC_MainHome.aspx");

        // RSLeave Management       
        routes.MapPageRoute("HOC_RLeave_Home/{UID}", "HOC_RLeave_Home/{UID}", "~/HOC/RLeave/RLeaveHome.aspx");
        routes.MapPageRoute("HOC_RAtt_Home/{UID}", "HOC_RAtt_Home/{UID}", "~/HOC/RAttendance/RAttHome.aspx");
        routes.MapPageRoute("HOC_RGeneral_Home/{UID}", "HOC_RGeneral_Home/{UID}", "~/HOC/RGeneral/Circulars.aspx");
        routes.MapPageRoute("HOC_RFinance_Home/{UID}", "HOC_RFinance_Home/{UID}", "~/HOC/RFinance/RFinanceHome.aspx");
        routes.MapPageRoute("HOC_RTour_Home/{UID}", "HOC_RTour_Home/{UID}", "~/HOC/RTour/RTourHome.aspx");
        routes.MapPageRoute("HOC_RVehicle_Home/{UID}", "HOC_RVehicle_Home/{UID}", "~/HOC/RVehicle/RVehicleHome.aspx");
        routes.MapPageRoute("HOC_RStores_Home/{UID}", "HOC_RStores_Home/{UID}", "~/HOC/RStores/RStoresHome.aspx");
        routes.MapPageRoute("HOC_RComplaints_Home/{UID}", "HOC_RComplaints_Home/{UID}", "~/HOC/RComplaints/RComplaintHome.aspx");
        routes.MapPageRoute("HOC_RHealth_Home/{UID}", "HOC_RHealth_Home/{UID}", "~/HOC/RHealth/RHealthHome.aspx");

        routes.MapPageRoute("HEmp_LApply/{UID}", "HEmp_LApply/{UID}", "~/HOC/RLeave/LeaveApply.aspx");
        routes.MapPageRoute("HEmp_LAppled/{UID}", "HEmp_LAppled/{UID}", "~/HOC/RLeave/LeavesApplied.aspx");
        routes.MapPageRoute("HEmp_LCanceled/{UID}", "HEmp_LCanceled/{UID}", "~/HOC/RLeave/LeavesCanceled.aspx");
        routes.MapPageRoute("HEmp_LforApproval/{UID}", "HEmp_LforApproval/{UID}", "~/HOC/RLeave/LeavesForApproval.aspx");
        routes.MapPageRoute("HEmp_LJRCEforApproval/{UID}", "HEmp_LJRCEforApproval/{UID}", "~/HOC/RLeave/Leaves_JR_Curt_Ext_ForApproval.aspx");
        routes.MapPageRoute("HEmp_LAprvd/{UID}", "HEmp_LAprvd/{UID}", "~/HOC/RLeave/LeavesApproved.aspx");
        routes.MapPageRoute("HEmp_LRcmded/{UID}", "HEmp_LRcmded/{UID}", "~/HOC/RLeave/LeavesRecommended.aspx");
        routes.MapPageRoute("HEmp_LRejcted/{UID}", "HEmp_LRejcted/{UID}", "~/HOC/RLeave/LeavesRejectedByMe.aspx");
        routes.MapPageRoute("HEmp_LCabyme/{UID}", "HEmp_LCabyme/{UID}", "~/HOC/RLeave/LeavesCancelledbyme.aspx");
        routes.MapPageRoute("HEmp_LApAction/{UID}", "HEmp_LApAction/{UID}", "~/HOC/RLeave/LeaveAction.aspx");
        routes.MapPageRoute("HEmp_LReviewAction/{UID}", "HEmp_LReviewAction/{UID}", "~/HOC/RLeave/RLReviewAction.aspx");
        routes.MapPageRoute("HEmp_LJRCEApAction/{UID}", "HEmp_LJRCEApAction/{UID}", "~/HOC/RLeave/Leaves_JR_Curt_Ext_Action.aspx");
        routes.MapPageRoute("HEmp_myAL/{UID}", "HEmp_myAL/{UID}", "~/HOC/RLeave/LeavesApproved4me.aspx");
        routes.MapPageRoute("HEmp_myRL/{UID}", "HEmp_myRL/{UID}", "~/HOC/RLeave/LeavesRejected4me.aspx");
        routes.MapPageRoute("HEmp_myLJR/{UID}", "HEmp_myLJR/{UID}", "~/HOC/RLeave/RS_LeaveJoingReport.aspx");
        routes.MapPageRoute("HEmp_myLExt/{UID}", "HEmp_myLExt/{UID}", "~/HOC/RLeave/RS_LeaveExtension.aspx");
        routes.MapPageRoute("HEmp_myLCurt/{UID}", "HEmp_myLCurt/{UID}", "~/HOC/RLeave/RS_LeaveCurtail.aspx");
        routes.MapPageRoute("HEmp_myALJR/{UID}", "HEmp_myALJR/{UID}", "~/HOC/RLeave/Leaves_JR_Ext_Curt_Approved4me.aspx");
        routes.MapPageRoute("HEmp_CancelCLRH/{UID}", "HEmp_CancelCLRH/{UID}", "~/HOC/RLeave/HCancel_CLRH.aspx");
        routes.MapPageRoute("HEmp_CancelNoCLRH/{UID}", "HEmp_CancelNoCLRH/{UID}", "~/HOC/RLeave/HCancel_OtherthanCLRH.aspx");
        routes.MapPageRoute("HEmp_AllmyLeaves/{UID}", "HEmp_AllmyLeaves/{UID}", "~/HOC/RLeave/AllLeaveswithanyStatus.aspx");
        
        routes.MapPageRoute("HEmp_Dept_EL_Status/{UID}", "HEmp_Dept_EL_Status/{UID}", "~/HOC/RLeave/Dept_el_AvailedStatus.aspx");
        routes.MapPageRoute("HEmp_Dept_ELs/{UID}", "HEmp_Dept_ELs/{UID}", "~/HOC/RLeave/Dept_eL_Used.aspx");
        routes.MapPageRoute("HEmp_Dept_ET_Status/{UID}", "HEmp_Dept_ET_Status/{UID}", "~/HOC/RLeave/Dept_eT_AvailedStatus.aspx");

        //RPSLeave Management
        routes.MapPageRoute("HEmp_PS_CLApproval/{UID}", "HEmp_PS_CLApproval/{UID}", "~/HOC/RLeave/PS_LeavesForApproval.aspx");
        routes.MapPageRoute("HEmp_PS_CLAction/{UID}", "HEmp_PS_CLAction/{UID}", "~/HOC/RLeave/PS_LeaveAction.aspx");
        routes.MapPageRoute("HEmp_PS_CLRecmded/{UID}", "HEmp_PS_CLRecmded/{UID}", "~/HOC/RLeave/PS_LeavesRecommended.aspx");
        routes.MapPageRoute("HEmp_PS_CLAprvdbyMe/{UID}", "HEmp_PS_CLAprvdbyMe/{UID}", "~/HOC/RLeave/PS_LeavesApprovedByMe.aspx");
        routes.MapPageRoute("HEmp_PS_CLApproved/{UID}", "HEmp_PS_CLApproved/{UID}", "~/HOC/RLeave/PS_LeavesApproved.aspx");
        routes.MapPageRoute("HEmp_PS_CLRej/{UID}", "HEmp_PS_CLRej/{UID}", "~/HOC/RLeave/PS_LeavesRejected.aspx");
        routes.MapPageRoute("HEmp_PSLCancel/{UID}", "HEmp_PSLCancel/{UID}", "~/HOC/RLeave/PSHCancel_CLSL.aspx");
        routes.MapPageRoute("HEmp_Late/{UID}", "HEmp_Late/{UID}", "~/HOC/RLeave/Reg_LateRequest.aspx");
        routes.MapPageRoute("HEmp_LateApprvl/{UID}", "HEmp_LateApprvl/{UID}", "~/HOC/RLeave/Reg_LateRequestApproval.aspx");


        //RS Tour Management

        routes.MapPageRoute("HEmp_RSTHome/{UID}", "HEmp_RSTHome/{UID}", "~/HOC/RTour/RSTourHome.aspx");
        routes.MapPageRoute("HEmp_RSTourApply/{UID}", "HEmp_RSTourApply/{UID}", "~/HOC/RTour/RS_TourApply.aspx");
        routes.MapPageRoute("HEmp_RSTAppled/{UID}", "HEmp_RSTAppled/{UID}", "~/HOC/RTour/RS_ToursApplied.aspx");
        routes.MapPageRoute("HEmp_RSTCanceled/{UID}", "HEmp_RSTCanceled/{UID}", "~/HOC/RTour/RS_ToursCanceled.aspx");
        routes.MapPageRoute("HEmp_RSTforApproval/{UID}", "HEmp_RSTforApproval/{UID}", "~/HOC/RTour/RS_ToursForApproval.aspx");
        routes.MapPageRoute("HEmp_RSTApAction/{UID}", "HEmp_RSTApAction/{UID}", "~/HOC/RTour/RS_TourAction.aspx");
        routes.MapPageRoute("HEmp_RSTRcmded/{UID}", "HEmp_RSTRcmded/{UID}", "~/HOC/RTour/RS_ToursRecommended.aspx");
        routes.MapPageRoute("HEmp_RSTRejcted/{UID}", "HEmp_RSTRejcted/{UID}", "~/HOC/RTour/RS_ToursRejectedByMe.aspx");
        routes.MapPageRoute("HEmp_myATRS/{UID}", "HEmp_myATRS/{UID}", "~/HOC/RTour/RS_ToursApproved4me.aspx");
        routes.MapPageRoute("HEmp_myRTRS/{UID}", "HEmp_myRTRS/{UID}", "~/HOC/RTour/RS_ToursRejected4me.aspx");
        routes.MapPageRoute("HEmp_RSTAprvd/{UID}", "HEmp_RSTAprvd/{UID}", "~/HOC/RTour/RS_ToursApprovedByMe.aspx");
        routes.MapPageRoute("HEmp_RSRPTitle/{UID}", "HEmp_RSRPTitle/{UID}", "~/HOC/RTour/AddRPTitle.aspx");


        routes.MapPageRoute("HEmp_TourApply/{UID}", "HEmp_TourApply/{UID}", "~/HOC/RTour/RS_TourApply.aspx");
        routes.MapPageRoute("HEmp_TAppled/{UID}", "HEmp_TAppled/{UID}", "~/HOC/RTour/RS_ToursApplied.aspx");
        routes.MapPageRoute("HEmp_TCanceled/{UID}", "HEmp_TCanceled/{UID}", "~/HOC/RTour/RS_ToursCanceled.aspx");
        routes.MapPageRoute("HEmp_TforApproval/{UID}", "HEmp_TforApproval/{UID}", "~/HOC/RTour/RS_ToursForApproval.aspx");
        routes.MapPageRoute("HEmp_TApAction/{UID}", "HEmp_TApAction/{UID}", "~/HOC/RTour/RS_TourAction.aspx");
        routes.MapPageRoute("HEmp_TRcmded/{UID}", "HEmp_TRcmded/{UID}", "~/HOC/RTour/RS_ToursRecommended.aspx");
        routes.MapPageRoute("HEmp_TRejcted/{UID}", "HEmp_TRejcted/{UID}", "~/HOC/RTour/RS_ToursRejectedByMe.aspx");
        routes.MapPageRoute("HEmp_myAT/{UID}", "HEmp_myAT/{UID}", "~/HOC/RTour/RS_ToursApproved4me.aspx");
        routes.MapPageRoute("HEmp_myRT/{UID}", "HEmp_myRT/{UID}", "~/HOC/RTour/RS_ToursRejected4me.aspx");
        routes.MapPageRoute("HEmp_TAprvd/{UID}", "HEmp_TAprvd/{UID}", "~/HOC/RTour/RS_ToursApprovedByMe.aspx");



        routes.MapPageRoute("HEmp_PS_TApproval/{UID}", "HEmp_PS_TApproval/{UID}", "~/HOC/RTour/PST_ToursForApproval.aspx");
        routes.MapPageRoute("HEmp_PS_TAction/{UID}", "HEmp_PS_TAction/{UID}", "~/HOC/RTour/PST_TourAction.aspx");
        routes.MapPageRoute("HEmp_PS_TApproved/{UID}", "HEmp_PS_TApproved/{UID}", "~/HOC/RTour/PST_ToursApproved.aspx");
        routes.MapPageRoute("HEmp_PS_TRecmded/{UID}", "HEmp_PS_TRecmded/{UID}", "~/HOC/RTour/PST_ToursRecommended.aspx");
        routes.MapPageRoute("HEmp_PS_TAprvdbyMe/{UID}", "HEmp_PS_TAprvdbyMe/{UID}", "~/HOC/RTour/PST_ToursApprovedByMe.aspx");
        routes.MapPageRoute("HEmp_PS_TRej/{UID}", "HEmp_PS_TRej/{UID}", "~/HOC/RTour/PST_ToursRejected.aspx");
        routes.MapPageRoute("HEmp_PST_Cancel/{UID}", "HEmp_PST_Cancel/{UID}", "~/HOC/RTour/PST_ATourCancel.aspx");
        routes.MapPageRoute("HEmp_PST_Canceled/{UID}", "HEmp_PST_Canceled/{UID}", "~/HOC/RTour/PST_AToursCancelled.aspx");

        //R Stores
        routes.MapPageRoute("HEmp_RStoreHome/{UID}", "HEmp_RStoreHome/{UID}", "~/HOC/RStores/RStoresHome.aspx");
        routes.MapPageRoute("HEmp_I2Store/{UID}", "HEmp_I2Store/{UID}", "~/HOC/RStores/Indent4Stock.aspx");
        routes.MapPageRoute("HEmp_EPI/{UID}", "HEmp_EPI/{UID}", "~/HOC/RStores/REmpIndents.aspx");
        routes.MapPageRoute("HEmp_NEPI/{UID}", "HEmp_NEPI/{UID}", "~/HOC/RStores/NewStoreIndents.aspx");
        routes.MapPageRoute("HEmp_AESI/{UID}", "HEmp_AESI/{UID}", "~/HOC/RStores/ApprovedStoreIndents.aspx");
        routes.MapPageRoute("HEmp_RPTitle/{UID}", "HEmp_RPTitle/{UID}", "~/HOC/RStores/AddRPTitle.aspx");
        routes.MapPageRoute("HEmp_CSE/{UID}", "HEmp_CSE/{UID}", "~/HOC//RStores/PersonwiseExpenditureReport.aspx");
        routes.MapPageRoute("HEmp_DEASI/{UID}", "HEmp_DEASI/{UID}", "~/HOC//RStores/DeptEmpApprovedStoreIndents.aspx");

        //R Attendnace
        routes.MapPageRoute("HEmp_RAttHome/{UID}", "HEmp_RAttHome/{UID}", "~/HOC/RAttendance/RAttHome.aspx");
        routes.MapPageRoute("HEmp_BAStatus/{UID}", "HEmp_BAStatus/{UID}", "~/HOC/RAttendance/BioMetricAttStatus.aspx");
        routes.MapPageRoute("HEmp_PS_Bio/{UID}", "HEmp_PS_Bio/{UID}", "~/HOC/RAttendance/PS_MonthlyBioMetricAttStatus.aspx");
        routes.MapPageRoute("HEmp_BAHStatus/{UID}", "HEmp_BAHStatus/{UID}", "~/HOC/RAttendance/BioMetricAtt_HourStatus.aspx");

        // RGeneral
        routes.MapPageRoute("HEmp_Resume/{UID}", "HEmp_Resume/{UID}", "~/HOC/RGeneral/ResumeResourcePool.aspx");
        routes.MapPageRoute("HEmp_RP/{UID}", "HEmp_RP/{UID}", "~/HOC/RGeneral/ResourcePersons.aspx");
        routes.MapPageRoute("HEmp_PCLs/{UID}", "HEmp_PCLs/{UID}", "~/HOC/RGeneral/AddProjectStaffCLs.aspx");
        routes.MapPageRoute("HEmp_UPCLs/{UID}", "HEmp_UPCLs/{UID}", "~/HOC/RGeneral/AUpdateProjectStaffCLs.aspx");
        routes.MapPageRoute("HEmp_Circulars/{UID}", "HEmp_Circulars/{UID}", "~/HOC/RGeneral/Circulars.aspx");
        routes.MapPageRoute("HEmp_UPS/{UID}", "HEmp_UPS/{UID}", "~/HOC/RGeneral/UpdateProfile.aspx");
        routes.MapPageRoute("HEmp_PP/{UID}", "HEmp_PP/{UID}", "~/HOC/RGeneral/PrintProfile.aspx");
        routes.MapPageRoute("HEmp_CPS/{UID}", "HEmp_CPS/{UID}", "~/HOC/RGeneral/ChangePassword.aspx");
        routes.MapPageRoute("HEmp_Contact/{UID}", "HEmp_Contact/{UID}", "~/HOC/RGeneral/NirdContactsList.aspx");
        routes.MapPageRoute("HEmp_GSMS/{UID}", "HEmp_GSMS/{UID}", "~/HOC/RGeneral/GroupSMS.aspx");
        routes.MapPageRoute("HEmp_GSMSRpt/{UID}", "HEmp_GSMSRpt/{UID}", "~/HOC/RGeneral/GroupSMSREport.aspx");
        routes.MapPageRoute("HEmp_Eph/{UID}", "HEmp_Eph/{UID}", "~/HOC/RGeneral/ChangePhoto.aspx");
        routes.MapPageRoute("HEmp_Gallery/{UID}", "HEmp_Gallery/{UID}", "~/HOC/RGeneral/Gallery.aspx");

        routes.MapPageRoute("HOC_RGeneral_WPList/{UID}", "HOC_RGeneral_WPList/{UID}", "~/HOC/RGeneral/WebnarTrainingList.aspx");
        routes.MapPageRoute("HOC_RGeneral_WPListMail/{UID}", "HOC_RGeneral_WPListMail/{UID}", "~/HOC/RGeneral/WebnarTrainingList_Mail.aspx");
        routes.MapPageRoute("HOC_RGeneral_eCert/{UID}", "HOC_RGeneral_eCert/{UID}", "~/HOC/RGeneral/Default.aspx");
        
        //Admin Master
        routes.MapPageRoute("Admin/{UID}", "Admin/{UID}", "~/Admin/AdminHome.aspx");
        routes.MapPageRoute("Admin_D_Incharge/{UID}", "Admin_D_Incharge/{UID}", "~/Admin/DeptIncharge.aspx");
        routes.MapPageRoute("AdminSMS_CPR/{UID}", "AdminSMS_CPR/{UID}", "~/Admin/CPRSMS.aspx");
        routes.MapPageRoute("Admin_UploadVideo/{UID}", "Admin_UploadVideo/{UID}", "~/Admin/UploadVideos.aspx");
        routes.MapPageRoute("Admin_PS/{UID}", "Admin_PS/{UID}", "~/Admin/Payscale.aspx");
        routes.MapPageRoute("Admin_ET/{UID}", "Admin_ET/{UID}", "~/Admin/EmpType.aspx");
        routes.MapPageRoute("Admin_EC/{UID}", "Admin_EC/{UID}", "~/Admin/EmpCategory.aspx");
        routes.MapPageRoute("Admin_DS/{UID}", "Admin_DS/{UID}", "~/Admin/Designation.aspx");
        routes.MapPageRoute("Admin_Dept/{UID}", "Admin_Dept/{UID}", "~/Admin/Department.aspx");
        routes.MapPageRoute("Admin_DA/{UID}", "Admin_DA/{UID}", "~/Admin/DA.aspx");
        routes.MapPageRoute("Admin_HRA/{UID}", "Admin_HRA/{UID}", "~/Admin/HRA.aspx");
        routes.MapPageRoute("Admin_Emp/{UID}", "Admin_Emp/{UID}", "~/Admin/Employee.aspx");
        routes.MapPageRoute("Admin_NPA/{UID}", "Admin_NPA/{UID}", "~/Admin/NPA.aspx");
        routes.MapPageRoute("Admin_TRA/{UID}", "Admin_TRA/{UID}", "~/Admin/TRA.aspx");
        routes.MapPageRoute("Admin_CLs/{UID}", "Admin_CLs/{UID}", "~/Admin/AutoAdjustCLs.aspx");
        routes.MapPageRoute("Admin_FY/{UID}", "Admin_FY/{UID}", "~/Admin/FinancialYear.aspx");
        routes.MapPageRoute("Admin_ESal/{UID}", "Admin_Esal/{UID}", "~/Admin/NewEmpSal.aspx");
        routes.MapPageRoute("Admin_MPSlips/{UID}", "Admin_MPSlips/{UID}", "~/Admin/MailEmpPaySlips.aspx");
        routes.MapPageRoute("Admin_PPS/{UID}", "Admin_PPS/{UID}", "~/Admin/EmpMailPaySlips.aspx");
        routes.MapPageRoute("Admin_OPS/{UID}", "Admin_OPS/{UID}", "~/Admin/OldEmpMailPaySlips.aspx");
        routes.MapPageRoute("Admin_PPEmp/{UID}", "Admin_PPEmp/{UID}", "~/Admin/PrintProfile.aspx");
        routes.MapPageRoute("Admin_ASS/{UID}", "Admin_ASS/{UID}", "~/Admin/AdjustStoreStock.aspx");
        routes.MapPageRoute("Admin_SMS/{UID}", "Admin_SMS/{UID}", "~/Admin/GroupSMS.aspx");
        routes.MapPageRoute("Admin_GovMailReq/{UID}", "Admin_GovMailReq/{UID}", "~/Admin/ViewGovMailRequests.aspx");
        routes.MapPageRoute("Admin_ADDPS/{UID}", "Admin_ADDPS/{UID}", "~/Admin/AddProjectStaff.aspx");
        routes.MapPageRoute("Admin_uEmpDept/{UID}", "Admin_uEmpDept/{UID}", "~/Admin/UpdateEmpDept.aspx");
        routes.MapPageRoute("Admin_uEmpDesign/{UID}", "Admin_uEmpDesign/{UID}", "~/Admin/UpdateEmpDesign.aspx");
        routes.MapPageRoute("Admin_CList/{UID}", "Admin_CList/{UID}", "~/Admin/NirdContactsList.aspx");
        routes.MapPageRoute("Admin_ResetPwd/{UID}", "Admin_ResetPwd/{UID}", "~/Admin/ResetUserPassword.aspx");
        routes.MapPageRoute("Admin_ActS/{UID}", "Admin_ActS/{UID}", "~/Admin/Emp_Active.aspx");
        routes.MapPageRoute("Admin_AEmpLeaves/{UID}", "Admin_AEmpLeaves/{UID}", "~/Admin/PS_EmpLeaves.aspx");
        routes.MapPageRoute("Admin_BlockedS/{UID}", "Admin_BlockedS/{UID}", "~/Admin/Emp_Blocked.aspx");
        routes.MapPageRoute("Admin_CHS/{UID}", "Admin_CHS/{UID}", "~/Admin/UpdateCentreHeadStatus.aspx");
        routes.MapPageRoute("Admin_EWDeligate/{UID}", "Admin_EWDeligate/{UID}", "~/Admin/EmpWorkDeligation.aspx");
        routes.MapPageRoute("Admin_AddPopImg/{UID}", "Admin_AddPopImg/{UID}", "~/Admin/UploadPopupImage.aspx");
        routes.MapPageRoute("Admin_SetAppDU/{UID}", "Admin_SetAppDU/{UID}", "~/Admin/SetAppDefaultUser.aspx");
        routes.MapPageRoute("Admin_UPSLeaves/{UID}", "Admin_UPSLeaves/{UID}", "~/Admin/UpdatePSLeaves.aspx");
        routes.MapPageRoute("Admin_ELeaveStatus/{UID}", "Admin_ELeaveStatus/{UID}", "~/Admin/REmpAppliedLeaveStatus.aspx");
		routes.MapPageRoute("Admin_PELeaveStatus/{UID}", "Admin_PELeaveStatus/{UID}", "~/Admin/PEmpAppliedLeaveStatus.aspx");

        routes.MapPageRoute("Admin_AddProbCategory/{UID}", "Admin_AddProbCategory/{UID}", "~/Admin/ET_AddComplaintType.aspx");
        routes.MapPageRoute("Admin_mapOfficer/{UID}", "Admin_mapOfficer/{UID}", "~/Admin/ET_MapOfficer.aspx");
        routes.MapPageRoute("Admin_GenPSEmpID/{UID}", "Admin_GenPSEmpID/{UID}", "~/Admin/GeneratePSEmpID.aspx");


        //Security Officer
        routes.MapPageRoute("SO_Dashboard/{UID}", "SO_Dashboard/{UID}", "~/SecurityOfficer/SOHome.aspx");
        routes.MapPageRoute("SO_AddSPosition/{UID}", "SO_AddSPosition/{UID}", "~/SecurityOfficer/AddSPosition.aspx");
        routes.MapPageRoute("SO_AddSG/{UID}", "SO_AddSG/{UID}", "~/SecurityOfficer/AddSecurityGuard.aspx");
        routes.MapPageRoute("SO_SID/{UID}", "SO_SID/{UID}", "~/SecurityOfficer/SecurityIDCard.aspx");
        routes.MapPageRoute("SO_VSBD/{UID}", "SO_VSBD/{UID}", "~/SecurityOfficer/VSearchbnDates.aspx");


        // EAdmin         
        routes.MapPageRoute("eAdmin/{UID}", "eAdmin/{UID}", "~/EAdmin/eAdmnHome.aspx");
        routes.MapPageRoute("eAdmin_ET/{UID}", "eAdmin_ET/{UID}", "~/EAdmin/EmpType.aspx");
        routes.MapPageRoute("eAdmin_EC/{UID}", "eAdmin_EC/{UID}", "~/EAdmin/EmpCategory.aspx");
        routes.MapPageRoute("eAdmin_DS/{UID}", "eAdmin_DS/{UID}", "~/EAdmin/Designation.aspx");
        routes.MapPageRoute("eAdmin_Dept/{UID}", "eAdmin_Dept/{UID}", "~/EAdmin/Department.aspx");
        routes.MapPageRoute("eAdmin_Emp/{UID}", "eAdmin_Emp/{UID}", "~/EAdmin/Employee.aspx");
        routes.MapPageRoute("eAdmin_FY/{UID}", "eAdmin_FY/{UID}", "~/EAdmin/FinancialYear.aspx");
        routes.MapPageRoute("eAdmin_PPEmp/{UID}", "eAdmin_PPEmp/{UID}", "~/EAdmin/PrintProfile.aspx");
        routes.MapPageRoute("eAdmin_Circulars/{UID}", "eAdmin_Circulars/{UID}", "~/EAdmin/PostCirculars.aspx");
        routes.MapPageRoute("eAdmin_BCirculars/{UID}", "eAdmin_BCirculars/{UID}", "~/EAdmin/BlockedCirculars.aspx");

        //Payroll Master
        routes.MapPageRoute("PAdmin/{UID}", "PAdmin/{UID}", "~/ACCPayrolls/PayrollHome.aspx");
        routes.MapPageRoute("PAdmin_PS/{UID}", "PAdmin_PS/{UID}", "~/ACCPayrolls/Payscale.aspx");
        routes.MapPageRoute("PAdmin_ET/{UID}", "PAdmin_ET/{UID}", "~/ACCPayrolls/EmpType.aspx");
        routes.MapPageRoute("PAdmin_EC/{UID}", "PAdmin_EC/{UID}", "~/ACCPayrolls/EmpCategory.aspx");
        routes.MapPageRoute("PAdmin_DS/{UID}", "PAdmin_DS/{UID}", "~/ACCPayrolls/Designation.aspx");
        routes.MapPageRoute("PAdmin_Dept/{UID}", "PAdmin_Dept/{UID}", "~/ACCPayrolls/Department.aspx");
        routes.MapPageRoute("PAdmin_DA/{UID}", "PAdmin_DA/{UID}", "~/ACCPayrolls/DA.aspx");
        routes.MapPageRoute("PAdmin_HRA/{UID}", "PAdmin_HRA/{UID}", "~/ACCPayrolls/HRA.aspx");
        routes.MapPageRoute("PAdmin_Emp/{UID}", "PAdmin_Emp/{UID}", "~/ACCPayrolls/Employee.aspx");
        routes.MapPageRoute("PAdmin_NPA/{UID}", "PAdmin_NPA/{UID}", "~/ACCPayrolls/NPA.aspx");
        routes.MapPageRoute("PAdmin_TRA/{UID}", "PAdmin_TRA/{UID}", "~/ACCPayrolls/TRA.aspx");
        routes.MapPageRoute("PAdmin_FY/{UID}", "PAdmin_FY/{UID}", "~/ACCPayrolls/FinancialYear.aspx");
        routes.MapPageRoute("PAdmin_ESal/{UID}", "PAdmin_Esal/{UID}", "~/ACCPayrolls/NewEmpSal.aspx");
        routes.MapPageRoute("PAdmin_MPSlips/{UID}", "PAdmin_MPSlips/{UID}", "~/ACCPayrolls/MailEmpPaySlips.aspx");
        routes.MapPageRoute("PAdmin_PPS/{UID}", "PAdmin_PPS/{UID}", "~/ACCPayrolls/EmpMailPaySlips.aspx");
        routes.MapPageRoute("PAdmin_OPS/{UID}", "PAdmin_OPS/{UID}", "~/ACCPayrolls/OldEmpMailPaySlips.aspx");
        routes.MapPageRoute("PAdmin_PPEmp/{UID}", "PAdmin_PPEmp/{UID}", "~/ACCPayrolls/PrintProfile.aspx");
        routes.MapPageRoute("PAdmin_PEmpSal/{UID}", "PAdmin_PEmpSal/{UID}", "~/ACCPayrolls/PrintMasterSalary.aspx");
        routes.MapPageRoute("PAdmin_ModifyEmpSal/{UID}", "PAdmin_ModifyEmpSal/{UID}", "~/ACCPayrolls/ModifyMonthlySalary.aspx");
        routes.MapPageRoute("PAdmin_NewEmpSalStmt/{UID}", "PAdmin_NewEmpSalStmt/{UID}", "~/ACCPayrolls/NewMonthlySalary.aspx");
        routes.MapPageRoute("PAdmin_MonthlyCatSummaryReport/{UID}", "PAdmin_MonthlyCatSummaryReport/{UID}", "~/ACCPayrolls/PrintEmpSummaryReport.aspx");
        routes.MapPageRoute("PAdmin_MonthlyBankStmt/{UID}", "PAdmin_MonthlyBankStmt/{UID}", "~/ACCPayrolls/PrintEmpBankStatement.aspx");
        routes.MapPageRoute("PAdmin_MonthlyAllowances/{UID}", "PAdmin_MonthlyAllowances/{UID}", "~/ACCPayrolls/PrintMonthlyAllowances.aspx");
        routes.MapPageRoute("PAdmin_MonthlySummaryRpt/{UID}", "PAdmin_MonthlySummaryRpt/{UID}", "~/ACCPayrolls/PMonthlySummaryReport.aspx");
        routes.MapPageRoute("PAdmin_Mon_Dedu_S1/{UID}", "PAdmin_Mon_Dedu_S1/{UID}", "~/ACCPayrolls/PrintMonthlyDeductions_S1.aspx");
        routes.MapPageRoute("PAdmin_Mon_Dedu_S2/{UID}", "PAdmin_Mon_Dedu_S2/{UID}", "~/ACCPayrolls/PrintMonthlyDeductions_S2.aspx");
        routes.MapPageRoute("PAdmin_MailPS/{UID}", "PAdmin_MailPS/{UID}", "~/ACCPayrolls/MailPayslip.aspx");
        routes.MapPageRoute("PAdmin_LIC/{UID}", "PAdmin_LIC/{UID}", "~/ACCPayrolls/AddLICMasterData.aspx");
        routes.MapPageRoute("PAdmin_LICPrint/{UID}", "PAdmin_LICPrint/{UID}", "~/ACCPayrolls/PrintLICMonthlyContribution.aspx");
        routes.MapPageRoute("PAdmin_LICMasterPrint/{UID}", "PAdmin_LICMasterPrint/{UID}", "~/ACCPayrolls/PrintLICEntryReport.aspx");
        routes.MapPageRoute("PAdmin_BLMaster/{UID}", "PAdmin_BLMaster/{UID}", "~/ACCPayrolls/AddBLMasterData.aspx");
        routes.MapPageRoute("PAdmin_BLMasterPrint/{UID}", "PAdmin_BLMasterPrint/{UID}", "~/ACCPayrolls/PrintBLEntryReport.aspx");
        routes.MapPageRoute("PAdmin_BLMonthlyStmt/{UID}", "PAdmin_BLMonthlyStmt/{UID}", "~/ACCPayrolls/PrintBLMonthlyContribution.aspx");
        routes.MapPageRoute("PAdmin_GI/{UID}", "PAdmin_GI/{UID}", "~/ACCPayrolls/PrintEmpGI.aspx");
        routes.MapPageRoute("PAdmin_IT/{UID}", "PAdmin_IT/{UID}", "~/ACCPayrolls/PrintEmpIT.aspx");
        routes.MapPageRoute("PAdmin_IMPS/{UID}", "PAdmin_IMPS/{UID}", "~/ACCPayrolls/NewIndividualMailPayslip.aspx");
        routes.MapPageRoute("PAdmin_IMPSC/{UID}", "PAdmin_IMPSC/{UID}", "~/ACCPayrolls/CurrentIndividualMailPayslip.aspx");
        routes.MapPageRoute("PAdmin_CP/{UID}", "PAdmin_CP/{UID}", "~/ACCPayrolls/ChangePassword.aspx");
        routes.MapPageRoute("PAdmin_BEL/{UID}", "PAdmin_BEL/{UID}", "~/ACCPayrolls/BlockedEmpList.aspx");
        routes.MapPageRoute("PAdmin_F16Entry/{UID}", "PAdmin_F16Entry/{UID}", "~/ACCPayrolls/Form16Entry.aspx");
        routes.MapPageRoute("PAdmin_F16Print/{UID}", "PAdmin_F16Print/{UID}", "~/ACCPayrolls/Form16Print.aspx");
        routes.MapPageRoute("PAdmin_F16UPrint/{UID}", "PAdmin_F16UPrint/{UID}", "~/ACCPayrolls/Form16UsersPrint.aspx");
        routes.MapPageRoute("PAdmin_F16ME/{UID}", "PAdmin_F16ME/{UID}", "~/ACCPayrolls/Form16MasterData.aspx");
        routes.MapPageRoute("PAdmin_GMP/{UID}", "PAdmin_GMP/{UID}", "~/ACCPayrolls/NewGovIndividualMailPayslip.aspx");
        routes.MapPageRoute("PAdmin_SBA/{UID}", "PAdmin_SBA/{UID}", "~/ACCPayrolls/MonthlyBioMetricAttStatus.aspx");
        routes.MapPageRoute("PAdmin_uEmpDept/{UID}", "PAdmin_uEmpDept/{UID}", "~/ACCPayrolls/UpdateEmpDept.aspx");
        routes.MapPageRoute("PAdmin_uEmpDesign/{UID}", "PAdmin_uEmpDesign/{UID}", "~/ACCPayrolls/UpdateEmpDesign.aspx");


        // Project Staff
        routes.MapPageRoute("PSPayrolls/{UID}", "PSPayrolls/{UID}", "~/PSPayrolls/PSHome.aspx");
        routes.MapPageRoute("PSAdd/{UID}", "PSAdd/{UID}", "~/PSPayrolls/AddProjectStaff.aspx");
        routes.MapPageRoute("PSAddExcel/{UID}", "PSAddExcel/{UID}", "~/PSPayrolls/AddProjectStaffExcel.aspx");
        routes.MapPageRoute("PSProjects/{UID}", "PSProjects/{UID}", "~/PSPayrolls/Projects.aspx");
        routes.MapPageRoute("PS_CMS/{UID}", "PS_CMS/{UID}", "~/PSPayrolls/ModifyPSSalary.aspx");
        routes.MapPageRoute("PS_DCMS/{UID}", "PS_DCMS/{UID}", "~/PSPayrolls/DeptPSModify.aspx");
        routes.MapPageRoute("PS_IPS/{UID}", "PS_IPS/{UID}", "~/PSPayrolls/EmpPaySlips.aspx");
        routes.MapPageRoute("PS_IPSMail/{UID}", "PS_IPSMail/{UID}", "~/PSPayrolls/MailEmpPaySlips.aspx");
        routes.MapPageRoute("PS_IPSPB/{UID}", "PS_IPSPB/{UID}", "~/PSPayrolls/PSPayBill.aspx");
        routes.MapPageRoute("PS_Blk/{UID}", "PS_Blk/{UID}", "~/PSPayrolls/BlockedProjectStaffList.aspx");
        routes.MapPageRoute("PS_ABS/{UID}", "PS_ABS/{UID}", "~/PSPayrolls/AllPSBankStatement.aspx");
        routes.MapPageRoute("PS_SBH/{UID}", "PS_SBH/{UID}", "~/PSPayrolls/SBHPSBankStatement.aspx");
        routes.MapPageRoute("PS_RTGS/{UID}", "PS_RTGS/{UID}", "~/PSPayrolls/RTGSPSBankStatement.aspx");
        routes.MapPageRoute("PS_NewSal/{UID}", "PS_NewSal/{UID}", "~/PSPayrolls/NewMonthlySalary.aspx");
        routes.MapPageRoute("PS_Consol/{UID}", "PS_Consol/{UID}", "~/PSPayrolls/PSConsolidatedReport.aspx");
        routes.MapPageRoute("PS_Voucher/{UID}", "PS_Voucher/{UID}", "~/PSPayrolls/GeneratePSVoucher.aspx");
        routes.MapPageRoute("PS_PV/{UID}", "PS_PV/{UID}", "~/PSPayrolls/PrintVoucher.aspx");
        routes.MapPageRoute("PS_Design/{UID}", "PS_Design/{UID}", "~/PSPayrolls/Designation.aspx");
        routes.MapPageRoute("PS_Dept/{UID}", "PS_Dept/{UID}", "~/PSPayrolls/Department.aspx");
        routes.MapPageRoute("PS_PTitle/{UID}", "PS_PTitle/{UID}", "~/PSPayrolls/ProjectTitles.aspx");


        // NIRDPR - Stores
        routes.MapPageRoute("StoreAdmin/{UID}", "StoreAdmin/{UID}", "~/NIRDStores/StoreAdmin/StoreAdminHome.aspx");
        routes.MapPageRoute("StoreAdmin_ET/{UID}", "StoreAdmin_ET/{UID}", "~/NIRDStores/StoreAdmin/EmpType.aspx");
        routes.MapPageRoute("StoreAdmin_EC/{UID}", "StoreAdmin_EC/{UID}", "~/NIRDStores/StoreAdmin/EmpCategory.aspx");
        routes.MapPageRoute("StoreAdmin_DS/{UID}", "StoreAdmin_DS/{UID}", "~/NIRDStores/StoreAdmin/Designation.aspx");
        routes.MapPageRoute("StoreAdmin_Dept/{UID}", "StoreAdmin_Dept/{UID}", "~/NIRDStores/StoreAdmin/Department.aspx");
        routes.MapPageRoute("StoreAdmin_FY/{UID}", "StoreAdmin_FY/{UID}", "~/NIRDStores/StoreAdmin/FinancialYear.aspx");
        routes.MapPageRoute("StoreAdmin_V/{UID}", "StoreAdmin_V/{UID}", "~/NIRDStores/StoreAdmin/Vendor.aspx");
        routes.MapPageRoute("StoreAdmin_IC/{UID}", "StoreAdmin_IC/{UID}", "~/NIRDStores/StoreAdmin/ItemCategory.aspx");
        routes.MapPageRoute("StoreAdmin_U/{UID}", "StoreAdmin_U/{UID}", "~/NIRDStores/StoreAdmin/User.aspx");

        // Store User
        routes.MapPageRoute("StoreUser/{UID}", "StoreUser/{UID}", "~/NIRDStores/StoreUser/StoreUserHome.aspx");
        routes.MapPageRoute("StoreUser_FY/{UID}", "StoreUser_FY/{UID}", "~/NIRDStores/StoreUser/FinancialYear.aspx");
        routes.MapPageRoute("StoreUser_V/{UID}", "StoreUser_V/{UID}", "~/NIRDStores/StoreUser/Vendor.aspx");
        routes.MapPageRoute("StoreUser_IC/{UID}", "StoreUser_IC/{UID}", "~/NIRDStores/StoreUser/ItemCategory.aspx");
        routes.MapPageRoute("StoreUser_ITM/{UID}", "StoreUser_ITM/{UID}", "~/NIRDStores/StoreUser/Items.aspx");
        routes.MapPageRoute("StoreUser_Stock/{UID}", "StoreUser_Stock/{UID}", "~/NIRDStores/StoreUser/AddStock.aspx");
        routes.MapPageRoute("StoreUser_Manu/{UID}", "StoreUser_Manu/{UID}", "~/NIRDStores/StoreUser/Manufacturer.aspx");
        routes.MapPageRoute("StoreUser_Stk/{UID}", "StoreUser_Stk/{UID}", "~/NIRDStores/StoreUser/StoreStock.aspx");
        routes.MapPageRoute("StoreUser_NIndent/{UID}", "StoreUser_NIndent/{UID}", "~/NIRDStores/StoreUser/Indent4Stock.aspx");
        routes.MapPageRoute("StoreUser_NRIndent/{UID}", "StoreUser_NRIndent/{UID}", "~/NIRDStores/StoreUser/RStoreIndents.aspx");
        routes.MapPageRoute("StoreUser_IRIndent/{UID}", "StoreUser_IRIndent/{UID}", "~/NIRDStores/StoreUser/IssueStoreIndent.aspx");
        routes.MapPageRoute("StoreUser_AppvdIndent/{UID}", "StoreUser_AppvdIndent/{UID}", "~/NIRDStores/StoreUser/ApprovedStoreIndents.aspx");
        routes.MapPageRoute("StoreUser_DWAI/{UID}", "StoreUser_DWAI/{UID}", "~/NIRDStores/StoreUser/DatewiseApprovedStoreIndents.aspx");
        routes.MapPageRoute("StoreUser_PWR/{UID}", "StoreUser_PWR/{UID}", "~/NIRDStores/StoreUser/PersonwiseExpenditureReport.aspx");

        // PS Head RACR
        routes.MapPageRoute("PHEmp_RACR_Home/{UID}", "PHEmp_RACR_Home/{UID}", "~/ProjectStaff/RACR/RACRHome.aspx");
        routes.MapPageRoute("PHACR_RPTO_Preview/{UID}", "PHACR_RPTO_Preview/{UID}", "~/ProjectStaff/RACR/ACR_Reporting_Officer_Preview.aspx");
        routes.MapPageRoute("PH3_3_ACRRpt_Officer_General/{UID}", "PH3_3_ACRRpt_Officer_General/{UID}", "~/ProjectStaff/RACR/3_3_ACRRpt_Officer_General.aspx");
        routes.MapPageRoute("PH3_2_4_ACRRpt_Officer_SPLAttributes/{UID}", "PH3_2_4_ACRRpt_Officer_SPLAttributes/{UID}", "~/ProjectStaff/RACR/3_2_4_ACRRpt_Officer_SPLAttributes.aspx");
        routes.MapPageRoute("PH3_2_3_ACRRpt_Officer_PerAttributes/{UID}", "PH3_2_3_ACRRpt_Officer_PerAttributes/{UID}", "~/ProjectStaff/RACR/3_2_3_ACRRpt_Officer_PerAttributes.aspx");
        routes.MapPageRoute("PH3_2_2_ACRRpt_Officer_FunComptncy/{UID}", "PH3_2_2_ACRRpt_Officer_FunComptncy/{UID}", "~/ProjectStaff/RACR/3_2_2_ACRRpt_Officer_FunComptncy.aspx");
        routes.MapPageRoute("PH3_2_1_ACRRpt_Officer_WorkOutput/{UID}", "PH3_2_1_ACRRpt_Officer_WorkOutput/{UID}", "~/ProjectStaff/RACR/3_2_1_ACRRpt_Officer_WorkOutput.aspx");
        routes.MapPageRoute("PH3_1_ACRRpt_Off_Action/{UID}", "PH3_1_ACRRpt_Off_Action/{UID}", "~/ProjectStaff/RACR/3_1_ACRRpt_Officer_Action.aspx");
        routes.MapPageRoute("PHACRRpt_Off_Action/{UID}", "PHACRRpt_Off_Action/{UID}", "~/ProjectStaff/RACR/ACR_Reporting_Officer_Action.aspx");
        routes.MapPageRoute("PHACRReV_Off_Action/{UID}", "PHACRReV_Off_Action/{UID}", "~/ProjectStaff/RACR/ACR_Reviewing_Officer_Action.aspx");
        routes.MapPageRoute("PHACRAccept_Off_Action/{UID}", "PHACRAccept_Off_Action/{UID}", "~/ProjectStaff/RACR/ACR_Accept_Officer_Action.aspx");

        routes.MapPageRoute("PHACRRpt_Rev_accpt/{UID}", "PHACRRpt_Rev_accpt/{UID}", "~/ProjectStaff/RACR/ACR_Reporting_Officer_Assmt_waiting.aspx");
        routes.MapPageRoute("ACR_RPTO_Assessed/{UID}", "ACR_RPTO_Assessed/{UID}", "~/HOC/RACR/ACR_RPTO_Assessed.aspx");
        routes.MapPageRoute("ACR_REVO_Assessed/{UID}", "ACR_REVO_Assessed/{UID}", "~/HOC/RACR/ACR_REVO_Assessed.aspx");
        routes.MapPageRoute("ACR_ACPT_Assessed/{UID}", "ACR_ACPT_Assessed/{UID}", "~/HOC/RACR/ACR_ACPT_Assessed.aspx");
        
        routes.MapPageRoute("PHACR_Rev_Officer/{UID}", "PHACR_Rev_Officer/{UID}", "~/ProjectStaff/RACR/ACR_Reviewing_Officer_Assmt_waiting.aspx");
         routes.MapPageRoute("PHACR_Accept_Officer/{UID}", "PHACR_Accept_Officer/{UID}", "~/ProjectStaff/RACR/ACR_Accept_Officer_Assmt_waiting.aspx");

        routes.MapPageRoute("PH4_1_ACR_RevOff_LengthOfService/{UID}", "PH4_1_ACR_RevOff_LengthOfService/{UID}", "~/ProjectStaff/RACR/4_1_ACR_RevOff_LengthOfService.aspx");
        routes.MapPageRoute("PH4_2_ACR_RevOff_Satisfy_RPTStatus/{UID}", "PH4_2_ACR_RevOff_Satisfy_RPTStatus/{UID}", "~/ProjectStaff/RACR/4_2_ACR_RevOff_Satisfy_RPTStatus.aspx");
        routes.MapPageRoute("PH4_3_ACR_RevOff_PenPicture/{UID}", "PH4_3_ACR_RevOff_PenPicture/{UID}", "~/ProjectStaff/RACR/4_3_ACR_RevOff_PenPicture.aspx");
        routes.MapPageRoute("PH4_4_1_ACR_Rev_Officer_WorkOutput/{UID}", "PH4_4_1_ACR_Rev_Officer_WorkOutput/{UID}", "~/ProjectStaff/RACR/4_4_1_ACR_Rev_Officer_WorkOutput.aspx");
        routes.MapPageRoute("PH4_4_2_ACR_Rev_Officer_FunComptncy/{UID}", "PH4_4_2_ACR_Rev_Officer_FunComptncy/{UID}", "~/ProjectStaff/RACR/4_4_2_ACR_Rev_Officer_FunComptncy.aspx");
        routes.MapPageRoute("PH4_4_3_ACR_Rev_Officer_PerAttributes/{UID}", "PH4_4_3_ACR_Rev_Officer_PerAttributes/{UID}", "~/ProjectStaff/RACR/4_4_3_ACR_Rev_Officer_PerAttributes.aspx");
        routes.MapPageRoute("PH4_4_4_ACR_Rev_Officer_SPLAttributes/{UID}", "PH4_4_4_ACR_Rev_Officer_SPLAttributes/{UID}", "~/ProjectStaff/RACR/4_4_4_ACR_Rev_Officer_SPLAttributes.aspx");

        routes.MapPageRoute("PH5_1_ACR_Accept_Off_LengthOfService/{UID}", "PH5_1_ACR_Accept_Off_LengthOfService/{UID}", "~/ProjectStaff/RACR/5_1_ACR_Accept_Off_LengthOfService.aspx");
        routes.MapPageRoute("PH5_2_ACR_Accept_Off_Satisfy_RPTStatus/{UID}", "PH5_2_ACR_Accept_Off_Satisfy_RPTStatus/{UID}", "~/ProjectStaff/RACR/5_2_ACR_Accept_Off_Satisfy_RPTStatus.aspx");
        routes.MapPageRoute("PH5_3_ACR_Accept_Off_PenPicture/{UID}", "PH5_3_ACR_Accept_Off_PenPicture/{UID}", "~/ProjectStaff/RACR/5_3_ACR_Accept_Off_PenPicture.aspx");
        routes.MapPageRoute("PH5_4_ACR_Accept_Off_Grading/{UID}", "PH5_4_ACR_Accept_Off_Grading/{UID}", "~/ProjectStaff/RACR/5_4_ACR_Accept_Off_Grading.aspx");
        routes.MapPageRoute("PH4_ACR_Reviewing_Officer_Preview/{UID}", "PH4_ACR_Reviewing_Officer_Preview/{UID}", "~/ProjectStaff/RACR/4_ACR_Reviewing_Officer_Preview.aspx");
        routes.MapPageRoute("PH5_ACR_Accept_Officer_Preview/{UID}", "PH5_ACR_Accept_Officer_Preview/{UID}", "~/ProjectStaff/RACR/5_ACR_Accept_Officer_Preview.aspx");

        // HOC ACR
        routes.MapPageRoute("HEmp_RACR_Home/{UID}", "HEmp_RACR_Home/{UID}", "~/HOC/RACR/RACRHome.aspx");
        routes.MapPageRoute("HEmp_RACR_PerData/{UID}", "HEmp_RACR_PerData/{UID}", "~/HOC/RACR/1_PersonalData.aspx");
        routes.MapPageRoute("ACR_Workflow/{UID}", "ACR_Workflow/{UID}", "~/eLeave/ACRSingleMapLeaveFlow.aspx");
        routes.MapPageRoute("ACR_AWorkflow/{UID}", "ACR_AWorkflow/{UID}", "~/eLeave/ACRPrintLeaveWorkFlow2.aspx");
        routes.MapPageRoute("ACR_Reports_Status/{UID}", "ACR_Reports_Status/{UID}", "~/eLeave/ACR_Reports_Status.aspx");

        routes.MapPageRoute("P34MasterAssOP/{UID}", "P34MasterAssOP/{UID}", "~/eLeave/3_4_Master_AssWorkOutput.aspx");
        routes.MapPageRoute("P34MasterAssFC/{UID}", "P34MasterAssFC/{UID}", "~/eLeave/3_4_Master_AssFinCompetency.aspx");
        routes.MapPageRoute("P34MasterAssPA/{UID}", "P34MasterAssPA/{UID}", "~/eLeave/3_4_Master_AssPersonalAttributes.aspx");
        routes.MapPageRoute("P34MasterAssSA/{UID}", "P34MasterAssSA/{UID}", "~/eLeave/3_4_Master_AssSpecialAttributes.aspx");

        routes.MapPageRoute("ACR_RPTO_Preview/{UID}", "ACR_RPTO_Preview/{UID}", "~/HOC/RACR/ACR_Reporting_Officer_Preview.aspx");
        routes.MapPageRoute("3_3_ACRRpt_Officer_General/{UID}", "3_3_ACRRpt_Officer_General/{UID}", "~/HOC/RACR/3_3_ACRRpt_Officer_General.aspx");
        routes.MapPageRoute("3_2_4_ACRRpt_Officer_SPLAttributes/{UID}", "3_2_4_ACRRpt_Officer_SPLAttributes/{UID}", "~/HOC/RACR/3_2_4_ACRRpt_Officer_SPLAttributes.aspx");
        routes.MapPageRoute("3_2_3_ACRRpt_Officer_PerAttributes/{UID}", "3_2_3_ACRRpt_Officer_PerAttributes/{UID}", "~/HOC/RACR/3_2_3_ACRRpt_Officer_PerAttributes.aspx");
        routes.MapPageRoute("3_2_2_ACRRpt_Officer_FunComptncy/{UID}", "3_2_2_ACRRpt_Officer_FunComptncy/{UID}", "~/HOC/RACR/3_2_2_ACRRpt_Officer_FunComptncy.aspx");
        routes.MapPageRoute("3_2_1_ACRRpt_Officer_WorkOutput/{UID}", "3_2_1_ACRRpt_Officer_WorkOutput/{UID}", "~/HOC/RACR/3_2_1_ACRRpt_Officer_WorkOutput.aspx");
        routes.MapPageRoute("3_1_ACRRpt_Off_Action/{UID}", "3_1_ACRRpt_Off_Action/{UID}", "~/HOC/RACR/3_1_ACRRpt_Officer_Action.aspx");
        routes.MapPageRoute("ACRRpt_Off_Action/{UID}", "ACRRpt_Off_Action/{UID}", "~/HOC/RACR/ACR_Reporting_Officer_Action.aspx");
        routes.MapPageRoute("ACRReV_Off_Action/{UID}", "ACRReV_Off_Action/{UID}", "~/HOC/RACR/ACR_Reviewing_Officer_Action.aspx");
        routes.MapPageRoute("ACRAccept_Off_Action/{UID}", "ACRAccept_Off_Action/{UID}", "~/HOC/RACR/ACR_Accept_Officer_Action.aspx");
        routes.MapPageRoute("ACR_New_Rpt_Off_Action/{UID}", "ACR_New_Rpt_Off_Action/{UID}", "~/HOC/RACR/ACR_NewLayout_Rpt_Officer_Action.aspx"); // New Layout
        routes.MapPageRoute("ACR_New_Rpt_Off_Preview/{UID}", "ACR_New_Rpt_Off_Preview/{UID}", "~/HOC/RACR/ACR_NewLayout_Rpt_Officer_Preview.aspx");

        routes.MapPageRoute("ACR_New_Rev_Off_Action/{UID}", "ACR_New_Rev_Off_Action/{UID}", "~/HOC/RACR/ACR_NewLayout_Reviewing_Officer_Action.aspx"); // New Layout
        routes.MapPageRoute("ACR_New_Rev_Off_Preview/{UID}", "ACR_New_Rev_Off_Preview/{UID}", "~/HOC/RACR/ACR_NewLayout_Reviewing_Officer_Preview.aspx");

        routes.MapPageRoute("ACR_New_Accept_Off_Action/{UID}", "ACR_New_Accept_Off_Action/{UID}", "~/HOC/RACR/ACR_NewLayout_Accept_Officer_Action.aspx"); // New Layout
        routes.MapPageRoute("ACR_New_Accept_Off_Preview/{UID}", "ACR_New_Accept_Off_Preview/{UID}", "~/HOC/RACR/ACR_NewLayout_Accept_Officer_Preview.aspx");

        
        routes.MapPageRoute("ACRRpt_Rev_accpt/{UID}", "ACRRpt_Rev_accpt/{UID}", "~/HOC/RACR/ACR_Reporting_Officer_Assmt_waiting.aspx");
        routes.MapPageRoute("ACR_Rev_Officer/{UID}", "ACR_Rev_Officer/{UID}", "~/HOC/RACR/ACR_Reviewing_Officer_Assmt_waiting.aspx");
        routes.MapPageRoute("ACR_Accept_Officer/{UID}", "ACR_Accept_Officer/{UID}", "~/HOC/RACR/ACR_Accept_Officer_Assmt_waiting.aspx");

        routes.MapPageRoute("4_1_ACR_RevOff_LengthOfService/{UID}", "4_1_ACR_RevOff_LengthOfService/{UID}", "~/HOC/RACR/4_1_ACR_RevOff_LengthOfService.aspx");
        routes.MapPageRoute("4_2_ACR_RevOff_Satisfy_RPTStatus/{UID}", "4_2_ACR_RevOff_Satisfy_RPTStatus/{UID}", "~/HOC/RACR/4_2_ACR_RevOff_Satisfy_RPTStatus.aspx");
        routes.MapPageRoute("4_3_ACR_RevOff_PenPicture/{UID}", "4_3_ACR_RevOff_PenPicture/{UID}", "~/HOC/RACR/4_3_ACR_RevOff_PenPicture.aspx");
        routes.MapPageRoute("4_4_1_ACR_Rev_Officer_WorkOutput/{UID}", "4_4_1_ACR_Rev_Officer_WorkOutput/{UID}", "~/HOC/RACR/4_4_1_ACR_Rev_Officer_WorkOutput.aspx");
        routes.MapPageRoute("4_4_2_ACR_Rev_Officer_FunComptncy/{UID}", "4_4_2_ACR_Rev_Officer_FunComptncy/{UID}", "~/HOC/RACR/4_4_2_ACR_Rev_Officer_FunComptncy.aspx");
        routes.MapPageRoute("4_4_3_ACR_Rev_Officer_PerAttributes/{UID}", "4_4_3_ACR_Rev_Officer_PerAttributes/{UID}", "~/HOC/RACR/4_4_3_ACR_Rev_Officer_PerAttributes.aspx");
        routes.MapPageRoute("4_4_4_ACR_Rev_Officer_SPLAttributes/{UID}", "4_4_4_ACR_Rev_Officer_SPLAttributes/{UID}", "~/HOC/RACR/4_4_4_ACR_Rev_Officer_SPLAttributes.aspx");

        routes.MapPageRoute("5_1_ACR_Accept_Off_LengthOfService/{UID}", "5_1_ACR_Accept_Off_LengthOfService/{UID}", "~/HOC/RACR/5_1_ACR_Accept_Off_LengthOfService.aspx");
        routes.MapPageRoute("5_2_ACR_Accept_Off_Satisfy_RPTStatus/{UID}", "5_2_ACR_Accept_Off_Satisfy_RPTStatus/{UID}", "~/HOC/RACR/5_2_ACR_Accept_Off_Satisfy_RPTStatus.aspx");
        routes.MapPageRoute("5_3_ACR_Accept_Off_PenPicture/{UID}", "5_3_ACR_Accept_Off_PenPicture/{UID}", "~/HOC/RACR/5_3_ACR_Accept_Off_PenPicture.aspx");
        routes.MapPageRoute("5_4_ACR_Accept_Off_Grading/{UID}", "5_4_ACR_Accept_Off_Grading/{UID}", "~/HOC/RACR/5_4_ACR_Accept_Off_Grading.aspx");
        routes.MapPageRoute("4_ACR_Reviewing_Officer_Preview/{UID}", "4_ACR_Reviewing_Officer_Preview/{UID}", "~/HOC/RACR/4_ACR_Reviewing_Officer_Preview.aspx");
        routes.MapPageRoute("5_ACR_Accept_Officer_Preview/{UID}", "5_ACR_Accept_Officer_Preview/{UID}", "~/HOC/RACR/5_ACR_Accept_Officer_Preview.aspx");


        routes.MapPageRoute("SubmittedACRs/{UID}", "SubmittedACRs/{UID}", "~/HOC/RACR/SubmittedACRs.aspx");
        routes.MapPageRoute("HEmp_RACR_2Appraisal/{UID}", "HEmp_RACR_2Appraisal/{UID}", "~/HOC/RACR/2_1_SelfAppraisal.aspx");
        routes.MapPageRoute("HEmp_RACR_2_2_1_TP/{UID}", "HEmp_RACR_2_2_1_TP/{UID}", "~/HOC/RACR/2_2_1_TrainingProgrammes.aspx");
        routes.MapPageRoute("HEmp_RACR_2_2_2_Research/{UID}", "HEmp_RACR_2_2_2_Research/{UID}", "~/HOC/RACR/2_2_2_Research.aspx");
        routes.MapPageRoute("HEmp_RACR_2_2_3_RP/{UID}", "HEmp_RACR_2_2_3_RP/{UID}", "~/HOC/RACR/2_2_3_ResearchPapers.aspx");
        routes.MapPageRoute("HEmp_RACR_2_2_4_Policy/{UID}", "HEmp_RACR_2_2_4_Policy/{UID}", "~/HOC/RACR/2_2_4_PlicyAdvocacy.aspx");
        routes.MapPageRoute("HEmp_RACR_2_2_5_WorkingPapers/{UID}", "HEmp_RACR_2_2_5_WorkingPapers/{UID}", "~/HOC/RACR/2_2_5_WorkingPapers.aspx");
        routes.MapPageRoute("HEmp_RACR_2_2_6_Books_Chapters/{UID}", "HEmp_RACR_2_2_6_Books_Chapters/{UID}", "~/HOC/RACR/2_2_6_Books_Chapters.aspx");
        routes.MapPageRoute("HEmp_RACR_2_2_7_SCWs/{UID}", "HEmp_RACR_2_2_7_SCWs/{UID}", "~/HOC/RACR/2_2_7_Seminars_Confs_Workshops.aspx");
        routes.MapPageRoute("HEmp_RACR_2_2_8_RA/{UID}", "HEmp_RACR_2_2_8_RA/{UID}", "~/HOC/RACR/2_2_8_Reviews_Abstraction.aspx");
        routes.MapPageRoute("HEmp_RACR_2_2_9_Guidance/{UID}", "HEmp_RACR_2_2_9_Guidance/{UID}", "~/HOC/RACR/2_2_9_Guidance.aspx");
        routes.MapPageRoute("HEmp_RACR_2_2_10_Spec/{UID}", "HEmp_RACR_2_2_10_Spec/{UID}", "~/HOC/RACR/2_2_10_Specialization.aspx");
        routes.MapPageRoute("HEmp_RACR_2_2_11_Others/{UID}", "HEmp_RACR_2_2_11_Others/{UID}", "~/HOC/RACR/2_2_11_AnyOthers.aspx");
        routes.MapPageRoute("2_3_1_1A_TrainProgs/{UID}", "2_3_1_1A_TrainProgs/{UID}", "~/HOC/RACR/2_3_1_1A_TrainingProgs.aspx");
        routes.MapPageRoute("2_3_1_1B_PGCourses/{UID}", "2_3_1_1B_PGCourses/{UID}", "~/HOC/RACR/2_3_1_1B_PGCourses.aspx");
        routes.MapPageRoute("2_3_1_2A_WorkShops/{UID}", "2_3_1_2A_WorkShops/{UID}", "~/HOC/RACR/2_3_1_2A_WorkShops.aspx");
        routes.MapPageRoute("2_3_1_2B_Seminars/{UID}", "2_3_1_2B_Seminars/{UID}", "~/HOC/RACR/2_3_1_2B_Seminars.aspx");
        routes.MapPageRoute("2_3_1_3_NewTPC/{UID}", "2_3_1_3_NewTPC/{UID}", "~/HOC/RACR/2_3_1_3_NewTPC.aspx");
        routes.MapPageRoute("2_3_1_4_NewCMM/{UID}", "2_3_1_4_NewCMM/{UID}", "~/HOC/RACR/2_3_1_4_NewCMM.aspx");
        routes.MapPageRoute("2_3_2_A_NIRDResearch/{UID}", "2_3_2_A_NIRDResearch/{UID}", "~/HOC/RACR/2_3_2_A_NIRDPRResearch.aspx");
        routes.MapPageRoute("2_3_2_B_ConsultResearch/{UID}", "2_3_2_B_ConsultResearch/{UID}", "~/HOC/RACR/2_3_2_B_ConsultResearch.aspx");
        routes.MapPageRoute("2_3_2_C_ActionResearch/{UID}", "2_3_2_C_ActionResearch/{UID}", "~/HOC/RACR/2_3_2_C_ActionResearch.aspx");
        routes.MapPageRoute("2_3_3_A_RP/{UID}", "2_3_3_A_RP/{UID}", "~/HOC/RACR/2_3_3_A_ResearchPublications.aspx");
        routes.MapPageRoute("2_3_3_B_Books/{UID}", "2_3_3_B_Books/{UID}", "~/HOC/RACR/2_3_3_B_Books.aspx");
        routes.MapPageRoute("2_3_3_C_ChaptersInBooks/{UID}", "2_3_3_C_ChaptersInBooks/{UID}", "~/HOC/RACR/2_3_3_C_ChaptersInBooks.aspx");
        routes.MapPageRoute("2_3_3_D_PolicyAdvocacy/{UID}", "2_3_3_D_PolicyAdvocacy/{UID}", "~/HOC/RACR/2_3_3_D_PolicyAdvocacy.aspx");
        routes.MapPageRoute("2_3_4_1_Reviews/{UID}", "2_3_4_1_Reviews/{UID}", "~/HOC/RACR/2_3_4_1_Reviews.aspx");
        routes.MapPageRoute("2_3_4_2_Abstracting/{UID}", "2_3_4_2_Abstracting/{UID}", "~/HOC/RACR/2_3_4_2_Abstracting.aspx");
        routes.MapPageRoute("2_3_5_PAP/{UID}", "2_3_5_PAP/{UID}", "~/HOC/RACR/2_3_5_ProgAttPresented.aspx");
        routes.MapPageRoute("2_3_6_Guidance/{UID}", "2_3_6_Guidance/{UID}", "~/HOC/RACR/2_3_6_Guidance.aspx");
        routes.MapPageRoute("2_3_7_COnline/{UID}", "2_3_7_COnline/{UID}", "~/HOC/RACR/2_3_7_Certif_Online.aspx");
        routes.MapPageRoute("2_4_1_ECAct/{UID}", "2_4_1_ECAct/{UID}", "~/HOC/RACR/2_4_1_Extra_Curr_Act.aspx");
        routes.MapPageRoute("2_4_2_ImpTasks/{UID}", "2_4_2_ImpTasks/{UID}", "~/HOC/RACR/2_4_2_ImpTasks.aspx");
        routes.MapPageRoute("2_4_3_Achievements/{UID}", "2_4_3_Achievements/{UID}", "~/HOC/RACR/2_4_3_Achievements.aspx");
        routes.MapPageRoute("2_4_4_Innovations/{UID}", "2_4_4_Innovations/{UID}", "~/HOC/RACR/2_4_4_Innovations.aspx");
        routes.MapPageRoute("2_4_5_Constraints/{UID}", "2_4_5_Constraints/{UID}", "~/HOC/RACR/2_4_5_Constraints.aspx");
        routes.MapPageRoute("2_7_AreaofInterest/{UID}", "2_7_AreaofInterest/{UID}", "~/HOC/RACR/2_7_AreaofInterest.aspx");
        routes.MapPageRoute("1_AppraisalPreview/{UID}", "1_AppraisalPreview/{UID}", "~/HOC/RACR/1_AppraisalPreview.aspx");
        //HOC
        routes.MapPageRoute("HEmp/{UID}", "HEmp/{UID}", "~/HOC/EmpHome.aspx");
        routes.MapPageRoute("HEmp_OPS/{UID}", "HEmp_OPS/{UID}", "~/HOC/RFinance/OldPaySlips.aspx");
        routes.MapPageRoute("HEmp_VI/{UID}", "HEmp_VI/{UID}", "~/HOC/RVehicle/IndentforVehicle.aspx");

        routes.MapPageRoute("HEmp_SVI/{UID}", "HEmp_SVI/{UID}", "~/HOC/RVehicle/ShowNewVehicleIndent.aspx");
        routes.MapPageRoute("HEmp_NPVI/{UID}", "HEmp_NPVI/{UID}", "~/HOC/RVehicle/NewPendingVechicleIndents.aspx");
        routes.MapPageRoute("HEmp_NVIPH/{UID}", "HEmp_NVIPH/{UID}", "~/HOC/RVehicle/NewlySubmittedPendVehIndents.aspx");
        routes.MapPageRoute("HEmp_ANVIPH/{UID}", "HEmp_ANVIPH/{UID}", "~/HOC/ANewlySubmittedPendVehIndents.aspx");
        routes.MapPageRoute("HEmp_Approved/{UID}", "HEmp_Approved/{UID}", "~/HOC/RStores/RVehicle/AllConfirmedIndents.aspx");
        routes.MapPageRoute("HEmp_ETR/{UID}", "HEmp_ETR/{UID}", "~/HOC/RTour/SubmitTourReport.aspx");

        routes.MapPageRoute("HEmp_GVI/{UID}", "HEmp_GVI/{UID}", "~/HOC/RVehicle/GroupIndentforVehicle.aspx");

        routes.MapPageRoute("HEmp_Pay/{UID}", "HEmp_Pay/{UID}", "~/HOC/RFinance/EmpSalaryInfo.aspx");


        routes.MapPageRoute("HEmp_CITInv/{UID}", "HEmp_CITInv/{UID}", "~/HOC/RGeneral/CITInventory.aspx");
        routes.MapPageRoute("HEmp_CITeTKT/{UID}", "HEmp_CITeTKT/{UID}", "~/HOC/CICTeTicketing.aspx");
        routes.MapPageRoute("HEmp_TiP/{UID}", "HEmp_TiP/{UID}", "~/HOC/CICTIniatedETickets.aspx");
        routes.MapPageRoute("HEmp_THistory/{UID}", "HEmp_THistory/{UID}", "~/HOC/CICTClosedETickets.aspx");
        routes.MapPageRoute("HEmp_THold/{UID}", "HEmp_THold/{UID}", "~/HOC/CICTHoldETickets.aspx");
        routes.MapPageRoute("HEmp_PSValidate/{UID}", "HEmp_PSValidate/{UID}", "~/HOC/HOC_ValidateProjectStaff.aspx");


        routes.MapPageRoute("HEmp_FInv/{UID}", "HEmp_FInv/{UID}", "~/HOC/RFinance/Fin_InvoiceEntry.aspx");

        routes.MapPageRoute("HEmp_HCFamily/{UID}", "HEmp_HCFamily/{UID}", "~/HOC/RHealth/HC_Emp_FamilyDetails.aspx");
        routes.MapPageRoute("HEmp_HCFamily_Edit/{UID}", "HEmp_HCFamily_Edit/{UID}", "~/HOC/RHealth/HC_EditFamilyDetails_Emp.aspx");
        routes.MapPageRoute("HEmp_HCFamilyMedUsage/{UID}", "HEmp_HCFamilyMedUsage/{UID}", "~/HOC/RHealth/HC_Emp_MedUsage.aspx");

        // Engineering Ticketing

        routes.MapPageRoute("HEmp_eComplaint/{UID}", "HEmp_eComplaint/{UID}", "~/HOC/RComplaints/ENGG_NewComplaint.aspx");
        routes.MapPageRoute("HEmp_InProgess/{UID}", "HEmp_InProgess/{UID}", "~/HOC/RComplaints/ENGG_InProgressComplaints.aspx");
        routes.MapPageRoute("HEmp_Hold/{UID}", "HEmp_Hold/{UID}", "~/HOC/RComplaints/ENGG_HoldComplaints.aspx");
        routes.MapPageRoute("HEmp_Closed/{UID}", "HEmp_Closed/{UID}", "~/HOC/RComplaints/ENGG_ClosedComplaints.aspx");
        routes.MapPageRoute("HEmp_AssignComplaint/{UID}", "HEmp_AssignComplaint/{UID}", "~/HOC/RComplaints/ENGG_TicketAssign.aspx");
        routes.MapPageRoute("HEmp_eResolveComplaint/{UID}", "HEmp_eResolveComplaint/{UID}", "~/HOC/RComplaints/ENGG_CompalintApproval.aspx");
        routes.MapPageRoute("HEmp_eResolveCIP/{UID}", "HEmp_eResolveCIP/{UID}", "~/HOC/RComplaints/ENGG_CompalintApproval_InProgress.aspx");
        routes.MapPageRoute("HEmp_eResolveCHold/{UID}", "HEmp_eResolveCHold/{UID}", "~/HOC/RComplaints/ENGG_CompalintApproval_Hold.aspx");
        routes.MapPageRoute("HEmp_eCClosed/{UID}", "HEmp_eCClosed/{UID}", "~/HOC/RComplaints/ENGG_Compalint_Closed.aspx");
        routes.MapPageRoute("HEmp_Officer_eComments/{UID}", "HEmp_Officer_eComments/{UID}", "~/HOC/RComplaints/ENGG_TicketComments.aspx");
        routes.MapPageRoute("HEmp_User_eComments/{UID}", "HEmp_User_eComments/{UID}", "~/HOC/RComplaints/ENGG_TicketUserComments.aspx");

        routes.MapPageRoute("ET_AddProbCategory/{UID}", "ET_AddProbCategory/{UID}", "~/CMU_Ticketing/ET_AddComplaintType.aspx");
        routes.MapPageRoute("ET_mapOfficer/{UID}", "ET_mapOfficer/{UID}", "~/CMU_Ticketing/ET_MapOfficer.aspx");
        routes.MapPageRoute("ET_OnHold/{UID}", "ET_OnHold/{UID}", "~/CMU_Ticketing/ENGG_HoldComplaints.aspx");
        routes.MapPageRoute("ET_IP/{UID}", "ET_IP/{UID}", "~/CMU_Ticketing/ENGG_InProgressComplaints.aspx");
        routes.MapPageRoute("ET_Closed/{UID}", "ET_Closed/{UID}", "~/CMU_Ticketing/ENGG_ClosedComplaints.aspx");
        routes.MapPageRoute("ET_New/{UID}", "ET_New/{UID}", "~/CMU_Ticketing/ENGG_NewComplaints.aspx");

        // Project Staff CMU Ticketing
        routes.MapPageRoute("PEmp_eComplaint/{UID}", "PEmp_eComplaint/{UID}", "~/ProjectStaff/PComplaints/ENGG_NewComplaint.aspx");
        routes.MapPageRoute("PEmp_InProgess/{UID}", "PEmp_InProgess/{UID}", "~/ProjectStaff/PComplaints/ENGG_InProgressComplaints.aspx");
        routes.MapPageRoute("PEmp_Hold/{UID}", "PEmp_Hold/{UID}", "~/ProjectStaff/PComplaints/ENGG_HoldComplaints.aspx");
        routes.MapPageRoute("PEmp_Closed/{UID}", "PEmp_Closed/{UID}", "~/ProjectStaff/PComplaints/ENGG_ClosedComplaints.aspx");
        routes.MapPageRoute("PEmp_AssignComplaint/{UID}", "PEmp_AssignComplaint/{UID}", "~/ProjectStaff/PComplaints/ENGG_TicketAssign.aspx");
        routes.MapPageRoute("PEmp_eResolveComplaint/{UID}", "PEmp_eResolveComplaint/{UID}", "~/ProjectStaff/PComplaints/ENGG_CompalintApproval.aspx");
        routes.MapPageRoute("PEmp_eResolveCIP/{UID}", "PEmp_eResolveCIP/{UID}", "~/ProjectStaff/PComplaints/ENGG_CompalintApproval_InProgress.aspx");
        routes.MapPageRoute("PEmp_eResolveCHold/{UID}", "PEmp_eResolveCHold/{UID}", "~/ProjectStaff/PComplaints/ENGG_CompalintApproval_Hold.aspx");
        routes.MapPageRoute("PEmp_Officer_eComments/{UID}", "PEmp_Officer_eComments/{UID}", "~/ProjectStaff/PComplaints/ENGG_TicketComments.aspx");
        routes.MapPageRoute("PEmp_User_eComments/{UID}", "PEmp_User_eComments/{UID}", "~/ProjectStaff/PComplaints/ENGG_TicketUserComments.aspx");

        // Proj Staff User
        routes.MapPageRoute("PEmp_LJRCEforApproval/{UID}", "PEmp_LJRCEforApproval/{UID}", "~/ProjectStaff/PLeave/Leaves_JR_Curt_Ext_ForApproval.aspx");
        routes.MapPageRoute("PEmp_LJRCEApAction/{UID}", "PEmp_LJRCEApAction/{UID}", "~/ProjectStaff/PLeave/Leaves_JR_Curt_Ext_Action.aspx");
        routes.MapPageRoute("PEmp_myALJR/{UID}", "PEmp_myALJR/{UID}", "~/ProjectStaff/PLeave/Leaves_JR_Ext_Curt_Approved4me.aspx");

        routes.MapPageRoute("PEmp_Home/{UID}", "PEmp_Home/{UID}", "~/ProjectStaff/PS_MainHome.aspx");
        routes.MapPageRoute("PEmp_Att_Home/{UID}", "PEmp_Att_Home/{UID}", "~/ProjectStaff/PAttendance/PAttHome.aspx");
        routes.MapPageRoute("PEmp_Complaint_Home/{UID}", "PEmp_Complaint_Home/{UID}", "~/ProjectStaff/PComplaints/PComplaintsHome.aspx");
        routes.MapPageRoute("PEmp_Finance_Home/{UID}", "PEmp_Finance_Home/{UID}", "~/ProjectStaff/PFinance/PFinanceHome.aspx");
        routes.MapPageRoute("PEmp_General_Home/{UID}", "PEmp_General_Home/{UID}", "~/ProjectStaff/PGeneral/StaffInfo.aspx");
        routes.MapPageRoute("PEmp_Leave_Home/{UID}", "PEmp_Leave_Home/{UID}", "~/ProjectStaff/PLeave/PLeaveHome.aspx");
        routes.MapPageRoute("PEmp_Store_Home/{UID}", "PEmp_Store_Home/{UID}", "~/ProjectStaff/PStores/PStoresHome.aspx");
        routes.MapPageRoute("PEmp_Tour_Home/{UID}", "PEmp_Tour_Home/{UID}", "~/ProjectStaff/PTour/PTourHome.aspx");
        routes.MapPageRoute("PEmp_PSServInfo/{UID}", "PEmp_PSServInfo/{UID}", "~/ProjectStaff/PGeneral/PSServiceInfo.aspx");

        routes.MapPageRoute("PGeneral_WPList/{UID}", "PGeneral_WPList/{UID}", "~/ProjectStaff/PGeneral/WebnarTrainingList.aspx");
        routes.MapPageRoute("PGeneral_WPListMail/{UID}", "PGeneral_WPListMail/{UID}", "~/ProjectStaff/PGeneral/WebnarTrainingList_Mail.aspx");
        
        routes.MapPageRoute("PEmp/{UID}", "PEmp/{UID}", "~/ProjectStaff/PGeneral/PSHome.aspx");
        routes.MapPageRoute("PEmp_CP/{UID}", "PEmp_CP/{UID}", "~/ProjectStaff/PGeneral/ChangePassword.aspx");
        routes.MapPageRoute("PEmp_Contact/{UID}", "PEmp_Contact/{UID}", "~/ProjectStaff/PGeneral/NirdContactsList.aspx");
        routes.MapPageRoute("PEmp_CITInv/{UID}", "PEmp_CITInv/{UID}", "~/ProjectStaff/PGeneral/CITInventory.aspx");
        routes.MapPageRoute("PEmp_CITeTKT/{UID}", "PEmp_CITeTKT/{UID}", "~/ProjectStaff/CICTeTicketing.aspx");
        routes.MapPageRoute("PEmp_TiP/{UID}", "PEmp_TiP/{UID}", "~/ProjectStaff/CICTIniatedETickets.aspx");
        routes.MapPageRoute("PEmp_THistory/{UID}", "PEmp_THistory/{UID}", "~/ProjectStaff/CICTClosedETickets.aspx");
        routes.MapPageRoute("PEmp_THold/{UID}", "PEmp_THold/{UID}", "~/ProjectStaff/CICTHoldETickets.aspx");
        routes.MapPageRoute("PEmp_ETR/{UID}", "PEmp_ETR/{UID}", "~/ProjectStaff/PTour/SubmitTourReport.aspx");
        routes.MapPageRoute("PEmp_BAStatus/{UID}", "PEmp_BAStatus/{UID}", "~/ProjectStaff/PAttendance/BioMetricAttStatus.aspx");
        routes.MapPageRoute("PEmp_BAHStatus/{UID}", "PEmp_BAHStatus/{UID}", "~/ProjectStaff/PAttendance/BioMetricAtt_HourStatus.aspx");
        routes.MapPageRoute("PEmp_ECont/{UID}", "PEmp_ECont/{UID}", "~/ProjectStaff/PGeneral/EditContactDetails.aspx");
        routes.MapPageRoute("PEmp_Eph/{UID}", "PEmp_Eph/{UID}", "~/ProjectStaff/PGeneral/ChangePhoto.aspx");
        routes.MapPageRoute("PEmp_Late/{UID}", "PEmp_Late/{UID}", "~/ProjectStaff/PLeave/PS_LateRequest.aspx");
        routes.MapPageRoute("PEmp_LateApprvl/{UID}", "PEmp_LateApprvl/{UID}", "~/ProjectStaff/PLeave/PSH_LateRequestApproval.aspx");
        routes.MapPageRoute("PEmp_EHoc/{UID}", "PEmp_EHoc/{UID}", "~/ProjectStaff/PGeneral/EditCentreHead.aspx");
        routes.MapPageRoute("PEmp_EDept/{UID}", "PEmp_EDept/{UID}", "~/ProjectStaff/PGeneral/EditUserDepartment.aspx");
        routes.MapPageRoute("PEmp_EProfile/{UID}", "PEmp_EProfile/{UID}", "~/ProjectStaff/PGeneral/PSProfile.aspx");
        routes.MapPageRoute("PEmp_PS_Bio/{UID}", "PEmp_PS_Bio/{UID}", "~/ProjectStaff/PAttendance/PS_MonthlyBioMetricAttStatus.aspx");
        routes.MapPageRoute("PEmp_APSL/{UID}", "PEmp_APSL/{UID}", "~/ProjectStaff/PLeave/PSLeaveApply.aspx");
        routes.MapPageRoute("PEmp_ACL/{UID}", "PEmp_ACL/{UID}", "~/ProjectStaff/PLeave/LeaveApplyPS.aspx");
        routes.MapPageRoute("PEmp_CLApplied/{UID}", "PEmp_CLApplied/{UID}", "~/ProjectStaff/PLeave/PSLeavesApplied.aspx");
        routes.MapPageRoute("PEmp_CLApprvd/{UID}", "PEmp_CLApprvd/{UID}", "~/ProjectStaff/PLeave/PSLeavesApproved.aspx");
        routes.MapPageRoute("PEmp_CLRej/{UID}", "PEmp_CLRej/{UID}", "~/ProjectStaff/PLeave/PSLeavesRejected.aspx");
        routes.MapPageRoute("PEmp_CLCancld/{UID}", "PEmp_CLCancld/{UID}", "~/ProjectStaff/PLeave/PSLeavesCancelled.aspx");
        routes.MapPageRoute("PHEmp_LApproval/{UID}", "PHEmp_LApproval/{UID}", "~/ProjectStaff/PLeave/PSLH_LeavesForApproval.aspx");
        routes.MapPageRoute("PHEmp_LAAction/{UID}", "PHEmp_LAAction/{UID}", "~/ProjectStaff/PLeave/PSLH_LeaveAction.aspx");
        routes.MapPageRoute("PHEmp_LARecmded/{UID}", "PHEmp_LARecmded/{UID}", "~/ProjectStaff/PLeave/PSLH_LeavesRecommended.aspx");
        routes.MapPageRoute("PHEmp_LApprvd/{UID}", "PHEmp_LApprvd/{UID}", "~/ProjectStaff/PLeave/PSLH_LeavesApproved.aspx");
        routes.MapPageRoute("PHEmp_LARejtd/{UID}", "PHEmp_LARejtd/{UID}", "~/ProjectStaff/PLeave/PSLH_LeavesRejected.aspx");
        routes.MapPageRoute("PHEmp_PSValidate/{UID}", "PHEmp_PSValidate/{UID}", "~/ProjectStaff/PGeneral/HOC_ValidateProjectStaff.aspx");
        routes.MapPageRoute("PHEmp_PCLs/{UID}", "PHEmp_PCLs/{UID}", "~/ProjectStaff/PGeneral/AddProjectStaffCLs.aspx");
        routes.MapPageRoute("PHEmp_UPCLs/{UID}", "PHEmp_UPCLs/{UID}", "~/ProjectStaff/PGeneral/AUpdateProjectStaffCLs.aspx");

        routes.MapPageRoute("PEmp_APT/{UID}", "PEmp_APT/{UID}", "~/ProjectStaff/PTour/PST_ApplyforTour.aspx");
        routes.MapPageRoute("PEmp_PTApplied/{UID}", "PEmp_PTApplied/{UID}", "~/ProjectStaff/PTour/PST_ToursApplied.aspx");
        routes.MapPageRoute("PEmp_PTApprvd/{UID}", "PEmp_PTApprvd/{UID}", "~/ProjectStaff/PTour/PST_ToursApproved.aspx");
        routes.MapPageRoute("PEmp_PTRej/{UID}", "PEmp_PTRej/{UID}", "~/ProjectStaff/PTour/PST_ToursRejected.aspx");
        routes.MapPageRoute("PEmp_PTCancld/{UID}", "PEmp_PTCancld/{UID}", "~/ProjectStaff/PTour/PST_ToursCancelled.aspx");
        routes.MapPageRoute("PHEmp_TApproval/{UID}", "PHEmp_TApproval/{UID}", "~/ProjectStaff/PTour/PSTH_ToursForApproval.aspx");
        routes.MapPageRoute("PHEmp_TAAction/{UID}", "PHEmp_TAAction/{UID}", "~/ProjectStaff/PTour/PSTH_TourAction.aspx");
        routes.MapPageRoute("PHEmp_TARecmded/{UID}", "PHEmp_TARecmded/{UID}", "~/ProjectStaff/PTour/PSTH_ToursRecommended.aspx");
        routes.MapPageRoute("PHEmp_TApprvd/{UID}", "PHEmp_TApprvd/{UID}", "~/ProjectStaff/PTour/PSTH_ToursApproved.aspx");
        routes.MapPageRoute("PHEmp_TRejd/{UID}", "PHEmp_TRejd/{UID}", "~/ProjectStaff/PTour/PSTH_ToursRejected.aspx");

        routes.MapPageRoute("PEmp_I2Store/{UID}", "PEmp_I2Store/{UID}", "~/ProjectStaff/PStores/Store_Indent4Stock.aspx");
        routes.MapPageRoute("PEmp_EPI/{UID}", "PEmp_EPI/{UID}", "~/ProjectStaff/PStores/Store_REmpIndents.aspx");
        routes.MapPageRoute("PEmp_NEPI/{UID}", "PEmp_NEPI/{UID}", "~/ProjectStaff/PStores/Store_NewStoreIndents.aspx");
        routes.MapPageRoute("PEmp_AESI/{UID}", "PEmp_AESI/{UID}", "~/ProjectStaff/PStores/Store_ApprovedStoreIndents.aspx");
        routes.MapPageRoute("PEmp_Approved/{UID}", "PEmp_Approved/{UID}", "~/ProjectStaff/PStores/Store_AllConfirmedIndents.aspx");
        routes.MapPageRoute("PEmp_RPTitle/{UID}", "PEmp_RPTitle/{UID}", "~/ProjectStaff/PStores/Store_AddRPTitle.aspx");

        routes.MapPageRoute("PHEmp_RegLA/{UID}", "PHEmp_RegLA/{UID}", "~/ProjectStaff/PLeave/RS_LeavesForApproval.aspx");
        routes.MapPageRoute("PHEmp_RegLAct/{UID}", "PHEmp_RegLAct/{UID}", "~/ProjectStaff/PLeave/RS_LeaveAction.aspx");
        routes.MapPageRoute("PHEmp_RegLRec/{UID}", "PHEmp_RegLRec/{UID}", "~/ProjectStaff/PLeave/RS_LeavesRecommended.aspx");
        routes.MapPageRoute("PHEmp_RegLApprvd/{UID}", "PHEmp_RegLApprvd/{UID}", "~/ProjectStaff/PLeave/RS_LeavesApproved.aspx");
        routes.MapPageRoute("PHEmp_CancelCLRH/{UID}", "PHEmp_CancelCLRH/{UID}", "~/ProjectStaff/PLeave/HCancel_CLRH.aspx");

        routes.MapPageRoute("PHEmp_RegTA/{UID}", "PHEmp_RegTA/{UID}", "~/ProjectStaff/PTour/RSH_ToursForApproval.aspx");
        routes.MapPageRoute("PHEmp_RegTAct/{UID}", "PHEmp_RegTAct/{UID}", "~/ProjectStaff/PTour/RSH_TourAction.aspx");
        routes.MapPageRoute("PHEmp_RegTRec/{UID}", "PHEmp_RegTRec/{UID}", "~/ProjectStaff/PTour/RSH_ToursRecommended.aspx");
        routes.MapPageRoute("PHEmp_RegTApprvd/{UID}", "PHEmp_RegTApprvd/{UID}", "~/ProjectStaff/PTour/RSH_ToursApprovedByMe.aspx");
        routes.MapPageRoute("PHEmp_RegTRejd/{UID}", "PHEmp_RegTRejd/{UID}", "~/ProjectStaff/PTour/RSH_ToursRejectedByMe.aspx");
        routes.MapPageRoute("PHEmp_Resume/{UID}", "PHEmp_Resume/{UID}", "~/ProjectStaff/PGeneral/ResumeResourcePool.aspx");
        routes.MapPageRoute("PEmp_LReviewAction/{UID}", "PEmp_LReviewAction/{UID}", "~/ProjectStaff/PLeave/PLReviewAction.aspx");
        routes.MapPageRoute("PHEmp_PSLCancel/{UID}", "PHEmp_PSLCancel/{UID}", "~/ProjectStaff/PLeave/PSHCancel_CLSL.aspx");
        // Vehicle
        routes.MapPageRoute("Vehicle/{UID}", "Vehicle/{UID}", "~/Vehicle/VehicleHome.aspx");
        routes.MapPageRoute("Vehicle_Drivers/{UID}", "Vehicle_Drivers/{UID}", "~/Vehicle/Drivers.aspx");
        routes.MapPageRoute("Vehicle_Vehicles/{UID}", "Vehicle_Vehicles/{UID}", "~/Vehicle/Vehicles.aspx");
        routes.MapPageRoute("Vehicle_HOCI/{UID}", "Vehicle_HOCI/{UID}", "~/Vehicle/AHOCApprovedIndents.aspx");
        routes.MapPageRoute("Vehicle_AVI/{UID}", "Vehicle_AVI/{UID}", "~/Vehicle/VSApprovedIndents.aspx");
        routes.MapPageRoute("Vehicle_AssVI/{UID}", "Vehicle_AssVI/{UID}", "~/Vehicle/AssignVehicletoIndents.aspx");
        routes.MapPageRoute("Vehicle_SMS/{UID}", "Vehicle_SMS/{UID}", "~/Vehicle/AllConfirmedIndents.aspx");

        // Security
        routes.MapPageRoute("Security/{UID}", "Security/{UID}", "~/Security/SecurityHomepage.aspx");
        routes.MapPageRoute("VVT/{UID}", "VVT/{UID}", "~/Security/VehicleType.aspx");
        routes.MapPageRoute("VC/{UID}", "VC/{UID}", "~/Security/VCards.aspx");
        routes.MapPageRoute("Security_VR/{UID}", "Security_VR/{UID}", "~/Security/VisitorRegistration.aspx");
        routes.MapPageRoute("GP/{UID}", "GP/{UID}", "~/Security/PrintGatePass.aspx");
        routes.MapPageRoute("VCI/{UID}", "VCI/{UID}", "~/Security/VisitorsCardInfo.aspx");
        routes.MapPageRoute("VArch/{UID}", "VArch/{UID}", "~/Security/VisitorsArchives.aspx");
        routes.MapPageRoute("VCP/{UID}", "VCP/{UID}", "~/Security/ChangePassword.aspx");

        // ART
        routes.MapPageRoute("ARTHome/{UID}", "ARTHome/{UID}", "~/AR_T/ARTHome.aspx");
        routes.MapPageRoute("StoreApprvdStock/{UID}", "StoreApprvdStock/{UID}", "~/AR_T/ApprovedStoreIndents.aspx");
        routes.MapPageRoute("ARTApprvdStock/{UID}", "ARTApprvdStock/{UID}", "~/AR_T/ART_Appvd_RStoreIndents.aspx");
        routes.MapPageRoute("ARTRStock/{UID}", "ARTRStock/{UID}", "~/AR_T/RStoreIndents.aspx");
        routes.MapPageRoute("ARTRShow/{UID}", "ARTRShow/{UID}", "~/AR_T/Edit_REmpIndents.aspx");
        routes.MapPageRoute("CurrStock/{UID}", "CurrStock/{UID}", "~/AR_T/StoreStock.aspx");
        routes.MapPageRoute("ART_DWAI/{UID}", "ART_DWAI/{UID}", "~/AR_T/DatewiseApprovedStoreIndents.aspx");

        // Hostel
        routes.MapPageRoute("GHHome/{UID}", "GHHome/{UID}", "~/GuestHouse/GHHome.aspx");
        routes.MapPageRoute("HTypes/{UID}", "HTypes/{UID}", "~/GuestHouse/HTypes.aspx");
        routes.MapPageRoute("HFloor/{UID}", "HFloor/{UID}", "~/GuestHouse/HFloors.aspx");
        routes.MapPageRoute("RoomType/{UID}", "RoomType/{UID}", "~/GuestHouse/RoomTypes.aspx");
        routes.MapPageRoute("RoomNo/{UID}", "RoomNo/{UID}", "~/GuestHouse/RoomNos.aspx");
        routes.MapPageRoute("HRBS/{UID}", "HRBS/{UID}", "~/GuestHouse/BookingStatus.aspx");
        routes.MapPageRoute("VReg/{UID}", "VReg/{UID}", "~/GuestHouse/VisitorRegistration.aspx");

        // ARE
        routes.MapPageRoute("AREHome/{UID}", "AREHome/{UID}", "~/AR_E/AREHome.aspx");
        routes.MapPageRoute("AREPVI/{UID}", "AREPVI/{UID}", "~/AR_E/NewlySubmittedPendVehIndents.aspx");

        // DG
        routes.MapPageRoute("DGHome/{UID}", "DGHome/{UID}", "~/DG/DGHome.aspx");
        routes.MapPageRoute("DG_CP/{UID}", "DG_CP/{UID}", "~/DG/ChangePassword.aspx");
        routes.MapPageRoute("DG_Contact/{UID}", "DG_Contact/{UID}", "~/DG/NirdContactsList.aspx");
        routes.MapPageRoute("DG_PWE/{UID}", "DG_PWE/{UID}", "~/DG/Store_PersonwiseExpenditureReport.aspx");
        routes.MapPageRoute("DG_DWE/{UID}", "DG_DWE/{UID}", "~/DG/Store_DeptwiseExpenditure.aspx");
        routes.MapPageRoute("DG_TR/{UID}", "DG_TR/{UID}", "~/DG/TourReports.aspx");
        routes.MapPageRoute("DG_ETR/{UID}", "DG_ETR/{UID}", "~/DG/TourReports_EmpWise.aspx");
        routes.MapPageRoute("DG_ETRI/{UID}", "DG_ETRI/{UID}", "~/DG/TourReports_EmpWiseInfo.aspx");
        routes.MapPageRoute("DG_SBA/{UID}", "DG_SBA/{UID}", "~/DG/MonthlyBioMetricAttStatus.aspx");
        routes.MapPageRoute("DG_MonthlyPay/{UID}", "DG_MonthlyPay/{UID}", "~/DG/PayDetails.aspx");
        routes.MapPageRoute("DG_eL_AllBARD_Rpt/{UID}", "DG_eL_AllBARD_Rpt/{UID}", "~/DG/All_MonthlyBioMetricAttRpt.aspx");
        routes.MapPageRoute("DG_eL_AllBARD_Rpt_LOP/{UID}", "DG_eL_AllBARD_Rpt_LOP/{UID}", "~/DG/All_MonthlyBioMetricAttRpt_LOP.aspx");
        routes.MapPageRoute("DG_eL_BARD_Rpt/{UID}", "DG_eL_BARD_Rpt/{UID}", "~/DG/PS_MonthlyBioMetricAttStatus.aspx");
        routes.MapPageRoute("DG_eL_Used/{UID}", "DG_eL_Used/{UID}", "~/DG/eL_Used.aspx");
        routes.MapPageRoute("DG_eL_UsedLeaves/{UID}", "DG_eL_UsedLeaves/{UID}", "~/DG/el_AvailedStatus.aspx");
        routes.MapPageRoute("DG_eT_UsedTours/{UID}", "DG_eT_UsedTours/{UID}", "~/DG/eT_AvailedStatus.aspx");
        routes.MapPageRoute("DG_db_emp/{UID}", "DG_db_emp/{UID}", "~/DG/Dashboard_Emp.aspx");
        routes.MapPageRoute("DG_db_empprof/{UID}", "DG_db_empprof/{UID}", "~/DG/Emp_Active.aspx");
        routes.MapPageRoute("DG_ELeaveStatus/{UID}", "DG_ELeaveStatus/{UID}", "~/DG/REmpAppliedLeaveStatus.aspx");
		routes.MapPageRoute("DG_PELeaveStatus/{UID}", "DG_PELeaveStatus/{UID}", "~/DG/PEmpAppliedLeaveStatus.aspx");

        //HR Information Report by Praveen
        routes.MapPageRoute("DGEmp_PSServInfoReportXLS/{UID}", "DGEmp_PSServInfoReportXLS/{UID}", "~/DG/HRInfoFilldReportsXLS.aspx");
        
        //CMU Ticketing
        routes.MapPageRoute("CMU_TktHome/{UID}", "CMU_TktHome/{UID}", "~/CMU_Ticketing/CMUTicketingHome.aspx");

        //CIT Inventory
        routes.MapPageRoute("CIT_InvHome/{UID}", "CIT_InvHome/{UID}", "~/CICTInventory/InventoryHome.aspx");
        routes.MapPageRoute("CIT_InvItems/{UID}", "CIT_InvItems/{UID}", "~/CICTInventory/ItemType.aspx");
        routes.MapPageRoute("CIT_ADDInv/{UID}", "CIT_ADDInv/{UID}", "~/CICTInventory/AddInventory.aspx");
        routes.MapPageRoute("CIT_Location/{UID}", "CIT_Location/{UID}", "~/CICTInventory/Location.aspx");
        routes.MapPageRoute("CIT_Floor/{UID}", "CIT_Floor/{UID}", "~/CICTInventory/Floors.aspx");
        routes.MapPageRoute("CIT_Rooms/{UID}", "CIT_Rooms/{UID}", "~/CICTInventory/RoomNos.aspx");
        routes.MapPageRoute("CIT_Halls/{UID}", "CIT_Halls/{UID}", "~/CICTInventory/Halls.aspx");
        routes.MapPageRoute("CITInv_CP/{UID}", "CITInv_CP/{UID}", "~/CICTInventory/ChangePassword.aspx");
        routes.MapPageRoute("CIT_MAPInv/{UID}", "CIT_MAPInv/{UID}", "~/CICTInventory/MapInventory.aspx");
        routes.MapPageRoute("CIT_ExcelMAPInv/{UID}", "CIT_ExcelMAPInv/{UID}", "~/CICTInventory/UpdateCITInventory_ExcelMapping.aspx");

        routes.MapPageRoute("CIT_SS/{UID}", "CIT_SS/{UID}", "~/CICTInventory/CITSupportingStaff.aspx");
        routes.MapPageRoute("CIT_TMap/{UID}", "CIT_TMap/{UID}", "~/CICTInventory/eTicketMapping2Staff.aspx");
        routes.MapPageRoute("CIT_TMapS/{UID}", "CIT_TMapS/{UID}", "~/CICTInventory/CICTETicketsStatus.aspx");
        routes.MapPageRoute("CIT_TClosed/{UID}", "CIT_TClosed/{UID}", "~/CICTInventory/CICTClosedETickets.aspx");
        routes.MapPageRoute("CIT_EInv/{UID}", "CIT_EInv/{UID}", "~/CICTInventory/CITEmp_Inventory.aspx");
        routes.MapPageRoute("CIT_Consol/{UID}", "CIT_Consol/{UID}", "~/CICTInventory/ConsoliInventory.aspx");
        routes.MapPageRoute("CIT_DetITInv/{UID}", "CIT_DetITInv/{UID}", "~/CICTInventory/DetailedITInventory.aspx");
        routes.MapPageRoute("CIT_DeptITInv/{UID}", "CIT_DeptITInv/{UID}", "~/CICTInventory/DeptDetailedITInventory.aspx");
        routes.MapPageRoute("CIT_DeptITInventory/{UID}", "CIT_DeptITInventory/{UID}", "~/CICTInventory/DeptWiseInventoryMappedReport_New.aspx");
        routes.MapPageRoute("CIT_HolDT/{UID}", "CIT_HolDT/{UID}", "~/CICTInventory/CICTETickets_HoldStatus.aspx");
        routes.MapPageRoute("CIT_AllT/{UID}", "CIT_AllT/{UID}", "~/CICTInventory/CICTETickets_AllbyDates.aspx");
        routes.MapPageRoute("CIT_AllTSS/{UID}", "CIT_AllTSS/{UID}", "~/CICTInventory/CICTETickets_AllbyDatesEmp.aspx");
        routes.MapPageRoute("CIT_DSR/{UID}", "CIT_DSR/{UID}", "~/CICTInventory/DeptWiseInventoryMappedReport.aspx");
        routes.MapPageRoute("CIT_IHR/{UID}", "CIT_IHR/{UID}", "~/CICTInventory/ItemHistoryReport.aspx");
        routes.MapPageRoute("CIT_InvReq/{UID}", "CIT_InvReq/{UID}", "~/CICTInventory/AssetRequest.aspx");
        routes.MapPageRoute("CIT_Staff/{UID}", "CIT_Staff/{UID}", "~/CICTInventory/Emp_Active.aspx");
        routes.MapPageRoute("CIT_ExcelMapping/{UID}", "CIT_ExcelMapping/{UID}", "~/CICTInventory/UpdateCITInventory_ExcelMapping.aspx");

        //CIT Staff
        routes.MapPageRoute("CIT_SSHome/{UID}", "CIT_SSHome/{UID}", "~/CITStaff/CITSSHome.aspx");
        routes.MapPageRoute("CITSS_CP/{UID}", "CITSS_CP/{UID}", "~/CITStaff/eTicketMapping2Staff.aspx");
        routes.MapPageRoute("CITSS_NewTkt/{UID}", "CITSS_NewTkt/{UID}", "~/CITStaff/NewETickets.aspx");
        routes.MapPageRoute("CITSS_TiP/{UID}", "CITSS_TiP/{UID}", "~/CITStaff/CICTIniatedETickets.aspx");
        routes.MapPageRoute("CITSS_SelfMap/{UID}", "CITSS_SelfMap/{UID}", "~/CITStaff/eTicketMapping2Staff.aspx");
        routes.MapPageRoute("CITSS_Cmts/{UID}", "CITSS_Cmts/{UID}", "~/CITStaff/TicketComments.aspx");
        routes.MapPageRoute("CITSS_Close/{UID}", "CITSS_Close/{UID}", "~/CITStaff/CICTClosedETickets.aspx");
        routes.MapPageRoute("CITSS_DWNT/{UID}", "CITSS_DWNT/{UID}", "~/CITStaff/CITSSDatewiseNewTickets.aspx");
        routes.MapPageRoute("CITSS_BAT/{UID}", "CITSS_BAT/{UID}", "~/CITStaff/BookATicket.aspx");

        //eLeave Admin
        routes.MapPageRoute("eL_AHome/{UID}", "eL_AHome/{UID}", "~/eLeave/eLeaveAdminHome.aspx");
        routes.MapPageRoute("eL_GHolidays/{UID}", "eL_GHolidays/{UID}", "~/eLeave/GovtHolidays.aspx");
        routes.MapPageRoute("eL_LT/{UID}", "eL_LT/{UID}", "~/eLeave/LeaveTypes.aspx");
        routes.MapPageRoute("eL_OLs/{UID}", "eL_OLs/{UID}", "~/eLeave/OfficerLevel.aspx");
        routes.MapPageRoute("eL_sMap/{UID}", "eL_sMap/{UID}", "~/eLeave/SingleMapLeaveFlow.aspx");
        routes.MapPageRoute("eL_DA/{UID}", "eL_DA/{UID}", "~/eLeave/AddDealingAsst.aspx");
        routes.MapPageRoute("eL_mapEmpDA/{UID}", "eL_mapEmpDA/{UID}", "~/eLeave/mapEmptoLDA.aspx");
        routes.MapPageRoute("eL_EmpMLA/{UID}", "eL_EmpMLA/{UID}", "~/eLeave/UpdateLeavesMaster.aspx");
        routes.MapPageRoute("eL_BAUpload/{UID}", "eL_BAUpload/{UID}", "~/eLeave/Upload_BioMetricAttendance.aspx");
        routes.MapPageRoute("eL_BARGen/{UID}", "eL_BARGen/{UID}", "~/eLeave/BioAttReportGeneration.aspx");
        routes.MapPageRoute("eL_BARD_Rpt/{UID}", "eL_BARD_Rpt/{UID}", "~/eLeave/PS_MonthlyBioMetricAttStatus.aspx");
        routes.MapPageRoute("eL_AllBARD_Rpt/{UID}", "eL_AllBARD_Rpt/{UID}", "~/eLeave/All_MonthlyBioMetricAttRpt.aspx");
        routes.MapPageRoute("eL_AllBARD_Rpt_LOP/{UID}", "eL_AllBARD_Rpt_LOP/{UID}", "~/eLeave/All_MonthlyBioMetricAttRpt_LOP.aspx");
        routes.MapPageRoute("eL_uLWF/{UID}", "eL_uLWF/{UID}", "~/eLeave/UpdateLeaveWorkFlow.aspx");
        routes.MapPageRoute("eT_uEmpDept/{UID}", "eT_uEmpDept/{UID}", "~/eLeave/UpdateEmpDept.aspx");
        routes.MapPageRoute("eT_uEmpDesign/{UID}", "eT_uEmpDesign/{UID}", "~/eLeave/UpdateEmpDesign.aspx");
        routes.MapPageRoute("eT_addDesign/{UID}", "eT_addDesign/{UID}", "~/eLeave/Designation.aspx");
        routes.MapPageRoute("eT_uDOB/{UID}", "eT_uDOB/{UID}", "~/eLeave/UpdateEmpDOB.aspx");
        routes.MapPageRoute("eT_uDOJ/{UID}", "eT_uDOJ/{UID}", "~/eLeave/UpdateEmpDOJ.aspx");
        routes.MapPageRoute("eT_uPhoto/{UID}", "eT_uPhoto/{UID}", "~/eLeave/UpdateEmpPhoto.aspx");
        routes.MapPageRoute("eL_PrintLWF/{UID}", "eL_PrintLWF/{UID}", "~/eLeave/PrintLeaveWorkFlow.aspx");
        routes.MapPageRoute("eT_TMs/{UID}", "eT_TMs/{UID}", "~/eLeave/TourMode.aspx");
        routes.MapPageRoute("eT_LDeduAct/{UID}", "eT_LDeduAct/{UID}", "~/eLeave/LDeductActionOnApprovedLeaves.aspx");

        routes.MapPageRoute("eL_AllEL/{UID}", "eL_AllEL/{UID}", "~/eLeave/All_RS_AppliedLeaves.aspx");
        routes.MapPageRoute("eL_AllAEL/{UID}", "eL_AllAEL/{UID}", "~/eLeave/All_RS_ApprovedLeaves.aspx");
        routes.MapPageRoute("eT_All_R_Applied_Tours/{UID}", "eT_All_R_Applied_Tours/{UID}", "~/eLeave/All_RS_AppliedTours.aspx");
        routes.MapPageRoute("eT_All_R_Approved_Tours/{UID}", "eT_All_R_Approved_Tours/{UID}", "~/eLeave/All_RS_ToursApproved.aspx");

        routes.MapPageRoute("eL_AllPEL/{UID}", "eL_AllPEL/{UID}", "~/eLeave/All_PS_LeavesApplied.aspx");
        routes.MapPageRoute("eL_AllAPEL/{UID}", "eL_AllAPEL/{UID}", "~/eLeave/All_PS_LeavesApproved.aspx");
        routes.MapPageRoute("eT_AllPET/{UID}", "eT_AllPET/{UID}", "~/eLeave/All_PS_ToursApplied.aspx");
        routes.MapPageRoute("eT_AllAPET/{UID}", "eT_AllAPET/{UID}", "~/eLeave/All_PS_ToursApproved.aspx");
        routes.MapPageRoute("eL_AEmp_L_Status/{UID}", "eL_AEmp_L_Status/{UID}", "~/eLeave/AllLeaveswithAnyStatus.aspx");
        routes.MapPageRoute("eL_Edit_LDAs/{UID}", "eL_Edit_LDAs/{UID}", "~/eLeave/ChangeLDAs.aspx");
        routes.MapPageRoute("eT_TS/{UID}", "eT_TS/{UID}", "~/eLeave/AllPSTourswithAnyStatus.aspx");
        routes.MapPageRoute("eL_LS/{UID}", "eL_LS/{UID}", "~/eLeave/All_PS_LeaveswithAnyStatus.aspx");
        routes.MapPageRoute("eL_Emp_LA/{UID}", "eL_Emp_LA/{UID}", "~/eLeave/RPT_EmpWiseApprovedLeaves.aspx");
        //eLeave Dealing Asst
        routes.MapPageRoute("eL_DAHome/{UID}", "eL_DAHome/{UID}", "~/eLeaveDA/EmployeeStatus.aspx");
        routes.MapPageRoute("eL_EmpStatus/{UID}", "eL_EmpStatus/{UID}", "~/eLeaveDA/eLDAHome.aspx");
        routes.MapPageRoute("eL_DACP/{UID}", "eL_DACP/{UID}", "~/eLeaveDA/ChangePassword.aspx");
        routes.MapPageRoute("eL_DAempList/{UID}", "eL_DAempList/{UID}", "~/eLeaveDA/eLEmpList.aspx");
        routes.MapPageRoute("eL_uEmpDeptDA/{UID}", "eL_uEmpDeptDA/{UID}", "~/eLeaveDA/UpdateEmpDept.aspx");
        routes.MapPageRoute("eL_uEmpDesignDA/{UID}", "eL_uEmpDesignDA/{UID}", "~/eLeaveDA/UpdateEmpDesign.aspx");
        routes.MapPageRoute("eL_addDesignDA/{UID}", "eL_addDesignDA/{UID}", "~/eLeaveDA/Designation.aspx");
        routes.MapPageRoute("eL_UpdateEssentialEmp/{UID}", "eL_UpdateEssentialEmp/{UID}", "~/eLeaveDA/UpdateEssentialEmployee.aspx");
        routes.MapPageRoute("eL_UpdateEssentialStatus/{UID}", "eL_UpdateEssentialStatus/{UID}", "~/eLeaveDA/UpdateEmpEssentialStatus.aspx");
        routes.MapPageRoute("eL_AllELDA/{UID}", "eL_AllELDA/{UID}", "~/eLeaveDA/AllAppliedLeaves.aspx");
        routes.MapPageRoute("eL_AllAELDA/{UID}", "eL_AllAELDA/{UID}", "~/eLeaveDA/AllApprovedLeaves.aspx");
        routes.MapPageRoute("eL_AllA_CLRH_ELDA/{UID}", "eL_AllA_CLRH_ELDA/{UID}", "~/eLeaveDA/AllApproved_CL_RH_Leaves.aspx");
        routes.MapPageRoute("eL_AllCELDA/{UID}", "eL_AllCELDA/{UID}", "~/eLeaveDA/AllCancelledLeaves.aspx");
        routes.MapPageRoute("eL_AllRELDA/{UID}", "eL_AllRELDA/{UID}", "~/eLeaveDA/AllRejectedLeaves.aspx");
        routes.MapPageRoute("eT_LDeduActDA/{UID}", "eT_LDeduActDA/{UID}", "~/eLeaveDA/LDeductActionOnApprovedLeaves.aspx");
        routes.MapPageRoute("eT_uDOBDA/{UID}", "eT_uDOBDA/{UID}", "~/eLeaveDA/UpdateEmpDOB.aspx");
        routes.MapPageRoute("eT_uDOJDA/{UID}", "eT_uDOJDA/{UID}", "~/eLeaveDA/UpdateEmpDOJ.aspx");
        routes.MapPageRoute("eL_EmpMLADA/{UID}", "eL_EmpMLADA/{UID}", "~/eLeaveDA/UpdateLeavesMaster.aspx");
        routes.MapPageRoute("eL_uLWFDA/{UID}", "eL_uLWFDA/{UID}", "~/eLeaveDA/UpdateLeaveWorkFlow.aspx");
        routes.MapPageRoute("eL_sMapDA/{UID}", "eL_sMapDA/{UID}", "~/eLeaveDA/SingleMapLeaveFlow.aspx");
        routes.MapPageRoute("eL_PrintLWFDA/{UID}", "eL_PrintLWFDA/{UID}", "~/eLeaveDA/PrintLeaveWorkFlow.aspx");
        routes.MapPageRoute("eL_AllFELDA/{UID}", "eL_AllFELDA/{UID}", "~/eLeaveDA/AllApproved_FinalizedLeaves.aspx");
        routes.MapPageRoute("eL_LDashboard/{UID}", "eL_LDashboard/{UID}", "~/eLeaveDA/LeaveDashboard.aspx");
        routes.MapPageRoute("eL_CancelAL/{UID}", "eL_CancelAL/{UID}", "~/eLeaveDA/CancelApprovedLeaves.aspx");
        routes.MapPageRoute("eL_CCLRH/{UID}", "eL_CCLRH/{UID}", "~/eLeaveDA/LSOCancel_CLRH.aspx");
        routes.MapPageRoute("eL_COCLRH/{UID}", "eL_COCLRH/{UID}", "~/eLeaveDA/LSOCancel_OtherthanCLRH.aspx");


        routes.MapPageRoute("eL_Emp_LDA_LA/{UID}", "eL_Emp_LDA_LA/{UID}", "~/eLeaveDA/RPT_EmpWiseApprovedLeaves.aspx");
        routes.MapPageRoute("eL_AEmp_LDA_LA/{UID}", "eL_AEmp_LDA_LA/{UID}", "~/eLeaveDA/RPT_AllEmpApprovedLeaves.aspx");
        routes.MapPageRoute("eL_AEmp_LDA_Status/{UID}", "eL_AEmp_LDA_Status/{UID}", "~/eLeaveDA/AllLeaveswithAnyStatus.aspx");
        routes.MapPageRoute("eL_AEmp_LDA_JR/{UID}", "eL_AEmp_LDA_JR/{UID}", "~/eLeaveDA/AllApprovedLJRs.aspx");
        routes.MapPageRoute("eL_AEmp_LDA_PJR/{UID}", "eL_AEmp_LDA_PJR/{UID}", "~/eLeaveDA/AllAppliedLJRS.aspx");

        routes.MapPageRoute("att_All/{UID}", "att_All/{UID}", "~/eLeaveDA/All_MonthlyBioMetricAttRpt.aspx");
        routes.MapPageRoute("att_All_LOP/{UID}", "att_All_LOP/{UID}", "~/eLeaveDA/All_MonthlyBioMetricAttRpt_LOP.aspx");
        routes.MapPageRoute("att_All_Mail/{UID}", "att_All_Mail/{UID}", "~/eLeaveDA/All_SendMailto_MissedDates_Attendance.aspx");

        //Health Dealing Asst
        routes.MapPageRoute("hDA_home/{UID}", "hDA_home/{UID}", "~/HCMS/hcmsHome.aspx");
        routes.MapPageRoute("hDA_CP/{UID}", "hDA_CP/{UID}", "~/HCMS/ChangePassword.aspx");
        routes.MapPageRoute("hDA_EmpInfo/{UID}", "hDA_EmpInfo/{UID}", "~/HCMS/HCMSEmpInfo.aspx");
        // Finance DA

        routes.MapPageRoute("FinDAHome/{UID}", "FinDAHome/{UID}", "~/FinanceDA/FinDAHome.aspx");
        routes.MapPageRoute("Fin_DARSTAReq/{UID}", "Fin_DARSTAReq/{UID}", "~/FinanceDA/RS_Tours_AprvdAdvance_Req.aspx");


        //Finace
        routes.MapPageRoute("FinHome/{UID}", "FinHome/{UID}", "~/Finance/FinanceHome.aspx");
        routes.MapPageRoute("Fin_CP/{UID}", "Fin_CP/{UID}", "~/Finance/ChangePassword.aspx");
        routes.MapPageRoute("Fin_Contact/{UID}", "Fin_Contact/{UID}", "~/Finance/NirdContactsList.aspx");
        routes.MapPageRoute("Fin_PWE/{UID}", "Fin_PWE/{UID}", "~/Finance/Store_PersonwiseExpenditureReport.aspx");
        routes.MapPageRoute("Fin_DWE/{UID}", "Fin_DWE/{UID}", "~/Finance/Store_DeptwiseExpenditure.aspx");
        routes.MapPageRoute("Fin_MonthlySummaryRpt/{UID}", "Fin_MonthlySummaryRpt/{UID}", "~/Finance/PMonthlySummaryReport.aspx");
        routes.MapPageRoute("Fin_MonthlyCatSummaryReport/{UID}", "Fin_MonthlyCatSummaryReport/{UID}", "~/Finance/PrintEmpSummaryReport.aspx");
        routes.MapPageRoute("Fin_MonthlyAllowances/{UID}", "Fin_MonthlyAllowances/{UID}", "~/Finance/PrintMonthlyAllowances.aspx");
        routes.MapPageRoute("Fin_Mon_Dedu_S1/{UID}", "Fin_Mon_Dedu_S1/{UID}", "~/Finance/PrintMonthlyDeductions_S1.aspx");
        routes.MapPageRoute("Fin_Mon_Dedu_S2/{UID}", "Fin_Mon_Dedu_S2/{UID}", "~/Finance/PrintMonthlyDeductions_S2.aspx");
        routes.MapPageRoute("Fin_MonthlyBankStmt/{UID}", "Fin_MonthlyBankStmt/{UID}", "~/Finance/PrintEmpBankStatement.aspx");
        routes.MapPageRoute("Fin_LICPrint/{UID}", "Fin_LICPrint/{UID}", "~/Finance/PrintLICMonthlyContribution.aspx");
        routes.MapPageRoute("Fin_BLMonthlyStmt/{UID}", "Fin_BLMonthlyStmt/{UID}", "~/Finance/PrintBLMonthlyContribution.aspx");
        routes.MapPageRoute("Fin_GI/{UID}", "Fin_GI/{UID}", "~/Finance/PrintEmpGI.aspx");
        routes.MapPageRoute("Fin_IT/{UID}", "Fin_IT/{UID}", "~/Finance/PrintEmpIT.aspx");
        routes.MapPageRoute("Fin_PPEmp/{UID}", "Fin_PPEmp/{UID}", "~/Finance/PrintProfile.aspx");
        routes.MapPageRoute("Fin_IMPSC/{UID}", "Fin_IMPSC/{UID}", "~/Finance/CurrentIndividualMailPayslip.aspx");
        routes.MapPageRoute("Fin_IMPS/{UID}", "Fin_IMPS/{UID}", "~/Finance/NewIndividualMailPayslip.aspx");
        routes.MapPageRoute("Fin_F16Print/{UID}", "Fin_F16Print/{UID}", "~/Finance/Form16Print.aspx");
        routes.MapPageRoute("Fin_BARD_Rpt/{UID}", "Fin_BARD_Rpt/{UID}", "~/Finance/PS_MonthlyBioMetricAttStatus.aspx");

        routes.MapPageRoute("eT_FinTMs/{UID}", "eT_FinTMs/{UID}", "~/Finance/TourMode.aspx");
        routes.MapPageRoute("eT_FinDAW/{UID}", "eT_FinDAW/{UID}", "~/Finance/RS_Tour_DailyAllowances.aspx");

        routes.MapPageRoute("Fin_HCodes/{UID}", "Fin_HCodes/{UID}", "~/Finance/Fin_MainHeadCodes.aspx");
        routes.MapPageRoute("Fin_SHCodes/{UID}", "Fin_SHCodes/{UID}", "~/Finance/Fin_SubHeadCodes.aspx");
        routes.MapPageRoute("Fin_RSTAReq/{UID}", "Fin_RSTAReq/{UID}", "~/Finance/RS_Tours_AprvdAdvance_Req.aspx");
        routes.MapPageRoute("Fin_UserRoles/{UID}", "Fin_UserRoles/{UID}", "~/Finance/Fin_SetUserRoles.aspx");
        routes.MapPageRoute("Fin_TAAct/{UID}", "Fin_TAAct/{UID}", "~/Finance/RS_TourAdvanceAction.aspx");

        // Delegated User
        routes.MapPageRoute("DHEmp_Home/{UID}", "DHEmp_Home/{UID}", "~/DelegatedUser/DUHome.aspx");
        routes.MapPageRoute("DHEmp_LApply/{UID}", "DHEmp_LApply/{UID}", "~/DelegatedUser/LeaveApply.aspx");
        routes.MapPageRoute("DHEmp_LAppled/{UID}", "DHEmp_LAppled/{UID}", "~/DelegatedUser/LeavesApplied.aspx");
        routes.MapPageRoute("DHEmp_myAL/{UID}", "DHEmp_myAL/{UID}", "~/DelegatedUser/LeavesApproved4me.aspx");
        routes.MapPageRoute("DHEmp_Eph/{UID}", "DHEmp_Eph/{UID}", "~/DelegatedUser/ChangePhoto.aspx");
        routes.MapPageRoute("DHEmp_I2Store/{UID}", "DHEmp_I2Store/{UID}", "~/DelegatedUser/Indent4Stock.aspx");
        routes.MapPageRoute("DHEmp_AESI/{UID}", "DHEmp_AESI/{UID}", "~/DelegatedUser/ApprovedStoreIndents.aspx");
        routes.MapPageRoute("DHEmp_PSValidate/{UID}", "DHEmp_PSValidate/{UID}", "~/DelegatedUser/HOC_ValidateProjectStaff.aspx");
        routes.MapPageRoute("DHEmp_PCLs/{UID}", "DHEmp_PCLs/{UID}", "~/DelegatedUser/AddProjectStaffCLs.aspx");
        routes.MapPageRoute("DHEmp_Late/{UID}", "DHEmp_Late/{UID}", "~/DelegatedUser/Reg_LateRequest.aspx");
        routes.MapPageRoute("DHEmp_LateApprvl/{UID}", "DHEmp_LateApprvl/{UID}", "~/DelegatedUser/Reg_LateRequestApproval.aspx");
        routes.MapPageRoute("DHEmp_TourApply/{UID}", "DHEmp_TourApply/{UID}", "~/DelegatedUser/RS_TourApply.aspx");
        routes.MapPageRoute("DHEmp_TAppled/{UID}", "DHEmp_TAppled/{UID}", "~/DelegatedUser/RS_ToursApplied.aspx");
        routes.MapPageRoute("DHEmp_ETR/{UID}", "DHEmp_ETR/{UID}", "~/DelegatedUser/SubmitTourReport.aspx");
        routes.MapPageRoute("DHEmp_RPTitle/{UID}", "DHEmp_RPTitle/{UID}", "~/DelegatedUser/AddRPTitle.aspx");
        routes.MapPageRoute("DHEmp_UPCLs/{UID}", "DHEmp_UPCLs/{UID}", "~/DelegatedUser/AUpdateProjectStaffCLs.aspx");
        routes.MapPageRoute("DHEmp_myAT/{UID}", "DHEmp_myAT/{UID}", "~/DelegatedUser/RS_ToursApproved4me.aspx");

        routes.MapPageRoute("DHEmp_myLJR/{UID}", "DHEmp_myLJR/{UID}", "~/DelegatedUser/RS_LeaveJoingReport.aspx");
        routes.MapPageRoute("DHEmp_myLExt/{UID}", "DHEmp_myLExt/{UID}", "~/DelegatedUser/RS_LeaveExtension.aspx");
        routes.MapPageRoute("DHEmp_myLCurt/{UID}", "DHEmp_myLCurt/{UID}", "~/DelegatedUser/RS_LeaveCurtail.aspx");
        routes.MapPageRoute("DHEmp_myALJR/{UID}", "DHEmp_myALJR/{UID}", "~/DelegatedUser/Leaves_JR_Ext_Curt_Approved4me.aspx");


        // PSDelegated User
        routes.MapPageRoute("PSDHEmp_Home/{UID}", "PSDHEmp_Home/{UID}", "~/PSDelegateUser/DUHome.aspx");
        routes.MapPageRoute("PSDHEmp_I2Store/{UID}", "PSDHEmp_I2Store/{UID}", "~/PSDelegateUser/Indent4Stock.aspx");
        routes.MapPageRoute("PSDHEmp_AESI/{UID}", "PSDHEmp_AESI/{UID}", "~/PSDelegateUser/ApprovedStoreIndents.aspx");
        routes.MapPageRoute("PSDHEmp_PSValidate/{UID}", "PSDHEmp_PSValidate/{UID}", "~/PSDelegateUser/HOC_ValidateProjectStaff.aspx");
        routes.MapPageRoute("PSDHEmp_PCLs/{UID}", "PSDHEmp_PCLs/{UID}", "~/PSDelegateUser/AddProjectStaffCLs.aspx");
        routes.MapPageRoute("PSDHEmp_RPTitle/{UID}", "PSDHEmp_RPTitle/{UID}", "~/PSDelegateUser/AddRPTitle.aspx");
        routes.MapPageRoute("PSDHEmp_UPCLs/{UID}", "PSDHEmp_UPCLs/{UID}", "~/PSDelegateUser/AUpdateProjectStaffCLs.aspx");
        routes.MapPageRoute("PSDHEmp_PSDAtt/{UID}", "PSDHEmp_PSDAtt/{UID}", "~/PSDelegateUser/PS_MonthlyBioMetricAttStatus.aspx");
        routes.MapPageRoute("PSDHEmp_Active/{UID}", "PSDHEmp_Active/{UID}", "~/PSDelegateUser/Emp_Active.aspx");
        routes.MapPageRoute("PSDHEmp_Blocked/{UID}", "PSDHEmp_Blocked/{UID}", "~/PSDelegateUser/Emp_Blocked.aspx");
        routes.MapPageRoute("PSDHEmp_PSLeavesStatus/{UID}", "PSDHEmp_PSLeavesStatus/{UID}", "~/PSDelegateUser/All_PS_LeaveswithAnyStatus.aspx");
    }
    void Application_End(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown

    }

    void Application_Error(object sender, EventArgs e)
    {
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e)
    {
        Session["showmessage"]="Show";
        Session["maxIssue"] = 1;
        Session.Add("UserID", "");
        if (Session["UserID"] == null)
        {
            Session.Abandon();
            Response.Redirect("~/Default.aspx");
        }

        Application.Lock();
        if (Session["UserID"] != null)
        {
            count = Convert.ToInt32(Application["NoOfVisitors"]);
            Application["NoOfVisitors"] = count + 1;
        }
        if (Session["UserID"] == null)
        {
            count = Convert.ToInt32(Application["NoOfVisitors"]);
            Application["NoOfVisitors"] = count - 1;
        }
        Application.UnLock();

        //ThreadStart tsTask = new ThreadStart(TaskLoop);
        //Thread MyTask = new Thread(tsTask);
        //MyTask.Start();

        //ThreadStart StoreTask = new ThreadStart(SMSAlert);
        //Thread SMSTask = new Thread(StoreTask);
        //SMSTask.Start();

    }
    static void TaskLoop()
    {
        while (true)
        {
            int year = DateTime.Now.Year;
            DateTime firstDay = new DateTime(year, 1, 1);
            string fday = firstDay.ToString("dd/MMM/yyyy");
            string now = DateTime.Now.ToString("dd/MMM/yyyy");
            if (now == fday)
            {
                if (DateTime.Now.Hour == 7 && DateTime.Now.Minute <= 2 &&  _leaves == false)
                {
                    _leaves = true;

                    EmpLeaveUpdates.Yearly_MasterLeaveUpdates(); // Closed Holidays List  & CL RH updation

                }
                if (DateTime.Now.Hour !=7  && DateTime.Now.Minute <= 2 &&  _leaves == true)
                {
                    _leaves = false;
                }
            }

            //EL HPL Update Half Yearly
            int NYear = DateTime.Now.Year;

            DateTime JulFirst = new DateTime(year, 7, 1);
            string JulF = JulFirst.ToString("dd/MMM/yyyy");

            if(now==JulF)
            {
                if (DateTime.Now.Hour == 7 && DateTime.Now.Minute <=2 &&  _el_hpl_update == false)
                {
                    _el_hpl_update = true;
                    EmpLeaveUpdates.Yearly_MasterLeaveUpdates();//addition of EL(15) HPL(10)  July 1st
                }
                if (DateTime.Now.Hour != 7 && DateTime.Now.Minute <= 2&&  _el_hpl_update == true)
                {
                    _el_hpl_update = false;
                }
            }

            if (DateTime.Now.Hour == 7 && DateTime.Now.Minute <= 2 && _ran == false)
            {
                _ran = true;
                ScheduledTask();
            }
            if (DateTime.Now.Hour != 7 &&  DateTime.Now.Minute <= 2 && _ran == true)
            {
                _ran = false;
            }

            //sms Alerts
            //if (DateTime.Now.Hour == 10 && DateTime.Now.Minute <=2 && _alert == false)
            //{
            //    _alert = true;
            //    //ApprovalAlert.DoART_StoreApprovalAlert();
            //    //AutoSQLBackupMail.AutoSqlBackupMail();
            //}
            //if (DateTime.Now.Hour != 11 && DateTime.Now.Minute <=2 && _alert == true)
            //{
            //    _alert = false;
            //}

            // Wait for certain time interval
            System.Threading.Thread.Sleep(TimeSpan.FromHours(24));
        }
    }

    static void ScheduledTask()
    {
        EmpBirthDayGreetings.SendGreetings();
        // AutoSQLBackupMail.AutoSqlBackupMail();
        StoreStockBackup.DoClosingStockBackup();
    }



    void Session_End(object sender, EventArgs e)
    {
        Session.Remove(Session.SessionID);
        Session.Abandon();
        Application["NoOfVisitors"] = count - 1;
    }

</script>
