using AutoMapper;
using Blog.Application.DataTransfer;
using Blog.Application.Exceptions;
using Blog.Application.Queries;
using Blog.Application.Searches;
using Blog.Domain;
using Blog.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Implementation.Queries
{
    public class EfGetOneCategoryQuery : IGetOneCategoryQuery
    {
        private readonly BlogContext _context;
        private readonly IMapper _mapper;

        public EfGetOneCategoryQuery(BlogContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 6;

        public string Name => "Search One Category";

        public CategoryDto Execute(int search)
        {
            var category = _context.Categories.Find(search);

            if (category == null)
            {
                throw new EntityNotFoundException(search, typeof(CategoryDto));
            }

            var response = _mapper.Map<CategoryDto>(category);

            return response;
        }
    }
}
