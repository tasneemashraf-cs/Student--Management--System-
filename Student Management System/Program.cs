using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Student_Management_System;
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

//var student = new Student
//{
//    FullName = "Ahmed Ali",
//    Email = "ahmed@gmail.com",
//    Age = 21,
//    Percentage = 85.5m
//};

//context.Students.Add(student);
//context.SaveChanges();

//Console.WriteLine("Student added successfully!");


////read
//var students = context.Students.ToList();

//foreach (var s in students)
//{
//    Console.WriteLine(
//        $"Id: {s.Id}, " +
//        $"Name: {s.FullName}, " +
//        $"Email: {s.Email}, " +
//        $"Age: {s.Age}, " +
//        $"Percentage: {s.Percentage}");
//}

////update
//var studentToUpdate = context.Students.Find(1);

//if (studentToUpdate == null)
//{
//    Console.WriteLine("Student not found!");
//}
//else
//{
//    studentToUpdate.FullName = "Ahmed Mohamed";
//    studentToUpdate.Percentage = 90;

//    context.SaveChanges();

//    Console.WriteLine("Student updated successfully!");
//}


//var studentToDelete = context.Students.Find(1);

//if (studentToDelete == null)
//{
//    Console.WriteLine("Student not found!");
//}
//else
//{
//    context.Students.Remove(studentToDelete);

//    context.SaveChanges();

//    Console.WriteLine("Student deleted successfully!");
//}

//var course = new Course
//{
//    Name = "Entity Framework Core",
//    Description = "Learning Entity Framework Core",
//    DurationInHours = 30,
//    InstructorId = 1
//};

//context.Courses.Add(course);
//context.SaveChanges();

//Console.WriteLine("Course added successfully!");


////read
//var courses = context.Courses
//    .Include(c => c.Instructor)
//    .ToList();

//foreach (var c in courses)
//{
//    Console.WriteLine(
//        $"Id: {c.Id}, " +
//        $"Name: {c.Name}, " +
//        $"Duration: {c.DurationInHours} Hours, " +
//        $"Instructor: {c.Instructor.Name}");
//}

//// update
//var courseToUpdate = context.Courses.Find(1);

//if (courseToUpdate == null)
//{
//    Console.WriteLine("Course not found!");
//}
//else
//{
//    courseToUpdate.Name = "Advanced Entity Framework Core";
//    courseToUpdate.DurationInHours = 40;

//    context.SaveChanges();

//    Console.WriteLine("Course updated successfully!");
//}

////delete


//var courseToDelete = context.Courses.Find(1);

//if (courseToDelete == null)
//{
//    Console.WriteLine("Course not found!");
//}
//else
//{
//    context.Courses.Remove(courseToDelete);
//    context.SaveChanges();

//    Console.WriteLine("Course deleted successfully!");
//}


//Create Instructor

//var instructor = new Instructor
//{
//    Name = "Mohamed Ahmed",
//    Email = "mohamed@gmail.com",
//    Specialization = "Backend Development"
//};

//context.Instructors.Add(instructor);
//context.SaveChanges();

//Console.WriteLine("Instructor added successfully!");

//// read

//var instructors = context.Instructors
//    .Select(i => new
//    {
//        i.Id,
//        i.Name
//    })
//    .ToList();

//foreach (var instructor1 in instructors)
//{
//    Console.WriteLine(
//        $"Instructor Id: {instructor1.Id} | Name: {instructor1.Name}");
//}
//COURSES 

//Console.WriteLine("========== COURSES ==========");

//var courses1 = context.Courses
//    .Select(c => new
//    {
//        c.Id,
//        c.Name,
//        c.InstructorId
//    })
//    .ToList();

//foreach (var course1 in courses1)
//{
//    Console.WriteLine(
//        $"Course Id: {course1.Id} | " +
//        $"Name: {course1.Name} | " +
//        $"InstructorId: {course1.InstructorId}");
//}

//student detials


//var student = context.Students
//    .Include(s => s.Courses)
//        .ThenInclude(c => c.Instructor)
//    .FirstOrDefault(s => s.Id == 2);

//if (student == null)
//{
//    Console.WriteLine("Student not found!");
//}
//else
//{
//    Console.WriteLine($"Student: {student.FullName}");
//    Console.WriteLine($"Email: {student.Email}");
//    Console.WriteLine($"Age: {student.Age}");
//    Console.WriteLine($"Percentage: {student.Percentage}");

//    Console.WriteLine("Courses:");

//    foreach (var course1 in student.Courses)
//    {
//        Console.WriteLine($"Course: {course1.Name}");
//        Console.WriteLine($"Instructor: {course1.Instructor.Name}");
//        Console.WriteLine("-------------------");
//    }
//}
//var student1 = context.Students
//    .Include(s => s.Courses)
//    .FirstOrDefault(s => s.Id == 2);

//var course1 = context.Courses
//    .FirstOrDefault(c => c.Id == 2);

//var course2 = context.Courses
//    .FirstOrDefault(c => c.Id == 3);

//if (student1 == null || course1 == null || course2 == null)
//{
//    Console.WriteLine("Student or Course not found!");
//}
//else
//{
//    student1.Courses.Add(course1);
//    student1.Courses.Add(course2);

//    context.SaveChanges();

//    Console.WriteLine("Courses assigned successfully!");
//}



//Course Details

//var course = context.Courses
//    .Include(c => c.Instructor)
//    .Include(c => c.Students)
//    .FirstOrDefault(c => c.Id == 2);

//if (course == null)
//{
//    Console.WriteLine("Course not found!");
//}
//else
//{
//    Console.WriteLine($"Course: {course.Name}");
//    Console.WriteLine($"Description: {course.Description}");
//    Console.WriteLine($"Duration: {course.DurationInHours} Hours");

//    Console.WriteLine("Instructor:");
//    Console.WriteLine(course.Instructor.Name);

//    Console.WriteLine("Students:");

//    foreach (var student1 in course.Students)
//    {
//        Console.WriteLine($"- {student1.FullName}");
//    }
//}

//Display all students with their enrolled courses

//Console.WriteLine("========== STUDENTS AND COURSES ==========");

//var studentsWithCourses = context.Students
//    .Include(s => s.Courses)
//    .ToList();

//foreach (var student in studentsWithCourses)
//{
//    Console.WriteLine($"Student: {student.FullName}");

//    foreach (var course in student.Courses)
//    {
//        Console.WriteLine($"- {course.Name}");
//    }

//    Console.WriteLine("----------------------");
//}

//Display all courses with their instructor

//Console.WriteLine("========== COURSES AND INSTRUCTORS ==========");

//var coursesWithInstructor = context.Courses
//    .Include(c => c.Instructor)
//    .ToList();

//foreach (var course in coursesWithInstructor)
//{
//    Console.WriteLine($"Course: {course.Name}");
//    Console.WriteLine($"Instructor: {course.Instructor.Name}");
//    Console.WriteLine("----------------------");
//}

//All Instructors with the Courses they teach

//Console.WriteLine("========== INSTRUCTORS AND COURSES ==========");

//var instructorsWithCourses = context.Instructors
//    .Include(i => i.Courses)
//    .ToList();

//foreach (var instructor in instructorsWithCourses)
//{
//    Console.WriteLine($"Instructor: {instructor.Name}");
//    Console.WriteLine($"Specialization: {instructor.Specialization}");

//    Console.WriteLine("Courses:");

//    foreach (var course in instructor.Courses)
//    {
//        Console.WriteLine($"- {course.Name}");
//    }

//    Console.WriteLine("----------------------");
//}


//Search Student by Name
//Console.WriteLine("========== SEARCH STUDENT ==========");

//string searchName = "Sara";

//var studentSearch = context.Students
//    .Include(s => s.Courses)
//        .ThenInclude(c => c.Instructor)
//    .FirstOrDefault(s => s.FullName.Contains(searchName));

//if (studentSearch == null)
//{
//    Console.WriteLine("Student not found!");
//}
//else
//{
//    Console.WriteLine($"Student: {studentSearch.FullName}");
//    Console.WriteLine($"Email: {studentSearch.Email}");

//    Console.WriteLine("Courses:");

//    foreach (var course in studentSearch.Courses)
//    {
//        Console.WriteLine($"Course: {course.Name}");
//        Console.WriteLine($"Instructor: {course.Instructor.Name}");
//        Console.WriteLine("----------------------");
//    }
//}

//Find the number of students enrolled in each course

//Console.WriteLine("========== NUMBER OF STUDENTS IN EACH COURSE ==========");

//var courseStudentCount = context.Courses
//    .Select(c => new
//    {
//        CourseName = c.Name,
//        StudentCount = c.Students.Count()
//    })
//    .ToList();

//foreach (var course in courseStudentCount)
//{
//    Console.WriteLine(
//        $"Course: {course.CourseName} | " +
//        $"Students: {course.StudentCount}");
//}

//Number of Courses taught by each Instructor

//Console.WriteLine("========== NUMBER OF COURSES FOR EACH INSTRUCTOR ==========");

//var instructorCourseCount = context.Instructors
//    .Select(i => new
//    {
//        InstructorName = i.Name,
//        CourseCount = i.Courses.Count()
//    })
//    .ToList();

//foreach (var instructor in instructorCourseCount)
//{
//    Console.WriteLine(
//        $"Instructor: {instructor.InstructorName} | " +
//        $"Courses: {instructor.CourseCount}");
//}
