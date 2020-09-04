using System;
using System.Data;
namespace NIRDPR.RK.PRReferences
{
    public class PRReq
    {
        private int uID;
        private string columnName;
        private string userID;
        private string email;
        private string password;
        private string name;
        private double mobile;
        private string photo;
        private DateTime now;
        private string status;
        private int role;
        private int oID;
        private string orgName;
        private string payscale;
        private int pSID;
        private string empType;
        private int eTID;
        private int eCID;
        private string empCategory;
        private string design;
        private int dSID;
        private int dID;
        private string department;
        private string deptID;
        private int dAID;
        private double dA;
        private string uName;
        private DateTime dated;
        private int hRAID;
        private double hRA;
        private int nPAID;
        private double nPA;
        private double accNo;
        private string pAN;
        private double gradePay;
        private double pPB;
        private double tA;
        private double dPA;
        private double pCA;
        private double sFN;
        private double wA;
        private double oTPay;
        private double sDA;
        private double bA;
        private double sA;
        private double grossSal;
        private string financialYear;
        private DateTime startDate;
        private DateTime endDate;
        private int fYID;
        private string vendor;
        private int vID;
        private string tIN;
        private string dLNo;
        private double phone;
        private string address;
        private int iCID;
        private string itemCategory;
        private int sUID;
        private int iTID;
        private string itemName;
        private int iMID;
        private string manufacturer;
        private string invoiceNo;
        private string invoiceDate;
        private string itemType;
        private DateTime purchaseDate;
        private string batchNo;
        private double quantity;
        private double rate;
        private double unitCost;
        private double minQty;
        private int tSID;
        private string pONo;
        private string fileNo;
        private double empID;

        private string bankAccNo;
        private string fathersName;
        private DateTime dOB;
        private DateTime dOJ;
        private string gender;
        private int eID;
        private string aadhar;
        private string state;
        private string bankAcType;
        private string bankName;
        private string bankBranchName;
        private string iFSCCode;
        private int tRAID;
        private double tRA;
        private double minBasicPay;
        private double minGradePay;
        private DateTime dOR;
        private double basicPay;
        private string payLevel;
        private string tRAEligible;
        private string tRGEligible;
        private double tRGA;
        private string nPAEligible;
        private string pFAccType;
        private string pFAccNo;
        private string pHCStatus;
        private string quarterAllotted;
        private string rentFreeAccom;
        private double specialDutyAllow;
        private double patientCareAllow;
        private double bookAllow;
        private double washingAllow;
        private string dPAType;
        private double sumptuaryAllow;
        private double otherAllow;
        private double arrears;
        private string staffBus;
        private string grossSalWords;
        private string projectTitle;
        private string projectDuration;
        private string projectCoordinator;
        private string centreHead;
        private int pID;
        private int pSTID;
        private string quarterType;
        private string month;
        private int year;
        private double profTax;
        private double incomeTax;
        private double licenceFee;
        private double waterCharges;
        private double garbageCharges;
        private double garageCharges;
        private double electricityCharges;
        private double tARecovery;
        private double otherDeductions;
        private double totDeductions;
        private double netPay;
        private int totDays;
        private double lopDays;
        private double lopAmount;
        private string projectCode;
        private int eMSID;
        private string offOrderNo;
        private DateTime offOrderDate;
        private string offOrderIssuingAuthority;
        private int sNO;
        private string voucherID;
        private double vNetSal;
        private string vNetSalInWords;
        private DateTime fDOJ;
        private DateTime eDate;
        private int flag1;
        private string chequeNo;
        private string chequeDate;
        private string primaryUnit;
        private string secondaryUnit;
        private string amountPayable;
        private string udated;
        private string citizenType;
        private string driverType;
        private string licenceNo;
        private string licenceValidDate;
        private int vDID;
        private string modelType;
        private string vehicleName;
        private string vehicleNumber;
        private int seatCapacity;
        private string vehicleType;
        private int eGID;
        private string empGroup;
        private string circularType;
        private string title;
        private string fileName;
        private int pCID;
        private string blockStatus;
        private int vVID;
        private int visitID;
        private string visitBy;
        private double cPMobile;
        private string cPEmail;
        private string purpose;
        private string campusStay;
        private string bPhoto;
        private int vCardNo;
        private string visitorType;
        private string contactPerson;
        private int dVID;
        private string toDay;
        private int vCID;
        private string qRCode;
        private int iSNo;
        private string indentNo;
        private int sPID;
        private string pCode;
        private string pTitle;
        private DateTime reqDate;
        private DateTime issuedDate;
        private double rQuantity;
        private double aQuantity;
        private double iQuantity;
        private int flag2;
        private int flag3;
        private int tEIID;
        private int flag4;
        private string rIndentNo;
        private string remarks;
        private int sTID;
        private double aPrice;
        private int eIID;
        private int tAEIID;
        private string apprvdIndentNo;
        private string aQRCode;
        private string isHOC;
        private string fromDate;
        private string newPassword;
        private int gHID;
        private string hType;
        private int hFID;
        private string hFloor;
        private int rTID;
        private string roomType;
        private int hRID;
        private string roomNo;
        private int vBSNo;
        private string vBName;
        private DateTime bookedDate;
        private DateTime releavedDate;
        private int daysInMonth;
        private double lOPPPB;
        private double lOPGRP;
        private double lOPBasicPay;
        private double lOPDA;
        private double lOPHRA;
        private double lOPGrossPay;
        private double lOPTRA;
        private double gPF;
        private double cPF;
        private double nPS;
        private double pFA;
        private double mS;
        private string lopGrossPayinWords;
        private double sF;
        private double gC;
        private double qR;
        private double eC;
        private double wC;
        private double bF;
        private double lIC;
        private double gI;
        private double iT;
        private double pT;
        private double sC;
        private double hBA_NIRD;
        private double hBA_HDFC;
        private double hBA_Others;
        private double hBA_Adv_Int;
        private double iNTA;
        private double tAdv;
        private double cabTV;
        private double vAdv;
        private double vAdvInt;
        private double bankLoan;
        private double cDLNo;
        private double pLI;
        private double compL;
        private double compLInt;
        private double others;
        private double bFA;
        private double bFAInt;
        private double courtAt;
        private double hC;
        private string netPayInWords;
        private double minGSal;
        private double maxGSal;
        private int pT_ID;
        private double lICPolicyNumber;
        private double lICPolicyAmount;
        private int lPID;
        private int bLID;
        private double loanAmount;
        private string purposeofJourney;
        private string journeyDetails;
        private int noofPersons;
        private string progCode;
        private string progType;
        private string progTitle;
        private string progCoordinator;
        private string progDept;
        private string pPDate;
        private string pPTime;
        private string pPAddress;
        private string placetoVisit;
        private string visitDate;
        private string visitTime;
        private string trainDetails;
        private string flightDetails;
        private string totHaltingTime;
        private string returnDate;
        private string returnTime;
        private string uDesign;
        private string uEmail;
        private double uMobile;
        private int tVIID;
        private int uEmpID;
        private int hEmpID;
        private string hName;
        private string hMobile;
        private string hDesign;
        private string hDeptID;
        private string hEmail;
        private int hoC_Approval;
        private int vS_Approval;
        private int aRE_Approval;
        private string hoC_Status;
        private string vS_Status;
        private string aRE_Status;
        private int vS_FinalApproval;
        private string vS_FinalStatus;
        private string driverMobile;
        private string driverName;
        private string journeyStatus;
        private string sPlace;
        private int sGID;
        private string sGNO;
        private string surName;
        private string lastDate;
        private string report;
        private string tourType;
        private string tourCategory;
        private string tourTitle;
        private string tourPlaces;
        private int eTRID;
        private string toDate;
        private string cPType;
        private string oTP;
        private string vTripType;
        private string vJourneyPurpose;
        private string progDuration;
        private string arrType;
        private string tripType;
        private string rUID;
        private string rUName;
        private string rUDate;
        private string blockName;
        private string floor;
        private string intercom;
        private int pTID;
        private int eMBSID;
        private string monthYear;
        private string assessmentYear;
        private int age;
        private double tGrossSal;
        private double tHRA;
        private double totalGSal;
        private double standardDeduction;
        private double grandTotalGrossSal;
        private double iRH_Loan_Max;
        private double iRH_Loan_Allowed;
        private double pHC_80U_Max;
        private double pHC_80U_Allowed;
        private double medIP_80D_Max;
        private double medIP_80D_Allowed;
        private double mTHD_80MTHD_Max;
        private double mTHD_80MTHD_Allowed;
        private double med_80DDB_Max;
        private double med_80DDB_Allowed;
        private double repayment_80E_Max;
        private double repayment_80E_Allowed;
        private double donations_80G_Max;
        private double donations_80G_Allowed;
        private double nPS_80CCD_Max;
        private double nPS_80CCD_Allowed;
        private double infracture_80CCF_Max;
        private double infracture_80CCF_Allowed;
        private double totalIncomeRebate;
        private double maxAllowedRebate;
        private double gPF_Max;
        private double gPF_Allowed;
        private double lIC_Max;
        private double lIC_Allowed;
        private double postSS_Max;
        private double postSS_Allowed;
        private double nSC_Max;
        private double nSC_Allowed;
        private double uLIP_Max;
        private double uLIP_Allowed;
        private double tutionFee_Max;
        private double tutionFee_Allowed;
        private double pPHouseLoan_Max;
        private double pPHouseLoan_Allowed;
        private double bonds_Max;
        private double bonds_Allowed;
        private double mutualFunds_Max;
        private double mutualFunds_Allowed;
        private double gI_Max;
        private double gI_Allowed;
        private double publicPF_Max;
        private double publicPF_Allowed;
        private double totalTaxableIncome;
        private double rebate_87A;
        private double surChargePercentage;
        private double educationCess;
        private double netTaxPayble;
        private double taxRecovered;
        private string taxRecoveredinWords;
        private double taxTobeRecovered;
        private double iRH_Loan_Actual;
        private double pHC_80U_Actual;
        private double medIP_80D_Actual;
        private double mTHD_80MTHD_Actual;
        private double med_80DDB_Actual;
        private double repayment_80E_Actual;
        private double donations_80G_Actual;
        private double nPS_80CCD_Actual;
        private double infracture_80CCF_Actual;
        private double gPF_Actual;
        private double lIC_Actual;
        private double postSS_Actual;
        private double nSC_Actual;
        private double uLIP_Actual;
        private double tutionFee_Actual;
        private double pPHouseLoan_Actual;
        private double bonds_Actual;
        private double mutualFunds_Actual;
        private double gI_Actual;
        private double publicPF_Actual;
        private double taxonTotIncome;
        private double totalTax;
        private double totalTaxRebate;
        private string programID;
        private string rPCode;
        private string progVenue;
        private string progclientele;
        private double aggregate_IV_A;
        private string tDSQuarter1;
        private string tDSQuarter2;
        private string tDSQuarter3;
        private string tDSQuarter4;
        private string message;
        private string smsCount;
        private DateTime smsSentTime;
        private string dLRStatus;
        private string jobID;
        private string dLRTime;
        private string govMail;
        private string serialNo;
        private string warranty;
        private string computerNo;
        private int iID;
        private string warrantyDate;
        private string dOP;
        private string location;
        private int lID;
        private int fLID;
        private int rMID;
        private int mIID;
        private int cSID;
        private int tID;
        private double ticketNo;
        private string availableTime;
        private string problemDescription;
        private string comment;
        private string offerLetter;
        private string quarterNumber;
        private string bankAccountNumber;
        private int hTID;
        private string holidayType;
        private DateTime hDate;
        private int lHID;
        private int lTID;
        private string leaveType;
        private string leaveTypeFullform;
        private int lTMaxDays;
        private int availDays;
        private int oLID;
        private string officerLevel;
        private int lDAID;
        private double cL;
        private double rH;
        private double eL;
        private double hPL;
        private double cML;
        private double eOL;
        private double sL;
        private double pL;
        private double mL;
        private double sCL;
        private double sTL;
        private double cCL;
        private double cPL;
        private double dL;
        private double vL;
        private double noofLeaves;
        private int oEmpID;
        private string oEmpName;
        private string lAction;
        private string holiday;
        private string leaveCategory;
        private string sLeaveType;
        private string sLFileName;
        private string sLFromDate;
        private string sLToDate;
        private string sLDay;
        private double sLNoofDays;
        private string cLeaveType;
        private string cLFileName;
        private string cLFromDate;
        private string cLToDate;
        private string cLDay;
        private double cLNoofDays;
        private string stationLeaveStatus;
        private string sTLFromDate;
        private string sTLToDate;
        private string sTLAfterOfficeHours;
        private string sTLBeforeOfficeHours;
        private string oDeptID;
        private string oMobile;
        private string oDesign;
        private string oName;
        private int eLAID;
        private string lTCAvailStatus;
        private string extIndiaStatus;
        private string purposeofLeave;
        private string outStationContacts;
        private string oEmail;
        private string oLevel;
        private string eLeaveID;
        private string inTime;
        private string outTime;
        private int flag5;
        private string sLPrefixDates;
        private string sLSufixDates;
        private string cLPrefixDates;
        private string cLSufixDates;
        private string cCMail;
        private string currentLeaveStatus;
        private string lDecision;
        private int lSO;
        private int lDA;
        private int lCancel;
        private int lPullBack;
        private int approval;
        private string attendanceID;
        private int tMID;
        private string tourMode;
        private string fromLocation;
        private string toLocation;
        private string purposeofTour;
        private string eTourID;
        private string duration;
        private int lT8Days;
        private int gT8Days;
        private double pDays;
        private double aDays;
        private double hDays;
        private double wDays;
        private double lDays;
        private double tDays;
        private string gT8Hours;
        private string lT8Hours;
        private string sLFromSession;
        private string sLToSession;
        private int pCEmpID;
        private string pCEmpName;
        private string pCDesign;
        private string pCDeptID;
        private string pCEmail;
        private string pCMobile;
        private string pCLevel;
        private string hLevel;
        private string pCAction;
        private string pCStatus;
        private string pCApproved;
        private string pCADate;
        private string hAction;
        private string hStatus;
        private string hApproved;
        private string hADate;
        private string aEmpID;
        private string aName;
        private string aDate;
        private int reject;
        private int tCancel;
        private int tPullBack;
        private string currentTourStatus;
        private string tAction;
        private string briefNote;
        private string observations;
        private string actionItems;
        private string sqlBackupPath;
        private int eLID;
        private string essentialStatus;
        private int cHolidays;
        private double expDays;
        private string cLFromSession;
        private string cLToSession;
        private string dates;
        private double days;
        private string problemType;
        private int lEID;
        private int aTMID;
        private double actualDays;
        private double availedDays;
        private double remainingDays;
        private string approvalFile;
        private string lDAName;
        private int dayNo;
        private string joinDate;
        private string lTCEncashment;
        private string cPLDate;
        private string cPLReason;
        private string prevBalance;
        private string remBalance;
        private double hWDays;
        private double hTDays;
        private string workAssignTo;
        private int eLDID;
        private string workArea;
        private string skillSet;
        private string experience;
        private string resumeTitle;
        private string userAge;
        private string qualification;
        private string myDate;
        private string totHours;

        private string mLHours;
        private string eEHours;
        private string actualDuration;
        private string wHours;
        private string tWHours;
        private string tMLHours;
        private string tEEHours;
        private string tActualDuration;
        private string tPDays;
        private string pHours;
        private string otherDays;
        private string spentHours;
        private string totLateHours;
        private string missedDates;
        private string jStatus;
        private string jType;
        private string invoiceNumber;
        private string dSNo;
        private string userType;
        private string cardNo;
        private string relation;
        private string healthCard;
        private string contentType;
        private byte[] data;
        private string problemCategory;
        private string description;
        private int flag_Open;
        private int flag_Hold;
        private int flag_Close;
        private string complaintID;
        private double sCA;
        private string availedUptoDate;
        private string hall;
        private int hID;
        private string payMatrixLevel;
        private string accommodationAmt;
        private string convanceAmt;
        private string foodBillsAmt;
        private string flightType;
        private string ticketBy;
        private string ticketAgency;
        private string advanceRequired;
        private string tAEligibileAmt;
        private string ticketAmt;
        private string totalAmt;
        private string totaccommodationAmt;
        private string totconvanceAmt;
        private string totfoodBillsAmt;
        private string hCode;
        private string hCodeTitle;
        private int hCID;
        private int sHCID;
        private string sHCode;
        private string sHCodeTitle;
        private string finalReqAdvAmt;
        private string roleType;
        private int fUID;
        private string reqCode;
        private string approvalID;
        private int approvalSNo;
        private string referenceID;
        private string application;
        private double lOPReqDays;
        private int flag_New;
        private string priority;
        private int dVSNo;
        private string dVoucherID;
        private string finalApprovedAdvAmt;
        private string currentStatus;
        private string personalEssay;
        private int nextYear;
        private string aCRID;
        private string highestQualification;
        private string areaOfSpecialisation;
        private string aPRSubmissionDate;
        private string tourDays;
        private int aWID;
        private double totalDays;
        private int aDID;
        private string duties;
        private string trainingProgs_Events;
        private string targeted;
        private string achieved;
        private int tPEID;
        private int rID;
        private string research;
        private string noofSessions;
        private string rating;
        private int tPID;
        private int rPID;
        private string dateofInitiation;
        private string completionStatus;
        private string dateofCompletion;
        private string journalStatus;
        private string nameoftheJournal;
        private string iSBNNumber;
        private string authorName;
        private string reviewTitle;
        private string outcome;
        private string details;
        private string assmentOfWorkOutput;
        private string assessmentOfFinCompetency;
        private string assessmentOfPersonalAttributes;
        private string assessmentOfSpecialAttributes;
        private int flag_Submit;
        private string qualityOfWork;
        private string grading;
        private double grade;
        private string workOutputParameter;
        private string funtionalCompetencyParameter;
        private string perAttributesParameter;
        private string sPLAttributesParameter;
        private string generalAssessment;
        private string integrity;
        private string stateofHealth;
        private int flag_RPTG_OFFICER;
        private DateTime rPTG_OFFICER_Dated;
        private int flag_REVG_OFFICER;
        private DateTime rEVG_OFFICER_Dated;
        private int flag_ACPT_OFFICER;
        private DateTime aCPT_OFFICER_Dated;
        private string lengthOfService;
        private string rPTStatus;
        private string reasons;
        private DateTime submit_Date;
        private int aPDID;
        private int iD;
        private string designation;
        private string pho;

        public string Pho
        {
            get { return pho; }
            set { pho = value; }
        }

        public string Designation
        {
            get { return designation; }
            set { designation = value; }
        }

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }

        public int APDID
        {
            get { return aPDID; }
            set { aPDID = value; }
        }

        public DateTime Submit_Date
        {
            get { return submit_Date; }
            set { submit_Date = value; }
        }

        public string Reasons
        {
            get { return reasons; }
            set { reasons = value; }
        }

        public string RPTStatus
        {
            get { return rPTStatus; }
            set { rPTStatus = value; }
        }

        public string LengthOfService
        {
            get { return lengthOfService; }
            set { lengthOfService = value; }
        }

        public DateTime ACPT_OFFICER_Dated
        {
            get { return aCPT_OFFICER_Dated; }
            set { aCPT_OFFICER_Dated = value; }
        }

        public int Flag_ACPT_OFFICER
        {
            get { return flag_ACPT_OFFICER; }
            set { flag_ACPT_OFFICER = value; }
        }

        public DateTime REVG_OFFICER_Dated
        {
            get { return rEVG_OFFICER_Dated; }
            set { rEVG_OFFICER_Dated = value; }
        }

        public int Flag_REVG_OFFICER
        {
            get { return flag_REVG_OFFICER; }
            set { flag_REVG_OFFICER = value; }
        }

        public DateTime RPTG_OFFICER_Dated
        {
            get { return rPTG_OFFICER_Dated; }
            set { rPTG_OFFICER_Dated = value; }
        }

        public int Flag_RPTG_OFFICER
        {
            get { return flag_RPTG_OFFICER; }
            set { flag_RPTG_OFFICER = value; }
        }

        public string StateofHealth
        {
            get { return stateofHealth; }
            set { stateofHealth = value; }
        }

        public string Integrity
        {
            get { return integrity; }
            set { integrity = value; }
        }

        public string GeneralAssessment
        {
            get { return generalAssessment; }
            set { generalAssessment = value; }
        }

        public string SPLAttributesParameter
        {
            get { return sPLAttributesParameter; }
            set { sPLAttributesParameter = value; }
        }

        public string PerAttributesParameter
        {
            get { return perAttributesParameter; }
            set { perAttributesParameter = value; }
        }

        public string FuntionalCompetencyParameter
        {
            get { return funtionalCompetencyParameter; }
            set { funtionalCompetencyParameter = value; }
        }

        public string WorkOutputParameter
        {
            get { return workOutputParameter; }
            set { workOutputParameter = value; }
        }

        public double Grade
        {
            get { return grade; }
            set { grade = value; }
        }

        public string Grading
        {
            get { return grading; }
            set { grading = value; }
        }

        public string QualityOfWork
        {
            get { return qualityOfWork; }
            set { qualityOfWork = value; }
        }

        public int Flag_Submit
        {
            get { return flag_Submit; }
            set { flag_Submit = value; }
        }

        public string AssessmentOfSpecialAttributes
        {
            get { return assessmentOfSpecialAttributes; }
            set { assessmentOfSpecialAttributes = value; }
        }

        public string AssessmentOfPersonalAttributes
        {
            get { return assessmentOfPersonalAttributes; }
            set { assessmentOfPersonalAttributes = value; }
        }

        public string AssessmentOfFinCompetency
        {
            get { return assessmentOfFinCompetency; }
            set { assessmentOfFinCompetency = value; }
        }

        public string AssmentOfWorkOutput
        {
            get { return assmentOfWorkOutput; }
            set { assmentOfWorkOutput = value; }
        }

        public string Details
        {
            get { return details; }
            set { details = value; }
        }

        public string Outcome
        {
            get { return outcome; }
            set { outcome = value; }
        }

        public string ReviewTitle
        {
            get { return reviewTitle; }
            set { reviewTitle = value; }
        }

        public string AuthorName
        {
            get { return authorName; }
            set { authorName = value; }
        }

        public string ISBNNumber
        {
            get { return iSBNNumber; }
            set { iSBNNumber = value; }
        }

        public string NameoftheJournal
        {
            get { return nameoftheJournal; }
            set { nameoftheJournal = value; }
        }

        public string JournalStatus
        {
            get { return journalStatus; }
            set { journalStatus = value; }
        }

        public string DateofCompletion
        {
            get { return dateofCompletion; }
            set { dateofCompletion = value; }
        }

        public string CompletionStatus
        {
            get { return completionStatus; }
            set { completionStatus = value; }
        }

        public string DateofInitiation
        {
            get { return dateofInitiation; }
            set { dateofInitiation = value; }
        }

        public int RPID
        {
            get { return rPID; }
            set { rPID = value; }
        }

        public int TPID
        {
            get { return tPID; }
            set { tPID = value; }
        }

        public string Rating
        {
            get { return rating; }
            set { rating = value; }
        }

        public string NoofSessions
        {
            get { return noofSessions; }
            set { noofSessions = value; }
        }

        public string Research
        {
            get { return research; }
            set { research = value; }
        }

        public int RID
        {
            get { return rID; }
            set { rID = value; }
        }

        public int TPEID
        {
            get { return tPEID; }
            set { tPEID = value; }
        }

        public string Achieved
        {
            get { return achieved; }
            set { achieved = value; }
        }

        public string Targeted
        {
            get { return targeted; }
            set { targeted = value; }
        }

        public string TrainingProgs_Events
        {
            get { return trainingProgs_Events; }
            set { trainingProgs_Events = value; }
        }

        public string Duties
        {
            get { return duties; }
            set { duties = value; }
        }

        public int ADID
        {
            get { return aDID; }
            set { aDID = value; }
        }

        public double TotalDays
        {
            get { return totalDays; }
            set { totalDays = value; }
        }

        public int AWID
        {
            get { return aWID; }
            set { aWID = value; }
        }

        public string TourDays
        {
            get { return tourDays; }
            set { tourDays = value; }
        }

        public string APRSubmissionDate
        {
            get { return aPRSubmissionDate; }
            set { aPRSubmissionDate = value; }
        }

        public string AreaOfSpecialisation
        {
            get { return areaOfSpecialisation; }
            set { areaOfSpecialisation = value; }
        }

        public string HighestQualification
        {
            get { return highestQualification; }
            set { highestQualification = value; }
        }

        public string ACRID
        {
            get { return aCRID; }
            set { aCRID = value; }
        }

        public int NextYear
        {
            get { return nextYear; }
            set { nextYear = value; }
        }

        public string PersonalEssay
        {
            get { return personalEssay; }
            set { personalEssay = value; }
        }

        public string CurrentStatus
        {
            get { return currentStatus; }
            set { currentStatus = value; }
        }

        public string FinalApprovedAdvAmt
        {
            get { return finalApprovedAdvAmt; }
            set { finalApprovedAdvAmt = value; }
        }

        public string DVoucherID
        {
            get { return dVoucherID; }
            set { dVoucherID = value; }
        }

        public int DVSNo
        {
            get { return dVSNo; }
            set { dVSNo = value; }
        }

        public string Priority
        {
            get { return priority; }
            set { priority = value; }
        }

        public int Flag_New
        {
            get { return flag_New; }
            set { flag_New = value; }
        }

        public double LOPReqDays
        {
            get { return lOPReqDays; }
            set { lOPReqDays = value; }
        }

        public string Application
        {
            get { return application; }
            set { application = value; }
        }

        public string ReferenceID
        {
            get { return referenceID; }
            set { referenceID = value; }
        }

        public int ApprovalSNo
        {
            get { return approvalSNo; }
            set { approvalSNo = value; }
        }

        public string ApprovalID
        {
            get { return approvalID; }
            set { approvalID = value; }
        }

        public string ReqCode
        {
            get { return reqCode; }
            set { reqCode = value; }
        }

        public int FUID
        {
            get { return fUID; }
            set { fUID = value; }
        }

        public string RoleType
        {
            get { return roleType; }
            set { roleType = value; }
        }

        public string FinalReqAdvAmt
        {
            get { return finalReqAdvAmt; }
            set { finalReqAdvAmt = value; }
        }

        public string SHCodeTitle
        {
            get { return sHCodeTitle; }
            set { sHCodeTitle = value; }
        }

        public string SHCode
        {
            get { return sHCode; }
            set { sHCode = value; }
        }

        public int SHCID
        {
            get { return sHCID; }
            set { sHCID = value; }
        }

        public int HCID
        {
            get { return hCID; }
            set { hCID = value; }
        }

        public string HCodeTitle
        {
            get { return hCodeTitle; }
            set { hCodeTitle = value; }
        }

        public string HCode
        {
            get { return hCode; }
            set { hCode = value; }
        }

        public string TotfoodBillsAmt
        {
            get { return totfoodBillsAmt; }
            set { totfoodBillsAmt = value; }
        }

        public string TotconvanceAmt
        {
            get { return totconvanceAmt; }
            set { totconvanceAmt = value; }
        }

        public string TotaccommodationAmt
        {
            get { return totaccommodationAmt; }
            set { totaccommodationAmt = value; }
        }

        public string TotalAmt
        {
            get { return totalAmt; }
            set { totalAmt = value; }
        }

        public string TicketAmt
        {
            get { return ticketAmt; }
            set { ticketAmt = value; }
        }

        public string TAEligibileAmt
        {
            get { return tAEligibileAmt; }
            set { tAEligibileAmt = value; }
        }

        public string AdvanceRequired
        {
            get { return advanceRequired; }
            set { advanceRequired = value; }
        }

        public string TicketAgency
        {
            get { return ticketAgency; }
            set { ticketAgency = value; }
        }

        public string TicketBy
        {
            get { return ticketBy; }
            set { ticketBy = value; }
        }

        public string FlightType
        {
            get { return flightType; }
            set { flightType = value; }
        }

        public string FoodBillsAmt
        {
            get { return foodBillsAmt; }
            set { foodBillsAmt = value; }
        }

        public string ConvanceAmt
        {
            get { return convanceAmt; }
            set { convanceAmt = value; }
        }

        public string AccommodationAmt
        {
            get { return accommodationAmt; }
            set { accommodationAmt = value; }
        }

        public string PayMatrixLevel
        {
            get { return payMatrixLevel; }
            set { payMatrixLevel = value; }
        }

        public int HID
        {
            get { return hID; }
            set { hID = value; }
        }

        public string Hall
        {
            get { return hall; }
            set { hall = value; }
        }

        public string AvailedUptoDate
        {
            get { return availedUptoDate; }
            set { availedUptoDate = value; }
        }

        public double SCA
        {
            get { return sCA; }
            set { sCA = value; }
        }

        public string ComplaintID
        {
            get { return complaintID; }
            set { complaintID = value; }
        }

        public int Flag_Close
        {
            get { return flag_Close; }
            set { flag_Close = value; }
        }

        public int Flag_Hold
        {
            get { return flag_Hold; }
            set { flag_Hold = value; }
        }

        public int Flag_Open
        {
            get { return flag_Open; }
            set { flag_Open = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string ProblemCategory
        {
            get { return problemCategory; }
            set { problemCategory = value; }
        }

        public byte[] Data
        {
            get { return data; }
            set { data = value; }
        }

        public string ContentType
        {
            get { return contentType; }
            set { contentType = value; }
        }

        public string HealthCard
        {
            get { return healthCard; }
            set { healthCard = value; }
        }

        public string Relation
        {
            get { return relation; }
            set { relation = value; }
        }

        public string CardNo
        {
            get { return cardNo; }
            set { cardNo = value; }
        }

        public string UserType
        {
            get { return userType; }
            set { userType = value; }
        }

        public string DSNo
        {
            get { return dSNo; }
            set { dSNo = value; }
        }

        public string InvoiceNumber
        {
            get { return invoiceNumber; }
            set { invoiceNumber = value; }
        }

        public string JType
        {
            get { return jType; }
            set { jType = value; }
        }

        public string JStatus
        {
            get { return jStatus; }
            set { jStatus = value; }
        }

        public string MissedDates
        {
            get { return missedDates; }
            set { missedDates = value; }
        }

        public string TotLateHours
        {
            get { return totLateHours; }
            set { totLateHours = value; }
        }

        public string SpentHours
        {
            get { return spentHours; }
            set { spentHours = value; }
        }

        public string OtherDays
        {
            get { return otherDays; }
            set { otherDays = value; }
        }

        public string PHours
        {
            get { return pHours; }
            set { pHours = value; }
        }

        public string TPDays
        {
            get { return tPDays; }
            set { tPDays = value; }
        }

        public string TActualDuration
        {
            get { return tActualDuration; }
            set { tActualDuration = value; }
        }

        public string TEEHours
        {
            get { return tEEHours; }
            set { tEEHours = value; }
        }

        public string TMLHours
        {
            get { return tMLHours; }
            set { tMLHours = value; }
        }

        public string TWHours
        {
            get { return tWHours; }
            set { tWHours = value; }
        }

        public string WHours
        {
            get { return wHours; }
            set { wHours = value; }
        }

        public string ActualDuration
        {
            get { return actualDuration; }
            set { actualDuration = value; }
        }

        public string EEHours
        {
            get { return eEHours; }
            set { eEHours = value; }
        }

        public string MLHours
        {
            get { return mLHours; }
            set { mLHours = value; }
        }


        public string TotHours
        {
            get { return totHours; }
            set { totHours = value; }
        }

        public string MyDate
        {
            get { return myDate; }
            set { myDate = value; }
        }

        public string Qualification
        {
            get { return qualification; }
            set { qualification = value; }
        }
        public string UserAge
        {
            get { return userAge; }
            set { userAge = value; }
        }

        public string ResumeTitle
        {
            get { return resumeTitle; }
            set { resumeTitle = value; }
        }

        public string Experience
        {
            get { return experience; }
            set { experience = value; }
        }

        public string SkillSet
        {
            get { return skillSet; }
            set { skillSet = value; }
        }

        public string WorkArea
        {
            get { return workArea; }
            set { workArea = value; }
        }

        public int ELDID
        {
            get { return eLDID; }
            set { eLDID = value; }
        }

        public string WorkAssignTo
        {
            get { return workAssignTo; }
            set { workAssignTo = value; }
        }

        public double HTDays
        {
            get { return hTDays; }
            set { hTDays = value; }
        }

        public double HWDays
        {
            get { return hWDays; }
            set { hWDays = value; }
        }

        public string RemBalance
        {
            get { return remBalance; }
            set { remBalance = value; }
        }

        public string PrevBalance
        {
            get { return prevBalance; }
            set { prevBalance = value; }
        }

        public string CPLReason
        {
            get { return cPLReason; }
            set { cPLReason = value; }
        }

        public string CPLDate
        {
            get { return cPLDate; }
            set { cPLDate = value; }
        }

        public string LTCEncashment
        {
            get { return lTCEncashment; }
            set { lTCEncashment = value; }
        }

        public string JoinDate
        {
            get { return joinDate; }
            set { joinDate = value; }
        }

        public int DayNo
        {
            get { return dayNo; }
            set { dayNo = value; }
        }

        public string LDAName
        {
            get { return lDAName; }
            set { lDAName = value; }
        }

        public string ApprovalFile
        {
            get { return approvalFile; }
            set { approvalFile = value; }
        }

        public double RemainingDays
        {
            get { return remainingDays; }
            set { remainingDays = value; }
        }

        public double AvailedDays
        {
            get { return availedDays; }
            set { availedDays = value; }
        }

        public double ActualDays
        {
            get { return actualDays; }
            set { actualDays = value; }
        }

        public int ATMID
        {
            get { return aTMID; }
            set { aTMID = value; }
        }

        public int LEID
        {
            get { return lEID; }
            set { lEID = value; }
        }

        public string ProblemType
        {
            get { return problemType; }
            set { problemType = value; }
        }

        public double Days
        {
            get { return days; }
            set { days = value; }
        }

        public string Dates
        {
            get { return dates; }
            set { dates = value; }
        }

        public string CLToSession
        {
            get { return cLToSession; }
            set { cLToSession = value; }
        }

        public string CLFromSession
        {
            get { return cLFromSession; }
            set { cLFromSession = value; }
        }

        public double ExpDays
        {
            get { return expDays; }
            set { expDays = value; }
        }

        public int CHolidays
        {
            get { return cHolidays; }
            set { cHolidays = value; }
        }

        public string EssentialStatus
        {
            get { return essentialStatus; }
            set { essentialStatus = value; }
        }

        public int ELID
        {
            get { return eLID; }
            set { eLID = value; }
        }

        public string SqlBackupPath
        {
            get { return sqlBackupPath; }
            set { sqlBackupPath = value; }
        }

        public string ActionItems
        {
            get { return actionItems; }
            set { actionItems = value; }
        }

        public string Observations
        {
            get { return observations; }
            set { observations = value; }
        }

        public string BriefNote
        {
            get { return briefNote; }
            set { briefNote = value; }
        }

        public string TAction
        {
            get { return tAction; }
            set { tAction = value; }
        }

        public string CurrentTourStatus
        {
            get { return currentTourStatus; }
            set { currentTourStatus = value; }
        }

        public int TPullBack
        {
            get { return tPullBack; }
            set { tPullBack = value; }
        }

        public int TCancel
        {
            get { return tCancel; }
            set { tCancel = value; }
        }

        public int Reject
        {
            get { return reject; }
            set { reject = value; }
        }

        public string ADate
        {
            get { return aDate; }
            set { aDate = value; }
        }

        public string AName
        {
            get { return aName; }
            set { aName = value; }
        }

        public string AEmpID
        {
            get { return aEmpID; }
            set { aEmpID = value; }
        }


        public string HADate
        {
            get { return hADate; }
            set { hADate = value; }
        }

        public string HApproved
        {
            get { return hApproved; }
            set { hApproved = value; }
        }

        public string HStatus
        {
            get { return hStatus; }
            set { hStatus = value; }
        }

        public string HAction
        {
            get { return hAction; }
            set { hAction = value; }
        }

        public string PCADate
        {
            get { return pCADate; }
            set { pCADate = value; }
        }

        public string PCApproved
        {
            get { return pCApproved; }
            set { pCApproved = value; }
        }

        public string PCStatus
        {
            get { return pCStatus; }
            set { pCStatus = value; }
        }

        public string PCAction
        {
            get { return pCAction; }
            set { pCAction = value; }
        }

        public string HLevel
        {
            get { return hLevel; }
            set { hLevel = value; }
        }

        public string PCLevel
        {
            get { return pCLevel; }
            set { pCLevel = value; }
        }

        public string PCMobile
        {
            get { return pCMobile; }
            set { pCMobile = value; }
        }

        public string PCEmail
        {
            get { return pCEmail; }
            set { pCEmail = value; }
        }

        public string PCDeptID
        {
            get { return pCDeptID; }
            set { pCDeptID = value; }
        }

        public string PCDesign
        {
            get { return pCDesign; }
            set { pCDesign = value; }
        }

        public string PCEmpName
        {
            get { return pCEmpName; }
            set { pCEmpName = value; }
        }

        public int PCEmpID
        {
            get { return pCEmpID; }
            set { pCEmpID = value; }
        }

        public string SLToSession
        {
            get { return sLToSession; }
            set { sLToSession = value; }
        }

        public string SLFromSession
        {
            get { return sLFromSession; }
            set { sLFromSession = value; }
        }

        public string LT8Hours
        {
            get { return lT8Hours; }
            set { lT8Hours = value; }
        }

        public string GT8Hours
        {
            get { return gT8Hours; }
            set { gT8Hours = value; }
        }

        public double TDays
        {
            get { return tDays; }
            set { tDays = value; }
        }

        public double LDays
        {
            get { return lDays; }
            set { lDays = value; }
        }

        public double WDays
        {
            get { return wDays; }
            set { wDays = value; }
        }

        public double HDays
        {
            get { return hDays; }
            set { hDays = value; }
        }

        public double ADays
        {
            get { return aDays; }
            set { aDays = value; }
        }

        public double PDays
        {
            get { return pDays; }
            set { pDays = value; }
        }

        public int GT8Days
        {
            get { return gT8Days; }
            set { gT8Days = value; }
        }

        public int LT8Days
        {
            get { return lT8Days; }
            set { lT8Days = value; }
        }

        public string Duration
        {
            get { return duration; }
            set { duration = value; }
        }

        public string ETourID
        {
            get { return eTourID; }
            set { eTourID = value; }
        }

        public string PurposeofTour
        {
            get { return purposeofTour; }
            set { purposeofTour = value; }
        }

        public string ToLocation
        {
            get { return toLocation; }
            set { toLocation = value; }
        }

        public string FromLocation
        {
            get { return fromLocation; }
            set { fromLocation = value; }
        }

        public string TourMode
        {
            get { return tourMode; }
            set { tourMode = value; }
        }

        public int TMID
        {
            get { return tMID; }
            set { tMID = value; }
        }

        public string ELeaveID
        {
            get { return eLeaveID; }
            set { eLeaveID = value; }
        }

        public string OLevel
        {
            get { return oLevel; }
            set { oLevel = value; }
        }

        public string OEmail
        {
            get { return oEmail; }
            set { oEmail = value; }
        }

        public string OutStationContacts
        {
            get { return outStationContacts; }
            set { outStationContacts = value; }
        }

        public string PurposeofLeave
        {
            get { return purposeofLeave; }
            set { purposeofLeave = value; }
        }

        public string ExtIndiaStatus
        {
            get { return extIndiaStatus; }
            set { extIndiaStatus = value; }
        }

        public string LTCAvailStatus
        {
            get { return lTCAvailStatus; }
            set { lTCAvailStatus = value; }
        }

        public int ELAID
        {
            get { return eLAID; }
            set { eLAID = value; }
        }

        public string OName
        {
            get { return oName; }
            set { oName = value; }
        }

        public string ODesign
        {
            get { return oDesign; }
            set { oDesign = value; }
        }

        public string OMobile
        {
            get { return oMobile; }
            set { oMobile = value; }
        }

        public string ODeptID
        {
            get { return oDeptID; }
            set { oDeptID = value; }
        }

        public string STLBeforeOfficeHours
        {
            get { return sTLBeforeOfficeHours; }
            set { sTLBeforeOfficeHours = value; }
        }

        public string STLAfterOfficeHours
        {
            get { return sTLAfterOfficeHours; }
            set { sTLAfterOfficeHours = value; }
        }

        public string STLToDate
        {
            get { return sTLToDate; }
            set { sTLToDate = value; }
        }

        public string STLFromDate
        {
            get { return sTLFromDate; }
            set { sTLFromDate = value; }
        }

        public string StationLeaveStatus
        {
            get { return stationLeaveStatus; }
            set { stationLeaveStatus = value; }
        }

        public double CLNoofDays
        {
            get { return cLNoofDays; }
            set { cLNoofDays = value; }
        }

        public string CLDay
        {
            get { return cLDay; }
            set { cLDay = value; }
        }

        public string CLToDate
        {
            get { return cLToDate; }
            set { cLToDate = value; }
        }

        public string CLFromDate
        {
            get { return cLFromDate; }
            set { cLFromDate = value; }
        }

        public string CLFileName
        {
            get { return cLFileName; }
            set { cLFileName = value; }
        }

        public string CLeaveType
        {
            get { return cLeaveType; }
            set { cLeaveType = value; }
        }

        public double SLNoofDays
        {
            get { return sLNoofDays; }
            set { sLNoofDays = value; }
        }

        public string SLDay
        {
            get { return sLDay; }
            set { sLDay = value; }
        }

        public string SLToDate
        {
            get { return sLToDate; }
            set { sLToDate = value; }
        }

        public string SLFromDate
        {
            get { return sLFromDate; }
            set { sLFromDate = value; }
        }

        public string SLFileName
        {
            get { return sLFileName; }
            set { sLFileName = value; }
        }

        public string SLeaveType
        {
            get { return sLeaveType; }
            set { sLeaveType = value; }
        }

        public string LeaveCategory
        {
            get { return leaveCategory; }
            set { leaveCategory = value; }
        }

        public string Holiday
        {
            get { return holiday; }
            set { holiday = value; }
        }

        public string LAction
        {
            get { return lAction; }
            set { lAction = value; }
        }

        public string OEmpName
        {
            get { return oEmpName; }
            set { oEmpName = value; }
        }

        public int OEmpID
        {
            get { return oEmpID; }
            set { oEmpID = value; }
        }

        public double NoofLeaves
        {
            get { return noofLeaves; }
            set { noofLeaves = value; }
        }

        public double VL
        {
            get { return vL; }
            set { vL = value; }
        }

        public double DL
        {
            get { return dL; }
            set { dL = value; }
        }

        public double CPL
        {
            get { return cPL; }
            set { cPL = value; }
        }

        public double CCL
        {
            get { return cCL; }
            set { cCL = value; }
        }

        public double STL
        {
            get { return sTL; }
            set { sTL = value; }
        }

        public double SCL
        {
            get { return sCL; }
            set { sCL = value; }
        }

        public double ML
        {
            get { return mL; }
            set { mL = value; }
        }

        public double PL
        {
            get { return pL; }
            set { pL = value; }
        }

        public double SL
        {
            get { return sL; }
            set { sL = value; }
        }

        public double EOL
        {
            get { return eOL; }
            set { eOL = value; }
        }

        public double CML
        {
            get { return cML; }
            set { cML = value; }
        }

        public double HPL
        {
            get { return hPL; }
            set { hPL = value; }
        }

        public double EL
        {
            get { return eL; }
            set { eL = value; }
        }

        public double RH
        {
            get { return rH; }
            set { rH = value; }
        }

        public double CL
        {
            get { return cL; }
            set { cL = value; }
        }

        public int LDAID
        {
            get { return lDAID; }
            set { lDAID = value; }
        }

        public string OfficerLevel
        {
            get { return officerLevel; }
            set { officerLevel = value; }
        }

        public int OLID
        {
            get { return oLID; }
            set { oLID = value; }
        }

        public int AvailDays
        {
            get { return availDays; }
            set { availDays = value; }
        }

        public int LTMaxDays
        {
            get { return lTMaxDays; }
            set { lTMaxDays = value; }
        }

        public string LeaveTypeFullform
        {
            get { return leaveTypeFullform; }
            set { leaveTypeFullform = value; }
        }

        public string LeaveType
        {
            get { return leaveType; }
            set { leaveType = value; }
        }

        public int LTID
        {
            get { return lTID; }
            set { lTID = value; }
        }

        public int LHID
        {
            get { return lHID; }
            set { lHID = value; }
        }

        public DateTime HDate
        {
            get { return hDate; }
            set { hDate = value; }
        }

        public string HolidayType
        {
            get { return holidayType; }
            set { holidayType = value; }
        }

        public int HTID
        {
            get { return hTID; }
            set { hTID = value; }
        }

        public string BankAccountNumber
        {
            get { return bankAccountNumber; }
            set { bankAccountNumber = value; }
        }

        public string QuarterNumber
        {
            get { return quarterNumber; }
            set { quarterNumber = value; }
        }

        public string OfferLetter
        {
            get { return offerLetter; }
            set { offerLetter = value; }
        }

        public string Comment
        {
            get { return comment; }
            set { comment = value; }
        }
        public string ProblemDescription
        {
            get { return problemDescription; }
            set { problemDescription = value; }
        }

        public string AvailableTime
        {
            get { return availableTime; }
            set { availableTime = value; }
        }

        public double TicketNo
        {
            get { return ticketNo; }
            set { ticketNo = value; }
        }

        public int TID
        {
            get { return tID; }
            set { tID = value; }
        }

        public int CSID
        {
            get { return cSID; }
            set { cSID = value; }
        }

        public int MIID
        {
            get { return mIID; }
            set { mIID = value; }
        }

        public int RMID
        {
            get { return rMID; }
            set { rMID = value; }
        }

        public int FLID
        {
            get { return fLID; }
            set { fLID = value; }
        }

        public int LID
        {
            get { return lID; }
            set { lID = value; }
        }

        public string Location
        {
            get { return location; }
            set { location = value; }
        }

        public string DOP
        {
            get { return dOP; }
            set { dOP = value; }
        }

        public string WarrantyDate
        {
            get { return warrantyDate; }
            set { warrantyDate = value; }
        }

        public int IID
        {
            get { return iID; }
            set { iID = value; }
        }

        public string ComputerNo
        {
            get { return computerNo; }
            set { computerNo = value; }
        }

        public string Warranty
        {
            get { return warranty; }
            set { warranty = value; }
        }

        public string SerialNo
        {
            get { return serialNo; }
            set { serialNo = value; }
        }

        public string GovMail
        {
            get { return govMail; }
            set { govMail = value; }
        }

        public string DLRTime
        {
            get { return dLRTime; }
            set { dLRTime = value; }
        }

        public string JobID
        {
            get { return jobID; }
            set { jobID = value; }
        }

        public string DLRStatus
        {
            get { return dLRStatus; }
            set { dLRStatus = value; }
        }

        public DateTime SmsSentTime
        {
            get { return smsSentTime; }
            set { smsSentTime = value; }
        }

        public string SmsCount
        {
            get { return smsCount; }
            set { smsCount = value; }
        }

        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        public string TDSQuarter4
        {
            get { return tDSQuarter4; }
            set { tDSQuarter4 = value; }
        }
        public string TDSQuarter3
        {
            get { return tDSQuarter3; }
            set { tDSQuarter3 = value; }
        }
        public string TDSQuarter2
        {
            get { return tDSQuarter2; }
            set { tDSQuarter2 = value; }
        }
        public string TDSQuarter1
        {
            get { return tDSQuarter1; }
            set { tDSQuarter1 = value; }
        }

        public double Aggregate_IV_A
        {
            get { return aggregate_IV_A; }
            set { aggregate_IV_A = value; }
        }

        public string ProgClientele
        {
            get { return progclientele; }
            set { progclientele = value; }
        }

        public string ProgVenue
        {
            get { return progVenue; }
            set { progVenue = value; }
        }

        public string RPCode
        {
            get { return rPCode; }
            set { rPCode = value; }
        }

        public string ProgramID
        {
            get { return programID; }
            set { programID = value; }
        }

        public double TotalTaxRebate
        {
            get { return totalTaxRebate; }
            set { totalTaxRebate = value; }
        }

        public double TotalTax
        {
            get { return totalTax; }
            set { totalTax = value; }
        }

        public double TaxonTotIncome
        {
            get { return taxonTotIncome; }
            set { taxonTotIncome = value; }
        }

        public double PublicPF_Actual
        {
            get { return publicPF_Actual; }
            set { publicPF_Actual = value; }
        }

        public double GI_Actual
        {
            get { return gI_Actual; }
            set { gI_Actual = value; }
        }

        public double MutualFunds_Actual
        {
            get { return mutualFunds_Actual; }
            set { mutualFunds_Actual = value; }
        }

        public double Bonds_Actual
        {
            get { return bonds_Actual; }
            set { bonds_Actual = value; }
        }

        public double PPHouseLoan_Actual
        {
            get { return pPHouseLoan_Actual; }
            set { pPHouseLoan_Actual = value; }
        }

        public double TutionFee_Actual
        {
            get { return tutionFee_Actual; }
            set { tutionFee_Actual = value; }
        }

        public double ULIP_Actual
        {
            get { return uLIP_Actual; }
            set { uLIP_Actual = value; }
        }

        public double NSC_Actual
        {
            get { return nSC_Actual; }
            set { nSC_Actual = value; }
        }

        public double PostSS_Actual
        {
            get { return postSS_Actual; }
            set { postSS_Actual = value; }
        }

        public double LIC_Actual
        {
            get { return lIC_Actual; }
            set { lIC_Actual = value; }
        }

        public double GPF_Actual
        {
            get { return gPF_Actual; }
            set { gPF_Actual = value; }
        }

        public double Infracture_80CCF_Actual
        {
            get { return infracture_80CCF_Actual; }
            set { infracture_80CCF_Actual = value; }
        }

        public double NPS_80CCD_Actual
        {
            get { return nPS_80CCD_Actual; }
            set { nPS_80CCD_Actual = value; }
        }

        public double Donations_80G_Actual
        {
            get { return donations_80G_Actual; }
            set { donations_80G_Actual = value; }
        }

        public double Repayment_80E_Actual
        {
            get { return repayment_80E_Actual; }
            set { repayment_80E_Actual = value; }
        }

        public double Med_80DDB_Actual
        {
            get { return med_80DDB_Actual; }
            set { med_80DDB_Actual = value; }
        }

        public double MTHD_80MTHD_Actual
        {
            get { return mTHD_80MTHD_Actual; }
            set { mTHD_80MTHD_Actual = value; }
        }

        public double MedIP_80D_Actual
        {
            get { return medIP_80D_Actual; }
            set { medIP_80D_Actual = value; }
        }

        public double PHC_80U_Actual
        {
            get { return pHC_80U_Actual; }
            set { pHC_80U_Actual = value; }
        }

        public double IRH_Loan_Actual
        {
            get { return iRH_Loan_Actual; }
            set { iRH_Loan_Actual = value; }
        }

        public double TaxTobeRecovered
        {
            get { return taxTobeRecovered; }
            set { taxTobeRecovered = value; }
        }

        public string TaxRecoveredinWords
        {
            get { return taxRecoveredinWords; }
            set { taxRecoveredinWords = value; }
        }

        public double TaxRecovered
        {
            get { return taxRecovered; }
            set { taxRecovered = value; }
        }

        public double NetTaxPayble
        {
            get { return netTaxPayble; }
            set { netTaxPayble = value; }
        }

        public double EducationCess
        {
            get { return educationCess; }
            set { educationCess = value; }
        }

        public double SurChargePercentage
        {
            get { return surChargePercentage; }
            set { surChargePercentage = value; }
        }

        public double Rebate_87A
        {
            get { return rebate_87A; }
            set { rebate_87A = value; }
        }

        public double TotalTaxableIncome
        {
            get { return totalTaxableIncome; }
            set { totalTaxableIncome = value; }
        }

        public double PublicPF_Allowed
        {
            get { return publicPF_Allowed; }
            set { publicPF_Allowed = value; }
        }

        public double PublicPF_Max
        {
            get { return publicPF_Max; }
            set { publicPF_Max = value; }
        }

        public double GI_Allowed
        {
            get { return gI_Allowed; }
            set { gI_Allowed = value; }
        }

        public double GI_Max
        {
            get { return gI_Max; }
            set { gI_Max = value; }
        }

        public double MutualFunds_Allowed
        {
            get { return mutualFunds_Allowed; }
            set { mutualFunds_Allowed = value; }
        }

        public double MutualFunds_Max
        {
            get { return mutualFunds_Max; }
            set { mutualFunds_Max = value; }
        }

        public double Bonds_Allowed
        {
            get { return bonds_Allowed; }
            set { bonds_Allowed = value; }
        }

        public double Bonds_Max
        {
            get { return bonds_Max; }
            set { bonds_Max = value; }
        }

        public double PPHouseLoan_Allowed
        {
            get { return pPHouseLoan_Allowed; }
            set { pPHouseLoan_Allowed = value; }
        }

        public double PPHouseLoan_Max
        {
            get { return pPHouseLoan_Max; }
            set { pPHouseLoan_Max = value; }
        }


        public double TutionFee_Allowed
        {
            get { return tutionFee_Allowed; }
            set { tutionFee_Allowed = value; }
        }

        public double TutionFee_Max
        {
            get { return tutionFee_Max; }
            set { tutionFee_Max = value; }
        }

        public double ULIP_Allowed
        {
            get { return uLIP_Allowed; }
            set { uLIP_Allowed = value; }
        }

        public double ULIP_Max
        {
            get { return uLIP_Max; }
            set { uLIP_Max = value; }
        }

        public double NSC_Allowed
        {
            get { return nSC_Allowed; }
            set { nSC_Allowed = value; }
        }

        public double NSC_Max
        {
            get { return nSC_Max; }
            set { nSC_Max = value; }
        }


        public double PostSS_Allowed
        {
            get { return postSS_Allowed; }
            set { postSS_Allowed = value; }
        }

        public double PostSS_Max
        {
            get { return postSS_Max; }
            set { postSS_Max = value; }
        }

        public double LIC_Allowed
        {
            get { return lIC_Allowed; }
            set { lIC_Allowed = value; }
        }

        public double LIC_Max
        {
            get { return lIC_Max; }
            set { lIC_Max = value; }
        }

        public double GPF_Allowed
        {
            get { return gPF_Allowed; }
            set { gPF_Allowed = value; }
        }

        public double GPF_Max
        {
            get { return gPF_Max; }
            set { gPF_Max = value; }
        }

        public double MaxAllowedRebate
        {
            get { return maxAllowedRebate; }
            set { maxAllowedRebate = value; }
        }

        public double TotalIncomeRebate
        {
            get { return totalIncomeRebate; }
            set { totalIncomeRebate = value; }
        }

        public double Infracture_80CCF_Allowed
        {
            get { return infracture_80CCF_Allowed; }
            set { infracture_80CCF_Allowed = value; }
        }

        public double Infracture_80CCF_Max
        {
            get { return infracture_80CCF_Max; }
            set { infracture_80CCF_Max = value; }
        }

        public double NPS_80CCD_Allowed
        {
            get { return nPS_80CCD_Allowed; }
            set { nPS_80CCD_Allowed = value; }
        }

        public double NPS_80CCD_Max
        {
            get { return nPS_80CCD_Max; }
            set { nPS_80CCD_Max = value; }
        }

        public double Donations_80G_Allowed
        {
            get { return donations_80G_Allowed; }
            set { donations_80G_Allowed = value; }
        }

        public double Donations_80G_Max
        {
            get { return donations_80G_Max; }
            set { donations_80G_Max = value; }
        }

        public double Repayment_80E_Allowed
        {
            get { return repayment_80E_Allowed; }
            set { repayment_80E_Allowed = value; }
        }

        public double Repayment_80E_Max
        {
            get { return repayment_80E_Max; }
            set { repayment_80E_Max = value; }
        }

        public double Med_80DDB_Allowed
        {
            get { return med_80DDB_Allowed; }
            set { med_80DDB_Allowed = value; }
        }

        public double Med_80DDB_Max
        {
            get { return med_80DDB_Max; }
            set { med_80DDB_Max = value; }
        }

        public double MTHD_80MTHD_Allowed
        {
            get { return mTHD_80MTHD_Allowed; }
            set { mTHD_80MTHD_Allowed = value; }
        }

        public double MTHD_80MTHD_Max
        {
            get { return mTHD_80MTHD_Max; }
            set { mTHD_80MTHD_Max = value; }
        }

        public double MedIP_80D_Allowed
        {
            get { return medIP_80D_Allowed; }
            set { medIP_80D_Allowed = value; }
        }

        public double MedIP_80D_Max
        {
            get { return medIP_80D_Max; }
            set { medIP_80D_Max = value; }
        }

        public double PHC_80U_Allowed
        {
            get { return pHC_80U_Allowed; }
            set { pHC_80U_Allowed = value; }
        }

        public double PHC_80U_Max
        {
            get { return pHC_80U_Max; }
            set { pHC_80U_Max = value; }
        }

        public double IRH_Loan_Allowed
        {
            get { return iRH_Loan_Allowed; }
            set { iRH_Loan_Allowed = value; }
        }

        public double IRH_Loan_Max
        {
            get { return iRH_Loan_Max; }
            set { iRH_Loan_Max = value; }
        }
        public double GrandTotalGrossSal
        {
            get { return grandTotalGrossSal; }
            set { grandTotalGrossSal = value; }
        }

        public double StandardDeduction
        {
            get { return standardDeduction; }
            set { standardDeduction = value; }
        }

        public double TotalGSal1
        {
            get { return totalGSal; }
            set { totalGSal = value; }
        }

        public double THRA
        {
            get { return tHRA; }
            set { tHRA = value; }
        }

        public double TGrossSal
        {
            get { return tGrossSal; }
            set { tGrossSal = value; }
        }


        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public string AssessmentYear
        {
            get { return assessmentYear; }
            set { assessmentYear = value; }
        }

        public string MonthYear
        {
            get { return monthYear; }
            set { monthYear = value; }
        }

        public int EMBSID
        {
            get { return eMBSID; }
            set { eMBSID = value; }
        }

        public int PTID
        {
            get { return pTID; }
            set { pTID = value; }
        }

        public string Intercom
        {
            get { return intercom; }
            set { intercom = value; }
        }

        public string Floor
        {
            get { return floor; }
            set { floor = value; }
        }

        public string BlockName
        {
            get { return blockName; }
            set { blockName = value; }
        }

        public string RUDate
        {
            get { return rUDate; }
            set { rUDate = value; }
        }

        public string RUName
        {
            get { return rUName; }
            set { rUName = value; }
        }

        public string RUID
        {
            get { return rUID; }
            set { rUID = value; }
        }

        public string TripType
        {
            get { return tripType; }
            set { tripType = value; }
        }

        public string ArrType
        {
            get { return arrType; }
            set { arrType = value; }
        }

        public string ProgDuration
        {
            get { return progDuration; }
            set { progDuration = value; }
        }

        public string VJourneyPurpose
        {
            get { return vJourneyPurpose; }
            set { vJourneyPurpose = value; }
        }

        public string VTripType
        {
            get { return vTripType; }
            set { vTripType = value; }
        }

        public string OTP
        {
            get { return oTP; }
            set { oTP = value; }
        }

        public string CPType
        {
            get { return cPType; }
            set { cPType = value; }
        }

        public string ToDate
        {
            get { return toDate; }
            set { toDate = value; }
        }

        public int ETRID
        {
            get { return eTRID; }
            set { eTRID = value; }
        }

        public string TourPlaces
        {
            get { return tourPlaces; }
            set { tourPlaces = value; }
        }

        public string TourTitle
        {
            get { return tourTitle; }
            set { tourTitle = value; }
        }

        public string TourCategory
        {
            get { return tourCategory; }
            set { tourCategory = value; }
        }

        public string TourType
        {
            get { return tourType; }
            set { tourType = value; }
        }

        public string Report
        {
            get { return report; }
            set { report = value; }
        }

        public string LastDate
        {
            get { return lastDate; }
            set { lastDate = value; }
        }

        public string SurName
        {
            get { return surName; }
            set { surName = value; }
        }

        public string SGNO
        {
            get { return sGNO; }
            set { sGNO = value; }
        }

        public int SGID
        {
            get { return sGID; }
            set { sGID = value; }
        }

        public string SPlace
        {
            get { return sPlace; }
            set { sPlace = value; }
        }

        public string JourneyStatus
        {
            get { return journeyStatus; }
            set { journeyStatus = value; }
        }

        public string DriverName
        {
            get { return driverName; }
            set { driverName = value; }
        }

        public string DriverMobile
        {
            get { return driverMobile; }
            set { driverMobile = value; }
        }

        public string VS_FinalStatus
        {
            get { return vS_FinalStatus; }
            set { vS_FinalStatus = value; }
        }

        public int VS_FinalApproval
        {
            get { return vS_FinalApproval; }
            set { vS_FinalApproval = value; }
        }

        public string ARE_Status
        {
            get { return aRE_Status; }
            set { aRE_Status = value; }
        }

        public string VS_Status
        {
            get { return vS_Status; }
            set { vS_Status = value; }
        }

        public string HoC_Status
        {
            get { return hoC_Status; }
            set { hoC_Status = value; }
        }

        public int ARE_Approval
        {
            get { return aRE_Approval; }
            set { aRE_Approval = value; }
        }

        public int VS_Approval
        {
            get { return vS_Approval; }
            set { vS_Approval = value; }
        }

        public int HoC_Approval
        {
            get { return hoC_Approval; }
            set { hoC_Approval = value; }
        }
        public string HEmail
        {
            get { return hEmail; }
            set { hEmail = value; }
        }

        public string HDeptID
        {
            get { return hDeptID; }
            set { hDeptID = value; }
        }

        public string HDesign
        {
            get { return hDesign; }
            set { hDesign = value; }
        }

        public string HMobile
        {
            get { return hMobile; }
            set { hMobile = value; }
        }

        public string HName
        {
            get { return hName; }
            set { hName = value; }
        }

        public int HEmpID
        {
            get { return hEmpID; }
            set { hEmpID = value; }
        }

        public int UEmpID
        {
            get { return uEmpID; }
            set { uEmpID = value; }
        }

        public int TVIID
        {
            get { return tVIID; }
            set { tVIID = value; }
        }

        public double UMobile
        {
            get { return uMobile; }
            set { uMobile = value; }
        }

        public string UEmail
        {
            get { return uEmail; }
            set { uEmail = value; }
        }

        public string UDesign
        {
            get { return uDesign; }
            set { uDesign = value; }
        }

        public string ReturnTime
        {
            get { return returnTime; }
            set { returnTime = value; }
        }

        public string ReturnDate
        {
            get { return returnDate; }
            set { returnDate = value; }
        }

        public string TotHaltingTime
        {
            get { return totHaltingTime; }
            set { totHaltingTime = value; }
        }

        public string FlightDetails
        {
            get { return flightDetails; }
            set { flightDetails = value; }
        }

        public string TrainDetails
        {
            get { return trainDetails; }
            set { trainDetails = value; }
        }

        public string VisitTime
        {
            get { return visitTime; }
            set { visitTime = value; }
        }

        public string VisitDate
        {
            get { return visitDate; }
            set { visitDate = value; }
        }

        public string PlacetoVisit
        {
            get { return placetoVisit; }
            set { placetoVisit = value; }
        }

        public string PPAddress
        {
            get { return pPAddress; }
            set { pPAddress = value; }
        }

        public string PPTime
        {
            get { return pPTime; }
            set { pPTime = value; }
        }

        public string PPDate
        {
            get { return pPDate; }
            set { pPDate = value; }
        }

        public string ProgDept
        {
            get { return progDept; }
            set { progDept = value; }
        }

        public string ProgCoordinator
        {
            get { return progCoordinator; }
            set { progCoordinator = value; }
        }

        public string ProgTitle
        {
            get { return progTitle; }
            set { progTitle = value; }
        }

        public string ProgType
        {
            get { return progType; }
            set { progType = value; }
        }

        public string ProgCode
        {
            get { return progCode; }
            set { progCode = value; }
        }

        public int NoofPersons
        {
            get { return noofPersons; }
            set { noofPersons = value; }
        }

        public string JourneyDetails
        {
            get { return journeyDetails; }
            set { journeyDetails = value; }
        }

        public string PurposeofJourney
        {
            get { return purposeofJourney; }
            set { purposeofJourney = value; }
        }




        public double LoanAmount
        {
            get { return loanAmount; }
            set { loanAmount = value; }
        }

        public int BLID
        {
            get { return bLID; }
            set { bLID = value; }
        }

        public int LPID
        {
            get { return lPID; }
            set { lPID = value; }
        }

        public double LICPolicyAmount
        {
            get { return lICPolicyAmount; }
            set { lICPolicyAmount = value; }
        }

        public double LICPolicyNumber
        {
            get { return lICPolicyNumber; }
            set { lICPolicyNumber = value; }
        }

        public int PT_ID
        {
            get { return pT_ID; }
            set { pT_ID = value; }
        }

        public double MaxGSal
        {
            get { return maxGSal; }
            set { maxGSal = value; }
        }

        public double MinGSal
        {
            get { return minGSal; }
            set { minGSal = value; }
        }

        public string NetPayInWords
        {
            get { return netPayInWords; }
            set { netPayInWords = value; }
        }

        public double HC
        {
            get { return hC; }
            set { hC = value; }
        }

        public double CourtAt
        {
            get { return courtAt; }
            set { courtAt = value; }
        }

        public double BFAInt
        {
            get { return bFAInt; }
            set { bFAInt = value; }
        }

        public double BFA
        {
            get { return bFA; }
            set { bFA = value; }
        }

        public double Others
        {
            get { return others; }
            set { others = value; }
        }

        public double CompLInt
        {
            get { return compLInt; }
            set { compLInt = value; }
        }

        public double CompL
        {
            get { return compL; }
            set { compL = value; }
        }

        public double PLI
        {
            get { return pLI; }
            set { pLI = value; }
        }

        public double CDLNo
        {
            get { return cDLNo; }
            set { cDLNo = value; }
        }

        public double BankLoan
        {
            get { return bankLoan; }
            set { bankLoan = value; }
        }

        public double VAdvInt
        {
            get { return vAdvInt; }
            set { vAdvInt = value; }
        }

        public double VAdv
        {
            get { return vAdv; }
            set { vAdv = value; }
        }

        public double CabTV
        {
            get { return cabTV; }
            set { cabTV = value; }
        }

        public double TAdv
        {
            get { return tAdv; }
            set { tAdv = value; }
        }

        public double INTA
        {
            get { return iNTA; }
            set { iNTA = value; }
        }

        public double HBA_Adv_Int
        {
            get { return hBA_Adv_Int; }
            set { hBA_Adv_Int = value; }
        }

        public double HBA_Others
        {
            get { return hBA_Others; }
            set { hBA_Others = value; }
        }

        public double HBA_HDFC
        {
            get { return hBA_HDFC; }
            set { hBA_HDFC = value; }
        }

        public double HBA_NIRD
        {
            get { return hBA_NIRD; }
            set { hBA_NIRD = value; }
        }

        public double SC
        {
            get { return sC; }
            set { sC = value; }
        }

        public double PT
        {
            get { return pT; }
            set { pT = value; }
        }

        public double IT
        {
            get { return iT; }
            set { iT = value; }
        }

        public double GI
        {
            get { return gI; }
            set { gI = value; }
        }

        public double LIC
        {
            get { return lIC; }
            set { lIC = value; }
        }

        public double BF
        {
            get { return bF; }
            set { bF = value; }
        }

        public double WC
        {
            get { return wC; }
            set { wC = value; }
        }

        public double EC
        {
            get { return eC; }
            set { eC = value; }
        }

        public double QR
        {
            get { return qR; }
            set { qR = value; }
        }

        public double GC
        {
            get { return gC; }
            set { gC = value; }
        }

        public double SF
        {
            get { return sF; }
            set { sF = value; }
        }

        public string LopGrossPayinWords
        {
            get { return lopGrossPayinWords; }
            set { lopGrossPayinWords = value; }
        }

        public double MS
        {
            get { return mS; }
            set { mS = value; }
        }

        public double PFA
        {
            get { return pFA; }
            set { pFA = value; }
        }

        public double NPS
        {
            get { return nPS; }
            set { nPS = value; }
        }

        public double CPF
        {
            get { return cPF; }
            set { cPF = value; }
        }

        public double GPF
        {
            get { return gPF; }
            set { gPF = value; }
        }

        public double LOPTRA
        {
            get { return lOPTRA; }
            set { lOPTRA = value; }
        }

        public double LOPGrossPay
        {
            get { return lOPGrossPay; }
            set { lOPGrossPay = value; }
        }

        public double LOPHRA
        {
            get { return lOPHRA; }
            set { lOPHRA = value; }
        }

        public double LOPDA
        {
            get { return lOPDA; }
            set { lOPDA = value; }
        }

        public double LOPBasicPay
        {
            get { return lOPBasicPay; }
            set { lOPBasicPay = value; }
        }




        public double LOPGRP
        {
            get { return lOPGRP; }
            set { lOPGRP = value; }
        }

        public double LOPPPB
        {
            get { return lOPPPB; }
            set { lOPPPB = value; }
        }


        public int DaysInMonth
        {
            get { return daysInMonth; }
            set { daysInMonth = value; }
        }


        public DateTime ReleavedDate
        {
            get { return releavedDate; }
            set { releavedDate = value; }
        }

        public DateTime BookedDate
        {
            get { return bookedDate; }
            set { bookedDate = value; }
        }

        public string VBName
        {
            get { return vBName; }
            set { vBName = value; }
        }

        public int VBSNo
        {
            get { return vBSNo; }
            set { vBSNo = value; }
        }

        public string RoomNo
        {
            get { return roomNo; }
            set { roomNo = value; }
        }

        public int HRID
        {
            get { return hRID; }
            set { hRID = value; }
        }

        public string RoomType
        {
            get { return roomType; }
            set { roomType = value; }
        }

        public int RTID
        {
            get { return rTID; }
            set { rTID = value; }
        }

        public string HFloor
        {
            get { return hFloor; }
            set { hFloor = value; }
        }

        public int HFID
        {
            get { return hFID; }
            set { hFID = value; }
        }

        public string HType
        {
            get { return hType; }
            set { hType = value; }
        }

        public int GHID
        {
            get { return gHID; }
            set { gHID = value; }
        }

        public string NewPassword
        {
            get { return newPassword; }
            set { newPassword = value; }
        }

        public string FromDate
        {
            get { return fromDate; }
            set { fromDate = value; }
        }

        public string IsHOC
        {
            get { return isHOC; }
            set { isHOC = value; }
        }

        public string AQRCode
        {
            get { return aQRCode; }
            set { aQRCode = value; }
        }

        public string ApprvdIndentNo
        {
            get { return apprvdIndentNo; }
            set { apprvdIndentNo = value; }
        }

        public int TAEIID
        {
            get { return tAEIID; }
            set { tAEIID = value; }
        }

        public int EIID
        {
            get { return eIID; }
            set { eIID = value; }
        }

        public double APrice
        {
            get { return aPrice; }
            set { aPrice = value; }
        }

        public int STID
        {
            get { return sTID; }
            set { sTID = value; }
        }

        public string Remarks
        {
            get { return remarks; }
            set { remarks = value; }
        }

        public string RIndentNo
        {
            get { return rIndentNo; }
            set { rIndentNo = value; }
        }

        public int Flag4
        {
            get { return flag4; }
            set { flag4 = value; }
        }

        public int TEIID
        {
            get { return tEIID; }
            set { tEIID = value; }
        }

        public int Flag3
        {
            get { return flag3; }
            set { flag3 = value; }
        }

        public int Flag2
        {
            get { return flag2; }
            set { flag2 = value; }
        }

        public double IQuantity
        {
            get { return iQuantity; }
            set { iQuantity = value; }
        }

        public double AQuantity
        {
            get { return aQuantity; }
            set { aQuantity = value; }
        }

        public double RQuantity
        {
            get { return rQuantity; }
            set { rQuantity = value; }
        }

        public DateTime IssuedDate
        {
            get { return issuedDate; }
            set { issuedDate = value; }
        }

        public DateTime ReqDate
        {
            get { return reqDate; }
            set { reqDate = value; }
        }

        public string PTitle
        {
            get { return pTitle; }
            set { pTitle = value; }
        }

        public string PCode
        {
            get { return pCode; }
            set { pCode = value; }
        }

        public int SPID
        {
            get { return sPID; }
            set { sPID = value; }
        }

        public string IndentNo
        {
            get { return indentNo; }
            set { indentNo = value; }
        }

        public int ISNo
        {
            get { return iSNo; }
            set { iSNo = value; }
        }

        public string QRCode
        {
            get { return qRCode; }
            set { qRCode = value; }
        }

        public int VCID
        {
            get { return vCID; }
            set { vCID = value; }
        }

        public string ToDay
        {
            get { return toDay; }
            set { toDay = value; }
        }

        public int DVID
        {
            get { return dVID; }
            set { dVID = value; }
        }

        public string ContactPerson
        {
            get { return contactPerson; }
            set { contactPerson = value; }
        }

        public string VisitorType
        {
            get { return visitorType; }
            set { visitorType = value; }
        }

        public int VCardNo
        {
            get { return vCardNo; }
            set { vCardNo = value; }
        }

        public string BPhoto
        {
            get { return bPhoto; }
            set { bPhoto = value; }
        }

        public string CampusStay
        {
            get { return campusStay; }
            set { campusStay = value; }
        }

        public string Purpose
        {
            get { return purpose; }
            set { purpose = value; }
        }

        public string CPEmail
        {
            get { return cPEmail; }
            set { cPEmail = value; }
        }

        public double CPMobile
        {
            get { return cPMobile; }
            set { cPMobile = value; }
        }
        public string VisitBy
        {
            get { return visitBy; }
            set { visitBy = value; }
        }

        public int VisitID
        {
            get { return visitID; }
            set { visitID = value; }
        }

        public int VVID
        {
            get { return vVID; }
            set { vVID = value; }
        }

        public string BlockStatus
        {
            get { return blockStatus; }
            set { blockStatus = value; }
        }

        public int PCID
        {
            get { return pCID; }
            set { pCID = value; }
        }

        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string CircularType
        {
            get { return circularType; }
            set { circularType = value; }
        }

        public string EmpGroup
        {
            get { return empGroup; }
            set { empGroup = value; }
        }

        public int EGID
        {
            get { return eGID; }
            set { eGID = value; }
        }

        public string VehicleType
        {
            get { return vehicleType; }
            set { vehicleType = value; }
        }

        public int SeatCapacity
        {
            get { return seatCapacity; }
            set { seatCapacity = value; }
        }
        public string VehicleNumber
        {
            get { return vehicleNumber; }
            set { vehicleNumber = value; }
        }

        public string VehicleName
        {
            get { return vehicleName; }
            set { vehicleName = value; }
        }

        public string ModelType
        {
            get { return modelType; }
            set { modelType = value; }
        }

        public int VDID
        {
            get { return vDID; }
            set { vDID = value; }
        }

        public string LicenceValidDate
        {
            get { return licenceValidDate; }
            set { licenceValidDate = value; }
        }

        public string LicenceNo
        {
            get { return licenceNo; }
            set { licenceNo = value; }
        }

        public string DriverType
        {
            get { return driverType; }
            set { driverType = value; }
        }


        public string CitizenType
        {
            get { return citizenType; }
            set { citizenType = value; }
        }

        public string Udated
        {
            get { return udated; }
            set { udated = value; }
        }

        public string AmountPayable
        {
            get { return amountPayable; }
            set { amountPayable = value; }
        }

        public string SecondaryUnit
        {
            get { return secondaryUnit; }
            set { secondaryUnit = value; }
        }

        public string PrimaryUnit
        {
            get { return primaryUnit; }
            set { primaryUnit = value; }
        }

        public string ChequeDate
        {
            get { return chequeDate; }
            set { chequeDate = value; }
        }

        public string ChequeNo
        {
            get { return chequeNo; }
            set { chequeNo = value; }
        }

        public int Flag1
        {
            get { return flag1; }
            set { flag1 = value; }
        }

        public DateTime EDate
        {
            get { return eDate; }
            set { eDate = value; }
        }

        public DateTime FDOJ
        {
            get { return fDOJ; }
            set { fDOJ = value; }
        }

        public string VNetSalInWords
        {
            get { return vNetSalInWords; }
            set { vNetSalInWords = value; }
        }

        public double VNetSal
        {
            get { return vNetSal; }
            set { vNetSal = value; }
        }

        public string VoucherID
        {
            get { return voucherID; }
            set { voucherID = value; }
        }

        public int SNO
        {
            get { return sNO; }
            set { sNO = value; }
        }

        public string OffOrderIssuingAuthority
        {
            get { return offOrderIssuingAuthority; }
            set { offOrderIssuingAuthority = value; }
        }

        public DateTime OffOrderDate
        {
            get { return offOrderDate; }
            set { offOrderDate = value; }
        }

        public string OffOrderNo
        {
            get { return offOrderNo; }
            set { offOrderNo = value; }
        }

        public int EMSID
        {
            get { return eMSID; }
            set { eMSID = value; }
        }

        public string ProjectCode
        {
            get { return projectCode; }
            set { projectCode = value; }
        }

        public double LopAmount
        {
            get { return lopAmount; }
            set { lopAmount = value; }
        }

        public double LopDays
        {
            get { return lopDays; }
            set { lopDays = value; }
        }

        public int TotDays
        {
            get { return totDays; }
            set { totDays = value; }
        }

        public double NetPay
        {
            get { return netPay; }
            set { netPay = value; }
        }

        public double TotDeductions
        {
            get { return totDeductions; }
            set { totDeductions = value; }
        }

        public double OtherDeductions
        {
            get { return otherDeductions; }
            set { otherDeductions = value; }
        }

        public double TARecovery
        {
            get { return tARecovery; }
            set { tARecovery = value; }
        }

        public double ElectricityCharges
        {
            get { return electricityCharges; }
            set { electricityCharges = value; }
        }

        public double GarageCharges
        {
            get { return garageCharges; }
            set { garageCharges = value; }
        }

        public double GarbageCharges
        {
            get { return garbageCharges; }
            set { garbageCharges = value; }
        }

        public double WaterCharges
        {
            get { return waterCharges; }
            set { waterCharges = value; }
        }

        public double LicenceFee
        {
            get { return licenceFee; }
            set { licenceFee = value; }
        }

        public double IncomeTax
        {
            get { return incomeTax; }
            set { incomeTax = value; }
        }

        public double ProfTax
        {
            get { return profTax; }
            set { profTax = value; }
        }

        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        public string Month
        {
            get { return month; }
            set { month = value; }
        }

        public string QuarterType
        {
            get { return quarterType; }
            set { quarterType = value; }
        }

        public int PSTID
        {
            get { return pSTID; }
            set { pSTID = value; }
        }

        public int PID
        {
            get { return pID; }
            set { pID = value; }
        }

        public string CentreHead
        {
            get { return centreHead; }
            set { centreHead = value; }
        }

        public string ProjectCoordinator
        {
            get { return projectCoordinator; }
            set { projectCoordinator = value; }
        }

        public string ProjectDuration
        {
            get { return projectDuration; }
            set { projectDuration = value; }
        }

        public string ProjectTitle
        {
            get { return projectTitle; }
            set { projectTitle = value; }
        }

        public string GrossSalWords
        {
            get { return grossSalWords; }
            set { grossSalWords = value; }
        }

        public string StaffBus
        {
            get { return staffBus; }
            set { staffBus = value; }
        }

        public double Arrears
        {
            get { return arrears; }
            set { arrears = value; }
        }

        public double OtherAllow
        {
            get { return otherAllow; }
            set { otherAllow = value; }
        }

        public double SumptuaryAllow
        {
            get { return sumptuaryAllow; }
            set { sumptuaryAllow = value; }
        }

        public string DPAType
        {
            get { return dPAType; }
            set { dPAType = value; }
        }

        public double WashingAllow
        {
            get { return washingAllow; }
            set { washingAllow = value; }
        }

        public double BookAllow
        {
            get { return bookAllow; }
            set { bookAllow = value; }
        }

        public double PatientCareAllow
        {
            get { return patientCareAllow; }
            set { patientCareAllow = value; }
        }

        public double SpecialDutyAllow
        {
            get { return specialDutyAllow; }
            set { specialDutyAllow = value; }
        }

        public string RentFreeAccom
        {
            get { return rentFreeAccom; }
            set { rentFreeAccom = value; }
        }

        public string QuarterAllotted
        {
            get { return quarterAllotted; }
            set { quarterAllotted = value; }
        }

        public string PHCStatus
        {
            get { return pHCStatus; }
            set { pHCStatus = value; }
        }

        public string PFAccNo
        {
            get { return pFAccNo; }
            set { pFAccNo = value; }
        }

        public string PFAccType
        {
            get { return pFAccType; }
            set { pFAccType = value; }
        }

        public string NPAEligible
        {
            get { return nPAEligible; }
            set { nPAEligible = value; }
        }

        public double TRGA
        {
            get { return tRGA; }
            set { tRGA = value; }
        }

        public string TRGEligible
        {
            get { return tRGEligible; }
            set { tRGEligible = value; }
        }

        public string TRAEligible
        {
            get { return tRAEligible; }
            set { tRAEligible = value; }
        }

        public string PayLevel
        {
            get { return payLevel; }
            set { payLevel = value; }
        }

        public double BasicPay
        {
            get { return basicPay; }
            set { basicPay = value; }
        }

        public DateTime DOR
        {
            get { return dOR; }
            set { dOR = value; }
        }

        public double MinGradePay
        {
            get { return minGradePay; }
            set { minGradePay = value; }
        }

        public double MinBasicPay
        {
            get { return minBasicPay; }
            set { minBasicPay = value; }
        }

        public double TRA
        {
            get { return tRA; }
            set { tRA = value; }
        }

        public int TRAID
        {
            get { return tRAID; }
            set { tRAID = value; }
        }

        public string IFSCCode
        {
            get { return iFSCCode; }
            set { iFSCCode = value; }
        }

        public string BankBranchName
        {
            get { return bankBranchName; }
            set { bankBranchName = value; }
        }

        public string BankName
        {
            get { return bankName; }
            set { bankName = value; }
        }

        public string BankAcType
        {
            get { return bankAcType; }
            set { bankAcType = value; }
        }

        public string State
        {
            get { return state; }
            set { state = value; }
        }

        public string Aadhar
        {
            get { return aadhar; }
            set { aadhar = value; }
        }

        public int EID
        {
            get { return eID; }
            set { eID = value; }
        }

        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        public DateTime DOJ
        {
            get { return dOJ; }
            set { dOJ = value; }
        }

        public DateTime DOB
        {
            get { return dOB; }
            set { dOB = value; }
        }

        public string FathersName
        {
            get { return fathersName; }
            set { fathersName = value; }
        }

        public string BankAccNo
        {
            get { return bankAccNo; }
            set { bankAccNo = value; }
        }

        public double EmpID
        {
            get { return empID; }
            set { empID = value; }
        }

        public string FileNo
        {
            get { return fileNo; }
            set { fileNo = value; }
        }

        public string PONo
        {
            get { return pONo; }
            set { pONo = value; }
        }

        public int TSID
        {
            get { return tSID; }
            set { tSID = value; }
        }

        public double MinQty
        {
            get { return minQty; }
            set { minQty = value; }
        }

        public double UnitCost
        {
            get { return unitCost; }
            set { unitCost = value; }
        }

        public double Rate
        {
            get { return rate; }
            set { rate = value; }
        }

        public double Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public string BatchNo
        {
            get { return batchNo; }
            set { batchNo = value; }
        }

        public DateTime PurchaseDate
        {
            get { return purchaseDate; }
            set { purchaseDate = value; }
        }

        public string ItemType
        {
            get { return itemType; }
            set { itemType = value; }
        }

        public string InvoiceDate
        {
            get { return invoiceDate; }
            set { invoiceDate = value; }
        }

        public string InvoiceNo
        {
            get { return invoiceNo; }
            set { invoiceNo = value; }
        }

        public string Manufacturer
        {
            get { return manufacturer; }
            set { manufacturer = value; }
        }

        public int IMID
        {
            get { return iMID; }
            set { iMID = value; }
        }

        public string ItemName
        {
            get { return itemName; }
            set { itemName = value; }
        }

        public int ITID
        {
            get { return iTID; }
            set { iTID = value; }
        }

        public int SUID
        {
            get { return sUID; }
            set { sUID = value; }
        }

        public string ItemCategory
        {
            get { return itemCategory; }
            set { itemCategory = value; }
        }

        public int ICID
        {
            get { return iCID; }
            set { iCID = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public double Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        public string DLNo
        {
            get { return dLNo; }
            set { dLNo = value; }
        }

        public string TIN
        {
            get { return tIN; }
            set { tIN = value; }
        }

        public int VID
        {
            get { return vID; }
            set { vID = value; }
        }

        public string Vendor
        {
            get { return vendor; }
            set { vendor = value; }
        }

        public int FYID
        {
            get { return fYID; }
            set { fYID = value; }
        }

        public DateTime EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }

        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }

        public string FinancialYear
        {
            get { return financialYear; }
            set { financialYear = value; }
        }

        public double GrossSal
        {
            get { return grossSal; }
            set { grossSal = value; }
        }

        public double SA
        {
            get { return sA; }
            set { sA = value; }
        }

        public double BA
        {
            get { return bA; }
            set { bA = value; }
        }

        public double SDA
        {
            get { return sDA; }
            set { sDA = value; }
        }

        public double OTPay
        {
            get { return oTPay; }
            set { oTPay = value; }
        }

        public double WA
        {
            get { return wA; }
            set { wA = value; }
        }

        public double SFN
        {
            get { return sFN; }
            set { sFN = value; }
        }

        public double PCA
        {
            get { return pCA; }
            set { pCA = value; }
        }

        public double DPA
        {
            get { return dPA; }
            set { dPA = value; }
        }

        public double TA
        {
            get { return tA; }
            set { tA = value; }
        }

        public double PPB
        {
            get { return pPB; }
            set { pPB = value; }
        }

        public double GradePay
        {
            get { return gradePay; }
            set { gradePay = value; }
        }

        public string PAN
        {
            get { return pAN; }
            set { pAN = value; }
        }

        public double AccNo
        {
            get { return accNo; }
            set { accNo = value; }
        }

        public double NPA
        {
            get { return nPA; }
            set { nPA = value; }
        }

        public int NPAID
        {
            get { return nPAID; }
            set { nPAID = value; }
        }

        public double HRA
        {
            get { return hRA; }
            set { hRA = value; }
        }

        public int HRAID
        {
            get { return hRAID; }
            set { hRAID = value; }
        }

        public DateTime Dated
        {
            get { return dated; }
            set { dated = value; }
        }

        public string UName
        {
            get { return uName; }
            set { uName = value; }
        }

        public double DA
        {
            get { return dA; }
            set { dA = value; }
        }

        public int DAID
        {
            get { return dAID; }
            set { dAID = value; }
        }

        public string DeptID
        {
            get { return deptID; }
            set { deptID = value; }
        }

        public string Department
        {
            get { return department; }
            set { department = value; }
        }

        public int DID
        {
            get { return dID; }
            set { dID = value; }
        }

        public int DSID
        {
            get { return dSID; }
            set { dSID = value; }
        }

        public string Design
        {
            get { return design; }
            set { design = value; }
        }

        public string EmpCategory
        {
            get { return empCategory; }
            set { empCategory = value; }
        }

        public int ECID
        {
            get { return eCID; }
            set { eCID = value; }
        }

        public int ETID
        {
            get { return eTID; }
            set { eTID = value; }
        }

        public string EmpType
        {
            get { return empType; }
            set { empType = value; }
        }

        public int PSID
        {
            get { return pSID; }
            set { pSID = value; }
        }

        public string Payscale
        {
            get { return payscale; }
            set { payscale = value; }
        }

        public string OrgName
        {
            get { return orgName; }
            set { orgName = value; }
        }

        public int OID
        {
            get { return oID; }
            set { oID = value; }
        }

        public int Role
        {
            get { return role; }
            set { role = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        public DateTime Now
        {
            get { return now; }
            set { now = value; }
        }

        public string Photo
        {
            get { return photo; }
            set { photo = value; }
        }

        public double Mobile
        {
            get { return mobile; }
            set { mobile = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        public string ColumnName
        {
            get { return columnName; }
            set { columnName = value; }
        }

        public int UID
        {
            get { return uID; }
            set { uID = value; }
        }

        public string InTime { get { return inTime; } set { inTime = value; } }
        public string OutTime { get { return outTime; } set { outTime = value; } }
        public int Flag5 { get { return flag5; } set { flag5 = value; } }
        public string SLPrefixDates { get { return sLPrefixDates; } set { sLPrefixDates = value; } }
        public string SLSufixDates { get { return sLSufixDates; } set { sLSufixDates = value; } }
        public string CLPrefixDates { get { return cLPrefixDates; } set { cLPrefixDates = value; } }
        public string CLSufixDates { get { return cLSufixDates; } set { cLSufixDates = value; } }
        public string CCMail { get { return cCMail; } set { cCMail = value; } }
        public string CurrentLeaveStatus { get { return currentLeaveStatus; } set { currentLeaveStatus = value; } }
        public string LDecision { get { return lDecision; } set { lDecision = value; } }
        public int LSO { get { return lSO; } set { lSO = value; } }
        public int LDA { get { return lDA; } set { lDA = value; } }
        public int LCancel { get { return lCancel; } set { lCancel = value; } }
        public int LPullBack { get { return lPullBack; } set { lPullBack = value; } }
        public int Approval { get { return approval; } set { approval = value; } }

        public string AttendanceID { get { return attendanceID; } set { attendanceID = value; } }
    }
    public class PRResp
    {
        private int count;
        private string singleValue;
        private DataTable getTable;

        public DataTable GetTable
        {
            get { return getTable; }
            set { getTable = value; }
        }

        public string SingleValue
        {
            get { return singleValue; }
            set { singleValue = value; }
        }

        public int Count
        {
            get { return count; }
            set { count = value; }
        }
    }
}
