using Jint;
using NetEaseCLI.Model;

namespace NetEaseCLI.Services.SignServer;

public static class SignServer
{
    private static Engine? _engine;

    public static SignModel Sign(object e)
    {
        var cryptoCode = File.ReadAllText("Services/SignServer/crypto-js.min.js");
        var signCode = File.ReadAllText("Services/SignServer/sign.js");

        _engine = new Engine().Execute(cryptoCode).Execute(signCode);

        var jsResult = _engine.Invoke("sign", e).ToObject();

        dynamic? obj = jsResult;

        if (obj != null)
        {
            return new SignModel
            {
                Param = obj.encText,
                EncSecKey = obj.encSecKey
            };
        }
        
        throw new Exception("Sign failed");
    }
}