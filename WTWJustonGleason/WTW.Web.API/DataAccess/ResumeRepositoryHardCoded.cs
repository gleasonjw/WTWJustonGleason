using System;
using WTW.Web.API.Models;

namespace WTW.Web.API.DataAccess
{
    /// <summary>
    /// Sample implementation of IResumeRepository.
    /// </summary>
    public class ResumeRepositoryHardCoded : IResumeRepository
    {
        public Resume GetResumeData(string applicantFirstName, string applicantLastName)
        {
            throw new NotImplementedException();
        }
    }
}