﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Iwentys.Common.Databases;
using Iwentys.Features.Achievements.Entities;
using Iwentys.Features.Achievements.Models;
using Microsoft.EntityFrameworkCore;

namespace Iwentys.Features.Achievements.Services
{
    public class AchievementService
    {
        private readonly IGenericRepository<GuildAchievement> _guildAchievementRepository;
        private readonly IGenericRepository<StudentAchievement> _studentAchievementRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AchievementService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _guildAchievementRepository = _unitOfWork.GetRepository<GuildAchievement>();
            _studentAchievementRepository = _unitOfWork.GetRepository<StudentAchievement>();
        }

        public async Task<List<AchievementInfoDto>> GetForStudent(int studentId)
        {
            return await _studentAchievementRepository
                .Get()
                .Where(a => a.StudentId == studentId)
                .Select(AchievementInfoDto.FromStudentsAchievement)
                .ToListAsync();
        }

        public async Task<List<AchievementInfoDto>> GetForGuild(int guildId)
        {
            return await _guildAchievementRepository
                .Get()
                .Where(a => a.GuildId == guildId)
                .Select(AchievementInfoDto.FromGuildAchievement)
                .ToListAsync();
        }

        //TODO: implement getting all achievement
    }
}