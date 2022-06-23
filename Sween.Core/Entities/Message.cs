using System;
using System.Collections.Generic;

#nullable disable

namespace Sween.Core.Entities
{
    public  class Message
    {
        public int MessageId { get; set; }
        public int? GroupId { get; set; }
        public string Message1 { get; set; }
        public string MessageBlob { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? Xdate { get; set; }
        public string Xuser { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UserId { get; set; }
        public string  BlobType { get; set; }
    }
}
