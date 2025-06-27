using Terminal.Gui.App;
using Terminal.Gui.Views;

namespace NetEaseCLI.UI;

public sealed class MenuUi : Window
{
    public MenuUi()
    {
        Title = $"NetEaseCli Menu ({Application.QuitKey} to quit)";
    }
}