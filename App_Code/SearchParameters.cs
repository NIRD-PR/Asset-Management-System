using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

public class SearchParameters
{
    private string EmpGroup;    
    private string Centre;
    private string Design;
    private string SalRngFrom;
    private string SalRngTo;
    private string TenureRngFrom;
    private string TenureRngTo;
    private string HikeRngFrom;
    private string HikeRngTo;
    private string OrderType;
    private string OrderDtRngFrom;
    private string OrderDtRngTo;
    private string PromotedTo;
    private string Mobile;
    private string Internet;
    private string Transport;
    private string Insurance;
    private string Medical;
    private string Other;

    [Required]
    public string empGroup
    {
        get { return EmpGroup; }
        set { EmpGroup = value; }
    }

    public string centre
    {
        get { return Centre; }
        set { Centre = value; }
    }

    public string design
    {
        get { return Design; }
        set { Design = value; }
    }
    
    public string salRngFrom
    {
        get { return SalRngFrom; }
        set { SalRngFrom = value; }
    }
    
    public string salRngTo
    {
        get { return SalRngTo; }
        set { SalRngTo = value; }
    }
    
    public string tenureRngFrom
    {
        get { return TenureRngFrom; }
        set { TenureRngFrom = value; }
    }
    
    public string tenureRngTo
    {
        get { return TenureRngTo; }
        set { TenureRngTo = value; }
    }
    
    public string hikeRngFrom
    {
        get { return HikeRngFrom; }
        set { HikeRngFrom = value; }
    }    
    
    public string hikeRngTo
    {
        get { return HikeRngTo; }
        set { HikeRngTo = value; }
    }
    public string orderType
    {
        get { return OrderType; }
        set { OrderType = value; }
    }
    
    public string orderDtRngFrom
    {
        get { return OrderDtRngFrom; }
        set { OrderDtRngFrom = value; }
    }
    public string orderDtRngTo
    {
        get { return OrderDtRngTo; }
        set { OrderDtRngTo = value; }
    }

    public string promotedTo
    {
        get { return PromotedTo; }
        set { PromotedTo = value; }
    }
    public string mobile
    {
        get { return Mobile; }
        set { Mobile = value; }
    }
    public string internet
    {
        get { return Internet; }
        set { Internet = value; }
    }
    public string transport
    {
        get { return Transport; }
        set { Transport = value; }
    }
    public string insurance
    {
        get { return Insurance; }
        set { Insurance = value; }
    }
    public string medical
    {
        get { return Medical; }
        set { Medical = value; }
    }
    public string other
    {
        get { return Other; }
        set { Other = value; }
    }
}


