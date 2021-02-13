using System;
using System.Collections.Generic;
using System.Text;

namespace CorrespondenceEF.Domain
{
    public class Sending
    {
        public int Id { get; set; }
        public Contractor SenderPassportNumber { get; set; }
        public Office SenderOfficeId { get; set; }
        public Contractor ReceiverPassportNumber { get; set; }
        public Office ReceiverOfficeId { get; set; }
        public PostalItem PostalItemId { get; set; }
    }
}
