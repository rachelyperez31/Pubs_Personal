using Pubs.Domain.Entities;
using Pubs_Infrastructure.Context;
using Pubs_Infrastructure.Core;
using Pubs_Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Pubs_Infrastructure.Repositories
{
    public class JobRepository : BaseRepository<Job>, IJobRepository
    {
        private readonly PubsContext _context;

        public JobRepository(PubsContext context) : base(context)
        {
            _context = context;
        }

        public override void Save(Job job)
        {
            _context.Jobs.Add(job);
            _context.SaveChanges();
        }

        public override List<Job> GetEntities()
        {
            return _context.Jobs.Where(jb => !jb.Deleted).ToList(); 
        }

        public override void Update(Job job)
        {
            _context.Jobs.Update(job);
            _context.SaveChanges();
        }

        public override void Remove(Job job)
        {
            _context.Jobs.Remove(job);
            _context.SaveChanges();
        }

        public Job GetJob(int jobID)
        {
            return GetJobs().Find(j => j.JobID == jobID);
        }

        public List<Job> GetJobs()
        {
            var jobs = _context.Jobs.Where(jobs => !jobs.Deleted).Select(
                j => new Job()
                {
                    JobDesc = j.JobDesc,
                    Max_Lvl = j.Max_Lvl,
                    Min_Lvl = j.Min_Lvl,
                }).ToList();

            return jobs;
        }

        public string GetJobDescription(int jobID)
        {
            string jobDesc = GetJob(jobID).JobDesc;
            return jobDesc;
        }

        public short GetJobMin_Lvl(int jobID)
        {
            short minLvl = GetJob(jobID).Min_Lvl;
            return minLvl;
        }

        public short GetJobMax_Lvl(int jobID)
        {
            short maxLvl = GetJob(jobID).Max_Lvl;
            return maxLvl;
        }
    }
}
