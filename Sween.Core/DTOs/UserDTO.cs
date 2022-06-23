using System;
using System.Collections.Generic;
using System.Text;

namespace Sween.Core.DTOs
{
    public class UserDTO
    {
        public int? UserPublicId { get; set; }
        public string UserPublicName { get; set; }
        public string UserName { get; set; }
        public string UserMidleName { get; set; }
        public string UserLastName { get; set; }
        public string UserPhoneNumber { get; set; }
        public string UserCountry { get; set; }
        public string Email { get; set; }
        public string Birthday { get; set; }
        public string Imageurl { get; set; }
    }
}
