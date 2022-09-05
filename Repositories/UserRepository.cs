using APITESTE.Models;

namespace APITESTE.Repositories{
    public static class UserRepository{
        public static User Get(string username, string email){
            var users = new List<User>{
                new User{Id = 1, Username = "batman", Email = "teste@gmail.com"}
            };
            return users.FirstOrDefault(x=>
            x.Username== username 
            && x.Email==email);
        }
    }
}