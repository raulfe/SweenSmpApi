using System;
using System.Collections.Generic;

#nullable disable

namespace Sween.Core.Entities
{
    public partial class UserGroup
    {
        public int UserId { get; set; }
        public int GroupId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreationDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
