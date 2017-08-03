using System.IO;
using System.Xml.Serialization;
using WTW.Web.API.Models;

namespace WTW.Web.API.DataAccess
{
    /// <summary>
    /// Sample implementation of IResumeRepository.
    /// </summary>
    public class ResumeRepositoryXml : IResumeRepository
    {
        public Resume GetResumeData(string firstName, string lastName)
        {
            Stream xmlResource = this.GetType().Assembly.GetManifestResourceStream($"WTW.Web.API.EmbeddedResources.{firstName}{lastName}Resume.xml");

            XmlSerializer serializer = new XmlSerializer(typeof(Resume));

            using (StreamReader reader = new StreamReader(xmlResource))
            {
                return (Resume) serializer.Deserialize(reader);
            }
        }
    }
}