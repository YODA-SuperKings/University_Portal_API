using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.Interface.IServices;
using BusinessLogic.Services;
using BusinessLogic.Model.Models;

namespace University_Admin_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly DocumentService _documentService;
        private readonly StudentService _studentService;

        public DocumentController(DocumentService documentService, StudentService studentService)
        {
            _documentService = documentService;
            _studentService = studentService;
        }

        [HttpGet]
        [Route("GetDocument")]
        public IActionResult GetDocument()
        {
            var student = _studentService.GetStudent().ToList();
            var studentDoc = _documentService.GetDocument().ToList();

            var _studentDocument = from s in student 
                                   join doc in studentDoc 
                                    on s.RegistrationNo equals doc.RegistrationNo 
                            select new
                            { 
                                RegistrationNo = s.RegistrationNo,
                                candidateName = s.FirstName +" "+ s.LastName,
                                Course = s.CourseAppliedType,
                                GraduatedYear =s.GraduatedYear,
                                DocumentType = doc.DocumentType,
                                FilePath = doc.FilePath,
                                Status = doc.Status
                            };
        
            return Ok(_studentDocument);
        }

        [HttpGet]
        [Route("GetDocumentByID")]
        public IActionResult GetDocumentByID(string registrationNo)
        {
            var student = _studentService.GetStudent().Where(s=> s.RegistrationNo == registrationNo).ToList();
            var studentDoc = _documentService.GetDocument().Where(doc=>doc.RegistrationNo == registrationNo).ToList();

            var _studentDocument = from s in student 
                                   join doc in studentDoc 
                                    on s.RegistrationNo equals doc.RegistrationNo 
                                   select new
                                   { 
                                       RegistrationNo = s.RegistrationNo,
                                       candidateName = s.FirstName + " " + s.LastName,
                                       Course = s.CourseAppliedType,
                                       GraduatedYear = s.GraduatedYear,
                                       DocumentType = doc.DocumentType,
                                       FilePath = doc.FilePath
                                   };

            return Ok(_studentDocument);

        }
        [HttpPost]
        [Route("CreateDocument")]
        public IActionResult PostDocument(Document _document)
        {
            string msg = "";
            if (_document != null)
            {
                _document.Status = "Not Verified";
                msg = _documentService.CreateDocument(_document);
            }
            return Ok(msg);
        }

        [HttpPost]
        [Route("UpdateDocument")]
        public IActionResult Update(string registrationCode)
        {
            var document = _documentService.GetDocument().Where(s => s.RegistrationNo == registrationCode).FirstOrDefault();

            if (document is null)
            {
                return NotFound();
            }

            document.Status = "Verified";

            _documentService.Update(document.Id, registrationCode, document);

            return Ok("Document verified successfully");
        }
    }
}
