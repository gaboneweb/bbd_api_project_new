
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UkukhulaAPI.Data;


// ...

[ApiController]
[Route("[controller]")]
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