﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPI
{
    public class TwitchFollower
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public DateTime FollowedAt { get; set; }

        public TwitchFollower()
        {

        }

    }

}
