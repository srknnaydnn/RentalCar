using Business.Abstract;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImageController : ControllerBase
    {
        ICarImagesService _carImageService;
        IWebHostEnvironment _webHostEnvironment;

        public CarImageController(ICarImagesService carImageService, IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            _carImageService = carImageService;
        }
        [HttpPost("add")]
        public async Task<string> Add([FromForm] FileUpload objectFile)
        {
            System.IO.FileInfo ff = new System.IO.FileInfo(objectFile.files.FileName);
            string fileExtension = ff.Extension;

            var result = Guid.NewGuid().ToString("N")
                + "_" + DateTime.Now.Month + "_"
                + DateTime.Now.Day + "_"
                + DateTime.Now.Year + fileExtension;
            try
            {
                if (objectFile.files.Length > 0)
                {

                    string path = _webHostEnvironment.WebRootPath + "\\uploads\\";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    using (FileStream fileStream = System.IO.File.Create(path + result))
                    {

                        objectFile.files.CopyTo(fileStream);
                        fileStream.Flush();
                        return "\\uploads\\" + objectFile.files.FileName;

                    }
                }
                else
                {
                    return "Yükleme başarısız!";
                }
            }
            catch (Exception exception)
            {

                return exception.Message;
            }
        }
        }   
}
