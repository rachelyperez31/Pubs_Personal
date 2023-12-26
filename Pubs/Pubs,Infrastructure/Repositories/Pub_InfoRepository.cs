using Pubs.Domain.Entities;
using Pubs_Infrastructure.Context;
using Pubs_Infrastructure.Core;
using Pubs_Infrastructure.Interfaces;
using Pubs_Infrastructure.Models;
using System.Collections.Generic;
using System.Linq;

namespace Pubs_Infrastructure.Repositories
{
    public class Pub_InfoRepository : BaseRepository<Pub_Info>, IPub_InfoRepository
    {
        private readonly PubsContext _context;

        public Pub_InfoRepository(PubsContext context) : base(context) 
        {
            _context = context;
        }

        public override void Save(Pub_Info pubInfo)
        {
            _context.Pub_Info.Add(pubInfo);
            _context.SaveChanges();
        }

        public override List<Pub_Info> GetEntities()
        {
            return _context.Pub_Info.Where(pubInfo => !pubInfo.Deleted).ToList();   
        }

        public override void Update(Pub_Info pubInfo)
        {
            _context.Pub_Info.Update(pubInfo);
            _context.SaveChanges();
        }

        public override void Remove(Pub_Info pubInfo)
        {
            _context.Pub_Info.Remove(pubInfo);
            _context.SaveChanges();
        }

        public List<PublicationModel> GetPub_Infos()
        {
            var pubInfos = (from pI in _context.Pub_Info
                            join pub in _context.Publishers on pI.PubID equals pub.PubID
                            select new PublicationModel()
                            {
                                PubName = pub.PubName,
                                PrInfo = pI.PrInfo
                            }).ToList();

            return pubInfos;
        }

        public PublicationModel GetPub_Info(int pubID)
        {
            return GetPub_Infos().Find(pI => pI.PubID == pubID);
        }
    }
}
