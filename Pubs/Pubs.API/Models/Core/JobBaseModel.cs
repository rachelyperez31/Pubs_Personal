namespace Pubs.API.Models.Core
{
    public abstract class JobBaseModel : BaseModel
    {
        public string JobDesc { get; set; }
        public short Min_Lvl { get; set; }
        public short Max_Lvl { get; set; }
    }
}
