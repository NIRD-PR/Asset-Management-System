using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

public class Education
{
    private string qualification;
    private string nameofexampassed;
    private string universityorbord;
    private string yearofpassing;
    private string classGradeDiv;
    private string marksPercentage;
    private string posRank;
    private string subOffered;
    private string Remarks;
    private string certificate;
    private string EMPId;
   // private string id;

    [Required]
    public string Qualification
    {
        get { return qualification; }
        set { qualification = value; }
    }
    [Required]
    public string Nameofexampassed
    {
        get { return nameofexampassed; }
        set { nameofexampassed = value; }
    }
    [Required]
    public string Universityorbord
    {
        get { return universityorbord; }
        set { universityorbord = value; }
    }
    [Required]
    public string Yearofpassing
    {
        get { return yearofpassing; }
        set { yearofpassing = value; }
    }
    [Required]
    public string ClassGradeDiv
    {
        get { return classGradeDiv; }
        set { classGradeDiv = value; }
    }
    [Required]
    public string MarksPercentage
    {
        get { return marksPercentage; }
        set { marksPercentage = value; }
    }

    public string PosRank
    {
        get { return posRank; }
        set { posRank = value; }
    }
    [Required]
    public string SubOffered
    {
        get { return subOffered; }
        set { subOffered = value; }
    }    
    [Required]
    public string Certificate
    {
        get { return certificate; }
        set { certificate = value; }
    }
    public string remarks
    {
        get { return Remarks; }
        set { Remarks = value; }
    }
   // [Required]
    public string EMPID
    {
        get { return EMPId; }
        set { EMPId = value; }
    }
    
    
}


