using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RWEDO.MSQLRepository.Contracts;

namespace RWEDO.Controllers
{
    public class SurveyFileController : Controller
    {
        private readonly ISuveyFileRepository _surveyFileRepository;
        public SurveyFileController(ISuveyFileRepository surveyFileRepository)
        {
            _surveyFileRepository = surveyFileRepository;
        }
        public ViewResult Index()
        {
            var model = _surveyFileRepository.GetAllSurveyFile();                            
            return View(model);
        }
    }
}