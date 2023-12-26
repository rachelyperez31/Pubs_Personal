using Pubs.Domain.Entities;
using Pubs_Infrastructure.Context;
using Pubs_Infrastructure.Core;
using Pubs_Infrastructure.Interfaces;
using Pubs_Infrastructure.Models;
using System.Collections.Generic;
using System.Linq;

namespace Pubs_Infrastructure.Repositories
{
    public class RoyschedRepository : BaseRepository<Roysched>, IRoyschedRepository
    {
        private readonly PubsContext _context;

        public RoyschedRepository(PubsContext context) : base(context) 
        {
            _context = context;
        }

        public override void Save(Roysched roysched)
        {
            _context.Roysched.Add(roysched);
            _context.SaveChanges();
        }

        public override List<Roysched> GetEntities()
        {
            return _context.Roysched.Where(r => !r.Deleted).ToList();
        }

        public override void Update(Roysched roysched)
        {
            _context.Roysched.Update(roysched);
            _context.SaveChanges();
        }

        public override void Remove(Roysched roysched)
        {
            _context.Roysched.Remove(roysched);
            _context.SaveChanges();
        }

        public List<PublicationModel> GetRoyscheds()
        {
            var royscheds = (from r in _context.Roysched
                             join t in _context.Titles on r.TitleID equals t.TitleID
                             select new PublicationModel()
                             {
                                 Royalty = r.Royalty,
                                 TitleName = t.TitleName,
                                 Hirange = r.Hirange,
                                 Lorange = r.Lorange
                             }).ToList();
            return royscheds;
        }

        public PublicationModel GetRoysched(int royschedID)
        {
            return GetRoyscheds().Find(r => r.RoyschedID == royschedID);
        }
    }
}
