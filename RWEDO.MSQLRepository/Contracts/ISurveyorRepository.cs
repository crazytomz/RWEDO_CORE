using RWEDO.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace RWEDO.MSQLRepository.Contracts
{
    public interface ISurveyorRepository
    {
        Surveyor GetSurveyor(int ID);
    }
}
