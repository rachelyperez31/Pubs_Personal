using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pubs.API.Models.Modules.Job;
using Pubs.Domain.Entities;
using Pubs_Infrastructure.Interfaces;

namespace Pubs.API.Controllers
{
    public class JobController : Controller
    {
        private readonly IJobRepository _jobRepository;

        public JobController(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        [HttpGet("Get Jobs")]
        public IActionResult GetJobs()
        {
            var jobs = _jobRepository.GetJobs().Select(
                j => new JobGetModel()
                {
                    JobDesc = j.JobDesc,
                    Min_Lvl = j.Min_Lvl,
                    Max_Lvl = j.Max_Lvl
                }
                );    

            return Ok(jobs);
        }

        [HttpGet("Get Job")]
        public IActionResult GetJob(int jobID)
        {
            var job = _jobRepository.GetJob(jobID);

            return Ok(job);
        }

        [HttpPost("Add Job")]
        public IActionResult AddJob([FromBody] JobAddModel jobAdd)
        {
            var job = new Job()
            {
                JobDesc = jobAdd.JobDesc,
                Min_Lvl = jobAdd.Min_Lvl,
                Max_Lvl = jobAdd.Max_Lvl
            };

            _jobRepository.Save(job);

            return Ok(job);
        }

        [HttpPut("Edit Job")]
        public IActionResult EditJob([FromBody] JobUpdateModel jobUpdate)
        {
            var job = new Job()
            {
                JobDesc = jobUpdate.JobDesc,
                Min_Lvl = jobUpdate.Min_Lvl,
                Max_Lvl = jobUpdate.Max_Lvl
            };

            _jobRepository.Update(job);

            return Ok(job);
        }

        [HttpDelete("Remove Job")]
        public IActionResult RemoveJob([FromBody] JobRemoveModel jobRemove)
        {
            var job = new Job()
            {
                JobID = jobRemove.JobID,
                Deleted = true,
                IDDeletedUser = jobRemove.ChangeUser,
                DeletedDate = jobRemove.ChangeDate
            };

            _jobRepository.Remove(job);

            return Ok(job);
        }
    }
}
