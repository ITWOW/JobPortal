using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;
using System.IO;
using System.Configuration;
using JobPortal.Models;
namespace JobPortal.Controllers
{
    public class JobSekkerController : Controller
    {
        JobSeekerOperations _operations;
        public JobSekkerController()
        {
            _operations = new JobSeekerOperations();
        }

        
        // GET: JobSeeker
        public ActionResult Index()
        {
            IEnumerable<JobSeeker> objSekeers = _operations.GetJobSekeerList();
            // return View(objSekeers);
            return View(objSekeers);
        }

        public ActionResult Create(int? id)
        {

            JobSeekerViewModel model = model = new JobSeekerViewModel()
            {
                SkillList = GetAllSkillTypes()
            };
            if (id > 0)
            {
                JobSeeker jobSeeker = _operations.GetJobSeekerById(id);
                if (jobSeeker != null)
                {
                    if (jobSeeker.Skills != null)
                    {
                        model.SelectedSkillIds = jobSeeker.Skills.Split(',').Select(n => Convert.ToInt32(n)).ToArray();
                        // model.SelectedSkillIds = jobSeeker.Skills..Split(',').Select(int.Parse).ToArray();
                        //  model.SelectedSkillIds = jobSeeker.Skills.Split(',').Select(s => int.TryParse(s, out n) ? n : 0).ToArray();
                    }


                    mappingModeltoViewModel(jobSeeker, model);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            ViewBag.CountryEFW = new SelectList(_operations.GetCountries(), "Id", "Name");
            return View(model);
        }

        #region Other Ways to bind DDL
        /* //to bind countries from code behind DB
        List<SelectListItem> cList = new List<SelectListItem>()
        {
            new SelectListItem() { Text = "INDIA", Value = "INDIA", Selected = false },
            new SelectListItem() { Text = "USA", Value = "USA", Selected = false },
            new SelectListItem() { Text = "UK", Value = "UK", Selected = false }
        };
       model.CountryList=cList;
       // bind Clist


       //to bind skils from code behind enum
        var myskill = new List<ConvertEnum>();
       foreach (MySkillsEnum lang in Enum.GetValues(typeof(MySkillsEnum)))
       {
           myskill.Add(new ConvertEnum { Value = (int)lang, Text = lang.ToString() });
       }
       ViewBag.MySkillEnum = myskill;


       */

        #endregion

        public JsonResult JSONDataActionmethod() 
        {
            return Json(_operations.GetCountries(), JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult Create(JobSeekerViewModel model)
        {

            model.SkillList = GetAllSkillTypes();
            if (ModelState.IsValid)
            {

                JobSeeker jobSeeker = jobSeeker = new JobSeeker();
                if (model.SelectedSkillIds != null)
                    model.Skills = string.Join(",", from i in model.SelectedSkillIds select i.ToString());

                if (model.Id > 0)
                {
                    if (model.ImageFile != null)
                    {
                        if (model.resume != null)
                        {
                            System.IO.File.Delete(Path.Combine(Server.MapPath("/images"), model.resume));
                        }

                    }
                    model.resume = ProcessUploadedFile(model);

                    mappingViewModeltoModel(model, jobSeeker);
                    _operations.Update(jobSeeker);
                }
                else
                {
                    model.resume = ProcessUploadedFile(model);
                    mappingViewModeltoModel(model, jobSeeker);

                    jobSeeker = _operations.Add(jobSeeker);
                }
                return RedirectToAction("Index");

            }
           

            ViewBag.CountryEFW = new SelectList(_operations.GetCountries(), "Id", "Name");
            return View(model);

        }

        private string ProcessUploadedFile(JobSeekerViewModel model)
        {
            string uniqueFileName = null;
            if (model.ImageFile != null)
            {
                string uploadsFolder = Server.MapPath("~/images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ImageFile.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                model.ImageFile.SaveAs(filePath);
                // using (var fileStream = new FileStream(filePath, FileMode.Create))
                // {

                // }
            }

            return uniqueFileName;
        }


        public List<SelectListItem> GetAllSkillTypes()
        {
            List<SelectListItem> items = new List<SelectListItem>()
            {
                new SelectListItem{ Text="ASP.NET MVC", Value = "1" },
                new SelectListItem{ Text="ASP.NET WEB API", Value = "2" },
                new SelectListItem{ Text="ENTITY FRAMEWORK", Value = "3" },
                new SelectListItem{ Text="DOCUSIGN", Value = "4" },
                new SelectListItem{ Text="ORCHARD CMS", Value = "5" },
                new SelectListItem{ Text="JQUERY", Value = "6" },
                new SelectListItem{ Text="ZENDESK", Value = "7" },
                new SelectListItem{ Text="LINQ", Value = "8" },
                new SelectListItem{ Text="C#", Value = "9" },
                new SelectListItem{ Text="GOOGLE ANALYTICS", Value = "10" },
            };
            return items;
        }      

        public void mappingModeltoViewModel(JobSeeker jobseeker, JobSeekerViewModel model)
        {
            model.Id = jobseeker.Id;
            model.Name = jobseeker.Name;
            model.Address = jobseeker.Address;
            model.Mobile = jobseeker.Mobile;
            model.resume = jobseeker.resume;
            model.Country = jobseeker.Country;
            model.DOB = jobseeker.DOB; 

            model.GENDER = Convert.ToBoolean(jobseeker.GENDER) ? "1" : "0";
            model.IsDotnet = Convert.ToBoolean(jobseeker.IsDotnet);
            model.IsJava = Convert.ToBoolean(jobseeker.IsJava);
            model.IsSAP = Convert.ToBoolean(jobseeker.IsSAP);


        }

        public void mappingViewModeltoModel(JobSeekerViewModel model, JobSeeker jobSeeker)
        {
            if (model.Id > 0)
            {
                jobSeeker.Id = model.Id;
            }

            jobSeeker.Name = model.Name;
            jobSeeker.Address = model.Address;
            jobSeeker.Mobile = model.Mobile;
            jobSeeker.resume = model.resume;
            jobSeeker.Country = model.Country;
            jobSeeker.DOB = model.DOB;            
            jobSeeker.GENDER = (model.GENDER == "1");
            jobSeeker.IsDotnet = model.IsDotnet;
            jobSeeker.IsJava = model.IsJava;
            jobSeeker.IsSAP = model.IsSAP;
            jobSeeker.Skills = model.Skills;
           /* bool result;
            bool.TryParse(, out result);*/
        }

        
    }
}