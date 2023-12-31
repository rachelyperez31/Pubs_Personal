namespace Pubs.API.Models.Core
{
    public abstract class EmployeeBaseModel : BaseModel
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public char? Minit { get; set; }
        public short JobID { get; set; }
        public short? JobLvl { get; set; }
        public int PubID { get; set; }
        public DateTime HireDate { get; set; }
    }
}
