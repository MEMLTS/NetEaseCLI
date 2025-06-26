using NetEaseCLI.Services;
using Spectre.Console;


AnsiConsole.Markup("[green]Hello[/] [blue]World[/]!");

var data = await SearchService.SearchSong("创作者之死");

Console.WriteLine(data);