using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace RWEDO.DataTransferObject
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Surveyor>().HasData(
                    new Surveyor
                    {
                        ID = 1,
                        Name = "SAdmin",
                        IdentityNumber = "Master",
                        Email = "thomsonkvarkey@outlook.com",
                        ISDeactivated = false
                    }
                );
            modelBuilder.Entity<UserRole>().HasData(
                    new UserRole
                    {
                        ID = 1,
                        Name = "SAdmin",
                        ISInternal = true
                    },
                    new UserRole
                    {
                        ID = 2,
                        Name = "CEO",
                        ISInternal = false
                    },
                    new UserRole
                    {
                        ID = 3,
                        Name = "Employee",
                        ISInternal = false
                    }
                );
            modelBuilder.Entity<User>().HasData(
                   new User
                   {
                       ID = 1,
                       SurveyorID = 1,
                       UserRoleID = 1,
                       UserName = "sadmin",
                       Password = "sa@2020",
                       ISAdmin = true,
                       ISDeactivared = false,
                       ISDeleted = false
                   }
               );
            modelBuilder.Entity<Status>().HasData(
                    new Status
                    {
                        ID = 1,
                        Description = "Opened"
                    },
                    new Status
                    {
                        ID = 2,
                        Description = "File Received"
                    },
                    new Status
                    {
                        ID = 3,
                        Description = "File Received"
                    },
                    new Status
                    {
                        ID = 4,
                        Description = "Surveyed"
                    },
                    new Status
                    {
                        ID = 5,
                        Description = "Estimate Received"
                    },
                    new Status
                    {
                        ID = 6,
                        Description = "Bill Received"
                    },
                    new Status
                    {
                        ID = 7,
                        Description = "Report Prepared"
                    },
                    new Status
                    {
                        ID = 8,
                        Description = "Report Submitted"
                    }
                );
        }
    }
        
}
