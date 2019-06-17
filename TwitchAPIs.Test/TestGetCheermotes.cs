﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.Test
{
    public class TestGetCheermotes : TestAbstract
    {
        public TestGetCheermotes()
        {

        }

        public override void Run(TestMain main)
        {
            var user = main.User;
            var handler = main.TwitchAPIHandler;

            var channelId = user.ReadInput("Enter ChannelId (Empty is global)");

            var actions = handler.API.Bits.GetCheermotes(channelId);
            main.PrintReflection(user, "Actions", actions);
        }

    }

}