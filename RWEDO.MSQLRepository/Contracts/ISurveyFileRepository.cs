using RWEDO.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace RWEDO.MSQLRepository.Contracts
{
    public interface ISuveyFileRepository
    {
        SurveyFile GetSurveyFile(int Id);
        IEnumerable<SurveyFile> GetAllSurveyFile();
        SurveyFile Add(SurveyFile SurveyFile);
        SurveyFile Update(SurveyFile SurveyFileChanges);
        SurveyFile Delete(int id);
    }
}
