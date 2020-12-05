﻿using Iwentys.Features.Students.Entities;

namespace Iwentys.Features.Guilds.Entities
{
    public class GuildRecruitmentMemberEntity
    {
        public int GuildRecruitmentId { get; set; }
        public GuildRecruitmentEntity GuildRecruitment { get; set; }

        public int MemberId { get; set; }
        public StudentEntity Member { get; set; }
    }
}