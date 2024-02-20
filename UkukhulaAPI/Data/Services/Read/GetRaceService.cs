using UkukhulaAPI.Data.Models;
using UkukhulaAPI.Data.Models.ViewModels;
using UkukhulaAPI.Data.Models.View;
using System.Collections.Generic;

namespace UkukhulaAPI.Data.Services.Read
{
    public class GetRaceService
    {
        private UkukhulaContext  _context;

        public GetRaceService(UkukhulaContext context)
        {
            _context = context;
        }



        public int GetRaceIdByRaceName(string raceName)
        {
            try
            {
                var race = _context.Race.FirstOrDefault(n => n.RaceName == raceName);
                return race.RaceId;
            } 
            catch (Exception ex)
            {
                return 0;
            }
        }

        public string GetRaceNameByRaceId(int raceId)
        {
            try
            {
                var race = _context.Race.FirstOrDefault(n => n.RaceId == raceId);
                return race.RaceName;
            } 
            catch (Exception ex)
            {
                return "";
            }
}

        public List<Race> GetAllRaces()
        {

            return _context.Race.ToList();

        }
    }
}
