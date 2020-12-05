﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Iwentys.Common.Exceptions;
using Iwentys.Common.Tools;
using Iwentys.Features.StudentFeature.Entities;
using Iwentys.Features.StudentFeature.Models;
using Iwentys.Features.StudentFeature.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Iwentys.Features.StudentFeature.Services
{
    public class StudentService
    {
        private readonly IStudentRepository _studentRepository;
        //private readonly AchievementProvider _achievementProvider;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<List<StudentPartialProfileDto>> GetAsync()
        {
            List<StudentEntity> students = await _studentRepository
                .Read()
                .ToListAsync();

            return students.SelectToList(s => new StudentPartialProfileDto(s));
        }

        public async Task<StudentPartialProfileDto> GetAsync(int id)
        {
            StudentEntity student = await _studentRepository.GetAsync(id);
            return new StudentPartialProfileDto(student);
        }

        public async Task<StudentPartialProfileDto> GetOrCreateAsync(int id)
        {
            StudentEntity student = await _studentRepository.ReadByIdAsync(id);
            if (student is null)
            {
                student = await _studentRepository.CreateAsync(StudentEntity.CreateFromIsu(id, "userInfo.FirstName", "userInfo.MiddleName", "userInfo.SecondName"));
                student = await _studentRepository.GetAsync(student.Id);
            }

            return new StudentPartialProfileDto(student);
        }

        public async Task<StudentPartialProfileDto> AddGithubUsernameAsync(int id, string githubUsername)
        {
            if (_studentRepository.Read().Any(s => s.GithubUsername == githubUsername))
                throw InnerLogicException.StudentEx.GithubAlreadyUser(githubUsername);

            //TODO:
            //throw new NotImplementedException("Need to validate github credentials");
            StudentEntity user = await _studentRepository.GetAsync(id);
            user.GithubUsername = githubUsername;
            await _studentRepository.UpdateAsync(user);

            //TODO:
            //_achievementProvider.Achieve(AchievementList.AddGithubAchievement, user.Id);
            user = await _studentRepository.GetAsync(id);
            return new StudentPartialProfileDto(user);
        }

        public async Task<StudentPartialProfileDto> RemoveGithubUsernameAsync(int id, string githubUsername)
        {
            StudentEntity user = await _studentRepository.GetAsync(id);
            user.GithubUsername = null;
            StudentEntity updatedUser = await _studentRepository.UpdateAsync(user);
            return new StudentPartialProfileDto(updatedUser);
        }
    }
}