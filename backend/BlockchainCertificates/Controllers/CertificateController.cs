using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BlockchainCertificates.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace BlockchainCertificates.Controllers
{
    [EnableCors("SiteCorsPolicy")]
    [Route("api/certificate")]
    public class CertificateController : Controller
    {
        private const string FolderId = "5b2075bfba18c95e507cbe6b";
        private const string FolderName = "certificates";
        private const double Accuracy = 95;
        private readonly Mantle.Services _mantle;

        public CertificateController(Task<Mantle.Services> mantle)
        {
            _mantle = mantle.Result;
        }

        [HttpGet("issue/{studentId}")]
        public async Task<IActionResult> IssueCertificate([FromRoute]string studentId)
        {
            var student = await Student.Get(studentId);
            if (student.CertIssued)
            {
                return BadRequest("Certificate already issued");
            }

            var cert = new Certificate($"{student.FirstName} {student.LastName}", student.Program, student.AvgGrade, DateTime.Now).GenerateCert();
            await _mantle.FileManager.Upload(FolderId, student.Id, "certificate.bin", cert, Accuracy);

            FileResult fileResult = new FileContentResult(cert, "image/png");
            return Ok(fileResult);
        }

        [HttpGet("reissue/{studentId}")]
        public async Task<IActionResult> ReIssueCertificate([FromRoute]string studentId)
        {
            var student = await Student.Get(studentId);
            if (!student.CertIssued)
            {
                return BadRequest("Student not graduated");
            }

            var cert = new Certificate($"{student.FirstName} {student.LastName}", student.Program, student.AvgGrade, DateTime.Now).GenerateCert();

            var exists = await _mantle.FileManager.Exists(FolderId, "certificate.bin", cert, Accuracy);

            FileResult fileResult = new FileContentResult(cert, "image/png");
            return exists ? (IActionResult)Ok(fileResult) : BadRequest("Certificate never issued before");
        }

        [HttpPost("verify")]
        public async Task<bool> VerifyCertificate([FromForm]VerifyRequest request)
        {
            using (var ms = new MemoryStream())
            {
                await request.File.CopyToAsync(ms);
                var binaryCert = ms.ToArray();
                return await _mantle.FileManager.Exists(FolderName, "certificate.bin", binaryCert, Accuracy);
            }
        }

        public class VerifyRequest
        {
            [Required]
            public IFormFile File { get; set; }
        }
    }
}