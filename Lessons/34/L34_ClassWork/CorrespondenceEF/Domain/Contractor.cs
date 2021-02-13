using System;
using System.Collections.Generic;
using System.Text;

namespace CorrespondenceEF.Domain
{
    public class Contractor
    {
        public int Id { get; set; }
        public string PassportNumber { get; set; }
        public string Name { get; set; }
        public Position Position { get; set; }
    }
}
