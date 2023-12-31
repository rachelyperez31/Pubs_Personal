namespace Pubs.API.Models.Core
{
    public abstract class AuthorBaseModel : BaseModel
    {
        public string AuLName { get; set; }
        public string AuFName { get; set; }
        public string Phone { get; set; }
        public string? Address { get; set; }
        public bool Contract { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
    }
}
