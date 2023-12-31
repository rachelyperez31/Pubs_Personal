namespace Pubs_Infrastructure.Models
{
    public class PublicationModel
    {
        public int TitleID { get; set; }
        public string TitleName { get; set; }
        public char Type { get; set; }
        public string AuLName { get; set; }
        public string AuFName { get; set; }
        public string Phone { get; set; }
        public string? Address { get; set; }
        public int AuID { get; set; }
        public int PubID { get; set; }
        public string PubName { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string PrInfo { get; set; }
        public int? Lorange { get; set; }
        public int? Hirange { get; set; }
        public int Royalty { get; set; }
        public bool Contract { get; set; }
        public int RoyschedID { get; set; }
    }
}
