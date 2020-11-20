using RWEDO.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace RWEDO.MSQLRepository.Contracts
{
    public interface ISurveyFileRepository
    {
        SurveyFile GetSurveyFile(int ID);
        IEnumerable<SurveyFile> GetAllSurveyFile();
        SurveyFile Add(SurveyFile SurveyFile);
        SurveyFile Update(SurveyFile SurveyFileChanges);
        SurveyFile Delete(int ID);
    }
}
