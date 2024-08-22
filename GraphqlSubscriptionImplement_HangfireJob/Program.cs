using GraphqlSubscriptionImplement_HangfireJob.Data;
using GraphqlSubscriptionImplement_HangfireJob.Models;
using GraphqlSubscriptionImplement_HangfireJob.Schema.Mutations;
using GraphqlSubscriptionImplement_HangfireJob.Schema.Queries;
using GraphqlSubscriptionImplement_HangfireJob.Schema.Subscriptions;
using GraphqlSubscriptionImplement_HangfireJob.Services;
using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//DB Configuration
builder.Services.AddEntityFrameworkNpgsql().AddDbContext<ApplicationDbContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("MyWebApiConection")));

//Hangfire Configuration
builder.Services.AddHangfire(x =>
 x.SetDataCompatibilityLevel(CompatibilityLevel.Version_170).
 UseSimpleAssemblyNameTypeSerializer().
 UseRecommendedSerializerSettings().
 UsePostgreSqlStorage(builder.Configuration.GetConnectionString("MyWebApiConection")));

builder.Services.AddControllers();
builder.Services.AddScoped<StudentService>();
//builder.Services.AddTransient<IAttendenceService,AttendenceService>();
builder.Services.AddScoped<AttendenceService>();
builder.Services.AddGraphQLServer().AddQueryType<StudentQuery>().AddMutationType<StudentMutation>().AddSubscriptionType<StudentSubscription>().AddInMemorySubscriptions(); ; 


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddHangfireServer();
var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseHangfireDashboard("/dashboard");
app.UseHangfireServer();
app.UseHttpsRedirection();
app.UseRouting();
app.UseWebSockets();
app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL();
});
app.UseAuthorization();

app.MapControllers();

//RecurringJob.AddOrUpdate<StudentService>(s => s.GetAllStudents(), Cron.Hourly);
//RecurringJob.AddOrUpdate<Job>("name", s=>s. MyMethod(null), "0 0 0 * * *");


RecurringJob.AddOrUpdate<AttendenceService>("StudentAttendence", s=>s.proceedAttendece(), "0 0 0 * * *");
app.Run();
