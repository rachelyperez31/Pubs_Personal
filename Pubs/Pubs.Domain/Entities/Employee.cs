using Pubs.Domain.Core;
using System;

namespace Pubs.Domain.Entities
{
    public class Employee : BaseEntity
    {
        public int EmpID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public char? Minit { get; set; }
        public short JobID { get; set; }
        public short? JobLvl { get; set; }
        public int PubID { get; set; }
        public DateTime HireDate { get; set; }
    }
}
