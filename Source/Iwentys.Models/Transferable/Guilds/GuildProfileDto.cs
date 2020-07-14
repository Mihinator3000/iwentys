﻿using System.Collections.Generic;
using Iwentys.Models.Entities;
using Iwentys.Models.Entities.Guilds;
using Iwentys.Models.Types.Github;
using Iwentys.Models.Types.Guilds;

namespace Iwentys.Models.Transferable.Guilds
{
    public class GuildProfileDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Bio { get; set; }
        public string LogoUrl { get; set; }

        public GuildHiringPolicy HiringPolicy { get; set; }

        public Student Leader { get; set; }
        public Student Totem { get; set; }

        public int TotalRate { get; set; }
        public List<Student> Members { get; set; }

        //TODO: add newsfeeds
        //TODO: wrap with DTO
        public Tribute Tribute { get; set; }
        public List<AchievementInfoDto> Achievements { get; set; }
        public List<GithubRepository> PinnedRepositories { get; set; }
    }
}