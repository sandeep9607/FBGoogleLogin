namespace FBGoggleLogin.Controllers
{


    using System.Collections.Generic;
    using System.Security.Claims;

    public class ProfileViewModel
    {
        public string Name { get; set; }
        public IEnumerable<Claim> Claims { get; set; }
    }

    public class AuthenticationResult
    {
        public string LoginProvider { get; set; }
        public string UserId { get; set; }
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string GoogleProfile { get; set; }
    }
}
