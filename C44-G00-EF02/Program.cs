using C44_G00_EF02;
using C44_G00_EF02.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace C44_G00_EF02
{
    internal class Program
    {
        static void Main(string[] args)
        {
           using ITIDbContext context = new ITIDbContext();
            // ITIDataSeeding.DataSeeding(context);

            #region LoadingRelatedData.
            #region Eager Loading.
            #region Example 01
            // get me all related data (good for DataBase but bad for application because i get data i don't need and make it slow)
            //var StudentWithDept = context.Students.Include(D=>D.Department).FirstOrDefault(S => S.ID == 15);
            //if(StudentWithDept != null)
            //{
            //    Console.WriteLine($"StudentID = {StudentWithDept.ID}");
            //    Console.WriteLine($"StudentName : {StudentWithDept.FName} {StudentWithDept.LName}");
            //    Console.WriteLine($"DepartmentID = {StudentWithDept.Dep_Id}");
            //    Console.WriteLine($"DepartmentName : {StudentWithDept.Department?.Name}");
            //} 
            #endregion
            #region Example 02
            // ThenInclude.[studentInfo+Dept+StudentGrade from StudCourses]
            //var StudentWithDept = context.Students.Include(S => S.Department).Include(S=>S.StudCourses).ThenInclude(src=>src.Course).FirstOrDefault(S => S.ID == 15);
            //if (StudentWithDept != null)
            //{
            //    Console.WriteLine($"StudentID = {StudentWithDept.ID}");
            //    Console.WriteLine($"StudentName : {StudentWithDept.FName} {StudentWithDept.LName}");
            //    Console.WriteLine($"DepartmentID = {StudentWithDept.Dep_Id}");
            //    Console.WriteLine($"DepartmentName : {StudentWithDept.Department?.Name}");
            //    Console.WriteLine(new string('-',59));

            //}

            #endregion
            #region Example 03[Getting the students in the Dept => 1 (cs)]
            //var StudentsWithDepts = context.Students.Include(S => S.Department)
            //    .Where(S => S.Department.ID == 1)
            //    .Select(S => new
            //    {
            //        StudentName = S.FName,
            //        DepartmentName = S.Department.Name
            //    }).ToList();
            //if (StudentsWithDepts is not null)
            //{
            //    StudentsWithDepts.ForEach(x => Console.WriteLine(x));
            //}
            #endregion

            #endregion

            #region Explicit Loading.
            #region Example 01
            //var StudentWithDept = context.Students.Include(D => D.Department).FirstOrDefault(S => S.ID == 15);
            //context.Entry(StudentWithDept).Reference(D => D.Department).Load();
            //if (StudentWithDept != null)
            //{
            //    Console.WriteLine($"StudentID = {StudentWithDept.ID}");
            //    Console.WriteLine($"StudentName : {StudentWithDept.FName} {StudentWithDept.LName}");
            //    Console.WriteLine($"DepartmentID = {StudentWithDept.Dep_Id}");
            //    Console.WriteLine($"DepartmentName : {StudentWithDept.Department?.Name}");
            //}
            #endregion
            #region Example 02
            //var DepartementsWithStudents = context.Departments.FirstOrDefault(D => D.ID == 1);
            //if(DepartementsWithStudents != null)
            //{
            //    Console.WriteLine($"DepartmentName : {DepartementsWithStudents.Name}");
            //    context.Entry(DepartementsWithStudents).Collection(D=>D.Students).Load();
            //    foreach(var item in DepartementsWithStudents.Students)
            //    {
            //        Console.WriteLine(item);
            //    }
            //}
            #endregion
            #endregion

            #region Lazy Loading.
            //var StudentWithDept = context.Students.Include(D => D.Department).FirstOrDefault(S => S.ID == 15);
            //if (StudentWithDept != null)
            //{
            //    Console.WriteLine($"StudentID = {StudentWithDept.ID}");
            //    Console.WriteLine($"StudentName : {StudentWithDept.FName} {StudentWithDept.LName}");
            //    Console.WriteLine($"DepartmentID = {StudentWithDept.Dep_Id}");
            //    Console.WriteLine($"DepartmentName : {StudentWithDept.Department?.Name}");
            //}
            #endregion
            #endregion

            #region Joins.
            #region Inner Join
            //Console.WriteLine("=== Example 1: Inner Join - Students with Departments ===");

            //var studentsWithDepartments = context.Students
            //    .Join(context.Departments,
            //          student => student.Dep_Id,      // Student foreign key
            //          department => department.ID,     // Department primary key
            //          (student, department) => new     // Result selector
            //          {
            //              StudentID = student.ID,
            //              StudentName = student.FName + " " + student.LName,
            //              DepartmentName = department.Name,
            //              StudentAge = student.Age
            //          })
            //    .ToList();

            //foreach (var item in studentsWithDepartments)
            //{
            //    Console.WriteLine($"ID: {item.StudentID} - {item.StudentName} ({item.StudentAge}) - Dept: {item.DepartmentName}");
            //}
            #endregion
            #region Multiple Join
            //Console.WriteLine("\n=== Example 2: Multiple Joins - Students with Course Topics ===");

            //var studentCoursesWithTopics = context.Students
            //    .Join(context.StudCourses,
            //          student => student.ID,
            //          studCourse => studCourse.Stud_ID,
            //          (student, studCourse) => new { student, studCourse })
            //    .Join(context.Courses,
            //          temp => temp.studCourse.Course_ID,
            //          course => course.ID,
            //          (temp, course) => new { temp.student, temp.studCourse, course })
            //    .Join(context.Topics,
            //          temp => temp.course.Top_ID,
            //          topic => topic.ID,
            //          (temp, topic) => new
            //          {
            //              StudentName = temp.student.FName + " " + temp.student.LName,
            //              CourseName = temp.course.Name,
            //              TopicName = topic.Name,
            //              Grade = temp.studCourse.Grade,
            //              Duration = temp.course.Duration
            //          })
            //    .ToList();

            //foreach (var item in studentCoursesWithTopics)
            //{
            //    Console.WriteLine($"{item.StudentName} - {item.CourseName} ({item.TopicName}) - Grade: {item.Grade ?? "N/A"} - {item.Duration}h");
            //}
            #endregion
            #region Left Join.
            //Console.WriteLine("\n=== Example 3: Left Join - Departments with Managers ===");

            //var departmentsWithManagers = context.Departments
            //    .GroupJoin(context.Instructors,
            //               dept => dept.Ins_ID,          // Department manager ID
            //               instructor => instructor.ID,   // Instructor ID
            //               (dept, instructors) => new { dept, instructors })
            //    .SelectMany(temp => temp.instructors.DefaultIfEmpty(), // This creates the LEFT JOIN
            //                (temp, instructor) => new
            //                {
            //                    DepartmentName = temp.dept.Name,
            //                    ManagerName = instructor != null ? instructor.Name : "No Manager",
            //                    HiringDate = temp.dept.HiringDate,
            //                    ManagerSalary = instructor != null ? instructor.Salary : 0
            //                })
            //    .ToList();

            //foreach (var item in departmentsWithManagers)
            //{
            //    Console.WriteLine($"Dept: {item.DepartmentName} - Manager: {item.ManagerName} - Hired: {item.HiringDate:yyyy-MM-dd} - Salary: ${item.ManagerSalary}");
            //}
            #endregion
            #endregion

            #region CRUD OPERATIONS.
            // i have inserted using json files 
            // i have Read data while using loading and joins.
            #region Update.
            //var UpdatedStudent = (from S in context.Students
            //                     where S.ID == 16
            //                     select S).FirstOrDefault();
            //Console.WriteLine(context.Entry(UpdatedStudent).State);
            //UpdatedStudent.FName = "Belal";
            //Console.WriteLine(context.Entry(UpdatedStudent).State);
            //context.SaveChanges();
            #endregion
            #region Delete
            //var DeletedStudent = (from S in context.Students
            //                      where S.ID == 16
            //                      select S).FirstOrDefault();
            //Console.WriteLine(context.Entry(DeletedStudent).State);
            //context.Students.Remove(DeletedStudent);  // Localy Deleted
            //context.SaveChanges();
            //Console.WriteLine(context.Entry(DeletedStudent).State);
            #endregion
            #endregion
        }
    }
}
