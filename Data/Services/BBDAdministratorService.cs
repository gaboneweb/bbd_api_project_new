

using System.Data.SqlTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using UkukhulaAPI.Data.Models;
using UkukhulaAPI.Data.Models.ViewModels;

namespace UkukhulaAPI.Data.Services
{

    public class BbdadministratorService
    {

        private UkukhulaContext _context;
        public BbdadministratorService(UkukhulaContext context)
        {
            _context = context;
        }
        public bool addBBDAdmin([FromBody]BbdadministratorVm bbdadministratorVm)
        {
            try{
                var contactInfo = new Contact()
            {
                Email= bbdadministratorVm.contact.Email,
                ContactNumber = bbdadministratorVm.contact.ContactNumber
            };
             _context.Add(contactInfo);
            _context.SaveChanges();
            int contactID = contactInfo.ContactId;
            var applicantInfo = new User()
                    {
                        FirstName = bbdadministratorVm.FirstName,
                        LastName = bbdadministratorVm.LastName,
                        Idnumber = bbdadministratorVm.Idnumber,
                        ContactId = contactID
                    };
                    _context.Add(applicantInfo);
                    _context.SaveChanges();
            var bbdAdmin = new Bbdadministrator()
            {
                UserId= applicantInfo.UserId,
                User = applicantInfo 
            };
            _context.Add(bbdAdmin);
             _context.SaveChanges();
            } catch(Exception){
                return false;
            }
            return true;
            


        }
        public Dictionary <bool,string > AllocateFunding([FromBody] vFunding funding)
        {
             Dictionary <bool,string > dict=[];
            var _user = _context.Users.FirstOrDefault(e => e.Idnumber == funding.Idnumber);
            if (_user == null)
            {
                dict[false]= "Not a valid admin";
                return dict;
            }

            var _admin = _context.Bbdadministrators.FirstOrDefault(e => e.UserId == _user.UserId);
            if (_admin == null)
            {
                dict[false]= "Not a valid admin";
                return dict;
            }

           


            var _newBudget = _context.YearlyBursaryDetails.FirstOrDefault(e => e.BursaryDetailsId == DateTime.Now.Year);

            if (_newBudget == null)
            {
                var yearBudget = new YearlyBursaryDetail()
                {
                    CapAmountPerStudent = funding.CapAmountPerStudent,
                    YearBudget = funding.YearBudget
                };
                _context.Add(yearBudget);
                _context.SaveChanges();
                _newBudget = _context.YearlyBursaryDetails.FirstOrDefault(e => e.BursaryDetailsId == DateTime.Now.Year);
            }
            // Retrieve the funded universities
            var fundedUniversities = _context.UniversityApplications
                   .Include(u => u.University)
                   .ThenInclude(e => e.YearlyUniversityAllocations)
                   .ThenInclude(r => r.BursaryDetails)
                   .Where(e => e.Status.StatusId == 2)
                   .ToList();
            int count = fundedUniversities.Count();
            if (count == 0)
            {
                // No universities are eligible for funding
                dict[false]= "No universities are eligible for funding";
                return dict;
            }
            if (amountLeftForYear(_newBudget.BursaryDetailsId)<=0){
                dict[false]= "No funds left to distribute this year";
                return dict;
            }

            // Calculate the amount per institution
            decimal amountPerInstitution = funding.YearBudget / count;

            foreach (var universityApplication in fundedUniversities)
            {
                // Add a new YearlyUniversityAllocation entry for each funded university
                universityApplication.University.YearlyUniversityAllocations.Add(new YearlyUniversityAllocation()
                {
                    AllocatedAmount = amountPerInstitution,
                    BursaryDetailsId = _newBudget.BursaryDetailsId
                });
            }

            // Save changes to persist the allocations
            _context.SaveChanges();
            dict[true]= "Funding distributed equally amongts funded institutions";
                return dict;
        }
        public List<University> getAllUniversities(){
            List<University> universities = _context.Universities.ToList();
            return universities;
        }

        public decimal amountLeftForYear(int year)
        {

            List<YearlyUniversityAllocation> universityAllocations = _context.YearlyUniversityAllocations.ToList();
            decimal yearlySpent =0;
            foreach(YearlyUniversityAllocation yearlyUniversityAllocation in universityAllocations){
                
                if(yearlyUniversityAllocation.BursaryDetailsId == year){
                    yearlySpent+= yearlyUniversityAllocation.AllocatedAmount;
                };
                
            }
            decimal budget =0;
            List<YearlyBursaryDetail> yearlyBursaryDetails = _context.YearlyBursaryDetails.ToList();
            foreach( YearlyBursaryDetail yearlyBursaryDetail in yearlyBursaryDetails)
            {
                if( yearlyBursaryDetail.BursaryDetailsId ==year){
                   budget=  yearlyBursaryDetail.YearBudget;
                }
            }
            return budget- yearlySpent;
        }
        public decimal GetMoneySpentForAUniversity(int univeristyId,int year)
        {
            ApplicationService service = new ApplicationService(_context);

            List<StudentBursaryApplication> applications = service.GetApplicationForUniversityInYear(univeristyId, year, "Accepted");

            decimal sum = 0;

            foreach(var  application in applications) {
                sum += application.BursaryAmount;
            }


            return sum;
            
        }

    }

    
}