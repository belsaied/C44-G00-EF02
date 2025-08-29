using C44_G00_EF02.DbContexts;
using C44_G00_EF02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace C44_G00_EF02
{
    public static  class ITIDataSeeding
    {
        public static bool DataSeeding(ITIDbContext dbContext)
        {

			try
			{
				#region Seeding Topics.
				dbContext.ChangeTracker.Clear();
				if (!dbContext.Topics.Any())
				{
					var TopicsData = File.ReadAllText("DataSeeding\\Topics.json");
					var Topics = JsonSerializer.Deserialize<List<Topic>>(TopicsData);
					if (Topics?.Count > 0)
					{
						dbContext.AddRange(Topics);
						dbContext.SaveChanges();
					}
					return true;
				}
				#endregion
				#region Seeding_Departments.
				dbContext.ChangeTracker.Clear();
				if (!dbContext.Departments.Any())
				{
					var DepartmentsData = File.ReadAllText("DataSeeding\\Departments.json");
					var Departments = JsonSerializer.Deserialize<List<Department>>(DepartmentsData);
					if (Departments?.Count > 0)
					{
						dbContext.AddRange(Departments);
						dbContext.SaveChanges();
						Console.WriteLine($" Seeded Departments are {Departments.Count}successfully ");
					}
					return true;
				}
				#endregion
				#region Instructors_seeding.

				dbContext.ChangeTracker.Clear();
				if (!dbContext.Instructors.Any())
				{
					var InstructorsData = File.ReadAllText("DataSeeding\\Instructors.json");
					var Instructors = JsonSerializer.Deserialize<List<Instructor>>(InstructorsData);
					if (Instructors?.Count > 0)
					{
						dbContext.AddRange(Instructors);
						dbContext.SaveChanges();
						Console.WriteLine($"Successfully seeded {Instructors.Count} Instrucors");
					}
					return true;
				}
				#endregion
				#region Courses seeding [courses - Departments]
				dbContext.ChangeTracker.Clear();
				if (!dbContext.Courses.Any())
				{
					var CoursesData = File.ReadAllText("DataSeeding\\Courses.json");
					var Courses = JsonSerializer.Deserialize<List<Course>>(CoursesData);
					if (Courses?.Count > 0)
					{
						dbContext.AddRange(Courses);
						dbContext.SaveChanges();
						Console.WriteLine($"Successfully added {Courses.Count} Courses");
					}
				}
				#endregion
				#region Seeding Students
				dbContext.ChangeTracker.Clear();
				if (!dbContext.Students.Any())
				{
					var StudentsData = File.ReadAllText("DataSeeding\\Students.json");
					var Students = JsonSerializer.Deserialize<List<Student>>(StudentsData);
					if(Students?.Count > 0)
					{
						dbContext.AddRange(Students);
						dbContext.SaveChanges();
                        Console.WriteLine($"Successfully Added {Students.Count} Students");
					}
					return true;
				}
				#endregion
				#region Course-Instructor Seeding.
				dbContext.ChangeTracker.Clear();
				if (!dbContext.CourseInstructors.Any())
				{
					var src_InstructorsData = File.ReadAllText("DataSeeding\\CourseInstructors.json");
					var src_Instructors = JsonSerializer.Deserialize<List<CourseInst>>(src_InstructorsData);
					if(src_Instructors?.Count > 0)
					{
						dbContext.AddRange(src_Instructors);
						dbContext.SaveChanges();
                        Console.WriteLine($"Successfully Added ");
					}
					return true;
				}
				#endregion
				#region Student_Course Seeding.
				dbContext.ChangeTracker.Clear();
				if (!dbContext.StudCourses.Any())
				{
					var StudentCoursesData = File.ReadAllText("DataSeeding\\StudCourses.json");
					var StudentCourses = JsonSerializer.Deserialize<List<StudCourse>>(StudentCoursesData);
					if(StudentCourses?.Count > 0)
					{
						dbContext.AddRange(StudentCourses);
						dbContext.SaveChanges();
						Console.WriteLine("Added Successfully");
					}
				}
				#endregion
				return false;
				
			}
			catch (Exception ex)
			{
				Console.WriteLine($" Seeding failed: {ex.Message}");
				if (ex.InnerException != null)
					Console.WriteLine($"Inner exception: {ex.InnerException.Message}");
				return false;
			} 
			

			
		}
    }
}
