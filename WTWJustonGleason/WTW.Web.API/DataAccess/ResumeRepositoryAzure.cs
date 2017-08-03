using System;
using WTW.Web.API.Models;

namespace WTW.Web.API.DataAccess
{
    /// <summary>
    /// Sample implementation of IResumeRepository.
    /// </summary>
    public class ResumeRepositoryAzure : IResumeRepository
    {
        public Resume GetResumeData(string firstName, string lastName)
        {
            throw new NotImplementedException();
        }
    }
}