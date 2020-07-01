using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.UseCases
{
    public interface IQuery<TSearch, TResult> : IUseCase
    {
        TResult Execute(TSearch search);
    }
}
