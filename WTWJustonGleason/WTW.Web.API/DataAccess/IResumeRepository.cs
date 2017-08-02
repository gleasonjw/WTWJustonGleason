using WTW.Web.API.Models;

namespace WTW.Web.API.DataAccess
{
    public interface IResumeRepository
    {
        Resume GetResumeData(string applicantFirstName, string applicantLastName);
    }
}
