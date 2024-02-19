
using Microsoft.AspNetCore.Mvc;
using UkukhulaAPI.Data;
using UkukhulaAPI.Data.Models;
using UkukhulaAPI.Data.Models.ViewModels;
using UkukhulaAPI.Data.Services;

namespace UkukhulaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Bbdadministrator: ControllerBase
    {
        BbdadministratorService _service;
        public Bbdadministrator(BbdadministratorService service){
            _service = service;
        }
        [HttpPost]
        [Route("bbd-admin/fund")]
        public IActionResult allocateFunding(vFunding fund)
        {
            if(_service.AllocateFunding(fund))
            {
                return Ok("Funding Succesful");
            }
            else
            {
                return BadRequest("allocation failed");
            }
            

            // return Ok (_ukukhulaContext.Bbdadministrators.ToArray());
        }

        [HttpGet]
        [Route("bbd-admin/view-universities-all-time")]

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
        }
    }
}