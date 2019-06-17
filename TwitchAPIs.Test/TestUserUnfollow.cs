﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.Test
{
    public class TestUserUnfollow : TestAbstract
    {
        public TestUserUnfollow()
        {

        }

        public override void Run(TestMain main)
        {
            var user = main.User;
            var handler = main.TwitchAPIHandler;

            var userId = user.ReadInput("Enter UserId");
            var channelId = user.ReadInput("Enter ChannelId");
            handler.API.Users.UnfollowChannel(userId, channelId);

            user.SendMessage("Unfollowed");
        }

    }

}
