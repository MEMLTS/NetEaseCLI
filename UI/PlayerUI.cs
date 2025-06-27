using Terminal.Gui.App;
using Terminal.Gui.Views;

namespace NetEaseCLI.UI;

public class PlayerUi: Window
{
    public PlayerUi()
    {
        Title = $"NetEaseCli Player ({Application.QuitKey} to quit)";
        var playerList = new ListView();
        var playerLrc = new TextView();
    }
}