﻿using System.Threading.Tasks;
using Iwentys.Features.Gamification.Models;
using Iwentys.Tests.TestCaseContexts;
using NUnit.Framework;

namespace Iwentys.Tests.Features.Gamification
{
    [TestFixture]
    public class KarmaServiceTest
    {
        [Test]
        public async Task AddKarma_ShouldContainUpVote()
        {
            var testCase = TestCaseContext
                .Case()
                .WithNewStudent(out var first)
                .WithNewStudent(out var second);

            await testCase.KarmaService.UpVote(first, second.Id);

            KarmaStatistic karmaStatistic = await testCase.KarmaService.GetStatistic(second.Id);

            Assert.IsTrue(karmaStatistic.UpVotes.Contains(first.Id));
        }

        [Test]
        public async Task AddAndRemoveKarma_ShouldNotContainUpVote()
        {
            var testCase = TestCaseContext
                .Case()
                .WithNewStudent(out var first)
                .WithNewStudent(out var second);

            await testCase.KarmaService.UpVote(first, second.Id);
            await testCase.KarmaService.RemoveUpVote(first, second.Id);

            KarmaStatistic karmaStatistic = await testCase.KarmaService.GetStatistic(second.Id);

            Assert.IsFalse(karmaStatistic.UpVotes.Contains(first.Id));
        }
    }
}