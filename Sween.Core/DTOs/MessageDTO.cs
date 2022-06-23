using System;
using System.Collections.Generic;
using System.Text;

namespace Sween.Core.DTOs
{
    public class MessageDTO
    {
        public int? MessageId { get; set; }
        public int? GroupId { get; set; }
        public byte[] MessageBlob { get; set; }
        public string Message1 { get; set; }
        public DateTime? Xdate { get; set; }
        public string Xuser { get; set; }
        public int? UserId { get; set; }
        public string BlobType { get; set; }
    }
}
