
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UkukhulaAPI.Data;


// ...

[ApiController]
[Route("api/[controller]")]
public class DepartmentController : ControllerBase
{
    private readonly UkukhulaContext _ukukhulaContext;

    public DepartmentController(UkukhulaContext ukukhulaContext)
    {
        _ukukhulaContext = ukukhulaContext;
    }

    [HttpGet]
    public IActionResult GetUContacts()
    {
     
        var departments = _ukukhulaContext.Departments.ToList();

        return Ok(departments);
    }
}