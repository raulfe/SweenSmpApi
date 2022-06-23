using System;
using System.Collections.Generic;

#nullable disable

namespace Sween.Core.Entities
{
    public partial class UserContact
    {
        public int ContactId { get; set; }
        public int UserPublicId { get; set; }
        public int UserPublicId2 { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreationDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? Status { get; set; }
    }
}
