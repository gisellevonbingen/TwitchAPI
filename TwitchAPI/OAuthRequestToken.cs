﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPI
{
    public class OAuthRequestToken : OAuthRequest
    {
        public OAuthRequestToken()
        {

        }

        public override string ResponseType => OAuthResponseType.Token;
    }

}
