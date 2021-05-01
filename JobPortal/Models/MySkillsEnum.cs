using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobPortal.Models
{
    public enum MySkillsEnum
    {
        ASPNETMVC,
        ASPNETWEPAPI,
        CSHARP,
        DOCUSIGN,
        JQUERY
    }

    public struct ConvertEnum
    {
        public int Value
        {
            get;
            set;
        }
        public String Text
        {
            get;
            set;
        }
    }
}