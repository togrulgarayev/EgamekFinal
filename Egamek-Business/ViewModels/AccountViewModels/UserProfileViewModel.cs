using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Egamek_Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Egamek_Business.ViewModels.AccountViewModels
{
    public class UserProfileViewModel
    {
        public string Fullname { get; set; }
        public string Email { get; set; }
        public int GenderId { get; set; }
        public List<Gender> Gender { get; set; }
        public int Age { get; set; }
        public string ProfilePicture { get; set; }
        public IFormFile ProfilePhoto { get; set; }



        [Required, MaxLength(255), DataType(DataType.Password)]
        public string CurrentPassword { get; set; }

        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [DataType(DataType.Password), Compare(nameof(NewPassword))]
        public string ConfirmPassword { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
