using System;
using System.ComponentModel.DataAnnotations;

namespace SS.API.Business.Dtos.Accept
{
    public class UserForRegisterDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        [Required]
        public string UserName { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "You must specify password between 4 and 20 characters ")]
        public string Password { get; set; }

        public UserForRegisterDto()
        {
            Created = DateTime.Now;
            LastActive = DateTime.Now;
        }
    }
}