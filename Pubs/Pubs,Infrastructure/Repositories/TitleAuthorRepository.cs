using Pubs.Domain.Entities;
using Pubs_Infrastructure.Context;
using Pubs_Infrastructure.Core;
using Pubs_Infrastructure.Interfaces;
using Pubs_Infrastructure.Models;
using System.Collections.Generic;
using System.Linq;

namespace Pubs_Infrastructure.Repositories
{
    public class TitleAuthorRepository : BaseRepository<TitleAuthor>, ITitleAuthorRepository
    {
        private readonly PubsContext _context;

        public TitleAuthorRepository(PubsContext context) : base(context)
        {
            _context = context;
        }

        public override void Save(TitleAuthor titleAuthor)
        {
            _context.TitleAuthor.Add(titleAuthor);
            _context.SaveChanges();
        }

        public override List<TitleAuthor> GetEntities()
        {
            return _context.TitleAuthor.Where(ta => !ta.Deleted).ToList();
        }

        public override void Update(TitleAuthor titleAuthor)
        {
            _context.TitleAuthor.Update(titleAuthor);
            _context.SaveChanges();
        }

        public override void Remove(TitleAuthor titleAuthor)
        {
            _context.TitleAuthor.Remove(titleAuthor);
            _context.SaveChanges();
        }

        public List<PublicationModel> GetTitleAuthors()
        {
            var titleAuthor = (from ta in _context.TitleAuthor
                               join t in _context.Titles on ta.TitleID equals t.TitleID
                               join au in _context.Authors on ta.AuID equals au.AuID
                               select new PublicationModel()
                               {
                                    TitleName = t.TitleName,
                                    AuFName = au.AuFName,
                                    AuLName = au.AuLName
                               }).ToList();

            return titleAuthor;
        }

        public PublicationModel GetTitleAuthor(int titleID, int authorID)
        {
            var id = new { TitleID = titleID, AuID = authorID };

            return GetTitleAuthors().Find(ta => ta.Equals(id));
        }

        public PublicationModel GetTitleAuthorByAuthor(string firstname, string lastname)
        {
            return GetTitleAuthors().FirstOrDefault(ta => ta.AuFName == firstname && ta.AuLName == lastname);
        }

        public PublicationModel GetTitleAuthorByTitle(string title)
        {
            return GetTitleAuthors().FirstOrDefault(ta => ta.TitleName == title);
        }
    }
}
