using System;
using System.Xml.Serialization;

namespace WTW.Web.API.Models
{
    [Serializable()]
    [XmlRoot("Resume")]
    public class Resume
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [XmlArray("EducationHistory")]
        [XmlArrayItem("Education", typeof(Education))]
        public Education[] EducationHistory { get; set; }

        [XmlArray("EmploymentHistory")]
        [XmlArrayItem("Employment", typeof(Employment))]
        public Employment[] EmploymentHistory { get; set; }
    }
}