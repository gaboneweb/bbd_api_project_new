namespace UkukhulaAPI.Data.Models.View;
public class UserConstants
    {
        public static List<LoginVm> Users = new()
            {
                    new LoginVm(){ Username="naeem",Password="naeem_admin",Role="Admin"}
            };
    }