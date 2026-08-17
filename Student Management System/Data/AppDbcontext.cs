using Microsoft.EntityFrameworkCore;

using Student_Management_System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System.Data
{
    public class AppDbcontext : DbContext
    {

        public AppDbcontext(DbContextOptions<AppDbcontext> options): base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Instructor> Instructors { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Student ↔ Course (Many-to-Many)
            modelBuilder.Entity<Student>()
                .HasMany(s => s.Courses)
                .WithMany(c => c.Students);

            // Instructor → Course (One-to-Many)
            modelBuilder.Entity<Instructor>()
                .HasMany(i => i.Courses)
                .WithOne(c => c.Instructor)
                .HasForeignKey(c => c.InstructorId)
                .OnDelete(DeleteBehavior.Restrict);
     
        modelBuilder.Entity<Student>().HasKey(s => s.Id);
            modelBuilder.Entity<Student>().Property(s => s.FullName).HasColumnName("Name");

            modelBuilder.Entity<Student>().Property(s => s.Percentage).HasColumnType("decimal(4,2)");
            modelBuilder.Entity<Student>().ToTable("students", table =>
            {
                table.HasCheckConstraint(
    "CK_Student_Email",
    "[Email] LIKE '%@%.%'"
);


                table.HasCheckConstraint(
                    "CK_Student_Age", " [Age] >=16"
                    );

            });

            modelBuilder.Entity<Course>().HasKey(c => c.Id);

            modelBuilder.Entity<Course>().Property(c => c.Description)
                .HasColumnName("Descriptoin")
                .HasColumnType("varchar(150)")
                .HasMaxLength(150);


            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    Id = 1,
                    FullName = "Ahmed Ali",
                    Email = "ahmed@gmail.com",
                    Percentage = 85.50m,
                    Age = 20,
                    
                },

                new Student
                {
                    Id = 2,
                    FullName = "Sara Mohamed",
                    Email = "sara@gmail.com",
                    Age = 19,
                    Percentage = 91.25m
                },

                new Student
                {
                    Id = 3,
                    FullName = "Omar Hassan",
                    Email = "omar@gmail.com",
                    Age = 21,
                    Percentage = 78.75m
                },

                new Student
                {
                    Id = 4,
                    FullName = "Mona Ahmed",
                    Email = "mona@gmail.com",
                    Age = 18,
                    Percentage = 88.00m
                },

                new Student
                {
                    Id = 5,
                    FullName = "Youssef Ali",
                    Email = "youssef@gmail.com",
                    Age = 22,
                    Percentage = 95.50m
                },

                new Student
                {
                    Id = 6,
                    FullName = "Nour Khaled",
                    Email = "nour@gmail.com",
                    Age = 20,
                    Percentage = 82.25m
                },

                new Student
                {
                    Id = 7,
                    FullName = "Hana Samir",
                    Email = "hana@gmail.com",
                    Age = 19,
                    Percentage = 90.00m
                },

                new Student
                {
                    Id = 8,
                    FullName = "Mahmoud Adel",
                    Email = "mahmoud@gmail.com",
                    Age = 23,
                    Percentage = 76.50m
                },

                new Student
                {
                    Id = 9,
                    FullName = "Laila Hassan",
                    Email = "laila@gmail.com",
                    Age = 18,
                    Percentage = 93.75m
                },

                new Student
                {
                    Id = 10,
                    FullName = "Khaled Mostafa",
                    Email = "khaled@gmail.com",
                    Age = 21,
                    Percentage = 87.50m
                }



            );

            modelBuilder.Entity<Instructor>().HasData(
                new Instructor
                {
                    Id = 1,
                    Name = "Mohamed Ahmed",
                    Email = "mohamed@gmail.com",
                    Specialization = "C# Programming"
                },
                new Instructor
                {
                    Id = 2,
                    Name = "Ahmed Hassan",
                    Email = "ahmed@gmail.com",
                    Specialization = "Database Systems"
                },
                new Instructor
                {
                    Id = 3,
                    Name = "Omar Ali",
                    Email = "omar@gmail.com",
                    Specialization = "Web Development"
                }
            );


           


            modelBuilder.Entity<Course>().HasData(
            new Course
      {
          Id = 1,
          Name = "C# Programming",
          Description = "Introduction to C# programming",
          DurationInHours = 40,
           InstructorId = 1

            },

      new Course
      {
          Id = 2,
          Name = "Database Systems",
          Description = "Introduction to databases and SQL",
          DurationInHours = 35,
          InstructorId=2
      },

      new Course
      {
          Id = 3,
          Name = "Data Structures",
          Description = "Arrays, linked lists, stacks, queues and trees",
          DurationInHours = 45,
          InstructorId=1
      },

      new Course
      {
          Id = 4,
          Name = "Web Development",
          Description = "Fundamentals of web development",
          DurationInHours = 50,
          InstructorId = 2
      },

      new Course
      {
          Id = 5,
          Name = "Software Engineering",
          Description = "Software development principles and practices",
          DurationInHours = 30,
          InstructorId = 1
      }
  );
















        }
    }
}
