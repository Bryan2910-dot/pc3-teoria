using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pc3_teoria.Dto;
using pc3_teoria.Interfaces;
using pc3_teoria.Models;

namespace pc3_teoria.Service
{
    public class NewsService : INewsService {
    private readonly HttpClient _httpClient;

    public NewsService(HttpClient httpClient) {
        _httpClient = httpClient;
    }

    public async Task<List<PostWithExtrasDto>> GetEnrichedPostsAsync() {
        var posts = await _httpClient.GetFromJsonAsync<List<Post>>("https://jsonplaceholder.typicode.com/posts");
        var users = await _httpClient.GetFromJsonAsync<List<User>>("https://jsonplaceholder.typicode.com/users");
        var comments = await _httpClient.GetFromJsonAsync<List<Comment>>("https://jsonplaceholder.typicode.com/comments");

        var enriched = posts.Select(post => new PostWithExtrasDto {
            Id = post.Id,
            Title = post.Title,
            Body = post.Body,
            Author = users.FirstOrDefault(u => u.Id == post.UserId),
            Comments = comments.Where(c => c.PostId == post.Id).ToList()
        }).ToList();

        return enriched;
    }
}

}