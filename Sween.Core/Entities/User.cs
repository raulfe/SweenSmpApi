using System;
using System.Collections.Generic;

#nullable disable

namespace Sween.Core.Entities
{
    public partial class User
    {
        public int UserId { get; set; }
        public int? UserPublicId { get; set; }
        public int? UserThemeId { get; set; }
        public string UserPublicName { get; set; }
        public string UserName { get; set; }
        public string UserMidleName { get; set; }
        public string UserLastName { get; set; }
        public string UserPhoneNumber { get; set; }
        public string UserCountry { get; set; }
        public string Status { get; set; }
        public DateTime? ActiveDate { get; set; }
        public DateTime? InactiveDate { get; set; }
        public string Email { get; set; }
        public DateTime? CreationDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UpdatedBy { get; set; }
        public string Birthday { get; set; }
        public string Imageurl { get; set; }

    }
}
