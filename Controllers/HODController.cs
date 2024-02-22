
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UkukhulaAPI.Data;


// ...

[Authorize(Roles ="Admin")]
[ApiController]
[Route("api/[controller]")]
public class HODController : ControllerBase
{
    private readonly UkukhulaContext _ukukhulaContext;

    public HODController(UkukhulaContext ukukhulaContext)
    {
        _ukukhulaContext = ukukhulaContext;
    }
    
    [HttpGet]
    public IActionResult GetUContacts()
    {
     
        var headOfDepartments = _ukukhulaContext.HeadOfDepartments.ToList();

        return Ok(headOfDepartments);
    }
}