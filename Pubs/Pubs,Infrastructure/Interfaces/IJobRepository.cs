using Pubs.Domain.Entities;
using Pubs.Domain.Repository;
using Pubs_Infrastructure.Models;
using System.Collections.Generic;

namespace Pubs_Infrastructure.Interfaces
{
    public interface IJobRepository : IBaseRepository<Job>
    {
        Job GetJob(int jobID);
        List<Job> GetJobs();
        string GetJobDescription(int  jobID);
        short GetJobMin_Lvl(int jobID);
        short GetJobMax_Lvl(int jobID);
    }
}
