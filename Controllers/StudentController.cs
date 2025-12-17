using Microsoft.AspNetCore.Mvc;
using MVCDemo.Models;

namespace MVCDemo.Controllers
{
    public class StudentController : Controller
    {
        // In-memory list (acts as database)
        // Index - Display the Student Details
        // Add - Add new Student
        // Edit - Edit existing Student
        // Delete - Delete existing Student
        //Table - Student (Id, Name) - inserted 2 rows
        static List<Student> students = new List<Student>()
    {
        new Student { Id = 1, Name = "John" },
        new Student { Id = 2, Name = "Anna" }
    };

        // LIST
        // Display all students
        public IActionResult Index()
        {
            return View(students); // 1,John 2,Anna
        }

        // ADD - GET
        public IActionResult Add()
        {
            return View();
        }

        // ADD - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Student student) // Akshay
        {
            student.Id = students.Max(s => s.Id) + 1; // 3
            students.Add(student); // Add Akshay to the list
            return RedirectToAction("Index");
        }

        // EDIT - GET
        public IActionResult Edit(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            return View(student);
        }

        // EDIT - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student student)
        {
            var s = students.FirstOrDefault(x => x.Id == student.Id);
            s.Name = student.Name;
            return RedirectToAction("Index");
        }

        // DELETE
        public IActionResult Delete(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            students.Remove(student);
            return RedirectToAction("Index");
        }
    }
}
