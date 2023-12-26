namespace Pubs_Infrastructure.Models
{
    public class EmploymentModel
    {
        public short JobID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public short? JobLvl { get; set; }
        public string JobDesc { get; set; }
        public short Min_Lvl { get; set; }
        public short Max_Lvl { get; set; }
        public int PubID { get; set; }
        public string PubName { get; set; }
        public int EmpID { get; set; }
    }
}
