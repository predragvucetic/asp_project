using Blog.Application.DataTransfer;
using Blog.Application.Searches;
using Blog.Application.UseCases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Queries
{
    public interface IGetCommentsQuery : IQuery<CommentSearch, PagedResponse<CommentDto>>
    {
    }
}
