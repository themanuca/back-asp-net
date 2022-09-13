using APITESTE.Models;

namespace APITESTE.Repositories{
    public static class UserRepository{
        public static User Get(string username, string email, string roles){
            var users = new List<User>{
                new User{Id = 1, Username = "batman", Email = "teste@gmail.com", Roles="admin"}
            };
            return users.FirstOrDefault(x=>
            x.Username== username && x.Roles==roles
            && x.Email==email);
        }
    }
}