using System;
using System.Collections.Generic;

#nullable disable

namespace Sween.Core.Entities
{
    public partial class Group
    {
        public int GroupId { get; set; }
        public int? GroupType { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreationDate { get; set; }
        public string GroupDescription { get; set; }
        public DateTime? Xdate { get; set; }
        public string Xuser { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
