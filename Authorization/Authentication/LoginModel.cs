namespace Authorization.Authentication
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class LoginModel
    {
        [Required(ErrorMessage = "User Required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password Required")]
        public string Password { get; set; }
    }
}
