using System.Web.Http;
using WTW.Web.API.DataAccess;
using WTW.Web.API.Models;

namespace WTW.Web.API.Controllers
{
    public class ResumeController : ApiController
    {
        private IResumeRepository _repository;

        public ResumeController(IResumeRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public Resume ResumeData()
        {
            // TODO: Add exception handling.
            return _repository.GetResumeData(firstName: "Juston", lastName: "Gleason");
        }
    }
}
