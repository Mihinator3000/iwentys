﻿using Iwentys.Features.Raids.Entities;

namespace Iwentys.Features.InterestTags.Entities
{
    public class RaidInterestTag
    {
        public int RaidId { get; set; }
        public virtual Raid Raid { get; set; }

        public int InterestTagId { get; set; }
        public virtual InterestTag InterestTag { get; set; }
    }
}