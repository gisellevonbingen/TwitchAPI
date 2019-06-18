﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.V5
{
    public class TwitchChannelFollow
    {
        public DateTime CreatedAt { get; set; }
        public bool Notifications { get; set; }
        public TwitchUser User { get; set; }

        public TwitchChannelFollow()
        {

        }

        public TwitchChannelFollow Read(JToken jToken)
        {
            this.CreatedAt = jToken.Value<DateTime>("created_at");
            this.Notifications = jToken.Value<bool>("notifications");
            this.User = new TwitchUser().Read(jToken["user"]);

            return this;
        }

    }

}