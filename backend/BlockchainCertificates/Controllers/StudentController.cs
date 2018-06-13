using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlockchainCertificates.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlockchainCertificates.Controllers
{
    [EnableCors("SiteCorsPolicy")]
    [Produces("application/json")]
    [Route("api/student")]
    public class StudentController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody]Student student)
        {
            var newStudent = await student.Save();
            return Ok(newStudent);
        }

        [HttpPut]
        public async Task<IActionResult> EditStudent([FromBody]Student student)
        {
            var newStudent = await (await Student.Get(student.Id)).ChangeProgram(student.Program).Update();
            return Ok(newStudent);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await Student.GetAll();
            return Ok(students);
        }

        [HttpGet("{studentId}")]
        public async Task<IActionResult> GetStudent([FromRoute]string studentId)
        {
            var student = await Student.Get(studentId);
            return Ok(student);
        }
    }
}