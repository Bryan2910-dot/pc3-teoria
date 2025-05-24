using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pc3_teoria.Dto;

namespace pc3_teoria.Interfaces
{
    public interface INewsService
    {
        Task<List<PostWithExtrasDto>> GetEnrichedPostsAsync();
    }
}