using System;
using UkukhulaAPI.Data.Models;
using UkukhulaAPI.Data.Models.View;

namespace UkukhulaAPI.Data.Services;

public class UsersService
{
    private UkukhulaContext _context;
    public UsersService(UkukhulaContext context)
    {
        _context = context;
    }

    public void AddUser(UserVm user)
    {
        

    }
}