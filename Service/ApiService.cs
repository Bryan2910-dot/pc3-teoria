using System.Net.Http;
using System.Net.Http.Json;
using Newtonsoft.Json;
using pc3_teoria.Models;

public class ApiService {
    private readonly HttpClient _httpClient;

    public ApiService(HttpClient httpClient) {
        _httpClient = httpClient;
    }

    public async Task<List<PostWithExtrasViewModel>> GetPostsAsync() {
        var response = await _httpClient.GetStringAsync("https://localhost:5001/api/news");
        var rawData = JsonConvert.DeserializeObject<List<dynamic>>(response);

        var result = rawData.Select(p => new PostWithExtrasViewModel {
            Id = (int)p.id,
            Title = (string)p.title,
            Body = (string)p.body,
            AuthorName = (string)p.author.name,
            Comments = ((IEnumerable<dynamic>)p.comments).Select(c => (string)c.body).ToList()
        }).ToList();

        return result;
    }

    public async Task<bool> SendFeedbackAsync(int postId, string sentimiento) {
        var feedback = new {
            PostId = postId,
            Sentimiento = sentimiento
        };

        var response = await _httpClient.PostAsJsonAsync("https://localhost:5001/api/feedback", feedback);
        return response.IsSuccessStatusCode;
    }
}
