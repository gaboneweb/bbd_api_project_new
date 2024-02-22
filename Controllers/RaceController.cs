
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UkukhulaAPI.Data;


[Authorize(Roles ="Admin")]
[ApiController]
[Route("api/[controller]")]
public class RaceController : ControllerBase
{
    private readonly UkukhulaContext _ukukhulaContext;

    public RaceController(UkukhulaContext ukukhulaContext)
    {
        _ukukhulaContext = ukukhulaContext;
    }

    [HttpGet]
    public IActionResult GetUContacts()
    {
     
        var races = _ukukhulaContext.Races.ToList();

        return Ok(races);
    }
}