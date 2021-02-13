using System;
using System.Collections.Generic;
using System.Text;

namespace CorrespondenceEF.Domain
{
    public class Flow
    {
        public int Id { get; set; }
        public Sending SendingId { get; set; }
        public Status StatusId { get; set; }
        public DateTimeOffset UpdateStatusDateTime { get; set; }
    }
}
