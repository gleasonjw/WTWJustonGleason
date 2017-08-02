using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WTW.Web.API.DataAccess;

namespace WTW.Web.API.Controllers
{
    public class ResumeController : ApiController
    {
        private IResumeRepository _repository;

        public ResumeController(IResumeRepository repository)
        {
            _repository = repository;
        }


    }
}
