using Pubs.Domain.Entities;
using Pubs_Infrastructure.Context;
using Pubs_Infrastructure.Core;
using Pubs_Infrastructure.Interfaces;
using Pubs_Infrastructure.Models;
using System.Collections.Generic;
using System.Linq;

namespace Pubs_Infrastructure.Repositories
{
    public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
    {
        private readonly PubsContext _context;

        public AuthorRepository(PubsContext context) : base(context)
        {
            this._context = context;
        }

        public override void Save(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
        }

        public override void Update(Author author)
        {
            _context.Authors.Update(author);
            _context.SaveChanges();
        }
        public override void Remove(Author author)
        {
            _context.Authors.Remove(author);
            _context.SaveChanges();
        }
        public override List<Author> GetEntities()
        {
            return _context.Authors.Where(au => !au.Deleted ).ToList();
        }

        public List<PublicationModel> GetAuthors()
        {
            var authors = (from ta in _context.TitleAuthor
                           join au in _context.Authors on ta.AuID equals au.AuID
                           join t in _context.Titles on ta.TitleID equals t.TitleID
                           join pub in _context.Publishers on t.PubID equals pub.PubID
                           select new PublicationModel
                           {
                               AuFName = au.AuFName,
                               AuLName = au.AuLName,
                               PubName = pub.PubName
                           }
                           ).ToList();

            return authors;
        }

        public PublicationModel GetAuthor(int authorID)
        {
            return GetAuthors().Find(au => au.AuID == authorID);
        }
        public List<PublicationModel> GetAuthorsWithContract()
        {
            var authors = (from ta in _context.TitleAuthor
                           join au in _context.Authors on ta.AuID equals au.AuID
                           join t in _context.Titles on ta.TitleID equals t.TitleID
                           join pub in _context.Publishers on t.PubID equals pub.PubID
                           select new PublicationModel
                           {
                               AuFName = au.AuFName,
                               AuLName = au.AuLName,
                               PubName = pub.PubName,
                               Contract = au.Contract
                           }).ToList();

            return authors;
        }

        public List<PublicationModel> GetEntityByCity(string city)
        {
            var authors = (from au in this.GetAuthors()
                           where au.City == city
                           select new PublicationModel
                           {
                               AuFName = au.AuFName,
                               AuLName = au.AuLName,
                               Phone = au.Phone
                           }).ToList();

            return authors;
        }

        public List<PublicationModel> GetEntityByState(char state)
        {
            var authors = (from au in this.GetAuthors()
                           where au.State == state
                           select new PublicationModel
                           {
                               AuFName = au.AuFName,
                               AuLName = au.AuLName,
                               Phone = au.Phone
                           }).ToList();
            return authors;
        }

        public List<PublicationModel> GetPeopleByFirstName(string firstName)
        {
            return GetAuthors().Where(au => au.AuFName == firstName).ToList();
        }

        public List<PublicationModel> GetPeopleByLastName(string lastName)
        {
            return GetAuthors().Where(au => au.AuLName == lastName).ToList();
        }

        public List<PublicationModel> GetPeopleByFullName(string firstName, string lastName)
        {
            return GetAuthors().Where(au => au.AuFName == firstName && au.AuLName == lastName).ToList();
        }
    }
}
