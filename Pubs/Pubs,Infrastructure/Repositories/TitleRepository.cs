using Pubs.Domain.Entities;
using Pubs_Infrastructure.Context;
using Pubs_Infrastructure.Core;
using Pubs_Infrastructure.Interfaces;
using Pubs_Infrastructure.Models;
using System.Collections.Generic;
using System.Linq;

namespace Pubs_Infrastructure.Repositories
{
    public class TitleRepository : BaseRepository<Title>, ITitleRepository
    {
        private readonly PubsContext _context;

        public TitleRepository(PubsContext context) : base(context) 
        {
            _context = context;
        }

        public override void Save(Title title)
        {
            _context.Titles.Add(title); 
            _context.SaveChanges();
        }

        public override List<Title> GetEntities()
        {
            return _context.Titles.Where(t => !t.Deleted).ToList();
        }

        public override void Update(Title title)
        {
            _context.Titles.Update(title);
            _context.SaveChanges();
        }

        public override void Remove(Title title)
        {
            _context.Titles.Remove(title);  
            _context.SaveChanges();
        }

        public List<PublicationModel> GetTitles()
        {
            var titles = (from t in _context.Titles
                          join pub in _context.Publishers on t.PubID equals pub.PubID
                          join ta in _context.TitleAuthor on t.TitleID equals ta.TitleID
                          join au in _context.Authors on ta.AuID equals au.AuID
                          select new PublicationModel()
                          {
                              TitleName = t.TitleName,
                              PubName = pub.PubName,
                              AuFName = au.AuFName,
                              AuLName = au.AuLName
                          }).ToList();
            return titles;
        }

        public PublicationModel GetTitle(int titleID)
        {
            return GetTitles().Find(t => t.TitleID == titleID); 
        }

        public List<PublicationModel> GetTitlesByPublisher(string publisher)
        {
            return GetTitles().Where(ta => ta.PubName == publisher).ToList();
        }
    }
}
