
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UkukhulaAPI.Data;


// ...

[ApiController]
[Route("[controller]")]
public class ContactController : ControllerBase
{
    private readonly UkukhulaContext _ukukhulaContext;

    public ContactController(UkukhulaContext ukukhulaContext)
    {
        _ukukhulaContext = ukukhulaContext;
    }

    [HttpGet]
    public IActionResult GetUContacts()
    {
     
        var contacts = _ukukhulaContext.Contacts.ToList();

        return Ok(contacts);
    }
}