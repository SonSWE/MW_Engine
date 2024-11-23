﻿using Object.Core;
using System.Net;

namespace MWShare.GrpcAuthen
{
    public interface IBOAuthClient
    {
        Task<bool> ValidateFunction(string userId, string functionId, string action, string checkMode = "");
        Task<Tuple<HttpStatusCode, LoggedUser>> ValidateTokenAndFunction(string token, string functionId, string action, bool checkFunction, string checkMode = "");
        Task<Tuple<HttpStatusCode, LoggedUser>> ValidateTokenAndUrl(string token, string requestUrl, bool isCheckUrl = true);
    }
}
