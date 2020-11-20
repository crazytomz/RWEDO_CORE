using RWEDO.DataTransferObject;
using RWEDO.MSQLRepository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace RWEDO.MSQLRepository.Services
{
    public class SurveyFileRepository : ISurveyFileRepository
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

        public SurveyFile Delete(int ID)
        {
            SurveyFile SurveyFile = context.SurveyFiles.Find(ID);
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

        public SurveyFile GetSurveyFile(int ID)
        {
            return context.SurveyFiles.Find(ID);
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
