using UkukhulaAPI.Data.Models;
using UkukhulaAPI.Data.Models.ViewModels;
using UkukhulaAPI.Data.Models.View;
using System;
using System.Collections.Generic;

namespace UkukhulaAPI.Data.Services.Read
{
    public class GetContactService
    {
        private UkukhulaContext  _context;

        public GetContactService(UkukhulaContext context)
        {
            _context = context;
        }

        public string GetContactNumberByContactId(int contactId)
        {
            try
            {
                var contact = _context.Contacts.FirstOrDefault(n => n.ContactId == contactId);
                return contact.ContactNumber;
            } 
            catch (Exception ex)
            {
                return "";
            }
        }

        public string GetEmailByContactId(int contactId)
        {
            try
            {
                var contact = _context.Contacts.FirstOrDefault(n => n.ContactId == contactId);
                return contact.Email;
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public List<Contact> GetAllContacts()
        {

            return _context.Contacts.ToList();

        }

    }
}
