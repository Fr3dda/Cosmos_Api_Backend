using Inlämning1.Models;
using Inlämning1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Inlämning1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssueModelController : ControllerBase
    {
        private readonly SqlHandler<IssueModel> issueModelHandler = new SqlHandler<IssueModel>();


        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await issueModelHandler.GetAsync("SELECT Title, Email, CreatedDate, IssueMessage, IssueStatus FROM IssueModel");
                return new OkObjectResult(result);
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return new BadRequestResult();
        }





        [HttpPost]

        public async Task<IActionResult> Create(IssueModel issueModel)
        {
            try
            {
                await issueModelHandler.CreateAsync("INSERT INTO IssueModels VALUES (@Title, @Email, @CreatedDate, @IssueMessage, @IssueStatus)", issueModel);
                return new OkResult();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return new BadRequestResult();
        }
    }
}
