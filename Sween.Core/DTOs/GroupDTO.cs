using System;
using System.Collections.Generic;
using System.Text;

namespace Sween.Core.DTOs
{
    public class GroupDTO
    {
        public int? GroupId { get; set; }
        public int GroupType { get; set; }
        public string GroupDescription { get; set; }
        public DateTime? Xdate { get; set; }
        public string Xuser { get; set; }
    }
}
