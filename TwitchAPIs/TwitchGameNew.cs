﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs
{
    public class TwitchGameNew
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string BoxArtUrl { get; set; }

        public TwitchGameNew()
        {

        }

        public TwitchGameNew Read(JToken jToken)
        {
            this.Id = jToken.Value<string>("id");
            this.Name = jToken.Value<string>("name");
            this.BoxArtUrl = jToken.Value<string>("box_art_url");

            return this;
        }

    }

}
