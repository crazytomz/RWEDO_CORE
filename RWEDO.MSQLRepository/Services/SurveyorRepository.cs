using RWEDO.DataTransferObject;
using RWEDO.MSQLRepository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace RWEDO.MSQLRepository.Services
{
    public class SurveyorRepository : ISurveyorRepository
    {
        private readonly RWEDODbContext context;
        public SurveyorRepository(RWEDODbContext context)
        {
            this.context = context;
        }
        public Surveyor GetSurveyor(int ID)
        {
            return context.Surveyors.Find(ID);
        }
    }
}
