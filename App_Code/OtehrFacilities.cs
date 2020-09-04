using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

public class OtherFacilities
{
    private bool availingFacs;
    private string servicetype;
    private string duration;
    private string facility;
    private string fromdate;
    private string allowance;
    private string ifOther;
    private string durationid;
    private string EMPId;

    [Required]
    public bool AvailingFacs
    {
        get { return availingFacs; }
        set { availingFacs = value; }
    }
    [Required]
    public string ServiceType
    {
        get { return servicetype; }
        set { servicetype = value; }
    }
    [Required]
    public string Duration
    {
        get { return duration; }
        set { duration = value; }
    }
    [Required]
    public string Facility
    {
        get { return facility; }
        set { facility = value; }
    }
    [Required]
    public string FromDate
    {
        get { return fromdate; }
        set { fromdate = value; }
    }
    [Required]
    public string Allowance
    {
        get { return allowance; }
        set { allowance = value; }
    }
    [Required]
    public string DurationId
    {
        get { return durationid; }
        set { durationid = value; }
    }

    public string IfOther
    {
        get { return ifOther; }
        set { ifOther = value; }
    }
   // [Required]
    public string EMPID
    {
        get { return EMPId; }
        set { EMPId = value; }
    }
    
}

