using Microsoft.EntityFrameworkCore;
using AutoManage.Models;

namespace AutoManage.Data

/*
Long comment about how DbContext and stuff works bellow, skip if you dont care

Alright so, think of "DbContext" as the database itself, "DbSet" as the table and "Vehicle" as the row, why:
"Vehicle" (the class) represents a single entity ONE car aka ONE tuple, since in this context our classes are 
effectively just the structure of the elements we can use SQL terminology and just say they are our columns,
that means that when we actually put data in them they become a list of n elements which is a tuple aka a row.
"DbSet" is CONCEPTUALLY just a list that stores our classes (which are rows), and what stores rows? A table.
All these "DbSet" lists are properties stored inside "DbContext" and what encapsulates tables is the database.
And finally in this analogy "AppDbContext" is the database session, .NET uses a scoped lifetime for "DbContext"
that means that a new "AppDbContext" is created every time the system sees it needs to access the database
specifically the "Dependency Injection" container handles the pipeline but that doesnt matter right now
(Which seems like it should take up way to much memory but apparently it doesnt and gives the ISOLATION of ACID)
for example the pipeline for a GET request: 

User sends a GET to the API -> Server receives the request and sees it needs the database ->
Creates a new "AppDbContext" -> Controller runs gets the data, sends it back -> Then that "AppDbContext" object
is deleted and the connection is closed

In practice a lot of these objects dont ACTUALLY function like this, but thinking about them this way 
allows for their implementation to be a lot more intuitive 
*/

{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {

        // All of the tables need to be registered here with "DbSet" to actually create them
        public DbSet<Accessory> Accessories {get;set;}
        public DbSet<Address> Addresses {get;set;}
        public DbSet<Owner> Owners {get;set;}
        public DbSet<Sale> Sales {get;set;}
        public DbSet<Salesperson> Salespeople {get;set;}
        public DbSet<Vehicle> Vehicles {get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // This doesn't do anything but it's good practice to leave it here
            base.OnModelCreating(modelBuilder);
            // Since we separated the configs of each class into differente files, we need this to scan for them
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}