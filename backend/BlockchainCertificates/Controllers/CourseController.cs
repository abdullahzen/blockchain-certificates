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
    [Route("api/course")]
    public class CourseController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> CreateCourse([FromBody]Course course)
        {
            var newCourse = await course.Save();
            return Ok(newCourse);
        }

        [HttpPut]
        public async Task<IActionResult> EditCourse([FromBody]Course course)
        {
            var newCourse = await (await Course.Get(course.Id)).ChangeRoom(course.Room, course.Capacity).Update();
            return Ok(newCourse);
        }

        [HttpPost("complete")]
        public async Task<IActionResult> SetCourseCompletion([FromBody]Completion completion)
        {
            await completion.Save();
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCourses()
        {
            var courses = await Course.GetAll();
            return Ok(courses);
        }

        [HttpGet("{courseId}")]
        public async Task<IActionResult> GetCourse([FromRoute]string courseId)
        {
            var course = await Course.Get(courseId);
            return Ok(course);
        }
    }
}