using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife.Client.Services
{
    public class Constants
    {
        public static readonly string ContentType = "application/json";
        private static readonly string Port = "65306";
        private static readonly string ServerBaseUrl = string.Format("http://localhost:{0}/", Port);

        public static readonly string NextGeneration = ServerBaseUrl + "api/game/NextGeneration";

    }
}