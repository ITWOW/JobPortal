using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace JobPortal.Models
{
    public class JobSeekerViewModel
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Member Name")]
        public string Name { get; set; }
        
        public string Address { get; set; }

        [Required]        
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid mobile number")]

        public string Mobile { get; set; }
        [Display(Name="Photo")]
        public string resume { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
        public string Skills { get; set; }

        public Nullable<int> Country { get; set; }


        //[DisplayFormat(ApplyFormatInEditMode =true,DataFormatString ="{0:MM/dd/yyyy")] 
        
        //[DataType(DataType.Date)]
        
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<System.DateTime> DOB { get; set; }
        [Required]
        public string GENDER { get; set; }

        [Display(Name="java")]
        public bool IsJava { get; set; }
        [Display(Name = ".net")]
        public bool IsDotnet { get; set; }

        [Display(Name = "SAP")]
        public bool IsSAP { get; set; }

        public List<SelectListItem> CountryList { get; set; }


        public int[] SelectedSkillIds { get; set; }
        public IEnumerable<SelectListItem> SkillList { get; set; }

        

    }
}