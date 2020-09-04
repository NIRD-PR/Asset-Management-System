using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

public class ServiceHostory
{
    private string servicetype;    
    private string dateofissue;
    private string startdate;
    private string enddate;
    private string newdesignation;
    private string previousdesignation;
    private string newsalary;
    private string previoussalary;
    private string Remarks;
    private string officeorder;
    private string EMPId;
   

    [Required]
    public string ServiceType
    {
        get { return servicetype; }
        set { servicetype = value; }
    }
    [Required]
    public string StartDate
    {
        get { return startdate; }
        set { startdate = value; }
    }
    [Required]
    public string DateofIssue
    {
        get { return dateofissue; }
        set { dateofissue = value; }
    }
    [Required]
    public string EndDate
    {
        get { return enddate; }
        set { enddate = value; }
    }
    [Required]
    public string NewDesignation
    {
        get { return newdesignation; }
        set { newdesignation = value; }
    }
    [Required]
    public string PreviousDesignation
    {
        get { return previousdesignation; }
        set { previousdesignation = value; }
    }
    [Required]
    public string NewSalary
    {
        get { return newsalary; }
        set { newsalary = value; }
    }
    [Required]
    public string PreviousSalary
    {
        get { return previoussalary; }
        set { previoussalary = value; }
    }    
    [Required]
    public string OfficeOrder
    {
        get { return officeorder; }
        set { officeorder = value; }
    }
    public string remarks
    {
        get { return Remarks; }
        set { Remarks = value; }
    }
    //[Required]
    public string EMPID
    {
        get { return EMPId; }
        set { EMPId = value; }
    }
}


