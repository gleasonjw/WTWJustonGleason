using System;

namespace WTW.Web.API.Models
{
    [Serializable()]
    public class Employment
    {
        public string CompanyName { get; set; }
        public string JobTitle { get; set; }
        public string JobDuties { get; set; }
        public string SkillsUsed { get; set; }
    }
}