﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.New
{
    public class TwitchStreamTags
    {
        public TwitchStreamTag[] Tags { get; set; }
        public Pagination Pagination { get; set; }

        public TwitchStreamTags()
        {

        }

    }

}
