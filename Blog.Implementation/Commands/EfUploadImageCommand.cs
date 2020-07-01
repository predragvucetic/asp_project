using Blog.Application.Commands;
using Blog.Application.DataTransfer;
using Blog.Domain;
using Blog.EfDataAccess;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Blog.Implementation.Commands
{
    public class EfUploadImageCommand : IUploadImageCommand
    {
        private readonly BlogContext _context;

        public EfUploadImageCommand(BlogContext context)
        {
            _context = context;
        }

        public int Id => 5;

        public string Name => "Upload Image";

        public void Execute(UploadImageDto request)
        {
            var guid = Guid.NewGuid();
            var extension = Path.GetExtension(request.Image.FileName);

            var newFileName = guid + extension;

            var path = Path.Combine("wwwroot", "images", newFileName);

            using(var fileStream = new FileStream(path, FileMode.Create))
            {
                request.Image.CopyTo(fileStream);
            }

            var image = new Image
            {
                ImageName = newFileName
            };

            _context.Images.Add(image);

            _context.SaveChanges();
        }
    }
}
