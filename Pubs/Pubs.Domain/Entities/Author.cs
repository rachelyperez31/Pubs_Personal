using Pubs.Domain.Core;

namespace Pubs.Domain.Entities
{
    public class Author : Location
    {
        public int AuID { get; set; }
        public string AuLName { get; set; }
        public string AuFName { get; set;}
        public char Phone { get; set; }
        public string? Address { get; set; }
        public bool Contract { get; set; }
    }
}
