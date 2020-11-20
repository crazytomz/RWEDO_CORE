using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RWEDO.MSQLRepository.Contracts;

namespace RWEDO.Controllers
{
    [Authorize]
    public class SurveyFileController : Controller
    {
        private readonly ISurveyFileRepository _surveyFileRepository;
        public SurveyFileController(ISurveyFileRepository surveyFileRepository)
        {
            _surveyFileRepository = surveyFileRepository;
        }
        [Authorize(Roles = "SAdmin,CEO,Employee")]
        public ActionResult Index()
        {
            var model = _surveyFileRepository.GetAllSurveyFile();                            
            return View(model);
        }
    }
}