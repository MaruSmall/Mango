﻿using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using static Mango.Web.Const;

namespace Mango.Web.Models
{
    public class ApiRequest
    {
        public ApiType ApiType { get; set; } = ApiType.GET;

        public string Url { get; set; }

        public object Data { get; set; }

        public string AccessToken { get; set; }
    }
}
