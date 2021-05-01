using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class JobSeekerOperations
    {

        JobDBContext _DbContext;
        public JobSeekerOperations()
        {
            _DbContext = new JobDBContext(); 
        }

        public IEnumerable<JobSeeker> GetJobSekeerList()
        {
            return _DbContext.JobSeekers.ToList();   
        }

        public JobSeeker GetJobSeekerById(int? Id)
        {
         return _DbContext.JobSeekers.Find(Id);            
        }



        public IEnumerable<Country> GetCountries()
        {
            return _DbContext.Countries.ToList();
        }

        public JobSeeker Add(JobSeeker newJobSeeker)
        {
            _DbContext.JobSeekers.Add(newJobSeeker);
            _DbContext.SaveChanges();
            return newJobSeeker;
        }

        public JobSeeker Update(JobSeeker updateJobSeeker)
        {
            JobSeeker jobSeeker = _DbContext.JobSeekers.Find(updateJobSeeker.Id);           
            jobSeeker.Id = updateJobSeeker.Id;
            jobSeeker.Name = updateJobSeeker.Name;
            jobSeeker.Address = updateJobSeeker.Address;
            jobSeeker.Mobile = updateJobSeeker.Mobile;
            jobSeeker.resume = updateJobSeeker.resume;
            jobSeeker.Country = updateJobSeeker.Country;
            //jobSeeker.DOB = updateJobSeeker.DOB;            
            jobSeeker.GENDER = updateJobSeeker.GENDER;
            jobSeeker.IsDotnet = updateJobSeeker.IsDotnet;
            jobSeeker.IsJava = updateJobSeeker.IsJava;
            jobSeeker.IsSAP = updateJobSeeker.IsSAP;
            jobSeeker.Skills = updateJobSeeker.Skills;
            _DbContext.SaveChanges();
            return updateJobSeeker;
        }


    }
}
