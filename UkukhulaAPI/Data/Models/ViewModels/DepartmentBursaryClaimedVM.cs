using System;
using System.ComponentModel.DataAnnotations;


namespace UkukhulaAPI.Data.Models.View;

public class DepartmentBursaryClaimedVM
{

    public string DepartmentName { get; set; }
    public decimal BursaryClaimed { get; set; }


}