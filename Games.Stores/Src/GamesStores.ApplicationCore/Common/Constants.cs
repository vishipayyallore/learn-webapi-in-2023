﻿namespace GamesStores.ApplicationCore.Common;

public static class Constants
{

    public static class GameEndpointNames
    {
        public static string GetGameByIdName => "GetGameById";
    }

    public static class GameEndpointRoutes
    {
        public static string Prefix => "/games";

        public static string Root => "/";

        public static string ActionById => "/{id}";
    }

    public static class ConfigurationConnectionStrings
    {
        public static string GamesStoreConnectionString => "GamesStoreConnectionString";
    }

}
