using Pubs.Domain.Entities;
using Pubs_Infrastructure.Context;
using Pubs_Infrastructure.Core;
using Pubs_Infrastructure.Interfaces;
using Pubs_Infrastructure.Models;
using System.Collections.Generic;
using System.Linq;

namespace Pubs_Infrastructure.Repositories
{
    public class PublisherRepository : BaseRepository<Publisher>, IPublisherRepository
    {
        private readonly PubsContext _context;

        public PublisherRepository(PubsContext context) : base(context)
        {
            _context = context;
        }

        public override void Save(Publisher publisher)
        {
            _context.Publishers.Add(publisher);
            _context.SaveChanges();
        }

        public override List<Publisher> GetEntities()
        {
           return _context.Publishers.Where(pub => !pub.Deleted).ToList();    
        }

        public override void Update(Publisher publisher)
        {
            _context.Publishers.Update(publisher);
            _context.SaveChanges();
        }

        public override void Remove(Publisher publisher)
        {
            _context.Publishers.Remove(publisher);
            _context.SaveChanges(); 
        }

        public List<Publisher> GetPublishers()
        {
            var publishers = _context.Publishers.Where(pub => !pub.Deleted).Select(
                pub => new Publisher()
                {
                    PubName = pub.PubName,
                    Country = pub.Country,
                    City = pub.City,
                    State = pub.State
                }).ToList();    

            return publishers;
        }

        public Publisher GetPublisher(int pubID)
        {
            return GetPublishers().Find(pub => pub.PubID == pubID);
        }

        public Publisher GetPublisherByName(string name)
        {
            return GetPublishers().FirstOrDefault(pub => pub.PubName == name);
        }

        public List<Publisher> GetPublishersByCountry(string country)
        {
            return GetPublishers().Where(pub => !pub.Deleted).ToList();
        }

        public List<Publisher> GetEntityByCity(string city)
        {
            return GetPublishers().Where(pub => pub.City == city).ToList();
        }

        public List<Publisher> GetEntityByState(char state)
        {
            return GetPublishers().Where(pub => pub.State == state).ToList();   
        }
    }
}
