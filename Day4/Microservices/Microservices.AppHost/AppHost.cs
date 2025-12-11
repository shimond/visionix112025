var builder = DistributedApplication.CreateBuilder(args);

var paymentApi = builder.AddProject<Projects.Payment_Api>("payment-api");

var smsApi = builder.AddProject<Projects.SmsManagment>("smsmanagment");

builder.AddProject<Projects.Mobile_BFF>("mobile-bff")
        .WithReference(smsApi)
        .WithReference(paymentApi)
        .WaitFor(smsApi)
        .WaitFor(paymentApi);

builder.Build().Run();
