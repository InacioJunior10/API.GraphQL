﻿namespace CommanderGQL.GraphQL;

public class Query
{
    [UseDbContext(typeof(AppDbContext))]
    public IQueryable<Platform> GetPlatform([ScopedService] AppDbContext context)
    {
        return context.Platform;
    }
}