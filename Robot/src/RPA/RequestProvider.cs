using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace RPA;

public class RequestProvider
{
    private readonly Lazy<HttpClient> _httpClient = new(() =>
    {
        var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        return httpClient;
    }, LazyThreadSafetyMode.ExecutionAndPublication);

    public async Task<TResult?> GetAsync<TResult>(string url)
    {
        var httpClient = _httpClient.Value;
        var response = await httpClient.GetAsync(url).ConfigureAwait(false);

        return await response.Content.ReadFromJsonAsync<TResult>();
    }

    public async Task<TResult?> PutAsync<TResult>(string url, TResult data)
    {
        var httpClient = _httpClient.Value;
        var content = new StringContent(JsonSerializer.Serialize(data));
        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        var response = await httpClient.PutAsync(url, content).ConfigureAwait(false);

        return await response.Content.ReadFromJsonAsync<TResult>();
    }
}
