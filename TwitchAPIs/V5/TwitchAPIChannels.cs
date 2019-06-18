﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.V5
{
    public class TwitchAPIChannels : TwitchAPIPart
    {
        public TwitchAPIChannels(TwitchAPI parent) : base(parent)
        {

        }

        public TwitchChannel GetChannel()
        {
            var apiRequest = new TwitchAPIRequest();
            apiRequest.Version = APIVersion.V5;
            apiRequest.Path = "channel";
            apiRequest.Method = "GET";
            var jToken = this.Parent.RequestAsJson(apiRequest);

            var channel = new TwitchChannel();
            channel.Read(jToken);

            return channel;
        }

        public TwitchChannel GetChannelByID(string channelId)
        {
            var apiRequest = new TwitchAPIRequest();
            apiRequest.Version = APIVersion.V5;
            apiRequest.Path = $"channels/{channelId}";
            apiRequest.Method = "GET";
            var jToken = this.Parent.RequestAsJson(apiRequest);

            var channel = new TwitchChannel();
            channel.Read(jToken);

            return channel;
        }

        public TwitchUser[] GetChannelEditors(string channelId)
        {
            var apiRequest = new TwitchAPIRequest();
            apiRequest.Version = APIVersion.V5;
            apiRequest.Path = $"channels/{channelId}/editors";
            apiRequest.Method = "GET";
            var jToken = this.Parent.RequestAsJson(apiRequest);

            return jToken.ReadArray("users", t => new TwitchUser().Read(t)) ?? new TwitchUser[0];
        }

        public TwitchChannelFollowers GetChannelFollowers(string channelId, int? limit = null, int? offset = null, string cursor = null, SortDirection? direction = null)
        {
            var apiRequest = new TwitchAPIRequest();
            apiRequest.Version = APIVersion.V5;
            apiRequest.Path = $"channels/{channelId}/follows";
            apiRequest.Method = "GET";
            apiRequest.QueryValues.Add("limit", limit);
            apiRequest.QueryValues.Add("offset", offset);
            apiRequest.QueryValues.Add("cursor", cursor);
            apiRequest.QueryValues.Add("direction", direction);
            var jToken = this.Parent.RequestAsJson(apiRequest);

            return new TwitchChannelFollowers().Read(jToken);
        }

    }

}
