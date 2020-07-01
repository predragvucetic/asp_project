using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.DataTransfer
{
    public class UploadImageDto
    {
        public IFormFile Image { get; set; }
    }
}
