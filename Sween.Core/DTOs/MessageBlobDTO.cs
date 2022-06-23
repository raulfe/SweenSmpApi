using System;
using System.Collections.Generic;
using System.Text;

namespace Sween.Core.DTOs
{
    public class MessageBlobDTO
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
        public string BlobType { get; set; }
    }
}
