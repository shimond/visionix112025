var builder = DistributedApplication.CreateBuilder(args);

var paymentService = builder.AddProject<Projects.PaymentService>("paymentservice");

builder.AddProject<Projects.HttpAndMore>("httpandmore")
    .WithReference(paymentService)
    .WaitFor(paymentService);


builder.Build().Run();
