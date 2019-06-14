﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TwitchAPIs.Test
{
    public class TestGetUserFollows : TestAbstract
    {
        public TestGetUserFollows()
        {

        }

        public override void Run(TestMain main)
        {
            var user = main.User;
            var handler = main.TwitchAPIHandler;

            var followsTypes = new Dictionary<FollowsType, string>
            {
                { FollowsType.From ,"XXX followed from id, Followings" },
                { FollowsType.To , "XXX follow to id, Followers" }
            }.ToArray();

            var userId = user.ReadInput("UserId");
            var input = user.QueryInput("Enter FollowsType", followsTypes.Select(pair => pair.Value));
            var followsType = followsTypes[input].Key;

            var api = handler.API;
            string cursor = null;

            while (true)
            {
                var userFollows = api.Users.GetUserFollows(followsType, userId, cursor);
                main.PrintReflection(user, "UserFollows", userFollows);

                cursor = userFollows.Cursor;

                if (cursor == null)
                {
                    break;
                }

                Thread.Sleep(1000);
            }

        }

    }

}