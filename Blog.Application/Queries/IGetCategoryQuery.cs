using Blog.Application.DataTransfer;
using Blog.Application.Searches;
using Blog.Application.UseCases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Queries
{
    public interface IGetCategoryQuery : IQuery<CategorySearch, PagedResponse<CategoryDto>>
    {
    }
}
