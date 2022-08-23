var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPooledDbContextFactory<AppDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("CommandConStr"))
);

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddSubscriptionType<Subscription>()
    .AddType<PlatformType>()
    .AddType<AddPlatformInputType>()
    .AddType<AddPlatformPayloadType>()
    .AddType<CommandType>()
    .AddType<AddCommandInputType>()
    .AddType<AddCommandPayloadType>()
    .AddFiltering()
    .AddSorting()
    .AddInMemorySubscriptions();

var app = builder.Build();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL();
    endpoints.MapGraphQLVoyager("ui/voyager");
});

app.Run();
