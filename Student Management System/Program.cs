using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Student_Management_System.Data;



var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();



var connectionString = config.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

var options = new DbContextOptionsBuilder<AppDbcontext>()
    .UseSqlServer(connectionString)
    .Options;


using var context = new AppDbcontext(options);


    
