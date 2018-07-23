using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Threading.Tasks;
using BlockchainCertificates.Models;
using mantle.lib.Api;
using mantle.lib.Client;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlockchainCertificates.Controllers
{
    [EnableCors("SiteCorsPolicy")]
    [Route("api/certificate")]
    public class CertificateController : Controller
    {
        private const string FolderId = "5b54e0bfd9c54a000ac3bfd2";
        private const int Accuracy = 95;
        private readonly KeeperApi _mantleKeeper;

        public CertificateController(Task<Configuration> mantleConfig)
        {
            _mantleKeeper = new KeeperApi(mantleConfig.Result);
        }

        [HttpGet("issue/{studentId}")]
        public async Task<IActionResult> IssueCertificate([FromRoute]string studentId)
        {
            var student = await Student.Get(studentId);
            if (student.CertIssued)
            {
                return BadRequest("Certificate already issued");
            }

            student.CertIssued = true;
            student.CertIssueDate = DateTime.Now.ToLongDateString();

            var certificate = new Certificate($"{student.FirstName} {student.LastName}", student.Program, student.AvgGrade, student.CertIssueDate);
            using (var certificateStream = certificate.GenerateCert())
            {
                await _mantleKeeper.KeeperFilesPostAsync(FolderId, certificateStream, student.Id, Accuracy);

                await student.Update();

                FileResult fileResult = new FileContentResult(certificateStream.ToArray(), "image/png");
                return Ok(fileResult);
            }
        }

        [HttpGet("reissue/{studentId}")]
        public async Task<IActionResult> ReIssueCertificate([FromRoute]string studentId)
        {
            var student = await Student.Get(studentId);
            if (!student.CertIssued)
            {
                return BadRequest("Certificate never issued before");
            }

            var certificate = new Certificate($"{student.FirstName} {student.LastName}", student.Program, student.AvgGrade, student.CertIssueDate);
            using (var certificateStream = certificate.GenerateCert())
            {
                var exists = await _mantleKeeper.KeeperFilesExistPostAsync(FolderId, certificateStream, Accuracy);

                FileResult fileResult = new FileContentResult(certificateStream.ToArray(), "image/png");
                return exists.Value ? (IActionResult)Ok(fileResult) : BadRequest("Certificate never issued before");
            }
        }

        [HttpPost("verify")]
        public async Task<bool> VerifyCertificate([FromForm]VerifyRequest request)
        {
            using (var memoryStream = new MemoryStream())
            {
                await request.File.CopyToAsync(memoryStream);
                var isValidCertificate = await _mantleKeeper.KeeperFilesExistPostAsync(FolderId, memoryStream, Accuracy);
                return isValidCertificate ?? false;
            }
        }

        public class VerifyRequest
        {
            [Required]
            public IFormFile File { get; set; }
        }
    }
}