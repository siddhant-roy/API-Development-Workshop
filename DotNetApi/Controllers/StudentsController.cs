using DotNetApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        List<Student> allStudents = new List<Student>()
        {
            new Student() {Id=1, Name="Pappu", RegNo=1042},
            new Student() {Id=2, Name="Sid", RegNo=1181},
            new Student() {Id=3, Name="Chintu", RegNo=1111},
            new Student() {Id=4, Name="Pratik", RegNo=1169},
        };

        [HttpGet]
        public IActionResult GetAllStudents()
        {
            if (allStudents.Count == 0)
                return NotFound("No students");
            return Ok(allStudents);
        }

        [HttpGet("GetStudent")]
        public IActionResult GetStudent(int id)
        {
            var student = allStudents.SingleOrDefault( x => x.Id == id );
            if (student == null) return NotFound("Not found");
            return Ok(student);
        }

        [HttpPost]
        public IActionResult Save(Student student)
        {
            allStudents.Add(student);
            return Ok(allStudents);
        }

        [HttpDelete]
        public IActionResult DeleteStudent(int id)
        {
            var student = allStudents.SingleOrDefault(x => x.Id == id);
            if (student == null) return NotFound("Not found");
            allStudents.Remove(student);
            return Ok(allStudents);
        }
    }
}
