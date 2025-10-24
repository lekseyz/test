var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.test_Web>("web");

builder.Build().Run();
