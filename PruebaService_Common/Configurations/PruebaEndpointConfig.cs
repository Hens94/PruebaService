﻿namespace PruebaService_Common.Configurations
{
    public class PruebaEndpointConfig
    {
        public string Base { get; set; }
        public Resources Resources { get; set; }
    }

    public class Resources
    {
        public string People { get; set; }
        public string Planet { get; set; }
    }
}
