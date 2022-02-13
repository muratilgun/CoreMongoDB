using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ImageSaveAndReadCoreMongoDB.Models
{
    public class FileUpload
    {
        public IFormFile File { get; set; }
        public string Employee { get; set; }
    }
}
