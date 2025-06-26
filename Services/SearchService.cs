using NetEaseCLI.Model;
namespace NetEaseCLI.Services;

public static class SearchService
{
    private static readonly HttpClient HttpClient = new();

    /// <summary>
    /// 搜索歌曲
    /// </summary>
    /// <param name="keyword"></param>
    /// <param name="limit"></param>
    public static async Task<string> SearchSong(string keyword,int limit = 10)
    {
        object e = new
        {
            s = keyword,
            limit = Convert.ToString(limit),
            csrf_token = ""
        };
        var sign = SignServer.SignServer.Sign(e);

        var from = new FormUrlEncodedContent([
                new KeyValuePair<string, string>("params", sign.Param),
                new KeyValuePair<string, string>("encSecKey", sign.EncSecKey)
            ]
        );

        var request =
            new HttpRequestMessage(HttpMethod.Post, "https://music.163.com/weapi/search/suggest/web?csrf_token=")
            {
                Content = from
            };
        
        try
        {
            var result = await HttpClient.SendAsync(request);
            return await result.Content.ReadAsStringAsync();
        }
        catch (HttpRequestException httpRequestException)
        {
            Console.WriteLine($"Error: {httpRequestException.Message}");
            Console.WriteLine("Please check your network connection.");
        }

        throw new Exception("Http Error");
    }

    /// <summary>
    /// 搜索专辑
    /// </summary>
    /// <param name="keyword"></param>
    public static void SearchAlbum(string keyword)
    {
        
    }

    /// <summary>
    /// 搜索歌手
    /// </summary>
    /// <param name="keyword"></param>
    public static void SearchArtist(string keyword)
    {
        
    }
}