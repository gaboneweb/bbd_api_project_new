
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UkukhulaAPI.Data;
using UkukhulaAPI.Data.Models;
using UkukhulaAPI.Data.Models.ViewModels;
using UkukhulaAPI.Data.Services;

namespace UkukhulaAPI.Controllers
{
    [Authorize(Roles ="Admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class Bbdadministrator: ControllerBase
    {
        BbdadministratorService _service;
        public Bbdadministrator(BbdadministratorService service){
            _service = service;
        }
        [HttpPost]
        [Route("addAdmin")]
        public IActionResult addNewAdmin(BbdadministratorVm bbdadministratorVm){
            if(_service.addBBDAdmin(bbdadministratorVm)){
                return Ok("Admin "+ bbdadministratorVm.FirstName + ' '+ bbdadministratorVm.LastName + " has been added");
            }else{
                return BadRequest("Failed to add Admin");
            }
        }
        [HttpPost]
        [Route("fund")]
        public IActionResult allocateFunding(vFunding fund)
        {
            Dictionary<bool,string> dict =_service.AllocateFunding(fund);
            if(dict.ContainsKey(true))
            {
                return Ok(dict[true]);
            }
            else
            {
                return BadRequest(dict[false]);
            }
            

            // return Ok (_ukukhulaContext.Bbdadministrators.ToArray());
        }

        [HttpGet]
        [Route("view-universities-all-time")]

        public IActionResult getAllAllocated(){
            Dictionary<String,decimal> universitiesByAllocatedAmount =[];
                

                foreach(University university in _service.getAllUniversities()){
                    for(int year=2022;year<2032;year++){
                        if( universitiesByAllocatedAmount.ContainsKey(university.UniversityName)){
                            universitiesByAllocatedAmount[university.UniversityName] += _service.GetMoneySpentForAUniversity(university.UniversityId,year);
                        }
                        else{
                            universitiesByAllocatedAmount[university.UniversityName] = _service.GetMoneySpentForAUniversity(university.UniversityId,year);
                        }

                    }
                }
            

            return Ok(universitiesByAllocatedAmount);
        } [HttpGet]
        [Route("view-universities-by-year/{Year}")]

        public IActionResult getAllAllocatedByYear(int Year)
        {
            Dictionary<String,decimal> universitiesByAllocatedAmount =[];
                

                foreach(University university in _service.getAllUniversities()){
                        if( universitiesByAllocatedAmount.ContainsKey(university.UniversityName)){
                            universitiesByAllocatedAmount[university.UniversityName] += _service.GetMoneySpentForAUniversity(university.UniversityId,Year);
                        }
                        else{
                            universitiesByAllocatedAmount[university.UniversityName] = _service.GetMoneySpentForAUniversity(university.UniversityId,Year);
                        }

                    
                }
            

            return Ok(universitiesByAllocatedAmount);
        }
    }
}