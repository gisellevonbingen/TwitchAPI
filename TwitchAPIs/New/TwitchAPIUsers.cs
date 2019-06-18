﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TwitchAPIs.New
{
    public class TwitchAPIUsers : TwitchAPIPart
    {
        public TwitchAPIUsers(TwitchAPI parent) : base(parent)
        {

        }

        public TwitchUser UpdateUser(string description)
        {
            var apiRequest = new TwitchAPIRequest();
            apiRequest.Version = APIVersion.New;
            apiRequest.Path = "users";
            apiRequest.Method = "PUT";
            apiRequest.QueryValues.Add("description", HttpUtility.UrlEncode(description));
            var jToken = this.Parent.RequestAsJson(apiRequest);

            return this.ParseUsers(jToken).FirstOrDefault();
        }

        public TwitchUserFollows GetUserFollows(FollowsType type, string id, string cursor = null)
        {
            var apiRequest = new TwitchAPIRequest();
            apiRequest.Version = APIVersion.New;
            apiRequest.Path = "users/follows";
            apiRequest.Method = "GET";
            apiRequest.QueryValues.Add($"{type.Request}_id", id);
            apiRequest.QueryValues.Add($"after", cursor);
            var jToken = this.Parent.RequestAsJson(apiRequest);

            var uerFollows = new TwitchUserFollows();
            uerFollows.Total = jToken.Value<int>("total");
            uerFollows.Cursor = this.Parent.GetPaination(jToken)?.Cursor;
            uerFollows.Follows = jToken.ReadArray("data", t => new TwitchFollow().Read(t, type)) ?? new TwitchFollow[0];

            return uerFollows;
        }

        public TwitchUser GetUser(UserRequest request)
        {
            var users = this.GetUsers(new UserRequest[] { request });
            return users.FirstOrDefault();
        }

        public TwitchUser[] GetUsers(IEnumerable<UserRequest> requests)
        {
            var apiRequest = new TwitchAPIRequest();
            apiRequest.Version = APIVersion.New;
            apiRequest.Path = "users";
            apiRequest.Method = "GET";
            apiRequest.QueryValues.AddRange(requests.Select(r => new QueryValue(r.Type.ToString().ToLowerInvariant(), r.Value)));
            var jToken = this.Parent.RequestAsJson(apiRequest);

            return this.ParseUsers(jToken);
        }

        private TwitchUser[] ParseUsers(JToken token)
        {
            return token.ReadArray("data", t => new TwitchUser().Read(t)) ?? new TwitchUser[0];
        }

    }

}