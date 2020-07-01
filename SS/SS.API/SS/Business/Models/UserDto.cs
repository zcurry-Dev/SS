using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SS.Business.Models.User
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string DisplayName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int UserStatusId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastActive { get; set; }
    }

    // Accept
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

    public class UserForLoginDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class UserForUpdateDto
    {
        public string Name { get; set; }
    }

    // Return    
    public class UserForAdminReturnDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public List<string> Roles { get; set; }
    }

    public class UserForDetailDto //UserDto instead? look into 070120
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        public string UserName { get; set; }
        public string DisplayName { get; set; }
    }
}