﻿
using Iwentys.Common.Databases;
using Iwentys.Database.Seeding.FakerEntities;
using Iwentys.Features.AccountManagement.Domain;
using Iwentys.Features.AccountManagement.Entities;
using Iwentys.Features.GithubIntegration.Entities;
using Iwentys.Features.GithubIntegration.Models;
using Iwentys.Features.Study.Entities;

namespace Iwentys.Tests.TestCaseContexts
{
    public partial class TestCaseContext
    {
        public TestCaseContext WithStudentProject(AuthorizedUser userInfo, out GithubProject githubProject)
        {
            IwentysUser student = UnitOfWork.GetRepository<Student>().GetById(userInfo.Id).Result;
            GithubUser githubUser = GithubIntegrationService.UserApiApiAccessor.FindGithubUser(userInfo.Id).Result;
            GithubRepositoryInfoDto repositoryInfo = GithubRepositoryFaker.Instance.Generate(student.GithubUsername);

            githubProject = new GithubProject(githubUser, repositoryInfo);
            //FYI: force EF to generate unique id
            githubProject.Id = 0;

            UnitOfWork.GetRepository<GithubProject>().InsertAsync(githubProject).Wait();
            UnitOfWork.CommitAsync().Wait();

            return this;
        }
    }
}
