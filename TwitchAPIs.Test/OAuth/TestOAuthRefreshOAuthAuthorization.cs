﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchAPIs.OAuth;

namespace TwitchAPIs.Test.OAuth
{
    [TwitchAPITest("OAuth", "Authorization")]
    public class TestOAuthRefreshOAuthAuthorization : TestAbstract
    {
        public override void Run(TestMain main)
        {
            var user = main.User;
            var handler = main.TwitchAPIHandler;

            var api = handler.API;
            var authRequest = handler.OAuthRequest;
            var authorization = handler.OAuthAuthorization;

            if (authorization.RefreshToken != null && authRequest is OAuthRequestAuthorization auth)
            {
                var oAuth = handler.OAuthAuthorization = api.Authentication.RefreshAccessTokens(authorization.RefreshToken, auth.ClientSecret);
                api.AccessToken = oAuth.AccessToken;

                main.PrintReflection(user, "Refreshed OAuthAuthorization", oAuth);
            }

        }

    }

}
