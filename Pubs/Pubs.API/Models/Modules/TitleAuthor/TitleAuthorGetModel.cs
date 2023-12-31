using Pubs.API.Models.Core;

namespace Pubs.API.Models.Modules.TitleAuthor
{
    public class TitleAuthorGetModel : TitleAuthorBaseModel
    {
        public int AuID { get; set; }
        public int TitleID { get; set; }
    }
}
