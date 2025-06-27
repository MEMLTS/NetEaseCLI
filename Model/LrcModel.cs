namespace NetEaseCLI.Model;

public class LrcModel
{
    private static readonly HttpClient HttpClient = new();

    public static async Task<string?> GetLrc(int id)
    {
        object payload = new {
            id = Convert.ToString(id),
            lv = -1,
            tv = -1,
            csrf_token = ""
        };
    }
}