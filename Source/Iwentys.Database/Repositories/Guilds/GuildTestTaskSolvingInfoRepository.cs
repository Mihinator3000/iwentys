﻿using System;
using System.Linq;
using Iwentys.Database.Context;
using Iwentys.Features.Guilds.Entities;
using Iwentys.Features.Guilds.Repositories;
using Iwentys.Features.Students.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Iwentys.Database.Repositories.Guilds
{
    public class GuildTestTaskSolvingInfoRepository : IGuildTestTaskSolvingInfoRepository
    {
        private readonly IwentysDbContext _dbContext;

        public GuildTestTaskSolvingInfoRepository(IwentysDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public GuildTestTaskSolvingInfoEntity Create(GuildEntity guild, StudentEntity student)
        {
            EntityEntry<GuildTestTaskSolvingInfoEntity> entityEntry = _dbContext.GuildTestTaskSolvingInfos.Add(new GuildTestTaskSolvingInfoEntity
            {
                GuildId = guild.Id,
                StudentId = student.Id,
                StartTime = DateTime.UtcNow
            });
            _dbContext.SaveChanges();
            return entityEntry.Entity;
        }

        public IQueryable<GuildTestTaskSolvingInfoEntity> Read()
        {
            return _dbContext.GuildTestTaskSolvingInfos;
        }

        public GuildTestTaskSolvingInfoEntity Update(GuildTestTaskSolvingInfoEntity testTask)
        {
            EntityEntry<GuildTestTaskSolvingInfoEntity> result = _dbContext.Update(testTask);
            _dbContext.SaveChanges();
            return result.Entity;
        }
    }
}