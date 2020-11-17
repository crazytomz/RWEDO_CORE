using RWEDO.DataTransferObject;
using RWEDO.MSQLRepository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace RWEDO.MSQLRepository.Services
{
    public class SurveyFileRepository : ISuveyFileRepository
    {
        private readonly RWEDODbContext context;
        public SurveyFileRepository(RWEDODbContext context)
        {
            this.context = context;
        }
        public SurveyFile Add(SurveyFile SurveyFile)
        {
            context.SurveyFiles.Add(SurveyFile);
            context.SaveChanges();
            return SurveyFile;
        }

        public SurveyFile Delete(int id)
        {
            SurveyFile SurveyFile = context.SurveyFiles.Find(id);
            if (SurveyFile != null)
            {
                context.SurveyFiles.Remove(SurveyFile);
                context.SaveChanges();
            }
            return SurveyFile;
        }

        public IEnumerable<SurveyFile> GetAllSurveyFile()
        {
            return context.SurveyFiles;
        }

        public SurveyFile GetSurveyFile(int Id)
        {
            //logger.LogTrace("Trace Log");
            //logger.LogDebug("Debug Log");
            //logger.LogInformation("Information Log");
            //logger.LogWarning("Warning Log");
            //logger.LogError("Error Log");
            //logger.LogCritical("Critical Log");

            return context.SurveyFiles.Find(Id);
        }

        public SurveyFile Update(SurveyFile SurveyFileChanges)
        {
            var SurveyFile = context.SurveyFiles.Attach(SurveyFileChanges);
            SurveyFile.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return SurveyFileChanges;
        }
    }
}
