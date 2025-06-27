using System.Data;
using NetEaseCLI.Model;
using NetEaseCLI.Services;
using Terminal.Gui.App;
using Terminal.Gui.ViewBase;
using Terminal.Gui.Views;

namespace NetEaseCLI.UI;

public sealed class SearchUi : Window
{
    private readonly DataTable _table = new();
    private readonly TableView _resultTable = new();

    public SearchUi()
    {
        Title = $"NetEaseCli Search ({Application.QuitKey} to quit)";

        var searchLabel = new Label()
        {
            Text = "Search: ", 
            X = 2, 
            Y = 1
        };
        var searchTextField = new TextField()
        {
            X = Pos.Right(searchLabel) + 1, 
            Y = Pos.Top(searchLabel), 
            Width = 30
        };
        var searchButton = new Button()
            { 
                Text = "Search", 
                X = Pos.Right(searchTextField) + 2, 
                Y = Pos.Top(searchLabel)
            };
        
        // 初始化表结构
        _table.Columns.Add("#");
        _table.Columns.Add("Song Name");
        _table.Columns.Add("Artists");
        _table.Columns.Add("Album");
        _table.Columns.Add("Duration");

        var tableSource = new DataTableSource(_table);
        _resultTable.X = 2;
        _resultTable.Y = Pos.Bottom(searchLabel) + 1;
        _resultTable.Width = Dim.Fill()! - 4;
        _resultTable.Height = Dim.Fill()! - 2;
        _resultTable.Table = tableSource;

        // 搜索逻辑
        searchButton.Accepting += async (s, e) =>
        {
            var keyword = searchTextField.Text ?? "";
            if (string.IsNullOrWhiteSpace(keyword))
            {
                MessageBox.ErrorQuery("Error", "Search text is empty", "OK");
                return;
            }

            SearchResult? result;
            try
            {
                result = await SearchService.SearchSong(keyword);
            }
            catch (Exception ex)
            {
                MessageBox.ErrorQuery("Error", $"Failed to search: {ex.Message}", "OK");
                return;
            }

            _table.Rows.Clear();

            // 加载新数据
            if (result != null)
            {
                var songs = result.Result.Songs;
                for (var i = 0; i < songs.Count; i++)
                {
                    var song = songs[i];
                    var artistNames = song.Artists != null ? string.Join(", ", song.Artists.Select(a => a.Name)) : "-";
                    var albumName = song.Album?.Name ?? "-";
                    var duration = TimeSpan.FromMilliseconds(song.Duration ?? 0).ToString(@"mm\:ss");

                    _table.Rows.Add(i + 1, song.Name, artistNames, albumName, duration);
                }
            }

            _resultTable.Update(); // 强制刷新表格
            e.Handled = true;
        };

        Add(searchLabel, searchTextField, searchButton, _resultTable);
    }
}