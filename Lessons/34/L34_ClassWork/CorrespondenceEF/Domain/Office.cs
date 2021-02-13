using System;
using System.Collections.Generic;
using System.Text;

namespace CorrespondenceEF.Domain
{
    public class Office
    {
        public int Id { get; set; }
        public City City { get; set; }
        public string Address { get; set; }
    }
}
