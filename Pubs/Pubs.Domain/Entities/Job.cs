using Pubs.Domain.Core;

namespace Pubs.Domain.Entities
{
    public class Job : BaseEntity
    {
        public short JobID { get; set; }
        public string JobDesc { get; set; }
        public short Min_Lvl { get; set; }
        public short Max_Lvl { get; set;}
    }
}
