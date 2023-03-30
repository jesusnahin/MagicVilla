﻿using System.Net;

namespace MagicVilla_API.Modelos
{
    public class APIresponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool IsExitoso { get; set; } = true;
        public List<string> ErrorMessages { get; set; }
        public object Resultado { get; set; }

    }
}
