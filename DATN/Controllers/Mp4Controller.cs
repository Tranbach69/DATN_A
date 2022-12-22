using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace DATN.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Mp4Controller : ControllerBase
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public Mp4Controller(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        [HttpGet]
        public async Task<IActionResult> GetFileById()
        {
            string path = "C:/Users/TranBach/Downloads/mFWA.mp4";
       

            if (System.IO.File.Exists(path))
            {
                return  File(System.IO.File.OpenRead(path), "application/octet-stream", Path.GetFileName(path));
            }
            return NotFound();
        }
 

    }
}
